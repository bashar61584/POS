using POS.Item;
using POS.SettingSoft;
using System;
using System.Windows.Forms;

namespace POS.Reports.CustomerLedger
{
    public partial class ExpenseReportForm : Form
    {
        private ExpenseReportLayer layer; 
        public ExpenseReportForm()
        {
            InitializeComponent();
            layer = new ExpenseReportLayer(); 
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
               
                case Keys.Control | Keys.Space:
                    Txtcode_EditorButtonClick(new object(),  null);
                    break;
              
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void loadSearchFormSupplier()
        {
            ExpenseMenuMain obj = new ExpenseMenuMain("ForSearchOnly");
            obj.ShowDialog();
            if (obj.ExpenseMenuModel != null)
            {
                txtcode.Text = obj.ExpenseMenuModel.EXPMENU_ID.ToString();
                txtname.Text = obj.ExpenseMenuModel.Name.ToString();

            }
        }


        private void CustomerLedger2_Load(object sender, EventArgs e)
        {
            getradiobuttonvalue = rdball.Name;
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
        }
        private void ConvertLanguage()
        {
            btnprint.Text = Language.print;
            btnpreview.Text = Language.Preview;
            lbltitle.Text = "د لګښتونو راپور";
            this.Text = "د لګښتونو راپور";
            rdball.Text = Language.All;
            rdbbetweendate.Text = Language.BetweenDate;
            lblfrom.Text = Language.From;
            lblto.Text = Language.To;
            lblname.Text = Language.Menu;
        }
        private string getradiobuttonvalue { get; set; }
        private string getTextBoxValue { get; set; }
        private DateTime fromDate { get; set; }
        private DateTime toDate { get; set; }
        private void Rdball_CheckedChanged(object sender, EventArgs e)
        {
            if (rdball.Checked)
            {
                gpbxDate.Visible = false;
                getradiobuttonvalue = rdball.Text;
            }
            else
            {
                gpbxDate.Visible = true;
                getradiobuttonvalue = rdbbetweendate.Text;
            }
           
        }

        private void Btnpreview_Click(object sender, EventArgs e)
        {
            
                ChecktextBoxforValue();
               layer.LoadDataForPreview("Preview", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            
        }
      
        private void ChecktextBoxforValue()
        {
            if (txtcode.Text != string.Empty)
            {
                getTextBoxValue = txtcode.Text;
            }
            else
            {
                getTextBoxValue = "0";

            }

            fromDate =(DateTime) txtfromdate.Value;
            toDate = (DateTime)txttodate.Value;
        }

        private void Btnprint_Click(object sender, EventArgs e)
        {
           
                ChecktextBoxforValue();
                layer.LoadDataForPreview("Print", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            
        }

        private void Btnword_Click(object sender, EventArgs e)
        {
           
                ChecktextBoxforValue();
                layer.LoadDataForPreview("Word", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
           
                ChecktextBoxforValue();
                layer.LoadDataForPreview("Excel", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            
        }

        private void Txtcode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (txtcode.Focused)
                loadSearchFormSupplier();
        }
    }
}
