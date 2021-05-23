cd ..

# Vars
$path = "tests\CodeDesignPlus.Event.Bus.Test"
$project = "$path\CodeDesignPlus.Event.Bus.Test.csproj"
$report = "$path\coverage.opencover.xml"

# Run Sonnar Scanner  
dotnet test $project `
    /p:CollectCoverage=true `
    /p:CoverletOutputFormat=opencover `

dotnet sonarscanner begin `
    /k:"CodeDesignPlus.Event.Bus" `
    /d:sonar.cs.opencover.reportsPaths="$report" `
    /d:sonar.coverage.exclusions="**Test.cs" `
    /d:sonar.exclusions="**/ExceptionBaseTest.cs"

dotnet build

dotnet sonarscanner end