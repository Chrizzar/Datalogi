(*
    Assignment 7i
    POP 2017
    Jan Rolandsen
*)

// time measure example
// to keep %i as a placeholder
let formatStr = "Leven \"dangerous house\" \"danger horse\": %i\n"

let a = "dangerous house"
let b = "danger horse"

let i = a.Length
let j = b.Length

// convert formatStr into TextWriterFormat (%i is int)
let twf = Printf.TextWriterFormat<int->unit> (formatStr)

printfn twf (duration ( fun() -> leven a b i j )) ;;

output from calling line 20:
    my first version, leven1, is fully functional and took 342000 milliseconds
    my second version, level2, (after tweaking one part of the code) took 92000 milliseconds
    my third version, levelI3, (level2 using cache) took 2 milliseconds (running 1000 times)
    an iterate version, levelIte, took 14 milliseconds (running 1000 times)

Compilation started at Fri Oct 27 14:49:31

mono "d:/POP-2017/ASG-7/leven1.exe"
Stopwatch starting:
Time used in (milliseconds): 341865
Leven1 "dangerous house" "danger horse": 4

Compilation finished at Fri Oct 27 14:55:13

// end