@echo off
cd %CD%\..\..\..\Win8\Domain
"C:\Program Files (x86)\Microsoft Visual Studio 11.0\Common7\IDE\MSTest.exe" /testcontainer:"..\..\..\..\..\TestBinaries\Dev2.Studio.UITests.dll" /testSettings:"UI.testsettings"
pause