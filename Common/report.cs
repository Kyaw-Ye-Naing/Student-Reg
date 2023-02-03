using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Common
{
    public class report:clsconnection
    {
        public void SaveTest(string one, string two)
        {
            // try
            //{
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
            }
            SqlCommand cmd = new SqlCommand("SP_SaveCalculatedCommissionData", sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@one", one);
            cmd.Parameters.AddWithValue("@two", two);
            cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            // {
            //   Console.WriteLine("spReport SaveCalculatedCommissionData>" + ex.Message);
            //}
            //finally
            //{
            //  sql.Close();
            //}
        }
    }
}
