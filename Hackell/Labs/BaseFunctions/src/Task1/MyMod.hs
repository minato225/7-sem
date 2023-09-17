module Task1.MyMod(myMod) where

myMod :: Int -> Int -> Int
myMod x y 
    | y > x     = x
    | otherwise = myMod (x-y) y