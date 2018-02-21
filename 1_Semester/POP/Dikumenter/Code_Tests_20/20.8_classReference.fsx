// Listing 20.8 classReference.fsx
// Objects are reference types means assignment is aliasing.

type aClass () =
    let mutable v = 0
    member this.value with get () = v and set (a) = v <- a

let a = aClass ()
let b = a
a.value <- 2
printfn "%d %d" a.value b.value
a.value <- 3
printfn "%d %d" a.value b.value

// The binding to "b" in line 9 is an alias to "a", not a copy,
// and changing object "a" also changes b!