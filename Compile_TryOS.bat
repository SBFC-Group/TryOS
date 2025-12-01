:: copys the dll's over to the TryOS_Build folder
copy ".\TouchTest\bin\Debug\*.dll" ".\TouchTest\bin\Debug\TryOS_Build\"

:: Creates Settings Folder.
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Settings"
copy ".\TouchTest\bin\Debug\Settings\ShellName USW.setting" ".\TouchTest\bin\Debug\TryOS_Build\Settings\ShellName.setting"
copy ".\TouchTest\bin\Debug\Settings\LogonWallpaper.setting" ".\TouchTest\bin\Debug\TryOS_Build\Settings\"

:: Copys new Logon page
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Settings\Page"
copy ".\TouchTest\bin\Debug\Settings\Page\index.html" ".\TouchTest\bin\Debug\TryOS_Build\Settings\Page"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Settings\Page\imgs"
copy ".\TouchTest\bin\Debug\Settings\Page\imgs\Wallpaper.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Settings\Page\imgs\"

:: Creates Admin User Folder.
::mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users"
::mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin"
::mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Apps"
::mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Settings"
::mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Notes"
::mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Temp"
::copy ".\TouchTest\bin\Debug\Users\Admin\Apps\Internet++.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Apps\"
::copy ".\TouchTest\bin\Debug\Users\Admin\Apps\QuickNotes.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Apps\"
::copy ".\TouchTest\bin\Debug\Users\Admin\Settings\Password.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Settings\"
::copy ".\TouchTest\bin\Debug\Users\Admin\Settings\Wallpaper.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Settings\"
::copy ".\TouchTest\bin\Debug\Users\Admin\Notes\quicknote_1.swnote" ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Notes\"
::copy ".\TouchTest\bin\Debug\Users\Admin\Temp\temp.txt" ".\TouchTest\bin\Debug\TryOS_Build\Users\Admin\Temp\"

:: Creates Folder for wallpapers
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_1.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_2.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_3.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_4.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"

:: Creates the folders that Webview2 needs.
mkdir ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x64\native"
copy ".\TouchTest\bin\Debug\runtimes\win-x64\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x64\native\"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x86\native"
copy ".\TouchTest\bin\Debug\runtimes\win-x86\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x86\native\"

:: Copys Main Program .exe
copy ".\TouchTest\bin\Debug\TouchTest.exe" ".\TouchTest\bin\Debug\TryOS_Build\TryOS.exe"
:: Add More when needed.

copy ".\TryOSUpdateWindow\bin\Debug\TryOSUpdateWindow.exe" ".\TouchTest\bin\Debug\TryOS_Build\"

:: Creates TryOS Store App
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Apps"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store"
copy ".\TryOS_Store_Loader\bin\Debug\TryOS_Store_Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\Main.dll"

pause