open ImgUtil


// Draws a whole lot of red squares in a grid
let rec square bmp len depth (x,y) =
    // if len < depth, draw a red box at x,y, with width and height = len
    // bmp is the bitmap, given  to setBox for drawing on it
  if depth <= 0 then setBox red (x,y) (x+len,y+len) bmp
  else let half = len / 2
       // Square of half size, starting at x,y       
       do square bmp half (depth-1) (x,y)
       // Square of half size, starting at x+half,y
       do square bmp half (depth-1) (x+half,y)
       // Square of half size, starting at x,y+half
       do square bmp half (depth-1) (x,y+half)
        // Square of half size, starting at x+half,y+half
       do square bmp half (depth-1) (x+half,y+half) 



// Draw function
// This is called whenever the user presses a key
// It takes a width and a height, as well as x, which can be anything.
// Here, x is an inter.
let draw w h x =
    // mk is a function in ImgUtil that returns a BitMap
    let bitmap = mk h w
    // Call triangle, supplying the new bitmap as an argument
    // Give 512 as len, and x as depth
    do square bitmap 640 x (60,60)
    // Return the bitmap after triangles have been drawn
    bitmap

// React function
// This will be called when the user presses a key
    // It takes an x as input. This is the x that was used to draw the last bitmap.
    // If The key is the up arrow, x is halved.
    // If the key is the down arrow, x is doubled
    // x becomes the input of the next call to draw
let react x (e:System.Windows.Forms.KeyEventArgs) =
    let max = 6
    match e.KeyCode with
        | System.Windows.Forms.Keys.Up ->
            match max > x with
                 | true -> Some (x+1)
                 | false -> Some (max)
        | System.Windows.Forms.Keys.Down ->
            match 0 < x with
                | false ->
                        Some (0)
                | true ->
                        Some (x-1)
        | _ -> printfn "No event for key."; None




// Starts an application, with
// title: "Squares"
// width: 800
// Height: 800
// A redrawing function that draws new squares
// A react function, that changes the depth of the recursion
do runApp "square" 800 800 draw react (0)

