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

namespace QLRCP.NhanVien
{
    public partial class FDatve : Form
    {
        Dictionary<string, LoaiVe> lvd = new Dictionary<string, LoaiVe>();
        Dictionary<string, Ghe> ghed = new Dictionary<string, Ghe>();
        public string MaHD { set; get; }
        public FDatve()
        {
            InitializeComponent();

            getcbbtenphim();
            cbbve.DisplayMember = "TenLV";
            cbbve.ValueMember = "MaLV";
            getve();
           

        }
        public void getcbbtenphim()
        {
            DataTable ds = new DataTable();
            string sql = "SELECT a.TenPhim FROM Phim a";
            Sql.DB.Connection.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);    
            adapt.Fill(ds);
            Sql.DB.Connection.Close();
            cbbtenphim.DataSource = ds;
            cbbtenphim.DisplayMember = "TenPhim";
            cbbtenphim.ValueMember = "TenPhim";

        }
        public void getDataSC()
        {
            string tenphim = cbbtenphim.Text;
            DateTime ngaychieu;
            ngaychieu = DateTime.Parse(txtngaychieu.Text);
            string nam = ngaychieu.ToString("yyyy");
            string thang = ngaychieu.ToString("MM");
            string ngay = ngaychieu.ToString("dd");
            Sql.DB.Connection.Open();
            string sql = "select b.MaSC,c.MaPhong,a.TenPhim,b.NgayChieu,d.GioBD,d.GioKT from Phim a, SuatChieu b,Phong c, LichChieu d Where a.MaPhim = b.MaPhim and b.MaLC = d.MaLC and c.MaPhong = b.MaPhong" +
                " and YEAR(b.NgayChieu)='" + nam + "' " +
                "and MONTH(b.NgayChieu)='" + thang + "' and DAY(b.NgayChieu)='" + ngay + "' and a.TenPhim=N'"+tenphim+"' ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Sql.DB.Connection.Close();
        }
        private void getve()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT a.MaLV, a.TenLV FROM LoaiVe a", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();

            lvd = new Dictionary<string, LoaiVe>();
            while (dr.Read())
            {
                LoaiVe c = new LoaiVe((string)dr[0], (string)dr[1]);
                cbbve.Items.Add(c);
                lvd[c.MaLV] = c;
            }

            Sql.DB.Connection.Close();
        }
        private void getghe()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT a.MaGhe, a.TenGhe FROM Ghe a,Phong b Where a.MaPhong=b.MaPhong and a.MaPhong='"+txtmaphong.Text+"'", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();

            ghed = new Dictionary<string, Ghe>();
            while (dr.Read())
            {
                Ghe c = new Ghe((string)dr[0], (string)dr[1]);
                cbbghe.Items.Add(c);
                ghed[c.MaGhe] = c;
            }

            Sql.DB.Connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtmahd.Text = MaHD;
            getDataSC();
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtmasc.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtmaphong.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbbghe.DisplayMember = "TenGhe";
            cbbghe.ValueMember = "MaGhe";
            getghe();
        }

        private void cbbve_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();
            string sql = "SELECT a.GiaVe FROM LoaiVe a Where a.TenLV='"+cbbve.Text+"'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataTable ds = new DataTable();
            adapt.Fill(ds);
            for (int i = 0; i < ds.Rows.Count; i++)// cái này nó sẽ duyệt từng dòng trong table tương ứng.
            {
                this.txtgia.Text = ds.Rows[i][0].ToString();
            }
         

            Sql.DB.Connection.Close();

        }
        public void gettrang()
        {

        }
        public void getdsve()
        {
            Sql.DB.Connection.Open();

            string sql = "SELECT d.MaVe,d.TenVe,b.TenPhim,e.TenLV,e.GiaVe,c.TenPhong,k.TenGhe,l.GioBD,l.GioKT " +
                "FROM HoaDon a,Phim b, Phong c,Ve d, LoaiVe e ,Ghe k, SuatChieu s,LichChieu l" +
                " Where a.MaHD = d.MaHD and e.MaLV = d.MaLV and d.MaSC = s.MaSC and s.MaLC = l.MaLC and d.MaGhe = k.MaGhe " +
                "and c.MaPhong = k.MaPhong and b.MaPhim = s.MaPhim and s.MaPhong = c.MaPhong " +
                "and a.MaHD = '" + txtmahd.Text + "' ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }
        private void button3_Click(object sender, EventArgs e)

        {
            DateTime ngay;
            ngay =DateTime.Now;
            string madh = txtgia.Text + ngay.ToString();
            string tenve = "Vé Xem Phim";
            SqlCommand cmd = new SqlCommand("INSERT INTO Ve(MaVe,TenVe,MaSC,MaLV,MaHD,MaGhe) VALUES( @mave,@tenve,@masc,@malv,@mahd,@maghe)", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.Parameters.AddWithValue("@mave",madh);
            cmd.Parameters.AddWithValue("@tenve", tenve);
            cmd.Parameters.AddWithValue("@masc", txtmasc.Text);
            cmd.Parameters.AddWithValue("@malv", ((LoaiVe)cbbve.SelectedItem).MaLV);
            cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
            cmd.Parameters.AddWithValue("@maghe", ((Ghe)cbbghe.SelectedItem).MaGhe);
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();

            MessageBox.Show("Thêm thành công!!!");
            getdsve();
            gettrang();
        }
    }
}
