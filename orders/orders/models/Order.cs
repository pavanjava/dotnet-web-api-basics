using System.ComponentModel.DataAnnotations;

namespace orders.models;

public class Order
{
    public string? Id { set; get; }

    [Required] public string CustomerName { set; get; }
    [Required][StringLength(10, MinimumLength = 10, ErrorMessage = "Not a valid mobile number")] public string CustomerMobileNumber { set; get; }
    public DateTime? OrderDate { set; get; }

    [Required] public string ShippingAddress { set; get; }

    [Required] public string BillingAddress { set; get; }

    public List<OrderLineItem> LineItems { get; set; }

    public class OrderLineItem
    {
        [Required] public string ProductCode { get; set; }

        [Required] [Range(1, int.MaxValue)] public int Quantity { get; set; }

        [Required] [Range(0, double.MaxValue)] public double UnitPrice { get; set; }
    }
}