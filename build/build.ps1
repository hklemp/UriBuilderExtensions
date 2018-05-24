Write-Host "Start Build:"
$baseDir = Split-Path -parent $PSScriptRoot
Write-Host "Basepath is: $basedir"
$projectPath = "$baseDir/UriExtension/UriBuilderExtension.csproj"
dotnet build $projectPath -c "Release"
