using RateExchangeApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RateExchangeApp.Controllers
{
    public class ExchangeController : ApiController
    {
        IExchangeLogic logic;// = new ExchangeLogic();

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

        [HttpGet]
        [Route("api/Exchange/all")]
        public string GetExchangeTable()
        {

            return logic.GetListOfAvilableCurrencies();
        }
        //Route: http://localhost:53470/api/Exchange?value=1&currencyFrom=PLN&currencyTo=EUR
        [HttpGet]
        public string GetExchangeValue(double value, string currencyFrom, string currencyTo)
        {
            return logic.ConvertCurrency(value,currencyFrom,currencyTo).ToString();
        }
    }
}
