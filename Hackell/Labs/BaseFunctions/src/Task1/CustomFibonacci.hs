module Task1.CustomFibonacci(customFibonacci) where

customFibonacci :: Num a => [a] -> [a]
customFibonacci [] = []
customFibonacci (a : as) = a : customFibonacci(as ++ [sum (a : as)])