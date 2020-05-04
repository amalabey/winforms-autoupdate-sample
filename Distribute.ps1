[CmdletBinding()]
param (
    [Parameter(Mandatory=$true)]
    [string]
    $Version
)

Write-Host "Generating nuget package"
.\.nuget\nuget.exe pack .\Contoso.DesktopApp\ContosoDesktopAppDemo.nuspec -Version $Version `
-Properties Configuration=Release `
-OutputDirectory .\Contoso.DesktopApp\bin\Release `
-BasePath .\Contoso.DesktopApp\bin\Release

Write-Host "Creating release using squirrel.exe --releasify"
.\packages\squirrel.windows.1.9.1\tools\Squirrel.exe `
--releasify .\Contoso.DesktopApp\bin\Release\ContosoDesktopAppDemo.$($Version).nupkg `
-n "/a /f ContosoAutoUpdateDeveloperCodeSigning.pfx /p Test123$ /fd sha256 /tr http://timestamp.digicert.com /td sha256"