using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess.Repositorys;

public class OrderRepository(HandmadeDbContext context)
{
    public async Task AddOrder(int customerID, List<int> productsID)
    {
        var customer = await context.Customers.FindAsync(customerID);
        if (customer is null)
        {
            Console.WriteLine();
        }
        Order newOrder = new();

        foreach (var product in productsID)
        {
            Product prod = await context.Products.FindAsync(product);
            newOrder.Products.Add(prod);
        }
        newOrder.CustomerID = customerID;
        newOrder.DateOfOrder = DateTime.Now;
        context.Orders.Add(newOrder);
        await context.SaveChangesAsync();
    }

    public async Task<DbSet<Order>> GetAllOrders()
    {
        return context.Orders;
    }

    public async Task<Order?> GetOrderById(int id)
    {
        var orderById = await context.Orders.FindAsync(id);
        if (orderById is null)
        {
            Console.WriteLine($"Order with id: {id} was not found");
            return null;
        }
        return orderById;
    }

    public async Task UpdateOrderStatus(int id)
    {
        var updateOrder = await context.Orders.FindAsync(id);
        if (updateOrder is null)
        {
            Console.WriteLine($"Order with id: {id} was not found");
            return;
        }
        updateOrder.OrderShipped = true;
        await context.SaveChangesAsync();
    }

    public async Task RemoveOrder(int id)
    {
        var removeOrder = await context.Orders.FindAsync(id);
        if (removeOrder is null)
        {
            Console.WriteLine($"Order with id: {id} was not found");
            return;
        }
        context.Remove(removeOrder);
        await context.SaveChangesAsync();
    }
}