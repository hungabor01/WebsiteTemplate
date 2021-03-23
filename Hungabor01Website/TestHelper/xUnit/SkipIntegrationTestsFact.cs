using Microsoft.Extensions.Configuration;
using Xunit;

namespace TestHelper.xUnit
{
    public sealed class SkipIntegrationTestsFact : FactAttribute
    {
        public SkipIntegrationTestsFact()
        {
            var configuration = new ConfigurationHelper().Configuration;
            var skipIntegrationTests = configuration.GetValue<bool>("SkipIntegrationTests");

            if (skipIntegrationTests)
            {
                Skip = "Skip integration tests";
            }
        }
    }
}
