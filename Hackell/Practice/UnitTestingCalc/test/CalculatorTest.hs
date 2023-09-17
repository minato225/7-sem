
import Test.HUnit
import System.Exit
 
factorial :: (Integral a) => a -> a  
factorial 0 = 1 
factorial n = n * factorial (n - 1)
 
testZeroCase = TestCase(assertEqual "Factorial 1" 1 (factorial 1))
testNonZeroCase = TestCase(assertEqual "Factorial 10" (3628800) (factorial 10))

 
main :: IO ()
main = do
    counts <- runTestTT ( test [
        testZeroCase,
        testNonZeroCase
        ])
    if errors counts + failures counts == 0
        then exitSuccess
        else exitFailure