:Loop
Tasklist /fi "PID eq 26176" | find ":"
if Errorlevel 1
(
  Timeout /T 1 /Nobreak
  Goto Loop
)
Del "5_4_fr.exe"
