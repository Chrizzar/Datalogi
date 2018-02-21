type Deck(randomObject: System.Random) = class
    do printfn "Deck of cards ready!"
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

    member this.GetDeck() = _deck 
   
    member this.SetDeck (newDeck: (int * string) list list) =
        _deck <- newDeck
    
    member this.DrawCard() =
        let cardNumber = randomObject.Next(0, List.length(this.GetDeck()))
        let drawnCard = this.GetDeck().[cardNumber]
        this.SetDeck(List.filter (fun card -> card <> drawnCard) (this.GetDeck()))
        drawnCard
end

type Player(playerNumber: int, playingDeck: Deck) = class
    let mutable _handList = []
    let mutable _handSum = 0
    let mutable _playing = true

    member this.GetHand () = _handList

    member this.SetHand (newCard: (int * string) list) = 
        _handList <- _handList @ newCard

    member this.GetSum () = _handSum

    member this.SetSum (newCard: (int * string) list) = 
        _handSum <- _handSum + (fst(newCard.[0]))

    member this.GetPlaying() = _playing
    
    member this.SetPlaying(value) = _playing <- value

    member this.PlayerNumber = playerNumber   

    member this.Hit () =
        let drawnCard = playingDeck.DrawCard()
        this.SetHand(drawnCard)
        this.SetSum(drawnCard)

    member this.Stand () = 
        this.SetPlaying(false)
    member this.PlayerAI() = 
        while (this.GetPlaying()) do
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
    member this.PlayerList() = 
        match playerAmount < 6 && playerAmount > 0  with
            | true  -> 
                let mutable playerOrNot = []
                let mutable fullPlayerList = []
                let mutable counter = 1

                for i=1 to playerAmount do
                    printfn "Player %d, AI or not? (yes/no)" (i)
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
            // printfn "\nSum of hand: %d" (player.GetSum())

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

                        | "stand" -> 
                            player.Stand()
                            // printf "\n--------------------------------------------\n"

                        | "Stand" -> 
                            player.Stand()
                            // printf "\n--------------------------------------------\n"

                        | _ -> printfn "Your only options are: hit or stand"

            printf "\n---------------------------------------------\n"
            resultList <- resultList @ [player.GetSum()]        
        printfn "\n%A" resultList

    new(playingDeck: Deck) = 
        let random = System.Random()
        let amountOfPlayers = random.Next(1,6)
        Game(amountOfPlayers, playingDeck)
end

let main() = 
    let generator = System.Random()
    let gameDeck = Deck(generator)

    printfn "How many players?"
    let howManyPlayers = int(System.Console.ReadLine())
    let playingGame = Game(howManyPlayers, gameDeck)
    playingGame.StartGame()

main()

(*
        // Unicode list, doesn't work on windows :(
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