open System
open System.Windows.Forms
open System.Drawing  

// ********* Winforms specifics *********
// Extended the default Form to avoid display flickered
type SmoothForm() as x =
    inherit Form()
    do x.DoubleBuffered <- true

let win = new SmoothForm()
win.ClientSize <- Size (400, 400)

/// ********* Digital Clock *********
// make a label to show time
let digitalTimerLabel = new Label ()
win.Controls.Add digitalTimerLabel
digitalTimerLabel.Width <- 200
digitalTimerLabel.Location <- Point (150,320)

// Timer
let timer = new Timer ()
timer.Interval <- 1000 // create an event every 1000 millisecond
timer.Enabled <- true // activiate the timer
timer.Tick.Add (fun _e ->
    digitalTimerLabel.Text <- string System.DateTime.Now
    win.Invalidate()
)

// ********* Translate function *********
let translate (d : Point) (arr : Point []) : Point [] =
    let add (d : Point) (p : Point) : Point =
        Point (d.X + p.X, d.Y + p.Y)
    Array.map (add d) arr

// ********* Rotate the clock hands *********
let rotate (theta : float) (arr : Point []) : Point [] =
    let toInt = int << round
    let rot (t : float) (p : Point) : Point =
        let (x, y) = (float p.X, float p.Y)
        let (a, b) = (x * cos t - y * sin t, x * sin t + y * cos t)
        Point (toInt a, toInt b)
    Array.map (rot theta) arr


/// ********* ClockHands (Ur-visere) *********
let myPaint (e : PaintEventArgs) : unit =
    // HourHand
    let black = new Pen (Color.Black,Width=4.0f)
    let hourHand = 
        [|Point (0,0); Point (0,-60)|]

    // MinuteHand
    let red = new Pen (Color.Red,Width=4.0f)
    let minuteHand =
        [|Point (0,0);Point (0,-90)|]

    // SecondHand
    let green = new Pen (Color.Green,Width=1.0f)
    let secondHand =
        [|Point (0,0);Point (0,-90)|]

    // Circle
    let circleBlack = new Pen(Color.Black,Width=4.0f)
    let circle =
        e.Graphics.DrawEllipse(circleBlack,100.0f,100.0f,200.0f,200.0f)
    circle

    //Circle color
    let circlecolorBrush = new SolidBrush(Color.LightSalmon)
    let circle =
        e.Graphics.FillEllipse(circlecolorBrush,100.0f,100.0f,200.0f,200.0f)
    circle
    
    // CenterDot
    let centerDotBrush = new SolidBrush(Color.Red)
    let center =
        e.Graphics.FillEllipse(centerDotBrush,197.5f,197.5f,5.0f,5.0f)
    center

    // Time
    let dt = DateTime.Now
    let s = dt.Second
    let m = dt.Minute
    let h = dt.Hour
    
    // Make Rotation
    let secondHand = rotate (float s/60.0*2.0*System.Math.PI) secondHand
    let minuteHand = rotate (float m/60.0*2.0*System.Math.PI) minuteHand
    let hourHand   = rotate (float h/12.0*2.0*System.Math.PI) hourHand
    // Make Translate (Moving Point)
    let secondHand = translate (Point (200, 200)) secondHand
    let minuteHand = translate (Point (200, 200)) minuteHand
    let hourHand   = translate (Point (200, 200)) hourHand
    e.Graphics.DrawLines (black, hourHand)
    e.Graphics.DrawLines (red,   minuteHand)
    e.Graphics.DrawLines (green, secondHand)

win.Paint.Add myPaint

Application.Run win // start event - loop