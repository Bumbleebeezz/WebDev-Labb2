using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.DataAccess.Repositorys;

namespace WebDev_Labb2.API.Extentions;

public static class ProductEndpointExtensions
{
    public static WebApplication MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/products");

        // "/products"	GET	NONE	Product[]	200, 404
        group.MapGet("/", GetAllProducts);
        // "/products/{id}"	GET	int ID	Product	200, 404
        group.MapGet("/{ean}", GetProductByEAN);
        // "/products"	POST	Product	  NONE	 200, 400
        group.MapPost("/", AddProduct);
        // "/products/{id}"	PATCH	int ID,  float Price	NONE	200, 400, 404
        group.MapPatch("/{id}", UpdateProduct);
        // "/products/{id}"    DELETE  int ID	NONE	200, 404
        group.MapDelete("/{id}", DeleteProduct);

        return app;
    }

    // "/products"	GET	NONE	Product[]	200, 404
    private static async Task<DbSet<Product>> GetAllProducts(ProductRepository repo)
    {
        return await repo.GetAllProducts();
    }

    // "/products/{id}"	GET	int ID	Product	200, 404
    private static async Task<IResult> GetProductByEAN(ProductRepository repo, int ean)
    {
        var product = repo.GetProductByEAN(ean);
        if (product is null)
        {
            return Results.NotFound($"Product with EAN {ean} was not found");
        }

        return Results.Ok(product);
    }

    // "/products"	POST	Product	  NONE	 200, 400
    private static async Task<IResult> AddProduct(ProductRepository repo, Product newProduct)
    {
        var excistingProduct = await repo.GetProductById(newProduct.ProductID);
        if (excistingProduct is not null)
        {
            return Results.BadRequest($"Product with id {newProduct.ProductID} already excists");
        }

        await repo.AddProduct(newProduct);
        return Results.Ok("Product created");
    }

    // "/products/{id}"	PATCH	int ID,  float Price	NONE	200, 400, 404
    private static async Task<IResult> UpdateProduct(ProductRepository repo, int id, float newPrice)
    {
        var excistingProduct = await repo.GetProductById(id);
        if (excistingProduct is null)
        {
            return Results.BadRequest($"Product with id {id} was not found");
        }

        await repo.UpdateProductStatus(id);
        await repo.UpdateProductPrice(id, newPrice);
        return Results.Ok("Product has been updated");
    }

    // "/products/{id}"    DELETE  int ID	NONE	200, 404
    private static async Task<IResult> DeleteProduct(ProductRepository repo, int id)
    {
        await repo.RemoveProduct(id);
        return Results.Ok("Product has been removed");
    }
}

        
    
