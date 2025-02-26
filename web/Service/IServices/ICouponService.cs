using E_Commerce.Web.Models.DTO;

using web.Models.DTO;

namespace web.Service.IServices
{
    public interface ICouponService
    {
        Task<ResponseDto?> getAllCouponsAsync();
        Task<ResponseDto?> getCounponByIdAsync(int counponId);
        Task<ResponseDto?> createCouponAsync(CouponDto coupon);
        Task<ResponseDto?> updateCouponAsync(CouponDto coupon);
        Task<ResponseDto?> deleteCouponAsync(int couponId);

    }
}
