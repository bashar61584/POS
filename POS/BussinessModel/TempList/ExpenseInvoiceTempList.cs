using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel.TempList
{
    class ExpenseInvoiceTempList
    {
        public string  ExpMenuName { get; set; }
        public int ExpMenu_ID { get; set; }
        public decimal Price { get; set; }
        public string Remark { get; set; }
    }
}
