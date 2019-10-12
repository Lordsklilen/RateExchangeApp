using Newtonsoft.Json.Linq;
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
        public double GetCurrentRate(string CurrencyType)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString($"http://api.nbp.pl/api/exchangerates/rates/a/{CurrencyType}/");
            }
            dynamic data = JObject.Parse(json);
            return Convert.ToDouble(data.rates[0].mid);
        }
    }
}
