﻿using Microsoft.EntityFrameworkCore;
using WebDev_Labb2.DataAccess.Entities;
using WebDev_Labb2.DataAccess.Repositorys;
using WebDev_Labb2.Shared.DTOs;

namespace WebDev_Labb2.API.Extentions;

public static class OrderEndpointExtensions
{
    public static WebApplication MapOrderEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("api/orders");

        // "/orders"	GET	NONE	Order[]	 200, 404
        group.MapGet("/", GetAllOrders);
        // "/orders/{orderID}"	GET	 int ID 	Order	200, 404
        group.MapGet("/{id}", GetAllOrdersById);
        // "/orders"	POST	Order	NONE	200, 400
        group.MapPost("/", AddOrder);
        // "/orders/{id}"	PATCH	int ID	NONE	200, 400, 404
        group.MapPatch("/{id}", ReplaceOrder);
        // "/orders/{id}"	DELETE	int ID	NONE	200, 404
        group.MapDelete("/{id}", RemoveOrder);

        return app;
    }

    private static async Task<IResult> RemoveOrder(OrderRepository repo, int id)
    {
        await repo.RemoveOrder(id);
        return Results.Ok("Order removed");
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