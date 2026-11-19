:: Deletes ..\..\..\TouchTest\bin\Debug\Apps\TryOS_Store\Main.dll

if exist ..\..\..\TouchTest\bin\Debug\Apps\TryOS_Store\Main.dll del ..\..\..\TouchTest\bin\Debug\Apps\TryOS_Store\Main.dll

copy .\TryOS_Store.dll ..\..\..\TouchTest\bin\Debug\Apps\TryOS_Store\Main.dll

exit /B 0