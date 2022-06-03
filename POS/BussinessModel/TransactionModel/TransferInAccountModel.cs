using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
    [Table("tbl_TransferAccount")]
    public class TransferInAccountModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Type { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public int? Transfer_In_ID { get; set; }
        public int? Transfer_Out_ID { get; set; }
        public int? cash_id { get; set; }
        public int? lo_id { get; set; }
        public int? user_id { get; set; }
        public decimal? Balance { get; set; }
        public LoanModel LoanModels { get; set; }

    }
}
