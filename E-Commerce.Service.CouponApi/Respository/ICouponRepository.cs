using E_Commerce.Service.CouponApi.Models.Domain;
using E_Commerce.Service.CouponApi.Models.DTO;

namespace E_Commerce.Service.CouponApi.Respository
{
    public interface ICouponRepository
    {
         Task<List<Coupons>> getAllCoupons();

        Task<Coupons> getCouponsById(int id);

        Task<Coupons> createAsyncCoupon (Coupons coupons);

        Task<Coupons> updateAsyncCoupon (Coupons coupons);

        Task<Coupons> deleteCoupons(int id);
    }
}
