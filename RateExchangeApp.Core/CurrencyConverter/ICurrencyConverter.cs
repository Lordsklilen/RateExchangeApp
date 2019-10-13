using RateExchangeApp.Repository.Entities;

namespace RateExchangeApp.Core
{
    public interface ICurrencyConverter
    {
        decimal ConvertCurrency(decimal value, string from, string to);
        ExchangeRatesSeries GetAllCurrencies();
    }
}
