using Database.Core;
using System.Threading.Tasks;

namespace Database.Tests.Helpers
{
    public class IdentityUserHelper
    {
        private readonly ApplicationDbContext context;

        public ApplicationUser TestUser { get; }

        public IdentityUserHelper(ApplicationDbContext context, string userId)
        {
            this.context = context;

            TestUser = new ApplicationUser
            {
                Id = userId,
            };
        }

        public void AddTestUser()
        {
            var testUserInDb = context.Users.Find(TestUser.Id);
            if (testUserInDb == null)
            {
                context.Users.Add(TestUser);
                context.SaveChanges();
            }
        }

        public async Task AddTestUserAsync()
        {
            var testUserInDb = await context.Users.FindAsync(TestUser.Id);
            if (testUserInDb == null)
            {
                await context.Users.AddAsync(TestUser);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveTestUserAsync()
        {
            var testUserInDb = await context.Users.FindAsync(TestUser.Id);
            if (testUserInDb != null)
            {
                context.Users.Remove(TestUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
