using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Contoso.DesktopApp
{
	public class WindowsProgramManager
	{
		public ProgramEntry GetInstalledProgram(string name)
		{
			var registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
			using (var key = Registry.LocalMachine.OpenSubKey(registryKey))
			{
				foreach (var subKeyName in key.GetSubKeyNames())
				{
					using (var subKey = key.OpenSubKey(subKeyName))
					{
						var displayName = subKey.GetValue("DisplayName");
						if (displayName == null || !displayName.ToString().Contains(name)) continue;
						var uninstallerPath = subKey.GetValue("UninstallString");

						return new ProgramEntry
						{
							Name = displayName.ToString(),
							UninstallerPath = uninstallerPath?.ToString()
						};
					}
				}
			}

			return null;
		}

		public void LaunchUninstaller(ProgramEntry installedProgram)
		{
			if (installedProgram == null)
			{
				throw new ArgumentNullException(nameof(installedProgram));
			}

			if (String.IsNullOrEmpty(installedProgram.UninstallerPath))
			{
				throw new Exception("Uninstaller path not available");
			}

			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = installedProgram.UninstallerPath;
			//startInfo.Arguments = @"C:\etc\desktop\file.spp C:\etc\desktop\file.txt";
			Process.Start(startInfo);
		}
	}


	public class ProgramEntry
	{
		public string Name { get; set; }
		public string UninstallerPath { get; set; }
	}
}
