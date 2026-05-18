using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities
{
    public class Category
    {
        public Guid CategoryGuid { get; set; } = Guid.NewGuid();

        [Required]
        public Guid CategoryParent { get; set;}

        [Required]
        public bool IsActive { get; set; } = true;

        public string ImageUrl { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
