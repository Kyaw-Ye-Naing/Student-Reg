using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Common
{
    public class clsconnection
    {
        public SqlConnection sql;
        public clsconnection()
        {
            sql = new SqlConnection(clsPublicVariable.connectionString);
        }
    }
}
