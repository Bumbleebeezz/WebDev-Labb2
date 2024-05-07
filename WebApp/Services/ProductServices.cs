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

    public Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO?> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddProduct(ProductDTO newProduct)
    {
        throw new NotImplementedException();
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