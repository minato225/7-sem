module Power(
    power,
    fasterPower,
    isEven,
    isOdd
)where

power::Int->Int->Int
power n k | k < 0 = error "power: negative argument"
power n 0 = 1
power n k = n*power n (k-1)

fasterPower :: Int->Int->Int
fasterPower n k | k < 0 = error "power: negative argument"
fasterPower n 0 = 1
fasterPower n k
    | isEven k = fasterPower (n*n) (k `div` 2)
    | otherwise = n * fasterPower n (k-1)

isEven::Int->Bool
isEven x = x `mod'` 2 == 0

isOdd::Int->Bool
isOdd x = (!) $ isEven x

(!) :: Bool-> Bool
(!) True = False
(!) _ = True 

mod' :: Int -> Int -> Int
mod' x y | y > x   = x
         | otherwise = mod' (x-y) y