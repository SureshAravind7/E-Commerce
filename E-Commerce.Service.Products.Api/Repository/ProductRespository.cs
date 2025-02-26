using E_Commerce.Service.Products.Api.Data;
using E_Commerce.Service.Products.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Service.Products.Api.Repository
{
    public class ProductRespository : IProductRepository
    {
        private readonly ProductDbContext dbContext;
        public ProductRespository(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> CreateProductAsync(Product product)
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var productDomain = dbContext.Products.FirstOrDefault(x=>x.ProductId == id);
            if (productDomain != null)
            {
                dbContext.Products.Remove(productDomain);
                await dbContext.SaveChangesAsync();
                return productDomain;
            }
            return null;

        }

        public async Task<List<Product>> GetAllProductAsync()
        {
           var productDomain =  dbContext.Products.AsQueryable();
            return await productDomain.OrderBy(x => x.ProductId).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDomain =await dbContext.Products.FirstOrDefaultAsync(x=>x.ProductId == id);
            return  productDomain;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            dbContext.Products.Update(product);
            await  dbContext.SaveChangesAsync();
            return product;
        }
    }
}
