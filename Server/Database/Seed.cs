using System.Text.Json;
using Server.Models.Identity;

namespace Server.Database
{
    public static class Seed
    {
        // In-memory list used by AccountsController
        public static List<AppUser> Users { get; private set; } = new List<AppUser>();

        public static void SeedData(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                // If a DbContext exists, you could resolve it here:
                // var context = services.GetRequiredService<ApplicationDbContext>();

                // Load from Seed.json if available
                var seedFile = Path.Combine(AppContext.BaseDirectory, "Data", "Seed.json");
                if (File.Exists(seedFile))
                {
                    var json = File.ReadAllText(seedFile);
                    var users = JsonSerializer.Deserialize<List<AppUser>>(json);

                    if (users != null && users.Count > 0)
                    {
                        Users = users;

                        // If using EF context, you could add:
                        // if (!context.Users.Any()) { context.Users.AddRange(users); context.SaveChanges(); }
                    }
                }
                else
                {
                    // Fallback: add one default admin user inline
                    Users = new List<AppUser>
                    {
                        new AppUser { Username = "admin", Password = "admin", Role = "Admin" }
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Seed] Error seeding data: {ex.Message}");
            }
        }
    }
}