Write-Host "Start Packing:"
$baseDir  = resolve-path ..
Write-Host "Basepath is: $basedir"
$projectPath = "$baseDir/UriExtension.Test/UriBuilderExtension.Test.csproj"
dotnet test $projectPath -c "Release"  
