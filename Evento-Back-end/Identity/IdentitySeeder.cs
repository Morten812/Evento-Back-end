using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Evento_Back_end.Data;


namespace Evento_Back_end.Identity
{
    public static class IdentitySeeder
    {
        public static async Task SeedUserAsync(IServiceProvider serviceProvider)
        {
            /*
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Define the admin user details
            var adminEmail = "admin@gmail.com";
            var adminPassword = "Admin@123";

            // Check if the admin user already exists
            var userExist = await userManager.FindByEmailAsync(adminEmail);
            if (userExist == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Admin",
                    PhoneNumber = "1122334455",
                    EmailConfirmed = true,
                    EnableNotifications = true
                };

                // Create the admin user
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    // Assign the admin role to the user
                    await userManager.AddToRoleAsync(adminUser, Rolenames.Admin);
                }
                else
                {
                    throw new Exception("Failed to create the admin user: " + string.Join(", ", result.Errors));
                }
            }
            */

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Define the customer user details
            var managerEmail = "GLSManager@gmail.com";
            var managerPassword = "GLSManager@123";

            // Check if the customer user already exists
            var userExist = await userManager.FindByEmailAsync(managerEmail);
            if (userExist == null)
            {
                var managerUser = new ApplicationUser
                {
                    UserName = managerEmail,
                    Email = managerEmail,
                    FullName = "GLSManager",
                    PhoneNumber = "44881212",
                    EmailConfirmed = true,
                    EnableNotifications = true
                };

                // Create the customer user
                var result = await userManager.CreateAsync(managerUser, managerPassword);
                if (result.Succeeded)
                {
                    // Assign the customer role to the user
                    await userManager.AddToRoleAsync(managerUser, Rolenames.Manager);
                }
                else
                {
                    throw new Exception("Failed to create the manager user: " + string.Join(", ", result.Errors));
                }
            }
        }

    }
}
