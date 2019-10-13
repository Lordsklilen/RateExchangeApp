using RateExchangeApp.Core;
using RateExchangeApp.Repository.Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace RateExchangeApp.Controllers
{
    public class ExchangeController : ApiController
    {
        IExchangeLogic logic;// = new ExchangeLogic();
        Logger logger;
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
        //Route: http://localhost:53470/api/Exchange?value=1&currencyFrom=PLN&currencyTo=EUR
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

    }
}
