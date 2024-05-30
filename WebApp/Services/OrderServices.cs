using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.Shared.DTOs;
using WebDev_Labb2.Shared.Interfaces;

namespace WebApp.Services;

public class OrderServices : IOrderService<OrderDTO>
{
    private readonly HttpClient _httpClient;

    public OrderServices(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("RestApi");
    }

    public Task<DbSet<Order>> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddOrder(OrderDTO newOrder)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderStatus(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveOrder(int id)
    {
        throw new NotImplementedException();
    }
}