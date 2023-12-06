using Microsoft.AspNetCore.Mvc;
using orders.models;

namespace orders.controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public string GetAllOrders()
    {
        return "Getting all orders";
    }

    [HttpPost]
    public IActionResult CreateOrders([FromBody] Order order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        order.Id = Guid.NewGuid().ToString();
        order.OrderDate = DateTime.Now;
        return Ok(order);
    }

    [HttpGet("{id}")]
    public string GetOrderById(int id)
    {
        return $"Getting orders By Id: {id}";
    }

    [HttpPut("{id}")]
    public string UpdateOrderById(int id)
    {
        return $"Update orders By ID: {id}";
    }

    [HttpDelete]
    public string DeleteOrderById([FromQuery] int id)
    {
        return $"Delete orders By Id: {id}";
    }
}