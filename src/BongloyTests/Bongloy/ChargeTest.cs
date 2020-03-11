using System;
using Stripe;
using Xunit;

namespace BongloyTests
{
    public class ChargeTest : IClassFixture<BongloyFixture>
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

            Assert.Equal(2000, charge.Amount);
            Assert.Equal("USD", charge.Currency);
            Assert.Equal("succeeded", charge.Status);
        }

        [Fact]
        public void Capture()
        {
            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "USD",
                Source = this.Token().Id,
                Capture = false,
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            var captureOptions = new ChargeCaptureOptions
            {
                Amount = 2000,
            };

            var charge_capture = service.Capture(charge.Id, captureOptions);

            Assert.Equal(true, charge_capture.Captured);
            Assert.Equal("succeeded", charge_capture.Status);
            Assert.Equal(2000, charge_capture.Amount);
        }

        [Fact]
        public void PartialCapture()
        {
            var options = new ChargeCreateOptions
            {
                Amount = 10000,
                Currency = "USD",
                Source = this.Token().Id,
                Capture = false,
            };

            var service = new ChargeService();
            var charge = service.Create(options);

            var captureOptions = new ChargeCaptureOptions
            {
                Amount = 8000,
            };

            var charge_capture = service.Capture(charge.Id, captureOptions);

            Assert.Equal(true, charge_capture.Captured);
            Assert.Equal(2000, charge_capture.AmountRefunded);
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

            var result = service.Get(charge.Id);
            
            Assert.Equal(charge.Id, result.Id);
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

            var charges = service.List();

            Assert.Equal(charges.Data[0].Amount, charge.Amount);
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
