using Bunifu.UI.WinForms.BunifuButton;
using Infragistics.Win.UltraWinToolbars;
using POS.BussinessModel;
using POS.Item;
using POS.Reports.CustomerLedger;
using POS.SettingSoft;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TMS;
using TMS.SettingBR;

namespace POS
{
    public partial class MainForm3 : Form
    {
        private UserModel Usermodel = new UserModel(); 
        public MainForm3(UserModel Usermodel)
        {
            InitializeComponent();
            this.Usermodel = Usermodel;
         
        }

        private void MainForm3_Load(object sender, EventArgs e)
        {
            Infragistics.Win.AppStyling.StyleManager.Load(FindPath() + POS.Properties.Settings.Default.Theme + ".isl");
            if (POS.Properties.Settings.Default.Language == 1)
                ConvertLanguage();
            //AdminSecurity();
            //DisableAllTabs();
            this.Text = "Point Of Sale Management System( Develope By Malak Software Developers)  ( Dedicated to : Muhammad and  Najeeb)  ( Current User LogIn :  " + POS.Properties.Settings.Default.username + " )";
            POS.Properties.Settings.Default.customerlist = (bool)Usermodel.customerlist;
            POS.Properties.Settings.Default.Save();
            POS.Properties.Settings.Default.itemlist = (bool)Usermodel.prodacclist;
            POS.Properties.Settings.Default.Save();
            POS.Properties.Settings.Default.supplierlist = (bool)Usermodel.supplierlist;
            POS.Properties.Settings.Default.Save();
            POS.Properties.Settings.Default.loanlist = (bool)Usermodel.branchlist;
            POS.Properties.Settings.Default.Save();

            if (!(bool)Usermodel.productFile)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Visible = false;


            }
            else
            {
                if (!(bool)Usermodel.prductstatus)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product File"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.productmaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product File"].Tools["btnProduct"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.productlist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product File"].Tools["ProductList"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.purchasestock)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductPurchase"].Visible = false;
                }
                else
                {
                    if (!(bool)Usermodel.purchasemaster)
                    {
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductPurchase"].Tools["Purchase Stock"].SharedProps.Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Tools["Supplier Purchase Stock"].SharedProps.Visible = false;
                    }
                    if (!(bool)Usermodel.purchaselist)
                    {
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductPurchase"].Tools["PurchaseList"].SharedProps.Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Tools["suppurchlist"].SharedProps.Visible = false;
                    }
                }
                if (!(bool)Usermodel.purchasereturn)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductReturn"].Visible = false;
                    this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Visible = false;
                }
                else
                {
                    if (!(bool)Usermodel.purchasereturnmaster)
                    {
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductReturn"].Tools["Purchaser Return"].SharedProps.Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Tools["supreturnstock"].SharedProps.Visible = false;
                    }
                    if (!(bool)Usermodel.purchasereturnlist)
                    {
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductReturn"].Tools["PurchaseReturnList"].SharedProps.Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Tools["supreturnlist"].SharedProps.Visible = false;
                    }
                }
                if (!(bool)Usermodel.prodaccount)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product Account"].Visible = false;
                    this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Visible = false;
                }
                else
                {
                    if (!(bool)Usermodel.prodaccmaster)
                    {
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product Account"].Tools["ProductAccountRec"].SharedProps.Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Tools["supaccountmast"].SharedProps.Visible = false;

                    }
                    if (!(bool)Usermodel.prodacclist)
                    {
                        this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product Account"].Tools["ProductAccountList"].SharedProps.Visible = false;
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Tools["supAccountlist"].SharedProps.Visible = false;
                    }
                }
                if (!(bool)Usermodel.prodreport)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Item Report"].Visible = false;
                    this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplieReport"].Visible = false;
                }
            }
            //-----------------Coding for the customer tab
            if (!(bool)Usermodel.customerFile)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Visible = false;

            }
            else
            {

                if (!(bool)Usermodel.customerstatus)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["Customer File"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.customermaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["Customer File"].Tools["New Customer"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.customerlist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["Customer File"].Tools["CustomerList"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.saleinvoice)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerTransaction"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.saleinvoicemaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerTransaction"].Tools["Sale Invoice"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.saleinvoicelist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerTransaction"].Tools["SaleInvoiceList"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.salereturn)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["SaleReturnTransaction"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.salereturnmaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["SaleReturnTransaction"].Tools["Sale Return"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.salereturnlist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["SaleReturnTransaction"].Tools["SaleReturnList"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.custaccount)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerAccount"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.custaccmaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerAccount"].Tools["customerAccountrec"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.custacclist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerAccount"].Tools["CustAccountList"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.customerreport)
                    this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerReport"].Visible = false;

            }
            //--------------------------Branch loan
            if (!(bool)Usermodel.branche)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Visible = false;

            }
            else
            {
                if (!(bool)Usermodel.branchstatus)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["Baranch File"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.branchmaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["Baranch File"].Tools["New Account"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.branchlist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["Baranch File"].Tools["LoanList"].SharedProps.Visible = false;

                }

                if (!(bool)Usermodel.transferin)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransaction"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.transferinmaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransaction"].Tools["Transfer In"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.transferinlist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransaction"].Tools["TransferInList"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.transferout)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransactionOut"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.transferoutmaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransactionOut"].Tools["Transfer Out"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.transferoutlist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransactionOut"].Tools["Transferoutlist"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.branchaccount)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["LoanAccount"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.branchaccmaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["LoanAccount"].Tools["BrachAccount"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.branchacclist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["LoanAccount"].Tools["BranchAccountList"].SharedProps.Visible = false;

                }
                if (!(bool)Usermodel.loanreport)
                    this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BranchReport"].Visible = false;
            }
            //--------------------------supplier code
            if (!(bool)Usermodel.supplier)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Visible = false;

            }
            else
            {
                if (!(bool)Usermodel.supplierstatus)
                {
                    this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierMaster"].Visible = false;

                }
                else
                {

                    if (!(bool)Usermodel.suppliermaster)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierMaster"].Tools["New Supplier"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.supplierlist)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierMaster"].Tools["SupplierList"].SharedProps.Visible = false;
                    if (!(bool)Usermodel.purchasestock)
                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Visible = false;
                    else
                    {
                        if (!(bool)Usermodel.purchasemaster)
                        {

                            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Tools["Supplier Purchase Stock"].SharedProps.Visible = false;
                        }
                        if (!(bool)Usermodel.purchaselist)
                        {

                            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Tools["suppurchlist"].SharedProps.Visible = false;
                        }
                    }
                    if (!(bool)Usermodel.purchasereturn)
                    {

                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Visible = false;
                    }
                    else
                    {
                        if (!(bool)Usermodel.purchasereturnmaster)
                        {

                            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Tools["supreturnstock"].SharedProps.Visible = false;
                        }
                        if (!(bool)Usermodel.purchasereturnlist)
                        {

                            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Tools["supreturnlist"].SharedProps.Visible = false;
                        }
                    }
                    if (!(bool)Usermodel.prodaccount)
                    {

                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Visible = false;
                    }
                    else
                    {
                        if (!(bool)Usermodel.prodaccmaster)
                        {

                            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Tools["supaccountmast"].SharedProps.Visible = false;

                        }
                        if (!(bool)Usermodel.prodacclist)
                        {

                            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Tools["supAccountlist"].SharedProps.Visible = false;
                        }
                    }
                    if (!(bool)Usermodel.prodreport)
                    {

                        this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplieReport"].Visible = false;
                    }
                }
            }
            //--------------Report coding
            if (!(bool)Usermodel.Report)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Visible = false;

            }
            if (!(bool)Usermodel.Setting)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Visible = false;

            }
            if (!(bool)Usermodel.Employee)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Visible = false;

            }
            if (!(bool)Usermodel.Expense)
            {
                this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Visible = false;

            }
        }
        //private void AdminSecurity()
        //{
        //    if(POS.Properties.Settings.Default.username!="ADMIN")
        //    {
        //        this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Visible = false; 
        //    }
        //}
        private void ConvertLanguage()
        {
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Caption = Language.Item;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product File"].Caption =Language.MasterFile;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product File"].Tools["btnProduct"].SharedProps.Caption =Language.NewItem;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product File"].Tools["ProductList"].SharedProps.Caption =Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductPurchase"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductPurchase"].Tools["Purchase Stock"].SharedProps.Caption = Language.PurchaseStock;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductPurchase"].Tools["PurchaseList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductReturn"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductReturn"].Tools["Purchaser Return"].SharedProps.Caption = Language.PurchaseReturn;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["ProductReturn"].Tools["PurchaseReturnList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product Account"].Caption = Language.Account;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product Account"].Tools["ProductAccountRec"].SharedProps.Caption = Language.AccountRecPay;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Product Account"].Tools["ProductAccountList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Item Report"].Caption = Language.Report;
            this.ultraToolbarsManager1.Ribbon.Tabs["Product"].Groups["Item Report"].Tools["btnsupplierledger"].SharedProps.Caption = Language.SupplierLedger;

            
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Caption = Language.Customer;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["Customer File"].Caption = Language.MasterFile;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["Customer File"].Tools["New Customer"].SharedProps.Caption = Language.NewCustomer;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["Customer File"].Tools["CustomerList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerTransaction"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerTransaction"].Tools["Sale Invoice"].SharedProps.Caption = Language.SaleInvoice;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerTransaction"].Tools["SaleInvoiceList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["SaleReturnTransaction"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["SaleReturnTransaction"].Tools["Sale Return"].SharedProps.Caption = Language.SaleReturn;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["SaleReturnTransaction"].Tools["SaleReturnList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerAccount"].Caption = Language.Account;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerAccount"].Tools["customerAccountrec"].SharedProps.Caption = Language.AccountRecPay;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerAccount"].Tools["CustAccountList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerReport"].Caption = Language.Report;
            this.ultraToolbarsManager1.Ribbon.Tabs["Customer"].Groups["CustomerReport"].Tools["btncustomerLedger"].SharedProps.Caption = Language.CustomerLedger;

            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Caption = Language.Branchloan;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["Baranch File"].Caption = Language.MasterFile;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["Baranch File"].Tools["New Account"].SharedProps.Caption = Language.newBranchloan;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["Baranch File"].Tools["LoanList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransaction"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransaction"].Tools["Transfer In"].SharedProps.Caption = Language.TransferIn;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransaction"].Tools["TransferInList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransactionOut"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransactionOut"].Tools["Transfer Out"].SharedProps.Caption = Language.TransferOut;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BaranchTransactionOut"].Tools["TrnasferoutList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["LoanAccount"].Caption = Language.Account;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["LoanAccount"].Tools["BrachAccount"].SharedProps.Caption = Language.AccountRecPay;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["LoanAccount"].Tools["BranchAccountList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BranchReport"].Caption = Language.Report;
            this.ultraToolbarsManager1.Ribbon.Tabs["Branches"].Groups["BranchReport"].Tools["LoanLedger"].SharedProps.Caption = Language.LoanLedger;

            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Caption = Language.Supplier;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierMaster"].Caption = Language.MasterFile;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierMaster"].Tools["New Supplier"].SharedProps.Caption = Language.NewSupplier;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierMaster"].Tools["SupplierList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Tools["Supplier Purchase Stock"].SharedProps.Caption = Language.PurchaseStock;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTrasactionPur"].Tools["suppurchlist"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Tools["supreturnstock"].SharedProps.Caption = Language.PurchaseReturn;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierTransactionout"].Tools["supreturnlist"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Caption = Language.Account;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Tools["supaccountmast"].SharedProps.Caption = Language.AccountRecPay;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplierAccount"].Tools["supAccountlist"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplieReport"].Caption = Language.Report;
            this.ultraToolbarsManager1.Ribbon.Tabs["Supplier"].Groups["SupplieReport"].Tools["SupplierLedger"].SharedProps.Caption = Language.SupplierLedger;

            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Caption = Language.Report;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["ReportLedger"].Caption = Language.Ledger;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["ReportLedger"].Tools["ReportCustomerLedger"].SharedProps.Caption = Language.CustomerLedger;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["ReportLedger"].Tools["ReportLoanLedger"].SharedProps.Caption = Language.LoanLedger;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["ReportLedger"].Tools["ReportSupplierLedger"].SharedProps.Caption = Language.SupplierLedger;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["Sale Report"].Caption = Language.SaleReport;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["Sale Report"].Tools["Sale Report"].SharedProps.Caption = Language.SaleReport;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["ReportExpenseReport"].Caption = Language.ExpenseReport;
            this.ultraToolbarsManager1.Ribbon.Tabs["Report"].Groups["ReportExpenseReport"].Tools["Expense Report"].SharedProps.Caption = Language.ExpenseReport;


            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Caption = Language.Setting;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["Basic Setting"].Caption = Language.BasicSetting;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["Basic Setting"].Tools["Basic Setting"].SharedProps.Caption = Language.BasicSetting;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["Backupandrestore"].Caption = Language.BackupAndRestor;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["Backupandrestore"].Tools["Backup"].SharedProps.Caption = Language.Backup;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["Backupandrestore"].Tools["Restore"].SharedProps.Caption = Language.Restore;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["User Master"].Caption = Language.UserMaster;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["User Master"].Tools["New User"].SharedProps.Caption = Language.NewUser;
            this.ultraToolbarsManager1.Ribbon.Tabs["Setting"].Groups["User Master"].Tools["UserList"].SharedProps.Caption = Language.Lists;

            this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Caption = Language.Employee;
            this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Groups["Employee File"].Caption = Language.MasterFile;
            this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Groups["Employee File"].Tools["Employee Master"].SharedProps.Caption = Language.NewEmployee;
            this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Groups["Employee File"].Tools["EmployeeList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Groups["Employee Payment"].Caption = Language.Transaction;
            this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Groups["Employee Payment"].Tools["EmployeePaymentMaster"].SharedProps.Caption = Language.NewEmployeePayment;
            this.ultraToolbarsManager1.Ribbon.Tabs["Employee"].Groups["Employee Payment"].Tools["EmpPayList"].SharedProps.Caption = Language.Lists;

            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Caption = Language.Expense;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["MenuMasterFile"].Caption = Language.MasterFile;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["MenuMasterFile"].Tools["New Menu"].SharedProps.Caption = Language.NewMenu;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["MenuMasterFile"].Tools["MenuList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["ExpenseMasterFile"].Caption = Language.MasterFile;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["ExpenseMasterFile"].Tools["New Expense"].SharedProps.Caption = Language.NewExpense;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["ExpenseMasterFile"].Tools["ExpenseList"].SharedProps.Caption = Language.Lists;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["ExpenseReport"].Caption = Language.ExpenseReport;
            this.ultraToolbarsManager1.Ribbon.Tabs["Expense"].Groups["ExpenseReport"].Tools["ExpenseReport"].SharedProps.Caption = Language.Report;
            //Toolbar item
            this.ultraToolbarsManager1.Ribbon.TabItemToolbar.Tools["ToolbarEdit"].SharedProps.Caption =Language.Edit;
            this.ultraToolbarsManager1.Ribbon.TabItemToolbar.Tools["ToolbarDelete"].SharedProps.Caption =Language.delete;

            this.ultraToolbarsManager1.Ribbon.FileMenuButtonCaption= Language.File;

            //Navigation Menu
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu2010.NavigationMenu.Tools["OpenEdit"].SharedProps.Caption = Language.Edit;
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu2010.NavigationMenu.Tools["btnExit"].SharedProps.Caption = Language.Exit;
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu2010.NavigationMenu.Tools["Pashtu"].SharedProps.Caption = Language.Pashtu;
            this.ultraToolbarsManager1.Ribbon.ApplicationMenu2010.NavigationMenu.Tools["applicationDelete"].SharedProps.Caption = Language.delete;
            
        }
        public string FindPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            //if (path.Contains("\\bin\\Release") || path.Contains("\\bin\\Debug"))
            //{
            //    path = path.Replace("\\bin\\Debug", "\\Resources\\Themes");


            //}
            //---------------------Path for build exe file---------------
            path = path + "Resources\\Themes\\";
            //MessageBox.Show(path);
            //------------------------------------
            return path;
        }
    
        private bool CheckFormExist(Type f)
        {
            foreach (Form form in Application.OpenForms)
            {
                // If frmHome is Opened, set focus to it and exit subroutine.
                if (form.GetType() == f)
                {

                    form.Activate();
                    return true ;
                }
            }
            return false;
        }
        private void OpenAndLoad()
        {
            Form tempChild = this.ActiveMdiChild;
            if (tempChild != null)
                foreach (var button in from Panel pnl in tempChild.Controls.OfType<Panel>()
                                       where pnl.Name == "panel3"//for button
                                       from BunifuButton button in pnl.Controls.OfType<BunifuButton>()
                                       where button.Name == "btnOpen"
                                       select button//For text box
                                                    //foreach (BunifuTextBox textBox in pnl.Controls.OfType<BunifuTextBox>())
                                                    //{
                                                    //    if (textBox.Name == "txtsearch")
                                                    //        textBox.Text = "OK";
                                                    //    //MessageBox.Show(button.Name);
                                                    //}
                )
                {
                    button.PerformClick();
                }
            //foreach (Panel pnl in tempChild.Controls.OfType<Panel>())
            //{
            //    if (pnl.Name == "panel3")
            //        //for button
            //        foreach (BunifuButton button in pnl.Controls.OfType<BunifuButton>())
            //        {
            //            if (button.Name == "btnOpen")
            //                button.PerformClick();

            //        }

        }
       
       
        private void UltraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
           
      
            switch (e.Tool.Key)
            {
                
                //
                case "btnProduct":    // ButtonTool
                    ItemMaster2 item = new ItemMaster2(null, "Save");
                    item.ShowDialog();
                    break;
                case "ProductList":
                    // Loop through all open forms...
                    if (CheckFormExist(typeof(ItemMain)))
                    {

                    }
                    else
                    {
                        ItemMain cust = new ItemMain();

                        cust.MdiParent = this;
                        cust.Show();
                    }


                    break; 
              
                case "Purchase Stock":
                    PurchaseMaster pm2 = new PurchaseMaster(null, "Save");
                    pm2.ShowDialog();
                    break;

                case "PurchaseList":   
                    if (CheckFormExist(typeof(PurchaseMain)))
                    {

                    }
                    else
                    {
                        PurchaseMain pumain2 = new PurchaseMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }            
                    break;

                case "Purchaser Return":    // ButtonTool
                    PurchaseReturnMaster pm3 = new PurchaseReturnMaster(null, "Save");
                    pm3.ShowDialog();                  // Place code here
                    break;

                case "PurchaseReturnList":    // ButtonTool
                    if (CheckFormExist(typeof(PurchaseReturnMain)))
                    {

                    }
                    else
                    {
                        PurchaseReturnMain pumain2 = new PurchaseReturnMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                           // Place code here
                    break;
                case "btnProductEdit":    // ButtonTool
                    OpenAndLoad();
                    break;

                case "btnProductDelete":
                    OpenAndLoad();
                    break;
                case "New Customer":    // ButtonTool
                    CustomerMaster pm4 = new CustomerMaster(null, "Save");
                    pm4.ShowDialog();                  // Place code here
                    break;

                case "CustomerList":    // ButtonTool
                    if (CheckFormExist(typeof(CustomerMain)))
                    {

                    }
                    else
                    {
                        CustomerMain pumain2 = new CustomerMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                           // Place code here
                    break;
                case "Sale Invoice":    // ButtonTool
                    SaleMaster pm5 = new SaleMaster(null, "Save");
                    pm5.ShowDialog();                  // Place code here
                    break;              // Place code here

                case "SaleInvoiceList":    // ButtonTool
                    if (CheckFormExist(typeof(SaleMain)))
                    {

                    }
                    else
                    {
                        SaleMain pumain2 = new SaleMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                      
                    break;

                case "Sale Return":    // ButtonTool
                    SaleReturnMaster p6 = new SaleReturnMaster(null,"Save");
                    p6.ShowDialog(); 
                    break;

                case "SaleReturnList":    // ButtonTool
                    if (CheckFormExist(typeof(SaleReturnMain)))
                    {

                    }
                    else
                    {
                        SaleReturnMain pumain2 = new SaleReturnMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                        // Place code here
                    break;

                case "CustomerEdit":    // ButtonTool
                    OpenAndLoad();              // Place code here
                    break;

                case "CustomerDelete":    // ButtonTool
                    OpenAndLoad();                // Place code here
                    break;

                case "New Account":    // ButtonTool
                    LoanMaster l2 = new LoanMaster(null, "Save");
                    l2.ShowDialog(); 
                    break;

                case "LoanList":    // ButtonTool
                    if (CheckFormExist(typeof(LoanMain)))
                    {

                    }
                    else
                    {
                        LoanMain pumain2 = new LoanMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;

                case "Transfer In":    // ButtonTool
                    TransferInMaster t2 = new TransferInMaster(null,"Save");
                    t2.ShowDialog(); 
                    break;

                case "TransferInList":    // ButtonTool
                    if (CheckFormExist(typeof(TransferInMain)))
                    {

                    }
                    else
                    {
                        TransferInMain pumain2 = new TransferInMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                   // Place code here
                    break;

                case "Transfer Out":    // ButtonTool
                    TransferOutMaster t3 = new TransferOutMaster(null, "Save");
                    t3.ShowDialog(); 
                    break;

                case "TrnasferoutList":    // ButtonTool
                    if (CheckFormExist(typeof(TransferOutMain)))
                    {

                    }
                    else
                    {
                        TransferOutMain pumain2 = new TransferOutMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                    
                    break;

                case "LoanEdit":    // ButtonTool
                    OpenAndLoad();              // Place code here

                    break;

                case "LoanDelete":    // ButtonTool
                    OpenAndLoad();              // Place code here

                    break;
                case "customerAccountrec":    // ButtonTool
                    CustomerAccountMaster mas = new CustomerAccountMaster(null,"Save");
                    mas.ShowDialog();// Place code here
                    break;

                case "CustACcountList":    // ButtonTool
                    if (CheckFormExist(typeof(CustomerAccountMain)))
                    {

                    }
                    else
                    {
                        CustomerAccountMain pumain2 = new CustomerAccountMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                         // Place code here
                    break;
                case "ProductAccountRec":    // ButtonTool
                    SupplierAccountMaster masd = new SupplierAccountMaster(null, "Save");
                    masd.ShowDialog();
                    break;

                case "ProductAccountList":    // ButtonTool
                    if (CheckFormExist(typeof(SupplierAccountMain)))
                    {

                    }
                    else
                    {
                        SupplierAccountMain pumain2 = new SupplierAccountMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;

                case "BrachAccount":    // ButtonTool
                    LoanAccountMaster massd = new LoanAccountMaster(null, "Save");
                    massd.ShowDialog();
                    break;

                case "BranchAccountList":    // ButtonTool
                    if (CheckFormExist(typeof(LoanAccountMain)))
                    {

                    }
                    else
                    {
                        LoanAccountMain pumain2 = new LoanAccountMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;
                case "New Supplier":    // ButtonTool
                     SupplierMaster sup = new SupplierMaster(null, "Save");
                    sup.ShowDialog();
                    break;

                case "Supplierlist":    // ButtonTool
                    if (CheckFormExist(typeof(SupplierMain)))
                    {

                    }
                    else
                    {
                        SupplierMain pumain2 = new SupplierMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;

                case "Supplier Purchase Stock":    // ButtonTool
                    PurchaseMaster pmt = new PurchaseMaster(null, "Save");
                    pmt.ShowDialog();
                  

                    break;

                case "suppurchlist":    // ButtonTool
                    if (CheckFormExist(typeof(PurchaseMain)))
                    {

                    }
                    else
                    {
                        PurchaseMain pumain2 = new PurchaseMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;

                case "supreturnstock":    // ButtonTool
                    PurchaseReturnMaster pms3 = new PurchaseReturnMaster(null, "Save");
                    pms3.ShowDialog();                 // Place code here
                    break;

                case "supreturnlist":    // ButtonTool
                    if (CheckFormExist(typeof(PurchaseReturnMain)))
                    {

                    }
                    else
                    {
                        PurchaseReturnMain pumain2 = new PurchaseReturnMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                           
                    break;

                case "supaccountmast":    // ButtonTool
                    SupplierAccountMaster spamast = new SupplierAccountMaster(null,"Save");
                    spamast.ShowDialog();
                    break;

                case "supAccountlist":    // ButtonTool
                    if (CheckFormExist(typeof(SupplierAccountMain)))
                    {

                    }
                    else
                    {
                        SupplierAccountMain pumain2 = new SupplierAccountMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                                 // Place code here
                    break;

                case "supEdit":    // ButtonTool
                    OpenAndLoad();               // Place code here
                    break;

                case "SupDelete":    // ButtonTool
                    OpenAndLoad();                // Place code here
                    break;
                case "Basic Setting":    // ButtonTool
                    SoftwareSetting sd = new SoftwareSetting();
                    sd.ShowDialog();
                    break;

                case "Backup":    // ButtonTool
                    BackupForm backi = new BackupForm();
                    backi.ShowDialog();
                    break;

                case "Restore":    // ButtonTool
                    RestoreForm restore = new RestoreForm();
                    restore.ShowDialog();
                    break;


                case "btnExit":    // ButtonTool
                    Application.Exit();          // Place code here
                    break;
                case "Theme 01":    // ButtonTool
                    POS.Properties.Settings.Default.Theme = e.Tool.Key;
                    POS.Properties.Settings.Default.Save();
                    Infragistics.Win.AppStyling.StyleManager.Load(FindPath() + POS.Properties.Settings.Default.Theme + ".isl");

                    break;

                case "Theme 02":    // ButtonTool
                    POS.Properties.Settings.Default.Theme = e.Tool.Key;
                    POS.Properties.Settings.Default.Save();
                    Infragistics.Win.AppStyling.StyleManager.Load(FindPath() + POS.Properties.Settings.Default.Theme + ".isl");             // Place code here
                    break;

                case "Theme 03":    // ButtonTool
                    POS.Properties.Settings.Default.Theme = e.Tool.Key;
                    POS.Properties.Settings.Default.Save();
                    Infragistics.Win.AppStyling.StyleManager.Load(FindPath() + POS.Properties.Settings.Default.Theme + ".isl");         // Place code here
                    break;

                case "Theme 04":    // ButtonTool
                    POS.Properties.Settings.Default.Theme = e.Tool.Key;
                    POS.Properties.Settings.Default.Save();
                    Infragistics.Win.AppStyling.StyleManager.Load(FindPath() + POS.Properties.Settings.Default.Theme + ".isl");           // Place code here
                    break;
                case "Pashtu":    // ButtonTool
                    if (Confirm("Changing the language of the application it must close", "Close Application") == DialogResult.Yes)
                    {
                        POS.Properties.Settings.Default.Language = 1;
                        POS.Properties.Settings.Default.Save();
                        Application.Exit();
                    }
                    break;

                case "English":    // ButtonTool
                    if (Confirm("Changing the language of the application it must close", "Close Application") == DialogResult.Yes)
                    {
                        POS.Properties.Settings.Default.Language = 0;
                        POS.Properties.Settings.Default.Save();
                        Application.Exit();
                    }
                    break;
                case "OpenEdit":    // ButtonTool
                    OpenAndLoad();     
                    break;
                case "ToolbarEdit":    // ButtonTool
                    OpenAndLoad();
                    break;
                case "ToolbarDelete":    // ButtonTool
                    OpenAndLoad();                     // Place code here
                    break;

                case "applicationDelete":    // ButtonTool
                    OpenAndLoad();           // Place code here
                    break;
                case "btnsupplierledger":    // ButtonTool
                    SupplierLedger sup2 = new SupplierLedger();
                    sup2.ShowDialog();// Place code here
                    break;
                case "btncustomerLedger":    // ButtonTool
                    CustomerLedger2 cus = new CustomerLedger2();
                    cus.ShowDialog();

                    break;
                case "LoanLedger":    // ButtonTool
                    LoanLedger cuqs = new LoanLedger();
                    cuqs.ShowDialog();

                    break;
                case "SupplierLedger":    // ButtonTool
                    SupplierLedger sup3= new SupplierLedger();
                    sup3.ShowDialog();

                    break;
                case "ReportCustomerLedger":    // ButtonTool
                    CustomerLedger2 s1 = new CustomerLedger2();
                    s1.ShowDialog(); 
                    break;

                case "ReportLoanLedger":    // ButtonTool
                    LoanLedger s2 = new LoanLedger();
                    s2.ShowDialog();
                    break;

                case "ReportSupplierLedger":    // ButtonTool
                    SupplierLedger s3 = new SupplierLedger();
                    s3.ShowDialog(); 
                    break;

                case "Sale Report":    // ButtonTool
                    SaleReport2 s4 = new SaleReport2();
                    s4.ShowDialog();// Place code here
                    break;

                case "New User":    // ButtonTool
                    UserMaster user = new UserMaster(null,"Save");
                    user.ShowDialog(); 
                    break;

                case "UserList":    // ButtonTool
                    if (CheckFormExist(typeof(UserMain)))
                    {

                    }
                    else
                    {
                        UserMain pumain2 = new UserMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }                         // Place code here
                    break;
                case "Employee Master":    // ButtonTool
                    EmployeeMaster emp2 = new EmployeeMaster(null, "Save");
                    emp2.ShowDialog();              
                    break;

                case "EmployeeList":    // ButtonTool
                    if (CheckFormExist(typeof(EmployeeMain)))
                    {

                    }
                    else
                    {
                        EmployeeMain pumain2 = new EmployeeMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }  
                    break;

                case "EmployeePaymentMaster":    // ButtonTool
                    EmployeePaymentMaster emp3 = new EmployeePaymentMaster(null, "Save");
                    emp3.ShowDialog();
                    break;

                case "EmpPayList":    // ButtonTool
                    if (CheckFormExist(typeof(EmployeePaymentMain)))
                    {

                    }
                    else
                    {
                        EmployeePaymentMain pumain2 = new EmployeePaymentMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;             // Place code here
                case "New Menu":    // ButtonTool
                    ExpenseMenuMaster emp5 = new ExpenseMenuMaster(null, "Save");
                    emp5.ShowDialog();
                    break;

                case "MenuList":    // ButtonTool
                    if (CheckFormExist(typeof(ExpenseMenuMain)))
                    {

                    }
                    else
                    {
                        ExpenseMenuMain pumain2 = new ExpenseMenuMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;

                case "New Expense":    // ButtonTool
                    ExpenseMaster emp8 = new ExpenseMaster(null, "Save");
                    emp8.ShowDialog();               // Place code here
                    break;

                case "ExpenseList":    // ButtonTool
                    if (CheckFormExist(typeof(ExpenseMain)))
                    {

                    }
                    else
                    {
                        ExpenseMain pumain2 = new ExpenseMain();

                        pumain2.MdiParent = this;
                        pumain2.Show();
                    }
                    break;

                case "ExpenseReport":    // ButtonTool
                    POS.Reports.CustomerLedger.ExpenseReportForm exp3 = new POS.Reports.CustomerLedger.ExpenseReportForm();
                    exp3.ShowDialog();
                    break;
                case "Expense Report":    // ButtonTool
                    POS.Reports.CustomerLedger.ExpenseReportForm exp4 = new POS.Reports.CustomerLedger.ExpenseReportForm();
                    exp4.ShowDialog();                  // Place code here
                    break;

                case "Summary2":    // ButtonTool
                    Summary sum12 = new Summary();
                    sum12.ShowDialog(); 
                    break;




            }
        }
        private DialogResult Confirm(string m, string t)
        {
            DialogResult dr = MessageBox.Show(m, t, MessageBoxButtons.YesNo);
            return dr;
        }
    }
}
