using System.Threading.Tasks;

namespace Dapper_Crud_App.HttpClients
{
    public interface IGitHubClient
    {
        Task<string>  OnGetGitBranches();
    }
}
