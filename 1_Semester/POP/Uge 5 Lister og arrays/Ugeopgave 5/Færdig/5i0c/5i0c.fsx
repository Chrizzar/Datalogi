// Christian Sass Hansen
// Opgave 5i0c
// Last edited 08/10-2017

// Task: 5i0c
// XMLdoc header for dropFirstColum:

/// <summary> The function dropFirstColum takes a list of lists and returns a list of lists, where the first elements in the inner lists are removed. </summary>
/// <remark> The function does not check for, if the list is empty (it spits out undefined) <remarks>
/// <param name="lst"> The parameter "lst", is a list, which contains multiple lists </param>
/// <returns> A new list, with a list of lists, where the first elements in the inner lists are removed </returns>
/// <example> The following call <code> dropFirstColum [[1;2;3];[4;5;6]] </code>
/// This will return a new list [[2; 3]; [5; 6]] </example>

// val firstColum : 'a list list -> 'a list list         // signature
let dropFirstColum (lst: 'a list list) =          // definition
    List.map List.tail lst

// Testing for true (Whitebox)
printfn "%A" (dropFirstColum [[1;2;3];[4;5;6]])          // Line: 16, 17
