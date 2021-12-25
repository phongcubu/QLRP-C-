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
    public partial class QLPChieu : Form
    {
        public QLPChieu()
        {
            InitializeComponent();
           getData();
        }
        public void getData()
        {
            Sql.DB.Connection.Open();

            string sql = "select a.MaPhong,a.TenPhong,a.MaRap from Phong a ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();

        }
        public void getDataTT()
        {
            Sql.DB.Connection.Open();
            DateTime ngaychieu;
            ngaychieu = DateTime.Parse(txtngaychieu.Text);
            string nam = ngaychieu.ToString("yyyy");
            string thang = ngaychieu.ToString("MM");
            string ngay = ngaychieu.ToString("dd");
            string sql = "select a.MaPhong,a.TenPhong,a.MaRap,Count(b.MaGhe)as TT from Phong a ,Ghe b,Ve c,HoaDon d where a.MaPhong=b.MaPhong and b.MaGhe=C.MaGhe " +
                "and YEAR(d.NgayHD)= '" + nam + "'and MONTH(d.NgayHD)= '" + thang + "' and DAY(d.NgayHD)= '" + ngay + "' " +
                " Group by a.MaPhong,a.TenPhong,a.MaRap,b.MaPhong";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();

        }
        public void gettrang()
        {
            tbmaphong.Text = string.Empty;
            tbtp.Text = string.Empty;
            tbtt.Text = string.Empty;
            tbtk.Text = string.Empty;
            tbmr.Text = string.Empty;
            

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();
            string sql = "select * from Phong Where TenPhong=N'" + tbtk.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Phong(MaPhong,TenPhong,MaRap) " +
                "VALUES('" + tbmaphong.Text + "',N'" + tbtp.Text + "','" + tbmr.Text + "')", Sql.DB.Connection);
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
            tbmaphong.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbtp.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbmr.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbtt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Phong set TenPhong=N'" + tbtp.Text + "', MaRap='" + tbmr.Text+"' Where MaPhong='" + tbmaphong.Text+ "'", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Sửa thành công!!!");
            getData();
            gettrang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete Phong  Where MaPhong='" + tbmaphong.Text + "' ", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Xóa thành công!!!");
            getData();
            gettrang();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getDataTT();
        }

       
    }
}
