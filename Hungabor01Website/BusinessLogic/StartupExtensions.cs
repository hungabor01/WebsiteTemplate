using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static void AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
