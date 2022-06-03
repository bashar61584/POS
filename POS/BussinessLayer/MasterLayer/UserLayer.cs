using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using POS;
using POS.BussinessModel;
using System.Data.Entity;
using POS.Item;
using POS.SettingSoft;

namespace MDS.Customer
{
    class UserLayer
    {
        private ModelContext db; 
        public UserLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, UserModel model )
        {
            int result = 0;
            if (txtcode==string.Empty)
            {
                db.UserModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.user_id = Convert.ToInt32(txtcode);
                var ItemINDB = db.UserModels.Find(model.user_id);
                db.Entry(ItemINDB).CurrentValues.SetValues(model);
                //db.Entry(model).State = EntityState.Modified;
                result=db.SaveChanges();
            }
            return result;
            
        }

        internal int DeleteFnc(string txtcode)
        {
            int result = 0;
            try
            {

                UserModel model = db.UserModels.Find(Convert.ToInt32(txtcode));
                db.UserModels.Remove(model);
                result = db.SaveChanges();

        
            }
            catch (Exception)
            {


            }
            return result;
        }
        internal DataTable LoadGridView(string state)
        {
            if(state=="Update")
            db = new ModelContext();
            DataTable da = new DataTable();

            var mod = db.UserModels.ToList().OrderByDescending(x => x.user_id);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add(Language.code);
                da.Columns.Add(Language.Name);
                da.Columns.Add(Language.Password);
                da.Columns.Add(Language.active, typeof(bool));


            }
            else
            {
                da.Columns.Add("Code");
                da.Columns.Add("Name");
                da.Columns.Add("Password");
                da.Columns.Add("Status", typeof(bool));

                //da.Columns.Add("productFile", typeof(bool));
                //da.Columns.Add("prductstatus", typeof(bool));
                //da.Columns.Add("productmaster", typeof(bool));
                //da.Columns.Add("productlist", typeof(bool));
                //da.Columns.Add("purchasestock", typeof(bool));
                //da.Columns.Add("purchasemaster", typeof(bool));
                //da.Columns.Add("purchaselist", typeof(bool));
                //da.Columns.Add("purchasereturn", typeof(bool));
                //da.Columns.Add("purchasereturnmaster", typeof(bool));
                //da.Columns.Add("purchasereturnlist", typeof(bool));
                //da.Columns.Add("prodaccount", typeof(bool));
                //da.Columns.Add("prodaccmaster", typeof(bool));
                //da.Columns.Add("prodacclist", typeof(bool));
                //da.Columns.Add("prodreport", typeof(bool));
                //da.Columns.Add("customerFile", typeof(bool));
                //da.Columns.Add("customerstatus", typeof(bool));
                //da.Columns.Add("customermaster", typeof(bool));
                //da.Columns.Add("customerlist", typeof(bool));
                //da.Columns.Add("saleinvoice", typeof(bool));
                //da.Columns.Add("saleinvoicemaster", typeof(bool));
                //da.Columns.Add("saleinvoicelist", typeof(bool));
                //da.Columns.Add("salereturn", typeof(bool));
                //da.Columns.Add("salereturnmaster", typeof(bool));
                //da.Columns.Add("salereturnlist", typeof(bool));
                //da.Columns.Add("custaccount", typeof(bool));
                //da.Columns.Add("custaccmaster", typeof(bool));
                //da.Columns.Add("custacclist", typeof(bool));
                //da.Columns.Add("customerreport", typeof(bool));
                //da.Columns.Add("branche", typeof(bool));
                //da.Columns.Add("branchstatus", typeof(bool));
                //da.Columns.Add("branchmaster", typeof(bool));
                //da.Columns.Add("branchlist", typeof(bool));
                //da.Columns.Add("transferin", typeof(bool));
                //da.Columns.Add("transferinmaster", typeof(bool));
                //da.Columns.Add("transferinlist", typeof(bool));
                //da.Columns.Add("transferout", typeof(bool));
                //da.Columns.Add("transferoutmaster", typeof(bool));
                //da.Columns.Add("transferoutlist", typeof(bool));
                //da.Columns.Add("branchaccount", typeof(bool));
                //da.Columns.Add("branchaccmaster", typeof(bool));
                //da.Columns.Add("branchacclist", typeof(bool));
                //da.Columns.Add("loanreport", typeof(bool));
                //da.Columns.Add("supplier", typeof(bool));
                //da.Columns.Add("supplierstatus", typeof(bool));
                //da.Columns.Add("suppliermaster", typeof(bool));
                //da.Columns.Add("supplierlist", typeof(bool));
                //da.Columns.Add("Report", typeof(bool));
                //da.Columns.Add("Employee", typeof(bool));
                //da.Columns.Add("Expense", typeof(bool));
                //da.Columns.Add("Setting", typeof(bool));

            }
            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0]     = item.user_id;
                row[1]     = item.user_name;
                row[2] = item.user_password;
                row[3]    = item.status;


                da.Rows.Add(row);
            }
            return da;
        }

        internal UserModel loadTempConstraints(int id)
        {
            var mod=db.UserModels.SingleOrDefault(x=>x.user_id==id);
            return mod; 
        }

        internal void RetrieveReport(string p)
        {
            
            DataSet1 ds = new DataSet1();
            var mod = db.CustomerModels.ToList();
            foreach (var item in mod)
            {
                DataRow row = ds.Tables["tbl_customer"].NewRow();
                row["Code"] = item.Cu_ID;
                row["Name"] = item.Name;
                row["Address"] = item.Address1;
                row["Phone 1"] = item.phone1;
                row["Phone 2"] = item.phone2;
                row["Address2"] = item.Address2;
                row["Fax"] = item.fax;
                row["Email"] = item.email;
                row["Website"] = item.website;
                row["Licence"] = item.licence;
                row["Remark"] = item.remark;
              
                ds.Tables["tbl_customer"].Rows.Add(row);
            }
            switch (p)
            {

                case "Preview":
                    CustomerReportForm obj = new CustomerReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    CustomerOtherReport orp = new CustomerOtherReport(p,ds);

                    break;
                case "Word":
                    CustomerOtherReport orp2 = new CustomerOtherReport(p, ds);

                    break;
                case "Excel":
                    CustomerOtherReport orp3 = new CustomerOtherReport(p, ds);

                    break;
                    //case "Email":
                    //    EmailForm obj3 = new EmailForm(ds, this.Text);
                    //    obj3.ShowDialog();
                    //    break;
                    //case "Word":
                    //    MDS.Formula.OrderOtherReport obj4 = new MDS.Formula.OrderOtherReport(ds, p);
                    //    break;

            }
        }
        internal int CheckDuplication(string name)
        {
            int da = 0;
            var mod = db.UserModels.SingleOrDefault(x=>x.user_name==name);
            if(mod!=null)
            {
                da = 1;
            }
            return da;
        }

    }

}
