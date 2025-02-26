using E_Commerce.Service.CouponApi.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace E_Commerce.Service.CouponApi.Data
{
    public class CouponDbContext : DbContext
    {
        public CouponDbContext(DbContextOptions<CouponDbContext> options) : base(options)
        {
        }


        public DbSet<Coupons> CouponsList { get; set; }

       
    }
}

