using BlazorCrudDotNet7.Shared;

namespace BlazorCrudDotNet7.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(int productId);
        Task<Product> CreateProduct(Product product);
        Task<Product?> UpdateProduct(int productId, Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
