namespace orders.models;

public class OrderStoreDatabaseSettings : IOrderStoreDatabaseSettings
{
    public string CollectionName { get; set; } = String.Empty;
    public string ConnectionName { get; set; } = String.Empty;
    public string DatabaseName { get; set; } = String.Empty;
}