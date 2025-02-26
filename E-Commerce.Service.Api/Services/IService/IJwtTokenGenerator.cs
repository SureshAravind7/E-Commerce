using E_Commerce.Service.Api.Models.Domain;

namespace E_Commerce.Service.Api.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
