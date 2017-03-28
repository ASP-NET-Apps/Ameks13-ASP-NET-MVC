rem ============================
rem Configure the UnitTests result file
rem Configure the UnitTests dll files
rem ============================

@echo off 
set "resultFile=\".\Source\All.UnitTest-Results.trx\""
set "testContainer_1=\".\Source\MyWoodenHouse.Data.Provider.UnitTests\bin\Release\MyWoodenHouse.Data.Provider.UnitTests.dll\""
set "testContainer_2=\".\Source\MyWoodenHouse.Data.Services.UnitTest\bin\Release\MyWoodenHouse.Data.Services.UnitTest.dll\""

rem /testcontainer:%testContainer_2%
rem /testcontainer:%testContainer_1%
rem /resultsfile:%resultFile%

".\Source\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\MSTest.exe" ^
-targetargs:" /testcontainer:%testContainer_1% /testcontainer:%testContainer_2% /resultsfile:%resultFile%" ^
-filter:"+[*]* -[MyWoodenHouse.*Tests*]*" ^
-mergebyhash ^
-skipautoprops ^
-output:".\Source\GeneratedReports\MyWoodenHouse.OpenCover-Report.xml"