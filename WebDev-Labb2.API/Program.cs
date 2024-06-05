using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.API.Extentions;
using WebDev_Labb2.DataAccess;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.DataAccess.Repositorys;
using WebDev_Labb2.Shared.Interfaces;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("HandmadeDb");
builder.Services.AddDbContext<HandmadeDbContext>(
    options =>
        options.UseSqlServer(connectionString)
);

builder.Services.AddHttpClient("RestApi", client =>
{
    client.BaseAddress = new Uri(System.Environment.GetEnvironmentVariable("apiUrl") ?? "http://localhost:5018");
});


builder.Services.AddScoped<ICustomerService<Customer>, CustomerRepository>();
builder.Services.AddScoped<IOrderService<Order>, OrderRepository>();
builder.Services.AddScoped<IProductService<Product>,ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "API is running!");
app.MapOrderEndpoints();
app.MapProductEndpoints();
app.MapCustomerEndpoints();

app.Run();
