module Task1.MyZip(xZip) where

xZip :: (t1 -> t2 -> a) -> [t1] -> [t2] -> [a]
xZip _ [] _ = []
xZip _ _ [] = []
xZip f (a:as) (b:bs) = f a b : xZip f as bs