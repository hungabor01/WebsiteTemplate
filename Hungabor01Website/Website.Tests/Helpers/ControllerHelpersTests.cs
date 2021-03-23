using Website.Controllers;
using Website.Helpers;
using Xunit;

namespace Website.Tests.Helper
{
    public class ControllerHelpersTests
    {
        [Fact]
        public void GetControllerName_TestController_Login()
        {
            var name = ControllerHelpers.GetControllerName<HomeController>();
            Assert.Equal("home", name);
        }
    }
}
