using CSharp___WebBlog.Data;
using CSharp___WebBlog.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp___WebBlog.Services
{
    public class BasicSeedService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;
        private readonly ApplicationDbContext _context;

        public BasicSeedService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // This is a wrapper method
        public async Task SeedDataAsync()
        {
            await SeedRolesAsync();
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
            await _roleManager.CreateAsync(new IdentityRole("Administrator"));
        }

        private async Task SeedUsersAsync()
        {
            //Task 1: Ask the DB if any Users already exist
            if (_context.Users.Any())
            {
                return;
            }

            // Task 2: Create the User intended to occupy the Administrator role
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
            await _userManager.CreateAsync(adminUser, "Abc&123!");
            await _userManager.AddToRoleAsync(adminUser, "Administrator");
        }
    }
}