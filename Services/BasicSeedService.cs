using CSharp___WebBlog.Data;
using CSharp___WebBlog.Enums;
using CSharp___WebBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Services
{
    public class BasicSeedService
    {
        // Seed a few roles into the system
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<BlogUser> _userManager;
        private readonly ApplicationDbContext _context;

        // Seed a few users into the service
        public BasicSeedService(ApplicationDbContext context,
                                RoleManager<IdentityRole> roleManager,
                                UserManager<BlogUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // This is a wrapper method
        public async Task SeedDataAsync()
        {
            // Creating the DB from the Migrations
            await _context.Database.MigrateAsync();
            // Seed a few Roles in the system
            await SeedRolesAsync();
            // Seed a few users into the systme
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            // Task 1: Ask the DB if any Roles already exist
            if (_context.Roles.Any())
            {
                return;
            }
            // Task 2: Create the necessary roles if they don't already exist
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                // use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
        }

        private async Task SeedUsersAsync()
        {
            //Task 1: Ask the DB if any Users already exist, if there are do nothing
            if (_context.Users.Any())
            {
                return;
            }

            // Step 1: Create the User intended to occupy the Administrator role
            var adminUser = new BlogUser()
            {
                Email = "coderfoundry@tiberio.org",
                UserName = "coderfoundry@tiberio.org",
                FirstName = "Belinda",
                LastName = "Tiberio",
                DisplayName = "Belle",
                PhoneNumber = "(206) 713-1688",
                EmailConfirmed = true
            };
            //Step 2: Use the UserManager to create a new user that is defined by the adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3: Add this new user to the Adminstrator Role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            // ================ SET UP THE MODERATOR =========================

            // Step 1: Create the Moderator User intended to occupy the Administrator role
            var modUser = new BlogUser()
            {
                Email = "AndrewRussell@CoderFoundry.com",
                UserName = "AndrewRussell@CoderFoundry.com",
                FirstName = "Andrew",
                LastName = "Russell",
                DisplayName = "Drew",
                PhoneNumber = "(800) 555-1213",
                EmailConfirmed = true
            };
            //Step 2: Use the UserManager to create a new user that is defined by the adminUser
            await _userManager.CreateAsync(modUser, "Abc&123!");

            //Step 3: Add this new user to the Adminstrator Role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }
    }
}