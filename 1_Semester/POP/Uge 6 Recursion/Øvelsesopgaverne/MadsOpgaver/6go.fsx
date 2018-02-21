// ==========================================================================
// 6ø0
// ==========================================================================

let rec fac n =
    match n with
        | 0 -> 1
        | 1 -> 1
        | _ -> n * fac (n-1)
let testcases'fac = [
    (0, 1);
    (1, 1);
    (2, 2);
    (3, 6);
    (4, 24);
    (5, 120);
    (6, 720);
    (10, 3628800);
    // Largest possible value with 32 bit
    (12, 479001600)
    ]

let test'fac testcases =
    let test'fac'testcase testcase =
        fac (fst testcase) = (snd testcase)
    List.map test'fac'testcase testcases
    |> List.fold (&&) true

test'fac testcases'fac
|> printfn "fac passed all tests: %b"


// ==========================================================================
// 6ø1
// ==========================================================================
let rec sum n =
    match n with
        | 0 -> 0
        | 1 -> 1
        | _ -> n + sum (n-1)


let testcases'sum = [
    (0, 0);
    (1, 1);
    (2, 3);
    (3, 6);
    (4, 10);
    (10, 55);
    (1000, 500500)
    ]
let test'sum testcases =
    let test'sum'testcase testcase =
        sum (fst testcase) = (snd testcase)
    List.map test'sum'testcase testcases
    |> List.fold (&&) true

test'sum testcases'sum
|> printfn "sum passed all tests: %b"


// ==========================================================================
// 6ø2
// ==========================================================================

let rec sum_list xs =
    match xs with
        | [] -> 0
        // If x is not last element, return x + sum of rest of elements
        | x::xs -> x + sum_list xs
let testcases'sum_list = [
    ([], 0);
    ([0], 0);
    ([1], 1);
    ([1..2], 3);
    ([1..3], 6);
    ([1..4], 10);
    ([1..10], 55);
    ([1..1000], 500500)
    ]
let test'sum_list testcases =
    let test'sum_list'testcase testcase =
        sum_list (fst testcase) = (snd testcase)
    List.map test'sum_list'testcase testcases
    |> List.fold (&&) true

test'sum_list testcases'sum_list
|> printfn "sum_list passed all tests: %b"

// ==========================================================================
// 6ø3
// ==========================================================================
let rec gcd (t, n) =
    match (t,n) with
        | _,0 -> t
        | _ -> gcd (n, t % n)

let testcases'gcd = [
    ((2,0), 2);
    ((0,0), 0);
    ((2,8), 2);
    ((500,100), 100);
    ((20,5), 5);
    ((790, 800), 10)
    ]
let test'gcd (testcases:((int*int)*int) list) =
    let test'gcd'testcase (testcase:(int*int)*int) =
        gcd (fst testcase) = (snd testcase)
    List.map test'gcd'testcase testcases
    |> List.fold (&&) true

test'gcd testcases'gcd
|> printfn "Gcd passed all tests: %b"

// ==========================================================================
// 6ø4
// ==========================================================================

let rec fold f acc xs =
    match xs with
    | [] -> acc
    | x::xs ->
        fold f (f acc x) xs

let rec foldback f xs acc =
    match xs with
        | [] -> acc
        | [x] -> f x acc
        | x::xs ->
            f x (foldback f xs acc)


let testcases'fold = [
    (+);
    (-);
    (*);
    ]

let test'fold testcases =
    let test'fold'testcase testcase =
        let l = [1..10]
        let real_fold = List.fold testcase 0 l
        let my_fold = fold testcase 0 l
        real_fold = my_fold
    List.map test'fold'testcase testcases
    |> List.fold (&&) true

test'fold testcases'fold
|> printfn "fold passed all tests: %b"

let test'foldback testcases =
    let test'foldback'testcase testcase =
        let l = [1..10]
        let real_foldback = List.foldBack testcase l 0
        let my_foldback = foldback testcase l 0
        real_foldback = my_foldback
    List.map test'foldback'testcase testcases
    |> List.fold (&&) true

test'foldback testcases'fold
|> printfn "foldback passed all tests: %b"



// Sum a list with all functions
// Run in fsharpi/interactive mode,
// with #time to see measurements
let sum_test n =
    List.fold (+) 0 [1..n] |> ignore
    fold (+) 0 [1..n] |> ignore
    List.foldBack (+) [1..n] 0 |> ignore
    foldback (+) [1..n] 0 |> ignore
