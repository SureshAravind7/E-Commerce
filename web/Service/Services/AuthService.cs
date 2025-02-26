using E_Commerce.Web.Models.DTO;
using web.Models.DTO;
using web.Service.IServices;
using web.Utility;

namespace web.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService baseService;
     
        public AuthService(IBaseService baseService) { 
         this.baseService = baseService;
            
        }
        public async Task<ResponseDto?> AssignRoles(RegisterRequestDto registerRequestDto)
        {

            throw new NotImplementedException();

        }

        public async  Task<ResponseDto?> Login(LoginRequestDto loginRequestDto)
        {
            var result = await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.POST,
                Data = loginRequestDto,
                Url =SD.AuthApiBase+ "/api/auth/Login",
                
            });
            return result;
        }

        public async Task<ResponseDto?> Register(RegisterRequestDto registerRequestDto)
        {
            var result = await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.POST,
                Data=registerRequestDto,
                Url =SD.AuthApiBase+ "/api/auth/register"
            });
            
            return result;
        }
    }
}
