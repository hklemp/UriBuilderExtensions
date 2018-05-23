Write-Host "Start Packing:"
$baseDir  = resolve-path ..
Write-Host "Basepath is: $basedir"
$projectPath = "$baseDir/UriExtension/UriBuilderExtension.csproj"
dotnet pack $projectPath -c "Release" --no-build 
