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
            var customerEmail = "customer@gmail.com";
            var customerPassword = "Customer@123";

            // Check if the customer user already exists
            var userExist = await userManager.FindByEmailAsync(customerEmail);
            if (userExist == null)
            {
                var customerUser = new ApplicationUser
                {
                    UserName = customerEmail,
                    Email = customerEmail,
                    FullName = "Customer",
                    PhoneNumber = "22446688",
                    EmailConfirmed = true,
                    EnableNotifications = true
                };

                // Create the customer user
                var result = await userManager.CreateAsync(customerUser, customerPassword);
                if (result.Succeeded)
                {
                    // Assign the customer role to the user
                    await userManager.AddToRoleAsync(customerUser, Rolenames.Customer);
                }
                else
                {
                    throw new Exception("Failed to create the customer user: " + string.Join(", ", result.Errors));
                }
            }
        }

    }
}
