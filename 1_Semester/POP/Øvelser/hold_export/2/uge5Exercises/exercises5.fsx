
// 5.0
printfn "\n---Exercise 5.0---"

let oneToN (n:int) =
    [1..n]

printfn "%A" (oneToN 10)
printfn "%A" (oneToN 5)
printfn "%A" (oneToN 0)


// 5.1
printfn "\n---Exercise 5.1---"

let multiplicity (x:int) (xs:int list) =
    let mutable counter = 0
    for y in xs do
        if y = x then
            counter <- counter + 1
    counter

printfn "%A" (multiplicity 2 [1;2;3;4;3;2;1;2;7;2])
printfn "%A" (multiplicity 9 [9;9;9])
printfn "%A" (multiplicity 2 [9;9])


// 5.2
printfn "\n---Exercise 5.2---"

let split (xs:int list) =
    List.foldBack (fun x (l,r) -> x::r, l) xs ([],[])

let split2SplitHarder (xs:int list) =
    List.partition (fun x -> x % 2 = 0) xs

let split3SplitWithAVengeance (xs:int list) =
    ((List.filter (fun x -> x % 2 = 0) xs),(List.filter (fun x -> x % 2 <> 0) xs))


printfn "%A" (split [0;1;2;3;4;5;6;7;8;9])
printfn "%A" (split2SplitHarder [0;1;2;3;4;5;6;7;8;9])
printfn "%A" (split3SplitWithAVengeance [0;1;2;3;4;5;6;7;8;9])


// 5.3
printfn "\n---Exercise 5.3---"

let reverseApply x f =
    f x

let adds x:int =
    x + 1

printfn "%A" (reverseApply 5 adds)
printfn "%A" (reverseApply 0 adds)
printfn "%A" (reverseApply -1 adds)


// 5.4
printfn "\n---Exercise 5.4---"



// 5.5
printfn "\n---Exercise 5.5---"

let evens (xs:int list) =
    List.filter (fun x -> x % 2 = 0) xs

printfn "%A" (evens [0;1;2;3;4;5;6;7;8;9])
printfn "%A" (evens [0;2;4;6;8])
printfn "%A" (evens [1;3;5;3;1])

// 5.6
printfn "\n---Exercise 5.6---"

let applyList (xs) (m) =
    List.map (reverseApply m) xs

let addXOne x =
    x + 1
let addXTwo x =
    x + 2
let subOne x =
    x - 1
let subTwo x =
    x - 2

printfn "%A" (applyList [addXOne; addXTwo; subOne; subTwo] 5)


// 5.7
printfn "\n---Exercise 5.7---"
printfn "List.filter: ('T -> bool) -> 'T list -> 'T list')"
printfn "List.foldBack : ('T -> 'State -> 'State) -> 'T list -> 'State -> 'State'"


// 5.8
printfn "\n---Exercise 5.8---"
// Dette er ikke en smart løsning da den ikke tager højde for duplikater
let ssort xs =
  Set.toList (Set.ofList xs)

// Denen tager højde for duplikater
let improvedSsort xs =
  List.sort xs

printfn "%A" (ssort [4;3;7;2])
printfn "%A" (improvedSsort [4;3;7;2])
printfn "%A" (improvedSsort [9;5;3;6;3;9;6])


// 5.9
printfn "\n---Exercise 5.9---"
let squares (n:int) =
    Array.init (n+1) (fun elem -> (elem)*(elem))

printfn "%A" (squares 5)
printfn "%A" (squares 6)
printfn "%A" (squares 0)


// 5.10
printfn "\n---Exercise 5.10---"
let reverseArray (a:int array) =
    Array.init (Array.length a) (fun i -> a.[Array.length a - (i+1)])

printfn "%A" (reverseArray [|1;2;3;4;5|])
printfn "%A" (reverseArray [|5;4;3;2;1|])
printfn "%A" (reverseArray [||])
