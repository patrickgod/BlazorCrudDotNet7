using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace BlazorCrudDotNet7.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public ProductService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task CreateProduct(Product product)
        {
            await _http.PostAsJsonAsync("api/product", product);
            _navigationManger.NavigateTo("products");
        }

        public async Task DeleteProduct(int id)
        {
            var result = await _http.DeleteAsync($"api/product/{id}");
            _navigationManger.NavigateTo("products");
        }

        public async Task<Product?> GetProductById(int id)
        {
            var result = await _http.GetAsync($"api/product/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Product>();
            }
            return null;
        }

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Product>>("api/product");
            if (result is not null)
                Products = result;
        }

        public async Task UpdateProduct(int id, Product product)
        {
            await _http.PutAsJsonAsync($"api/product/{id}", product);
            _navigationManger.NavigateTo("products");
        }
    }
}
