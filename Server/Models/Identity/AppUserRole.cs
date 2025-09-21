// Shared/Models/AppUserRole.cs
using Microsoft.AspNetCore.Identity;

namespace Server.Models.Identity
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}