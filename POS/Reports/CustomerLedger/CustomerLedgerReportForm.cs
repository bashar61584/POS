using CrystalDecisions.CrystalReports.Engine;
using MDS.Customer;
using POS.Reports.CustomerLedger;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.Customer
{
    public partial class CustomerLedgerReportForm : Form
    {
        DateTime fromDate;
        DateTime toDate;
        decimal debit;
        decimal credit; 
        DataSet1 ds;




        public CustomerLedgerReportForm(
            DateTime fromDate, DateTime toDate,
            decimal credit, decimal debit,DataSet s)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.debit = debit;
            this.credit = credit;
            ds = (DataSet1)s;
        }


        ReportClass rp2; 
    
        private void CustomerReportForm_Load(object sender, EventArgs e)
        {
            if (POS.Properties.Settings.Default.Language == 1)
                rp2 = new CustomerLedgerReportPashtu();
            else
                rp2 = new CustomerLedgerReport();

              rp2.SetDataSource(ds.Tables["tbl_CustomerLedger"]);
                rp2.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
                rp2.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
                rp2.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
                rp2.SetParameterValue("@user", POS.Properties.Settings.Default.username);
                rp2.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);
                rp2.SetParameterValue("@fromdate", fromDate);
                rp2.SetParameterValue("@todate", toDate);
                rp2.SetParameterValue("@debit", debit);
                rp2.SetParameterValue("@credit", credit);




                crystalReportViewer1.ReportSource = rp2;
                crystalReportViewer1.Refresh();




        }

        private void crystalReportViewer1_Navigate(object source, CrystalDecisions.Windows.Forms.NavigateEventArgs e)
        {

            rp2.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
            rp2.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
            rp2.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
            rp2.SetParameterValue("@user", POS.Properties.Settings.Default.username);
            rp2.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);


        }
    }
}
