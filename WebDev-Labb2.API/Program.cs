using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess;
using WebDev_Labb2.DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("HandmadeDb");
builder.Services.AddDbContext<HandmadeDbContext>(
    options =>
        options.UseSqlServer(connectionString)
);

builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

#region Product

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
// "/products/{Category}"	GET 	string Category 	Product	200, 404
app.MapGet("/products/{category}", async (ProductRepository repo, string category) =>
{
    var allProducts = await repo.GetAllProducts();
    var productOfType = allProducts.Where(p => p.Category.Equals(category));
    if (productOfType is null || productOfType.Count() <= 0)
    {
        return Results.NotFound($"No products found in category: {category}");
    }
    return Results.Ok(productOfType);
});
// "/products"	POST	Product	  NONE	 200, 400
app.MapPost("/products", (ProductRepository repo, Product newProduct) => 
{
    if (repo.Products.Any(p => p.ProductID == newProduct.ProductID))
    {
        return Results.BadRequest($"Product with id {newProduct.ProductID} already excists");
    }
    repo.Products.Add(newProduct);
    return Results.Ok("Product created");
});

#endregion


app.Run();
