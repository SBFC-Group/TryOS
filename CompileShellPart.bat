:: Deletes ..\..\..\TouchTest\bin\Debug\ShellApps\ShellGUI.dll

if exist ..\..\..\TouchTest\bin\Debug\ShellApps\ShellGUI.dll del ..\..\..\TouchTest\bin\Debug\ShellApps\ShellGUI.dll

copy .\ShellGUI.dll ..\..\..\TouchTest\bin\Debug\ShellApps\ShellGUI.dll

exit /B 0