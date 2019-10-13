using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Core.Logger
{
    public class EmptyLogger : ILogger
    {
        public void SaveErrorLog(Exception ex, string Type)
        {
        }

        public void SaveGetAllLog()
        {
        }

        public void SaveGetAllRatesLog()
        {
        }

        public void SaveGetCurrencyLog(decimal valueInput, decimal valueOuput, string currencyFrom, string currencyTo)
        {
        }

        public void SaveGetRatesLog(string[] types)
        {
        }
    }
}
