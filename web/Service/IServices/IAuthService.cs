using E_Commerce.Web.Models.DTO;

namespace web.Service.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> Register(RegisterRequestDto registerRequestDto);
        Task<ResponseDto?> Login(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> AssignRoles(RegisterRequestDto registerRequestDto);
    }
}
