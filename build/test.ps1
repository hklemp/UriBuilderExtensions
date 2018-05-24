Write-Host "Start Packing:"
$baseDir = Split-Path -parent $PSScriptRoot
Write-Host "Basepath is: $basedir"
$projectPath = "$baseDir/UriExtension.Test/UriBuilderExtension.Test.csproj"
dotnet test $projectPath -c "Release"  
