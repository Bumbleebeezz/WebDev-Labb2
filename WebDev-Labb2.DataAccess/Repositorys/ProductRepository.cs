using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess.Repositorys;

public class ProductRepository(HandmadeDbContext context)
{
    public async Task AddProduct(Product newProduct)
    {
        await context.Products.AddAsync(newProduct);
        await context.SaveChangesAsync();
    }

    public async Task<DbSet<Product>> GetAllProducts()
    {
        return context.Products;
    }

    public async Task<Product?> GetProductByEAN(int ean)
    {
        return await context.Products.FindAsync(ean);
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task UpdateProductStatus(int id)
    {
        var updateProduct = await context.Products.FindAsync(id);
        if (updateProduct is null)
        {
            return;
        }
        updateProduct.Discontinued = true;
        await context.SaveChangesAsync();
    }

    public async Task RemoveProduct(int id)
    {
        var removeProduct = await context.Products.FindAsync(id);
        if (removeProduct is null)
        {
            return;
        }
        context.Remove(removeProduct);
        await context.SaveChangesAsync();
    }
}