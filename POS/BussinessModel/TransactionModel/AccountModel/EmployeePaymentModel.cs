using POS.BussinessModel.MasterModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel.TransactionModel.AccountModel
{
    [Table("tbl_EmployeeAccount")]
    public class EmployeePaymentModel
    {
        [Key]
        public int EMP_AC_ID { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Deduction { get; set; }
        public string Remarks{ get; set; }
        public int? EMP_ID { get; set; }
        public int? user_id { get; set; }
        public decimal? Allownce { get; set; }
        public string AllowRemark { get; set; }

        public UserModel UserModels { get; set; }
        public EmployeeModel EmployeeModels { get; set; }

    }
}
