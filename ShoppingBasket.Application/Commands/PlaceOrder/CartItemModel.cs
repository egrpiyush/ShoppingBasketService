using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Application.Commands.PlaceOrder
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
