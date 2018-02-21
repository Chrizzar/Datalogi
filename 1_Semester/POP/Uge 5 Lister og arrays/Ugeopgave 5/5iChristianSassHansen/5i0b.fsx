// Christian Sass Hansen
// Opgave 5i0b
// Last edited 08/10-2017

// Task: 5i0b
// XMLdoc header for firstColum:

/// <summary> The function firstColum will return a new list, with the first element of each list. </summary>
/// <remark> The function does not check for, if the list is empty (it spits out undefined) <remarks>
/// <param name="lst"> The parameter "lst", is a list, which contains multiple lists </param>
/// <returns> A new list, with only the first element of each element </returns>
/// <example> The following call <code> firstColum [[1;2;3];[4;5;6]] </code>
/// This will return a new list [1; 4] </example>

// val firstColum : 'a list list -> 'a list          // signature
let firstColum (lst: 'a list list) =            // definition
    List.map List.head lst

// Testing for true (Whitebox)
printfn "%A" (firstColum [[1;2;3];[4;5;6]])          // Line: 16, 17
