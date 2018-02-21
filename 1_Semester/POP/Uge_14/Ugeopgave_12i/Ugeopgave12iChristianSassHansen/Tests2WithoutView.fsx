open System  
open System.Windows.Forms  
open System.ComponentModel  
open System.Drawing  
open System.Drawing
open System.Drawing
open System.CodeDom

// ********* Winforms specifics *********
let win = new Form()
win.ClientSize <- Size (400, 400)

/// ********* Working Digital Clock *********
// make a label to show time
let digitalTimerLabel = new Label ()
win.Controls.Add digitalTimerLabel
digitalTimerLabel.Width <- 200
digitalTimerLabel.Location <- new Point (150,320)
digitalTimerLabel.Text <- string System.DateTime.Now // get present time and date

(*
let mutable hourHand =  [|Point (200,200); Point (200,150)|] //[|Point (0,0);Point (0,-45)|]
// MinuteHand
let mutable minuteHand = [|Point (200,200); Point (200,120)|] // [|Point (0,0);Point (0,-20)|]
// SecondHand
let mutable secondHand = [|Point (200,200); Point (200,100)|] // [|Point (0,0);Point (0,-20)|]
*)

(*
// hourHand
let mutable hourHand = [|Point (0,0);Point (0,-45)|] // [|Point (200,200); Point (200,150)|]
// MinuteHand
let mutable minuteHand = [|Point (0,0);Point (0,-20)|] // [|Point (200,200); Point (200,120)|]
// SecondHand
let mutable secondHand = [|Point (0,0);Point (0,-20)|] // [|Point (200,200); Point (200,100)|]
*)


// make a timer and link to label
let timer = new Timer ()
timer.Interval <- 60 // create an event every 1000 millisecond
timer.Enabled <- true // activiate the timer
timer.Tick.Add (fun e ->
digitalTimerLabel.Text <- string System.DateTime.Now
win.Invalidate()
)

// ********* Translate the clock *********
let translate (d : Point) (arr : Point []) : Point [] =
    let add (d : Point) (p : Point) : Point =
        Point (d.X + p.X, d.Y + p.Y)
    Array.map (add d) arr
    //Array.set arr 1 (add (d) (arr.[1]))
    //arr

// ********* Rotate the clock hands *********
(*
let rotate (theta : float) (arr : Point []) : Point [] =
        let toInt = int << round
        let rot (t : float) (p : Point) : Point =
            let (x, y) = (float p.X, float p.Y)
            let (a, b) = (x * cos t - y * sin t, x * sin t + y * cos t)
            Point (toInt a, toInt b)
        Array.map (rot theta) arr
*)

let rotate (theta : float) (arr : Point []) : Point [] =
        let toInt = int << round
        let rot (t : float) (p : Point) : Point =
            let (x, y) = (float p.X, float p.Y)
            let (a, b) = (x * cos t - y * sin t, x * sin t + y * cos t)
            Point (toInt a, toInt b)
        Array.set arr 1 (rot (theta) (arr.[1]))
        arr

/// ********* ClockHands (Ur-visere) *********
let myPaint (e : PaintEventArgs) : unit =
    // HourHand
    let black = new Pen (Color.Black,Width=2.0f)
    let hourHand =
    //   [bot cord]    [top cord]
        [|Point (0,0);Point (0,-45)|]
    e.Graphics.DrawLines (black, hourHand)

    // MinuteHand
    let red = new Pen (Color.Red,Width=4.0f)
    let minuteHand =
    //   [bot cord]    [top cord]
        [|Point (0,0);Point (0,-20)|]
    e.Graphics.DrawLines (red, minuteHand)

    // SecondHand
    let green = new Pen (Color.Green,Width=1.0f)
    let secondHand =
    //   [bot cord]    [top cord]
        [|Point (0,0);Point (0,-20)|]
    e.Graphics.DrawLines (green, secondHand)
    //printf "%A" secondHand

    (*
    // Circle
    let circleBlack = new Pen(Color.Black,Width=4.0f)
    let circle =
        e.Graphics.DrawEllipse(circleBlack,-100.0f,-100.0f,200.0f,200.0f)
    circle
    *)

    // Circle
    let circleBlack = new Pen(Color.Black,Width=4.0f)
    let circle =
        e.Graphics.DrawEllipse(circleBlack,100.0f,100.0f,200.0f,200.0f)
    circle


    // CenterDot
    let CenterDotBrush = new SolidBrush(Color.Red)
    let center =
        e.Graphics.FillEllipse(CenterDotBrush,200.0f,200.0f,5.0f,5.0f)
    center

    let dt = DateTime.Now
    let s = dt.Second
    let m = dt.Minute
    let h = dt.Hour
    let newS = rotate (float s/60.0*2.0*System.Math.PI) secondHand
   // printf "%A" newS
    let newM = rotate (float m/60.0*2.0*System.Math.PI) minuteHand
    let newH = rotate (float h/12.0*2.0*System.Math.PI) hourHand
    let finalS = translate (Point (200, 200)) secondHand
    let finalM = translate (Point (200, 200)) minuteHand
    let finalH = translate (Point (200, 200)) hourHand
    ()
    (*
    let finalS =
        [(green, secondHand);
        (green, translate (Point (200, 200)) secondHand);
        (green, rotate (float s/60.0*2.0*System.Math.PI) secondHand)]
    (finalS)
    *)

    //let newSecondHand = [|Point (0,0);Point (0,-20)|] // [|Point (200,200);Point (200,150)|]

    // ********* Laver min egen translate funktion *********
    // Manuelt lave et nyt startpunkt for secondHand, minuteHand, hourHand (How to)? 
    
    // *** Hvad den er nu: ***
    // p = {x = 0 ; y = -20}

    // *** Hvad den skal blive til: ***
    // x = {p.X + 200(dx) ; y = p.Y + 200(dy)}
(*
    let secondHand =
    //   [bot cord]      [top cord]
        [|Point (0,200);Point (0,200)|] 
    e.Graphics.DrawLines (green, secondHand)
*)
    e.Graphics.DrawLines (green, secondHand)
    e.Graphics.DrawLines (red, minuteHand)
    e.Graphics.DrawLines (black, hourHand)
    //e.Graphics.DrawEllipse(circleBlack,100.0f,100.0f,200.0f,200.0f)

    
    // Timer (fun e -> win.Invalidate)

win.Paint.Add myPaint

(*
let timer = new Timer ()
timer.Interval <- 1000 // create an event every 1000 millisecond
timer.Enabled <- true // activiate the timer
timer.Tick.Add (fun e ->
    digitalTimerLabel.Text <- string System.DateTime.Now
    hourHand <- rotate 12.0 hourHand
    minuteHand <- rotate 60.0 minuteHand
    secondHand <- rotate 60.0 secondHand
    win.Paint.Add myPaint
    win.Invalidate()
)
*)

(*
/// ********* minuteHand (Minutviser) *********
let minuteHand (e : PaintEventArgs) : unit =
    let red = new Pen (Color.Red,Width=4.0f)
    let points =
        [|Point(93,95); Point(93,20)|]
    e.Graphics.DrawLines (red, points)
win.Paint.Add minuteHand
*)

(*
/// ********* secondHand (Sekundviser) *********
let secondHand (e : PaintEventArgs) : unit =
    let green = new Pen (Color.Green,Width=1.0f)
    let points =
        [|Point(93,95); Point(93,20)|]
    e.Graphics.DrawLines (green, points)
win.Paint.Add secondHand
*)

(*
/// ********* Cirkel *********
win.Paint.Add(fun draw ->
    let black = new Pen(Color.Black,Width=4.0f)
    draw.Graphics.DrawEllipse(black,10.0f,10.0f,160.0f,160.0f))
*)

(*
/// ********* CenterDot (center af cirklen) *********
win.Paint.Add(fun draw ->
    let CenterDotBrush = new SolidBrush(Color.Red)
    draw.Graphics.FillEllipse(CenterDotBrush,89.0f,89.0f,6.0f,6.0f))
*)

// Draw the things and animate
(* 
win.Paint.Add (fun e ->
        e.Graphics.DrawLines (pen, (rotate (timer*System.Math.PI/60.0) hourHand)) // Takes input from model (hourHand)
        // e.Graphics.DrawLines (pen, pts.[1]) // Takes input from model (minuteHand)
        // e.Graphics.DrawLines (pen, pts.[2]) // Takes input from model (secondHand)
        e.Graphics.DrawEllipse (pen,10.0f,10.0f,160.0f,160.0f))
win.Refresh()
*)

Application.Run win // start event - loop