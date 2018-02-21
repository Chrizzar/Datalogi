
// ********* Hjælp *********
// 4 shapes (3 visere og en cirkel) ligge ind i et arrat, 
// så den tegner det hvert sekund.
// Start viserene ved 12 (Til at starte med).

/// ********* Working Circle *********

open System  
open System.Windows.Forms  
open System.ComponentModel  
open System.Drawing  

// ********* Cirkel *********
let win = new Form(Text="Use DrawEllipse")  
win.ClientSize <- Size (800, 400)

win.Paint.Add(fun draw ->
    let pen=new Pen(Color.Black,Width=4.0f)
    draw.Graphics.DrawEllipse(pen,10.0f,10.0f,160.0f,160.0f))

Application.Run win


// ********* Lodret Streg *********
(*
let win = new Form ()
win.ClientSize <- Size (800, 400)

let secondHand (e : PaintEventArgs) : unit =
    let pen = new Pen (Color.Black)
    let points =
        [|Point (100,50); Point(100,170)|]
    e.Graphics.DrawLines (pen, points)
win.Paint.Add secondHand

// let secondHandTimer = 

Application.Run win
*)



/// ********* Working Digital Clock *********
(*
open System.Windows.Forms
open System.Drawing
open System
*) 


let win = new Form () // make a window form
win.ClientSize <- Size (200, 50)

// make a label to show time
let label = new Label ()
win.Controls.Add label
label.Width <- 200
label.Text <- string System.DateTime.Now // get present time and date

// make a timer and link to label
let timer = new Timer ()
timer.Interval <- 1000 // create an event every 1000 millisecond
timer.Enabled <- true // activiate the timer
timer.Tick.Add (fun e -> label.Text <- string System.DateTime.Now)

Application.Run win // start event - loop
