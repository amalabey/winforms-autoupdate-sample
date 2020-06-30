using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Build.Tasks;
using NuGet.Common;
using NuGet.Packaging.Signing;

namespace Contoso.DesktopApp.Verification
{
	public class SignerCommonNameVerificationProvider : ISignatureVerificationProvider
	{
		private readonly string _signerCommonName;

		public SignerCommonNameVerificationProvider(string signerCommonName)
		{
			_signerCommonName = signerCommonName;
		}

		public Task<PackageVerificationResult> GetTrustResultAsync(ISignedPackageReader package, PrimarySignature signature,
			SignedPackageVerifierSettings settings, CancellationToken token)
		{
			token.ThrowIfCancellationRequested();
			var issues = Enumerable.Empty<SignatureLog>();

			if (signature == null)
			{
				throw new ArgumentNullException(nameof(signature));
			}
			
			var signedCerts = signature.SignedCms.Certificates;
			if (signedCerts.Count == 0)
			{
				issues = issues.Concat(new[] { SignatureLog.Error(NuGetLogCode.NU3038, "Package does not contain signer certificates") });
				return Task.FromResult<PackageVerificationResult>(new UnsignedPackageVerificationResult(SignatureVerificationStatus.Disallowed, issues));
			}

			var hasExpectedCn = signedCerts.OfType<X509Certificate2>().Any(HasExpectedCommonName);
			return Task.FromResult<PackageVerificationResult>(new SignedPackageVerificationResult(SignatureVerificationStatus.Valid, signature, issues));
		}

		private bool HasExpectedCommonName(X509Certificate2 certificate)
		{
			if (certificate.SubjectName.Name == null) return false;

			var subjectName = certificate.SubjectName.Name.Split(',');
			return  string.Equals(subjectName[0], $"CN={_signerCommonName}");
		}
	}
}
