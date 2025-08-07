:: Creates "bin" folder
mkdir "..\TouchTest\bin"

:: Creates "Debug" folder
mkdir "..\TouchTest\bin\Debug"

:: Copys "Menu.swfiles" into settings folder
xcopy /e /Y ".\Base" "..\TouchTest\bin\Debug\"

xcopy /e /Y ".\Base" "..\TouchTest\bin\Debug\"

pause