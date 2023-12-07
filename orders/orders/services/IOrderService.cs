using orders.models;

namespace orders.services;

public interface IOrderService
{
    List<Order> GetAll();
    Order GetById(string id);
    Order Create(Order order);
    long UpdateById(string id, Order order);
    long DeleteById(string id);
}