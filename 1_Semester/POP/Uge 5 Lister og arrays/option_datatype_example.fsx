// This is an example *.fsx file showing the use
// of an option datatype, which is to be used when
// the returnvalue is undefined !

(*
   Example
   Jan Rolandsen
   Observe: I always use F# Interactive during development, so
   run this using fsharpi !
   If using fsharpc then prepend 'printfn %A%' to the tests.
*)

// E5.1                                                  // task
// XMLdoc header for divOption:

/// <summary> The function div is will divide two numbers </summary>
/// <remarks> The function checks for b = 0 </remarks>
/// <param name="a"> The number a (int) </param>
/// <param name="b"> The number b (int) </param>
/// <returns> The result of a/b (float option) </returns>
/// <example> The following call <code> div 8 2 </code>
///           will return <c> 4.0 </c> </example>

(*
// The first naive version, where the returnvalue is undefined for the case b=0
// val div : int -> int -> float               // signature
let div a b =                                  // definition
    if b = 0 then
        ?
    else
        float a / float b
;;
   In this case we have to use the option datatype, and therefore None and Some
*)

// The final version, where the returnvalue is defined for all cases.
// val div : int -> int -> float option        // signature
let div a b : float option =                   // definition
    if b = 0 then
        None
    else
        Some ((float a) / (float b))
;;
// testing for true (Blackbox)
div  6  0  = None ;;                           // b equals 0
div -7  2  = Some -3.5 ;;                      // a negative
div 42 -6  = Some -7.0 ;;                      // b negative
div -6 -3  = Some 2.0 ;;                       // a,b negative
div 42  6  = Some 7.0 ;;                       // a,b positive

// testing for true (Whitebox)
// The tests below will have coverage of the algorithm.
div  6  0  = None ;;                           // line: 39, 40
div -7  2  = Some -3.5 ;;                      // line: 39, 41, 42

// end
