using Database.Core;
using Database.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // add repositories
            // services.AddTransient<ISampleEntityRepository, SampleEntityRepository>();

            if (isDevelopment)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("AppDbContextLocal"), b => b.MigrationsAssembly("Database")),
                    ServiceLifetime.Transient);
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration["AppDbContextAzure"], b => b.MigrationsAssembly("Database")),
                    ServiceLifetime.Transient);
            }

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(o => o.LoginPath = "/Login/Login");
        }
    }
}