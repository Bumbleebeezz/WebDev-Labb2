using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.Shared.DTOs;

namespace WebDev_Labb2.API.Extentions;

public static class OrderEndpointExtensions
{
    public static WebApplication MapOrderEndpoints(this WebApplication app)
    {
        // "/orders"	GET	NONE	Order[]	 200, 404
        app.MapGet("/orders", GetAllOrders);
        // "/orders/{orderID}"	GET	 int ID 	Order	200, 404
        app.MapGet("/orders/{id:int}", GetAllOrdersById);
        // "/orders"	POST	Order	NONE	200, 400
        app.MapPost("/orders", AddOrder);
        // "/orders/{id}"	PATCH	int ID	NONE	200, 400, 404
        app.MapPatch("/orders/{id}", ReplaceOrder);
        // "/orders/{id}"	DELETE	int ID	NONE	200, 404
        app.MapDelete("/orders/{id}", RemoveOrder);

        return app;
    }

    private static async Task RemoveOrder(OrderRepository repo, int id)
    {
        await repo.RemoveOrder(id);
    }

    private static async Task<IResult> ReplaceOrder(OrderRepository repo, int id)
    {
        var existingOrder = await repo.GetOrderById(id);
        if (existingOrder is null)
        {
            return Results.BadRequest($"Order with id {id} does not excist");
        }

        await repo.UpdateOrderStatus(id);
        return Results.Ok("Order updated");
    }

    private static async Task<IResult> GetAllOrdersById(OrderRepository repo, int id)
    {
        var order = await repo.GetOrderById(id);
        if (order is null)
        {
            return Results.NotFound($"Order with ID {id} was not found");
        }

        return Results.Ok(order);
    }

    private static async Task<DbSet<Order>> GetAllOrders(OrderRepository repo)
    {
        return await repo.GetAllOrders();
    }

    private static void AddOrder(OrderRepository repo, OrderDTO dto)
    {
        repo.AddOrder(dto.CustomerID, dto.Products);
    }
}