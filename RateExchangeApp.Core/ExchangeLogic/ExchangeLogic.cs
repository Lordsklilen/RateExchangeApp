using System;
using System.Collections.Generic;
using System.Linq;
using RateExchangeApp.Repository.Entities;

namespace RateExchangeApp.Core
{
    public class ExchangeLogic : IExchangeLogic
    {
        ICurrencyConverter converter;
        Logger logger;
        public ExchangeLogic(ICurrencyConverter _converter, Logger _logger)
        {
            converter = _converter;
            logger = _logger;
        }

        public decimal ConvertCurrency(decimal value, string currencyFrom, string currencyTo)
        {
            decimal result = 0;
            try
            {
                result = converter.ConvertCurrency(value, currencyFrom, currencyTo);
                logger.SaveGetCurrencyLog(value, result, currencyFrom, currencyTo);
            }
            catch (Exception ex) {
                logger.SaveErrorLog(ex, "ConvertCurrency");
                throw;
            }
            return result;
        }

        public ExchangeRatesSeries GetAllRates()
        {
            try
            {
                var result = converter.GetAllCurrencies();
                logger.SaveGetAllRatesLog();
                return result;
            }
            catch (Exception ex)
            {
                logger.SaveErrorLog(ex, "GetAllRates");
                throw;
            }
        }

        public IEnumerable<CurrencyType> GetListOfAvilableCurrencies()
        {
            List<CurrencyType> result = new List<CurrencyType>();
            try
            {
                result = Enum.GetValues(typeof(CurrencyType)).OfType<CurrencyType>().ToList();
                logger.SaveGetAllLog();
            }
            catch (Exception ex)
            {
                logger.SaveErrorLog(ex, "GetAllCurrencies");
                throw;
            }
            return result;
        }
    }
}
