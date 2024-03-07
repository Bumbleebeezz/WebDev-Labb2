using Microsoft.EntityFrameworkCore;
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

    public async Task<DbSet<Product>> GetAllProducts()
    {
        return _context.Products;
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product?> GetProductByName(string name)
    {
        return await _context.Products.FindAsync(name);
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

    public async Task RemoveProduct(int id)
    {
        var removeProduct = await _context.Products.FindAsync(id);
        if (removeProduct is null)
        {
            return;
        }
        _context.Remove(removeProduct);
        await _context.SaveChangesAsync();
    }
}