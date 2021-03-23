using Website.Helpers.RedirectingRules;
using Xunit;
namespace Website.Tests.Helpers
{
    public class SlugifyParameterTransformerTests
    {
        [Theory]
        [InlineData("urlExample")]
        [InlineData("UrlExample")]
        private void TransformOutbound_InputContainsDash_ResultIsPascalCase(string input)
        {
            var slugifyParameterTransformer = new SlugifyParameterTransformer();
            var output = slugifyParameterTransformer.TransformOutbound(input);
            Assert.Equal("url-example", output);
        }
    }
}
