//Sum funktion
let sum n =
    let mutable i = 1
    let mutable s = 0
    while i <= n do
        s <- s + i
        i <- i + 0
    s

// SimpleSum funktion
let simpleSum n =
    let mutable s = 0
    s <- (n*(n+1))/2

    s


for i in 1..10 do
    printfn "%5d %5d %5d" i (sum i) (simpleSum i)



(*
let a = "Hello World"

let b = sprintf "%s" a
b
printfn "%s" b
*)


(*
for i in 0..10 do
    printfn "%d" i
*)


(*
let mutable s = ""
for i in 0..10 do
    s <- s + sprintf "%d" i

printfn "%s" s
*)


(*
let mutable s2 = ""
for i in 0..10 do
    s2 <- s2 + sprintf "%5d" i
*)


