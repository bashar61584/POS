using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel.MasterModel
{
    [Table("tbl_ExpenseOrder")]
   public class ExpenseOrderModel
    {
        [Key]
        public int EXP_ID { get; set; }
        public DateTime? Date { get; set; }
        public int? user_id { get; set; }

        public UserModel UserModels { get; set; }

    }
}
