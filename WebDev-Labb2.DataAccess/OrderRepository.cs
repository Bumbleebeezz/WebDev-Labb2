﻿using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess;

public class OrderRepository
{
    private readonly HandmadeDbContext _context;

    public OrderRepository(HandmadeDbContext context)
    {
        _context = context;
    }

    public async Task AddOrder(int customerID, List<int> productsID)
    {
        var customer = await _context.Customers.FindAsync(customerID);
        Order newOrder = new();
        foreach (var product in productsID)
        {
            Product prod = await _context.Products.FindAsync(product);
            newOrder.Products.Add(prod);
        }
        newOrder.CustomerID = customerID;
        newOrder.DateOfOrder = DateTime.Now;
        customer.Orders.Add(newOrder);
        _context.Orders.Add(newOrder);
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

    public async Task UpdateOrderStatus(int id)
    {
        var updateOrder = await _context.Orders.FindAsync(id);
        if (updateOrder is null)
        {
            return;
        }
        updateOrder.DateOfDelivery = DateTime.Now;
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