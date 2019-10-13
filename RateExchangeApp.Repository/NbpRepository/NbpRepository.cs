using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RateExchangeApp.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Repository
{
    public class NbpRepository : INbpRepository
    {
        public ExchangeRatesSeries GetCurrentRate(string CurrencyType)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString($"http://api.nbp.pl/api/exchangerates/rates/c/{CurrencyType}/");
            }
            ExchangeRatesSeries data = JsonConvert.DeserializeObject<ExchangeRatesSeries>(json); ;
            return data;
        }
    }
}
