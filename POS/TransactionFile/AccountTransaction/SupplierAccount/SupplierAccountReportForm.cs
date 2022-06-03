using CrystalDecisions.CrystalReports.Engine;
using POS.TransactionFile.AccountTransaction.SupplierAccount;
using System;
using System.Data;
using System.Windows.Forms;

namespace POS.Item
{
    public partial class SupplierAccountReportForm : Form
    {

        ReportClass rp;
        DataSet1 ds; 
        public SupplierAccountReportForm(DataSet s)
        {
            InitializeComponent();
            ds = (DataSet1)s;
        }

        private void ItemReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (POS.Properties.Settings.Default.Language == 1)
                    rp = new SupplierAccountOrderReportsPashtu(); 
                else
                rp = new SupplierAccountOrderReports();

                rp.SetDataSource(ds.Tables["tbl_Account"]);
                rp.SetParameterValue("@Header", POS.Properties.Settings.Default.TopTitle);
                rp.SetParameterValue("@OwnerPhone", POS.Properties.Settings.Default.Phone);
                rp.SetParameterValue("@OwnerAddress", POS.Properties.Settings.Default.Address);
                rp.SetParameterValue("@user", POS.Properties.Settings.Default.username);
                rp.SetParameterValue("@Email", POS.Properties.Settings.Default.Email);




                crystalReportViewer1.ReportSource = rp;

                crystalReportViewer1.Refresh();
              

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
