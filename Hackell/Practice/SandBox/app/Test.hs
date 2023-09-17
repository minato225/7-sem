module Test(
    someFunc,
    inc,
    list
) where

import Data.List

someFunc::Int->Int
someFunc x
    | x == tmp      = x * 4
    | x == tmp * 3  = x * 3
    | otherwise     = x
    where tmp = 4

add :: Int -> Int -> Int
add x y = x + y

inc::Int->Int
inc = add 1

list:: [String]
list = ["Vim", "Emacs", "Atom"]