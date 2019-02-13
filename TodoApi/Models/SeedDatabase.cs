using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApi.Models
{
    public class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user = new ApplicationUser()
                {
                    Email = "marciocleberbrazil@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "marciocleberbrazil@gmail.com"
                };
                userManager.CreateAsync(user, "Password@123");
            }
        }
    }
}
