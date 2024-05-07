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

    public Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDTO?> GetOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddOrder(OrderDTO newOrder)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderDTO>> GetOrderByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task RemoveOrder(int id)
    {
        throw new NotImplementedException();
    }
}