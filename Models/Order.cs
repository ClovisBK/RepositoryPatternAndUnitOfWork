namespace RepositoryPattern.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTimeOffset OrderDate { get; set; }
        public int CustomerId { get; set; }
        public int  ProductId { get; set; }
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
        public string ShippingAdress { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Paid,
        Shipped,
        Cancelled
    }
}
