using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BussinessModel
{

    [Table("tbl_user")]
    public class UserModel
    {

        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public bool? productFile { get; set; }
        public bool? prductstatus { get; set; }
        public bool? productmaster { get; set; }
        public bool? productlist { get; set; }
        public bool? purchasestock { get; set; }
        public bool? purchasemaster { get; set; }
        public bool? purchaselist { get; set; }
        public bool? purchasereturn { get; set; }
        public bool? purchasereturnmaster { get; set; }
        public bool? purchasereturnlist { get; set; }
        public bool? prodaccount { get; set; }
        public bool? prodaccmaster { get; set; }
        public bool? prodacclist { get; set; }
        public bool? prodreport { get; set; }
        public bool? customerFile { get; set;  }
        public bool? customerstatus { get; set;  }
        public bool? customermaster { get; set;  }
        public bool? customerlist { get; set; }
        public bool? saleinvoice { get; set; }
        public bool? saleinvoicemaster { get; set; }
        public bool? saleinvoicelist { get; set; }
        public bool? salereturn{ get; set; }
        public bool? salereturnmaster{ get; set; }
        public bool? salereturnlist { get; set; }
        public bool? custaccount { get; set; }
        public bool? custaccmaster { get; set; }
        public bool? custacclist { get; set; }
        public bool? customerreport{ get; set; }
        public bool? branche { get; set; }
        public bool? branchstatus { get; set; }
        public bool? branchmaster { get; set; }
        public bool? branchlist { get; set; }
        public bool? transferin { get; set; }
        public bool? transferinmaster { get; set; }
        public bool? transferinlist { get; set; }
        public bool? transferout { get; set; }
        public bool? transferoutmaster { get; set; }
        public bool? transferoutlist { get; set; }
        public bool? branchaccount { get; set; }
        public bool? branchaccmaster { get; set; }
        public bool? branchacclist { get; set; }
        public bool? loanreport { get; set; }
        public bool? supplier { get; set; }
        public bool? supplierstatus { get; set; }
        public bool? suppliermaster { get; set; }
        public bool? supplierlist { get; set; }

        public bool? Report { get; set; }
        public bool? Employee { get; set; }
        public bool? Expense { get; set; }
        public bool? Setting { get; set; }
        public bool? status { get; set; }


    }
}
