using Microsoft.AspNetCore.Mvc;
using orders.models;

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
    public Object CreateOrders([FromBody] Order order, [FromHeader(Name = "api-key")] string apiKey)
    {
        if (apiKey.StartsWith("web-api-"))
        {
            return order;
        }
        else
        {
            return new Dictionary<string, Exception>() { {"message", new Exception("Authorization Error, api key should start with web-api-*")} };
        }
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
    public string DeleteOrderById([FromQuery]int id)
    {
        return $"Delete orders By Id: {id}";
    }
    
}