using Microsoft.AspNetCore.Identity;

namespace Server.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}