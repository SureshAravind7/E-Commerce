using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Service.CouponApi.Models.Domain
{
    public class Coupons
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string? CouponCode { get; set; }
        public int DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
