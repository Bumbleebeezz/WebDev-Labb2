using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.DataAccess;

namespace WebDev_Labb2.API.Extentions;

public static class CustomerEndpointExtensions
{
    public static WebApplication MapCustomerEndpoints(this WebApplication app)
    {
        // "/customers"	GET	 NONE	Customer[]	200, 404
        app.MapGet("/customers", async (CustomerRepository repo) =>
        {
            return await repo.GetAllCustomers();
        });
        // "/customers/{email}"	GET	 string Email	Customer	200, 404
        app.MapGet("/customers/{email}", async (CustomerRepository repo, string email) =>
        {
            var allCustomers = await repo.GetAllCustomers();
            var customerWithEmail = allCustomers.Where(c => c.Email.Equals(email));
            if (customerWithEmail is null || customerWithEmail.Count() <= 0)
            {
                return Results.NotFound($"No customer found with email: {email}");
            }
            return Results.Ok(customerWithEmail);
        });
        // "/customers"	POST	Customer	NONE	200, 400
        app.MapPost("/customers", async (CustomerRepository repo, Customer newCustomer) =>
        {
            var excistingCustomer = await repo.GetCustomerById(newCustomer.CustomerID);
            if (excistingCustomer is not null)
            {
                return Results.BadRequest($"Customer with id {newCustomer.CustomerID} already excists");
            }
            await repo.AddCustomer(newCustomer);
            return Results.Ok("Customer created");
        });
        // "/customers/{id}"	PATCH	int ID, ???	NONE	200, 400, 404
        app.MapPatch("/customers/{id}", async (CustomerRepository repo, int id, string newLastname, string newAddress, string newEmail, string newPhone) =>
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
        });
        // "/customers/{id}"	DELETE	 int ID	 NONE	200, 404
        app.MapDelete("/customers/{id}", async (CustomerRepository repo, int id) =>
        {
            await repo.RemoveCustomer(id);
        });

        return app;
    }
}