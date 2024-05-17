using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.Shared.Interfaces;

public interface IOrderService<T> where T : class
{
    Task<DbSet<Order>> GetAllOrders();
    Task<Order?> GetOrderById(int id);
    Task AddOrder(T newOrder);
    Task UpdateOrderStatus(int id);
    Task RemoveOrder(int id);

}