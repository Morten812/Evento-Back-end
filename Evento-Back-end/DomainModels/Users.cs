using Microsoft.AspNetCore.Identity;

namespace Evento_Back_end.DomainModels
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}
