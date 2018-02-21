// Listing 20.9 classCopy.fsx
// A copy method is often needed. Compare with Listing 20.8

// You should think of objects as arrays. For this reason, it is often
// seen that classes implement a copy function, returning a new object
// with copied values, e.g., Listing 20.9 shown down-under.

type aClass () =
    let mutable v = 0
    member this.value with get () = v and set (a) = v <- a
    member this.copy () =
        let o = aClass ()
        o.value <- v
        o

let a = aClass ()
let b = a.copy ()

// Inserting 2
a.value <- 2
printfn "%d %d" a.value b.value

// Inserting 3
a.value <- 3
printfn "%d %d" a.value b.value

// In the example, we see that since "b" now is a copy, we do not change
// it by changing a. This is called a "copy constructor".