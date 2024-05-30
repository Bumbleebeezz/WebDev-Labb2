using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.Shared.DTOs;

namespace WebDev_Labb2.Shared.Interfaces;

public interface IOrderService<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrders();
    Task<Order?> GetOrderById(int id);
    Task<OrderDTO> AddOrder(T newOrder);
    Task UpdateOrderStatus(int id);
    Task RemoveOrder(int id);

}