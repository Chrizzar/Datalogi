// Christian Sass Hansen
// 3i1b
// Last modified: 06/10 - 2017

// Laver funktionen loopMultable til n
let loopMulTable n =
    // Her sætter jeg en mutable variabel s = "", så jeg altid kan ændre det der står inde i den.
    let mutable s = "      1    2    3    4    5    6    7    8    9   10\n"
    // Her laver jeg en for-løkke, hvor for i = 1 til n, som i dette tilfælde vil være 3. Altså 3 linjer.
    for i = 1 to n do
        s <- s + sprintf "%2d" (i)
        // Her laver jeg så endnu en for-løkke, hvor for j = 1 til 10, som i dette tilfælde vil være 10 for titabellen.
        for j = 1 to 10 do
            // Her tager jeg så det sidst gemte s og ligger en streng-værdi (j*i) ind:
            s <- s + sprintf "%5d" (j*i)
         // Får hver nye tabel ned på næste linje
        s <- s + "\n"
    s
// Nu printer jeg så strengen, med funktionen sat med n = 3, så vi får en tabel med 1-tabellen, 2-tabellen og 3-tabellen.
printfn "%s" "Her er n = 1"
printfn "%s" (loopMulTable 1)
printfn "%s" "Her er n = 2"
printfn "%s" (loopMulTable 2)
printfn "%s" "Her er n = 3"
printfn "%s" (loopMulTable 3)
printfn "%s" "Her er n = 4"
printfn "%s" (loopMulTable 4)
printfn "%s" "Her er n = 10"
printfn "%s" (loopMulTable 10)
