using E_Commerce.Web.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using web.Models.DTO;
using web.Service.IServices;
using web.Service.Services;

namespace web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;


        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            List<ProductDto>? list = new();

            ResponseDto response = await productService.GetAllProductsAsync();

            if (response != null && response.isSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.result));
                return Ok(new ResponseDto()
                {
                    result = list,
                    isSuccess = true

                });
            }
            return BadRequest(new ResponseDto()
            {
                result = response.result,
                isSuccess = response.isSuccess,
                errorMessage = response.errorMessage
            });



        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getAllProductById(int id)
        {
             ProductDto? product= new ProductDto();
            var response = await productService.GetProductsByIdAsync(id);
            if (response != null && response.isSuccess)
            {
                product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.result));
                return Ok(new ResponseDto()
                {
                    result = product,
                    isSuccess = response.isSuccess,
                    errorMessage = response.errorMessage
                });
            }
            
            
                return BadRequest(new ResponseDto()
                {
                    result = product,
                    isSuccess = response.isSuccess,
                    errorMessage = response.errorMessage
                });
            
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteProducts(int id)
        {
            
            var response = await productService.DeleteProductAsync(id);
            if (response != null && response.isSuccess) {
            return Ok(new ResponseDto()
            {
                
                result = response,
                isSuccess = response.isSuccess,
                errorMessage = response.errorMessage
            });
        }
            return BadRequest(new ResponseDto()
            {
                result = null,
                isSuccess = response.isSuccess,
                errorMessage = response.errorMessage
            });
        }
    }
}
