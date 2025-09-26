using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Dtos.CustomerDtos
{
    public class UpdateCustomerDto
    {
        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;
    }
}
