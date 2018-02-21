(*
   Exercise 6.4 and 6.5
   Jan Rolandsen
   I allways use F# Interactive during development.
*)

// Ø6.4
// my version of List.fold
// val listFold : ('a -> 'b -> 'a) -> 'a -> 'b list -> 'a
//  f ... (f (f (f s b0 ) b1 ) b2 ) ... bn
let rec listfold f s xs =
    if xs = [] then s
    else f (listfold f s xs.Tail) xs.Head
;;
// testing for true
listfold (+) 0 [3;6;2;5] = 0+3+6+2+5 ;;  // sum
listfold (*) 1 [3;6;2;5] = 1*3*6*2*5 ;;  // multiplication

// my version of List.foldBack
// val listfoldBack :(('a -> 'b -> 'b) -> 'a list -> 'b -> 'b
// f x0 (f x1 (f x2 ...(f xn s)...))
let rec listfoldBack f xs s =
    if xs = [] then s
    else f xs.Head (listfoldBack f xs.Tail s)
;;
// testing for true
listfoldBack (+) [3;6;2;5] 0 = 0+5+2+6+3 ;;  // sum
listfoldBack (*) [3;6;2;5] 1 = 1*5*2*6*3 ;;  // multiplication


// Ø6.5
// duration is used for timing a function.
// This function will measure the time it takes a function
// to complete its task, from start to finish, in milliseconds.

// Observe: you can measure everything that is a function, like
//     duration ( fun() -> 42 + 41 )  // increase k significantly
//     duration ( fun() -> 42 * 41 )  // ditto

open System  // using Diagnostics etc.

let duration f =
    let mutable returnValue = 0
    printfn "Stopwatch starting:"
    let mutable timer = new Diagnostics.Stopwatch()
    timer.Start()
    for k=0 to 100000 do
        returnValue <- f()
    timer.Stop()
    let total = timer.ElapsedMilliseconds
    printfn "Time use in (millisesonds): %i" total
    returnValue         // last function value
;;

let n = 100000

printfn "List.fold: %i\n" (duration ( fun() -> List.fold (+) 0 [0 .. n] )) ;;

printfn "listfold: %i\n" (duration ( fun() -> listfold (+) 0 [0 .. n] )) ;;

printfn "List.foldback: %i\n" (duration ( fun() -> List.foldBack (+) [0 .. n] 0 )) ;;

printfn "listfoldback: %i\n" (duration ( fun() -> listfoldBack (+) [0 .. n] 0 )) ;;

// end
