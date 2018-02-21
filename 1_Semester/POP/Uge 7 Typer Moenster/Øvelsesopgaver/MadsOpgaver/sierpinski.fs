open ImgUtil

// Draws a whole lot of triangles
// I added the depth argument and replaced
// The magic constant being compared to len with depth.
let rec triangle bmp len depth (x,y) =
    // if len < depth, draw a red box at x,y, with width and height = len
    // bmp is the bitmap, given  to setBox for drawing on it
  if len < depth then setBox red (x,y) (x+len,y+len) bmp
  // If not, try halving len and calling triangle
  else let half = len / 2
       do triangle bmp half depth (x+half/2,y)
       do triangle bmp half depth (x,y+half)
       do triangle bmp half depth (x+half,y+half) 

// Starts an application, with
// title: Sierpinski
// width: 600
// Height: 600
// A redrawing function that does nothing. It just draws the triangles with
// 512 hardcoded as len
// Pipes the result to ignore
// We don't need the result when we are not drawing anything new
//do runSimpleApp "Sierpinski" 600 600 (fun bmp -> triangle bmp 512 (30,30) |> ignore)

// Draw function
// This is called whenever the user presses a key
// It takes a width and a height, as well as x, which can be anything.
// Here, x is an inter.
let draw w h x =
    // mk is a function in ImgUtil that returns a BitMap
    let bitmap = mk h w
    // Call triangle, supplying the new bitmap as an argument
    // Give 512 as len, and x as depth
    // Let the offset to start from be (30,30)
    do triangle bitmap 512 x (30,30)
    // Return the bitmap after triangles have been drawn
    bitmap

// React function
// This will be called when the user presses a key
    // It takes an x as input. This is the x that was used to draw the last bitmap.
    // If The key is the up arrow, x is halved.
    // If the key is the down arrow, x is doubled
    // x becomes the input of the next call to draw
let react x (e:System.Windows.Forms.KeyEventArgs) =
    printfn "%A" x
    match e.KeyCode with
        | System.Windows.Forms.Keys.Up ->
            match x > 2 with
                // ensure the minimum depth value is 2
                | true -> Some (max 2 (x/2))
                | false -> Some 2
        | System.Windows.Forms.Keys.Down ->
            match x < 512 with
                // Ensure the maximum depth value is 512
                | true ->  Some (min 512 (x*2))
                | false -> Some 512
        | _ -> printfn "Not registered"; None

// Starts an application, with
// title: Sierpinski
// width: 600
// Height: 600
// A redrawing function that draws new triangles.
// A react function, that changes the depth of the recursion
do runApp "Sierpinski" 600 600 draw react (64)
