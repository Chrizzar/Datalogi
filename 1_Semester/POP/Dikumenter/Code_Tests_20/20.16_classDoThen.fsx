// Listing 20.16 classDoThen.fsx
// The optional "do"- and "then" keyword allows for computations before and after the
// primary constructor is called.

// Before the call to the primary constructor, "let" and "do" statements are allowed.
// If code is is to be executed after the primary constructor has been called,
// then it must be preceded by the "then" keyword as shown down-under:

type classDoThen (aValue : float) =
    // "do" is mandatory to execute code in the primary constructor
    do printfn " Primary constructor called"
    // Some calculations
    do printfn " Primary done" (* *)
    new () =
        // "do" is optional in additional constructors
        printfn " Additional constructor called"
        classDoThen (0.0)
        // Use "then" to execute code after construction
        then
            printfn " Additional done"
    member this.value = aValue

printfn "Calling additional constructor"
let v = classDoThen ()                     // Uses line 14 - 20, 9 - 13 (and 21)
printfn "Calling primary constructor"
let w = classDoThen (1.0)                  // Uses line 9 - 13 (and 21)
// This line does not use line 14 - 20, 
// because is given the float (1.0) and
// to access line 9 - 13, the () should
// be leaved empty.