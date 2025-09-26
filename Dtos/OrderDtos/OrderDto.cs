using RepositoryPattern.Models;

namespace RepositoryPattern.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTimeOffset OrderDate { get; set; }
        public int CustomerId { get; set; }
        public  int ProductId { get; set; }
        public string ShippingAdress { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
    }
}
