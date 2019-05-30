using System;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;

namespace servicePrincipal
{
    class Program
    {
        /// <param name="appId">Application Id of the service principal</param>
        /// <param name="tenantId">Tenant id where the service principal is defined</param>
        /// <param name="clientSecret">Client secret for the service principal</param>
        static async Task Main(string appId, string tenantId, string clientSecret)
        {
            if (string.IsNullOrEmpty(appId) ||
                string.IsNullOrEmpty(tenantId) ||
                string.IsNullOrEmpty(clientSecret))
                {
                    Console.WriteLine("appId, tenantId and clientSecret must be specified");
                    return;
                }
            var provider = new AzureServiceTokenProvider($"RunAs=App;AppId={appId};TenantId={tenantId};AppKey={clientSecret}");
            try
            {
                var token = await provider.GetAccessTokenAsync("https://management.azure.com/");
                Console.WriteLine($"token is : {token}");
            }
            catch (AzureServiceTokenProviderException ex)
            {
                Console.WriteLine($"Got exception. : {ex.Message}");
            }
        }
    }
}
