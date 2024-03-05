using WebDev_Labb2.DataAccess;
using WebDev_Labb2.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

#region Product

    // "/products"	GET	NONE	Product[]	200, 404
    app.MapGet("/products", (ProductRepository repo) =>
    {
        return new List<Product>();
    });
    // "/products/{id}"	GET	int ID	Product	200, 404
    app.MapGet("/products/{id}", (ProductRepository repo, int id) =>
    {
        var product = repo.Products.FirstOrDefault(p => p.ProductID == id);
        if (product is null)
        {
            return Results.NotFound($"Product with ID {id} was not found");
        }

        return Results.Ok(product);
    });

#endregion


app.Run();
