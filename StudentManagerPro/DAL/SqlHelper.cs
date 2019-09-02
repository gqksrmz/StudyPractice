using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class SqlHelper
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        //返回整个表
        public static DataTable GetDataTable(string sql,CommandType type,params SqlParameter[] parms)
        {
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                using (SqlDataAdapter adapter=new SqlDataAdapter(sql,conn))
                {
                    if (parms != null)
                    {
                        adapter.SelectCommand.Parameters.AddRange(parms);
                    }
                    adapter.SelectCommand.CommandType = type;
                    DataTable da = new DataTable();
                    adapter.Fill(da);
                    return da;
                }
            }
        }
        //返回受影响的行数
        public static int ExecuteNonquery(string sql,CommandType type,params SqlParameter[] parms)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    if (parms != null)
                    {
                        cmd.Parameters.AddRange(parms);
                    }   
                    cmd.CommandType = type;
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
