using CartService.Models.Base;
using System;

namespace CartService.Models
{
    public class Cart : BaseEntity
    {
        public int Status { get; set; }
        public ICollection<CartItem>? Products { get; set; }
    }

}