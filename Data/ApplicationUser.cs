using Microsoft.AspNetCore.Identity;

namespace WebApiWithPostgreSQL.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}