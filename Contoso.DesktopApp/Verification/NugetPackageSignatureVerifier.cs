using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Build.Tasks;
using NuGet.Packaging;
using NuGet.Packaging.Signing;

namespace Contoso.DesktopApp.Verification
{
	public class NugetPackageSignatureVerifier : IReleaseVerifier
	{
		public async Task<ReleaseVerificationResult> GetResultAsync(string packagePath)
		{
			var verifierSettings = SignedPackageVerifierSettings.GetVerifyCommandDefaultPolicy();
			var verificationProviders = new List<ISignatureVerificationProvider>()
			{
				new IntegrityVerificationProvider(),
				new SignatureTrustAndValidityVerificationProvider(),
				new SignerCommonNameVerificationProvider("ContosoAutoUpdateDeveloper")
			};
			
			var verifier = new PackageSignatureVerifier(verificationProviders);

			using (var packageReader = new PackageArchiveReader(packagePath))
			{
				var verificationResult =
					await verifier.VerifySignaturesAsync(packageReader, verifierSettings, CancellationToken.None);

				var result = new ReleaseVerificationResult
				{
					Success = verificationResult.IsSigned && verificationResult.IsValid,
					Issues = verificationResult?.Results.SelectMany(r => r.Issues, (res, iss) => iss.Message).AsEnumerable()
				};

				return result;
			}
		}


	}
}
