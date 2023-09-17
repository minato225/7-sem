module Task1.Polynomial(evalP) where

evalP :: Num t => [t] -> t -> t
evalP cs x = evalPHelper (reverse cs) x 1 0

evalPHelper :: Num t => [t] -> t -> t -> t -> t
evalPHelper [] _ _ res = res
evalPHelper (c:cs) x p res = evalPHelper cs x (p * x) (res + c * p)