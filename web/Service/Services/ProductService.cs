using E_Commerce.Web.Models.DTO;
using web.Models.DTO;
using web.Service.IServices;
using web.Utility;
using static System.Net.WebRequestMethods;

namespace web.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseService baseService;
        public ProductService(IBaseService baseService)
        {
            this.baseService = baseService;
        }
        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.POST,
                Url = SD.ProductApiBase + "/api/Products",
                Data =productDto

            });
        }

        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.DELETE,
                Url = SD.ProductApiBase + "/api/Products/"+id

            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.GET,
                Url = SD.ProductApiBase + "/api/Products/"

            });
        }

        public async Task<ResponseDto?> GetProductsByIdAsync(int id)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.GET,
                Url = SD.ProductApiBase + "/api/Products/"+id

            });
        }

        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await baseService.sendRequestAsync(new RequestDto()
            {
                Apitype = SD.ApiTypes.PUT,
                Url = SD.ProductApiBase + "/api/Products",
                Data = productDto


            });
        }
    }
}
