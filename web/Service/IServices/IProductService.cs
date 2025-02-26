using E_Commerce.Web.Models.DTO;
using web.Models.DTO;

namespace web.Service.IServices
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductsByIdAsync(int id);

        Task<ResponseDto?> CreateProductAsync(ProductDto productDto);

        Task<ResponseDto?> UpdateProductAsync(ProductDto productDto);
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}
