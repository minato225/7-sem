module Task1.Collatz(collatz) where

collatz :: Int -> Int
collatz a = collatzHelper a 1

collatzHelper :: Int -> Int -> Int
collatzHelper 1 n = n
collatzHelper a n =
  if odd a
    then collatzHelper (3 * a + 1) (n + 1)
    else collatzHelper (a `div` 2) (n + 1)