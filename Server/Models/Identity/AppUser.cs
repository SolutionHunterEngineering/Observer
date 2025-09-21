using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;

namespace Server.Models.Identity
{
    public class AppUser : IdentityUser<int>
    {
        // public string UserName { get; set; } identity manager
        [MaxLength(255)]
        public string FirstName { get; set; } = "";
        [MaxLength(255)]
        public string LastName { get; set; } = "";
        [MaxLength(255)]
        public string KnownAs { get; set; } = "";
        
        [MaxLength(255)]
        public string Username { get; set; } = "";
        [MaxLength(255)]
        public string Password { get; set; } = "";

        [MaxLength(255)]
        public string Organization { get; set; } = "";

        [Phone]
        [MaxLength(255)]
        public string Phone { get; set; } = "";
        [Phone]
        [MaxLength(255)]
        public string AltPhone { get; set; } = "";

        [MaxLength(255)]
        public string City { get; set; } = "";
        [MaxLength(255)]
        public string State { get; set; } = "";
        [MaxLength(255)]
        public string Country { get; set; } = "";
        [MaxLength(255)]
        public string ZipCode { get; set; } = "";
        //[EmailAddress]
        //public string Email { get; set; }  /// this is handled by Identity Manager

        public bool CanTrial { get; set; } = false;
        public DateTime TrialBegan { get; set; } = DateTime.Now;
        public DateTime TrialEnd { get; set; } = DateTime.Today;

        public bool CCTypeUser { get; set; } = false;
        [MaxLength(255)]
        public string NameOnCC { get; set; } = "";
        [MaxLength(255)]
        public string CCNumber { get; set; } = "";
        [MaxLength(255)]
        public string CCExpires { get; set; } = "";
        [MaxLength(255)]
        public string CCAuthCode { get; set; } = "";

        [MaxLength(255)]
        public string Question { get; set; } = "";
        [MaxLength(255)]
        public string Answer { get; set; } = "";

        public bool isAdmin { get; set; } = false;
        public bool isDesigner { get; set; } = false;
        public bool isTrialUser { get; set; } = false;
        public bool isUser { get; set; } = false;


        public List<Project> Projects { get; set; } = new();

        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}