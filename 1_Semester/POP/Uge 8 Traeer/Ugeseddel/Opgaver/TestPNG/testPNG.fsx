// Christian Sass Hansen
// Last edited 06/11-2017

// *** Pixel Test ***
let bmp = ImgUtil.mk 256 256
do ImgUtil.setPixel (ImgUtil.fromRgb (255,255,0)) (10,10) bmp
do ImgUtil.toPngFile "test.png" bmp
