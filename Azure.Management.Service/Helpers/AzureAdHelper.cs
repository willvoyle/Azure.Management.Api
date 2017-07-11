using Azure.Management.Service.Interfaces;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;
using Microsoft.Rest;

namespace Azure.Management.Service.Helpers
{
    public class AzureAdHelper : IAzureAdHelper
    {
        private readonly IConfigHelper _configHelper;

        public AzureAdHelper(IConfigHelper configHelper)
        {
            _configHelper = configHelper;
        }

        public async Task<string> GetAdAccessTokenAsync(string authority, string resource, string scope)
        {
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var clientCredential = new ClientCredential(_configHelper.ClientId, _configHelper.ClientSecret);
            var tokenresponse = await context.AcquireTokenAsync(resource, clientCredential);
            return tokenresponse.AccessToken;
        }

        public async Task<TokenCredentials> GetAdTokenCredentialsAsync(string authority, string resource)
        {
            var token = await GetAdAccessTokenAsync(authority, resource, string.Empty);
            return new TokenCredentials(token);
        }
    }
}
