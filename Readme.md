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

## Secure Distribution using TUF
Refer to [Quick Start](https://github.com/theupdateframework/tuf/blob/develop/docs/QUICKSTART.md) on how to use 'The Update Framework' to securely deliver updates. You need Python 3.7 installed for this.

### Install and setup TUF

There is a pipenv setup (Pipfile) in `tuf` directory
```
cd tuf
pip3 install pipenv # if you haven't already got pipenv
pipenv --python 3.6
pipenv install
pipenv shell
```

Follow the [TUF Quickstart](https://github.com/theupdateframework/tuf/blob/develop/docs/QUICKSTART.md) on how to use the tuf repository and client.


## Convert client.py to a standalone exe

Follow [nuitka](http://nuitka.net/doc/user-manual.html#tutorial-setup-and-build-on-windows) instructions.

Download mingw C compiler and set the path to it as follows
```
$Env:CC="C:\mingw32\bin\gcc.exe"
```

Copy the client.py to current directory
```
cd nuitka-client
cp $(get-command client.py).Source .\
```

Execute below to convert client.py to client.exe
```
python -m nuitka --standalone --mingw64 client.py
```

Above should generate the client.exe in `client.dist\client.exe`.

