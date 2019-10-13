using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Core.Logger
{
    public interface ILogger
    {
        void SaveGetAllLog();

        void SaveErrorLog(Exception ex, string Type);

        void SaveGetCurrencyLog(decimal valueInput, decimal valueOuput, string currencyFrom, string currencyTo);
        void SaveGetAllRatesLog();

        void SaveGetRatesLog(string[] types);
    }
}
