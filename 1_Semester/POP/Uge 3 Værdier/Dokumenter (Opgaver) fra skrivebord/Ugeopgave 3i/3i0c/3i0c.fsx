// Christian Sass Hansen
// 3i0c
// Last modified: 27/09 - 2017

// Her tager jeg funktionerne fra opgave 3i0a og 3i0b:
// Sum funktion
let sum n =
    let mutable i = 1
    let mutable s = 0
    while i <= n do
        s <- s + i
        i <- i + 1
    s

// SimpleSum funktion
let simpleSum n =
    let mutable s = 0
    s <- (n*(n+1))/2

    s

// Her laver jeg en for-løkke der tager i fra 1 til 10, hvilket betyder at jeg laver 10 linjer fra 1 til 10, som er i. Derefter printer jeg 3 linjer, hvor linje 1 er i, altså 1, 2, 3 osv. linje 2 er sum funtionen og linje 3 er simpleSum funktionen.
// Funktionerne bruger i til at tælle hvilket i de er noget til.
for i in 1..10 do
    printfn "%5d %5d %5d" i (sum i) (simpleSum i)
