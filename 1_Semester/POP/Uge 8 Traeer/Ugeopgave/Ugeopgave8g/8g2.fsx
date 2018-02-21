// Christian Sass Hansen, Daniel Nathan Krog, Michael Kwaensanthiah Olesen
// Opgave 8g2
// Last edited 28/11-2017

#r "img_util.dll"

type point = int * int
type colour = int * int * int

// XMLdoc header for triarea2:

/// <summary> This function is used to decide whether a point is placed inside a triangle,
///           which it does by calculating the area of a triangle, knowing its coners. </summary>
/// <remarks> Can only be used on triangles  <remarks>
/// <param name="p1"> Point (int * int) </param>
/// <param name="p2"> Point (int * int) </param>
/// <param name="p3"> Point (int * int) </param>
/// <returns> The function will return the area of the triangle multiplied by two </returns>
/// <example> The following call: <code> (triarea2 (15,80) (45,80) (85,70)) </code>
/// Will return 2500 </example>

// Definition of the function triarea2, which is the fomular of "area"
// int * int -> int * int -> int * int -> int                                                                             // Signature
let triarea2 (p1:point) (p2:point) (p3:point) : int =                                                                 // Definition
    abs ((fst p1) * ((snd p2) - (snd p3)) + (fst p2) * ((snd p3) - (snd p1)) + (fst p3) * ((snd p1) - (snd p2)))
