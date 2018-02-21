// Listing 20.12 classAssymetry.fsx
// Mutally recursive classes are defined using the "and" keyword

type anInt (v : int) =
    member this.value = v
    member this.add (w : aFloat) : aFloat = aFloat ((float this.value) + w.value)
and aFloat (w : float) =
    member this.value = w
    member this.add (v : anInt) : aFloat = aFloat ((float v.value) + this.value)

let a = anInt (2)
let b = aFloat (3.2)
let c = a.add b
let d = b.add a
printfn "%A %A %A %A" a.value b.value c.value d.value

// Here "anInt" and "aFloat" hold an integer and a floating point value respectivel,
// and they both implement an addition of "anInt" and "aFloat" that returns aFloat.
// Thus, they are mutally dependent and must be defined in the same "type" definition 
// using "and".