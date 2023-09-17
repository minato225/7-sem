module Main (main) where

import MyClasses.MyEqClass(MyEq, ($==$), ($/=$))

main :: IO ()
main = do
    print $ 5 ($==$) 5