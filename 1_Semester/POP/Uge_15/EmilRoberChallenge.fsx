// Class declaration and primary constructor
type laser(p,a) =
  // Privates
  let mutable power = p
  let mutable accuracy = a

  // Public methods
  member x.Shoot() =
    power <- power - 1.0
    do printfn "power %f, accuracy: %f" power accuracy
  member x.Scan() = 
    if power < 50.0 then power <- power * 0.9 else power <- power * 0.7
    accuracy <- accuracy * 1.05
    do printfn "power %f, accuracy: %f" power accuracy
  
  // Additional constructor
  new(input : float) = 
    let rnd = System.Random()
    // Calculating random value in the interval [1;100] and binding it to wineVal
    let wineVal = (rnd.Next() % 100) + 1
    // Checks whether wineVal is above 50
    if wineVal > 50 then
      let acc = float (rnd.Next(100))  // Getting random value for accuracy
      new laser(input,acc)             // Calling primary constructor
    else 
      let pow = float (rnd.Next(100))  // Getting random value for power
      new laser(pow,input)             // Calling primary constructor


let q = new laser(27.1)
let p = new laser(100.0)

q.Shoot()
p.Shoot()
