// Christian Sass Hansen
// 3i0a
// Last modified: 27/09 - 2017

// Jeg starter med at lave en funktion med navnet "sum" af "n". 
let sum n =
    // Her sætter jeg en mutable variabel s = 0, så jeg altid kan ændre det der står inde i den.
    let mutable s = 0
    // Her gør jeg det samme som ovenover bare hvor sætter en mutable variabel i = 1.
    let mutable i = 1
    // Her laver jeg så en while-løkke, som jeg sætter til, så længe i er mindre end eller i lig med n, så skal den tage det sidst gemte sum og ligge det næste tal i tabellen til, altså i.
    while i <= n do
        s <- s + i
        // Når vi har lagt i til summen, ligger vi så +1 til i, og går op i while-løkken igen, og derefter forsætter indtil den når n
        i <- i + 1
    s
// Her printer vi så et eksempel med en sum 10, altså 1+2+3..+9+10 som er i lig med 15.
printfn "%d" (sum 5)
