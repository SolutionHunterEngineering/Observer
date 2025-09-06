using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Models.Identity;
using Server.Models.Logs;

namespace Server.Database
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

//        public DbSet<AppUser> Users { get; set; } Identity handles this guy
        // public DbSet<EngDataMap>                EngDataMaps { get; set; }
        // public DbSet<ExternalDataRec>           ExternalDataRecs { get; set; }
        // public DbSet<Ghost>                     Ghosts { get; set; }
        // public DbSet<IndividualTrait>           IndividualTraits { get; set; }
        public DbSet<LogEngineerStream>            LogEngineerStreams { get; set; }
        public DbSet<LogRecord>                    LogRecords { get; set; }
        // public DbSet<Notification>              Notifications { get; set; }
        // public DbSet<Plugin>                    Plugins { get; set; }
        // public DbSet<PluginConfiguration>       PluginConfigurations { get; set; }
        // public DbSet<Project>                   Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users");

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
        }
    }
}