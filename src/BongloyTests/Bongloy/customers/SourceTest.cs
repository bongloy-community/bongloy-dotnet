using System;
using Stripe;
using Xunit;

namespace BongloyTests {
    public class SourceTest : IClassFixture<BongloyFixture>
    {
        [Fact]
        public void Create()
        {
            var customerOptions = new CustomerCreateOptions
            {
                Email = "user@example.com",
                Description = "My First Test Customer",
                Source = this.Token().Id,
            };
            var service = new CustomerService();
            var customer = service.Create(customerOptions);

            var sourceOptions = new CardCreateOptions
            {
                Source = this.Token().Id,
            };
            var sourceService = new CardService();
            var card = sourceService.Create(customer.Id, sourceOptions);

            Assert.Equal(card.CustomerId, customer.Id);
        }

        [Fact]
        public void Get()
        {
            var customerOptions = new CustomerCreateOptions
            {
                Email = "user@example.com",
                Description = "My First Test Customer",
                Source = this.Token().Id,
            };
            var service = new CustomerService();
            var customer = service.Create(customerOptions);

            var sourceOptions = new CardCreateOptions
            {
                Source = this.Token().Id,
            };
            var sourceService = new CardService();
            var card = sourceService.Create(customer.Id, sourceOptions);

            var result = sourceService.Get(customer.Id, card.Id);

            Assert.Equal(result.Id, card.Id);
        }

        [Fact]
        public void List()
        {
            var customerOptions = new CustomerCreateOptions
            {
                Email = "user@example.com",
                Description = "My First Test Customer",
                Source = this.Token().Id,
            };
            var service = new CustomerService();
            var customer = service.Create(customerOptions);

            var sourceOptions = new CardCreateOptions
            {
                Source = this.Token().Id,
            };
            var sourceService = new CardService();
            var card = sourceService.Create(customer.Id, sourceOptions);

            var cards = sourceService.List(customer.Id);

            Assert.Equal(cards.Data[0].Id, card.Id);
        }

        [Fact(Skip = "no content response")]
        public void Delete()
        {
            var customerOptions = new CustomerCreateOptions
            {
                Email = "user@example.com",
                Description = "My First Test Customer",
                Source = this.Token().Id,
            };
            var service = new CustomerService();
            var customer = service.Create(customerOptions);

            var sourceOptions = new CardCreateOptions
            {
                Source = this.Token().Id,
            };
            var sourceService = new CardService();
            var card = sourceService.Create(customer.Id, sourceOptions);

            var result = sourceService.Delete(customer.Id, card.Id);

            Assert.Equal(true, result.Deleted);
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
