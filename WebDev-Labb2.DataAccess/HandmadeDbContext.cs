using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess;

public class HandmadeDbContext :DbContext 
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    public HandmadeDbContext() { }
    public HandmadeDbContext(DbContextOptions<HandmadeDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=MARIACONFIG;Initial Catalog=HandmadeDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
