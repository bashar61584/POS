using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS
{
    class Connection
    {
        public static string connection = "Data Source=" + POS.Properties.Settings.Default.Server + ";Initial Catalog=POSDBMS;Integrated Security=False; User ID=Bashar; password=mypassword";
    }
}
