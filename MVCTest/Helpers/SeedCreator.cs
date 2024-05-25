using Microsoft.AspNetCore.Identity;
using MVCTest.Areas.Identity.Data;
using MVCTest.Data;

namespace MVCTest.Helpers
{
    public static class SeedCreator
    {
        public async static Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new[]
            { nameof(Roles.User), nameof(Roles.Manager), nameof(Roles.Admin) };

            foreach (string role in roles)
            {
                if (!(await roleManager.RoleExistsAsync(role)))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        public async static Task CreateUsersAsync(UserManager<User> userManager)
        {
            (string email, string password, string role)[] users = [
                ("admin@admin.com", "Admin1234!", nameof(Roles.Admin)),
                ("user@user.com", "Admin1234!", nameof(Roles.User)),
                ("manager@manager.com", "Admin1234!", nameof(Roles.Manager)),
            ];

            foreach (var u in users)
            {
                if (await userManager.FindByEmailAsync(u.email) == null)
                {
                    var user = new User();
                    user.Email = u.email;
                    user.UserName = u.email;
                    user.EmailConfirmed = true;


                    await userManager.CreateAsync(user, u.password);//add user into db

                    await userManager.AddToRoleAsync(user, u.role);
                }
            }
        }
    }
}
