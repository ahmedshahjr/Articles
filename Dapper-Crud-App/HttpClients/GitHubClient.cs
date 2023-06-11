using Microsoft.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Dapper_Crud_App.HttpClients
{
    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient _httpClient;
  
        public GitHubClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> OnGetGitBranches()
        {
            var json = await _httpClient.GetStringAsync("orgs/dotnet/repos");
            return json;
        }
    }
}
