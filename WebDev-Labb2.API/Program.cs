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
// "/products/{id}"    DELETE  int ID	NONE	200, 404
app.MapDelete("/products/{id}", async (ProductRepository repo, int id) =>
{
    await repo.RemoveProduct(id);
});

#endregion

#region Customer

// "/customers"	GET	 NONE	Customer[]	200, 404
app.MapGet("/customers", async (CustomerRepository repo) =>
{
    return await repo.GetAllCustomers();
});
// "/customers/{id}"	GET 	int ID	Customer	200, 404
app.MapGet("/customers/{id:int}", async (CustomerRepository repo, int id) =>
{
    var customer = repo.GetCustomerById(id);
    if (customer is null)
    {
        return Results.NotFound($"Customer with ID {id} was not found");
    }
    return Results.Ok(customer);
});
// "/customers/{name}"	GET	 string Name	Customer	200, 404
app.MapGet("/customers/{name}", async (CustomerRepository repo, string name) =>
{
    var allCustomers = await repo.GetAllCustomers();
    var customerWithName = allCustomers.Where(c => c.Name.Equals(name));
    if (customerWithName is null || customerWithName.Count() <= 0)
    {
        return Results.NotFound($"No customer found with name: {name}");
    }
    return Results.Ok(customerWithName);
});
// "/customers"	POST	Customer	NONE	200, 400
app.MapPost("/customers", async (CustomerRepository repo, Customer newCustomer) =>
{
    var excistingCustomer = await repo.GetCustomerById(newCustomer.CustomerID);
    if (excistingCustomer is not null)
    {
        return Results.BadRequest($"Customer with id {newCustomer.CustomerID} already excists");
    }
    await repo.AddCustomer(newCustomer);
    return Results.Ok("Customer created");
});
// "/customers/{id}"	PATCH	int ID, ???	NONE	200, 400, 404

// "/customers/{id}"	DELETE	 int ID	 NONE	200, 404
app.MapDelete("/customers/{id}", async (CustomerRepository repo, int id) =>
{
    await repo.RemoveCustomer(id);
});

#endregion

#region Order

// "/orders"	GET	NONE	Order[]	 200, 404
app.MapGet("/orders", async (OrderRepository repo) =>
{
    return await repo.GetAllOrders();
});
// "/orders/{orderID}"	GET	 int ID 	Order	200, 404
app.MapGet("/orders/{id:int}", async (OrderRepository repo, int id) =>
{
    var order = repo.GetOrderById(id);
    if (order is null)
    {
        return Results.NotFound($"Order with ID {id} was not found");
    }
    return Results.Ok(order);
});
// "/orders"	POST	Order	NONE	200, 400
app.MapPost("/orders", async (OrderRepository repo, Order newOrder) =>
{
    var excistingOrder = await repo.GetOrderById(newOrder.OrderID);
    if (excistingOrder is not null)
    {
        return Results.BadRequest($"Order with id {newOrder.OrderID} already excists");
    }
    await repo.AddOrder(newOrder);
    return Results.Ok("Order created");
});
// "/orders/{id}"	PATCH	int ID, ???	NONE	200, 400, 404

// "/orders/{id}"	DELETE	int ID	NONE	200, 404
app.MapDelete("/orders/{id}", async (OrderRepository repo, int id) =>
{
    await repo.RemoveOrder(id);
});

#endregion

app.Run();
