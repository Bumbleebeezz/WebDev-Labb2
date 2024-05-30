using Azure;
using Newtonsoft.Json;
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

    public async Task<IEnumerable<CustomerDTO>> GetAllCustomers()
    {
        var response = await _httpClient.GetAsync("api/customers/");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<CustomerDTO>();
        }

        var result = await response.Content.ReadFromJsonAsync<List<CustomerDTO>>();
        return result ?? Enumerable.Empty<CustomerDTO>();
    }

    public async Task<CustomerDTO?> GetCustomerById(int id)
    {
        var response = await _httpClient.GetAsync($"api/customers/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<CustomerDTO>(result);
            return customer;
        }
        else
        {
            return null;
        }
    }

    public async Task<CustomerDTO?> GetCustomerByEmail(string email)
    {
        var response = await _httpClient.GetAsync($"api/Customer/{email}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var result = await response.Content.ReadAsStringAsync();
        var customer = JsonConvert.DeserializeObject<CustomerDTO>(result);
        return customer;
    }

    public async Task AddCustomer(CustomerDTO newCustomer)
    {
        throw new NotImplementedException();

        //var respons = await _httpClient.PostAsJsonAsync($"api/customers/", newCustomer);
        //if (!respons.IsSuccessStatusCode)
        //{
        //    return;
        //}
        
        //return;
    }

    public async Task DeleteCustomer(int id)
    {
        var respons = await _httpClient.GetAsync($"api/customers/{id}");
        if (!respons.IsSuccessStatusCode)
        {
            return;
        }
        var result = await respons.Content.ReadAsStringAsync();
        _httpClient.DeleteAsync(result);
    }
}