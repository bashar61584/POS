using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
    [Table("tbl_Supplier_CashRecord")]
    public class SupplierAccountOrderModel
    {
        [Key]
        public int Cash_ID { get; set; }
        public DateTime? Date { get; set; }
        public int? user_id { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public UserModel UserModels { get; set; }
    }
}
