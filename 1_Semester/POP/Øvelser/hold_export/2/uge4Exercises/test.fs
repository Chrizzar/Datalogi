// This is the Implementation file.
// How to compile to a .dll
// $ fsharpc -a test.fsi test.fs

// BONUS: Generate the Signature file like so:
// $ fsharpc --nologo --sig:test.fsi test.fs


module color

  type aColor = int*int*int
  type aFunc = aColor -> aColor -> aColor    
  
  let trunc cVal : int = 
    if cVal < 0 then 0
    elif cVal > 255 then 255
    else cVal

  let add ((r1, g1, b1):aColor) ((r2, g2, b2):aColor) =
    (trunc(r1+r2), trunc(g1+g2), trunc(b1+b2)) 

  let scale ((r1, g1, b1):aColor) ((r2, g2, b2):aColor) =
    (trunc(r1*r2), trunc(g1*g2), trunc(b1*b2)) 

  let gray (r, g, b):aColor = 
    let greyVal = (r+g+b)/3
    (greyVal, greyVal, greyVal)
