using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Service.CouponApi.Models.DTO
{
    public class CreateCouponDto
    {
        [Required]
        [MinLength(3, ErrorMessage ="It should be more than 3 characters")]
        [MaxLength(19,ErrorMessage ="It should be less than 19")]
        public string? CouponCode { get; set; }

        [Required]
        public int DiscountAmount { get; set; }

        [Required]
        public int MinAmount { get; set; }
    }
}
