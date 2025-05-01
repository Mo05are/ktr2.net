using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example_ktra2
{
    internal class DAO
    {
        public static SqlConnection conn;
        public static string ConnectionString = "Data Source=DESKTOP-NQH6AOJ\\SQLEXPRESS;Initial Catalog=QuanLyNhanVien;Integrated Security=True;TrustServerCertificate=True ";
        public static void Connect()
        {
            conn = new SqlConnection(ConnectionString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
            }

            catch (Exception exx)
            {
                throw exx;
            }
        }
        public static void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public static DataTable LoadDataToTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dt);
            return dt;
        }
       public static void RunSql(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            Connect();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        
    }
}
