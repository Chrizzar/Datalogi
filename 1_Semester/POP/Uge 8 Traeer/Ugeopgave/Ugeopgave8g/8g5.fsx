// Christian Sass Hansen, Daniel Nathan Krog, Michael Kwaensanthiah Olesen
// Opgave 8g5
// Last edited 28/11-2017

#r "img_util.dll"

type Point = int * int
type Colour = int * int * int

type Figure =
    // Definition of a circle, as center, radius and color
    | Circle of center:Point * radius:int * color:Colour
    // Definition of a rectangle, as bottemleft, topright and color
    | Rectangle of botLeft:Point * topRight:Point * color:Colour
    // Definition of a triangle, as first point, second point and third point
    | Triangle of p1:Point * p2:Point * p3:Point * color:Colour
    // Definition of mixed figure, which mixes to figures on top of each other
    | Mix of Figure * Figure


// XMLdoc header for triarea2:

/// <summary> This function is used to decide whether a point is placed inside a triangle,
///           which it does by calculating the area of a triangle, knowing its corners. </summary>
/// <remarks> Can only be used on triangles <remarks>
/// <param name="p1"> Point (int * int) </param>
/// <param name="p2"> Point (int * int) </param>
/// <param name="p3"> Point (int * int) </param>
/// <returns> The function will return the area of the triangle multiplied by two </returns>
/// <example> The following call: <code> (triarea2 (15,80) (45,80) (85,70)) </code>
/// Will return 2500 </example>

// Definition of the function triarea2, which is the fomular of "area"
// int * int -> int * int -> int * int -> int                                                                             // Signature
let triarea2 (p1:Point) (p2:Point) (p3:Point) : int =                                                                 // Definition
    abs ((fst p1) * ((snd p2) - (snd p3)) + (fst p2) * ((snd p3) - (snd p1)) + (fst p3) * ((snd p1) - (snd p2)))


// XMLdoc header for colourAt:

/// <summary> The function colourAt, will decide the colour of a figure with a given pixel.
///           Where the colour of a pixel depends on whether it is inside a figure or outside a figure.  </summary>
/// <remarks> This function is recursive and calls itself. <remarks>
/// <param name="x"> This is the x-coordinate (int) </param>
/// <param name="y"> This is the y-coordinate (int) </param>
/// <returns> It will return a Colour option </returns>
/// <example> The following call: <code> colourAt (70,20) (Circle ((70,20), 10, (255,255,0))) </code>
/// Will return Some (255, 255, 0) </example>

// Definition of the function colourAt, which will decide the colour of a figure with a given pixel
// int * int -> Figure -> Colour option                                                                   // Signature
let rec colourAt (x, y) (figure:Figure) =                                                             // Definition
    match figure with

    | Circle ((cx, cy) , r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r then
            Some col
        else
            None

    | Rectangle ((x0, y0), (x1, y1), col) ->
        if x <= x1 && x >= x0 && y >= y1 && y <= y0 then
            Some col
        else
            None
    // This will divide the triangle into three smaller triangles, inside the big triangle
    | Triangle ((x1,y1), (x2,y2), (x3,y3), col) ->
            // Calculates the area of triangle 1
        if ((triarea2 (x1,y1) (x2,y2) (x,y)) +
            // Calculates the area of triangle 2
            (triarea2 (x1,y1) (x3,y3) (x,y)) +
            // Calculates the area of triangle 3
            (triarea2 (x2,y2) (x3,y3) (x,y))) <= triarea2 (x1,y1) (x2,y2) (x3,y3) then
            Some col
        else
            None

    | Mix (f1 , f2) ->
        match (colourAt (x , y) f1 , colourAt (x , y) f2) with
        | (None, c) -> c
        | (c , None) -> c
        | (Some (r1, g1, b1), Some (r2, g2, b2)) ->
            Some ((r1 + r2)/2, (g1 + g2)/2, (b1 + b2)/2)


// XMLdoc header for checkColour:

/// <summary> The function checkColour, checks if the colour of the figure is inside the colour interval </summary>
/// <param name="col"> col (int * int * int) </param>
/// <returns> The function returns true if the colour of the figure is inside the colour interval and false if not </returns>
/// <example> The following call: <code> checkColour (256, 255, 255) </code>
/// Will return false </example>

// Definition of checkColour, which checks if the colour of the figure is inside the colour interval
// int * int * int -> bool                                                                               // Signature
let checkColour (col:Colour): bool =                                                               // Definition
    col >= (0,0,0) && col <= (255,255,255)


// XMLdoc header for checkFigure:

/// <summary> The function checkFigure checks if the attributes of the
///     circle, rectangle and triangle maintains correctly assigned
///     values for how the figures are defined as the certain figure. </summary>
/// <param name="figure"> A circle, rectangle and triangel (figure) </param>
/// <returns> true/false </returns>
/// <example> The following call <code> checkFigure Circle ((70,20), 10, (255,255,0)) </code>
///           will return <c> True </c> </example>

// Definition of checkFigure
// 'a -> bool                                                                                          // Signature
let rec checkFigure figure: bool =                                                               // Definition
    match figure with
        // Checks if the radius is non-negative
        | Circle ((cx,cy), r, col) ->
            r >= 0 && checkColour col

        // Checks if the coordinates is placed correctly in relative to the definition "type Figure, Rectangle"
        | Rectangle ((x0,y0), (x1,y1), col) ->
            x0 <= x1 && y0 <= y1 && checkColour col

        // Checks if the coordinates are placed inside the bitmap
        | Triangle ((x0,y0), (x1,y1), (x2,y2), col) ->
            x0 >= 0 && y0 >= 0 &&
            x1 >= 0 && y1 >= 0 &&
            x2 >= 0 && y2 >= 0 &&
            checkColour col

        // Checks if the figures are valid (true/false)
        | Mix (f1, f2) ->
            checkFigure f1 && checkFigure f2


// XMLdoc header for boundingbox:

/// <summary> The function boundingbox, will with a given figure find the corners (top-left, bottom-right)
///           for the smallest axed rectangle containing the entire figure. </summary>
/// <param name="figure"> A circle, rectangle and triangel (figure) </param>
/// <returns> The function returns the coordinates of the points in the top-left and bottom-right corners,
///           around all the figures, as one figure. </returns>
/// <example> The following call: <code> boundingbox rectangleHouse </code>
/// returns ((20, 70), (80, 120)) </example>

// Definition of boundingbox, which given a figure finds the corners (top-left, bottom-right)
// for the smallest axed rectangle containing the entire figure
// Figure -> Point * Point                                                                     // Signature
let rec boundingbox (figure:Figure) : Point * Point =                                    // Definition
    match figure with
    | Circle ((cx, cy) , r, _) ->
        ((cx-r,cy-r), (cx+r,cy+r))

    | Rectangle ((x0, y0), (x1, y1), _) ->
        ((x0,y0), (x1,y1))

    | Triangle ((x1,y1), (x2,y2), (x3,y3), _) ->
        ((min (min x1 x2) x3, min (min y1 y2) y3),
         (max (max x1 x2) x3, max (max y1 y2) y3))

    | Mix (fig1, fig2) ->
        ((min (fst (fst (boundingbox fig1))) (fst (fst (boundingbox fig2))),
          min (snd (fst (boundingbox fig1))) (snd (fst (boundingbox fig2)))),
         (max (fst (snd (boundingbox fig1))) (fst (snd (boundingbox fig2))),
          max (snd (snd (boundingbox fig1))) (snd (snd (boundingbox fig2)))))


// Definition of makePicture, which will create a PNG file from the figures with ImgUtil
// string -> Figure -> itn -> int -> unit                                                         // Signature
let makePicture (fileName : string) (figure : Figure) (width : int) (height : int) =        // Definition
    match checkFigure figure with
    | true ->
        let bmp = ImgUtil.mk width height
        for i=0 to height-1 do
            for j=0 to width-1 do
                match (colourAt (j,i) figure) with
                | Some col -> ImgUtil.setPixel (ImgUtil.fromRgb col) (j,i) bmp
                | None     -> ImgUtil.setPixel (ImgUtil.fromRgb (128,128,128)) (j,i) bmp
        ImgUtil.toPngFile (fileName + ".png") bmp
    | false ->
        printfn "Invalid figure"

let rectangleHouse = Rectangle ((20,70),(80,120),(255,0,0))
let triangleHouse = Triangle ((15,80), (45,40), (85,70), (0,0,255))
let circleHouse = Circle ((70,20), 10, (255,255,0))
let figHouse = Mix (Mix (rectangleHouse, triangleHouse), circleHouse)

(*
printfn "rectangle boundingBox: %A" (boundingbox rectangleHouse)
printfn "triangle boundingBox: %A" (boundingbox triangleHouse)
printfn "circle boundingBox: %A" (boundingbox circleHouse)
*)
printfn "house boundingBox: %A" (boundingbox figHouse)



(*
// Blacbox testing
// (input, Expected output)
let testcases = [
    (1, Some Monday);
    (2, Some Tuesday);
    (3, Some Wednesday);
    (4, Some Thursday);
    (5, Some Friday);
    (6, Some Saturday);
    (7, Some Sunday);
    (8, None);
    ]

let test'day day_function x =
    day_function (fst x) = (snd x)

let test'print_results day_function (x: int * weekday option) =
    let res = test'day day_function x
    printfn "Input: %A.\nExpected %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (day_function (fst x)) res
    res

let test f = List.map (test'print_results f) testcases

let all_tests_passed (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let test_function = test numberToDay |> all_tests_passed

printfn "All tests passed for numberToDay: %b\n" test_function
*)
