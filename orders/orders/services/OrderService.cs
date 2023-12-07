using MongoDB.Driver;
using orders.models;

namespace orders.services;

public class OrderService : IOrderService
{
    private readonly IMongoCollection<Order> _orderCollection;

    public OrderService(IOrderStoreDatabaseSettings orderStoreDatabaseSettings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(orderStoreDatabaseSettings.DatabaseName);
         _orderCollection = database.GetCollection<Order>(orderStoreDatabaseSettings.CollectionName);
    }
    
    public List<Order> GetAll()
    {
        return _orderCollection.Find(order => true).ToList();
    }

    public Order GetById(string id)
    {
        return _orderCollection.Find(order => order.Id != null && order.Id.Equals(id)).FirstOrDefault();
    }

    public Order Create(Order order)
    {
        _orderCollection.InsertOne(order);
        return order;
    }

    public long UpdateById(string id, Order order)
    {
        return _orderCollection.ReplaceOne(order1 => order1.Id != null && order1.Id.Equals(id), order).ModifiedCount;
    }

    public long DeleteById(string id)
    {
        return _orderCollection.DeleteOne(order => order.Id != null && order.Id.Equals(id)).DeletedCount;
    }
}