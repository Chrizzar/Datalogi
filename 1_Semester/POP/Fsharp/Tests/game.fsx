type Suit = Spades | Hearts | Clubs | Diamonds

type Rank = Two | Three | Four  | Five 
            | Six | Seven | Eight | Nine
            | Ten | Jack  | Queen | King | Ace

type Card = Rank * Suit

type Deck = Card list

type Player = { Name : string; Hand : Card list }

type Game = { Deck : Card list
              Players : Player list 
              CurrentPlayer : Player
              DiscardPile : Card list }

let newDeck =
    [(Two, Spades); (Three, Spades); (Four, Spades); (Five, Spades); 
    (Six, Spades); (Seven, Spades); (Eight, Spades); (Nine, Spades); 
    (Ten, Spades); (Jack, Spades); (Queen, Spades); (King, Spades); (Ace, Spades);
    (Two, Hearts); (Three, Hearts); (Four, Hearts); (Five, Hearts); 
    (Six, Hearts); (Seven, Hearts); (Eight, Hearts); (Nine, Hearts); 
    (Ten, Hearts); (Jack, Hearts); (Queen, Hearts); (King, Hearts); (Ace, Hearts);
    (Two, Clubs); (Three, Clubs); (Four, Clubs); (Five, Clubs); 
    (Six, Clubs); (Seven, Clubs); (Eight, Clubs); (Nine, Clubs); 
    (Ten, Clubs); (Jack, Clubs); (Queen, Clubs); (King, Clubs); (Ace, Clubs);
    (Two, Diamonds); (Three, Diamonds); (Four, Diamonds); (Five, Diamonds); 
    (Six, Diamonds); (Seven, Diamonds); (Eight, Diamonds); (Nine, Diamonds); 
    (Ten, Diamonds); (Jack, Diamonds); (Queen, Diamonds); (King, Diamonds); (Ace, Diamonds)]

let shuffle deck =
    let random = new System.Random()
    deck |> List.sortBy (fun card -> random.Next())


newDeck |> shuffle
newDeck
let deal deck = 
    match deck with
    | head::tail -> (Some head, tail)
    | [] -> (None, []) //handle empty list

let rec dealAllCards deck =
    let (card, remainingDeck) = deck |> deal
    match card with 
    | None -> printfn "Cards out"
    | Some c -> 
        printfn "%A" c
        remainingDeck |> dealAllCards

newDeck |> shuffle |> dealAllCards