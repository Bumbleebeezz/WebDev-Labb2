using WebDev_Labb2.DataAccess;
using WebDev_Labb2.Shared.DTOs;

namespace WebDev_Labb2.API.Extentions;

public static class OrderEndpointExtensions
{
    public static WebApplication MapOrderEndpoints(this WebApplication app)
    {
        // "/orders"	GET	NONE	Order[]	 200, 404
        app.MapGet("/orders", async (OrderRepository repo) =>
        {
            return await repo.GetAllOrders();
        });
        // "/orders/{orderID}"	GET	 int ID 	Order	200, 404
        app.MapGet("/orders/{id:int}", async (OrderRepository repo, int id) =>
        {
            var order = await repo.GetOrderById(id);
            if (order is null)
            {
                return Results.NotFound($"Order with ID {id} was not found");
            }
            return Results.Ok(order);
        });
        // "/orders"	POST	Order	NONE	200, 400
        app.MapPost("/orders", async (OrderRepository repo, OrderDTO dto) =>
        {
            await repo.AddOrder(dto.CustomerID, dto.Products);
            return Results.Ok("Order created");
        });
        // "/orders/{id}"	PATCH	int ID	NONE	200, 400, 404
        app.MapPatch("/orders/{id}", async (OrderRepository repo, int id) =>
        {
            var existingOrder = await repo.GetOrderById(id);
            if (existingOrder is null)
            {
                return Results.BadRequest($"Order with id {id} does not excist");
            }
            await repo.UpdateOrderStatus(id);
            return Results.Ok("Order updated");
        });

        // "/orders/{id}"	DELETE	int ID	NONE	200, 404
        app.MapDelete("/orders/{id}", async (OrderRepository repo, int id) =>
        {
            await repo.RemoveOrder(id);
        });

        return app;
    }
}