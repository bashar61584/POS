using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
    [Table("tbl_TransferInOrder")]
    public class TransferInOrderModel
    {
        [Key]
        public int Transfer_In_ID { get; set; }
        public TimeSpan? Time { get; set; }
        public int? Lo_ID { get; set; }
        public int? user_id { get; set; }
        public decimal? Dis { get; set; }
        public DateTime? Date { get; set; }
        public string Type { get; set; }
        public string InvoiceNo { get; set; }
        public LoanModel LoanModels { get; set; }
        public UserModel UserModels { get; set; }
      

    }
    
}
