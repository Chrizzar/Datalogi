type Deck(randomObject: System.Random) = class
    do printfn "Deck of cards ready!"
    // (int * string) list list
    let mutable _deck =

        // Card represented as tuples of
        // (card_value (int), card_terminal_representation (string))
        [[(1,"AofH")]; [(1,"AofD")]; [(1,"AofS")]; [(1,"AofC")];
        [(2,"2ofH")]; [(2,"2ofD")]; [(2,"2ofS")]; [(2,"2ofC")];
        [(3,"3ofH")]; [(3,"3ofD")]; [(3,"3ofS")]; [(3,"3ofC")];
        [(4,"4ofH")]; [(4,"4ofD")]; [(4,"4ofS")]; [(4,"4ofC")];
        [(5,"5ofH")]; [(5,"5ofD")]; [(5,"5ofS")]; [(5,"5ofC")];
        [(6,"6ofH")]; [(6,"6ofD")]; [(6,"6ofS")]; [(6,"6ofC")];
        [(7,"7ofH")]; [(7,"7ofD")]; [(7,"7ofS")]; [(7,"7ofC")];
        [(8,"8ofH")]; [(8,"8ofD")]; [(8,"8ofS")]; [(8,"8ofC")];
        [(9,"9ofH")]; [(9,"9ofD")]; [(9,"9ofS")]; [(9,"9ofC")];
        [(10,"10JofH")]; [(10,"10JofD")]; [(10,"10JofS")]; [(10,"10JofC")];
        [(10,"10QofH")]; [(10,"10QofD")]; [(10,"10QofS")]; [(10,"10QofC")];
        [(10,"10KofH")]; [(10,"10KofD")]; [(10,"10KofS")]; [(10,"10KofC")]]

    // unit -> (int * sting) list list
    member this.GetDeck () = _deck

    // (int * string) list list -> unit
    member this.SetDeck (newDeck: (int * string) list list) =
        _deck <- newDeck

    /// XMLdoc header for the method DrawCard:

    /// <summary> The method "this.DrawCard", takes a random object inside the list: "_deck" with the method "GetDeck", 
    /// from within index 0 to the length of the list: "List.length(this.GetDeck()". 
    /// It then will draw random a card from within the deck, with a random index 0 to the length of the list, and use
    /// "filter" to filter out the card (delete the card) from the deck, so which this card can't be drawn again. </summary>
    /// <remarks> The method will filter out (delete) the drawn card from the deck, so it can't be drawn again. <remarks>
    /// <returns> Will return a random card </returns>
    
    // unit -> (int * string) list
    member this.DrawCard() =
        let cardNumber = randomObject.Next(0, List.length(this.GetDeck()))
        let drawnCard = this.GetDeck().[cardNumber]
        this.SetDeck(List.filter (fun card -> card <> drawnCard) (this.GetDeck()))
        drawnCard
end

type Player(playerNumber: int, playingDeck: Deck) = class
    // (int * string) list
    let mutable _handList = []
    let mutable _handSum = 0
    let mutable _playing = true

    // unit -> (int * string) list
    member this.GetHand () = _handList

    // (int * string) list -> unit
    member this.SetHand (newCard: (int * string) list) =
        _handList <- _handList @ newCard

    // unit -> int 
    member this.GetSum () = _handSum

    // (int * string) list -> unit
    member this.SetSum (newCard: (int * string) list) =
        _handSum <- _handSum + (fst(newCard.[0]))

    // unit -> bool
    member this.GetPlaying() = _playing

    // bool -> unit
    member this.SetPlaying(value) = _playing <- value
    // unit -> int
    member this.PlayerNumber = playerNumber
    // unit -> int
    member this.GetPlayerNumber() = this.PlayerNumber

    /// XMLdoc header for the method this.Hit:

    /// <summary> The method Hit, will use the drawCard method to draw a card from the deck and then give it to a players HandList, 
    /// using the method "this.SetHand" and calculating the new sum of the cards with the method "this.SetSum". </summary>
    /// <returns> Returns a new card, which is taken from the deck and put into a players handlist, while also calculating the sum of the
    /// cards plus the new card. </returns>

    // unit -> unit
    member this.Hit () =
        let drawnCard = playingDeck.DrawCard()
        this.SetHand(drawnCard)
        this.SetSum(drawnCard)

    // unit -> unit
    member this.Stand () =
        this.SetPlaying(false)
    // unit -> unit
    member this.PlayerAI() =
        if this.GetSum() < 18 then
            this.Hit()
        else
            this.Stand()
end

type Dealer(playingDeck: Deck) = class
    inherit Player(0, playingDeck)
    let mutable _handList = []
    let mutable _handSum = 0
    let mutable _playing = true
end

type Game(playerAmount: int, playingDeck: Deck) = class
    // unit -> Player list
    member this.PlayerList() =
        match playerAmount with
            | 5 ->
                let p1 = Player(1, playingDeck)
                let p2 = Player(2, playingDeck)
                let p3 = Player(3, playingDeck)
                let p4 = Player(4, playingDeck)
                let p5 = Player(5, playingDeck)
                let d0 = Dealer(playingDeck)
                [p1;p2;p3;p4;p5] @ [d0]
            | 4 ->
                let p1 = Player(1, playingDeck)
                let p2 = Player(2, playingDeck)
                let p3 = Player(3, playingDeck)
                let p4 = Player(4, playingDeck)
                let d0 = Dealer(playingDeck)
                [p1;p2;p3;p4] @ [d0]
            | 3 ->
                let p1 = Player(1, playingDeck)
                let p2 = Player(2, playingDeck)
                let p3 = Player(3, playingDeck)
                let d0 = Dealer(playingDeck)
                [p1;p2;p3] @ [d0]
            | 2 ->
                let p1 = Player(1, playingDeck)
                let p2 = Player(2, playingDeck)
                let d0 = Dealer(playingDeck)
                [p1;p2] @ [d0]
            | 1 ->
                let p1 = Player(1, playingDeck)
                let d0 = Dealer(playingDeck)
                [p1] @ [d0]
            | _ -> failwith ("Not enough/Too many amount of players")

    // unit -> unit
    member this.StartGame() =
        let listOfPlayers = this.PlayerList()
        let mutable resultList = []

        for player in listOfPlayers do
            player.Hit()
            player.Hit()

        for player in listOfPlayers do
            for card in player.GetHand() do
                printf "%s " (snd(card))
            printfn "\nSum of hand: %d" (player.GetSum())

            while (player.GetPlaying() && player.GetSum() < 21) do
                match player.GetPlayerNumber() with
                    | 0 ->
                        printfn "\nDealers turn"
                        player.PlayerAI()
                        // printfn "Sum of hand: %d" (player.GetSum())

                    | _ ->
                        printfn "Player %d, Hit or stand?" (player.GetPlayerNumber())
                        let answer = System.Console.ReadLine()
                        match answer with
                            | "hit" ->
                                player.Hit()
                                for card in player.GetHand() do
                                    printf "%s " (snd(card))
                                printfn "\n"
                                printfn "\nSum of hand: %d" (player.GetSum())

                            | "Hit" ->
                                player.Hit()
                                for card in player.GetHand() do
                                    printf "%s " (snd(card))
                                printfn "\n"
                                printfn "\nSum of hand: %d" (player.GetSum())

                            | "stand" ->
                                player.Stand()
                                printfn "\nSum of hand: %d" (player.GetSum())

                            | "Stand" ->
                                player.Stand()
                                printfn "\nSum of hand: %d" (player.GetSum())

                            | _ -> printfn "Your only options are: hit or stand"
            resultList <- player.GetSum() :: resultList
        printfn "%A" resultList
    
    // Deck -> Game
    new(playingDeck: Deck) =
        let random = System.Random()
        let amountOfPlayers = random.Next(1,6)
        Game(amountOfPlayers, playingDeck)
end

// unit -> unit
let main() =
    let generator = System.Random()
    let gameDeck = Deck(generator)
    let playingGame = Game(5, gameDeck)
    playingGame.StartGame()

main()

(*
        // Unicode list, doesn't work on windows PepeHands
        [[(1,"\u2665")];[(1,"\u2666")];[(1,"\u2660")];[(1,"\u2663")];
        [(2,"\u2665")];[(2,"\u2666")];[(2,"\u2660")];[(2,"\u2663")];
        [(3,"\u2665")];[(3,"\u2666")];[(3,"\u2660")];[(3,"\u2663")];
        [(4,"\u2665")];[(4,"\u2666")];[(4,"\u2660")];[(4,"\u2663")];
        [(5,"\u2665")];[(5,"\u2666")];[(5,"\u2660")];[(5,"\u2663")];
        [(6,"\u2665")];[(6,"\u2666")];[(6,"\u2660")];[(6,"\u2663")];
        [(7,"\u2665")];[(7,"\u2666")];[(7,"\u2660")];[(7,"\u2663")];
        [(8,"\u2665")];[(8,"\u2666")];[(8,"\u2660")];[(8,"\u2663")];
        [(9,"\u2665")];[(9,"\u2666")];[(9,"\u2660")];[(9,"\u2663")];
        [(10,"J\u2665")];[(10,"J\u2666")];[(10,"J\u2660")];[(10,"J\u2663")];
        [(10,"Q\u2665")];[(10,"Q\u2666")];[(10,"Q\u2660")];[(10,"Q\u2663")];
        [(10,"K\u2665")];[(10,"K\u2666")];[(10,"K\u2660")];[(10,"K\u2663")]]

        // Card represented as tuples of
        // (card_value (int), card_terminal_representation (string))
        [[(1,"1ofH")]; [(1,"1ofD")]; [(1,"1ofS")]; [(1,"1ofC")];
        [(2,"2ofH")]; [(2,"2ofD")]; [(2,"2ofS")]; [(2,"2ofC")];
        [(3,"3ofH")]; [(3,"3ofD")]; [(3,"3ofS")]; [(3,"3ofC")];
        [(4,"4ofH")]; [(4,"4ofD")]; [(4,"4ofS")]; [(4,"4ofC")];
        [(5,"5ofH")]; [(5,"5ofD")]; [(5,"5ofS")]; [(5,"5ofC")];
        [(6,"6ofH")]; [(6,"6ofD")]; [(6,"6ofS")]; [(6,"6ofC")];
        [(7,"7ofH")]; [(7,"7ofD")]; [(7,"7ofS")]; [(7,"7ofC")];
        [(8,"8ofH")]; [(8,"8ofD")]; [(8,"8ofS")]; [(8,"8ofC")];
        [(9,"9ofH")]; [(9,"9ofD")]; [(9,"9ofS")]; [(9,"9ofC")];
        [(10,"10JofH")]; [(10,"10JofD")]; [(10,"10JofS")]; [(10,"10JofC")];
        [(10,"10QofH")]; [(10,"10QofD")]; [(10,"10QofS")]; [(10,"10QofC")];
        [(10,"10KofH")]; [(10,"10KofD")]; [(10,"10KofS")]; [(10,"10KofC")]]
*)

// =============================================================================
// UNIT TESTING
//
// A unit test can be built up as the three steps
// Arrange - Create instances and set up the "environment" to test
// Act - Act upon those instances
// Assert - Assert the behaviour was as expected
// =============================================================================

// Unit test, that tests the StartGame method works as expected

(*
member this.Hit () =
        let drawnCard = playingDeck.DrawCard()
        this.SetHand(drawnCard)
        this.SetSum(drawnCard)
*)
let SimpleTestHit() =
    // (Arrange) Creating instances
    let SimpleTest1 = player.Hit()
    // (ACT) Act on instances
    SimpleTest1.Hit()
    // (ASSERT) behaviour was as expected
    // We should have got a card
    SimpleTest1