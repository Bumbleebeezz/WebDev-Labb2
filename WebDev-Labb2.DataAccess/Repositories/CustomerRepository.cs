using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess.Repositories;

public class CustomerRepository(HandmadeDbContext context)
{
    public async Task AddCustomer(Customer newCustomer)
    {
        await context.Customers.AddAsync(newCustomer);
        await context.SaveChangesAsync();
    }

    public async Task<DbSet<Customer>> GetAllCustomers()
    {
        return context.Customers;
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        return await context.Customers.FindAsync(id);
    }

    public async Task UpdateCustomerLastname(int id, string newLastname)
    {
        var updateCustomer = await context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Lastname = newLastname;
        await context.SaveChangesAsync();
    }
    public async Task UpdateCustomerAddress(int id, string newAdress)
    {
        var updateCustomer = await context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Address = newAdress;
        await context.SaveChangesAsync();
    }

    public async Task UpdateCustomerEmail(int id, string newEmail)
    {
        var updateCustomer = await context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Email = newEmail;
        await context.SaveChangesAsync();
    }

    public async Task UpdateCustomerPhone(int id, string newPhone)
    {
        var updateCustomer = await context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Phone = newPhone;
        await context.SaveChangesAsync();
    }

    public async Task RemoveCustomer(int id)
    {
        var removeCustomer = await context.Customers.FindAsync(id);
        if (removeCustomer is null)
        {
            return;
        }
        context.Remove(removeCustomer);
        await context.SaveChangesAsync();
    }
}