namespace WebDev_Labb2.Shared.Interfaces;

public interface IOrderService<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrders();
    Task<T?> GetOrderById(int id);
    Task AddOrder(T newOrder);
    Task<IEnumerable<T>> GetOrderByName(string name);
    Task RemoveOrder(int id);

}