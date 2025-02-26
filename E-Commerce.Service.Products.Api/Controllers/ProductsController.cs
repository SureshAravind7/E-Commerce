using AutoMapper;
using E_Commerce.Service.Products.Api.Data;
using E_Commerce.Service.Products.Api.Mappings;
using E_Commerce.Service.Products.Api.Models.Domain;
using E_Commerce.Service.Products.Api.Models.Dto;
using E_Commerce.Service.Products.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.Service.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var productDomain = await productRepository.GetAllProductAsync();
                var domain = mapper.Map<List<ProductDto>>(productDomain);
                return Ok(new ResponseDto()
                {
                    Result = domain,
                    isSuccess = true,
                    errorMessage = null
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    Result = null,
                    isSuccess = false,
                    errorMessage = e.Message
                });
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var productDomain = await productRepository.GetProductByIdAsync(id);
                if (productDomain == null)
                {
                    return NotFound(new ResponseDto()
                    {
                        errorMessage=$"No product with {id} found"
                    });
                }
                var result = mapper.Map<ProductDto>(productDomain);
                return Ok(new ResponseDto()
                {
                    Result = result,
                    isSuccess = true,
                    errorMessage = null
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    Result = null,
                    isSuccess = false,
                    errorMessage = e.Message
                });
            }

        }

        [HttpPost]

        public async Task<IActionResult> createProduct(ProductDto product)
        {
            try
            {
                var productdomain = mapper.Map<Product>(product);
                var response = await productRepository.CreateProductAsync(productdomain);
                var result = mapper.Map<ProductDto>(response);
                return Ok(new ResponseDto()
                {
                    Result = result,
                    isSuccess = true,
                    errorMessage = null
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseDto()
                {
                    Result = null,
                    isSuccess = false,
                    errorMessage = e.Message
                });
            }
        }
        [HttpPut]

        public async Task<IActionResult> UpdateProduct(ProductDto productDto)
        {
            try
            {
                var productDomain = mapper.Map<Product>(productDto);
                var Response = await productRepository.UpdateProductAsync(productDomain);
                var result = mapper.Map<ProductDto>(Response);
                return Ok(new ResponseDto()
                {
                    Result = result,
                    isSuccess = true,
                    errorMessage = null
                });

            }
            catch (Exception e) 
            {
                return BadRequest(new ResponseDto()
                {
                    Result = null,
                    isSuccess = false,
                    errorMessage = e.Message
                });
            }
           
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var productDomain = await productRepository.DeleteProductAsync(id);
                if (productDomain == null)
                {
                    return NotFound(new ResponseDto()

                    {
                        Result = productDomain,
                        isSuccess =false,
                        errorMessage="Not Found"
                    });
                }
                var result = mapper.Map<ProductDto>(productDomain);
                return Ok(new ResponseDto()
                {
                    Result = result,
                    isSuccess = true,
                    errorMessage = null
                });
            }
            catch (Exception e) 
            {
                return BadRequest(new ResponseDto()
                {
                    Result = null,
                    isSuccess = false,
                    errorMessage = e.Message
                });
            }
            
        }
    }
}
