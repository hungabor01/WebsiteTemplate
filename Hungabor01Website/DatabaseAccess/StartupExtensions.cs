using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static void AddDatabaseAccess(this IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}