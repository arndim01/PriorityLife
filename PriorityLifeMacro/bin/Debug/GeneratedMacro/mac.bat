@ECHO OFF
TASKKILL /F /IM Chrome.exe
START "Chrome" "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" "file:///C:\Users\Arndimz\Desktop\Workflow\Bituin\PriorityLife\PriorityLifeMacro\bin\Debug\GeneratedMacro\TPS.htm" --new-window
:LOOP
tasklist | find /i "CHROME" >nul 2>&1
IF ERRORLEVEL 1 (
GOTO CONTINUE
) ELSE  (
ECHO CHROME is still running
Timeout /T 300 /Nobreak
GOTO CONTINUE
)
:CONTINUE
