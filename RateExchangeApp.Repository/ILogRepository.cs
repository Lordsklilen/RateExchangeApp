using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateExchangeApp.Repository
{
    public interface ILogRepository
    {
        void CreateLog(string message);
    }
}
