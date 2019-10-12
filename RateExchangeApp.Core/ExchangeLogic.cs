using System;
using System.Collections.Generic;
using System.Linq;

namespace RateExchangeApp.Core
{
    public class ExchangeLogic : IExchangeLogic
    {
        ICurrencyConverter converter;
        public ExchangeLogic(ICurrencyConverter _converter)
        {
            converter = _converter;
        }

        public double ConvertCurrency(double value, string currencyFrom, string currencyTo)
        {
            return converter.ConvertCurrency(value, currencyFrom, currencyTo);
        }

        public IEnumerable<CurrencyType> GetListOfAvilableCurrencies()
        {
            return Enum.GetValues(typeof(CurrencyType)).OfType<CurrencyType>().ToList();
        }
    }
}
