REM ..\src\.nuget\nuget.exe update ..\src\RConDevServer.sln
rmdir /S /Q ..\_Artifacts
SET NET_DIRECTORY=%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\
%NET_DIRECTORY%\msbuild ..\src\RConDevServer.sln /t:clean,rebuild
mkdir ..\_Artifacts\reports\
tools\OpenCover.4.0.804\OpenCover.Console.exe -target:"tools\nunit-console\bin\nunit-console-x86.exe" -targetdir:..\_Artifacts\Tests\ -targetargs:"RConDevServer.Core.Tests.dll RConDevServer.Protocol.Dice.Battlefield3.Tests.dll" -register:user "tools\OpenCover.4.0.804\x86\OpenCover.Profiler.dll" -output:"..\_Artifacts\reports\coverage.xml" -filter:"+[RConDevServer*]*"
tools\ReportGenerator.1.6.0.0\ReportGenerator.exe "..\_Artifacts\reports\coverage.xml" "..\_Artifacts\reports"
pause