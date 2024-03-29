﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;

namespace WebDev_Labb2.DataAccess;

public class CustomerRepository
{
    private readonly HandmadeDbContext _context;

    public CustomerRepository(HandmadeDbContext context)
    {
        _context = context;
    }

    public async Task AddCustomer(Customer newCustomer)
    {
        await _context.Customers.AddAsync(newCustomer);
        await _context.SaveChangesAsync();
    }

    public async Task<DbSet<Customer>> GetAllCustomers()
    {
        return _context.Customers;
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task UpdateCustomerLastname(int id, string newLastname)
    {
        var updateCustomer = await _context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Lastname = newLastname;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerAddress(int id, string newAdress)
    {
        var updateCustomer = await _context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Address = newAdress;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomerEmail(int id, string newEmail)
    {
        var updateCustomer = await _context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Email = newEmail;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCustomerPhone(int id, string newPhone)
    {
        var updateCustomer = await _context.Customers.FindAsync(id);
        if (updateCustomer is null)
        {
            return;
        }
        updateCustomer.Phone = newPhone;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveCustomer(int id)
    {
        var removeCustomer = await _context.Customers.FindAsync(id);
        if (removeCustomer is null)
        {
            return;
        }
        _context.Remove(removeCustomer);
        await _context.SaveChangesAsync();
    }
}