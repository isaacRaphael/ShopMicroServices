namespace ProductInventoryService.Models
{
    public class Product
    {
        public Product()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
