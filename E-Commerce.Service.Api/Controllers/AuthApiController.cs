using E_Commerce.Service.Api.Models.DTO;
using E_Commerce.Service.Api.Services.IService;
using E_Commerce.Service.CouponApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Service.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService authService;
        protected ResponseDto responseDto { get; set; }
         public AuthApiController(IAuthService authService) 
        {
            this.authService = authService;
            responseDto = new();
        }
        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var result = await authService.Register(registerRequestDto);
            if (!string.IsNullOrEmpty(result)) {
                responseDto.errorMessage= result;
                responseDto.isSuccess =false;
                return BadRequest(responseDto);
            }
            return Ok(responseDto);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            var result = await authService.Login(loginRequestDto);
            if (result.User != null)
            {
                responseDto.isSuccess = true;
                responseDto.result = result;
                responseDto.isSuccess = true;
                return Ok(responseDto);
            }
            else
            {
                responseDto.isSuccess = false;
                responseDto.errorMessage = "Username or password is incorrect";
                return BadRequest(responseDto);
            }
           
        }



        [HttpPost("AssignRoles")]

        public async Task<IActionResult> AssignRoles (RegisterRequestDto registerRequestDto)
        {
             var result =await authService.AssignRole(registerRequestDto.Email.ToUpper(), registerRequestDto.Role);
            if (result == false)
            {
                responseDto.isSuccess = false;
                responseDto.errorMessage ="Error Encountered" ;
                return BadRequest(responseDto);
            }
            return Ok(responseDto);

        }
    }
}
