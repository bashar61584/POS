using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
    [Table("tbl_SaleAccount")]
    public class SaleAccountModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public string Type { get; set; }
        public decimal? Credit { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Balance { get; set; }
        public int? Sale_Order_ID { get; set; }
        public int? Sale_Return_ID { get; set; }
        public int? cash_id { get; set; }
        public int? Cu_ID { get; set; }
        public int? user_id { get; set; }

        public CustomerModel CustomerModels { get; set; }

    }
}
