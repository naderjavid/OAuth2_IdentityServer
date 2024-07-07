using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OAuth2_IdentityServer
{
    public static class SeedData
    {
        public static WebApplication EnsureSeedData(this WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                if (!context.Users.Any())
                {
                    var alice = new ApplicationUser
                    {
                        UserName = "alice",
                        Email = "alice@example.com",
                        EmailConfirmed = true
                    };
                    userManager.CreateAsync(alice, "Password123!").Wait();
                }
            }

            return app;
        }
    }

}
