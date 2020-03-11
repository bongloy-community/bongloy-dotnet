using System;
using Stripe;
using Xunit;

namespace BongloyTests
{
    public class RefundTest : IClassFixture<BongloyFixture>
    {
        [Fact]
        public void Create()
        {
            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "USD",
                Source = this.Token().Id,
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            var refundService = new RefundService();

            var refundOptions = new RefundCreateOptions
            {
                ChargeId = charge.Id
            };

            var refund = refundService.Create(refundOptions);

            Assert.Equal(2000, refund.Amount);
            Assert.Equal(charge.Id, refund.ChargeId);
        }

        [Fact]
        public void PartialRefund()
        {
            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "USD",
                Source = this.Token().Id,
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            var refundOptions = new RefundCreateOptions
            {
                Amount = 800,
                ChargeId = charge.Id
            };

            var refundService = new RefundService();
            var refund = refundService.Create(refundOptions);

            Assert.Equal(800, refund.Amount);
        }

        [Fact]
        public void Get()
        {
            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "USD",
                Source = this.Token().Id,
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            var refundOptions = new RefundCreateOptions
            {
                Amount = 800,
                ChargeId = charge.Id
            };

            var refundService = new RefundService();
            var refund = refundService.Create(refundOptions);

            var result = refundService.Get(refund.Id);

            Assert.Equal(result.Id, refund.Id);
        }

        [Fact]
        public void List()
        {
            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "USD",
                Source = this.Token().Id,
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            var refundOptions = new RefundCreateOptions
            {
                Amount = 800,
                ChargeId = charge.Id
            };

            var refundService = new RefundService();
            var refund = refundService.Create(refundOptions);

            var refunds = refundService.List();

            Assert.Equal(refunds.Data[0].Id, refund.Id);
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
