using AutoMapper;
using E_Commerce.Service.Api.Models.DTO;

namespace E_Commerce.Service.Api.Mappings
{
    public class AutoMapperProfilel:Profile
    {
        public AutoMapperProfilel()
        {
            CreateMap<UserDto,UserDto>().ReverseMap();
        }
    }
}
