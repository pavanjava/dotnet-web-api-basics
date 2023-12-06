namespace orders.models;

public class Order
{
    public int id { set; get; }
    public DateTime orderDate { set; get; }
    public string shippingAddress { set; get; }
    public string billingAddress { set; get; }
}