(*
   POP 2017
   Assignment 6g
*)

   < ...your source code goes here...>

// Testing cfrac2float and float2cfrac
// Expected result: "[3; 4; 12; 4] -> 3.245 -> [3; 4; 11; 4]", but rounding error may occur
let c = [3; 4; 12; 4]
let xc = cfrac2float c
let cx = float2cfrac xc
printfn "%A -> %g -> %A" c xc cx

// Testing frac2cfrac and cfrac2frac
// Expected result: "649/200 -> [3; 4; 12; 4] -> 649/200"
let t = 649
let n = 200
let ctn = frac2cfrac t n
let (ct, cn) = cfrac2frac ctn 4
printfn "%d/%d -> %A -> %d/%d" t n ctn ct cn

// On my machine I get the following output
// running the above test code.
// It shows roundoff errors, and this is OKAY !!!

(*
    mono "c:/POP-2017/ASG-6/6g.exe"
    [3; 4; 12; 4] -> 3.2449 -> [3; 4; 11; 1; -2147483648]
    649/200 -> [3; 4; 12; 4] -> 649/200
*)

(*
   Floats are prone to roundoff error in computers.
   We have at least 3*2*2=12 combinations
   -> 3 OS (Linux, MacOS, Windows)
   -> 2 CPUs (32-bit, 64-bit)
   -> 2 chipmakers (AMD, Intel)

   This could have the effect that the result on a
   group members computer, is somewhat different from
   another group member.
*)

