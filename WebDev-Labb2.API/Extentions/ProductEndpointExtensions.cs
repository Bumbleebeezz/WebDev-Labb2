using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.DataAccess.Repositories;

namespace WebDev_Labb2.API.Extentions;

public static class ProductEndpointExtensions
{
    public static WebApplication MapProductEndpoints(this WebApplication app)
    {
        // "/products"	GET	NONE	Product[]	200, 404
        app.MapGet("/products", async (ProductRepository repo) =>
        {
            return await repo.GetAllProducts();
        });
        // "/products/{id}"	GET	int ID	Product	200, 404
        app.MapGet("/products/{id:int}", async (ProductRepository repo, int id) =>
        {
            var product = repo.GetProductById(id);
            if (product is null)
            {
                return Results.NotFound($"Product with ID {id} was not found");
            }
            return Results.Ok(product);
        });
        // "/products/{name}"	GET	 string Name	Product	200, 404
        app.MapGet("/products/{name}", async (ProductRepository repo, string name) =>
        {
            var product = repo.GetProductByName(name);
            if (product is null)
            {
                return Results.NotFound($"Product with name {name} was not found");
            }
            return Results.Ok(product);
        });
        // "/products"	POST	Product	  NONE	 200, 400
        app.MapPost("/products", async (ProductRepository repo, Product newProduct) =>
        {
            var excistingProduct = await repo.GetProductById(newProduct.ProductID);
            if (excistingProduct is not null)
            {
                return Results.BadRequest($"Product with id {newProduct.ProductID} already excists");
            }
            await repo.AddProduct(newProduct);
            return Results.Ok("Product created");
        });
        // "/products/{id}"	PATCH	int ID,  float Price	NONE	200, 400, 404
        app.MapPatch("/products/{id}", async (ProductRepository repo, int id, float newPrice) =>
        {
            var excistingProduct = await repo.GetProductById(id);
            if (excistingProduct is null)
            {
                return Results.BadRequest($"Product with id {id} was not found");
            }
            await repo.UpdateProductPrice(id, newPrice);
            return Results.Ok("Product has been updated");
        });
        app.MapPatch("/products/{id}", async (ProductRepository repo, int id) =>
        {
            var excistingProduct = await repo.GetProductById(id);
            if (excistingProduct is null)
            {
                return Results.BadRequest($"Product with id {id} was not found");
            }
            await repo.UpdateProductStatus(id);
            return Results.Ok("Product has been updated");
        });
        // "/products/{id}"    DELETE  int ID	NONE	200, 404
        app.MapDelete("/products/{id}", async (ProductRepository repo, int id) =>
        {
            await repo.RemoveProduct(id);
        });

        return app;
    }
}