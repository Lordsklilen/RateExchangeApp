
namespace RateExchangeApp.Repository
{
    public class LogRepository : ILogRepository
    {
        ExchangeRates_LOGEntities dbObj = new ExchangeRates_LOGEntities();
        public void CreateLog(ExchangeRatesLog log)
        {
            dbObj.ExchangeRatesLog.Add(log);
            dbObj.SaveChangesAsync();
        }
    }
}
