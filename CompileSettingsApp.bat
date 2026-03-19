:: Deletes ..\..\..\TouchTest\bin\Debug\Apps\Settings\Main.dll

if exist ..\..\..\TouchTest\bin\Debug\Apps\Settings\Main.dll del ..\..\..\TouchTest\bin\Debug\Apps\Settings\Main.dll

copy .\SettingsApp.dll ..\..\..\TouchTest\bin\Debug\Apps\Settings\Main.dll

exit /B 0