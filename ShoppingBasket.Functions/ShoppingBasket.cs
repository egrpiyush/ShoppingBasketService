using AzureFunctionsV2.HttpExtensions.Annotations;
using AzureFunctionsV2.HttpExtensions.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingBasket.Application.Commands.PlaceOrder;
using ShoppingBasket.Application.Queries.GetDeliveryFee;
using ShoppingBasket.Application.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShoppingBasket.Functions
{
    public class ShoppingBasket
    {
        private readonly IMediator _mediator;
        public ShoppingBasket(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName(nameof(GetProducts))]
        public async Task<IActionResult> GetProducts(
            [HttpTrigger(AuthorizationLevel.Function, "get")]
            HttpRequest req,
            ILogger log,
            CancellationToken cancellationToken)
        {
            var quoteModel = await _mediator.Send(new GetProductsQuery(), cancellationToken);
            return new OkObjectResult(quoteModel);
        }

        [FunctionName(nameof(GetDeliveryFee))]
        public async Task<IActionResult> GetDeliveryFee(
            [HttpTrigger(AuthorizationLevel.Function, "get")]
            HttpRequest req,
            [HttpQuery] HttpParam<decimal> cartTotal,
            ILogger log,
            CancellationToken cancellationToken)
        {
            var quoteModel = await _mediator.Send(new GetDeliveryFeeQuery { CartTotal = cartTotal }, cancellationToken);
            return new OkObjectResult(quoteModel);
        }

        [FunctionName(nameof(PlaceOrder))]
        public async Task<IActionResult> PlaceOrder(
            [HttpTrigger(AuthorizationLevel.Function, "post")]
            HttpRequest req,
            ILogger log,
            CancellationToken cancellationToken)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var cartItems = JsonConvert.DeserializeObject<List<CartItemModel>>(body);
            var command = new PlaceOrderCommand { CartItems = cartItems };
            await _mediator.Send(command, cancellationToken);
            return new OkResult();
        }
    }
}
