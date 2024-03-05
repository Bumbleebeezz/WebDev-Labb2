using WebDev_Labb2.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<OrderRepository>();
builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
