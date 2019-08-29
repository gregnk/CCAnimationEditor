@echo off
set /p ver="Enter version: v"
cd ..\CCAnimationEditor\bin\Release
::del CCAnimationEditor\bin\Release\Settings.xml
"C:\Program Files\7-Zip\7z.exe" a D:\Projects\GameToolProjects\CCAnimationEditor\Distrib\CCAnimationEditor-v%ver%.zip
pause