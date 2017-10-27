using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class DBHelper
    {
        public static string strConn = "server=.;database=TestDB;integrated security=true";
        public static DataTable GetDataTable(string strSql)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                //声明表格，用来填充查询的数据
                DataTable dt = new DataTable();

                //conn.State:链接状态
                //ConnectionState.Closed:链接状态为关闭
                try
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        //打开数据库
                        conn.Open();
                        //SqlDataAdapter:数据库指令，只限于查询
                        SqlDataAdapter sda = new SqlDataAdapter(strSql, conn);
                        
                        //把查询出来的数据填充到Datatable中
                        sda.Fill(dt);

                    }
                    return dt;
                }
                catch (Exception)
                {
                    return dt;
                }

            }

        }


        //增删改
        public static int ExecuteNonQuery(string strSql)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(strConn))
            {

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();

                    SqlCommand comm = new SqlCommand(strSql, conn);
                    try
                    {
                        result = comm.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        return 0;
                    }

                }

            }
            return result;
        }
    }
}
