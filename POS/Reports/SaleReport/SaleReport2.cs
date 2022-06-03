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
    public partial class SaleReport2 : Form
    {
        private SaleReportLayer layer;
        public SaleReport2()
        {
            InitializeComponent();
            layer = new SaleReportLayer();
        }
        private void CustomerLedger2_Load(object sender, EventArgs e)
        {

            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            btnprint.Text = Language.print;
            btnpreview.Text = Language.Preview;
            lbltitle.Text = "د خرڅلاو راپور";
            this.Text = "د خرڅلاو راپور";

            lblfrom.Text = Language.From;
            lblto.Text = Language.To;
            rdbcostPrice.Text = Language.cp;
            rdbretailprice.Text = Language.rp;
            rdbtp.Text = Language.tp;

        }
       
        private DateTime fromDate { get; set; }
        private DateTime toDate { get; set; }


        private void Btnpreview_Click(object sender, EventArgs e)
        {

            ChecktextBoxforValue();
            layer.LoadDataForPreview("Preview",rdbPrice, fromDate, toDate);

        }
        public string rdbPrice { get; set; }
        private void ChecktextBoxforValue()
        {


            fromDate = (DateTime)txtfromdate.Value;
            toDate = (DateTime)txttodate.Value;
            if (rdbcostPrice.Checked)
                rdbPrice = "CP";
            else if (rdbretailprice.Checked)
                rdbPrice = "RP";
            else
                rdbPrice = "TP";


        }

        private void Btnprint_Click(object sender, EventArgs e)
        {

            ChecktextBoxforValue();
            layer.LoadDataForPreview("Print", rdbPrice, fromDate, toDate);
        }

        private void Btnword_Click(object sender, EventArgs e)
        {

            ChecktextBoxforValue();
            layer.LoadDataForPreview("Word", rdbPrice, fromDate, toDate);
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {

            ChecktextBoxforValue();
            layer.LoadDataForPreview("Excel", rdbPrice, fromDate, toDate);

        }

    }
}
