cd ..

# Vars
$path = "tests\CodeDesignPlus.EFCore.Test"
$project = "$path\CodeDesignPlus.EFCore.Test.csproj"
$report = "$path\coverage.opencover.xml"

# Run Sonnar Scanner  
dotnet test $project `
    /p:CollectCoverage=true `
    /p:CoverletOutputFormat=opencover `
    /p:Exclude="[CodeDesignPlus.Entities]*%2c[CodeDesignPlus.InMemory]*%2c[CodeDesignPlus.Abstractions]*"

dotnet sonarscanner begin `
    /k:"CodeDesignPlus.EFCore" `
    /d:sonar.host.url=http://localhost:9000 `
    /d:sonar.cs.opencover.reportsPaths="$report" `
    /d:sonar.coverage.exclusions="**/CodeDesignPlus.Abstractions/**/*.cs,**/CodeDesignPlus.Entities/**/*.cs,**/CodeDesignPlus.InMemory/**/*.cs,**Test*.cs,**/CodeDesignPlus.EFCore.Sample.Api/**/*.cs,**/CodeDesignPlus.EFCore.Sample.Api.Entities/**/*.cs,**/CodeDesignPlus.EFCore.Sample.Api.Abstractions/**/*.cs,**/CodeDesignPlus.EfCore.Sample.Api.SqlServer/**/*.cs" `
    /d:sonar.exclusions="**/CodeDesignPlus.Abstractions/**/*.cs,**/CodeDesignPlus.Entities/**/*.cs,**/CodeDesignPlus.InMemory/**/*.cs,**/CodeDesignPlus.EFCore.Sample.Api/**/*.cs,**/CodeDesignPlus.EFCore.Sample.Api.Entities/**/*.cs,**/CodeDesignPlus.EFCore.Sample.Api.Abstractions/**/*.cs,**/CodeDesignPlus.EfCore.Sample.Api.SqlServer/**/*.cs"

dotnet build

dotnet sonarscanner end