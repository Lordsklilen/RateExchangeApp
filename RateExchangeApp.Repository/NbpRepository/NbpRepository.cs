using Newtonsoft.Json;
using RateExchangeApp.Repository.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RateExchangeApp.Repository
{
    public class NbpRepository : INbpRepository
    {
        public static string urlSingleAddress { get; private set; } = "http://api.nbp.pl/api/exchangerates/rates/c";
        public static string urlAllAddress { get; private set; } = "http://api.nbp.pl/api/exchangerates/tables/c";

        public ExchangeRatesSeries GetAllRates()
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString($"{urlAllAddress}/");
            }
            var data = JsonConvert.DeserializeObject<List<ExchangeRatesSeries>>(json); ;
            return data.First();
        }

        public ExchangeRatesSeries GetCurrentRate(string CurrencyType)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString($"{urlSingleAddress}/{CurrencyType}/");
            }
            ExchangeRatesSeries data = JsonConvert.DeserializeObject<ExchangeRatesSeries>(json); ;
            return data;
        }
    }
}
