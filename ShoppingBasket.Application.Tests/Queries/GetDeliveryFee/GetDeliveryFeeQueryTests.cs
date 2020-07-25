using AutoFixture;
using ShoppingBasket.Application.Queries.GetDeliveryFee;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace ShoppingBasket.Application.Tests.Queries.GetDeliveryFee
{
    public class GetDeliveryFeeQueryTests
    {
        private static readonly Fixture Fixture = new Fixture();
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        [Fact]
        public async void WhenCartTotalIsLessThan50_ShouldReturn10()
        {
            //Arange
            var request = Fixture.Build<GetDeliveryFeeQuery>()
                .With(p => p.CartTotal, 49.9M)
                .Create();
            var handler = new GetDeliveryFeeQuery.Handler();
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.ShouldBe(10);
        }

        [Fact]
        public async void WhenCartTotalIsEqualTo50_ShouldReturn10()
        {
            //Arange
            var request = Fixture.Build<GetDeliveryFeeQuery>()
                .With(p => p.CartTotal, 50M)
                .Create();
            var handler = new GetDeliveryFeeQuery.Handler();
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.ShouldBe(10);
        }

        [Fact]
        public async void WhenCartTotalIsGreaterThan50_ShouldReturn20()
        {
            //Arange
            var request = Fixture.Build<GetDeliveryFeeQuery>()
                .With(p => p.CartTotal, 51.1M)
                .Create();
            var handler = new GetDeliveryFeeQuery.Handler();
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.ShouldBe(20);
        }
    }
}
