using BlazorCrudDotNet7.Server.Services.ProductService;
using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<Product?> GetProductById(int id)
        {
            return await _productService.GetProductById(id);
        }

        [HttpPost]
        public async Task<Product?> CreateProduct(Product product)
        {
            return await _productService.CreateProduct(product);
        }

        [HttpPut("{id}")]
        public async Task<Product?> UpdateProduct(int id, Product product)
        {
            return await _productService.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);
        }
    }
}
