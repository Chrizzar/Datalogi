// Christian Sass Hansen
// Last edited 06/11-2017

// *** Opgave 8o3 ***
#r "img_util.dll"

type point = int * int // a point (x, y) in the plane
type colour = int * int * int // (red, green, blue), 0..255

type figure =
    | Circle of center:point * radius:int * color:colour
        // defined by center, radius, and colour
    | Rectangle of botleft:point * topRight:point * color:colour
        // defined by corners bottom-left, top-right, and colour
    | Mix of figure * figure
        // combine figures with mixed colour at overlap

// finds colour of figure at point
let rec colourAt (x,y) (figure:figure) =
    match figure with
    | Circle ((cx,cy), r, col) ->
        if (x-cx)*(x-cx)+(y-cy)*(y-cy) <= r*r then
            // uses Pythagoras' formular to determine
            // distance to center
            Some col
        else
            None
    | Rectangle ((x0,y0), (x1,y1), col) ->
        if x0 <= x1 && x <= x1 && y0 <= y && y <= y1 then
            // within corners
            Some col
        else
            None
    | Mix (f1, f2) ->
        match (colourAt (x,y) f1, colourAt (x,y) f2) with
        | (None, c) -> c // no overlap
        | (c, None) -> c // no overlap
        | (Some (r1,g1,b1), Some (r2,g2,b2)) ->
            // average color
            Some ((r1+r2)/2, (g1+g2)/2, (b1+b2)/2)

let makePicture (fileName : string) (figure : figure) (width : int) (height : int) =
    let bmp = ImgUtil.mk width height
    for i=0 to height-1 do
        for j=0 to width-1 do
            match (colourAt (j,i) figure) with
            | Some col -> ImgUtil.setPixel (ImgUtil.fromRgb col) (j,i) bmp
            | None     -> ImgUtil.setPixel (ImgUtil.fromRgb (128,128,128)) (j,i) bmp
    ImgUtil.toPngFile (fileName + ".png") bmp

let rectangle = Rectangle ((40,40), (90,110), (255,0,0))
let circle = Circle ((50,50), 45, (255,0,0))
let mixFig = Mix (rectangle, circle)
makePicture "8o3" mixFig 100 150
