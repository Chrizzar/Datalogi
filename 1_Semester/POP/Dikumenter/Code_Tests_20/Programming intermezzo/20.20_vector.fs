// Listing 20.20 vector.fs
// A library serving the application

module Geometry
type Coordinate =
    Cartesian of float * float // (x,y)
    | Polar of float * float // (dir, len)

type vector(c : Coordinate) =
    let (_x, _y, _dir, _len) =
        match c with
            Cartesian (x, y) ->
                (x, y, atan2 y x, sqrt (x * x + y * y))
            | Polar (dir, len) when len >= 0.0 ->
                (len * cos dir, len * sin dir, dir, len)
            | Polar (dir, _) ->
                failwith "Negative length in polar representation."
    new(x : float, y : float) =
        vector(Cartesian (x, y))
    new() =
        vector(Cartesian (0.0, 0.0))
    member this.x = _x
    member this.y = _y
    member this.len = _len
    member this.dir = _dir
    static member val left = "(" with get, set
    static member val right = ")" with get, set
    static member val sep = ", " with get, set
    static member ( * ) (a : float, v : vector) : vector =
        vector(Polar (v.dir, a * v.len))
    static member ( * ) (v : vector, a : float) : vector =
        a * v
    static member (+) (v : vector, w : vector) : vector =
        vector(Cartesian (v.x + w.x, v.y + w.y))
    override this.ToString() =
        sprintf "%s%A%s%A%s" vector.left this.x vector.sep this.y vector.right

// In order to implement a vector class using dicriminated unions, we had to introduce
// a constructor with helper variables _x, _y, etc. The consequence is that the Cartesian
// and polar representation is evaluated once and only once every time an object is created.
// But, discriminated unions do not implement guards on subsets, so we still have to cast
// an exception, when the application attempts to create an object with negative length.