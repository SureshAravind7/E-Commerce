using E_Commerce.Service.Api.Models.DTO;

namespace E_Commerce.Service.Api.Services.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegisterRequestDto requestDto);

        Task<LoginResponseDto> Login(LoginRequestDto requestDto);
        Task<bool> AssignRole(string email, string roleName);

    }
}
