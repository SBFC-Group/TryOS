:: copys the dll's over to the TryOS_Build folder
copy ".\TouchTest\bin\Debug\*.dll" ".\TouchTest\bin\Debug\TryOS_Build\"

:: Creates Settings Folder.
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Settings"
copy ".\TouchTest\bin\Debug\Settings\ShellName USW.setting" ".\TouchTest\bin\Debug\TryOS_Build\Settings\ShellName.setting"
copy ".\TouchTest\bin\Debug\Settings\LogonWallpaper.setting" ".\TouchTest\bin\Debug\TryOS_Build\Settings\"
echo True > ".\TouchTest\bin\Debug\Settings\TryOS_Build\UseAppViewer.setting"

:: Creates new ShellApps Folder to load newer ui elements and for newer Settings to load the new gui (20-03-2026 now haves the new ShellApp dll)
mkdir ".\TouchTest\bin\Debug\TryOS_Build\ShellApps"
copy ".\TouchTest\bin\Debug\ShellApps\ShellGUI.dll" ".\TouchTest\bin\Debug\TryOS_Build\ShellApps\"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\ShellApps\ShellGUI"
:: The Text files enables parts of ShellGUI
echo txt_file_does_not_contain_anything_that_you_need > ".\TouchTest\bin\Debug\TryOS_Build\ShellApps\ShellGUI\SettingsApp.SettingsForm.txt"
echo txt_file_does_not_contain_anything_that_you_need > ".\TouchTest\bin\Debug\TryOS_Build\ShellApps\ShellGUI\ShellGUI.PCC.txt"
echo txt_file_does_not_contain_anything_that_you_need > ".\TouchTest\bin\Debug\TryOS_Build\ShellApps\ShellGUI\ShellGUI.TaskInteracter.txt"
echo txt_file_does_not_contain_anything_that_you_need > ".\TouchTest\bin\Debug\TryOS_Build\ShellApps\ShellGUI\ShellGUI.PCC=TaskInteracter.txt"
echo txt_file_does_not_contain_anything_that_you_need > ".\TouchTest\bin\Debug\TryOS_Build\ShellApps\ShellGUI\ShellGUI=TouchTest.Form1.txt"

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

:: Creates The Program User (Used on Logon Page)
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser"

:: User Apps (Not Used with normal or program) Users 
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Apps"
echo Nothing > ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Apps\temp.txt"

:: Copys Settings
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Settings"
copy ".\TouchTest\bin\Debug\Users\SuperSecretUser\Settings\Password.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Settings\"
copy ".\TouchTest\bin\Debug\Users\SuperSecretUser\Settings\Role.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Settings\"
copy ".\TouchTest\bin\Debug\Users\SuperSecretUser\Settings\Software.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Settings\"
copy ".\TouchTest\bin\Debug\Users\SuperSecretUser\Settings\UserMode.swfiles" ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Settings\"

:: yeah it creates a temp for later use.
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Temp"
echo Nothing > ".\TouchTest\bin\Debug\TryOS_Build\Users\SuperSecretUser\Temp\temp.txt"

:: Creates Folder for wallpapers
 xcopy ".\TouchTest\bin\Debug\Wallpapers" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers" /E /I /H

::mkdir ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers"
:: copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_1.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
:: copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_2.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
:: copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_3.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"
:: copy ".\TouchTest\bin\Debug\Wallpapers\Wallpaper_4.jpg" ".\TouchTest\bin\Debug\TryOS_Build\Wallpapers\"

:: Creates the folders that Webview2 needs.
mkdir ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x64\native"
copy ".\TouchTest\bin\Debug\runtimes\win-x64\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x64\native\"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x86\native"
copy ".\TouchTest\bin\Debug\runtimes\win-x86\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\runtimes\win-x86\native\"

:: Copys Main Program .exe
copy ".\TouchTest\bin\Debug\TouchTest.exe" ".\TouchTest\bin\Debug\TryOS_Build\TryOS.exe"
:: Add More when needed.

:: Remove Unneeded Files
del ".\TouchTest\bin\Debug\TryOS_Build\SWFiles.dll"
del ".\TouchTest\bin\Debug\TryOS_Build\Test.dll"

:: Creates TryOS Store App
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Apps"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store"
copy ".\TryOS_Store\bin\Debug\TryOS_Store.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\TryOS_Store.dll"
copy ".\TryOS_Store\bin\Debug\Microsoft.Web.WebView2.Core.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\"
copy ".\TryOS_Store\bin\Debug\Microsoft.Web.WebView2.WinForms.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\"
copy ".\TryOS_Store\bin\Debug\Microsoft.Web.WebView2.Wpf.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\"
copy ".\TryOS_Store\bin\Debug\TryOS_Store_Manager.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\"

mkdir ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\runtimes\win-x64\native"
copy ".\TryOS_Store\bin\Debug\runtimes\win-x64\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\runtimes\win-x64\native\"
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\runtimes\win-x86\native"
copy ".\TryOS_Store\bin\Debug\runtimes\win-x86\native\WebView2Loader.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\TryOS_Store\runtimes\win-x86\native\

:: Creates Settings App
mkdir ".\TouchTest\bin\Debug\TryOS_Build\Apps\Settings"
copy ".\SettingsApp\bin\Debug\SettingsApp.dll" ".\TouchTest\bin\Debug\TryOS_Build\Apps\Settings\Main.dll"

pause