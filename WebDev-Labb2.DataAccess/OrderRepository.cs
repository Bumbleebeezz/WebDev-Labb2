using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess;

public class OrderRepository
{
    private readonly HandmadeDbContext _context;

    public OrderRepository(HandmadeDbContext context)
    {
        _context = context;
    }

    public async Task AddOrder(OrderDTO newOrder)
    {

        await _context.Orders.AddAsync(newOrder);
        await _context.SaveChangesAsync();
    }

    public async Task<DbSet<Order>> GetAllOrders()
    {
        return _context.Orders;
    }

    public async Task<Order?> GetOrderById(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task UpdateOrderStatus(int id, DateTime dateOfDelivery)
    {
        var updateOrder = await _context.Orders.FindAsync(id);
        if (updateOrder is null)
        {
            return;
        }
        updateOrder.DateOfDelivery = dateOfDelivery;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveOrder(int id)
    {
        var removeOrder = await _context.Orders.FindAsync(id);
        if (removeOrder is null)
        {
            return;
        }
        _context.Remove(removeOrder);
        await _context.SaveChangesAsync();
    }
}