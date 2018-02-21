(*
   Ugeopgave 6g
   POP 2017
   Continued fractions
*)

// Testing for difference
let diff (f1 : float) (f2 : float) : unit =
    printfn "%A" (abs (f1 - f2))
;;

// 6g0

    < ... your source code for cfrac2float goes here ...>

// Testing for difference (Blackbox)
diff (cfrac2float [0; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1])  0.61803 ;;
diff (cfrac2float [3; 4; 12; 4])  3.245 ;;
diff (cfrac2float [3; 0])  3.0 ;;

// Testing for difference (Whitebox)
diff (cfrac2float [])  0.0 ;;
diff (cfrac2float [1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1; 1])  1.61803 ;;

(* Output:

   mono "c:/POP-2017/ASG-6/Testing-for-difference-6g.exe"
   7.135278515e-06
   0.0001020408163
   0.0
   0.0
   7.135278514e-06
*)

// end
