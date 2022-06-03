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

namespace MDS.Customer
{
    class ItemLayer
    {
        private ModelContext db; 
        public ItemLayer()
        {
            db = new ModelContext();

        }

        internal int SaveUpdateFnc(string txtcode, ItemModel model )
        {
            int result = 0;
            if (txtcode==string.Empty)
            {
                db.ItemModels.Add(model);
                result = db.SaveChanges();

            }
            else
            {
                model.item_id = Convert.ToInt32(txtcode);
                model.user_id = Convert.ToInt32(POS.Properties.Settings.Default.userid);
                var ItemINDB = db.ItemModels.Find(model.item_id);
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

               
                ItemModel model = db.ItemModels.Find(Convert.ToInt32(txtcode));
                db.ItemModels.Remove(model);
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

            var mod = db.ItemModels.Include(u => u.UserModels).ToList().OrderByDescending(x => x.item_id);
            if (POS.Properties.Settings.Default.Language == 1)
            {
                da.Columns.Add("کوډ");
                da.Columns.Add("نوم");
                da.Columns.Add("دخرڅلاو بیه");
                da.Columns.Add("دلګښت بیه");
                da.Columns.Add("دتجارت بیه");
                da.Columns.Add("بسته بندی کول");
                da.Columns.Add("لږ تر لږه سټاک");
                da.Columns.Add("په لاس کې سټاک");
                da.Columns.Add("فعال", typeof(bool));
                da.Columns.Add("کاروونکی");
                da.Columns.Add("user_id");
            }
            else
            {

                da.Columns.Add("Code");
                da.Columns.Add("Name");
                da.Columns.Add("Retail");
                da.Columns.Add("Cost Price");
                da.Columns.Add("Trade Price");
                da.Columns.Add("Packing");
                da.Columns.Add("Mini Stock");
                da.Columns.Add("Stock");
                da.Columns.Add("Status", typeof(bool));
                da.Columns.Add("User");
                da.Columns.Add("user_id");

            }

            foreach (var item in mod)
            {
                var row = da.NewRow();
                row[0] = item.item_id;
                row[1] = item.item_name;
                row[2] = item.item_retail;
                row[3] = item.item_costprice;
                row[4] = item.item_tp;
                row[5] = item.item_packing;
                row[6] = item.item_ministock;
                row[7] = item.item_stock;
                row[8] = item.item_state;
                row[9] = item.UserModels.user_name;
                row[10] = item.user_id;
                da.Rows.Add(row);
            }
            return da;
        }

        internal void RetrieveReport(string p)
        {
            
            DataSet1 ds = new DataSet1();
            var mod = db.ItemModels.ToList();
            foreach (var item in mod)
            {
                DataRow dr = ds.Tables["tbl_item"].NewRow();
                dr["item_id"] = item.item_id;
                dr["item_name"] = item.item_name;
                dr["item_tp"] = item.item_tp;
                dr["item_costprice"] = item.item_costprice;
                dr["item_retail"] = item.item_retail;
                dr["item_stock"] = item.item_stock;
                ds.Tables["tbl_item"].Rows.Add(dr);
            }
            switch (p)
            {

                case "Preview":
                    POS.Item.ItemReportForm obj = new POS.Item.ItemReportForm(ds);
                    obj.Show();
                    break;
                case "Print":
                    ItemOtherReport orp = new ItemOtherReport(p,ds);

                    break;
                case "Word":
                    ItemOtherReport orp2 = new ItemOtherReport(p, ds);

                    break;
                case "Excel":
                    ItemOtherReport orp3= new ItemOtherReport(p, ds);

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
