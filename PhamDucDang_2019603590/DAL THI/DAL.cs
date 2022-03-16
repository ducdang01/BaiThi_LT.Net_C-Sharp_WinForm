using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL_THI
{
    public class DAL
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=TRUNGDOAN\SQLEXPRESS;Initial Catalog=QLHang;Integrated Security=True");
        }

        public DataTable GetDataTable(string strsql)
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public void Execute(string strsql)
        {
            SqlConnection conn = GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(strsql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
