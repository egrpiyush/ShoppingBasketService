using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
