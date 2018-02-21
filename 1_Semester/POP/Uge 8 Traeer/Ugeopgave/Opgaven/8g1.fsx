// Christian Sass Hansen
// Opgave 8g.1
// Last edited 06/11-2017
type point = int * int // a point (x, y) in the plane
type colour = int * int * int // (red, green, blue), 0..255

type figure =
    | Circle of point * int * colour
        // defined by center, radius, and colour
    | Rectangle of point * point * colour
        // defined by corners bottom-left, top-right, and colour
    | Mix of figure * figure // * figure
        // combine figures with mixed colour at overlap
    | Triangle of point * point * point * colour
        // defined by the three points and colour

let rectangleHouse = Rectangle ((20,120), (80,70), (255,0,0))

let triangleHouse = Triangle ((15,80), (45,30), (85,70), (0,0,255))

let circleHouse = Circle ((70,20), 10, (255,255,0))

let figHouse = Mix (Mix (rectangleHouse, triangleHouse), circleHouse)

(*
// finds colour of figure at point
let rec colourAt (x,y) figure =
    match figure with
    | Circle ((cx,cy), r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r
            // uses Pythagoras' formular to determine
            // distance to center
        then Some col else None
    | Rectangle ((x0,y0), (x1,y1), col) ->
        if x0<=x && x <= x1 && y0 <= y && y <= y1
            // within corners
        then Some col else None
    | Mix (f1, f2) ->
        match (colourAt (x,y) f1, colourAt (x,y) f2) with
        | (None, c) -> c // no overlap
        | (c, None) -> c // no -overlap
        | (Some (r1,g1,b1), Some (r2,g2,b2)) ->
            // average color
            Some ((r1+r2)/2, (g1+g2)/2, (b1+b2)/2)
*)

let bmp = ImgUtil.mk 256 256
do ImgUtil.setPixel ()


// let bmp = ImgUtil.mk 256 256
// do ImgUtil.setPixel (ImgUtil.fromRgb (255,255,0)) (10,10) bmp
// do ImgUtil.toPngFile "test.png" bmp
