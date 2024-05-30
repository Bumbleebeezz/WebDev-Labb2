using Newtonsoft.Json;
using WebDev_Labb2.Shared.DTOs;
using WebDev_Labb2.Shared.Interfaces;

namespace WebApp.Services;

public class ProductServices : IProductService<ProductDTO>
{
    private readonly HttpClient _httpClient;

    public ProductServices(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("RestApi");
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        var response = await _httpClient.GetAsync("api/products/");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<ProductDTO>();
        }

        var result = await response.Content.ReadFromJsonAsync<List<ProductDTO>>();
        return result ?? Enumerable.Empty<ProductDTO>();
    }

    public async Task<ProductDTO?> GetProductById(int id)
    {
        var response = await _httpClient.GetAsync($"api/products/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(result);
            return product;
        }
        else
        {
            return null;
        }
    }

    public async Task<ProductDTO?> GetProductByEAN(int ean)
    {
        var response = await _httpClient.GetAsync($"api/Product/{ean}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDTO>(result);
            return product;
        }
        else
        {
            return null;
        }
    }

    public async Task AddProduct(ProductDTO newProduct)
    {
        var response = await _httpClient.PostAsJsonAsync($"api/products/add", newProduct);

        if (!response.IsSuccessStatusCode)
        {
            return;
        }
        else if (response.IsSuccessStatusCode)
        {
            return;
        }
    }

    public Task UpdateProductPrice(int id, float newPrice)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }
}