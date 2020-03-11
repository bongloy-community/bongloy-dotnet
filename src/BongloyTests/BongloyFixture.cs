using System;
using Bongloy;
using Xunit;

namespace BongloyTests
{
    public class BongloyFixture : IDisposable
    {
        public BongloyFixture()
        {
            new BongloyClient("sk_test_8c3215891ebc18ae40a24f68a09b872646cf62c5b1d47c75232e7abd54b5e645");
        }

        public void Dispose()
        {
        }
    }
}
