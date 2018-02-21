
type dealer () = class
    member this.deck = [
        (1, "Hearts"); (1, "Diamond"); (1, "Spades"); (1, "Clover");
        (2, "Hearts"); (2, "Diamond"); (2, "Spades"); (2, "Clover");
        (3, "Hearts"); (3, "Diamond"); (3, "Spades"); (3, "Clover");
        (4, "Hearts"); (4, "Diamond"); (4, "Spades"); (4, "Clover");
        (5, "Hearts"); (5, "Diamond"); (5, "Spades"); (5, "Clover");
        (6, "Hearts"); (6, "Diamond"); (6, "Spades"); (6, "Clover");
        (7, "Hearts"); (7, "Diamond"); (7, "Spades"); (7, "Clover");
        (8, "Hearts"); (8, "Diamond"); (8, "Spades"); (8, "Clover");
        (9, "Hearts"); (9, "Diamond"); (9, "Spades"); (9, "Clover");
        (10, "Hearts"); (10, "Diamond"); (10, "Spades"); (10, "Clover");
        (10, "Hearts"); (10, "Diamond"); (10, "Spades"); (10, "Clover");
        (10, "Hearts"); (10, "Diamond"); (10, "Spades"); (10, "Clover")
    ]
end

let dealer1 =
    dealer()

let rnd = System.Random()
let rndNext = rnd.Next(dealer1.deck.Length - 1)

printfn "%A" (dealer1.deck.[rndNext])


(*
// ********* Working random number generator ************
let deck = [1;1;1;1;2;2;2;2;3;3;3;3;4;4;4;4;5;5;5;5;6;6;6;6;7;7;7;7;8;8;8;8;9;9;9;9;10;10;10;10;10;10;10;10;10;10;10;10]
let rnd = System.Random()
let rndNext = rnd.Next(deck.Length - 1)

printfn "%A" (deck.[rndNext])
*)


// let simpleJack = 21


(*
let player = 


let playerCardReceive =

let deal deck = function
    | card1::card2::remaining -> Some(card1, card2), remaining
    | _ -> None, []


let deal deck = 
    match deck with
    | head::tail -> (Some head, tail)
    | [] -> (None, []) //handle empty list
*)