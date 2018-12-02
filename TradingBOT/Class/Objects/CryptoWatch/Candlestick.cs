using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBOT.Class.Objects
{
    class CandlestickCryptoWatch
    {
        /*
         * Possible times in seconds
         * 60       = 1 minute
         * 180      = 3 minutes
         * 300      = 5 minutes
         * 900      = 15 minutes
         * 1800     = 30 minutes
         * 3600     = 1 hour
         * 7200     = 2 hours
         * 14400    = 4 hours
         * 21600    = 6 hours
         * 43200    = 12 hours
         * 86400    = 1 day
         * 259200   = 3 days
         * 604800   = 7 days
         * 
         * Response format
         * [ CloseTime, OpenPrice, HighPrice, LowPrice, ClosePrice, Volume ]
         * */

        private int TimeRange { get; set; }
        private Int64 CloseTime { get; set; }
        private Decimal OpenPrice { get; set; }
        private Decimal HighPrice { get; set; }
        private Decimal LowPrice { get; set; }
        private Decimal ClosePrice { get; set; }
        private Decimal Volume { get; set; }

        public void setVariables()
        {

        }

    }
}
