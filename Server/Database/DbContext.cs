using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ObserverApp.Models;
using Server.Models.Identity;
using Server.Models.Logs;
using Request = Azure.Core.Request;

namespace Server.Database
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ServerEntity> Servers { get; set; }
        public DbSet<Link> Links { get; set; }

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Result> Results { get; set; }

        public DbSet<LogEngineerStream> LogEngineerStreams { get; set; }
        public DbSet<LogRecord> LogRecords { get; set; }
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