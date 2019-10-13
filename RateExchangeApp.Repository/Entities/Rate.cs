using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Repository.Entities
{
    public class Rate
    {
        public string Currency;
        public string Code;
        public decimal Bid;
        public decimal Ask;
    }
}
