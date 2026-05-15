namespace Ecommerce.Domain.Entities
{
    public class Categories
    {
        public Guid CategoryGuid { get; set; } = Guid.NewGuid();
        public Guid CategoryParent { get; set;}

        public bool IsActive { get; set; } = true;

        public string Name { get; set; }
    }
}
