using AutoMapper;
using E_Commerce.Service.CouponApi.Models.Domain;
using E_Commerce.Service.CouponApi.Models.DTO;

namespace E_Commerce.Service.CouponApi.Mappings
{
    public class AutomapperProfile :Profile
    {
        public AutomapperProfile() {

            CreateMap<Coupons, CouponDto>().ReverseMap();
            CreateMap<Coupons,CreateCouponDto>().ReverseMap();

        }
    }
}
