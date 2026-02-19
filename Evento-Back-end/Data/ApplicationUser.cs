using Microsoft.AspNetCore.Identity;

namespace Evento_Back_end.Data
{
    public class ApplicationUser : IdentityUser
    {
        public bool EnableNotifications { get; set; }
        public string Initials { get; set; } = string.Empty;
    }
}
