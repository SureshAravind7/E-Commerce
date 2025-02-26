using E_Commerce.Service.CouponApi.Data;
using E_Commerce.Service.CouponApi.Models.Domain;
using E_Commerce.Service.CouponApi.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace E_Commerce.Service.CouponApi.Respository
{
    public class CouponsRespository : ICouponRepository

    {
        private readonly CouponDbContext dbContext;

        public CouponsRespository(CouponDbContext   dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Coupons> createAsyncCoupon(Coupons coupons)
        {
            await dbContext.AddAsync(coupons);
            await dbContext.SaveChangesAsync();

            return coupons;
        }

        public async Task<Coupons> deleteCoupons(int id)
        {
           var couponDomain = await dbContext.CouponsList.FirstOrDefaultAsync(x=> x.CouponId == id);
            if (couponDomain == null) 
            {
                return null;

            }
            else
            {
                 dbContext.CouponsList.Remove(couponDomain);
               await dbContext.SaveChangesAsync();
                return couponDomain;

            }
        }

        public async Task<List<Coupons>> getAllCoupons()
        {
            var counpounDomain = dbContext.CouponsList.AsQueryable();
                 return await counpounDomain.OrderBy(x => x.CouponId).ToListAsync();


            
        }

        public async Task<Coupons> getCouponsById(int id)
        {
             var couponsDomain = await dbContext.CouponsList.FirstOrDefaultAsync(x=>x.CouponId == id);


            return couponsDomain;
        }

        public async Task<Coupons> updateAsyncCoupon(Coupons coupons)
        {
              dbContext.CouponsList.Update(coupons);

            await dbContext.SaveChangesAsync();
            return coupons;

        }
    }
}
