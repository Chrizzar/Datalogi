(*
   POP 2017
   Jan Rolandsen
   Exercise 7ø.4 -> Example code
*)

//### Fractal, Sierpinsky
//### Compilation

//    To avoid display flickering use the smooth version:

//    $ fsharpc -a img_util.fsi img_util_smooth.fs
//    $ fsharpc -r img_util_smooth.dll 7o4.fs

//### Execution on Linux+Windows

//    $ mono 7o4.exe

//### Execution on MacOS

//    $ mono --arch=32 7o4.exe

open ImgUtil

// This is running example code.
// Your task is to do the following:
//    0)  compile the code as-is and use keyUp, keyDown
//    1)  edit the code (add/delete/replace/etc.) to complete the tasks:
//        1a) at startup the "Level 0" image is shown in full size
//        1b) pressing keyUp will show the next image, Level (K+1), in full size
//        1c) pressing keyDown will show the previous image, Level (K-1), in full size
//    2)  use the function ImgUtil.toPngFile and save each level image in a file ("Level-2.png")
// Enjoy


// useful konstants
let BOXSIZE = 64
let W = 600
let H = 600
let STARTXY = (30, 30)
let STEP = 1
let INIT = 48

let rec triangle bmp len (x,y) =
  if len < BOXSIZE then
      setBox red (x,y) (x+len, y+len) bmp
  else let half = len / 2
       do triangle bmp half (x + half/2, y)
       do triangle bmp half (x, y + half)
       do triangle bmp half (x + half, y + half)
;;

// val draw: int -> int -> 's -> bitmap
let draw (w: int) (h: int) state =
    let bmp = ImgUtil.mk w h          // create a bitmap width=w, height=h
    triangle bmp state STARTXY        // draw image to screen at (30,30)
    bmp                               // returnvalue
;;


// The function below MUST be REWRITTEN using Pattern Matching.
// val react : 's -> KeyEventArgs -> 's option
let react state (e: System.Windows.Forms.KeyEventArgs) =
    if e.KeyCode = System.Windows.Forms.Keys.Up then
        Some (state + STEP)              // increase in steps of STEP
    elif e.KeyCode = System.Windows.Forms.Keys.Down then
        Some (state - STEP)              // decrease in steps of STEP
    else Some state                      // unknown key pressed, don't change the state
;;

// initial state
let init =
    INIT                          // starting value
                                  // other start values could be here
;;

// run sierpinsky and make use of keyUp and KeyDown
do runApp "Exercise 7o.4" W H draw react init

// end
