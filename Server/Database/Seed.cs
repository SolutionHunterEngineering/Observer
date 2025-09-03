using IdentityDomain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Server.Database
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context, 
                UserManager<AppUser> userManager, IConfiguration configuration)
        {
            if (await context.Users.AnyAsync()) return;  // users already present, then exit

            var userData = await File.ReadAllTextAsync("Database/UserSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = new List<AppUser>();
            try
            {
                users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            foreach (AppUser user in users)
            {
                user.UserName = user.UserName.ToLower();
                try
                {
                    var result = await userManager.CreateAsync(user, "Test$12345");
                    if (!result.Succeeded)
                    {
                        Console.WriteLine($"Failed to create user {user.UserName}:");
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine($" - {error.Code}: {error.Description}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                if (user.isAdmin) claims.Add(new Claim("AdminUser", "true"));
                if (user.isDesigner) claims.Add(new Claim("Designer", "true"));
                if (user.isTrialUser) claims.Add(new Claim("TrialUser", "true"));
                if (user.isUser) claims.Add(new Claim("User", "true"));

                await userManager.AddClaimsAsync(user, claims);

                // Generate a token for each user for testing purposes
                var token = GenerateToken(user, configuration);
                Console.WriteLine($"Generated token for {user.UserName}: {token}");
            }
        }

        private static string GenerateToken(AppUser user, IConfiguration configuration)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            if (user.isAdmin) claims.Add(new Claim("AdminUser", "true"));
            if (user.isDesigner) claims.Add(new Claim("Designer", "true"));
            if (user.isTrialUser) claims.Add(new Claim("TrialUser", "true"));
            if (user.isUser) claims.Add(new Claim("User", "true"));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
