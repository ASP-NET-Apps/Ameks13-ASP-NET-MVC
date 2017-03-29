rem ============================
rem Configure the UnitTests result file
rem Configure the UnitTests dll files
rem ============================

REM Create a 'GeneratedReports' folder if it does not exist
if not exist ".\GeneratedReports" mkdir ".\GeneratedReports"

@echo off 
set "resultFile=\"All.UnitTest-Results.trx\""
set "testContainer_1=\".\MyWoodenHouse.Data.Provider.UnitTests\bin\Release\MyWoodenHouse.Data.Provider.UnitTests.dll\""
set "testContainer_2=\".\MyWoodenHouse.Data.Services.UnitTest\bin\Release\MyWoodenHouse.Data.Services.UnitTest.dll\""
set "testContainer_3=\".\MyWoodenHouse.Pure.Models.UnitTests\bin\Release\MyWoodenHouse.Pure.Models.UnitTests.dll\""

rem /testcontainer:%testContainer_2%
rem /testcontainer:%testContainer_1%
rem /resultsfile:%resultFile%

".\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\MSTest.exe" ^
-targetargs:" /testcontainer:%testContainer_1% /testcontainer:%testContainer_2% /testcontainer:%testContainer_3% /resultsfile:%resultFile%" ^
-filter:"+[*]* -[MyWoodenHouse.*Tests*]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"MyWoodenHouse.OpenCover-Report.xml"