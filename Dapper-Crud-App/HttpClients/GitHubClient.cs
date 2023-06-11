using Microsoft.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dapper_Crud_App.HttpClients
{
    public class GitHubClient : IGitHubClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;   
        public GitHubClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<string> OnGetGitBranches()
        {
            var json = await _httpClient.GetStringAsync("orgs/dotnet/repos");
            return json;
        }
    }
}
