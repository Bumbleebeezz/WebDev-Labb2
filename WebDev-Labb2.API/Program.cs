using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.API.Extentions;
using WebDev_Labb2.DataAccess;
using WebDev_Labb2.DataAccess.Repositorys;

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

builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "API is running!");
app.MapOrderEndpoints();
app.MapProductEndpoints();
app.MapCustomerEndpoints();

app.Run();
