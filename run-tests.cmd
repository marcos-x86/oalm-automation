SETLOCAL
SET TestEnvironment=%1
if [%2]==[] (dotnet test --logger:"console;verbosity=detailed") else (dotnet test --logger:"console;verbosity=detailed" --filter TestCategory=%2)
