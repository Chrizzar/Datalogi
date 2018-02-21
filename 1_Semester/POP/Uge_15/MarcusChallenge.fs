open System

//create two new wrapper types
type Power = Power of float
type Accuracy = Accuracy of float



type Laser(p : float,a : float)=
    //variables which
    //will be set in the primary constructor
    //(this is if we pass 2 arguments)
    let mutable power = p
    let mutable accuracy = a

    //this secondary constructor is used
    //if we give the constructor a power value
    new (pow : Power) = 
        //we generate a random value for the accuraccy
        let acr : float = (Random().Next(1,50) |> float)
        //and call the primary constructor with our new
        //arguments
        Laser(match pow with
              |Power x->x
              ,acr)
    //we do the same here, except with accuraccy
    //instead of power
    new (acr : Accuracy) = 
        let pow : float = (Random().Next(1,50) |> float)
        Laser(pow, match acr with
                   |Accuracy x->x
                    )    

    //the shoot and scan methods from the lecture
    member x.Shoot() = 
        power <- (power - 1.0)
        do printfn "Power left: %f power" power

    member x.Scan() =
        if power > 50.0 then power <- power *0.9 else power <- power*0.7
        accuracy <- accuracy*1.05
        do printfn "power: %f, accuracy: %f" power accuracy

//we can now simply instantiate new objects
//by casting floats to our wrapper types
let l1 = new Laser(5.0|>Power)
let l2 = new Laser(3.0|>Accuracy)

l1.Shoot()
l2.Shoot()
l1.Scan()
l2.Scan()