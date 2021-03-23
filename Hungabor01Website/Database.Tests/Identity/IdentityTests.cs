using Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TestHelper;
using TestHelper.xUnit;
using Xunit;

namespace Database.Tests.Identity
{
    [CollectionDefinition("Serial", DisableParallelization = true)]
    public class IdentityTests
    {
        [SkipIntegrationTestsFact]
        public async Task AddAndRemoveTestUserAsync()
        {
            var userId = "TestUser";

            var configurationHelper = new ConfigurationHelper();
            var databaseHelper = new DatabaseHelper(configurationHelper.Configuration);
            var identityUserHelper = new IdentityUserHelper(databaseHelper.Context, userId);

            Assert.Null(await databaseHelper.Context.Users.FirstOrDefaultAsync(u => u.Id == userId));

            await identityUserHelper.AddTestUserAsync();
            Assert.NotNull(await databaseHelper.Context.Users.FirstOrDefaultAsync(u => u.Id == userId));

            await identityUserHelper.RemoveTestUserAsync();
            Assert.Null(await databaseHelper.Context.Users.FirstOrDefaultAsync(u => u.Id == userId));

            databaseHelper.Dispose();
        }
    }
}
