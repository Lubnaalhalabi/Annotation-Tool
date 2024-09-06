using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DB.Seeder
{
    public class AdminUserSeeder
    {
        public static async Task SeedAdminAsync(UserManager<DB.Models.ApplicationUser> userManager)
        {
            if ((await userManager.FindByEmailAsync("admin@admin.com")) == null)
            {
                var user = new DB.Models.ApplicationUser
                { 
                    Id = Guid.NewGuid().ToString(), 
                    UserName = "admin@admin.com", 
                    Email = "admin@admin.com", 
                    Name = "Admin", 
                    Address = "Damascus", 
                    PhoneNumber = "1234567890" 
                };

                var result = userManager.CreateAsync(user, "123456789dD!").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
