// Christian Sass Hansen, Daniel Nathan Krog, Michael Kwaensanthiah Olesen
// Opgave 8g1
// Last edited 28/11-2017

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

let rectangleHouse = Rectangle ((20,120),(80,70),(255,0,0))
let triangleHouse = Triangle ((15,80), (45,40), (85,70), (0,0,255))
let circleHouse = Circle ((70,20), 10, (255,255,0))
let figHouse = Mix (Mix (rectangleHouse, triangleHouse), circleHouse)
