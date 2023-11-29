dotnet sonarscanner begin /k:"SoftwareSikkerhed-eksamen-WebGoat" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_c362b35ea7e8a66f3c48ad337fcd2ef2cee9c85a"

dotnet build SoftwareSikkerhedsEksamen.sln

dotnet sonarscanner end /d:sonar.token="sqp_c362b35ea7e8a66f3c48ad337fcd2ef2cee9c85a"