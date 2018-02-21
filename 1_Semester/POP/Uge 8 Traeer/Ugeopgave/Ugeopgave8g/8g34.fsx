// Christian Sass Hansen, Daniel Nathan Krog, Michael Kwaensanthiah Olesen
// Opgave 8g34
// Last edited 28/11-2017

#r "img_util.dll"

type Point = int * int
type Colour = int * int * int

type Figure =
    | Circle of center:Point * radius:int * color:Colour
    | Rectangle of botLeft:Point * topRight:Point * color:Colour
    | Triangle of p1:Point * p2:Point * p3:Point * color:Colour
    | Mix of Figure * Figure

// XMLdoc header for triarea2:

/// <summary> This function is used to decide whether a point is placed inside a triangle,
///           which it does by calculating the area of a triangle, knowing its coners. </summary>
/// <remarks> Can only be used on triangles  <remarks>
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


let makePicture (fileName : string) (figure : Figure) (width : int) (height : int) =
    let bmp = ImgUtil.mk width height
    for i=0 to height-1 do
        for j=0 to width-1 do
            match (colourAt (j,i) figure) with
            | Some col -> ImgUtil.setPixel (ImgUtil.fromRgb col) (j,i) bmp
            | None     -> ImgUtil.setPixel (ImgUtil.fromRgb (128,128,128)) (j,i) bmp
    ImgUtil.toPngFile (fileName + ".png") bmp

let rectangleHouse = Rectangle ((20,120),(80,70),(255,0,0))
let triangleHouse = Triangle ((15,80), (45,40), (85,70), (0,0,255))
let circleHouse = Circle ((70,20), 10, (255,255,0))
let figHouse = Mix (Mix (rectangleHouse, triangleHouse), circleHouse)

makePicture "figTest" figHouse 100 150
