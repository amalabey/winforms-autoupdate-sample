# Auto Update WinForms App using Squirrel

## Integrate Squirrel
- Install `Squirrel.Windows` nuget package
- Integrate `UpdateManager` to bootstrap code

## Build Application
- Build application in "Release" mode

## Package using NuSpec

```
.\.nuget\nuget.exe pack .\Contoso.DesktopApp\ContosoDesktopAppDemo.nuspec -Version 2.0.0 -Properties Configuration=Release -OutputDirectory .\Contoso.DesktopApp\bin\Release -BasePath .\Contoso.DesktopApp\bin\Release
```

## Releasify

```
.\packages\squirrel.windows.1.9.1\tools\Squirrel.exe --releasify .\Contoso.DesktopApp\bin\Release\ContosoDesktopAppDemo.2.0.0.nupkg
```

## Install
- Install application by using "Setup.exe"

## Update

- Build new version
- Package new version
```
.\.nuget\nuget.exe pack .\Contoso.DesktopApp\ContosoDesktopAppDemo.nuspec -Version 2.0.1 -Properties Configuration=Release -OutputDirectory .\Contoso.DesktopApp\bin\Release -BasePath .\Contoso.DesktopApp\bin\Release
```
- Releasify new version
```
.\packages\squirrel.windows.1.9.1\tools\Squirrel.exe --releasify .\Contoso.DesktopApp\bin\Release\ContosoDesktopAppDemo.2.0.0.nupkg
```

- Distribute from HTTP location
```
npm install http-server -g

http-server .\Releases\ -p 8081
```
- Open the application using desktop shortcut


