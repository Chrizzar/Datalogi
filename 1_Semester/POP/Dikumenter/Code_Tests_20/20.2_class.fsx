// Listing 20.2 class.fsx
// A class definition and an object of this class

type aClass (anArgument : int) =
    // Constructor body section
    let objectValue = anArgument
    do printfn "A class has been created (%A)" objectValue
    // Member section
    member this.value = anArgument
    member this.scale (factor : int) = factor * objectValue

// Two obejcts a and b of type aClass are created, which implies
// that memory is reserved on The Heap, and the constructor is run
// for each of them.
let a = aClass (2)
let b = aClass (1)

// For a, this.value refers to the memory set aside for a,
// and b, this.value refers to the memory set aside for b.
printfn "%d %d %d" a.value (a.scale 3) b.value