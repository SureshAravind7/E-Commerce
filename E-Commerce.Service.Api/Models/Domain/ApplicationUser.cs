using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Service.Api.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
