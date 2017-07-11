using Microsoft.Rest;
using System.Threading.Tasks;

namespace Azure.Management.Service.Interfaces
{
    public interface IAzureAdHelper
    {
        Task<string> GetAdAccessTokenAsync(string authority, string resource, string scope);
        Task<TokenCredentials> GetAdTokenCredentialsAsync(string authority, string resource);
    }
}