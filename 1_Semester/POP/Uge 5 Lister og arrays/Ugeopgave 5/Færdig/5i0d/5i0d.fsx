// Christian Sass Hansen
// Opgave 5i0d
// Last edited 08/10-2017

// Use Recursion
// Using firstColum and dropFirstColum

(*
let transpose (xss: 'a list list) : 'a list list =
    List.map List.head xss
    transpose (List.map List.tail xss)
*)

// *** VERSION 1 ***
(*
let rec transpose lst = function
| [] -> failwith "cannot transpose a 0-by-n matrix"
| [] :: xs -> []
| xs -> List.map List.head xs :: transpose (List.tail xs)

transpose [[1;2;3];[4;5;6]]
*)

// *** VERSION 2 ***
(*
let transpose (lst: 'a list list): 'a list list
*)

// *** VERSION 3 ***
let firstColum (xss: 'a list list) =
    List.map List.head xss
let dropFirstColum (xss: 'a list list) =
    List.map List.tail xss
let rec transpose (xss: 'a list list) =
    firstColum xss && transpose (dropFirstColum xss)

(*
let firstColum (lst: 'a list list) =
    List.map List.head lst
printfn "%A" (firstColum [[1;2;3];[4;5;6]])
*)


(*
let dropFirstColum (lst: 'a list list) =
    // Erstatter head med tail. Dette erstatter alle elementer med resten af listen der ikke er head. Hvor head er starten af listen, altså 1 og 4 i tilfældet nedenunder.
    List.map List.tail lst
printfn "%A" (dropFirstColum [[1;2;3];[4;5;6]])
*)
