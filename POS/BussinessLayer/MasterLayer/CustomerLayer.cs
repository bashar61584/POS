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
    class CustomerLayer
    {
        private ModelContext db; 
        public CustomerLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, CustomerModel model )
        {
            int result = 0;
            if (txtcode==string.Empty)
            {
                db.CustomerModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.Cu_ID = Convert.ToInt32(txtcode);
                model.user_id = Convert.ToInt32(POS.Properties.Settings.Default.userid);
                var ItemINDB = db.CustomerModels.Find(model.Cu_ID);
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

                CustomerModel model = db.CustomerModels.Find(Convert.ToInt32(txtcode));
                db.CustomerModels.Remove(model);
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

            var mod = db.CustomerModels.Include(u => u.UserModels).ToList().OrderByDescending(x => x.Cu_ID);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add(Language.code);
                da.Columns.Add(Language.Name);
                da.Columns.Add(Language.Phone1);
                da.Columns.Add(Language.Phone2);
                da.Columns.Add(Language.Address1);
                da.Columns.Add(Language.Address2);
                da.Columns.Add(Language.Fax);
                da.Columns.Add(Language.Email);
                da.Columns.Add(Language.Website);
                da.Columns.Add(Language.Licence);
                da.Columns.Add(Language.Remark);
                da.Columns.Add(Language.active, typeof(bool));
                da.Columns.Add(Language.user);
                da.Columns.Add("user_id");

            }
            else
            {
                da.Columns.Add("Code");
                da.Columns.Add("Name");
                da.Columns.Add("Phone 1");
                da.Columns.Add("Phone 2");
                da.Columns.Add("Address");
                da.Columns.Add("Address2");
                da.Columns.Add("Fax");
                da.Columns.Add("Email");
                da.Columns.Add("website");
                da.Columns.Add("licence");
                da.Columns.Add("remark");
                da.Columns.Add("Status", typeof(bool));
                da.Columns.Add("User");
                da.Columns.Add("user_id");
            }
            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0]     = item.Cu_ID;
                row[1]     = item.Name;
                row[2] = item.phone1;
                row[3] = item.phone2;
                row[4] = item.Address1;
                row[5] = item.Address2;
                row[6]      = item.fax;
                row[7]     = item.email;
                row[8]   = item.website;
                row[9]  = item.licence;
                row[10]   = item.remark;
                row[11]    = item.status;
                row[12]     = item.UserModels.user_name;
                row["user_id"] = item.user_id;
                da.Rows.Add(row);
            }
            return da;
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
            var mod = db.CustomerModels.SingleOrDefault(x=>x.Name==name);
            if(mod!=null)
            {
                da = 1;
            }
            return da;
        }

    }

}
