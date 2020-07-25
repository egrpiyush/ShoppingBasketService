using AutoFixture;
using FluentValidation.TestHelper;
using ShoppingBasket.Application.Commands.PlaceOrder;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingBasket.Application.Tests.Commands.PlaceOrder
{
    public class PlaceOrderCommandValidatorTests
    {
        private readonly PlaceOrderCommandValidator _rulesValidator;
        private static readonly Fixture Fixture = new Fixture();

        public PlaceOrderCommandValidatorTests()
        {
            _rulesValidator = new PlaceOrderCommandValidator();
        }

        [Fact]
        public void WhenCartItemIsNull_ShouldHaveValidationError()
        {
            var command = new PlaceOrderCommand { CartItems = null };
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.CartItems, command);
        }

        [Fact]
        public void WhenCartItemIsEmpty_ShouldHaveValidationError()
        {
            var command = new PlaceOrderCommand { CartItems = new List<CartItemModel>() };
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.CartItems, command);
        }
    }
}
