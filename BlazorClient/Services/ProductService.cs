using System.Net.Http.Json;
using BlazorClient.Models;

namespace BlazorClient.Services;

public class ProductService
{
    private readonly HttpClient _http;
    
    public ProductService(HttpClient http)
    {
        _http = http;
    }
    
    public async Task<List<Product>> GetProductsAsync()
        => await _http.GetFromJsonAsync<List<Product>>("api/products") ?? new();
    
    public async Task CreateProductAsync(Product product)
        => await _http.PostAsJsonAsync("api/products", product);
    
    public async Task UpdateProductAsync(int id, Product product)
        => await _http.PutAsJsonAsync($"api/products/{id}", product);
    
    public async Task DeleteProductAsync(int id)
        => await _http.DeleteAsync($"api/products/{id}");
}