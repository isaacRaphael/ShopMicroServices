using CartService.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartService.Models
{
    public class CartItem : BaseEntity
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Cart")]
        public Guid  CartId { get; set; }
    }
}
