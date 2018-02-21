// Listing 20.3 classTuple.fsx
// Beware: Creating objects from classes with several
// arguments and tuples have the same syntax.

type vectorWTupleArgs (x : float * float) =
    member this.cartesian = x
type vectorWTwoArgs (x : float, y : float) =
    member this.cartesian = (x,y)
let v = vectorWTupleArgs (1.0, 2.0)
let w = vectorWTwoArgs (1.0, 2.0)