// Christian Sass Hansen, Daniel Nathan Krog, Michael Kwaensanthiah Olesen
// Assignment 8g5
// Last edited 29/11-2017

// Assignment: Where to find em
// 8g1: line 224-229
// 8g2: line 20-39 
// 8g3: line 42-90
// 8g4: figHouse.png, generated on line 234-236
// 8g5: lines 111-209
// Blackbox tests : line 243+
//#r "img_util.dll"

type Point = int * int
type Colour = int * int * int

type Figure =
    | Circle of center:Point * radius:int * color:Colour
    | Rectangle of leftCorner:Point * rightCorner:Point * color:Colour
    | Triangle of p1:Point * p2:Point * p3:Point * color:Colour
    | Mix of Figure * Figure

/// <--- 8g2 start --->
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
// int * int -> int * int -> int * int -> int                                               // Signature
let triarea2 (p1:Point) (p2:Point) (p3:Point) : int =                                       // Definition
    abs ((fst p1) * ((snd p2) - (snd p3)) +
         (fst p2) * ((snd p3) - (snd p1)) +
         (fst p3) * ((snd p1) - (snd p2)))
// <--- 8g2 end --->

// <--- 8g3 start --->
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
// int * int -> Figure -> Colour option                                                     // Signature
let rec colourAt (x, y) (figure:Figure) =                                                   // Definition
    match figure with

    | Circle ((cx, cy) , r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r then
            Some col
        else
            None

    | Rectangle ((x0, y0), (x1, y1), col) ->
        if x0 <= x && x <= x1 && y0 <= y && y <= y1 then
            Some col
        else if x0 <= x && x <= x1 && y1 <= y && y <= y0 then
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
// <--- 8g3 end --->

// XMLdoc header for checkColour:

/// <summary> The function checkColour, checks if the colour of the figure is inside the colour interval </summary>
/// <param name="col"> col (int * int * int) </param>
/// <returns> The function returns true if the colour of the figure is inside the colour interval and false if not </returns>
/// <example> The following call: <code> checkColour (256, 255, 255) </code>
/// Will return false </example>

// Definition of checkColour, which checks if the colour of the figure is inside the colour interval
// int * int * int -> bool                                                                  // Signature
let checkColour (col : Colour): bool =                                                        // Definition
    match col with
    | (r,g,b) ->
        0 <= r && r <= 255 &&
        0 <= g && g <= 255 &&
        0 <= b && b <= 255

// <--- 8g5 start --- >
// XMLdoc header for checkFigure:

/// <summary> The function checkFigure checks if the attributes of the
///     circle, rectangle and triangle maintains correctly assigned
///     values for how the figures are defined as the certain figure. </summary>
/// <param name="figure"> A circle, rectangle and triangel (figure) </param>
/// <returns> true/false </returns>
/// <example> The following call <code> checkFigure Circle ((70,20), 10, (255,255,0)) </code>
///           will return <c> True </c> </example>

// Definition of checkFigure
// 'a -> bool                                                                               // Signature
let rec checkFigure figure: bool =                                                          // Definition
    match figure with
        | Circle ((cx,cy), r, col) ->
            cx >= 0 && cy >= 0 &&
            r > 0 && checkColour col

        | Rectangle ((x0,y0), (x1,y1), col) ->
            // (x,y) greater than zero
            y0 >= 0 && y1 >= 0 &&
            x0 >= 0 && x1 >= 0 &&
            // check if points correspond to top-left and bottom-left / top-right and bottom right
            not (x0 = x1 && (y0 <= y1 || y0 >= y1)) &&
            // check if points correspond to top-left and top right / bottom-left and bottom right
            not (y0 = y1 && (x0 <= x1 || x0 >= x1)) &&
            x0 <= x1 && checkColour col

        // Checks if the coordinates are placed inside the bitmap
        | Triangle ((x0,y0), (x1,y1), (x2,y2), col) ->
            x0 >= 0 && y0 >= 0 &&
            x1 >= 0 && y1 >= 0 &&
            x2 >= 0 && y2 >= 0 &&
            checkColour col

        // Checks if both figures are valid (recursive definition)
        | Mix (f1, f2) ->
            checkFigure f1 && checkFigure f2

// XMLdoc header for boundingbox:

/// <summary> The function boundingbox, will with a given figure find the corners (top-left, bottom-right)
///           for the smallest axed rectangle containing the entire figure. </summary>
/// <param name="figure"> A circle, rectangle and triangel (figure) </param>
/// <remarks> a return value of ((-1,-1), (-1,-1)) means the Rectangle 
///           (by itself or in the Mix) was invalid </remarks>
/// <returns> The function returns the coordinates of the points in the top-left and bottom-right corners,
///           around all the figures, as one figure. </returns>
/// <example> The following call: <code> boundingbox rectangleHouse </code>
/// returns ((20, 70), (80, 120)) </example>

// Definition of boundingbox, which given a figure finds the corners (top-left, bottom-right)
// for the smallest axed rectangle containing the entire figure
// Figure -> Point * Point                                                                  // Signature
let rec boundingbox (figure:Figure) : Point * Point =                                       // Definition
    match figure with
    | Circle ((cx, cy) , r, _) ->
        if checkFigure figure then
            ((cx-r,cy-r), (cx+r,cy+r))
        else
            ((-1,-1),(-1,-1))

    | Rectangle ((x0, y0), (x1, y1), _) ->
        // Ambiguous definiton of Rectangle in assignment. Can either be top-left and bottom-right (in 8g0), 
        // or top-right, bottom-left (in Figure type definition)
        // check if the rectangle consists of points: top-left, bottom-right
        if checkFigure figure && y0 <= y1 then
            ((x0,y0), (x1,y1))
        // else it consists of points: top-right, bottom-left, and y-cordinates are swapped
        else if checkFigure figure && y0 >= y1 then
            ((x0,y1), (x1,y0))
        // Any combination of points other than botton-left - top-right and bottom-right - top-left
        // we count as invalid Rectangles, and return ((-1,-1), (-1,-1))
        else
            ((-1,-1), (-1,-1))

    | Triangle ((x1,y1), (x2,y2), (x3,y3), _) ->
        if checkFigure figure then
            // find smallest vaue of x and y
            ((min (min x1 x2) x3, min (min y1 y2) y3),
            // find the largest value of x and y
             (max (max x1 x2) x3, max (max y1 y2) y3))
        else
            ((-1,-1), (-1,-1))

    | Mix (fig1, fig2) ->
        // If a rectangle is within the mix, and it is invalid, the whole Mix figure becomes invalid
        if boundingbox fig1 = ((-1,-1), (-1,-1)) || boundingbox fig2 = ((-1,-1), (-1,-1)) then
            ((-1,-1), (-1,-1))
        else
            // by use of recursion, compare the bounding boxes of both figures, and find smallest (x,y)
            ((min (fst (fst (boundingbox fig1))) (fst (fst (boundingbox fig2))),
              min (snd (fst (boundingbox fig1))) (snd (fst (boundingbox fig2)))),

            // find biggest (x,y) afterwards with same method
             (max (fst (snd (boundingbox fig1))) (fst (snd (boundingbox fig2))),
              max (snd (snd (boundingbox fig1))) (snd (snd (boundingbox fig2)))))
// <--- 8g5 end -->

// Definition of makePicture, which will create a PNG file from the figures with ImgUtil
// string -> Figure -> itn -> int -> unit                                                   // Signature
let makePicture (fileName : string) (figure : Figure) (width : int) (height : int) =        // Definition
    match checkFigure figure with
    | true ->
        let bmp = ImgUtil.mk width height
        // iterate through every point in bitmap
        for i=0 to height-1 do
            for j=0 to width-1 do
                match (colourAt (j,i) figure) with
                | Some col -> ImgUtil.setPixel (ImgUtil.fromRgb col) (j,i) bmp
                | None     -> ImgUtil.setPixel (ImgUtil.fromRgb (128,128,128)) (j,i) bmp
        ImgUtil.toPngFile (fileName + ".png") bmp
    | false ->
        printfn "Invalid figure"

// <--- 8g1 start --->
let rectangleHouse = Rectangle ((80,120),(20,70),(255,0,0))
let triangleHouse = Triangle ((15,80), (45,40), (85,70), (0,0,255))
let circleHouse = Circle ((70,20), 10, (255,255,0))
let figHouse = Mix (Mix (rectangleHouse, triangleHouse), circleHouse)
// <--- 8g1 end -->

// <--- 8g4 start -->
makePicture "figTest" figHouse 100 150
// <--- 8g4 end --->

// <-- 8g5 start --->
printfn "house boundingBox: %A\n" (boundingbox figHouse)
// <--- 8g5 end --->


// <-------------------------------- Start of Blackbox tests -------------------------------->
// list of valid cases                                // Valid case # description
let validFigureList = [                                                           
    Rectangle ((10,10),(100,100),(255,0,0));          // 0. Rectangle ((top-left), (bottom-right), red)
    Rectangle ((10,100),(100,10),(255,0,0));          // 1. Rectangle ((top-right), (bottom-left), red)
    Triangle ((10,20), (4,4), (25,9), (0,0,255));     // 2. Valid Triangle
    Circle ((40,35), 10, (0,255,0))                   // 3. Valid Circle
]

// list of invalid cases                              // Invalid case # and description
let invalidFigureList = [
    Rectangle ((-10,10),(100,100),(255,0,0));         // 0. Rectangle defined with negative x-cordinate(s)
    Rectangle ((10,-10),(100,100),(255,0,0));         // 1. Rectangle defined with negative y-cordinate(s)
    Rectangle ((10,10),(100,100),(300,0,0));          // 2. Colour of Rectangle larger than 255 
    Rectangle ((10,10),(100,100),(-100,0,0));         // 3. Colour of Rectangle less than 0
    Rectangle ((10,10),(10,100),(255,0,0));           // 4. Rectangle defined with top-left and bottom-left points
    Rectangle ((100,10),(100,100),(255,0,0));         // 5. Rectangle defined with top-right and bottom-right points
    Rectangle ((10,10),(100,10),(255,0,0));           // 6. Rectangle defined with top-left and top-right points
    Rectangle ((10,100),(100,100),(255,0,0));         // 7. Rectangle defined with bottom-left and bottom-right points
    
    Triangle ((-10,20), (4,4), (25,9), (0,0,255));    // 8. Triangle defined with negative x-cordinate(s)
    Triangle ((10,-20), (4,4), (25,9), (0,0,255));    // 9. Triangle defined with negative y-cordinate(s)
    Triangle ((10,20), (4,4), (25,9), (0,0,1000));    // 10. Colour of Triangle larger than 255 
    Triangle ((10,20), (4,4), (25,9), (0,0,-1));      // 11. Colour of Triangle less than 0 

    Circle ((-40,35), 10, (0,255,0))                  // 12. Circle defined with negative x cordinate of center
    Circle ((40,-35), 10, (0,255,0))                  // 13. Circle defined with negative y cordinate of center
    Circle ((40,35), -10, (0,255,0))                  // 14. Circle defined with negative radius 
    Circle ((40,35), 10, (0,400,0))                   // 15. Colour of Circle larger than 255
    Circle ((40,35), 10, (0,-400,0))                  // 16. Colour of Circle less than 0
]

// list of testCases for colourAt                                // Cases tested
// (input, Expected output)
let colourAtTestcases = [
    (((0,0), List.item 0 validFigureList), None);                // Point outside of Rectangle
    (((10,10), List.item 0 validFigureList), Some (255,0,0));    // Point on edge of Rectangle 
    (((50,50), List.item 0 validFigureList), Some (255,0,0));    // Point inside of Rectangle

    (((0,0), List.item 2 validFigureList), None);                // Point outside of Triangle 
    (((25,9), List.item 2 validFigureList), Some (0,0,255));     // Point on edge of Triangle 
    (((12,12), List.item 2 validFigureList), Some (0,0,255));    // Point inside of Triangle 

    (((0,0), List.item 3 validFigureList), None);                // Point outside of Circle
    (((50,35), List.item 3 validFigureList), Some (0,255,0));    // Point on edge of Circle
    (((40,35), List.item 3 validFigureList), Some (0,255,0));    // Point inside Circle
]

// list of testcases for checkFigure                                                  // Cases tested
let checkFigureTestCases = [
    (List.item 0 invalidFigureList, false); (List.item 1 invalidFigureList, false);   // invalid case 0. & 1.
    (List.item 2 invalidFigureList, false); (List.item 3 invalidFigureList, false);   // invalid case 2. & 3.
    (List.item 4 invalidFigureList, false); (List.item 5 invalidFigureList, false);   // invalid case 4. & 5.
    (List.item 6 invalidFigureList, false); (List.item 7 invalidFigureList, false);   // invalid case 6. & 7.
    (List.item 8 invalidFigureList, false); (List.item 9 invalidFigureList, false);   // invalid case 8. & 9.
    (List.item 10 invalidFigureList, false); (List.item 11 invalidFigureList, false); // invalid case 10. & 11.
    (List.item 12 invalidFigureList, false); (List.item 13 invalidFigureList, false); // invalid case 12. & 13.
    (List.item 14 invalidFigureList, false); (List.item 15 invalidFigureList, false); // invalid case 14. & 15.
    (List.item 16 invalidFigureList, false)                                           // invalid case  16.

    (List.item 0 validFigureList, true); (List.item 1 validFigureList, true);         // valid case 0. & 1.
    (List.item 2 validFigureList, true); (List.item 3 validFigureList, true);         // valid case 2. & 3.
]

// list of testcases for boundingBox                                                                              // Cases tested
let boundingBoxTestCases = [
    (List.item 0 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 1 invalidFigureList, ((-1,-1), (-1,-1)));     // invalid case 0. & 1.
    (List.item 2 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 3 invalidFigureList, ((-1,-1), (-1,-1)));     // invalid case 2. & 3.
    (List.item 4 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 5 invalidFigureList, ((-1,-1), (-1,-1)));     // invalid case 4. & 5.
    (List.item 6 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 7 invalidFigureList, ((-1,-1), (-1,-1)));     // invalid case 6. & 7.
    (List.item 8 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 9 invalidFigureList, ((-1,-1), (-1,-1)));     // invalid case 8. & 9.
    (List.item 10 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 11 invalidFigureList, ((-1,-1), (-1,-1)));   // invalid case 10. & 11.
    (List.item 12 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 13 invalidFigureList, ((-1,-1), (-1,-1)));   // invalid case 12. & 13.
    (List.item 14 invalidFigureList, ((-1,-1), (-1,-1))); (List.item 15 invalidFigureList, ((-1,-1), (-1,-1)));   // invalid case 14. & 15.
    (List.item 16 invalidFigureList, ((-1,-1), (-1,-1)))                                                          // invalid case  16.

    ((List.item 0 validFigureList), ((10,10), (100,100))); ((List.item 1 validFigureList), ((10,10), (100,100))); // valid case 0. & 1.
    ((List.item 2 validFigureList), ((4,4), (25,20))); ((List.item 3 validFigureList), ((30,25), (50,45)));       // Valid case 2. & 3.

]

// Blacbox testfunctions for colourAt
printfn "Beginning tests for colourAt\n"
let test'colour colourFunction x =
    colourFunction (fst (fst x)) (snd (fst x)) = (snd x)

let test'printResultsColour colourFunction (x : (Point * Figure) * Colour option) =
    let res = test'colour colourFunction x
    printfn "Input: %A.\nExpected: %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (colourFunction (fst (fst x)) (snd (fst x))) res
    res

let testColourAt f = List.map (test'printResultsColour f) colourAtTestcases 

let allTestsPassedColour (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let testFunctionColour = testColourAt colourAt |> allTestsPassedColour

printfn "All tests passed for colourAt: %b\n" testFunctionColour

// Blackbox testfunctions for checkFigure
printfn "Beginning test for checkFigure\n"
let test'check checkFunction x =
    checkFunction (fst x) = (snd x)

let test'printResultsCheck checkFunction (x : Figure * bool) =
    let res = test'check checkFunction x
    printfn "Input: %A.\nExpected: %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (checkFunction (fst x)) res
    res

let testCheckFigure f = List.map (test'printResultsCheck f) checkFigureTestCases 

let allTestsPassedCheck (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let testFunctionCheck = testCheckFigure checkFigure|> allTestsPassedCheck

printfn "All tests passed for checkFigure: %b\n" testFunctionCheck

// Blackbox testfunctions for boundingBox
printfn "Beginning test for boundingBox\n"
let test'bounding boundingFunction x =
    boundingFunction (fst x) = (snd x)

let test'printResultsBounding boundingFunction (x : Figure * (Point * Point)) =
    let res = test'bounding boundingFunction x
    printfn "Input: %A.\nExpected: %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (boundingFunction (fst x)) res
    res

let testBoundingBox f = List.map (test'printResultsBounding f) boundingBoxTestCases

let allTestsPassedBounding (results: bool list) =
    List.fold (fun x acc -> x && acc) true results
let testFunctionBounding = testBoundingBox boundingbox |> allTestsPassedBounding
printfn "All tests passed for and boundingBox: %b\n" testFunctionBounding 
printfn "All tests passed for colourAt, checkFigure and boundingBox: %b\n" (testFunctionBounding && testFunctionColour && testFunctionCheck)

// end of file