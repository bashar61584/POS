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
using POS.BussinessModel.MasterModel;

namespace MDS.Customer
{
    class DesignationLayer
    {
        private ModelContext db; 
        public DesignationLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, DesignationModel model )
        {
            int result = 0;
            if (txtcode==string.Empty)
            {
                db.DesignationModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.DSIG_ID= Convert.ToInt32(txtcode);
                model.user_id = Convert.ToInt32(POS.Properties.Settings.Default.userid);
                var ItemINDB = db.DesignationModels.Find(model.DSIG_ID);
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

               
                DesignationModel model = db.DesignationModels.Find(Convert.ToInt32(txtcode));
                db.DesignationModels.Remove(model);
                result = db.SaveChanges();

               
            }
            catch (Exception )
            {
              
                
            }
            return result;
        }
        internal DataTable LoadGridView(string state)
        {
            if (state == "Update")
                db = new ModelContext();
            DataTable da = new DataTable();

            var mod = db.DesignationModels.Include(u => u.UserModels).ToList().OrderByDescending(x => x.DSIG_ID);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add("کوډ");
                da.Columns.Add("نوم");
                da.Columns.Add("فعال", typeof(bool));
                da.Columns.Add("کاروونکی");
                da.Columns.Add("user_id");
            }
            else
            {

                da.Columns.Add("Code");
                da.Columns.Add("Name");
                da.Columns.Add("Status", typeof(bool));
                da.Columns.Add("User");
                da.Columns.Add("user_id");

            }

            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0] = item.DSIG_ID;
                row[1] = item.Name;
                row[2] = item.status;
                row[3] = item.UserModels.user_name;
                row[4] = item.user_id;
                da.Rows.Add(row);
            }
            return da;
        }

        internal void RetrieveReport(string p)
        {
            
            DataSet1 ds = new DataSet1();
            var mod = db.DesignationModels.ToList();
            foreach (var item in mod)
            {
                DataRow dr = ds.Tables["tbl_item"].NewRow();
                dr["item_id"] = item.DSIG_ID;
                dr["item_name"] = item.Name;

                ds.Tables["tbl_item"].Rows.Add(dr);
            }
            switch (p)
            {

                case "Preview":
                    DesignationReportForm obj = new DesignationReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    DesignationOtherReport orp = new DesignationOtherReport(p,ds);

                    break;
                case "Word":
                    DesignationOtherReport orp2 = new DesignationOtherReport(p, ds);

                    break;
                case "Excel":
                    DesignationOtherReport orp3 = new DesignationOtherReport(p, ds);

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
            var mod = db.ItemModels.SingleOrDefault(x=>x.item_name==name);
            if(mod!=null)
            {
                da = 1;
            }
            return da;
        }

    }

}
