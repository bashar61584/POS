using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel.TempList
{
    class SaleInvoiceTempList
    {
        public int  Item_id { get; set; }
        public string Item_name { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int Bonus { get; set; }
        public int Disc { get; set; }
        public decimal Tp_Price { get; set; }
    }
}
