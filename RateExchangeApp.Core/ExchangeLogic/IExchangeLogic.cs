using RateExchangeApp.Repository.Entities;
using System.Collections.Generic;

namespace RateExchangeApp.Core
{
    public interface IExchangeLogic
    {
        decimal ConvertCurrency(decimal value, string currencyFrom, string currencyTo);
        IEnumerable<CurrencyType> GetListOfAvilableCurrencies();
        ExchangeRatesSeries GetAllRates();
        IEnumerable<Rate> GetRates(string[] currencies);
    }
}
