
// *** Øvelsesopgave 6ø0 ***
let rec fac (n: int): int =
    if n = 1 then
        1
    else
        n * fac (n - 1)
printfn "%A" (fac 31)
