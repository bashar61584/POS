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
using POS.BussinessModel.MasterModel;
using POS.BussinessModel.TransactionModel.AccountModel;

namespace MDS.Customer
{
    class EmployeePaymentLayer
    {
        private ModelContext db; 
        public EmployeePaymentLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, EmployeePaymentModel model )
        {
            int result = 0;
            if (txtcode==string.Empty)
            {
                db.EmployeePaymentModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.EMP_AC_ID = Convert.ToInt32(txtcode);
                model.user_id = Convert.ToInt32(POS.Properties.Settings.Default.userid);
                var ItemINDB = db.EmployeePaymentModels.Find(model.EMP_AC_ID);
                db.Entry(ItemINDB).CurrentValues.SetValues(model);
                //db.Entry(model).State = EntityState.Modified;
                result = db.SaveChanges();
            }
            return result;
            
        }

        internal int DeleteFnc(string txtcode)
        {
            int result = 0;
            try
            {

                EmployeePaymentModel model = db.EmployeePaymentModels.Find(Convert.ToInt32(txtcode));
                db.EmployeePaymentModels.Remove(model);
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

            var mod = db.EmployeePaymentModels.Include(u => u.UserModels)
                .Include(u=>u.EmployeeModels)
                .Include(u=>u.EmployeeModels.DesignationModels)
                .ToList().OrderByDescending(x => x.EMP_AC_ID);
            if (POS.Properties.Settings.Default.Language ==1)
            {
  
                da.Columns.Add(Language.code);
                da.Columns.Add(Language.Name);
                da.Columns.Add(Language.Address1);
                da.Columns.Add(Language.Phone1);
                da.Columns.Add(Language.Address2);
                da.Columns.Add(Language.Phone2);
                da.Columns.Add(Language.NICNO);
                da.Columns.Add(Language.Email);
                da.Columns.Add(Language.Salary);
                da.Columns.Add(Language.Designation);
                da.Columns.Add(Language.payed);
                da.Columns.Add(Language.Deduction);
                da.Columns.Add(Language.Allowances);
                da.Columns.Add(Language.Remark);
                da.Columns.Add(Language.Date);
                da.Columns.Add(Language.user);
                da.Columns.Add("user_id");
                da.Columns.Add("Desig_ID");
                da.Columns.Add("EMP_ID");
                da.Columns.Add("Remark");
                da.Columns.Add("DedRemark");
                da.Columns.Add("AddDate");


            }
            else
            {
                da.Columns.Add("Code");
                da.Columns.Add("Name");

                da.Columns.Add("Address");
                da.Columns.Add("Phone 1");
                da.Columns.Add("Address2");
                da.Columns.Add("Phone 2");
                da.Columns.Add("NIC NO");
                da.Columns.Add("Email");
                da.Columns.Add("Salary");
                da.Columns.Add("Designation");
                da.Columns.Add("Payed Salary");
                da.Columns.Add("Deduction");
                da.Columns.Add("Allowance");
                da.Columns.Add("AllowRemark");
                da.Columns.Add("Date");
                da.Columns.Add("User");
                da.Columns.Add("user_id");
                da.Columns.Add("Desig_ID");
                da.Columns.Add("EMP_ID");
                da.Columns.Add("Remark");
                da.Columns.Add("DedRemark");
                da.Columns.Add("AddDate");

            }
            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0]     = item.EMP_AC_ID;
                row[1]     = item.EmployeeModels.Name;
                row[2] = item.EmployeeModels.Address1;
                row[3] = item.EmployeeModels.phone1;
                row[4] = item.EmployeeModels.Address2;
                row[5] = item.EmployeeModels.phone2;
                row[6]      = item.EmployeeModels.NICNO;
                row[7]     = item.EmployeeModels.email;
                row[8]   = item.EmployeeModels.BasicSalary;
                row[9]  = item.EmployeeModels.DesignationModels.Name;
                row[10] = item.Salary;
                row[11] = item.Deduction;
                row[12] = item.Allownce;
                row[13] = item.AllowRemark;
                row[14]   = item.Date.Value.ToShortDateString();
                row[15]     = item.UserModels.user_name;
                row["user_id"] = item.user_id;
                row["Desig_ID"] = item.EmployeeModels.DesignationModels.DSIG_ID;
                row[18] = item.EMP_ID;
                row[19] = item.EmployeeModels.remark;
                row[20] = item.Remarks;
                row[21] = item.EmployeeModels.AddDate;


                da.Rows.Add(row);
            }
            return da;
        }

        internal void RetrieveReport(string p)
        {
            
            //DataSet1 ds = new DataSet1();
            //var mod = db.EmployeePaymentModels.Include(u=>u.EmployeeModels).Include(u=>u.EmployeeModels.DesignationModels).ToList();
            //foreach (var item in mod)
            //{
            //    DataRow row = ds.Tables["tbl_EmployeePay"].NewRow();
            //    row["Code"] = item.EMP_ID;
            //    row["Name"] = item.Name;
            //    row["Address"] = item.Address1;
            //    row["Phone 1"] = item.phone1;
           
            //    row["Email"] = item.email;
            //    row["Remark"] = item.remark;
              
            //    ds.Tables["tbl_customer"].Rows.Add(row);
            //}
            //switch (p)
            //{

            //    case "Preview":
            //        EmployeePaymentReportForm obj = new EmployeePaymentReportForm(ds);
            //        obj.Show();
            //        break;
            //    case "Print":
            //        EmployeeOtherReport orp = new EmployeeOtherReport(p,ds);

            //        break;
            //    case "Word":
            //        EmployeeOtherReport orp2 = new EmployeeOtherReport(p, ds);

            //        break;
            //    case "Excel":
            //        EmployeeOtherReport orp3 = new EmployeeOtherReport(p, ds);

            //        break;
            //        //case "Email":
            //        //    EmailForm obj3 = new EmailForm(ds, this.Text);
            //        //    obj3.ShowDialog();
            //        //    break;
            //        //case "Word":
            //        //    MDS.Formula.OrderOtherReport obj4 = new MDS.Formula.OrderOtherReport(ds, p);
            //        //    break;

            //}
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
