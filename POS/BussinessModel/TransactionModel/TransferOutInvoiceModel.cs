using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
    [Table("tbl_TransferOutInvoice")]
   public class TransferOutInvoiceModel
    {
        [Key]
        public int ID { get; set; }
        public int? Item_id { get; set; }
        public int? Bonus { get; set; }
        public int? Qty { get; set; }
        public int? Disc { get; set; }
        public decimal? Price { get; set; }
        public int? Transfer_Out_ID { get; set; }
        public decimal? Tp_Price { get; set; }
        public TransferOutOrderModel TransferOutOrderModel { get; set; }
        public ItemModel itemModel { get; set; }
    }
}
