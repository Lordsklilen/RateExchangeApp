using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RateExchangeApp.Tests
{
    public class ExchangeLogicTests
    {
        [Theory]
        [InlineData(1,"PLN","EUR")]
        public void ConvertCurrencyTest(double value, string currencyFrom, string currencyTo) {
            throw new NotImplementedException();
        }

        [Fact]
        string GetListOfAvilableCurrencies()
        {
            throw new NotImplementedException();
        }
    }
}
