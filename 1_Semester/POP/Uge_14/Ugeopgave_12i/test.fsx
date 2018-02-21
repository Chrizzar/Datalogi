open System  
open System.Windows.Forms  
open System.ComponentModel  
open System.Drawing

let rotate (theta : float) (arr : Point []) : Point [] =
        let toInt = int << round
        let rot (t : float) (p : Point) : Point =
            let (x, y) = (float p.X, float p.Y)
            let (a, b) = (x * cos t - y * sin t, x * sin t + y * cos t)
            Point (toInt a, toInt b)
        Array.set arr 1 (rot (theta) (arr.[1]))
        arr
(*
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
*)
let dt = DateTime.Now
let s = dt.Second
let m = dt.Minute
let h = dt.Hour
let newS = rotate (float s/60.0*2.0*System.Math.PI)
printf "%A" newS
(*
let newM = rotate (float m/60.0*2.0*System.Math.PI) minuteHand
let newH = rotate (float h/12.0*2.0*System.Math.PI) hourHand
*)