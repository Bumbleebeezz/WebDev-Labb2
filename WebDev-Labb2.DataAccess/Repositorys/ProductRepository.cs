﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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

    public async Task<Product?> GetProductById(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<Product?> GetProductByName(string name)
    {
        return await context.Products.FindAsync(name);
    }

    public async Task UpdateProductPrice(int id, float price)
    {
        var updateProduct = await context.Products.FindAsync(id);
        if (updateProduct is null)
        {
            return;
        }
        updateProduct.Price = price;
        await context.SaveChangesAsync();
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