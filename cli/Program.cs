using System;
using System.Threading.Tasks;
using Microsoft.Azure.Services.AppAuthentication;

namespace cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var provider = new AzureServiceTokenProvider("RunAs=Developer;DeveloperTool=AzureCLI");
            try
            {
                var token = await provider.GetAccessTokenAsync("https://management.azure.com/");
                Console.WriteLine($"token is : {token}");
            }
            catch (AzureServiceTokenProviderException ex)
            {
                Console.WriteLine($"Got exception. Have you logged in? : {ex.Message}");
            }
        }
    }
}
