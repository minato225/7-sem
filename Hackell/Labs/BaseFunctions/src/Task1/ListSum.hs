module Task1.ListSum (lsum, lmin) where
import Data.Function ( fix )

lsumHelper :: Num a => ([a] -> a -> a) -> [a] -> a -> a
lsumHelper _ [] s = s
lsumHelper f (x : xs) s = f xs (s + x)


lsum :: Num a => [a] -> a
lsum x = fix lsumHelper x 0


lmin :: Ord a => [a] -> Maybe a
lmin [] = Nothing
lmin (x : xs) = Just $ fix lminHelper xs x

lminHelper :: Ord a => ([a] -> a -> a) -> [a] -> a -> a
lminHelper _ [] m = m
lminHelper f (x : xs) m = f xs $ min m x