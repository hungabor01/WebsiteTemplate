using Database.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Database.Tests.Helpers
{
    public sealed class DatabaseHelper : IDisposable
    {
        public ApplicationDbContext Context { get; }

        public DatabaseHelper(IConfiguration configuration)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseSqlServer(configuration.GetConnectionString("AppDbContextLocal"));
            Context = new ApplicationDbContext(options.Options);
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
