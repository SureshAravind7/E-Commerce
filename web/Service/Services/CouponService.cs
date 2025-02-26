using E_Commerce.Web.Models.DTO;
using web.Models.DTO;
using web.Service.IServices;
using web.Utility;
using static System.Net.WebRequestMethods;

namespace web.Service.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService baseService;
        public CouponService(IBaseService baseService)
        {
            this.baseService = baseService;
        }
        public async Task<ResponseDto?> createCouponAsync(CouponDto coupon)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype=SD.ApiTypes.POST,
                Url = SD.CouponApiBase+"/api/Coupons",
                Data = coupon
            });
        }

        public async Task<ResponseDto?> deleteCouponAsync(int couponId)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype =SD.ApiTypes.DELETE,
                Url = SD.CouponApiBase+"/api/Coupons?id="+couponId
                

            });
        }

        public async Task<ResponseDto?> getAllCouponsAsync()

        {
            if (baseService == null)
            {
                throw new Exception("couponService is null");
            }

            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.GET,
                Url = SD.CouponApiBase+ "/api/Coupons",
               
            });

            }

        public async Task<ResponseDto?> getCounponByIdAsync(int counponId)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.GET,
                Url = SD.CouponApiBase +"api/Coupons/"+counponId
            });
        }

        public async Task<ResponseDto?> updateCouponAsync(CouponDto coupon)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.PUT,
                Url = SD.CouponApiBase + "/api/Coupons",
                Data = coupon
            });
        }
    }

        
    }

