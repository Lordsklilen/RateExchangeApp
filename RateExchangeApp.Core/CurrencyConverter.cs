using RateExchangeApp.Repository;
using System;

namespace RateExchangeApp.Core
{
    public class CurrencyConverter:ICurrencyConverter
    {
        INbpRepository repository;
        public CurrencyConverter(INbpRepository _repository)
        {
            repository = _repository;

        }
        public double ConvertCurrency(double value, string from, string to) {
            var CurrencyFrom = ParseCurrency(from);
            var CurrencyTo = ParseCurrency(to);
            var fromRate = GetRate(CurrencyFrom.ToString());
            var toRate = GetRate(CurrencyTo.ToString());
            return value * fromRate/toRate;
        }

        private double GetRate(string currency) {
            if (string.Equals(currency, "PLN", StringComparison.InvariantCultureIgnoreCase))
                return 1;
            return repository.GetCurrentRate(currency);
        }
        private CurrencyType ParseCurrency(string currency) {
            CurrencyType currencyType = (CurrencyType) Enum.Parse(typeof(CurrencyType), currency.ToUpper());
            return currencyType;
        }
    }
}
