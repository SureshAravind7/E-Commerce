using E_Commerce.Service.Products.Api.Models.Domain;

namespace E_Commerce.Service.Products.Api.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);

        Task<Product> DeleteProductAsync(int id);
    }
}
