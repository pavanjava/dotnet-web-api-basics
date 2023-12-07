using Microsoft.AspNetCore.Mvc;
using orders.models;
using orders.services;

namespace orders.controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrdersController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public List<Order> GetAllOrders()
    {
        return orderService.GetAll();
    }

    [HttpPost]
    public IActionResult CreateOrders([FromBody] Order order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        order.OrderDate = DateTime.Now;
        return Ok(orderService.Create(order));
    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(string id)
    {
        Order order = orderService.GetById(id);
        if (order != null)
        {
            return Ok(order);
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrderById(string id, [FromBody] Order order)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var modifiedCount = orderService.UpdateById(id, order);
        var response = new Dictionary<string, long> { { "updatedCount", modifiedCount } };

        return Ok(response);
    }

    [HttpDelete]
    public string DeleteOrderById([FromQuery] string id)
    {
        return $"Delete orders By Id: {id}";
    }
}