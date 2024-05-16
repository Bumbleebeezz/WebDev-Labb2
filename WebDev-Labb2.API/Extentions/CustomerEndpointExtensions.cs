using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.DataAccess.Repositorys;

namespace WebDev_Labb2.API.Extentions;

public static class CustomerEndpointExtensions
{
    public static WebApplication MapCustomerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/customers");

        // "/customers"	GET	 NONE	Customer[]	200, 404
        group.MapGet("/", GetAllCustomers);
        // "/customers/{email}"	GET	 string Email	Customer	200, 404
        group.MapGet("/{email}", GetCustomerByEmail);
        // "/customers"	POST	Customer	NONE	200, 400
        group.MapPost("/", AddCustomer);
        // "/customers/{id}"	PATCH	int ID, ???	NONE	200, 400, 404
        group.MapPatch("/{id}", UpdateCustomer);
        // "/customers/{id}"	DELETE	 int ID	 NONE	200, 404
        group.MapDelete("/{id}", RemoveCustomer);

        return app;
    }

    // "/customers"	GET	 NONE	Customer[]	200, 404
    private static async Task<IResult> GetAllCustomers(CustomerRepository repo)
    {
        var allCustomers = await repo.GetAllCustomers();
        if (allCustomers == null)
        {
            return Results.BadRequest("No customers found");
        }
        return Results.Ok(allCustomers);
    }

    // "/customers/{email}"	GET	 string Email	Customer	200, 404
    private static async Task<IResult> GetCustomerByEmail(CustomerRepository repo, string email)
    {
        var allCustomers = await repo.GetAllCustomers();
        var customerWithEmail = allCustomers.Where(c => c.Email.Equals(email));
        if (customerWithEmail is null || customerWithEmail.Count() <= 0)
        {
            return Results.BadRequest($"No customer found with email: {email}");
        }

        return Results.Ok(customerWithEmail);
    }

    // "/customers"	POST	Customer	NONE	200, 400
    private static void AddCustomer(CustomerRepository repo, Customer newCustomer)
    {
        repo.AddCustomer(newCustomer);
    }

    // "/customers/{id}"	PATCH	int ID, ???	NONE	200, 400, 404
    private static async Task<IResult> UpdateCustomer(CustomerRepository repo, int id, string newLastname,
        string newAddress, string newEmail, string newPhone)
    {
        var excistingCustomer = await repo.GetCustomerById(id);
        if (excistingCustomer is null)
        {
            return Results.BadRequest($"Customer with id {id} already excists");
        }

        await repo.UpdateCustomerLastname(id, newLastname);
        await repo.UpdateCustomerAddress(id, newAddress);
        await repo.UpdateCustomerEmail(id, newEmail);
        await repo.UpdateCustomerPhone(id, newPhone);
        return Results.Ok("Customer updated");
    }

    // "/customers/{id}"	DELETE	 int ID	 NONE	200, 404
    private static async Task<IResult> RemoveCustomer(CustomerRepository repo, int id)
    {
        var excistingCustomer = await repo.GetCustomerById(id);
        if (excistingCustomer is null)
        {
            return Results.BadRequest($"Customer with id {id} does not excists");
        }
        await repo.RemoveCustomer(id);
        return Results.Ok("Customer has been deleted");
    }
}

        
    
