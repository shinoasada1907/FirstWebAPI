using Microsoft.AspNetCore.Identity;

namespace FirstWebAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
    }
}
