namespace orders.models;

public interface IOrderStoreDatabaseSettings
{
    string CollectionName { get; set; }
    string ConnectionName { get; set; }
    string DatabaseName { get; set; }
}