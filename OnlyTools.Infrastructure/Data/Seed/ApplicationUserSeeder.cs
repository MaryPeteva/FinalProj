using Microsoft.AspNetCore.Identity;
using OnlyTools.Infrastructure.Data.IdentityModels;

namespace OnlyTools.Infrastructure.Data.Seed
{
    public class ApplicationUserSeeder
    {
        private readonly OnlyToolsDbContext _context;
       
        public async Task SeedAsync()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            if (!_context.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        Id = new Guid("0F0929A7-3E3E-4A9E-A1E7-08DC5D8CB0E2"),
                        UserName = "CoolCat42",
                        NormalizedUserName = "COOLCAT42",
                        Email = "coolcat42@example.com",
                        NormalizedEmail = "COOLCAT42@EXAMPLE.COM",
                        EmailConfirmed = true,
                        SecurityStamp = "IJXOEOZCE5A5FM2LJZQ272YEIDRNEQCS",
                        ConcurrencyStamp = "28847a60-353d-4e56-9afe-bc9ed616538d",
                        PhoneNumber = "1234567890",
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new ApplicationUser
                    {
                        Id = new Guid("30DB344E-DD97-4F7F-A1E8-08DC5D8CB0E2"),
                        UserName = "SparkleGuru",
                        NormalizedUserName = "SPARKLEGURU",
                        Email = "sparkle.guru@email.com",
                        NormalizedEmail = "SPARKLE.GURU@EMAIL.COM",
                        EmailConfirmed = true,
                        SecurityStamp = "SLURWCO7BZ7JCWETAIVKIZF7QGNBTVDV",
                        ConcurrencyStamp = "6fce96b9-9358-48cf-8a3e-26b285410ba8",
                        PhoneNumber = "9876543210",
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new ApplicationUser
                    {
                        Id = new Guid("2886BDBD-4ED2-4306-A1E9-08DC5D8CB0E2"),
                        UserName = "TurboChic",
                        NormalizedUserName = "TURBOCHIC",
                        Email = "turbo.chic87@email.com",
                        NormalizedEmail = "TURBO.CHIC87@EMAIL.COM",
                        EmailConfirmed = true,
                        SecurityStamp = "NYWYSBWSJTIDM3J2JD7AVRJ3OXCL7IPE",
                        ConcurrencyStamp = "7864db46-c3e8-4872-bec4-2a700c67efcb",
                        PhoneNumber = "1234567890",
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new ApplicationUser
                    {
                        Id = new Guid("9FD3CD44-6F9E-4DB2-A1EA-08DC5D8CB0E2"),
                        UserName = "RainbowNinja",
                        NormalizedUserName = "RAINBOWNINJA",
                        Email = "rainbow.ninja@example.com",
                        NormalizedEmail = "RAINBOW.NINJA@EXAMPLE.COM",
                        EmailConfirmed = true,
                        SecurityStamp = "ZMULL5NIDDH2S4IIZFG7UTNEFRWBMLBC",
                        ConcurrencyStamp = "970a9f67-c4ff-40fb-98f3-cc82bc0d1923",
                        PhoneNumber = "1234567890",
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new ApplicationUser
                    {
                        Id = new Guid("A056FE60-3683-4D77-A1EB-08DC5D8CB0E2"),
                        UserName = "Jane",
                        NormalizedUserName = "JANE",
                        Email = "janedoe@example.com",
                        NormalizedEmail = "JANEDOE@EXAMPLE.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        PhoneNumber = "1234567890",
                        PhoneNumberConfirmed = true,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    }
                };

                List<string> Passwords = new List<string>()
                {
                    "p@ssw0rd123","[email protected]$$W0rd", "ChicTurbo456!", "NinjaRainbow789","Explorer55#"
                };
                int i = 0;
                foreach (var user in users)
                {
                    user.PasswordHash = hasher.HashPassword(user, Passwords[i]);
                    i++;
                    try
                    {
                        await _context.AddAsync(user);
                    }
                    catch (Exception ex)
                    {
                        await Console.Out.WriteLineAsync(ex.Message);
                    }
                }
            }
        }
    }
}
