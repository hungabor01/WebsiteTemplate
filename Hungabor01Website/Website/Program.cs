using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.AzureAppServices;
using Shared.Resources;

namespace Website
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection.Configure<AzureBlobLoggerOptions>(options =>
                    {
                        options.BlobName = Strings.LogFileName;
                    });
                })
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    var keyVaultEndpoint = Strings.KeyVaultEndpoint;
                    if (!string.IsNullOrEmpty(keyVaultEndpoint))
                    {
                        AzureServiceTokenProvider azureServiceTokenProvider = null;
                        if (ctx.HostingEnvironment.IsDevelopment())
                        {
                            var connectionStringForLocal = "RunAs = Developer; DeveloperTool = VisualStudio";
                            azureServiceTokenProvider = new AzureServiceTokenProvider(connectionStringForLocal);
                        }
                        else
                        {
                            azureServiceTokenProvider = new AzureServiceTokenProvider();
                        }

                        var keyVaultClient = new KeyVaultClient(
                           new KeyVaultClient.AuthenticationCallback(
                              azureServiceTokenProvider.KeyVaultTokenCallback));

                        builder.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
                    }
                })
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
