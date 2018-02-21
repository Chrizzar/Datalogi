// Christian Sass Hansen
// 3i0d
// Last modified: 27/09 - 2017

// Programmet køre på int32, som har en max værdi på 2.147.483.647.
// Man kan derved finde n ved at isolere ligningen 2.147.483.647 = (n*(n+1))/2, som giver 65535,49, hvor man derved så afrunder ned til nærmeste heltal, dvs. n = 65535. 
// Den første funktion "sum" kan derfor kun komme op på n = 65535. 

// 

// Hvordan kan programmet modificeres, så funktionen kan beregnes for større værdier af n?

For at funktionen kan beregne med større værdier af n, så skal funktionen sættes til at køre med integer 64. Da programmet er sat til int32, kan den nemlig kun tage fra 2.147.483.647 n tal til 2.147.483.647 n tal. Mens int64 kan tage fra omkring -9 trillioner n tal til omkring 9 trillioner n tal.
