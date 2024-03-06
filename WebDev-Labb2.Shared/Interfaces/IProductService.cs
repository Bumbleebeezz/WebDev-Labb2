namespace WebDev_Labb2.Shared.Interfaces;

public interface IProductService<T> where T : class
{
    Task<IEnumerable<T>> GetAllProducts();
    Task<T?> GetProductById(int id);
    Task AddProduct(T newProduct);
    Task UpdateProductPrice(int id, float newPrice);
    Task DeleteProduct(int id);
}