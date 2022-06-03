using CrystalDecisions.CrystalReports.Engine;
using POS.TransactionFile.SaleReturn;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.Item
{
    public partial class SaleReturnReportForm : Form
    {

        ReportClass rp;
        DataSet1 ds; 
        public SaleReturnReportForm(DataSet s)
        {
            InitializeComponent();
            ds = (DataSet1)s;
        }

        private void ItemReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (POS.Properties.Settings.Default.Language == 1)
                    rp = new SaleReturnOrderReportsPashtu();
                else
                rp = new SaleReturnOrderReports();

                rp.SetDataSource(ds.Tables["tbl_Invoice"]);
                rp.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
                rp.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
                rp.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
                rp.SetParameterValue("@user", POS.Properties.Settings.Default.username);
                rp.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);




                crystalReportViewer1.ReportSource = rp;

                crystalReportViewer1.Refresh();
                //crystalReportViewer1.DataBind();
                //crystalReportViewer1.SeparatePages = false;

                //crystalReportViewer1.setDisplayMode(DisplayMode.PrintLayout);

                //rp.Close();
                //crystalReportViewer1.DisplayToolbar = true;

            }
            catch (Exception)
            {

            }

        }

        private void CrystalReportViewer1_Navigate(object source, CrystalDecisions.Windows.Forms.NavigateEventArgs e)
        {
              rp.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
            rp.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
            rp.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
            rp.SetParameterValue("@user", POS.Properties.Settings.Default.username);
            rp.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);
        }
    }
}
