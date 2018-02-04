@echo off
color 0a

:run:
set "cmd="
echo.
set /p cmd="git "
echo.

goto check1

:check1:
if "%cmd%" == "exit" (
goto nope
)

goto check2

:check2:
if "%cmd%" == "" (
goto nope
)
goto git

:git:
C:\Users\GRAMINI\AppData\Local\GitHubDesktop\app-1.0.13\resources\app\git\cmd\git.exe %cmd%
echo.
echo =========================================================================================
echo =========================================================================================

goto run

:nope:
exit
