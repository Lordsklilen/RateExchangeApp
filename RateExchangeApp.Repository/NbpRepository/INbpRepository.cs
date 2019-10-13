using RateExchangeApp.Repository.Entities;

namespace RateExchangeApp.Repository
{
    public interface INbpRepository
    {
        ExchangeRatesSeries GetCurrentRate(string CurrencyType);
        ExchangeRatesSeries GetAllRates();
    }
}
