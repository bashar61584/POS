
using CrystalDecisions.CrystalReports.Engine;
using MDS;
using MDS.Customer;
using POS.Reports.SaleReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Customer
{
    public partial class SalesReportReportForm : Form
    {
        
        DataSet1 ds;
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }

        public SalesReportReportForm(DataSet s,DateTime fromd, DateTime tod)
        {
            InitializeComponent();
            ds = (DataSet1)s;
            fromdate = fromd;
            todate = tod; 
        }


        ReportClass rp;

        private void CustomerReportForm_Load(object sender, EventArgs e)
        {

            try
            {
                if (POS.Properties.Settings.Default.Language == 1)
                    rp = new SalesReportPashtu();
                else
                    rp = new SalesReport();
                rp.SetDataSource(ds.Tables["tbl_SalesReport"]);
                rp.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
                rp.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
                rp.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
                rp.SetParameterValue("@user", POS.Properties.Settings.Default.username);
                rp.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);
                rp.SetParameterValue("@fromdate", fromdate);
                rp.SetParameterValue("@todate", todate);

                crystalReportViewer1.ReportSource = rp;

            }
            catch (Exception)
            {

            }
        }

        private void crystalReportViewer1_Navigate(object source, CrystalDecisions.Windows.Forms.NavigateEventArgs e)
        {

            rp.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
            rp.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
            rp.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
            rp.SetParameterValue("@user", POS.Properties.Settings.Default.username);
            rp.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);


        }
    }
}
