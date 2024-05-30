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
        // "/products/{ean}"	GET	int ID	Product	200, 404
        group.MapGet("/{ean}", GetProductByEAN);
        // "/products"	POST	Product	  NONE	 200, 400
        group.MapPost("/", AddProduct);
        // "/products/{id}"	PATCH	int ID,  float Price	NONE	200, 400, 404
        group.MapPatch("/{id}", UpdateProductStatus);
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
    private static void AddProduct(ProductRepository repo, Product newProduct)
    {
        repo.AddProduct(newProduct);
    }

    // "/products/{id}"	PATCH	int ID,  float Price	NONE	200, 400, 404
    private static async Task<IResult> UpdateProductStatus(ProductRepository repo, int id)
    {
        var excistingProduct = await repo.GetProductById(id);
        if (excistingProduct is null)
        {
            return Results.BadRequest($"Product with id {id} was not found");
        }

        await repo.UpdateProductStatus(id);
        return Results.Ok("Product has been updated");
    }

    // "/products/{id}"    DELETE  int ID	NONE	200, 404
    private static async Task<IResult> DeleteProduct(ProductRepository repo, int id)
    {
        await repo.RemoveProduct(id);
        return Results.Ok("Product has been removed");
    }
}

        
    
