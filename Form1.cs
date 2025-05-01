using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example_ktra2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DAO.Connect();
                ///  MessageBox.Show("Ket noi thanh cong");
                ///  load dât to gridview
                LoadDataToGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDataToGridview()
        {
            string sql = "select * from tblNhanVien";
            DataTable dt = new DataTable();
            //var ds = new DataSet();
            dt = DAO.LoadDataToTable(sql);

            
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtMaNhanvien.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtQueQuan.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtMaNhanvien.Enabled = false;
            }
        }

        private void clear()
        {
            txtHoTen.Text = "";
            txtMaNhanvien.Text = "";
            txtQueQuan.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clear();
            btnHuy.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMaNhanvien.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            clear();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaNhanvien.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // kiem tra dl
            if (txtQueQuan.Text == "")
            {
                MessageBox.Show("chua nhap ma");
            }
            // luu  

            string sql = "insert into tblNhanVien values (N'" +
                        txtMaNhanvien.Text.Trim() + "', N'" + txtHoTen.Text.Trim() + "'," +
                        "N'" + txtQueQuan.Text.Trim() + "')";

            SqlCommand cmd = new SqlCommand(sql, DAO.conn);
            try
            {
                cmd.ExecuteNonQuery();
                LoadDataToGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clear();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //check data
            if (txtMaNhanvien.Text == "")
            {
                MessageBox.Show("chua chon dl de sua");
                return;
            }
            // ckek ho ten, que ko dc trong
            string sql = "update tblNhanVien set hoten = N'" + txtHoTen.Text.Trim() + "', " +
                "quequan = N'" + txtQueQuan.Text.Trim() +
                "' where manv = N'" + txtMaNhanvien.Text + "'";

            SqlCommand cmd = new SqlCommand(sql, DAO.conn);
            try
            {
                cmd.ExecuteNonQuery();
                LoadDataToGridview();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ban co muon thoat khong");
            ActiveForm.Close();
            DAO.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanvien.Text == "")
            {
                MessageBox.Show("chua chon dl de xoa");
                return;
            }
            String MaNVbixoa = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string sql = "DELETE FROM tblNhanvien WHERE MaNV = " + "'" + MaNVbixoa + "'";

            SqlCommand cmd = new SqlCommand(sql, DAO.conn);
            try
            {
                cmd.ExecuteNonQuery();
                LoadDataToGridview();
                MessageBox.Show("Xoa thanh cong " + MaNVbixoa + ".");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
