using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
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

    public async Task<IEnumerable<OrderDTO>> GetAllOrders()
    {
        var respons = await _httpClient.GetAsync("api/orders/");
        if (!respons.IsSuccessStatusCode)
        {
            return Enumerable.Empty<OrderDTO>();
        }

        var result = await respons.Content.ReadFromJsonAsync<IEnumerable<OrderDTO>>();
        return result;
    }

    public async Task<OrderDTO?> GetOrderById(int id)
    {
        var respons = await _httpClient.GetAsync($"api/orders/{id}");
        if (!respons.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await respons.Content.ReadAsStringAsync();
        var order = JsonConvert.DeserializeObject<OrderDTO>(result);
        return order;
    }

    public async Task<OrderDTO> AddOrder(OrderDTO neworder)
    {
        var respons = await _httpClient.PostAsJsonAsync($"api/orders/", neworder);
        if (!respons.IsSuccessStatusCode)
        {
            return null;
        }
        else if (respons.IsSuccessStatusCode)
        {
            return neworder;
        }
        return null;
    }

    public async Task UpdateOrderStatus(int id)
    {
        throw new NotImplementedException();

        //var respons = await _httpClient.GetAsync($"api/orders/{id}");
        //if (!respons.IsSuccessStatusCode)
        //{
        //    return;
        //}
        //var result = await respons.Content.ReadAsStringAsync();
    }

    public async Task RemoveOrder(int id)
    {
        var respons = await _httpClient.GetAsync($"api/orders/{id}");
        if (!respons.IsSuccessStatusCode)
        {
            return;
        }
        var result = await respons.Content.ReadAsStringAsync();
        _httpClient.DeleteAsync(result);
    }
}