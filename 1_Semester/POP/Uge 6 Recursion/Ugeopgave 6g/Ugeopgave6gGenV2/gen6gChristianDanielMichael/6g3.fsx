(*
   Task 6g
   Christian Sass Hansen, Daniel Nathan Krog
   and Michael Kwaensanthiah Olesen
   Observe: We always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// T6g3                                                          // task
// XMLdoc header for float2frac:

/// <summary> The function cfrac2frac returns a tuple showing the approximation
///    of a continued fraction as an integer fractal.
///    It uses the following signature: int list -> int -> int * int </summary>
/// <remarks> The function checks for an empty list </remarks>
/// <param name="lst"> A list (int list) to make an integer fractal </param>
/// <param name="i"> A number (int) that controls how much of a list we want to use </param>
/// <returns> A tuple with the approximation of a continued fraction
///    as an integer fractal</returns>
/// <example> The following call <code> cfrac2frac [3;4;12;4] 3 </code>
///           will return <c> (649, 200) </c> </example>

let cfrac2frac (lst: int list) (i: int): int * int =
    if List.isEmpty lst || i < 0 || i > (List.length lst - 1) then
        (0, 0)
    else
        let rec inner_cfrac2frac (lst: int list) (i: int): int*int =
            match i with
                | -2 -> (0, 1)
                | -1 -> (1, 0)
                | _ ->
                    let (t2, n2) = (inner_cfrac2frac lst (i-2))
                    let (t1, n1) = (inner_cfrac2frac lst (i-1))
                    let (ti, ni) = (List.item i lst * t1 + t2,
                                    List.item i lst * n1 + n2)

                    (ti, ni)
        inner_cfrac2frac lst i
;;

// Blacbox testing
let args0 = ([], 0)
let args1 = ([3;4;12;4], 0)
let args2 = ([3;4;12;4], 1)
let args3 = ([3;4;12;4], 2)
let args4 = ([3;4;12;4], 3)
let testcases = [
    (args0, (0, 0));
    (args1, (3, 1));
    (args2, (13, 4));
    (args3, (159, 49));
    (args4, (649, 200))
    ]

let test'float float_function x =
    float_function (fst(fst x)) (snd(fst x)) = (snd x)

let test'print_results float_function (x: (int list*int) * (int*int)) =
    let res = test'float float_function x
    printfn "Input: %A.\nExpected %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (float_function (fst (fst x)) (snd (fst x))) res
    res

let test f = List.map (test'print_results f) testcases

let all_tests_passed (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let test_float = test cfrac2frac |> all_tests_passed

printfn "All tests passed for cfrac2frac: %b\n" test_float

// Whitebox testing
printfn "Testing lines 25-26:\nComparison: %A\n" (cfrac2frac [] 0 = (0, 0))
printfn "Testing lines 29-36:\nComparison: %A" (cfrac2frac [3;4;12;4] 2 = (159, 49))
