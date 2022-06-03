using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel.MasterModel
{
    [Table("tbl_ExpenseInvoice")]
   public class ExpenseInvoiceModel
    {
        [Key]
        public int EXPINVOICE_ID { get; set; }
        public int? EXPMENU_ID { get; set; }
        public decimal? Price { get; set; }
        public string Remark { get; set; }
        public int? EXP_ID { get; set; }
        public ExpenseOrderModel ExpenseOrderModels { get; set; }
        public ExpenseMenuModel ExpenseMenuModels { get; set; }

    }
}
