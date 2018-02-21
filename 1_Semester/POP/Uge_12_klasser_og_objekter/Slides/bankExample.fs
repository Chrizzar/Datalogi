// Source: https://en.wikibooks.org/wiki/F_Sharp_Programming/Classes#Example
//License: Creative Commons Attribution-ShareAlike License

open System
type Account(number : int, holder : string) = class
    let mutable amount = 0m

    member x.Number = number
    member x.Holder = holder
    member x.Amount = amount

    member x.Deposit(value) = amount <- amount + value
    member x.Withdraw(value) = amount <- amount - value
end

let homer = new Account(12345, "Homer")
let marge = new Account(67890, "Marge")

let transfer amount (source : Account) (target : Account) = 
    source.Withdraw amount
    target.Deposit amount

let printAccount (x : Account) =
    printfn "x.Number: %i, x.Holder: %s, x.Amount: %M" x.Number x.Holder x.Amount

let main() = 
    let printAccounts()=
        [homer; marge] |> Seq.iter printAccount

    printfn "\nInitializing account"
    homer.Deposit 50M
    marge.Deposit 100M
    printAccounts()

    printfn "\nTransferring 30 from Marge to Homer"
    transfer 30M marge homer
    printAccounts()

    printfn "\nTransferring 75 from Homer to Marge"
    transfer 75M homer marge
    printAccounts()

main()