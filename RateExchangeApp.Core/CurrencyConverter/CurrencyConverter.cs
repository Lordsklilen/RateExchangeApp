using RateExchangeApp.Repository;
using RateExchangeApp.Repository.Entities;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Rate> GetCurrencies(string[] currencies)
        {
            if (!currencies.Any())
                return null;
            List<Rate> result = new List<Rate>();
            foreach (var currency in currencies) {
                result.Add(GetRateWithMetadata(currency));
            }
            return result;
        }

        private Rate GetRate(string currency)
        {
            if (string.Equals(currency, "PLN", StringComparison.InvariantCultureIgnoreCase))
                return new Rate() { Ask = 1, Bid = 1 };
            return repository.GetCurrentRate(currency).Rates.First();
        }
        private Rate GetRateWithMetadata(string currency)
        {
            if (string.Equals(currency, "PLN", StringComparison.InvariantCultureIgnoreCase))
                return new Rate() { Ask = 1, Bid = 1 , Code = "PLN", Currency = "Polski złoty"};
            var data = repository.GetCurrentRate(currency);
            var result = data.Rates.First();
            result.Code = data.Code;
            result.Currency = data.Currency;
            return result;
        }

    private CurrencyType ParseCurrency(string currency)
        {
            CurrencyType currencyType = (CurrencyType)Enum.Parse(typeof(CurrencyType), currency.ToUpper());
            return currencyType;
        }
    }
}
