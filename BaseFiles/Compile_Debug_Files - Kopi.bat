:: Creates "bin" folder
mkdir "..\TouchTest\bin"

:: Creates "Debug" folder
mkdir "..\TouchTest\bin\Debug"

:: Copys "Menu.swfiles" into settings folder
xcopy /e /Y ".\Base" "..\TouchTest\bin\Debug\"

::xcopy /e /Y ".\Base" "..\TouchTest\bin\Debug\"

:: This creates the folder that's needed for Compiling TryOS. So DON'T DELETE THE FOLDER!!!
mkdir "..\TouchTest\bin\Debug\TryOS_Build"

pause