// This is an example *.fsx file showing the format
// you should use, when you handin your functions !

(*
   Exercise 5
   Jan Rolandsen
   Observe: I always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// E5.1                                                  // task
// XMLdoc header for multiplicity:

/// <summary> The function multiplicity will return the number of times
///     a number is found in a list, using a recursive algorithm. </summary>
/// <remarks> The function checks for an empty list </remarks>
/// <param name="x"> The number x (int) </param>
/// <param name="xs"> The list of numbers (int list) </param>
/// <returns> The number of times x occurs in the list xs (int) </returns>
/// <example> The following call <code> multiplicity 5 [1; 5; 3; 4; 5; 6; 7; 8; 9;  5] </code>
///           will return <c> 3 </c> </example>

// val multiplicity int -> int list -> int               // signature
let rec multiplicity x xs =                              // definition
    if xs = [] then                                      // beginning of algorithm
        0
    else
        if x = xs.Head then
            1 + multiplicity x xs.Tail
        else
            multiplicity x xs.Tail
;;                                                       // end of algorithm 
// testing for true (Blackbox)
multiplicity  6 [] = 0 ;;                                // empty list
multiplicity 42 [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] = 0 ;;   // number not found
multiplicity  1 [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] = 1 ;;   // found as first element
multiplicity 10 [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] = 1 ;;   // found as last element
multiplicity  5 [1; 5; 3; 4; 5; 6; 7; 8; 9;  5] = 3 ;;   // more than one occurrences

// testing for true (Whitebox)
// The tests below will have coverage of the algorithm.
multiplicity 6 [] = 0 ;;                                 // line: 27, 28 
multiplicity 1 [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] = 1 ;;    // line: 27, 29, 30, 31
multiplicity 0 [1; 2; 3; 4; 5; 6; 7; 8; 9; 10] = 0 ;;    // line: 27, 29, 30, 32, 33
multiplicity 5 [1; 5; 3; 4; 5; 6; 7; 8; 9;  5] = 3 ;;    // line: 27, 29, 30, 32, 33


// alternative solution
// val multiplicity int -> int list -> int               // signature
let multiplicityAlt x xs =
    List.length (List.filter (fun n -> n = x) xs)        // using List library functions
;;
// testing for true
multiplicityAlt 5 [1; 5; 3; 4; 5; 6; 7; 8; 9;  5] = 3 ;;

// end
