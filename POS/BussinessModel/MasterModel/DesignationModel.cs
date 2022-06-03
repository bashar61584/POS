using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel.MasterModel
{
    [Table("tbl_Designation")]
   public class DesignationModel
    {
        [Key]
        public int DSIG_ID { get; set; }
        public string Name { get; set; }
        public bool? status { get; set; }

        public int? user_id { get; set; }
        public UserModel UserModels { get; set; }

    }
}
