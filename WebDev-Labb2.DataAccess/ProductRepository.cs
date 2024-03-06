using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess;

public class ProductRepository
{
    private readonly HandmadeDbContext _context;

    public ProductRepository(HandmadeDbContext context)
    {
        _context = context;
    }

    public async Task AddProduct(Product newProduct)
    {
        await _context.Products.AddAsync(newProduct);
        await _context.SaveChangesAsync();
    }

    public async Task<Enumerable<Product>> GetAllProducts()
    {
        return _context.Products;
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product?> GetProductByCategory(string category)
    {

        return await _context.Products.FindAsync(category);
    }

    public async Task UpdateProductPrice(int id, float price)
    {
        var updateProduct = await _context.Products.FindAsync(id);
        if (updateProduct is null)
        {
            return;
        }
        updateProduct.Price = price;
        await _context.SaveChangesAsync();
    }
}