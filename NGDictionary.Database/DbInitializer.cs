using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NGDictionary.Database.Entity;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using NGDictionary.Core;

namespace NGDictionary.Database
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }



    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly EFDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;

        public DatabaseInitializer(
            EFDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<DatabaseInitializer> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _logger = logger;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);

            if (!await _context.Users.AnyAsync())
            {
                _logger.LogInformation("Generating inbuilt accounts");

                await EnsureRoleAsync(ServerRoles.Admin);
                await EnsureRoleAsync(ServerRoles.User);

                await CreateUserAsync("DefaultAdmin", "tempP@ss123", "admin@ebenmonney.com", new string[] { ServerRoles.Admin });
                await CreateUserAsync("DefaultUser", "tempP@ss123", "user@ebenmonney.com", new string[] { ServerRoles.User });

                _logger.LogInformation("Inbuilt account generation completed");
            }

        }

        private async Task EnsureRoleAsync(string roleName)
        {
            if ((await _roleManager.FindByNameAsync(roleName)) == null)
            {
                IdentityRole applicationRole = new IdentityRole(roleName);

                var result = await _roleManager.CreateAsync(applicationRole);

                if (!result.Succeeded)
                    throw new Exception($"Seeding \"{roleName}\" role failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");
            }
        }

        private async Task<ApplicationUser> CreateUserAsync(string userName, string password, string email, string[] roles)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = true,
                IsEnabled = true
            };

            var result = await CreateUserAsync(applicationUser, roles, password);

            if (!result.Succeeded)
                throw new Exception($"Seeding \"{userName}\" user failed. Errors: {string.Join(Environment.NewLine, result.Errors)}");


            return applicationUser;
        }

        private async Task<(bool Succeeded, string[] Errors)> CreateUserAsync(ApplicationUser user, IEnumerable<string> roles, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            user = await _userManager.FindByNameAsync(user.UserName);

            try
            {
                result = await _userManager.AddToRolesAsync(user, roles.Distinct());
            }
            catch
            {
                await DeleteUserAsync(user);
                throw;
            }

            if (!result.Succeeded)
            {
                await DeleteUserAsync(user);
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }

            return (true, new string[] { });
        }

        private async Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);
            return (result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }
    }
}
