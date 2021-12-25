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
    public partial class QLPhim : Form
    {
        Dictionary<string, NCC> nccd = new Dictionary<string,NCC>();
        public QLPhim()
        {
            InitializeComponent();
            cbbtenncc.DisplayMember = "TenNCC";
            cbbtenncc.ValueMember = "MaNCC";
            getCBB();
            getData();

        }
        private void getCBB()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT a.MaNCC, a.TenNCC FROM NhaCungCap a", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();

            nccd = new Dictionary<string, NCC>();
            while (dr.Read())
            {
                NCC c = new NCC((string)dr[0], (string)dr[1]);
                cbbtenncc.Items.Add(c);
                nccd[c.MaNCC] = c;
            }

            Sql.DB.Connection.Close();
        }
        public void getData()
        {
            Sql.DB.Connection.Open();

            string sql = "select a.MaPhim, a.TenPhim,a.DaoDien,a.TheLoai,b.TenNCC,a.NgayKC,a.NgayKT ,a.ThoiLuong from Phim a,NhaCungCap b where a.MaNCC=B.MaNCC";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

           Sql. DB.Connection.Close();

        }
        public void gettrang()
        {
            tbmaphim.Text = string.Empty;
            tbtenphim.Text = string.Empty;
            tbthoiluong.Text = string.Empty;
            tbtk.Text = string.Empty;
            tbtl.Text = string.Empty;
            
            tbdd.Text = string.Empty;
            cbbtenncc.Text = " ";
            tbnkt.Text = string.Empty;
            tbnkc.Text = string.Empty;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt, dt1;
            dt = DateTime.Parse(tbnkc.Text); 
            dt1 = DateTime.Parse(tbnkt.Text);
            string ncc = ((NCC)cbbtenncc.SelectedItem).MaNCC;

            SqlCommand cmd = new SqlCommand("INSERT INTO Phim(MaPhim,TenPhim,DaoDien,TheLoai,ThoiLuong,MaNCC,NgayKC,NgayKT) VALUES( @maphim,@tenphim,@dd,@tl,@tluo,@ncc,@ngay1,@ngay2)", Sql.DB.Connection);
            Sql.DB.Connection.Open();

            cmd.Parameters.AddWithValue("@maphim", tbmaphim.Text);
            cmd.Parameters.AddWithValue("@tenphim",tbtenphim.Text );
            cmd.Parameters.AddWithValue("@dd", tbdd.Text);
            cmd.Parameters.AddWithValue("@tl", tbtl.Text);
            cmd.Parameters.AddWithValue("@tluo", tbthoiluong.Text);
            cmd.Parameters.AddWithValue("@ncc", ncc);
            cmd.Parameters.AddWithValue("@ngay1", dt);
            cmd.Parameters.AddWithValue("@ngay2", dt1);
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();

            MessageBox.Show("Thêm thành công!!!");
            getData();
            gettrang();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();
            string sql = "select * from Phim Where TenPhim=N'" + tbtk.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            tbmaphim.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbtenphim.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbdd.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbtl.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbbtenncc.Text= dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
            tbnkc.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            tbnkt.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            tbthoiluong.Text = dataGridView2.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt, dt1;
            dt = DateTime.Parse(tbnkc.Text);
            dt1 = DateTime.Parse(tbnkt.Text);
            string ncc = ((NCC)cbbtenncc.SelectedItem).MaNCC;
            SqlCommand cmd = new SqlCommand("update Phim set TenPhim=@tenphim,DaoDien=@dd,TheLoai=@tl,ThoiLuong=@tluo,MaNCC=@ncc,NgayKC=@ngay1,NgayKT=@ngay2 Where MaPhim=@maphim", Sql.DB.Connection);
            cmd.Parameters.AddWithValue("@maphim", tbmaphim.Text);
            cmd.Parameters.AddWithValue("@tenphim", tbtenphim.Text);
            cmd.Parameters.AddWithValue("@dd", tbdd.Text);
            cmd.Parameters.AddWithValue("@tl", tbtl.Text);
            cmd.Parameters.AddWithValue("@tluo", tbthoiluong.Text);
            cmd.Parameters.AddWithValue("@ncc", ncc);
            cmd.Parameters.AddWithValue("@ngay1", dt);
            cmd.Parameters.AddWithValue("@ngay2", dt1);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Sửa thành công!!!");
            getData();
           gettrang();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete Phim  Where MaPhim='" + tbmaphim.Text + "' ", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Xóa thành công!!!");
            getData();
            gettrang();
        }

        
    }
}
