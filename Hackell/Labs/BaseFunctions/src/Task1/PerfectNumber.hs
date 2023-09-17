module Task1.PerfectNumber(isPerfect) where

getDelims :: Int -> [Int]
getDelims n = [ d | d <- [1..n-1], n `mod` d == 0]

isPerfect :: Int -> Bool
isPerfect n = sum (getDelims n) == n