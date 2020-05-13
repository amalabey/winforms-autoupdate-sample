using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contoso.DesktopApp
{
	public partial class Form1 : Form
	{
		private const string updateUrl = "http://127.0.0.1:8001/";

		public Form1()
		{
			InitializeComponent();

			//CheckForUpdate();
			EnsureLatestUpdate();

			AddVersionNumber();
		}

		private void AddVersionNumber()
		{
			System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			LblVersion.Text = $" Version: {versionInfo.FileVersion}";
		}

		private async Task CheckForUpdate()
		{
			try
			{
				using (var mgr = new UpdateManager(updateUrl))
				{
					LblStatus.Text = "Status: Checking for updates...";
					await mgr.UpdateApp();
					LblStatus.Text = "Status: Update check complete..";
				}
			}
			catch (Exception ex)
			{
				LblStatus.Text = $"Error: {ex.Message}";
			}
		}

		private async Task EnsureLatestUpdate()
		{
			try
			{
				var requireRestart = false;

				using (var mgr = new UpdateManager(updateUrl, null, null, new TufClientFileDownloader()))
				{
					var updateInfo = await mgr.CheckForUpdate();
					if (updateInfo.ReleasesToApply.Any())
					{
						requireRestart = true;

						var newVersion = updateInfo.FutureReleaseEntry.Version;
						LblStatus.Text = $"Downloading new release: {newVersion}";
						await mgr.DownloadReleases(updateInfo.ReleasesToApply);
						LblStatus.Text = "Applying new release";
						await mgr.ApplyReleases(updateInfo);
						LblStatus.Text = "Restarting to load new version";
					}
				}

				if (requireRestart)
				{
					UpdateManager.RestartApp();
				}
			}
			catch (Exception ex)
			{
				LblStatus.Text = $"Error: {ex.Message}";
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			//MessageBox.Show("Hello from Example Win Forms App!");

			var tufFileDownloaer = new TufClientFileDownloader();
			tufFileDownloaer.DownloadFile("http://localhost:8001/testfile.txt", "c:\\temp1\\testfile.txt",(p) => { Console.WriteLine($"Progress: {p}"); });
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var programManager = new WindowsProgramManager();
			var installedProgram = programManager.GetInstalledProgram("Fiddler");
			programManager.LaunchUninstaller(installedProgram);
		}
	}
}
