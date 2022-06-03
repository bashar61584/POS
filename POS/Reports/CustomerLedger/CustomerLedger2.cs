﻿using Infragistics.Win.UltraWinEditors;
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
    public partial class CustomerLedger2 : Form
    {
        private CustomerLedgerLayer2 layer; 
        public CustomerLedger2()
        {
            InitializeComponent();
            layer = new CustomerLedgerLayer2(); 
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
            CustomerMain obj = new CustomerMain("ForSearchOnly");
            obj.ShowDialog();
            if (obj.customermodel != null)
            {
                txtcode.Text = obj.customermodel.Cu_ID.ToString();
                txtname.Text = obj.customermodel.Name.ToString();
                txtaddress.Text = obj.customermodel.Address1.ToString();
                txtphone.Text = obj.customermodel.phone1.ToString();

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
            lbltitle.Text = "د پیرودونکی لیډګر";
            this.Text = "د پیرودونکی لیډګر";
            rdball.Text = Language.All;
            rdbbetweendate.Text = Language.BetweenDate;
            lblfrom.Text = Language.From;
            lblto.Text = Language.To;
            lblname.Text = Language.Name;
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
            if (CheckForEmpty())
            {
                ChecktextBoxforValue();
               layer.LoadDataForPreview("Preview", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            }
        }
        private bool CheckForEmpty()
        {
            if (txtname.Text == string.Empty)
            {
                MessageBox.Show("Please Select A Customer");
                txtcode.Focus();
                return false;
            }
            return true;
        }
        private void ChecktextBoxforValue()
        {
            if (txtcode.Text != string.Empty)
            {
                getTextBoxValue = txtcode.Text;
            }
            else
            {
                getTextBoxValue = "";

            }

            fromDate =(DateTime) txtfromdate.Value;
            toDate = (DateTime)txttodate.Value;
        }

        private void Btnprint_Click(object sender, EventArgs e)
        {
            if (CheckForEmpty())
            {
                ChecktextBoxforValue();
                layer.LoadDataForPreview("Print", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            }
        }

        private void Btnword_Click(object sender, EventArgs e)
        {
            if (CheckForEmpty())
            {
                ChecktextBoxforValue();
                layer.LoadDataForPreview("Word", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            }
        }

        private void Btnexcel_Click(object sender, EventArgs e)
        {
            if (CheckForEmpty())
            {
                ChecktextBoxforValue();
                layer.LoadDataForPreview("Excel", Convert.ToInt32(getTextBoxValue), getradiobuttonvalue, fromDate, toDate);
            }
        }

        private void Txtcode_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (txtcode.Focused)
                loadSearchFormSupplier();
        }
    }
}
