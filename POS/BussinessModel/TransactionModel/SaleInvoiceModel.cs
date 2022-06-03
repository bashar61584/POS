using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
    [Table("tbl_SaleInvoice")]
   public class SaleInvoiceModel
    {
        [Key]
        public int ID { get; set; }
        public int? Item_id { get; set; }
        public int? Bonus { get; set; }
        public int? Qty { get; set; }
        public int? Disc { get; set; }
        public decimal? Price { get; set; }
        public decimal? Tp_Price { get; set; }
        public int? Sale_Order_ID { get; set; }
        public SaleOrderModel SaleOrderModel { get; set; }
        public ItemModel itemModel { get; set; }
    }
}
