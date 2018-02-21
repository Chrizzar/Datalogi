/// Christian Sass Hansen
/// Task 10o0
/// Last edited: 08/12 - 2017

// Implicit method of implementing a class
type Counter() = class
    let mutable count = 0
    member this.Get () = count // Med paranter () : Funktion
    member this.Incr () = count <- count + 1 // Ingen parantes : Datafelt
end

// TESTING
let counting = new Counter() // <- man behøver ikke at skrive "new" foran "Counter" i F#
printfn "Count Start: %A" counting.Get
counting.Incr
printfn "New Count: %A" counting.Get
