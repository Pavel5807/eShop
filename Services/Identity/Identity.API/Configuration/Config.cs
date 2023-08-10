using IdentityServer4;
using IdentityServer4.Models;

namespace eShop.Services.Identity.API.Configuration
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}