module Task1.GCD(myGcd) where

myGcd :: Integer -> Integer -> Integer
myGcd a 0 = abs a
myGcd a b = myGcd b (a `mod` b)