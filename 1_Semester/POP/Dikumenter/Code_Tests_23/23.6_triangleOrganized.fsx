/// Listing 23.6 winforms/triangleOrganized.fsx
/// Improved organization of code for drawing a triangle
/// Shown down-under:

// Open often used libraries, be ware of namespace polution!
open System.Windows.Forms
open System.Drawing

// **************** WinForm Specifics ****************
// Setup a window form and return function to activate
let view (sz : Size) (pen : Pen) (pts: Point []) : (unit -> unit) =
    let win = new System.Windows.Forms.Form ()
    win.ClientSize <- sz
    win.Paint.Add (fun e -> e.Graphics.DrawLines (pen, pts))
    fun () -> Application.Run win // Function as return value

// ******** Model ********
// a black triangle, using winform primitives for brevity
let model () : Size * Pen * (Point []) =
    let size = Size (320, 170)
    let pen = new Pen (Color.FromArgb (0, 0, 0))
    let lines =
        [|Point (0,0); Point (10,170); Point (320,20); Point (0,0)|]
    (size, pen, lines)

// ************* Connection *************
// Tie view and model together and enter main event loop
let (size, pen, lines) = model ()
let run = view size pen lines
run ()