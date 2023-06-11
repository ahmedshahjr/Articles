using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace Dapper_Crud_App.Delegates
{
    public class ValidateHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Headers.Contains("test123"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(
                        "The API key header test123 is not good.")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
