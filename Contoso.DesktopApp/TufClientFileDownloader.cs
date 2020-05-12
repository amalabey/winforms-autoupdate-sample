using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Squirrel;

namespace Contoso.DesktopApp
{
	public class TufClientFileDownloader : IFileDownloader
	{
		private const string TufClientExeName = "client.exe";
		private const string TufTargetsDirectoryName = "tuftargets";

		public async Task DownloadFile(string url, string targetFile, Action<int> progress)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new  ArgumentNullException(nameof(url));
			}

			if (string.IsNullOrEmpty(targetFile))
			{
				throw new ArgumentNullException(nameof(targetFile));
			}

			var urlParts = SplitUrl(url);
			var downloadFilePath = $".\\{TufTargetsDirectoryName}\\{urlParts.Item2}";
			if (File.Exists(downloadFilePath))
			{
				File.Delete(downloadFilePath);
			}

			var result = await DownloadFile(urlParts.Item1, urlParts.Item2);
			if (File.Exists(downloadFilePath))
			{
				File.Copy(downloadFilePath, targetFile);
			}
			else
			{
				throw new Exception($"Unable to download the file. Output: {result.Item2}");
			}
		}

		public async Task<byte[]> DownloadUrl(string url)
		{
			if (string.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException(nameof(url));
			}

			var urlParts = SplitUrl(url);
			var downloadFilePath = $".\\{TufTargetsDirectoryName}\\{urlParts.Item2}";
			if (File.Exists(downloadFilePath))
			{
				File.Delete(downloadFilePath);
			}

			var result = await DownloadFile(urlParts.Item1, urlParts.Item2);
			if (File.Exists(downloadFilePath))
			{
				var bytes = File.ReadAllBytes(downloadFilePath);
				return await Task.FromResult(bytes);
			}
			else
			{
				throw new Exception($"Unable to download the file. Output: {result.Item2}");
			}
		}

		private static Tuple<string, string> SplitUrl(string url)
		{
			var lastSlashIndex = url.LastIndexOf('/');
			if (lastSlashIndex < 0)
			{
				throw new Exception("url is not formatted correctly");
			}
			var repoUrl = url.Substring(0, lastSlashIndex);
			var fileName = url.Substring(lastSlashIndex + 1, url.Length - lastSlashIndex - 1);
			return new Tuple<string, string>(repoUrl, fileName);
		}

		private async Task<Tuple<int, string>> DownloadFile(string repoUrl, string fileName)
		{
			using (var cts = new CancellationTokenSource())
			{
				cts.CancelAfter(10 * 1000);
				return await Utility.InvokeProcessAsync(TufClientExeName, $"--repo {repoUrl} {fileName}", cts.Token);
			}
		}
	}
}
