namespace WebDev_Labb2.Shared.Interfaces;

public interface ICustomerService<T> where T : class
{
    Task<IEnumerable<T>> GetAllCustomers();
    Task<T?> GetCustomerById(int id);
    Task<T?> GetCustomerByName(string name);
    Task AddCustomer(T newCustomer);
}