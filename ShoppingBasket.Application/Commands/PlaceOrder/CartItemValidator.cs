using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Application.Commands.PlaceOrder
{
    public class CartItemValidator : AbstractValidator<CartItemModel>
    {
        public CartItemValidator()
        {
            RuleFor(p => p.ProductId)
                .GreaterThan(0);
            RuleFor(p => p.Quantity)
                .GreaterThan(0);
        }
    }
}
