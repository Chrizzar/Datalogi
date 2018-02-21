open System  
open System.Windows.Forms  
open System.ComponentModel  
open System.Drawing  

// ********* Winforms specifics *********
let win = new Form()
win.ClientSize <- Size (400, 400)

/// ********* Working Digital Clock *********
// make a label to show time
let digitalTimerLabel = new Label ()
win.Controls.Add digitalTimerLabel
digitalTimerLabel.Width <- 200
digitalTimerLabel.Location <- new Point (150,320)
//digitalTimerLabel.Text <- string System.DateTime.Now // get present time and date


/// ********* ClockHands (Ur-visere) *********
let myPaint (e : PaintEventArgs) : unit =
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
                let (a, b) = (x * cos t - y * sin t, x * sin t + y * cos t) // (150.0 + (100.0 * cos t), 150.0 + (100.0 * sin t))
                Point (toInt a, toInt b)
            Array.set arr 1 (rot (theta) (arr.[1]))
            arr

    // HourHand
    let black = new Pen (Color.Black,Width=2.0f)
    let mutable hourHand = 
        [|Point (0,0); Point (0,-45)|]
    //e.Graphics.DrawLines (black, hourHand)

    // MinuteHand
    let red = new Pen (Color.Red,Width=4.0f)
    let mutable minuteHand =
        [|Point (0,0);Point (0,-20)|]
    //e.Graphics.DrawLines (red, minuteHand)

    // SecondHand
    let green = new Pen (Color.Green,Width=1.0f)
    let mutable secondHand =
        [|Point (0,0);Point (0,-45)|]
    //e.Graphics.DrawLines (green, secondHand)


    // Circle
    let circleBlack = new Pen(Color.Black,Width=4.0f)
    let circle =
        e.Graphics.DrawEllipse(circleBlack,100.0f,100.0f,200.0f,200.0f)
    circle

    // CenterDot
    let CenterDotBrush = new SolidBrush(Color.Red)
    let center =
        e.Graphics.FillEllipse(CenterDotBrush,197.5f,197.5f,5.0f,5.0f)
    center

    let dt = DateTime.Now
    let s = dt.Second
    let m = dt.Minute
    let h = dt.Hour
    let newS = rotate (float s/60.0*2.0*System.Math.PI) secondHand
    let newM = rotate (float m/60.0*2.0*System.Math.PI) minuteHand
    let newH = rotate (float h/12.0*2.0*System.Math.PI) hourHand
    let finalS = translate (Point (200, 200)) secondHand
    let finalM = translate (Point (200, 200)) minuteHand
    let finalH = translate (Point (200, 200)) hourHand

    // ********* Laver min egen translate funktion *********
    // Manuelt lave et nyt startpunkt for secondHand, minuteHand, hourHand (How to)? 
    
    // *** Hvad den er nu: ***
    // p = {x = 0 ; y = -20}

    // *** Hvad den skal blive til: ***
    // x = {p.X + 200(dx) ; y = p.Y + 200(dy)}

    e.Graphics.DrawLines (black, hourHand)
    e.Graphics.DrawLines (red, minuteHand)
    e.Graphics.DrawLines (green, secondHand)
    ()
    // Timer (fun e -> win.Invalidate)

// make a timer and link to label
win.Paint.Add myPaint

let timer = new Timer ()
timer.Interval <- 1000 // create an event every 1000 millisecond
timer.Enabled <- true // activiate the timer
timer.Tick.Add (fun e ->
    digitalTimerLabel.Text <- string System.DateTime.Now
    win.Invalidate()
)

Application.Run win // start event - loop