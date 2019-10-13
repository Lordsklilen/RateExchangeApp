using RateExchangeApp.Repository;
using System;

namespace RateExchangeApp.Core
{
    public class Logger
    {
        ILogRepository logRepository;
        public Logger(ILogRepository _logRepository) {
            logRepository = _logRepository;

        }

        public void SaveGetAllLog() {
            ExchangeRatesLog log = new ExchangeRatesLog()
            {
                OperationType = "GetAllCurrencies",

            };
            logRepository.CreateLog(log);
        }

        public void SaveErrorLog(Exception ex, string Type) {
            ExchangeRatesLog log = new ExchangeRatesLog()
            {
                OperationType = Type,
                Exception = $"Message: {ex.Message}\nStack: {ex.StackTrace}"
            };
            logRepository.CreateLog(log);
        }

        public void SaveGetCurrencyLog(decimal valueInput, decimal valueOuput, string currencyFrom, string currencyTo) {
            ExchangeRatesLog log = new ExchangeRatesLog()
            {
                OperationType = "ConvertCurrency",
                CurrencyFrom = currencyFrom,
                CurrencyTo = currencyTo,
                RequestedURL = NbpRepository.urlSingleAddress,
                ValueInput = Math.Round((Decimal)valueInput, 2),
                ValueOutput = Math.Round((Decimal)valueOuput, 2)
            };
            logRepository.CreateLog(log);
        }

        public void SaveGetAllRatesLog()
        {
            ExchangeRatesLog log = new ExchangeRatesLog()
            {
                OperationType = "GetAllRates",
                RequestedURL = NbpRepository.urlAllAddress,
            };
            logRepository.CreateLog(log);
        }

        public void SaveGetRatesLog(string[] types)
        {
            ExchangeRatesLog log = new ExchangeRatesLog()
            {
                OperationType = "GetRates",
                RequestedURL = NbpRepository.urlSingleAddress,
                CurrencyFrom = "["+ String.Join(",",types)+ "]"
        };
            logRepository.CreateLog(log);
        }
    }
}
