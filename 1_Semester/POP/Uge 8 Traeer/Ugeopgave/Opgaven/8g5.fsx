#r "img_util.dll"

// Laver 3 funktioner checkFigure, checkColour, checkPoint
type Point = int * int // a point (x, y) in the plane
type Colour = int * int * int // (red, green, blue), 0..255

type Figure =
    | Circle of center:Point * radius:int * color:Colour
    | Rectangle of botLeft:Point * topRight:Point * color:Colour
    | Triangle of p1:Point * p2:Point * p3:Point * color:Colour
   // | Mix of Figure * Figure

let checkColour (col:Colour): bool =
    col >= (0,0,0) && col <= (255,255,255)

let rec checkFigure figure: bool =
    match figure with
    | Circle ((cx,cy), r, col) ->
        r >= 0 && checkColour col

    | Rectangle ((x0, y0), (x1, y1), col) ->
        x0 <= x1 && y0 <= y1 && checkColour col

    | Triangle ((x0, y0), (x1,y1), (x2,y2), col) ->
        x0 >= 0 && y0 >= 0 &&
        x1 >= 0 && y1 >= 0 &&
        x2 >= 0 && y2 >= 0 &&
        checkColour col

    //| Mix (f1, f2) ->



let boundingBox figure: Point * Point =
