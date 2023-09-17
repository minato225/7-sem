module MyClasses.MyEqClass(MyEq, ($==$), ($/=$)) where

class MyEq a where
  ($==$), ($/=$) :: a -> a -> Bool
  x $==$ y = not (x $/=$ y)
  x $/=$ y = not (x $==$ y)

instance MyEq Int where
  x $==$ y = x == y

instance MyEq Integer where
  x $==$ y = x == y

instance MyEq a => MyEq [a] where
  [] $==$ [] = True
  [] $==$ (_:_) = False
  (_:_) $==$ [] = False
  (x:xs) $==$ (y:ys) = (x $==$ y) && (xs $==$ ys)
