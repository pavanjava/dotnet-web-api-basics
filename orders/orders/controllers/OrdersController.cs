using Microsoft.AspNetCore.Mvc;

namespace orders.controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class OrdersController: ControllerBase
{
    [HttpGet]
    public string GetAllOrders()
    {
        return "Getting all orders";
    }
    
    [HttpPost]
    public string CreateOrders()
    {
        return "Create orders";
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
    
    [HttpDelete("{id}")]
    public string DeleteOrderById(int id)
    {
        return $"Delete orders By Id: {id}";
    }
    
}