module Main (main) where
 
import Test.HUnit
import System.Exit
 
import Modules.Calculator as Calc
 
testZeroCase = TestCase(assertEqual "Factorial 1" 1 (Calc.factorial 1))
testNonZeroCase = TestCase(assertEqual "Factorial 10" 2 (Calc.factorial 10))
 
main :: IO ()
main = do
    counts <- runTestTT ( test [
        testZeroCase,
        testNonZeroCase
        ])
    if errors counts + failures counts == 0
        then exitSuccess
        else exitFailure