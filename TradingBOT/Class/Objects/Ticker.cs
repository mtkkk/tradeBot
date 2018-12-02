using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBOT.Class.Objects
{
    public class Ticker
    {
        public float bid { get; set; }
        public float bid_size { get; set; }
        public float ask { get; set; }
        public float ask_size { get; set; }
        public float daily_change { get; set; }
        public float daily_change_perc { get; set; }
        public float last_price { get; set; }
        public float volume { get; set; }
        public float high { get; set; }
        public float low { get; set; }

        public Ticker(string response)
        {
            string[] data = response.Split(',');
            this.bid = float.Parse(data[0], System.Globalization.CultureInfo.InvariantCulture);
            this.bid_size = float.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture);
            this.ask = float.Parse(data[2], System.Globalization.CultureInfo.InvariantCulture);
            this.ask_size = float.Parse(data[3], System.Globalization.CultureInfo.InvariantCulture);
            this.daily_change = float.Parse(data[4], System.Globalization.CultureInfo.InvariantCulture);
            this.daily_change_perc = float.Parse(data[5], System.Globalization.CultureInfo.InvariantCulture);
            this.last_price = float.Parse(data[6], System.Globalization.CultureInfo.InvariantCulture);
            this.volume = float.Parse(data[7], System.Globalization.CultureInfo.InvariantCulture);
            this.high = float.Parse(data[8], System.Globalization.CultureInfo.InvariantCulture);
            this.low = float.Parse(data[9], System.Globalization.CultureInfo.InvariantCulture);
        }
    }   
}
