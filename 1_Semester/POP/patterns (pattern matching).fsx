
// **** Pattern Matching **** //

// Stupid function. Important part is the match expression with guard condition
let rec log (x:float) (n:int) =
    match x with
        | x when x <= 0.00000001 -> n
        | _ ->
            printfn "x is: %.25f" x
            log (x/2.0) (n+1)

// Same function, using if statements instead
let rec iflog x n =
    if x <= 0.00000001 then
        n
    else
        printfn "x is: %.25f" x
        iflog (x/2.0) (n+1)


log 9.0 0 = iflog 9.0 0


// Sum a list of ints using recursion
let rec sumlist xs =
    match xs with
        | x::xs ->
            printfn "x is: %d" x
            printfn "xs is: %A" xs
            x + sumlist xs
        | [] -> 0

sumlist [1..3]

// Do the same, but with a for-loop
let sumlist_for xs =
    let mutable sum = 0
    for i in xs do
        sum <- sum + i
    sum

sumlist_for [1..3]


// Deconstruct tuples in match expressions
let tupleExample x =
    match x with
        | (a,b) when a = 1 ->
            printfn "a is: %d" a
            printfn "b is: %d" b
            a + b
        | _ ->
            printfn "MatcheD!"
            0

tupleExample (0,1)
tupleExample (1,1)


// Match more than head an tail
let multiListMatch xs =
    match xs with
        | x::xs::xss -> printfn "More than three elements\na: %db: %d:c%A" x xs xss
        | _ -> printfn "Something else"

multiListMatch [1;2;3]
