module Task1.MyClone(xClone) where

xClone :: Int -> [a] -> [a]
xClone 0 _ = []
xClone _ [] = []
xClone n (x:xs) = replicate n x ++ xClone n xs