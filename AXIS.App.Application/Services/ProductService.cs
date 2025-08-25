using AXIS.App.Core.Entities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AXIS.App.Application.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Product>> GetProductsAsync(string token)
    {
        // No agregar el header Authorization si el token está vacío
        if (!string.IsNullOrWhiteSpace(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        else
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        var response = await _httpClient.GetAsync("http://127.0.0.1:8000/productos/");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var products = JsonSerializer.Deserialize<List<Product>>(json, _jsonOptions);
        return products ?? [];
    }
}


