// Christian Sass Hansen, Daniel Nathan Krog, Michael Kwaensanthiah Olesen
// Opgave 8g0
// Last edited 28/11-2017

// Definere ugedagene som en type.
type weekday = Monday | Tuesday | Wednesday |Thursday | Friday | Saturday | Sunday


// XMLdoc header for numberToday:

/// <summary> The function numberToday takes an integer and returns the
///      corresponding day of the week. </summary>
/// <remarks> We checks if there are inputs other that the integers
///      in the interval [1-7] <\remarks>
/// <param name="a"> An integer (int) </param>
/// <returns> A day of the week </returns>
/// <example> The following call <code> numberToday (1) </code>
///           will return <c> Monday </c> </example>

// Defining an integer "a", that can be a number from 1 to 7, each of which can return one weekday.
// Where 1 will return monday, 2 will return tuesday, etc.
let numberToDay (a:int) =
    match a with
        | 1 -> Some Monday
        | 2 -> Some Tuesday
        | 3 -> Some Wednesday
        | 4 -> Some Thursday
        | 5 -> Some Friday
        | 6 -> Some Saturday
        | 7 -> Some Sunday
        | _ -> None
;;

// Blacbox testing
// (input, Expected output)
let testcases = [
    (1, Some Monday);
    (2, Some Tuesday);
    (3, Some Wednesday);
    (4, Some Thursday);
    (5, Some Friday);
    (6, Some Saturday);
    (7, Some Sunday);
    (8, None);
    ]

let test'day day_function x =
    day_function (fst x) = (snd x)

let test'print_results day_function (x: int * weekday option) =
    let res = test'day day_function x
    printfn "Input: %A.\nExpected %A. Actual: %A.\nComparison: %b.\n" (fst x) (snd x) (day_function (fst x)) res
    res

let test f = List.map (test'print_results f) testcases

let all_tests_passed (results: bool list) =
    List.fold (fun x acc -> x && acc) true results

let test_function = test numberToDay |> all_tests_passed

printfn "All tests passed for numberToDay: %b\n" test_function
