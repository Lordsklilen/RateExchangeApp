using RateExchangeApp.Repository;
using RateExchangeApp.Repository.Entities;
using System;
using System.Linq;
namespace RateExchangeApp.Core
{
    public class CurrencyConverter : ICurrencyConverter
    {
        INbpRepository repository;
        public CurrencyConverter(INbpRepository _repository)
        {
            repository = _repository;

        }
        public decimal ConvertCurrency(decimal value, string from, string to)
        {
            var CurrencyFrom = ParseCurrency(from);
            var CurrencyTo = ParseCurrency(to);
            var fromRate = GetRate(CurrencyFrom.ToString());
            var toRate = GetRate(CurrencyTo.ToString());
            return value * fromRate.Bid / toRate.Ask;
        }

        public ExchangeRatesSeries GetAllCurrencies()
        {
            return repository.GetAllRates();
        }

        private Rate GetRate(string currency)
        {
            if (string.Equals(currency, "PLN", StringComparison.InvariantCultureIgnoreCase))
                return new Rate() { Ask = 1, Bid = 1 };
            return repository.GetCurrentRate(currency).Rates.First();
        }

        private CurrencyType ParseCurrency(string currency)
        {
            CurrencyType currencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), currency.ToUpper());
            return currencyType;
        }
    }
}
