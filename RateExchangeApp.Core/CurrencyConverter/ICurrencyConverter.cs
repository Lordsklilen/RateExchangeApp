using RateExchangeApp.Repository.Entities;
using System.Collections.Generic;

namespace RateExchangeApp.Core
{
    public interface ICurrencyConverter
    {
        decimal ConvertCurrency(decimal value, string from, string to);
        ExchangeRatesSeries GetAllCurrencies();
        IEnumerable<Rate> GetCurrencies(string[] currencies);
    }
}
