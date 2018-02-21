// Listing 20.6 classGetSetIndexed.fsx
// Properties can act as index variables with the built-in getter and setter functions.

// Defining an Item property with extended "get" and "set" makes objects
// act as indexed variables as demostrated down-under:

type aClass (size : int) =
    let arr = Array.create<int> size 0
    member this.Item
        with get (ind : int) = arr.[ind]
        and set (ind : int) (p : int) = arr.[ind] <- p

let a = aClass (3)
printfn "%A" a
printfn "%d %d %d" a.[0] a.[1] a.[2]
// Inserting the integer 3 on index 1 in a
a.[1] <- 3
printfn "%d %d %d" a.[0] a.[1] a.[2]
// Inserting the integer 5 on index 2 in a
a.[2] <- 5
printfn "%d %d %d" a.[0] a.[1] a.[2]