// Learn more about F# at http://fsharp.net 
//specifies the memory location of the class files 
//that will be needed in our application 
open System.Collections.Generic
open System
open System.Windows.Forms
open System.ComponentModel
open System.Drawing
open System.Drawing.Drawing2D
let drawingform = new Form (Text = "Paint Application", AutoScaleDimensions = new System.Drawing.SizeF (60.0F, 13.0F), ClientSize = new System.Drawing.Size (400, 250), StartPosition = FormStartPosition.CenterScreen) 

//creates our control 
let exitbutton=new Button(Text = "Exit", Location = new System.Drawing.Point (200, 200)) 
let erasebutton=new Button(Text = "Erase", Location = new System.Drawing.Point (120, 200)) 
let colorbutton=new Button(Text = "Brush Color", Location = new System.Drawing.Point (40, 200)) 
drawingform.Controls.Add(exitbutton) 
drawingform.Controls.Add(erasebutton) 
drawingform.Controls.Add(colorbutton) 

//creates a color dialog box 
let colordlg = new ColorDialog() 

//creates a colorblend object 
let mutable color = new ColorBlend() 
let gr = drawingform.CreateGraphics() 
gr.SmoothingMode <- SmoothingMode.HighQuality 

//when the form is loaded, change its color to white 
drawingform.Load.Add (fun background -> 
    //set the default brush color to indigo 
    color.Colors <- [|Color.Indigo|]
    drawingform.BackColor <- Color.White) 

drawingform.MouseMove.Add (fun trail -> 
    //when the mouse button is moved and the left button is clicked 
    if (trail.Button = System.Windows.Forms.MouseButtons.Left) then
        //draw the object assign the color seleted from the color dialog as a brush color 
        gr.FillRectangle (new SolidBrush(color.Colors.[0]), new Rectangle (trail.X, trail.Y, 5, 5)))  

//when the erase button is clicked 
//erase the object drawn in the form 
erasebutton.Click.Add (fun erase -> gr.Clear(Color.White))  

//when the exit button is clicked 
//quit the form                                                                                                               
exitbutton.Click.Add (fun quit -> drawingform.Close()) 

//when the brush color button is selected                                                           
colorbutton.Click.Add (fun colors -> 
    //display the Color Dialog box 
    if colordlg.ShowDialog() = DialogResult.OK then 
        //store the value selected by the user in our colorblend object 
        color.Colors <- [|colordlg.Color|]) 

//executes our application
Application.Run (drawingform) 