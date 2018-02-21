// Christian Sass Hansen
// Opgave 5i0a
// Last edited 08/10-2017


// val isTable : 'a list list -> bool                                                       // signature
let isTable (xss: 'a list list option) =                                                // definition
    // We allways start with what is going to happen if the list is empty
    xss.Length > 0                                                                         // <check for NonEmptyness> &&
    // Check that 1 element not empty>
    List.foraal (fun x -> x <> None) xss // List.forall f ys                               // <check for x_j =/ Empty>
    // Check same length (xs_k = xs_j)
    List.forall (fun x -> x = ) xss                                                        // <check same |x_k| = |x_j|> &&




(*
a = List.map List.length

let square x = x*x
let l = [1..10]
list.map square l


Både lige og ulige tal: (false og true)
List.map (fun x -> x % 2 = 1) [1..100]

Kun ulige tal, altså true:
List.filter (fun x -> x % 2 = 1) [1..100]
*** Filter gør listen mindre ***


let squares = List.map square odds
List.fold (+) 0 squres

List.fold (+) 0 [1..10]


// let listLength = (List.Length (0 list))

*)
