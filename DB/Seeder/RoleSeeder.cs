using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DB.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManeger)
        {
            if (!await roleManeger.RoleExistsAsync("Admin"))  {
                await roleManeger.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManeger.RoleExistsAsync("Manager"))  {
                await roleManeger.CreateAsync(new IdentityRole("Manager")); 
            }
            if (!await roleManeger.RoleExistsAsync("Annotator"))  {
                await roleManeger.CreateAsync(new IdentityRole("Annotator"));
            }

        }
    }
}
