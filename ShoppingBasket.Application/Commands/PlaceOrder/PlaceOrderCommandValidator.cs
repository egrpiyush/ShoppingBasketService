using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Application.Commands.PlaceOrder
{
    public class PlaceOrderCommandValidator : AbstractValidator<PlaceOrderCommand>
    {
        public PlaceOrderCommandValidator()
        {
            RuleFor(p => p.CartItems)
                .NotEmpty()
                .NotNull();

            RuleForEach(p => p.CartItems)
                .SetValidator(new CartItemValidator());
        }
    }
}
