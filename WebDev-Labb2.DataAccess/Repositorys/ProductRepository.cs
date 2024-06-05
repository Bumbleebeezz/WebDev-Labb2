﻿using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.Shared.Interfaces;


namespace WebDev_Labb2.DataAccess.Repositorys;

public class ProductRepository(HandmadeDbContext context) : IProductService<Product>
{
    public async Task AddProduct(Product newProduct)
    {
        await context.Products.AddAsync(newProduct);
        await context.SaveChangesAsync();
    }

    public Task UpdateProductPrice(int id, float newPrice)
    {
        throw new NotImplementedException();
    }

    public async Task<DbSet<Product>> GetAllProducts()
    {
        return context.Products;
    }

    public async Task<Product?> GetProductByEAN(int ean)
    {
        return await context.Products.FindAsync(ean);
    }

    Task<IEnumerable<Product>> IProductService<Product>.GetAllProducts()
    {
        throw new NotImplementedException();
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

    public Task DeleteProduct(int id)
    {
        throw new NotImplementedException();
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