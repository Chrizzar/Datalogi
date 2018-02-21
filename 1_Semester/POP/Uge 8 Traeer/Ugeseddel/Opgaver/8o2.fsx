// Christian Sass Hansen
// Last edited 06/11-2017

// *** Opgave 8o2 ***
type point = int * int // a point (x, y) in the plane
type colour = int * int * int // (red, green, blue), 0..255

type figure =
    | Circle of point * int * colour
        // defined by center, radius, and colour
    | Rectangle of point * point * colour
        // defined by corners bottom-left, top-right, and colour
    | Mix of figure * figure
        // combine figures with mixed colour at overlap

let circle = Circle ((50,50), 45, (255,0,0))
let rectangle = Rectangle ((40,40), (90,110), (255,255,0))
let mix = Mix (circle, rectangle)
