using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.Shared.DTOs;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("HandmadeDb");
builder.Services.AddDbContext<HandmadeDbContext>(
    options =>
        options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductRepository>();

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
// "/products/{name}"	GET	 string Name	Product	200, 404
app.MapGet("/products/{category}", async (ProductRepository repo, string name) =>
{
    var product = repo.GetProductByName(name);
    if (product is null)
    {
        return Results.NotFound($"Product with name {name} was not found");
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
// "/customers/{email}"	GET	 string Email	Customer	200, 404
app.MapGet("/customers/{email}", async (CustomerRepository repo, string email) =>
{
    var allCustomers = await repo.GetAllCustomers();
    var customerWithEmail = allCustomers.Where(c => c.Email.Equals(email));
    if (customerWithEmail is null || customerWithEmail.Count() <= 0)
    {
        return Results.NotFound($"No customer found with email: {email}");
    }
    return Results.Ok(customerWithEmail);
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
app.MapPatch("/customers/{id}", async (CustomerRepository repo, int id, string newLastname, string newAddress, string newEmail, string newPhone) =>
{
    var excistingCustomer = await repo.GetCustomerById(id);
    if (excistingCustomer is not null)
    {
        return Results.BadRequest($"Customer with id {id} already excists");
    }

    await repo.UpdateCustomerLastname(id, newLastname);
    await repo.UpdateCustomerAddress(id, newAddress);
    await repo.UpdateCustomerEmail(id, newEmail);
    await repo.UpdateCustomerPhone(id, newPhone);
    return Results.Ok("Customer updated");
});
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
app.MapPost("/orders", async (OrderRepository repo,int customerID, List<int> products) =>
{
    await repo.AddOrder(customerID, products);
    return Results.Ok("Order created");
});
// "/orders/{id}"	PATCH	int ID,bool DateOfDelivery	NONE	200, 400, 404
app.MapPatch("/orders/{id}", async (OrderRepository repo, int id) =>
{
    var existingOrder = repo.GetOrderById(id);
    if (existingOrder is null)
    {
        return Results.BadRequest($"Order with id {id} does not excist");
    }
    await repo.UpdateOrderStatus(id);
    return Results.Ok("Order updated");
});

// "/orders/{id}"	DELETE	int ID	NONE	200, 404
app.MapDelete("/orders/{id}", async (OrderRepository repo, int id) =>
{
    await repo.RemoveOrder(id);
});

#endregion

app.Run();
