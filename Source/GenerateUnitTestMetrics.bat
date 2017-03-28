"C:\Program Files (x86)\Jenkins\workspace\MyWoodenHouse-AutomaticUnitTesting\Source\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe"  ^
-register:user ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\MSTest.exe" ^
-targetargs:"/testcontainer:  \"C:\Program Files (x86)\Jenkins\workspace\MyWoodenHouse-AutomaticUnitTesting\Source\MyWoodenHouse.Data.Provider.UnitTests\bin\Release\MyWoodenHouse.Data.Provider.UnitTests.dll\"  /resultsfile:\"ALL.RESULT.trx\""^
-filter:"+[*]*  -[MyWoodenHouse.*.Tests*]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"\GeneratedReports\MyWoodenHouse-Report.xml"