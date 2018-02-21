// Christian Sass Hansen
// Opgave 7i.2
// Last edited 01/11-2017

// Task: 7i.2
// XMLdoc header for xFractal:

/// <summary> The function xFractal, will draw a version of a X-fractal, as shown in the assignment. </summary>
/// <remarks> This function is recursive and calls itself. <remarks>
/// <param name="x"> This is the x-coordinate. </param>
/// <param name="y"> This is the y-coordinate. </param>
/// <returns> It will draw a X-fractal, as shown in the assignment. </returns>
/// <example> This following call: <code> xFractal bmp third (x,y) </code>
/// </example> will return one square in the top left corner with the length of 125 / 3

// val xFractal                                            // signature
open ImgUtil
let rec xFractal bmp len (x,y) =                       // Definition
    if len < 125 then
        setBox green (x,y) (x+len,y+len) bmp
    else
        let third = len / 3
        xFractal bmp third (x,y)
        xFractal bmp third (x+third*2, y)
        xFractal bmp third (x+third, y+third)
        xFractal bmp third (x, y+third*2)
        xFractal bmp third (x+third*2, y+third*2)

do runSimpleApp "Sierpinski" 600 600 (fun bmp -> xFractal bmp 512 (30,30) |> ignore)
