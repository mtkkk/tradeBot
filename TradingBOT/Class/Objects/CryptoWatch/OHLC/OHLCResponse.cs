using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingBOT.Class.Objects.CryptoWatch.OHLC;

namespace TradingBOT.Class.Objects.CryptoWatch
{
    class OHLCResponse
    {
        private Object result { get; set; }
        private Dictionary<string, Allowance> allowance { get; set; }        
    }
}
