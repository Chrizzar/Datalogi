
// *** Øvelsesopgave 6ø1 ***
let rec sum (n: int): int =
    if n = 0 then
        n
    else
        n + sum(n-1)

// (Whitebox testing) 6+5+4+3+2+1 = 21
printfn "%A" (sum 6)                     // Line: 3, 6, 7

// (Whitebox testing) 0+0 = 0
printfn "%A" (sum 0)                     // Line: 3, 4, 5
