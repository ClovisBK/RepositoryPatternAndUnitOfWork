using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        [Required]
        [Range(0, 9999999.99)]
        [RegularExpression(@"^\d+(\.\d{1,3})?$", ErrorMessage = "Price can have max 3 decimal places")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(40)]
        public string StockCode { get; set; } = string.Empty;
    }
}
