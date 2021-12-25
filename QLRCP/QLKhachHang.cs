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
    public partial class QLKhachHang : Form
    {
        public QLKhachHang()
        {                                         
            InitializeComponent();
            getData();
        }
        public void getData()
        {
            Sql.DB.Connection.Open();

            string sql = "select * from KhachHang";
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
            tbdc.Text = string.Empty;
            tbsdt.Text = string.Empty;
            tbtk.Text = string.Empty;

        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();
            string sql = "select * from KhachHang Where TenKH=N'" + tbtk.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO KhachHang(MaKH,TenKH,DiaChi,SDT) " +
                "VALUES(N'" + tbm.Text + "',N'" + tbt.Text + "',N'" + tbdc.Text + "',N'" + tbsdt.Text + "')", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();

            Sql.DB.Connection.Close();

            MessageBox.Show("Thêm thành công!!!");
            getData();
            gettrang();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            tbm.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbdc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbsdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update KhachHang set TenKH=N'" + tbt.Text + "',DiaChi=N'" + tbdc.Text + "'," +
                " SDT=N'" + tbsdt.Text + "'" +
                " Where MaKH='" + tbm.Text + "'", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Sửa thành công!!!");
            getData();
            gettrang();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Delete KhachHang Where MaKH='" + tbm.Text + "' ", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Xóa thành công!!!");
            getData();
            gettrang();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
