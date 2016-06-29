@echo off

pushd %~dp0

SET PACKAGEPATH=.\packages\
SET NUGET=.\tools\nuget\NuGet.exe
SET NUGETOPTIONS=-ConfigFile .\tools\nuget\NuGet.Config -OutputDirectory %PACKAGEPATH% -ExcludeVersion

IF NOT EXIST %PACKAGEPATH%FAKE\Ver_4.28.0 (
  RD /S/Q %PACKAGEPATH%FAKE
  %NUGET% install FAKE -Version 4.28.0 %NUGETOPTIONS%
  COPY NUL %PACKAGEPATH%FAKE\Ver_4.28.0
)

IF NOT EXIST %PACKAGEPATH%FAKE.BuildLib\Ver_0.3.6 (
  RD /S/Q %PACKAGEPATH%FAKE.BuildLib
  %NUGET% install FAKE.BuildLib -Version 0.3.6 %NUGETOPTIONS%
  COPY NUL %PACKAGEPATH%FAKE.BuildLib\Ver_0.3.6
)

set encoding=utf-8
"%PACKAGEPATH%FAKE\tools\FAKE.exe" build.fsx %*

popd
