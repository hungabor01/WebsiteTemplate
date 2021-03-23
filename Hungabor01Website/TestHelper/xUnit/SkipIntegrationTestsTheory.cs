using Microsoft.Extensions.Configuration;
using Xunit;

namespace TestHelper.xUnit
{
    public sealed class SkipIntegrationTestsTheory : TheoryAttribute
    {
        public SkipIntegrationTestsTheory()
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
