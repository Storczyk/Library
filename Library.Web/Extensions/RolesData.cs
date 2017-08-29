using Library.Infrastructure.Data;
using Library.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Library.Web.Extensions
{
    public static class RolesData
    {
        private static readonly string[] Roles = new string[] { "Administrator" };
        private static readonly string[] Admin = new string[] { "testingpgsapp@gmail.com", "Test90()" };

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<LibraryDbContext>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                foreach (var role in Roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

            }
        }

        public static async Task SeedUsers(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<LibraryDbContext>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var result = await userManager.FindByEmailAsync(Admin[0]);
                if (result != null)
                {
                    return;
                }

                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = Admin[0],
                    UserName = "Admin"
                };
                var passwordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, Admin[1]);
                user.PasswordHash = "AQAAAAEAACcQAAAAEGbWHpLy3SB7tZ1iCrJP41ZBuvKllrj5M89GXpIDaPqEISI5cKU6Ios6wTFBlAcB4g==";

                await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, "ADMINISTRATOR");
            }
        }
    }
}

