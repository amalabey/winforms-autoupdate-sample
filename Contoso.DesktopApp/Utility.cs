using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.DesktopApp
{
	static class Utility
	{
		public static Task<Tuple<int, string>> InvokeProcessAsync(string fileName, string arguments, CancellationToken ct, string workingDirectory = "")
		{
			var psi = new ProcessStartInfo(fileName, arguments);
			if (Environment.OSVersion.Platform != PlatformID.Win32NT && fileName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
			{
				psi = new ProcessStartInfo("wine", fileName + " " + arguments);
			}

			psi.UseShellExecute = false;
			psi.WindowStyle = ProcessWindowStyle.Hidden;
			psi.ErrorDialog = false;
			psi.CreateNoWindow = true;
			psi.RedirectStandardOutput = true;
			psi.RedirectStandardError = true;
			psi.WorkingDirectory = workingDirectory;

			return InvokeProcessAsync(psi, ct);
		}

		public static async Task<Tuple<int, string>> InvokeProcessAsync(ProcessStartInfo psi, CancellationToken ct)
		{
			var pi = Process.Start(psi);
			await Task.Run(() => {
				while (!ct.IsCancellationRequested)
				{
					if (pi.WaitForExit(2000)) return;
				}

				if (ct.IsCancellationRequested)
				{
					pi.Kill();
					ct.ThrowIfCancellationRequested();
				}
			});

			string textResult = await pi.StandardOutput.ReadToEndAsync();
			if (String.IsNullOrWhiteSpace(textResult) || pi.ExitCode != 0)
			{
				textResult = (textResult ?? "") + "\n" + await pi.StandardError.ReadToEndAsync();

				if (String.IsNullOrWhiteSpace(textResult))
				{
					textResult = String.Empty;
				}
			}

			return Tuple.Create(pi.ExitCode, textResult.Trim());
		}
	}
}
