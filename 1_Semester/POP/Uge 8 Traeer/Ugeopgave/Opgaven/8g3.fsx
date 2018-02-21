type point = int * int // a point (x, y) in the plane
type colour = int * int * int // (red, green, blue), 0..255

type figure =
    // Circle defined by center, radius, and colour
    | Circle of center:point * radius:int * color:colour
    // Rectangle defined by corners bottom-left, top-right, and colour
    | Rectangle of botleft:point * topRight:point * color:colour
    // Triangle defined 3 points, and colour
    | Triangle of p1:point * p2:point * p3:point * color:colour
    // Combining figures with mixed colour at overlap
    | Mix of figure * figure
