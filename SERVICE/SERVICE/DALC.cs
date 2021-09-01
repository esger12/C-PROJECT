using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE
{
     public static  class DALC
    {

        public static string GetConnectionString()
        {
            string constring = "Data Source=DESKTOP-VP173UQ; Initial Catalog=ESGER; Integrated Security=true";
            return constring;
        }
    }
}
