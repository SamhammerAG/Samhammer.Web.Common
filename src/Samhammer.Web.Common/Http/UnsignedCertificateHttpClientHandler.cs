using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Samhammer.Web.Common.Http
{
    public class UnsignedCertificateHttpClientHandler : HttpClientHandler
    {
        public UnsignedCertificateHttpClientHandler()
        {
            ServerCertificateCustomValidationCallback += ValidateCertificate;
        }

        private bool ValidateCertificate(HttpRequestMessage requestMessage, X509Certificate2 cert, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
    }
}
