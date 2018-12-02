using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradingBOT
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            frmBtcTrading form = new frmBtcTrading();
            form.Show();
        }
    }
}
