#r "img_util.dll"

type Point = int * int
type Colour = int * int * int

type Figure =
    | Circle of center:Point * radius:int * color:Colour
    | Rectangle of botLeft:Point * topRight:Point * color:Colour
    | Triangle of p1:Point * p2:Point * p3:Point * color:Colour
    | Mix of Figure * Figure

let rec colourAt (x , y) (figure:Figure) =
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
    | Mix ( f1 , f2 ) ->
        match ( colourAt (x , y ) f1 , colourAt (x , y) f2) with
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
let circleHouse = Circle ((70,20), 10, (255,255,0))
let circleHouse2 = Circle ((330,300), 10, (0,255,0))
let figHouse = Mix (Mix (rectangleHouse, circleHouse), circleHouse2)
makePicture "picture" figHouse 500 500
