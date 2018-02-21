module vec2d

let len ((x: float),y) =
    sqrt (x*x+y*y)

let ang ((x:float),y) =
    atan2 y x

let scale (a : float) (tup : float * float) : float * float =
    let newTupe = ((fst(tup)*a), (snd(tup)*a))
    newTupe

let add ((x1: float),y1 : float) ((x2 : float),y2 : float) =
    let newTupe = ((x1 + x2), (y1 + y2))
    newTupe

let dot ((x1: float),y1: float) ((x2: float),y2: float) =
    (x1*x2) + (y1*y2)
