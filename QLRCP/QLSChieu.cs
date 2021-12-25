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
    public partial class QLSChieu : Form
    {
        Dictionary<string,Phim> phimd = new Dictionary<string, Phim>();

        Dictionary<string,Phong> phongd = new Dictionary<string, Phong>();

        public QLSChieu()
        {
            InitializeComponent();
            getData();
            cbbphim.DisplayMember = "TenPhim";
            cbbphim.ValueMember = "MaPhim";
            getcbbphim();
            cbbphong.DisplayMember = "TenPhong";
            cbbphong.ValueMember = "MaPhong";
            getcbbphong();
            getcbblc();
        }
        public void getData()
        {
            Sql.DB.Connection.Open();
            string sql = "select b.MaSC,a.TenPhim,c.TenPhong,b.NgayChieu,d.MaLC,d.GioBD,d.GioKT from Phim a,SuatChieu b,Phong c,LichChieu d Where a.MaPhim=b.MaPhim and b.MaLC=d.MaLC and c.MaPhong=b.MaPhong";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Sql.DB.Connection.Close();

        }
        public void gettrang()
        {
            txtsc.Text = " ";
            cbbphim.Text = " ";
            cbbphong.Text = " ";
            txtnc.Text = " ";
            cbblc.Text = " ";
            txtgbd.Text = " ";
            txtgkt.Text = " ";
        }
        public void getcbbphim()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT a.MaPhim, a.TenPhim FROM Phim a", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();

            phimd = new Dictionary<string, Phim>();
            while (dr.Read())
            {
                Phim p = new Phim((string)dr[0], (string)dr[1]);
                cbbphim.Items.Add(p);
                phimd[p.MaPhim] = p;
            }

            Sql.DB.Connection.Close();
        }

        public void getcbbphong()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT a.MaPhong, a.TenPhong FROM Phong a", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();

            phongd = new Dictionary<string, Phong>();
            while (dr.Read())
            {
                Phong p = new Phong((string)dr[0], (string)dr[1]);
                cbbphong.Items.Add(p);
                phongd[p.MaPhong] = p;
            }

            Sql.DB.Connection.Close();
        }

        public void getcbblc()
        {
            DataTable ds = new DataTable();
            string sql = "SELECT a.MaLC FROM LichChieu a";
            Sql.DB.Connection.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            adapt.Fill(ds);
            Sql.DB.Connection.Close();
            cbblc.DataSource = ds;
            cbblc.DisplayMember = "MaLC";
            cbblc.ValueMember = "MaLC";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();
            string sql = "select b.MaSC,a.TenPhim,c.TenPhong,b.NgayChieu,d.MaLC,d.GioBD,d.GioKT from Phim a,SuatChieu b,Phong c,LichChieu d Where a.MaPhim=b.MaPhim and b.MaLC=d.MaLC and c.MaPhong=b.MaPhong and a.TenPhim=N'"+txttimkiem.Text+"'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Sql.DB.Connection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            txtsc.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbbphim.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbbphong.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtnc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbblc.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtgbd.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtgkt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            dt = DateTime.Parse(txtnc.Text);
            SqlCommand cmd = new SqlCommand("INSERT INTO SuatChieu(MaSC,MaPhong,MaPhim,MaLC,NgayChieu) VALUES( @masc,@maphong,@maphim,@malc,@ngaychieu)", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.Parameters.AddWithValue("@masc", txtsc.Text);
            cmd.Parameters.AddWithValue("@maphong", ((Phong)cbbphong.SelectedItem).MaPhong);
            cmd.Parameters.AddWithValue("@maphim", ((Phim)cbbphim.SelectedItem).MaPhim);
            cmd.Parameters.AddWithValue("@malc", cbblc.Text);
            cmd.Parameters.AddWithValue("@ngaychieu", dt);
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();

            MessageBox.Show("Thêm thành công!!!");
            getData();
            gettrang();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime dt;
            dt = DateTime.Parse(txtnc.Text);
            
            
            SqlCommand cmd = new SqlCommand("update SuatChieu set MaPhong=@maphong,MaPhim=@maphim,MaLC=@malc,NgayChieu=@ngaychieu Where MaSC=@masc", Sql.DB.Connection);
            cmd.Parameters.AddWithValue("@masc", txtsc.Text);
            cmd.Parameters.AddWithValue("@maphong", ((Phong)cbbphong.SelectedItem).MaPhong);
            cmd.Parameters.AddWithValue("@maphim", ((Phim)cbbphim.SelectedItem).MaPhim);
            cmd.Parameters.AddWithValue("@malc", cbblc.Text);
            cmd.Parameters.AddWithValue("@ngaychieu", dt);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Sửa thành công!!!");
            getData();
            gettrang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete SuatChieu  Where MaSC='" + txtsc.Text + "' ", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Xóa thành công!!!");
            getData();
            gettrang();
        }
    }
}
