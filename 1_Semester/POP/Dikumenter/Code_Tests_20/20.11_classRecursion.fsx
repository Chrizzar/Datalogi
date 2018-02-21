// Listing 20.11 classRecursion.fsx
// Members can recurse without the "rec" keyword and refer to other members regardless
// of their lexicographical scope.

type twice (v : int) =
    static member fac n = if n > 1 then n *(twice.fac (n-1)) else 1 // no rec
    member this.copy = this.twice // no lexicographical scope
    member this.twice = 2*v

let a = twice (2)
let b = twice.fac 3
printfn "%A %A %A" a.copy a.twice b