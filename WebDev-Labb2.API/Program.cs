using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.API.Extentions;
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

app.MapOrderEndpoints();
app.MapProductEndpoints();
app.MapCustomerEndpoints();

app.Run();
