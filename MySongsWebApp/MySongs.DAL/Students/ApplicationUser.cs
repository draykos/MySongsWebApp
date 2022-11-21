using Microsoft.AspNetCore.Identity;

namespace MySongs.DAL.Students
{
    public class ApplicationUser : IdentityUser
    {
        public string CustomTag { get; set; }
    }
}
