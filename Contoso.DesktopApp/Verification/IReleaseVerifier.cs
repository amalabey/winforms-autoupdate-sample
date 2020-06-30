using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contoso.DesktopApp.Verification
{
	public class ReleaseVerificationResult
	{
		public bool Success { get; set; }
		public IEnumerable<string> Issues { get; set; }
	}

	public interface IReleaseVerifier
	{
		Task<ReleaseVerificationResult> GetResultAsync(string packagePath);
	}
}
