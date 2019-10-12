using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Core
{
    public interface IExchangeLogic
    {
        double ConvertCurrency(double value, string currencyFrom, string currencyTo);
        IEnumerable<CurrencyType> GetListOfAvilableCurrencies();
    }
}
