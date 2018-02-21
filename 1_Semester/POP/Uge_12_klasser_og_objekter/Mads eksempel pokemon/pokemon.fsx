type Pokemon() =
    let rnd = new System.Random()
    let mutable pokename = "Generic Pokemon"
    let mutable health = 10
    let mutable strength = 1
    let mutable level = 1
    let chanceToHit = 80
    let criticalChance = 10
    // Percentage to add when critical hit
    let criticalBonus = 30
    member this.Name
        with get() = pokename
        and set(name) = pokename <- name
    member this.Health
        with get() = health
        and set(newHealth) = health <- newHealth
    member this.Strength
        with get() = strength
        and set(s) = strength <- s
    member this.Level
        with get() = level
        and set(l) = level <- l
    member this.TakeDamage(damage:int) =
        health <- health - (abs damage)
    member this.Attack(pokemonToAttack:Pokemon) =
        // it's a hit 80 % of the time
        if rnd.Next(100) < chanceToHit then
            let crit = rnd.Next(100) < criticalChance
            if crit then
                let critBonus = (strength / 100) * criticalBonus
                pokemonToAttack.TakeDamage(strength + critBonus)
                do printfn "It's very effective!"
            else
                pokemonToAttack.TakeDamage(strength)
            // Indicate that the attack was a success
            true
        else
            // Indicate the attack failed
            false
    override this.ToString() = sprintf "Name: %s\nHealth: %d\nLevel: %d\nStrength: %d" pokename health level strength




// Class that takes two pokemon, makes them fight in a turnbased style, prints the fight and prints who won.
type Fight (poke1:Pokemon, poke2:Pokemon) =
    let pokemon1 = poke1
    let pokemon2 = poke2
    // keep track of the round
    let mutable round = 1
    member this.Fight () =
        printfn "The two pokemon %s and %s are about to fight!" pokemon1.Name pokemon2.Name

        while pokemon1.Health > 0 && pokemon2.Health > 0 do
            printfn "Round %d" round
            round <- round + 1
            printfn "%s tries to attack!" pokemon1.Name
            let attack1Result = pokemon1.Attack(pokemon2)
            if attack1Result then
                do printfn "%s took %d damage and now has %d health." pokemon2.Name pokemon1.Strength pokemon2.Health
                if pokemon2.Health <= 0 then
                    do printfn "%s fainted!" pokemon2.Name
                else
                    do printfn "%ss attack failed!" pokemon1.Name
            if pokemon2.Health > 0 then
                printfn "%s tries to attack!" pokemon2.Name
                let attack2Result = pokemon2.Attack(pokemon1)
                if attack2Result then
                    do printfn "It's very effective!\n%s took %d damage and now has %d health." pokemon1.Name pokemon2.Strength pokemon1.Health
                else
                    do printfn "%ss attack failed!" pokemon2.Name
                printfn ""
        let winner =
            if pokemon1.Health > pokemon2.Health then
                pokemon1
            else
                pokemon2
        printfn "Winner is: %s" winner.Name

// Create two pokemon that can fight each other!
let squirtle = Pokemon(Name="Squirtle")
let charmander = Pokemon(Name="Charmander")

let fight = Fight(squirtle, charmander)
fight.Fight()

// Create some stronger pokemon
let charizard = Pokemon(Name="Charizard", Strength=10, Health=100, Level=50)
let blastoise = Pokemon(Name="Blastoise", Strength=8, Health=130, Level=50)
let crazyFight = Fight(charizard, blastoise)
crazyFight.Fight()
