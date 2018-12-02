using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TradingBOT.Class.Objects;

namespace TradingBOT.Class
{
    class Analysis
    {
        public string sentiment { get; set; }

        public void startAnalysis()
        {
            //First part of the analysis is checking the candles
            Console.WriteLine("Starting candle Analysis");
            string candles = getCandles("30m", "tBTCUSD");
            processCandles(candles);
            Console.WriteLine("Candle Analysis complete. Sentiment: " + sentiment);

            //Second step is to check if there are already open orders
            Console.WriteLine("Starting open position Analysis");
            string position = getPosition();
            Console.WriteLine("Open position Analysis complete.");


        }

        public string getCandles(string timeFrame, string symbol)
        {
            try
            {
                HttpWebRequest request;
                string requestURI = ConfigurationManager.AppSettings["candlesURL"] + timeFrame + ":" + symbol + "/hist";
                string requestParams = "/?limit=3";
                requestURI += requestParams;
                request = (HttpWebRequest)WebRequest.Create(requestURI);
                request.Method = "GET";
                request.ContentType = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(dataStream);

                return sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        public void processCandles(string candles)
        {
            var lstCandles = new List<Candle>();
            string[] delimiter = {"],"};
            StringSplitOptions opt = new StringSplitOptions();
            string[] candlesArr = candles.Split(delimiter, opt);

            foreach (string c in candlesArr)
            {
                var cClean = c.Replace("]","").Replace("[","");
                Candle candleStick = new Candle(cClean);
                lstCandles.Add(candleStick);
            }
                    
            //After storing the requested candles time to process them
            int countNegativeCandles = 0;
            float variation = 0;
            foreach (Candle c in lstCandles)
            {
                if ((c.close < c.open) && ((c.open - c.close) > 20))
                {
                    countNegativeCandles += 1;
                    variation += c.open - c.close;
                }
            }
            if (countNegativeCandles >= 3 && variation >= 80)
            {
                sentiment = "buy";
            }
            else
            {
                sentiment = "nothing";
            }

        }

        public string getPosition()
        {
            string nonce = DateTime.Now.ToString();
            return nonce;
        }

    }
}
