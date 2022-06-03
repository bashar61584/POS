using MDS;
using POS.BussinessModel;
using POS.BussinessModel.MasterModel;
using POS.BussinessModel.TransactionModel.AccountModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class ModelContext:DbContext
    {
        public ModelContext():base(Connection.connection)
        {
        }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<ItemModel>  ItemModels{ get; set; }
        public DbSet<SupplierModel>  SupplierModels{ get; set; }
        public DbSet<CustomerModel>  CustomerModels{ get; set; }
        public DbSet<PurchaseOrderModel> purchaseOrderModels{ get; set; }
        public DbSet<PurchaseInvoiceModel> PurchaseInvoiceModels{ get; set; }
        public DbSet<PurchaseAccountModel> PurchaseAccountModels { get; set; }
        public DbSet<PurchaseReturnOrderModel> purchaseReturnOrderModels { get; set; }
        public DbSet<PurchaseReturnInvoiceModel> PurchaseReturnInvoiceModels { get; set; }
        public DbSet<SaleOrderModel> SaleOrderModels { get; set; }
        public DbSet<SaleInvoiceModel> SaleInvoiceModels { get; set; }
        public DbSet<SaleAccountModel> SaleAccountModels { get; set; }
        public DbSet<SaleReturnOrderModel> SaleReturnOrderModels { get; set; }
        public DbSet<SaleReturnInvoiceModel> SaleReturnInvoiceModels { get; set; }
        public DbSet<LoanModel> LoanModels { get; set; }
        public DbSet<TransferInOrderModel> TransferInOrderModels { get; set; }
        public DbSet<TransferInInvoiceModel> TransferInInvoiceModels { get; set; }
        public DbSet<TransferInAccountModel> TransferInAccountModels { get; set; }
        public DbSet<TransferOutOrderModel> TransferOutOrderModels { get; set; }
        public DbSet<TransferOutInvoiceModel> TransferOutInvoiceModels { get; set; }
        public DbSet<CustomerAccountOrderModel> CustomerAccountOrderModels { get; set; }
        public DbSet<SupplierAccountOrderModel> SupplierAccountOrderModels { get; set; }
        public DbSet<LoanAccountOrderModel> LoanAccountOrderModels { get; set; }
        public DbSet<DesignationModel> DesignationModels{ get; set; }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<EmployeePaymentModel> EmployeePaymentModels { get; set; }
        public DbSet<ExpenseMenuModel> ExpenseMenuModels { get; set; }
        public DbSet<ExpenseOrderModel> ExpenseOrderModels { get; set; }
        public DbSet<ExpenseInvoiceModel> ExpenseInvoiceModels { get; set; }



    }
}
