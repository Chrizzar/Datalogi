// Christian Sass Hansen
// Opgave 5i2
// Last edited 08/10-2017

// Task: 5i2
// XMLdoc header for firstColum:

/// <summary> The function gennemsnit, finds the average of a list of decimals, if it is well-defined, and NONE (NULL), if not. </summary>
/// <remark> The function checks for, if the list is empty (it spits out NULL) <remarks>
/// <param name="lst"> The parameter "lst", is a list, which contains multiple lists </param>
/// <returns> The average of a list of decimals, if it is well-defined, and NONE (NULL), if not </returns>
/// <example> The following call <code> gennemsnit [1.0; 2.0; 3.0] </code>
/// This will return the average 2.0 </example>

// val firstColum : 'a list list -> 'a list                                                 // signature
let gennemsnit (lst: float list): float option =                                       // definition
    if lst = [] then                                                                        // beginning of algorithm
        None
    else
        Some (List.foldBack (fun elm acc -> acc + elm) lst 0.0 / float lst.Length)          // end of algorithm

// Testing for true (Whitebox)
printfn "%A" (gennemsnit [1.0; 2.0; 3.0])                                                   // Line: 16, 19, 20
printfn "%A" (gennemsnit [])                                                                // Line: 16, 17, 18
