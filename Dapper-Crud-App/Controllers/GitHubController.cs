using Dapper_Crud_App.HttpClients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dapper_Crud_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubClient _gitHubClient;
        public GitHubController(IGitHubClient gitHubClient)
        {
            _gitHubClient = gitHubClient;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var githubResponse = await _gitHubClient.OnGetGitBranches();
            return Ok(githubResponse);
        }
    }
}