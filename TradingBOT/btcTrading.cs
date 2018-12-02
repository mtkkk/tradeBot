using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using TradingBOT.Class.Objects;
using TradingBOT.Class;
using System.Timers;
using Newtonsoft.Json;
using TradingBOT.Class.Objects.CryptoWatch;

namespace TradingBOT
{
    public partial class frmBtcTrading : Form
    {
        public Boolean running = false;

        public frmBtcTrading()
        {
            InitializeComponent();

            //Loads current price information for this symbol
            //string response = getTickerResponse("tBTCUSD").Replace("[","").Replace("]","");
            string response = getCryptoWatchCandles("3600", "btcusd", "bitfinex");

            OHLCResponse ohlcResponse = JsonConvert.DeserializeObject<OHLCResponse>(response);

            Ticker ticker = new Ticker(response);

            txtPrice.Text = ticker.last_price.ToString();
            txtHigh.Text = ticker.high.ToString();
            txtLow.Text = ticker.low.ToString();
            txtVolume.Text = ticker.volume.ToString();
            switchStatus(running);
            Console.WriteLine(ticker.ToString());
            
        }

        public void frmBtcTrading_Load(object sender, EventArgs e)
        {
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Analysis analysis = new Analysis();
            do
            {
                running = true;
                switchStatus(running);
                analysis.startAnalysis();
                if (analysis.sentiment == "buy")
                {
                    Order order = new Order("tBTCUSD", "0.002", "10000", "buy", "market");
                    Boolean retorno = order.executeOrder(order);
                }
                System.Timers.Timer timer = new System.Timers.Timer(5000);
                timer.Start();                
            }
            while (running);
        }

        /*
         * This method gets de Ticker values for the given symbol
         * 
         */
        public string getTickerResponse(string symbol)
        {
            try
            {
                HttpWebRequest request;
                string requestURI = ConfigurationManager.AppSettings["tickerURL"] + symbol;
                request = (HttpWebRequest) WebRequest.Create(requestURI);
                request.Method = "GET";
                request.ContentType = "application/json";

                HttpWebResponse response = (HttpWebResponse) request.GetResponse();

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

        public string getCryptoWatchCandles(string timeRange, string symbol, string market)
        {
            try
            {
                HttpWebRequest request;
                string cwUrl = ConfigurationManager.AppSettings["cwUrl"];

                string requestURI = $"{cwUrl}/{market}/{symbol}/ohlc?periods={timeRange}";
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

        public void switchStatus(Boolean running)
        {
            if (running)
            {
                lblStatus.Text = "Running";
                lblStatus.ForeColor = System.Drawing.Color.Green;                
            }
            else
            {
                lblStatus.Text = "Offline";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
