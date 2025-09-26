using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;
using RepositoryPattern.Models;

namespace RepositoryPattern.Dtos.OrderDtos
{
    public class CreateOrderDto
    {
        [Required]
        [StringLength(20)]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set;}
        
        [Required]
        [StringLength(60)]
        public string ShippingAdress { get; set; } = string.Empty;

        [Required]
        public OrderStatus Status { get; set; }
    }
}
