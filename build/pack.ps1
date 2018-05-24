Write-Host "Start Packing:"
$baseDir = Split-Path -parent $PSScriptRoot
Write-Host "Basepath is: $basedir"
$projectPath = "$baseDir/UriExtension/UriBuilderExtension.csproj"
dotnet pack $projectPath -c "Release" --no-build 
