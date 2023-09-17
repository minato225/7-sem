module Task1.Power (power, fasterPower) where

import Task1.MyMod (myMod)

power :: Int -> Int -> Int
power _ k | k < 0 = error "power: negative argument"
power _ 0 = 1
power n k = n * power n (k - 1)

fasterPower :: Int -> Int -> Int
fasterPower _ k | k < 0 = error "power: negative argument"
fasterPower _ 0 = 1
fasterPower n k
  | isEven k = fasterPower (n * n) (k `div` 2)
  | otherwise = n * fasterPower n (k - 1)

isEven :: Int -> Bool
isEven x = x `myMod` 2 == 0

isOdd :: Int -> Bool
isOdd x = (!) $ isEven x

(!) :: Bool -> Bool
(!) True = False
(!) _ = True