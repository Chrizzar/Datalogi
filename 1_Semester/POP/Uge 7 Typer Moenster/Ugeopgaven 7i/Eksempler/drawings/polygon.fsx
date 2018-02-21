open ImgUtil

let rnd = System.Random()

let random_color () =
    // All possible rgb values
    System.Drawing.Color.FromArgb(255,rnd.Next(255),rnd.Next(255),rnd.Next(255))
    // Define what colors to choose from if desired
    // match rnd.Next(3) with
    //     | 0 -> red
    //     | 1 -> blue
    //     | 2 -> green
    //     | _ -> System.Drawing.Color.Purple

// Draw a polygon
let rec polygon bmp (n, i, radius, color)  (x,y) =
    let pi = System.Math.PI
    let (v1x,v1y) =
        let v =
            (2.0 * pi * (float i)) / (float n) in
            (float x + radius * cos v, float y + radius * sin v)
    let (v2x,v2y) =
        let v =
            (2.0 * pi * (float (i+1))) / (float n) in
            (float x + radius * cos v, float y + radius * sin v)

    if n > i then
        do polygon bmp (n, (i+1), radius, color) (x,y)
    do setLine color (int v1x, int v1y) (int v2x, int v2y) bmp

let polygon_react ((n:int), (i:int), (radius:float), color) (e:System.Windows.Forms.KeyEventArgs) =
    let max = 180
    let new_color = random_color ()
    match e.KeyCode with
        | System.Windows.Forms.Keys.Up ->
            match max > n with
                | false ->
                    Some (max, 0, radius, new_color)
                | true ->
                    Some (n + 1, 0, radius, new_color)
        | System.Windows.Forms.Keys.Down ->
            match 0 < n with
                | false ->
                        Some (0, i, radius, new_color)
                | true ->
                        Some (n-1, i, radius, new_color)
        | _ -> printfn "Not registered"; None
    

// Draw function
// This is called whenever the user presses a key
// It takes a width and a height, as well as x, which can be anything.
// Here, x has type (int * int * float * System.Drawing.Color).
let draw w h x =
    // mk is a function in ImgUtil that returns a BitMap
    let bitmap = mk h w
    // Call triangle, supplying the new bitmap as an argument
    do polygon bitmap x (w/2, h/2)
    // Return the bitmap after circle have been drawn
    bitmap

// Starts an application, with
// title: Polygon
// width: 800
// Height: 800
// Polygon sides: 10
// A redrawing function that draws a polygon
// And can increase/decrease number of sides
// A react function, that changes the sides of the polygon (and the color)
do runApp "Polygon" 800 800 draw polygon_react (10, 0, 100.0, (random_color ()))

