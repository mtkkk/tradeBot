using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TradingBOT.Class.Objects.CryptoWatch.OHLC
{
    class Result
    {
        [JsonProperty(PropertyName="60")]
        private string t60 { get; set; }
        [JsonProperty(PropertyName = "180")]
        private string t180 { get; set; }
        [JsonProperty(PropertyName = "300")]
        private string t300 { get; set; }
        [JsonProperty(PropertyName = "900")]
        private string t900 { get; set; }
        [JsonProperty(PropertyName = "1800")]
        private string t1800 { get; set; }
        [JsonProperty(PropertyName = "3600")]
        private string t3600 { get; set; }
        [JsonProperty(PropertyName = "7200")]
        private string t7200 { get; set; }
        [JsonProperty(PropertyName = "14400")]
        private string t14400 { get; set; }
        [JsonProperty(PropertyName = "21600")]
        private string t21600 { get; set; }
        [JsonProperty(PropertyName = "43200")]
        private string t43200 { get; set; }
        [JsonProperty(PropertyName = "86400")]
        private string t86400 { get; set; }
        [JsonProperty(PropertyName = "259200")]
        private string t259200 { get; set; }
        [JsonProperty(PropertyName = "604800")]
        private string t604800 { get; set; }

    }
}
