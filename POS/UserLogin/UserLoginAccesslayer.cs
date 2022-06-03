using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using POS;
using POS.BussinessModel;

namespace TMS.User_Login
{
    class UserLoginAccesslayer
    {
        private readonly ModelContext db;
        public UserLoginAccesslayer()
        {
            db = new ModelContext();

        }

        internal UserModel RetrieveUser(string username, string password)
        {
            var mod = db.UserModels.SingleOrDefault(x=>x.user_name==username && x.user_password==password && x.status==true);
            return mod; 
           
        }
    }
}
