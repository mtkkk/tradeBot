using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace TradingBOT.Class.Objects
{
    class Order
    {
        public string request { get; set; }
        public string nonce { get; set; }        
        public string symbol { get; set; }
        public string amount { get; set; }
        public float price { get; set; }
        public string side { get; set; }
        public string type { get; set; }
        public string exchange { get; set; }
        public Boolean is_hidden { get; set; }
        public Boolean is_postonly { get; set; }
        public Int32 use_all_available { get; set; }
        public Boolean ocoorder { get; set; }
        public float buy_price_oco { get; set; }
        public float sell_price_oco { get; set; }

        public Order(string sb, string amt, string prc, string s, string t)
        {
            this.request = ConfigurationManager.AppSettings["orderURI"];
            this.nonce = Util.getNonce().ToString();
            this.symbol = sb;
            this.amount = amt;
            this.price = float.Parse(prc, System.Globalization.CultureInfo.InvariantCulture);
            this.side = s;
            this.type = t;
            this.ocoorder = false;
            this.buy_price_oco = 0;
            this.sell_price_oco = 0;
        }

        public Boolean executeOrder(Order order)
        {
            try
            {                
                var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var payloadJson = jsonSerializer.Serialize(order);                

                string payload = Util.Base64Encode(payloadJson);
                string key = ConfigurationManager.AppSettings["apiKEY"];
                HMACSHA384 hmac = new HMACSHA384(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["apiSECRET"]));
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                string signature = BitConverter.ToString(hash).Replace("-", "").ToLower();

                HttpWebRequest request;
                string requestURI = ConfigurationManager.AppSettings["orderURL"];
                request = (HttpWebRequest)WebRequest.Create(requestURI);
                request.Method = "POST";
                request.ContentType = "application/json";

                WebHeaderCollection headers = request.Headers;
                headers.Add("X-BFX-APIKEY", key);
                //headers.Add("X-BFX-PAYLOAD", payload);
                headers.Add("X-BFX-PAYLOAD", "eyJyZXF1ZXN0IjoiL3YxL29yZGVyL25ldyIsIm5vbmNlIjoiNjM2NDgxMDE3MzAxNDI4MDUxIiwic3ltYm9sIjoidEJUQ1VTRCIsImFtb3VudCI6IjAuMDAyIiwicHJpY2UiOjEwMDAwLCJzaWRlIjoiYnV5IiwidHlwZSI6Im1hcmtldCIsImV4Y2hhbmdlIjpudWxsLCJpc19oaWRkZW4iOmZhbHNlLCJpc19wb3N0b25seSI6ZmFsc2UsInVzZV9hbGxfYXZhaWxhYmxlIjowLCJvY29vcmRlciI6ZmFsc2UsImJ1eV9wcmljZV9vY28iOjAsInNlbGxfcHJpY2Vfb2NvIjowfQ==");
                //headers.Add("X-BFX-SIGNATURE", signature);
                headers.Add("X-BFX-SIGNATURE", "d3f531396b16ea34f25a3ae3a39ead389c535f42a4a4fee4c89f496e9535f140818d84989bd8d9f4fe88d088e3aae267");

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(dataStream);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;                
            }            
        }
    }

    
}
