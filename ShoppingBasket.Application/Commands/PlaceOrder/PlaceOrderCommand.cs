using MediatR;
using ShoppingBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasket.Application.Commands.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<Unit>
    {
        public List<CartItemModel> CartItems { get; set; }

        public class Handler : IRequestHandler<PlaceOrderCommand, Unit>
        {
            public async Task<Unit> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
            {
                return Unit.Value;
            }
        }
    }
}
