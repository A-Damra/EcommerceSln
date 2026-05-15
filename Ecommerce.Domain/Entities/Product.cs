namespace Ecommerce.Domain.Entities
{
    public class Product
    {
        public Guid ProductGuid { get; set; } = Guid.NewGuid();
        public Guid CategoryGuid { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int StockQuantity { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
