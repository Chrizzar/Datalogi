open System  
open System.Windows.Forms  
open System.ComponentModel  
open System.Drawing  

// Extended the default Form to avoid display flickered
type SmoothForm() as x =
    inherit Form()
    do x.DoubleBuffered <- true

let view (sz : Size) (pen : Pen) (pts : Point [] []) : (unit -> unit) =
    let win = new SmoothForm()
    win.ClientSize <- sz
    for i in pts do
        win.Paint.Add (fun e -> e.Graphics.DrawLines (pen, i))


    /// ********* Working Digital Clock *********
    // make a label to show time
    let digitalTimerLabel = new Label ()
    win.Controls.Add digitalTimerLabel
    digitalTimerLabel.Width <- 200
    digitalTimerLabel.Location <- new Point (40,190)
    digitalTimerLabel.Text <- string System.DateTime.Now // get present time and date

    // make a timer and link to label
    let timer = new Timer ()
    timer.Interval <- 60 // create an event every 1000 millisecond
    timer.Enabled <- true // activiate the timer
    timer.Tick.Add (fun e ->
        digitalTimerLabel.Text <- string System.DateTime.Now
        timerH <- float (System.DateTime.Now.Hour)
        win.Invalidate()
        )

    // *** Animation ***
    // timer.Tick.Add (fun e -> win.Paint.Add paint; win.Incalidate(); delta <- delta + 50; printfn "%d" delta)
    // Rotate a primitive
    let rotate (theta : float) (arr : Point []) : Point [] =
        let toInt = int << round
        let rot (t : float) (p : Point) : Point =
            let (x, y) = (float p.X, float p.Y)
            let (a, b) = (150.0 + (100.0 * cos t), 150.0 + (100.0 * sin t))
            Point (toInt a, toInt b)
        Array.set arr 1 (rot (theta) (arr.[1]))
        arr
    

    // Drawing the lines with index and drawing the circle, and invalidating 
    win.Paint.Add (fun e ->
        e.Graphics.DrawLines (pen, (rotate (timer*System.Math.PI/60.0) hourHand)) // Takes input from model (hourHand)
        // e.Graphics.DrawLines (pen, pts.[1]) // Takes input from model (minuteHand)
        // e.Graphics.DrawLines (pen, pts.[2]) // Takes input from model (secondHand)
        e.Graphics.DrawEllipse (pen,10.0f,10.0f,160.0f,160.0f))
    win.Invalidate()

    (*
    // Drawing the lines with index and drawing the circle, and invalidating 
    win.Paint.Add (fun e ->
        e.Graphics.DrawLines (pen, pts.[0]) // Takes input from model (hourHand)
        //e.Graphics.DrawLines (pen, pts.[1]) // Takes input from model (minuteHand)
        //e.Graphics.DrawLines (pen, pts.[2]) // Takes input from model (secondHand)
        e.Graphics.DrawEllipse (pen,10.0f,10.0f,160.0f,160.0f))
    win.Invalidate()
    *)

    /// ********* CenterDot (center af cirklen) *********
    win.Paint.Add(fun draw ->
        let CenterDotBrush = new SolidBrush(Color.Red)
        draw.Graphics.FillEllipse(CenterDotBrush,89.0f,89.0f,6.0f,6.0f))  

    fun () -> Application.Run win // Function as return value 

/// ********* Clock Hands (Ur-visere) *********
let model () : Size * Pen * (Point [] []) =
    let size = Size (183, 230)
    let pen = new Pen (Color.Black,Width=2.0f)
    //               (Bottom cord) ;   (Top cord)
    let hourHand   = [|Point(93,95); Point(93,20)|]
   // let minuteHand = [|Point(93,95); Point(93,20)|]
   // let secondHand = [|Point(93,95); Point(93,20)|]
    let lines = [|hourHand|] //; minuteHand; secondHand|]
    (size, pen, lines)

(*
let model () : Size * Pen * (Point [] []) =
    let size = Size (400, 400)
    let pen = new Pen (Color.Black,Width=2.0f)
    let hourHand   = [|Point (78,20); Point(92,93)|]
    let minuteHand = [|Point (110,45); Point(93,93)|]
    let secondHand = [|Point (93,20); Point(93,103)|]
    let lines = [|hourHand; minuteHand; secondHand|]
    (size, pen, lines)
*)

/// ********* Connection *********
let (size, pen, lines) = model ()
let run = view size pen lines
run() // Start the event - loop

//Application.Run win // start event - loop
