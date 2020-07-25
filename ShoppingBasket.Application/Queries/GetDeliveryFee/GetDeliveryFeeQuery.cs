using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasket.Application.Queries.GetDeliveryFee
{
    public class GetDeliveryFeeQuery : IRequest<decimal>
    {
        public decimal CartTotal { get; set; }
        public class Handler : IRequestHandler<GetDeliveryFeeQuery, decimal>
        {
            public Handler()
            {
            }
            
            public async Task<decimal> Handle(GetDeliveryFeeQuery request, CancellationToken cancellationToken)
            {
                return request.CartTotal > 50 ? 20 : 10;
            }
        }
    }
}
