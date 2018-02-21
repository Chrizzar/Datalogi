// Christian Sass Hansen
// 3i0d
// Last modified: 06/10 - 2017

// Hvad er det største n de 2 cersioner kan beregne sum funktionen

// *** sum funktionen ***
// Programmet køre på int32, som har en max værdi på 2.147.483.647.
// Man kan derved finde n ved at isolere ligningen (2.147.483.647 = (n*(n+1))/2), som giver 65535,49, hvor man derved så afrunder ned til nærmeste heltal, dvs. n = 65535.
// Den første funktion "sum" kan derfor komme op på n = 65535.

// *** simpleSum funktionen ***
// simpleSum køre variablen n, 2 gange i ligningen. Vi kan derfor regne på samme måde som med sum funktionen, bare hvor vi først dividere 2.147.483.647 med 2 altså:
// Vi isolere n med ligningen: (2.147.483.647/2 = (n*(n+1))/2), som giver 46340,45, hvor man derved så afrunder ned til nærmeste heltal, dvs. 46340.
// Den anden funktion "simpleSum" kan derfor komme op på 46340.


// Hvordan kan programmet modificeres, så funktionen kan beregnes for større værdier af n?

// For at funktionen kan beregne med større værdier af n, så skal funktionen sættes til at køre med integer 64. Da programmet er sat til int32, kan den nemlig kun tage fra 2.147.483.647 n tal til 2.147.483.647 n tal. Mens int64 kan tage fra omkring -9 trillioner n tal til omkring 9 trillioner n tal.

// Hvilket vil sige at i stedet for at skrive:

// sum : n:int -> int
// og
// simpleSum : n:int -> int

// Så skal vi skrive:

// sum : nint64 -> int64
// og
// simpleSum : n:64 -> int64
