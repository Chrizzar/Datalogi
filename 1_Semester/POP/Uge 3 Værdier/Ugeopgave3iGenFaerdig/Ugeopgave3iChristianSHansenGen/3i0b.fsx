// Christian Sass Hansen
// 3i0b
// Last modified: 06/10 - 2017

// SimpleSum funktion
let simpleSum n =
    // Her sætter jeg en mutable variabel s = 0, så jeg altid kan ændre det der står inde i den.
    let mutable s = 0
    // Her sætter jeg s = (formlen) n*(n+1)/2, som der står i opgaven, hvor den så vil bruge formlen til at finde summen.
    s <- (n*(n+1))/2

    s
// Den her finder summen af tallene 5*(5+1)/2 som er i lig med 15
printfn "%d" (simpleSum 5)

// Ps.
// Den her funktion er hurtigere end den forrige, da den forrige tjekker alt i gennem. Den skal altså igennem flere trin. Mens den her bruger en formel til at tjekke hvad summen bliver.
