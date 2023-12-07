using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace orders.models;

[BsonIgnoreExtraElements]
public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { set; get; }

    [BsonElement("customerName")]
    [Required]
    public string CustomerName { set; get; }

    [BsonElement("mobileNumber")]
    [Required]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Not a valid mobile number")]
    public string CustomerMobileNumber { set; get; }

    [BsonElement("orderDate")] public DateTime? OrderDate { set; get; }

    [BsonElement("shippingAddr")]
    [Required]
    public string ShippingAddress { set; get; }

    [BsonElement("billingAddr")]
    [Required]
    public string BillingAddress { set; get; }

    [BsonElement("items")] public List<OrderLineItem> LineItems { get; set; }

    public class OrderLineItem
    {
        [BsonElement("productCode")]
        [Required]
        public string ProductCode { get; set; }

        [BsonElement("quantity")]
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [BsonElement("unitPrice")]
        [Required]
        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }
    }
}