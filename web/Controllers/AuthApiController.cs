using E_Commerce.Web.Models.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using web.Service.IServices;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthApiController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;            _tokenProvider = tokenProvider;

        }




        [HttpPost("Register")]

        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            ResponseDto responceDto = await _authService.Register(registerRequestDto);

            if (responceDto == null) {

                return BadRequest(new ResponseDto()
                { errorMessage = responceDto.errorMessage,
                    isSuccess = responceDto.isSuccess });
            }
           

            return Ok(new ResponseDto()
            {
                errorMessage = responceDto.errorMessage,
                result = null,
                isSuccess = responceDto.isSuccess
            });

        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ResponseDto responseDto = await _authService.Login(loginRequestDto);

            if (responseDto != null && responseDto.isSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.result));
              
                await SignInUser(loginResponseDto);
                
                _tokenProvider.SetToken(loginResponseDto.Token);
                return Ok(new ResponseDto()
                {
                    errorMessage = responseDto.errorMessage,
                    result = loginResponseDto,
                    isSuccess = responseDto.isSuccess
                });

            }
            return BadRequest(new ResponseDto()
            {
                errorMessage = responseDto.errorMessage,
                result = responseDto.result,
                isSuccess = responseDto.isSuccess
            });

        }
    
        
        private async Task SignInUser(LoginResponseDto loginResponseDto)
        {
            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(loginResponseDto.Token);

            var identity= new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
              jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
              jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));



            identity.AddClaim(new Claim(ClaimTypes.Name,
              jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

            identity.AddClaim(new Claim(ClaimTypes.Role,
              jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));



            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);


        }
    }
}
