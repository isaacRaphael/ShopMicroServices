using CartService.Models.Base;

namespace CartService.Models
{
    public class ProductTwin : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public string? ImageUrl { get; set; }

    }
}
