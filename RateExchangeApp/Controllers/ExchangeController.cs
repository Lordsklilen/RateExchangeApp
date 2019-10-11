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
        [HttpGet]
        public string GetPing()
        {
            return "Ping";
        }
    }
}
