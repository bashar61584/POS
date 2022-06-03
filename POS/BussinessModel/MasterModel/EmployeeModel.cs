using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel.MasterModel
{
    [Table("tbl_Employee")]
    public class EmployeeModel
    {
        [Key]
        public int EMP_ID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string NICNO { get; set; }
        public string email { get; set; }
        public int? DSIG_ID { get; set; }
        public decimal? BasicSalary { get; set; }
        public string remark { get; set; }
        public bool? status { get; set; }
        public int? user_id { get; set; }
        public DateTime? AddDate { get; set; }
        public UserModel UserModels { get; set; }
        public DesignationModel DesignationModels{ get; set; }

    }
}
