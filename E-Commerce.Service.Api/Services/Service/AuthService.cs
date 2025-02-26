using E_Commerce.Service.Api.Data;
using E_Commerce.Service.Api.Models.Domain;
using E_Commerce.Service.Api.Models.DTO;
using E_Commerce.Service.Api.Services.IService;
using E_Commerce.Service.CouponApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Service.Api.Services.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        public AuthService(AuthDbContext authDbContext, UserManager<ApplicationUser>
            userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this.authDbContext = authDbContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> AssignRole(string email, string roleName )
        {
           var user = authDbContext.ApplicationUsers.FirstOrDefault(u=>u.Email== email.ToLower());
            if (user != null)
            {
                if (!roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult()) { 
                    
                    roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();  
                    
                }
                await userManager.AddToRoleAsync(user, roleName);
                return true;
            }
                return false;
            
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto requestDto)
        {
            var user = await authDbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.UserName == requestDto.UserName);
            bool isValid = await userManager.CheckPasswordAsync(user, requestDto.Password);
            if (user == null || isValid ==false) {

                return new LoginResponseDto() { User = null, Token = "" };
            }
            var roles = await userManager.GetRolesAsync(user);
            var token =  jwtTokenGenerator.GenerateToken(user,roles);

            UserDto userDto = new UserDto()
            {
                Name = user.Name,
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,

            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };
            return loginResponseDto;
        }

        public async Task<string> Register(RegisterRequestDto requestDto)
        {
            ApplicationUser user = new()
            {
                UserName = requestDto.Email,
                Email = requestDto.Email,
                NormalizedEmail = requestDto.Email.ToUpper(),
                PhoneNumber = requestDto.PhoneNumber,
                Name = requestDto.Name,
            };
            try
            {
                var result = await userManager.CreateAsync(user, requestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn =await  authDbContext.ApplicationUsers.FirstOrDefaultAsync(user => user.UserName == requestDto.Email);

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch(Exception e) {
             
               
           
            }
            return "Error Encountered";
            
        }
    }
}
