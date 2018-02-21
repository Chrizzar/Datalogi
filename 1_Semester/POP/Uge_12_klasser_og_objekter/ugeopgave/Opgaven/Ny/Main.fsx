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
        [(10,"JofH")]; [(10,"JofD")]; [(10,"JofS")]; [(10,"JofC")];
        [(10,"QofH")]; [(10,"QofD")]; [(10,"QofS")]; [(10,"QofC")]; 
        [(10,"KofH")]; [(10,"KofD")]; [(10,"KofS")]; [(10,"KofC")]]
        // King og Hearts, King of Diamonds, King of Spades, King of Clubs

    // unit -> (int * string) list list
    member this.GetDeck() = _deck 
    
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
        while (this.GetPlaying()) do
            if this.GetSum() < 17 then
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
        match playerAmount < 6 && playerAmount > 0  with
            | true  -> 
                let mutable playerOrNot = []
                let mutable fullPlayerList = []
                let mutable counter = 1

                for i=1 to playerAmount do
                    printfn "Player %d, AI or not? (yes/no)\n" (i)
                    match System.Console.ReadLine() with
                        | "Yes" -> playerOrNot <- playerOrNot @ [1]
                        | "yes" -> playerOrNot <- playerOrNot @ [1]
                        | "y"   -> playerOrNot <- playerOrNot @ [1]
                        | "No"  -> playerOrNot <- playerOrNot @ [0]
                        | "no"  -> playerOrNot <- playerOrNot @ [0]
                        | "n"   -> playerOrNot <- playerOrNot @ [0]
                        | _     -> failwith("Yes/yes/n or No/no/n")

                for number in playerOrNot do
                    match number with
                        | 1 ->
                            fullPlayerList <- fullPlayerList @ [Player(counter+playerAmount, playingDeck)]
                            counter <- counter + 1
                        | 0 ->
                            fullPlayerList <- fullPlayerList @ [Player(counter, playingDeck)]
                            counter <- counter + 1
                        | _ -> 
                            printfn "How did it end here?"

                fullPlayerList @ [Dealer(playingDeck)]

            | false -> 
                failwith ("Not enough/Too many players!")       

    // unit -> int list
    member this.StartGame() =
        let listOfPlayers = this.PlayerList()
        let mutable resultList = []

        for player in listOfPlayers do
            player.Hit()
            player.Hit()

        for player in listOfPlayers do
            printf "Starting Hand: "
            for card in player.GetHand() do 
                printf "[%s] " (snd(card))

            while (player.GetPlaying() && player.GetSum() < 21) do
                if (player.PlayerNumber = 0) then
                    player.PlayerAI()
                    printfn "\nDealer Sum: %d\n" (player.GetSum())

                elif (player.PlayerNumber > playerAmount) then
                    player.PlayerAI()
                    printfn "\nPlayer %d Sum: %d\n" (player.PlayerNumber-playerAmount) (player.GetSum())

                elif (player.PlayerNumber >= 1 && player.PlayerNumber <= playerAmount) then
                    printfn "Player %d, Hit or stand?" (player.PlayerNumber)
                    let answer = System.Console.ReadLine()
                    match answer with
                        | "h" -> 
                            player.Hit()
                            printf "\n---------------------------------------------\nPlayer %d:" player.PlayerNumber
                            for card in player.GetHand() do 
                                printf "[%s] " (snd(card))
                            printfn "\nSum: %d\n" (player.GetSum())

                        | "hit" -> 
                            player.Hit()
                            printf "\n---------------------------------------------\nPlayer %d:" player.PlayerNumber
                            for card in player.GetHand() do 
                                printf "[%s] " (snd(card))
                            printfn "\nSum: %d\n" (player.GetSum())

                        | "Hit" -> 
                            player.Hit()
                            printf "\n--------------------------------------------\nPlayer %d:" player.PlayerNumber
                            for card in player.GetHand() do 
                                printf "[%s] " (snd(card))
                            printfn "\nSum: %d\n" (player.GetSum())

                        | "s" -> 
                            player.Stand()
                            printf "Next player's turn"

                        | "stand" -> 
                            player.Stand()
                            printf "Next player's turn"

                        | "Stand" -> 
                            player.Stand()
                            printf "Next player's turn"

                        | _ -> printfn "Your only options are: hit or stand"

            printf "\n---------------------------------------------\n"
            resultList <- resultList @ [player.GetSum()]        
        resultList

    // int list -> unit
    member this.WhoWins(listOfResults: int list) = 
        let dealerSum = listOfResults.[(listOfResults.Length)-1]
        if (listOfResults.[(List.length listOfResults)-1]) = 21 then
            printfn "The house wins, dealer has BlackJack"
        else
            for i=0 to listOfResults.Length-2 do
                if listOfResults.[i] < 22 && listOfResults.[i] > dealerSum then
                    printfn "Player %d wins!" (i+1)
                else
                    printfn "Player %d loses!" (i+1)        

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
    printfn "How many players?"
    let howManyPlayers = int(System.Console.ReadLine())
    let playingGame = Game(howManyPlayers, gameDeck)
    playingGame.WhoWins(playingGame.StartGame())

main()

(*
        // Unicode list, doesn't work on windows :(
        // Replace line 6-17 for cool icons
        [[(1,"1\u2665")];[(1,"1\u2666")];[(1,"1\u2660")];[(1,"1\u2663")];
        [(2,"2\u2665")];[(2,"2\u2666")];[(2,"2\u2660")];[(2,"2\u2663")];
        [(3,"3\u2665")];[(3,"3\u2666")];[(3,"3\u2660")];[(3,"3\u2663")];
        [(4,"4\u2665")];[(4,"4\u2666")];[(4,"4\u2660")];[(4,"4\u2663")];
        [(5,"5\u2665")];[(5,"5\u2666")];[(5,"5\u2660")];[(5,"5\u2663")];
        [(6,"6\u2665")];[(6,"6\u2666")];[(6,"6\u2660")];[(6,"6\u2663")];
        [(7,"7\u2665")];[(7,"7\u2666")];[(7,"7\u2660")];[(7,"7\u2663")];
        [(8,"8\u2665")];[(8,"8\u2666")];[(8,"8\u2660")];[(8,"8\u2663")];
        [(9,"9\u2665")];[(9,"9\u2666")];[(9,"9\u2660")];[(9,"9\u2663")];
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