using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Core
{
    public interface ICurrencyConverter
    {
        double ConvertCurrency(double value, string from, string to);
    }
}
