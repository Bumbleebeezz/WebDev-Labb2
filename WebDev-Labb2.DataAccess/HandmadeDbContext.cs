using Microsoft.EntityFrameworkCore;
using System;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess;

public class HandmadeDbContext :DbContext 
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public HandmadeDbContext(DbContextOptions options) : base(options)
    {
        
    }
}