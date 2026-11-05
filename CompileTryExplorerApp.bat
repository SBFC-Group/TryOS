:: Deletes ..\..\..\TouchTest\bin\Debug\Apps\TryExplorer\Main.dll

if exist ..\..\..\TouchTest\bin\Debug\Apps\TryExplorer\Main.dll del ..\..\..\TouchTest\bin\Debug\Apps\TryExplorer\Main.dll

copy .\TryExplorer.dll ..\..\..\TouchTest\bin\Debug\Apps\TryExplorer\Main.dll

exit /B 0