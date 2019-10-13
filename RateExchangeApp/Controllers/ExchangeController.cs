using RateExchangeApp.Core;
using RateExchangeApp.Repository.Entities;
using System.Collections.Generic;
using System.Web.Http;
using RateExchangeApp.Core.Logger;
namespace RateExchangeApp.Controllers
{
    public class ExchangeController : ApiController
    {
        IExchangeLogic logic;// = new ExchangeLogic();
        ILogger logger;
        public ExchangeController(IExchangeLogic _logic)
        {
            logic = _logic;
        }

        [HttpGet]
        [Route("api/Ping")]
        public string GetPing()
        {
            return "Ping";
        }

        //Route: http://localhost:53470/api/Exchange/Currencies
        [HttpGet]
        [Route("api/Exchange/Currencies")]
        public IEnumerable<CurrencyType> GetExchangeTable()
        {
            return logic.GetListOfAvilableCurrencies();
        }
        //Route: http://localhost:53470/api/Exchange?value=1&currencyFrom=USD&currencyTo=EUR
        [HttpGet]
        public decimal GetExchangeValue(decimal value, string currencyFrom, string currencyTo)
        {
            return logic.ConvertCurrency(value, currencyFrom, currencyTo);
        }
        //Route: http://localhost:53470/api/Exchange/Rates
        [HttpGet]
        [Route("api/Exchange/Rates")]
        public ExchangeRatesSeries GetAllRates()
        {
            return logic.GetAllRates();
        }
        //Route: http://localhost:53470/api/Exchange/ListRates?currencies=USD&currencies=EUR
        [HttpGet]
        [Route("api/Exchange/ListRates")]
        public IEnumerable<Rate> GetAllRates([FromUri] string[] currencies)
        {
            return logic.GetRates(currencies);
        }

    }
}
