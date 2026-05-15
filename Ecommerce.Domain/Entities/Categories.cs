namespace Ecommerce.Domain.Entities
{
    public class Categories
    {
        public Guid CategoryGuid { get; set; } = Guid.NewGuid();
        public Guid CategoryParent { get; set;}

        public string Name { get; set; }
    }
}
