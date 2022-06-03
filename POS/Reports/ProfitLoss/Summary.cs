using Infragistics.Win.UltraWinEditors;
using POS.Item;
using POS.SettingSoft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Reports.CustomerLedger
{
    public partial class Summary : Form
    {
        private SummaryLayer layer;
        public Summary()
        {
            InitializeComponent();
            layer = new SummaryLayer();
        }
        private void CustomerLedger2_Load(object sender, EventArgs e)
        {

            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            btnpreview.Text = Language.Preview;
            lbltitle.Text = "د خرڅلاو راپور";
            this.Text = "د خرڅلاو راپور";

            lblfrom.Text = Language.From;
            lblto.Text = Language.To;

        }
       
        private DateTime fromDate { get; set; }
        private DateTime toDate { get; set; }


        private void Btnpreview_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); 
            ChecktextBoxforValue();
           dt=layer.LoadSaleRecord("Preview", fromDate, toDate);
            txtsale.Text = dt.Rows[0][0].ToString();
            txttpsale.Text = dt.Rows[0][1].ToString();
            txtprofit.Text = dt.Rows[0][2].ToString();
            txtexpense.Text = dt.Rows[0][3].ToString();
            txtransferout.Text = dt.Rows[0][4].ToString();
            txtnetamount.Text = (Convert.ToDecimal(txtprofit.Text) - Convert.ToDecimal(txtexpense.Text)+Convert.ToDecimal(txtransferout.Text)).ToString();
        }
        public string rdbPrice { get; set; }
        private void ChecktextBoxforValue()
        {


            fromDate = (DateTime)txtfromdate.Value;
            toDate = (DateTime)txttodate.Value;
           


        }


    }
}
