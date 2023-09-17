import qualified Test.HUnit.Base

import Test.HUnit ((~=?),(~:),runTestTT, test, errors, failures)
import System.Exit ( exitFailure, exitSuccess )
import Task1.Factorial ( factorial )
import Task1.GCD ( myGcd )
import Task1.Power ( power, fasterPower )
import Task1.Fibonacci( getFib )
import Task1.Collatz (collatz)

tests :: Test.HUnit.Base.Test
tests = test [  
    -- Factorial
    "Factorial 1"   ~: 1        ~=? factorial 1,
    "Factorial 10"  ~: 3628800  ~=? factorial 10,

    -- GCD
    "GCD 2, 4" ~: 2 ~=? myGcd 2 4,
    "GCD 1, 5" ~: 1 ~=? myGcd 1 5,
    "GCD 3, 6" ~: 3 ~=? myGcd 3 6,
    
    -- Power
    "2^2"       ~: 4    ~=? power 2 2,
    "1^1000"    ~: 1    ~=? power 1 1000,
    "0^1000"    ~: 0    ~=? power 0 1000,
    "2^10"      ~: 1024 ~=? power 2 10,
    
    -- FastPower
    "2^2" ~: 4 ~=? fasterPower 2 2,
    "1^1000" ~: 1 ~=? fasterPower 1 1000,
    "0^1000" ~: 0 ~=? fasterPower 0 1000,
    "2^10" ~: 1024 ~=? fasterPower 2 10,

    -- Collatz
    "7...1" ~: 17 ~=? collatz 7,

    -- Fibonacci
    "1,2,3,5,8" ~: 8 ~=? getFib 5]

main :: IO ()
main = do
        c <- runTestTT tests
        if errors c + failures c == 0
            then exitSuccess
            else exitFailure
