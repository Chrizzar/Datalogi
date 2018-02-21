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
    | Mix of figure * figure
        // combine figures with mixed colour at overlap
    | Triangle of point * point * point * colour
        // defined by the three points and colour

let figHouse bmp len (x1,y1) (x2,y2) =
