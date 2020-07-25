using AutoFixture;
using FluentValidation.TestHelper;
using ShoppingBasket.Application.Commands.PlaceOrder;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingBasket.Application.Tests.Commands.PlaceOrder
{
    public class CartItemValidatorTests
    {
        private readonly CartItemValidator _rulesValidator;
        private static readonly Fixture Fixture = new Fixture();

        public CartItemValidatorTests()
        {
            _rulesValidator = new CartItemValidator();
        }

        [Fact]
        public void WhenProductIdIsInvalid_ShouldHaveValidationError()
        {
            var sut = Fixture.Build<CartItemModel>()
                    .Without(p => p.ProductId)
                    .Create();
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.ProductId, sut);
        }

        [Fact]
        public void WhenQuantityIsInvalid_ShouldHaveValidationError()
        {
            var sut = Fixture.Build<CartItemModel>()
                    .Without(p => p.Quantity)
                    .Create();
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.Quantity, sut);
        }
    }
}
