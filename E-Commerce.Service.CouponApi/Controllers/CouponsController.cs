using AutoMapper;
using E_Commerce.Service.CouponApi.Data;
using E_Commerce.Service.CouponApi.Models.Domain;
using E_Commerce.Service.CouponApi.Models.DTO;
using E_Commerce.Service.CouponApi.Respository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Service.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponRepository repository;

        private readonly IMapper mapper;


        public CouponsController(ICouponRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet]

        public async Task<IActionResult> getAllCoupons()
        {
            try
            {
                var counpounDomain = await repository.getAllCoupons();
                var domain = mapper.Map<List<CouponDto>>(counpounDomain);
                var response = new ResponseDto()
                {
                    result = domain,
                    isSuccess = true,
                    errorMessage = ""
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto()
                {
                    errorMessage = ex.Message,
                    isSuccess = false
                };

                return NotFound(response);
            }

        }



        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> getCouponsById(int id)
        {
            
            try
            {
                var counpon = await repository.getCouponsById(id);

                if (counpon == null)
                {
                    return StatusCode(400, new ResponseDto()
                    {
                        errorMessage = $"Coupon with {id} not found",
                        isSuccess = false,
                    });
                }

                var result = mapper.Map<CouponDto>(counpon);

                var Response = new ResponseDto
                {
                    result = result,
                    errorMessage = "",
                    isSuccess = true

                };
                return Ok(Response);



            }
            catch (Exception ex)
            {

                var response = new ResponseDto()
                {
                    errorMessage = ex.Message,
                    isSuccess = false
                };

                return BadRequest(response);

            }

        }


        [HttpPost]


        public async Task<IActionResult> CreateCoupon([FromBody] CreateCouponDto createCouponDto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var couponDomain = mapper.Map<Coupons>(createCouponDto);
                    var dto = mapper.Map<CreateCouponDto>(couponDomain); return StatusCode(200, new ResponseDto
                    {
                        result = dto,
                        isSuccess = true,
                    });
                }
                catch (Exception ex)
                {
                    return StatusCode(400, new ResponseDto
                    {
                        errorMessage = ex.Message,
                        isSuccess = false,
                    });

                }


            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCoupons([FromBody] CouponDto couponDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var couponDomain = mapper.Map<Coupons>(couponDto);
                    var result = await repository.updateAsyncCoupon(couponDomain);

                    return StatusCode(200, new ResponseDto
                    {
                        result = result,
                        errorMessage = "",
                        isSuccess = true,
                    });

                }
                catch (Exception e)
                {
                    var response = new ResponseDto()
                    {
                        isSuccess = false,
                        errorMessage = e.Message,
                    };

                    return Ok(response);

                }
            }
            else
            {
                return Ok(ModelState);
            }
        }


        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            var result =await  repository.deleteCoupons(id);

            if (result == null)
            {
                return StatusCode(404, new ResponseDto
                {
                    isSuccess = false,
                    result = null,
                    errorMessage = $"Coupon with{id} is not found "

                });
            }
            else {
                return StatusCode(200, new ResponseDto { isSuccess = true, result = result, });
                   
            }
        }


    }
}
