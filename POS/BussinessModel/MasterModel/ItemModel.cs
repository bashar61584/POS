using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
    [Table("tbl_Item")]
    public class ItemModel
    {
        [Key]
        public int item_id { get; set; }
        public string item_name { get; set; }
        public decimal? item_tp { get; set; }
        public decimal? item_costprice { get; set; }
        public decimal? item_retail { get; set; }
        public int? item_stock { get; set; }
        public int? item_packing { get; set; }
        public int? item_ministock { get; set; }
        public bool? item_state { get; set; }
        public int? user_id { get; set; }
        public int? item_stockout { get; set; }
        public UserModel UserModels { get; set; }

    }
}
