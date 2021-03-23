using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System.IO;

namespace TestHelper
{
    public class ConfigurationHelper
    {
        public IConfiguration Configuration { get; }

        public ConfigurationHelper()
        {
            var keyVaultEndpoint = "https://kv-hungabor01website.vault.azure.net/";
            var azureServiceTokenProvider = new AzureServiceTokenProvider("RunAs = Developer; DeveloperTool = VisualStudio");
            var keyVaultClient = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(
                    azureServiceTokenProvider.KeyVaultTokenCallback));

            var appSettingsPath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("Hungabor01Website\\"))
                + "Hungabor01Website\\Website\\";

            Configuration = new ConfigurationBuilder()
              .SetBasePath(appSettingsPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables()
              .AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager())
              .Build();
        }
    }
}
