using Microsoft.AspNetCore.Identity;

namespace Server.Models.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}

