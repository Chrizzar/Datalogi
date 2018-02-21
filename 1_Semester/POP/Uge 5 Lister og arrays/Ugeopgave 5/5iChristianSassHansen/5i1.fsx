// Christian Sass Hansen
// Opgave 5i1
// Last edited 08/10-2017

// Task: 5i1
// XMLdoc header for concat:

/// <summary> The function concat puts together a list of lists to a single list. </summary>
/// <remark> The function does not check for, if the list is empty (it spits out undefined) <remarks>
/// <param name="lst"> The parameter "lst", is a list, which contains multiple lists </param>
/// <returns> A new list, which puts together a list og lists to a single list.  </returns>
/// <example> The following call <code> concat [[2];[6; 4];[1]] </code>
/// This will return a new list [2; 6; 4; 1] </example>

// val concat : 'a list list -> 'a list
let concat (lst: 'a list list) =           // signature
    List.collect (fun x -> x) lst             // definition

// Testing for true (Whitebox)
printfn "%A" (concat [[2];[6; 4];[1]])        // Line: 16, 17
