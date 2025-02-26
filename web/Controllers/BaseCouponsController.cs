using E_Commerce.Web.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using web.Models.DTO;
using web.Service.IServices;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCouponsController : ControllerBase
    {
        private readonly ICouponService couponService;
        public BaseCouponsController(ICouponService couponService)
        {

            this.couponService = couponService;

        }

        [HttpGet]

        public async Task<IActionResult> GetAllCoupons()
        {

            List<CouponDto>? list = new();

            ResponseDto response = await couponService.getAllCouponsAsync();

            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.result));
                return Ok(new ResponseDto()
                {
                    result = list,
                    isSuccess = true

                });
            }

            return BadRequest(new ResponseDto()
            {
                result = response?.result,
                isSuccess=response.isSuccess,
                errorMessage =response?.errorMessage
            });
            
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteCoupon(int id)
        {
               var result = await  couponService.deleteCouponAsync(id);

            if (result != null && result.isSuccess) {

                return Ok(new ResponseDto()
                {
                    isSuccess = true,
                    result = result,
                    errorMessage = result.errorMessage
                  

                });
            }
            return BadRequest(new ResponseDto()
            {
                isSuccess = false,
                result = result.result,
                errorMessage = result.errorMessage


            });
        }


    }
}
