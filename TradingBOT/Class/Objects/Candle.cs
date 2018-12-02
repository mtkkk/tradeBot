using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingBOT.Class.Objects
{
    public class Candle
    {
        public Int64 mts {get; set; }
        public float open { get; set; }
        public float close { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float volume { get; set; }

        public Candle(string response)
        {
            string[] data = response.Split(',');
            this.mts = Int64.Parse(data[0], System.Globalization.CultureInfo.InvariantCulture);
            this.open = float.Parse(data[1], System.Globalization.CultureInfo.InvariantCulture);
            this.close = float.Parse(data[2], System.Globalization.CultureInfo.InvariantCulture);
            this.high = float.Parse(data[3], System.Globalization.CultureInfo.InvariantCulture);
            this.low = float.Parse(data[4], System.Globalization.CultureInfo.InvariantCulture);
            this.volume = float.Parse(data[5], System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
