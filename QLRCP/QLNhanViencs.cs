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

namespace QLRCP
{
    public partial class QLNhanViencs : Form
    {
        public QLNhanViencs()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            Sql.DB.Connection.Open();

            string sql = "select * from NhanVien";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();

        }
        public void gettrang()
        {
            tbm.Text = string.Empty;
            tbt.Text = string.Empty;
            tbgt.Text = string.Empty;
            tbdc.Text = string.Empty;
            tbcmt.Text = string.Empty;
            tbsdt.Text = string.Empty;
            tbcv.Text = string.Empty;
            tbmk.Text = string.Empty;
            tbe.Text = string.Empty;
            tbtk.Text = string.Empty;

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();
            string sql = "select * from NhanVien Where TenNV=N'" + tbtk.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO NhanVien(MaNV,TenNV,GioiTinh,DiaChi,CMT,SDT,ChucVu,MatKhau,Email) " +
                "VALUES('" + tbm.Text + "',N'" + tbt.Text + "',N'" + tbgt.Text + "',N'" + tbdc.Text + "'" +
                ",N'" + tbcmt.Text + "',N'" + tbsdt.Text + "',N'" + tbcv.Text + "',N'" + tbmk.Text + "',N'" + tbe.Text + "')", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();

            Sql.DB.Connection.Close();

            MessageBox.Show("Thêm nhân viên thành công!!!");
            getData();
            gettrang();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("update NhanVien set TenNV=N'" + tbt.Text + "',GioiTinh=N'" + tbgt.Text + "',DiaChi=N'" + tbdc.Text + "'," +
                "CMT=N'" + tbcmt.Text + "' ,SDT=N'" + tbsdt.Text + "',ChucVu=N'" + tbcv.Text + "',MatKhau=N'" + tbmk.Text + "',Email=N'" + tbe.Text + "'" +
                " Where MaNV='" + tbm.Text + "'", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Sửa thành công!!!");
            getData();
            gettrang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete NhanVien Where MaNV='" + tbm.Text + "' ", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Xóa thành công!!!");
            getData();
            gettrang();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            tbm.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbgt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbdc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbsdt.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbe.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbcmt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            
            tbcv.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            tbmk.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
           
        }
    }
}
