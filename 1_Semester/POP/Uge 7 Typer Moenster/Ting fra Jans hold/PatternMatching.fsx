(*
   POP 2017, Pattern Matching
   Jan Rolandsen
*)

// Sum of elements in a list, the (traditional recursive) functional way
let rec sumList xs =
    if xs = [] then 0
    else xs.Head + sumList xs.Tail
;;
// testing for value
sumList [1..5] ;;

// Sum of elements in a list, using pattern matching
let rec sumListPM xs =
    match xs with
        | [] -> 0
        | x :: xstail -> x + sumListPM xstail
;;
// testing for value
sumListPM [1..5] ;;


// Matching more than head and tail
let multiList xs =
    match xs with
        | x :: y :: z  -> "This list have elements. How many ?\n"
        | _            -> "Something else. When is this executed ?\n"
;;
// testing for value
multiList [1; 2] ;;
multiList [1; 2; 3] ;;
multiList [1; 2; 3; 4] ;;


// Deconstruct a tuple in match expressions
let tupleExample t =
    match t with
        | (_, y, z) when y = 1 -> y - z        // using a guard
        | (a, b, c) when b = 2 -> b + c        // using a guard
        | _                    -> -1
;;
// testing for value
tupleExample (1,2,3) ;;
tupleExample (0,1,2) ;;
// tupleExample (1,1) ;;          // Uncomment this line and see the error
// tupleExample (1,2,3,4) ;;      // Uncomment this line and see the error

// Deconstruct a list in match expressions
let listExample xs =
    match xs with
        | [_; y; z] when y = 1 -> y - z        // using a guard
        | [a; b; c] when b = 2 -> b + c        // using a guard
        | _                    -> -1
;;
// testing for value
listExample [1; 2; 3] ;;
listExample [0; 1; 2] ;;
// listExample [1; 1] ;;           // Uncomment this line and see the error
// listExample [1; 2; 3; 4] ;;     // Uncomment this line and see the error

// end
