using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WoD.Data;
using WoD.Enums;
using WoD.Models;

namespace WoD.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<WoDUser> _userManager;

        public DataService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<WoDUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            await _context.Database.MigrateAsync();
            await SeedRolesAsync();
            await SeedUsersAsync();
            //await SeedBooksAsync();
            //await SeedClans();
            //await SeedBloodPotency();
            //await SeedDisciplines();
            //await SeedDisciplinePower();
            //await SeedSkills();
            //await SeedChronicle();
            //await SeedPredatorTypes();
            //await SeedLoreSheets();
            //await SeedLoreSheetParts();
            //await SeedRituals();
            //await SeedThinBloodAlchemy();
            //await SeedCoterie();
        }

        private async Task SeedRolesAsync()
        {
            if (_context.Roles.Any()) return;
            foreach (var role in Enum.GetNames(typeof(WoDRole)))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            if (_context.Users.Any()) return;

            var user = new WoDUser()
            {
                Email = "Admin@gmail.com",
                UserName = "Admin@gmail.com",
                NickName = "Floki",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(user, "Cas&1234");
            await _userManager.AddToRoleAsync(user, WoDRole.Admin.ToString());

            var userST = new WoDUser()
            {
                Email = "StoryTeller@gmail.com",
                UserName = "StoryTeller@gmail.com",
                NickName = "StoryFloki",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(userST, "Cas&1234");
            await _userManager.AddToRoleAsync(userST, WoDRole.StoryTeller.ToString());

            var userP = new WoDUser()
            {
                Email = "Player@gmail.com",
                UserName = "Player@gmail.com",
                NickName = "PlayerFloki",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true

            };

            await _userManager.CreateAsync(userP, "Cas&1234");
            await _userManager.AddToRoleAsync(userP, WoDRole.Player.ToString());

            var userG = new WoDUser()
            {
                Email = "Guest@gmail.com",
                UserName = "Guest@gmail.com",
                NickName = "GuestFloki",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(userG, "Cas&1234");
            await _userManager.AddToRoleAsync(userG, WoDRole.Guest.ToString());

            var userGgG = new WoDUser()
            {
                Email = "wljmanie@gmail.com",
                UserName = "wljmanie@gmail.com",
                NickName = "gmailrofl",
                EmailConfirmed = false
            };

            await _userManager.CreateAsync(userGgG, "Cas&1234");
            await _userManager.AddToRoleAsync(userGgG, WoDRole.Guest.ToString());
        }
    }
}
