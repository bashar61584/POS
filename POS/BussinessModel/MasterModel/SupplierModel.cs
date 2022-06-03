using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{
   [Table("tbl_Supplier")]
   public class SupplierModel
    {
        [Key]
        public int? Sup_ID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string licence { get; set; }
        public string remark { get; set; }
        public bool? status { get; set; }
        public int? user_id { get; set; }
        public UserModel UserModels { get; set; }
    }
}
