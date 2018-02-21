/// Christian Sass Hansen
/// Task 10o1
/// Last edited: 08/12 - 2017

type Car (efficiency:int) = class
    //int
    let mutable gas = 0

    // unit -> int
    member this.Efficiency = efficiency

    // unit -> int
    member this.AddGas (value:int) = gas <- gas + value

    // unit -> int
    member this.GasLeft = printfn "Gas left: %i" gas

    //
    member this.Drive (distance:int) =
        let mutable usedGas = 0

        if (distance % this.Efficiency) <> 0 then
            usedGas <- (distance/this.Efficiency) + 1
         else
             usedGas <- (distance/this.Efficiency)

        if (gas - usedGas) >= 0 then
            gas <- (gas - usedGas)
            printfn "A %A km long drive has used %A liters of gas" distance usedGas
        else
            printfn "We cannot drive that far with our current amount of Gas"
end

// unit -> unit
let ex1 () =
    let Volvo = new Car(10)
    Volvo.AddGas 52
    Volvo.GasLeft
    Volvo.Drive 25
    Volvo.GasLeft
    Volvo.Drive 500

ex1()
