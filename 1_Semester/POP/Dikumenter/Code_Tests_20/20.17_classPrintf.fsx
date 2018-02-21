// Listing 20.17 classPrintf.fsx
// Printing classes yields low-level information about the class.

// Objects can be printed directly, but the result is most often not very
// useful as can be seen down-under:

type vectorDefaultToString (x : float, y : float) =
    member this.x = (x,y)

let v = vectorDefaultToString (1.0, 2.0)
printfn "%A" v // Printing objects gives lowlevel information

// All classes are given default member through a process called "inheritance", which will
// be shown in the 21.1 tests.
// When an object is given as argument to a "printf" function, then "printf" calls the
// object, as can be seen in above tests. But we may "override" this member using the
// "override" keyword as demostrated in the next file: classToString.fsx