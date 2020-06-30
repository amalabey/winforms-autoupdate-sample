using System;
using System.Threading.Tasks;
using Contoso.DesktopApp.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Contoso.DesktopApp.Tests
{
	[TestClass]
	public class NugetPackageSignatureVerifierTests
	{
		[TestMethod]
		public async Task GetResultAsync_WhenSignedReleasePackage_ReturnsSuccess()
		{
			var verifier = new NugetPackageSignatureVerifier();
			var result =
				await verifier.GetResultAsync(
					@"C:\work\winforms-autoupdate-sample\Releases\ContosoDesktopAppDemo-2.1.11-full.nupkg");

			Assert.IsTrue(result.Success);
		}
	}
}
