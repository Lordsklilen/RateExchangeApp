using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Repository.Entities
{
    public class ExchangeRatesSeries
    {
        public string Table;
        public string Currency;
        public string Code;
        public List<Rate> Rates;
    }
}
