using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess.Repositories;

public class OrderRepository(HandmadeDbContext context)
{
    public async Task AddOrder(int customerID, List<int> productsID)
    {
        var customer = await context.Customers.FindAsync(customerID);
        Order newOrder = new();
        foreach (var product in productsID)
        {
            Product prod = await context.Products.FindAsync(product);
            newOrder.Products.Add(prod);
        }
        newOrder.CustomerID = customerID;
        newOrder.DateOfOrder = DateTime.Now;
        customer.Orders.Add(newOrder);
        context.Orders.Add(newOrder);
        await context.SaveChangesAsync();
    }

    public async Task<DbSet<Order>> GetAllOrders()
    {
        return context.Orders;
    }

    public async Task<Order?> GetOrderById(int id)
    {
        return await context.Orders.FindAsync(id);
    }

    public async Task UpdateOrderStatus(int id)
    {
        var updateOrder = await context.Orders.FindAsync(id);
        if (updateOrder is null)
        {
            return;
        }
        updateOrder.DateOfDelivery = DateTime.Now;
        await context.SaveChangesAsync();
    }

    public async Task RemoveOrder(int id)
    {
        var removeOrder = await context.Orders.FindAsync(id);
        if (removeOrder is null)
        {
            return;
        }
        context.Remove(removeOrder);
        await context.SaveChangesAsync();
    }
}