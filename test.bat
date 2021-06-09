echo off
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\devenv" MacroManager.sln /Build Release /project "TestMacroManager\TestMacroManager.csproj" /projectconfig Release
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "%~dp0TestMacroManager\bin\Release\TestMacroManager.dll"

pause