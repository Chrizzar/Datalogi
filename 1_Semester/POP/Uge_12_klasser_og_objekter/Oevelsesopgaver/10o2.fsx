/// Christian Sass Hansen
/// Task 10o2
/// Last edited: 08/12 - 2017

type coordinate = float * float
(*
type moth (xCoordinate: float,  yCoordinate: float) = class
    let mutable x = xCoordinate
    let mutable x = yCoordinate

    member this.GetPosition () = (x, y)
    member this.MoveToLight (xCoorLight: float, yCoorLight: float) =
*)

type Moth (position:coordinate, name:string, light:coordinate) = class
    // Coordinate
    let mutable currentPosition = position
    // unit -> coordinate
    member this.Position = currentPosition // this : den skal ændre noget på sig selv
    // unit -> coordinate
    member this.Light = light
    // unit -> unit
    member this.PrintName = printfn "%s" name

    // unit -> unit
    member this.MoveTowardsLight =
        let distanceToMove (x0,x1) (y0,y1) =
            ( (y0 + (x0-y0)/2.0),(y1 + (x1-y1)/2.0) )

        currentPosition <- (distanceToMove (this.Light) (this.Position))

end

// unit -> unit
 let ex2() =
     let insekt = new Moth()
