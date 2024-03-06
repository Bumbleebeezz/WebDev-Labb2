namespace WebDev_Labb2.Shared.Interfaces;

public interface IOrderService<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrders();
    Task<T?> GetOrderById(int id);
}