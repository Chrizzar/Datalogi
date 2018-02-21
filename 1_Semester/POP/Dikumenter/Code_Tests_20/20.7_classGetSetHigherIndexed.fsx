// Listing 20.7 classGetSetHigherIndexed.fsx
// Properties can act as index variables with the built-in getter and setter functions.

// Higher dimensional indexed properties are defined by adding more indexing arguments
// to the definition of "get" and "set" such as demostrated in down-under:

type aClass (rows : int, cols : int) =
    let arr = Array2D.create<int> rows cols 0
    member this.Item
        with get (i : int, j : int) = arr.[i,j]
        and set (i : int, j : int) (p : int) = arr.[i,j] <- p

let a = aClass (3, 3)
printfn "%A" a
printfn "%d %d %d" a.[0,0] a.[0,1] a.[2,1]
// Inserting the integer 3 on index [0,1] in a 
a.[0,1] <- 3
printfn "%d %d %d" a.[0,0] a.[0,1] a.[2,1]
// Inserting the integer 1 on index [0,0] in a 
a.[0,0] <- 1
printfn "%d %d %d" a.[0,0] a.[0,1] a.[2,1]