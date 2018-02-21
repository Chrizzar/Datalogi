// ==========================================================================
// 7ø0
// ==========================================================================
// Funktion fra forelæsning
let rec insert xs y =
    if List.isEmpty xs then
        [y]
    else
        let x = List.head xs
        in if y < x then y :: xs
           else x :: insert (List.tail xs) y


let isort xs =
    List.fold (fun acc x -> insert acc x) [] xs

(*
   // Uncomment this, and comment the above function to print what is being sorted, as it is being sorted

let isort xs =
    List.fold (fun acc x -> printfn "Current sorted list: %A\nCurrently being sorted:%A" acc x; insert acc x) [] xs
*)           
// Pattern matching udgave
let rec insert_pattern (xs:'a list) (y:'a):('a list) =    
    match xs,y with
        | [],_ -> [y]
        | x::xs,y ->
// Uncomment to print the values as they are being sorted            
//            printfn "x is: %A\nxs is: %A\ny is: %A" x xs y
            match y < x with
                | true -> y :: x::xs
                | false -> x :: insert_pattern xs y
            

// Function to fold insert_pattern over a list, so we can sort the list
let isort_pat xs =
    List.fold (fun acc x -> insert_pattern acc x) [] xs
(*
   // Uncomment this, and comment the above function to print what is being sorted, as it is being sorted
let isort_pat xs =
    List.fold (fun acc x -> printfn "Current sorted list: %A\nCurrently being sorted:%A" acc x; insert_pattern acc x) [] xs
*)








// ===================================================================================
// 7ø1
// ===================================================================================

let rec bubble (xs:int list) =
    if List.isEmpty xs then []
    else
        let x = List.head xs
        let ys = List.tail xs
        in if List.isEmpty ys then [x]
           else let y = List.head ys
                 in if x < y then x :: bubble ys
                    else y :: bubble (x::List.tail ys)

// Bubble sort function
let bsort xs =
    List.fold (fun acc _ -> bubble acc) xs xs

let rec bubble_pat (xs:int list) =
    match xs with
        | [] -> [] // Tom liste
        | x::[] -> [x] // liste med et element
        // x = første element
        // y = andet element
        // ys = resten af listen
        | x::y::ys -> 
            match x < y with
                | true -> x :: bubble_pat (y::ys)
                | false -> y :: bubble_pat (x::ys)

let bsort_pat xs =
    List.fold (fun acc _ -> bubble_pat acc) xs xs


// ===================================================================================
// 7ø2
// ===================================================================================


// Testcases, in tuples. first element is arguments to the function being tested,
// second argument is the expected result
// insert takes to arguments, so the first tuple is itself a tuple.
let testcases'insert = [
    (([1], 2), [1;2]);
    (([1;3], 2), [1;2;3]);
    (([1;0;0;100], -1), [-1;1;0;0;100]);
    (([], 1), [1]);
    (([0], -1), [-1;0])
    ]

let testcases'bubble = [
    ([2;1], [1;2]);
    ([2;3;1], [2;1;3]);
    ([], []);
    ([-1;2;3], [-1;2;3])
    ]

// First element of each tuple is list to be sorted by a function
// second element of each tuple is the expected result
let testcases'isort = [
    ([7;55;34;23;5;42;32;34;8], [5; 7; 8; 23; 32; 34; 34; 42; 55]);
    ([10; 9; 8; 7; 6; 5; 4; 3; 2; 1], [1..10]);
    ([], [])
    ]

// insert_fun is a function, actual,expected is a testcase
let test'insert insert_fun (actual, expected) =
    insert_fun (fst actual) (snd actual) = expected
// testcases is a list of testcases
let test'all_insert testcases =
    List.map (fun x -> test'insert insert x) testcases
    |> List.fold (&&) true

let test'bubble bubble_fun (actual, expected) =
    bubble_fun actual = expected
    
let test'all_insert_pattern testcases =
    List.map (fun x -> test'insert insert_pattern x) testcases
    |> List.fold (&&) true

let test'all_bubble testcases =
    List.map (fun x -> test'bubble bubble x) testcases
    |> List.fold (&&) true

let test'all_bubble_pattern testcases =
    List.map (fun x -> test'bubble bubble_pat x) testcases
    |> List.fold (&&) true

    
// Takes a testcase as input, sorts the actual input with sort_fun and
// compares it to the expected output
let test'sort sort_fun (actual,expected) =
    sort_fun actual = expected

// Maps isort over all testcases, folds the output to a single boolean
let test'all_isort testcases =
    List.map (fun x -> test'sort isort x) testcases
    |> List.fold (&&) true

// Maps isort_pat over all testcases, folds the output to a single boolean
let test'all_isort_pat testcases =
    List.map (fun x -> test'sort isort_pat x) testcases
    |> List.fold (&&) true

let test'all_bsort testcases =
    List.map (fun x -> test'sort bsort x) testcases
    |> List.fold (&&) true

let test'all_bsort_pat testcases =
    List.map (fun x -> test'sort bsort_pat x) testcases
    |> List.fold (&&) true


let run_all_tests () =
    printfn "%-30s%b" "insert passed tests:" (test'all_insert testcases'insert)
    printfn "%-30s%b" "insert_pattern passed tests:" (test'all_insert_pattern testcases'insert)
    printfn "%-30s%b" "bubble passed tests:" (test'all_bubble testcases'bubble)
    printfn "%-30s%b" "bubble_pat passed tests:" (test'all_bubble_pattern testcases'bubble)
    printfn "%-30s%b" "isort passed tests:" (test'all_isort testcases'isort)
    printfn "%-30s%b" "isort_pat passed tests:" (test'all_isort_pat testcases'isort)
    printfn "%-30s%b" "bsort passed tests:" (test'all_bsort testcases'isort)
    printfn "%-30s%b" "isort_pat passed tests:" (test'all_bsort_pat testcases'isort)
    
run_all_tests ()
