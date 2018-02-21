open System  
open System.Windows.Forms  
open System.ComponentModel  
open System.Drawing
let win = new Form()
let mutable delta = 0
let paint (e : PaintEventArgs) : unit =
    let pen = new Pen (Color.Black)
    let points =
        [|Point (0+delta, 0); Point (0+delta, 100)|]
    e.Graphics.DrawLines (pen, points)

/// ********* Working Digital Clock *********
// make a label to show time
(*
let digitalTimer = new Label ()
win.Controls.Add digitalTimer
digitalTimer.Width <- 200
digitalTimer.Location <- new Point (40,190)
digitalTimer.Text <- string System.DateTime.Now // get present time and date
*)
// make a timer and link to label
let timer = new Timer ()
timer.Interval <- 1000 // create an event every 1000 millisecond
timer.Enabled <- true // activiate the timer
// timer.Tick.Add (fun e -> digitalTimer.Text <- string System.DateTime.Now)
// *** Animation ***
timer.Tick.Add (fun e -> win.Paint.Add paint; win.Invalidate(); delta <- delta + 20; printfn "%d" delta)

Application.Run win // start event - loop