// Christian Sass Hansen
// Opgave 7i.0 & 7i.1
// Last edited 01/11-2017

// Task: 7i.0 & 7i.1
// XMLdoc header for merge and msort:

/// <summary> The function merge, merges two sorted lists together, thus that the result is sorted </summary>
/// <param name="xs"> This is a list </param>
/// <param name="ys"> This is a list </param>
/// <returns> Returns a sorted list </returns>
/// <example> This following call: <code> ([5;8;3;7;4;10;2;9;6;1]) (msort [5;8;3;7;4;10;2;9;6;1]) ([1;2;3;4;5;6;7;8;9;10] = msort [5;8;3;7;4;10;2;9;6;1]) </code>
/// Returns a sorted list [1;2;3;4;5;6;7;8;9;10] = true
/// </example>

// val merge                                                 // Signature
let rec merge xs ys =                                     // Definition
    match xs with
        | xempt when xs = [] -> ys
        | yempt when ys = [] -> xs
        | _ ->
            let x = List.head xs
            let y = List.head ys
            let xs = List.tail xs
            let ys = List.tail ys
            match x with
                | x when x < y ->
                    x :: merge xs (y :: ys)
                | _ ->
                    y :: merge (x :: xs) ys

/// <summary> The function msort makes use of the slice-syntax to extract parts of a list </summary>
/// <remark> msort makes use of the utility-function merge <remarks>
/// <param name="xs"> This is a list </param>
/// <returns> Returns a sorted list  </returns>
/// <example> This following call: <code> ([5;8;3;7;4;10;2;9;6;1]) (msort [5;8;3;7;4;10;2;9;6;1]) ([1;2;3;4;5;6;7;8;9;10] = msort [5;8;3;7;4;10;2;9;6;1]) </code>
/// Returns a sorted list [1;2;3;4;5;6;7;8;9;10] = true
/// </example>

// val msort 'a list -> 'a list 'a list
let rec msort (xs:int list) =                       // Signature
    let sz = List.length xs                           // Definition
    match sz with
        lgh when sz < 2 ->
            xs
        | _ ->
            let n = sz / 2
            let ys = xs.[0..n-1]
            let zs = xs.[n..sz-1]
            merge (msort ys) (msort zs)

let xs = [7;55;34;23;5;42;32;34;8]
printfn "%A\n" (msort xs)


// **** Opgave 7i.1 ****

// Blackbox testing (for forskellige udfald, tom liste, fuld liste osv.)

// Testing for an empty list
printfn "Testing for an empty list: %A -> %A = %A" ([]) (msort []) ([] = msort [])

// Testing for 1 element
printfn "Testing for 1 element: %A -> %A = %A" ([1]) (msort [1]) ([1] = msort [1])

// Testing for 2 elements sorted
printfn "Testing for 2 elements, sorted: %A -> %A = %A" ([25;50]) (msort [25;50]) ([25;50] = msort [25;50])

// Testing for 2 elements vise versa sorted
printfn "Testing for 2 elements, vise versa sorted: %A -> %A = %A" ([50;25]) (msort [50;25]) ([25;50] = msort [50;25])

// Testing for 3 elements
printfn "Testing for 3 elements, sorted: %A -> %A = %A" ([10;46;83]) (msort [10;46;83]) ([10;46;83] = msort [10;46;83])

// Already sorted
printfn "Testing for 5 elements that is already sorted: %A -> %A = %A" ([1;2;3;4;5]) (msort [1;2;3;4;5]) ([1;2;3;4;5] = msort [1;2;3;4;5])

// Vise versa sorted
printfn "Testing for 5 elements vise versa sorted: %A -> %A = %A" ([5;4;3;2;1]) (msort [5;4;3;2;1]) ([1;2;3;4;5] = msort [5;4;3;2;1])

// Testing for random
printfn "Testing for random with 10 elements %A -> %A = %A" ([5;8;3;7;4;10;2;9;6;1]) (msort [5;8;3;7;4;10;2;9;6;1]) ([1;2;3;4;5;6;7;8;9;10] = msort [5;8;3;7;4;10;2;9;6;1])
