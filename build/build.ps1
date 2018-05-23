Write-Host "Start Build:"
$baseDir  = resolve-path ..
Write-Host "Basepath is: $basedir"
$projectPath = "$baseDir/UriExtension/UriBuilderExtension.csproj"
dotnet build $projectPath -c "Release"
