(*
   Exercise 5
   Jan Rolandsen
   Denne version er fejlfri (som alle tidligere versioner)
   Jeg benytter altid interactive, når jeg udfører true tests
*)

// Ø5.0
// val oneToN : int -> int list
let oneToN n =
    [1..n]
;;
// testing true
oneToN 10 = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] ;;

// Ø5.1
// val multiplicity int -> int list -> int
let rec multiplicity x xs =
    if xs = [] then
        0
    else
        if x = xs.Head then
            1 + multiplicity x xs.Tail
        else
             multiplicity x xs.Tail
;;
// testing true (Whitebox)
multiplicity 1 [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] = 1 ;;    // linie: 19, 21, 22, 23
multiplicity 0 [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] = 0 ;;    // linie: 19, 21, 22, 24, 25
multiplicity 5 [1; 5; 3; 4; 5; 6; 7; 8; 9;  5] = 3 ;;    // linie: 19, 21, 22, 24, 25
multiplicity 6 [] = 0 ;;                                 // linie: 19, 20


// alternativ
let multiplicityAlt x xs =
    List.length (List.filter (fun n -> n = x) xs)
;;
// testing true
multiplicityAlt 5 [1; 5; 3; 4; 5; 6; 7; 8; 9;  5] = 3 ;;

// Ø5.2
// val split : int list -> int list * int list
let rec split (xs : int list) : int list * int list =
    if xs = [] then ([], [])                              // antal = 0
    else if xs.Tail = [] then ([xs.Head], [])                   // antal = 1
         else let (xs0, xs1) = split xs.Tail.Tail in      // antal > 1
              (xs.Head :: xs0, xs.Tail.Head :: xs1)
;;
// testing true
split [0; 1; 2; 3; 4] = ([0; 2; 4], [1; 3]) ;;

// Ø5.3
// val reverseApply : 'a -> ('a -> 'b) -> 'b
let reverseApply x f =
    f x
;;
// testing true
reverseApply [3; 2; 4] List.head = 3 ;;
reverseApply [3; 2; 4] List.tail = [2; 4] ;;

// Ø5.4
// val f : int -> (int -> int) vil returnere en function
let f n = (+) n

// val g : (int -> int) -> int vil tager imod en function
let g f : int = f 4

// Ø5.5
// val evens : int list -> int list
let evens xs =
    List.filter (fun n -> n % 2 = 0) xs
;;
// testing true
evens [1; 5; 3; 4; 5; 6; 7; 8; 9; 5] =  [4; 6; 8] ;;

// Ø5.6
// val applylist : ('a -> 'b) list -> 'a -> 'b list
let applylist fs x =
    List.map (reverseApply x) fs
;;
// testing true
applylist [(+) 2; (-) 2; (*) 2] 42 ;;

// Ø5.7
// List.filter
List.filter ;;         // har typen: ('a -> bool) -> 'a list -> 'a list
// List.foldBack
List.foldBack ;;       // har typen: ('a -> 'b -> 'b) -> 'a list -> 'b -> 'b

// Ø5.8
// Han er ikke specielt snedig, idet han sletter dubletter i listen,
// i samme øjeblik han ændrer listen til et set (mængde) !!!
//
// val ssort : 'a list -> 'a list when 'a : comparison
let ssort xs =
    Set.toList (Set.ofList xs)
;;
// testing true
ssort [1; 3 ; 1 ; 2; 1] = [1; 2; 3] ;;   // mængder har ikke dubletter

// Ø5.9
// val squares: int -> int array
let squares n =
    Array.init n (fun x -> (x+1) * (x+1))   // init starter fra 0
;;
// testing true
squares 5 = [|1; 4; 9; 16; 25|] ;;

// Ø5.10
// val funktionreverseArray : 'a array -> 'a array
let reverseArray ar =
  Array.init (Array.length ar) (fun i -> ar.[Array.length ar - i - 1])
;;
// testing true
reverseArray [|1..5|] = [|5; 4; 3; 2; 1|] ;;

// Ø5.11
// val reverseArrayD : 'a [] -> unit
let reverseArrayD ar =
    let mutable n = Array.length ar - 1
    let mutable m = 0
    while m < n do
        let tmp = ar.[m]
        ar.[m] <- ar.[n]
        ar.[n] <- tmp
        n <- n - 1
        m <- m + 1
;;
// testing
let aa = [|1..5|]
printfn "initial array : %A" aa
reverseArrayD aa
printfn "reverse array : %A" aa ;;

// Ø5.10
// val transpose : 'a [,] -> 'a [,]
let transpose ar2d =
  Array2D.init (Array2D.length1 ar2d) (Array2D.length2 ar2d) (fun i j -> ar2d.[j, i])
;;
// testing
let bb = Array2D.init 5 5 (fun i j -> i)
printfn "Original array :\n%A" bb
printfn "Transposed array :\n%A" (transpose bb)
;;

// slut
