using WebDev_Labb2.Shared.DTOs;
using WebDev_Labb2.Shared.Interfaces;

namespace WebApp.Services;

public class CustomerServices : ICustomerService<CustomerDTO>
{
    private readonly HttpClient _httpClient;

    public CustomerServices(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("RestApi");
    }

    public Task<IEnumerable<CustomerDTO>> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDTO?> GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerDTO?> GetCustomerByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task AddCustomer(CustomerDTO newCustomer)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }
}