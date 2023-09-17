module Digits(
    toDigits,
    sumDigits
)where

toDigitsR 0 _ = [0]
toDigitsR x n =
    let (y,z) = divMod x n  
    in
    z: toDigitsR y n

toDigits x n = reverse $ toDigitsR x n

sumDigits (x:xy) n = x + n * sumDigits xy n