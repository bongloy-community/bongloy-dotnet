using System;
using Stripe;
using Xunit;

namespace BongloyTests
{
    public class CustomerTest : IClassFixture<BongloyFixture>
    {
        [Fact]
        public void Create()
        {
            var options = new CustomerCreateOptions
            {
                Email = "user@example.com",
                Description = "My First Test Customer",
                Source = this.Token().Id,
            };

            var service = new CustomerService();

            var customer = service.Create(options);

            Assert.Equal("user@example.com", customer.Email);
            Assert.Equal("My First Test Customer", customer.Description);
        }

        [Fact]
        public void Get()
        {
            var options = new CustomerCreateOptions
            {
                Email = "user@example.com",
                Description = "My First Test Customer",
                Source = this.Token().Id,
            };

            var service = new CustomerService();

            var customer = service.Create(options);

            var result = service.Get(customer.Id);

            Assert.Equal(result.Id, customer.Id);
        }

        [Fact]
        public void List()
        {
            var options = new CustomerCreateOptions
            {
                Email = "user@example.com",
                Description = "My First Test Customer",
                Source = this.Token().Id,
            };

            var service = new CustomerService();

            var customer = service.Create(options);

            var customers = service.List();

            Assert.Equal(customers.Data[0].Id, customer.Id);
        }

        private Token Token()
        {
            var options = new TokenCreateOptions
            {
                Card = new CreditCardOptions
                {
                    Number = "6200000000000005",
                    ExpYear = DateTime.Now.Year + 1,
                    ExpMonth = 3,
                    Cvc = "123"
                }
            };

            var service = new TokenService();

            return service.Create(options);
        }
    }
}