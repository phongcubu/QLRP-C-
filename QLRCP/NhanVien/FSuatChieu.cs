using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLRCP.NhanVien
{
    public partial class FSuatChieu : Form
    {
        public FSuatChieu()
        {
            InitializeComponent();
            getData();
        }
        public void getData()
        {
            Sql.DB.Connection.Open();
            string sql = "select b.MaSC,a.TenPhim,c.TenPhong,b.NgayChieu,d.GioBD,d.GioKT from Phim a,SuatChieu b,Phong c,LichChieu d Where a.MaPhim=b.MaPhim and b.MaLC=d.MaLC and c.MaPhong=b.MaPhong";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();    
            adapt.Fill(ds);                
            dataGridView1.DataSource = ds.Tables[0];
            Sql.DB.Connection.Close();

        }
        public void TKTheoTenphim()
        {

            Sql.DB.Connection.Open();
            string sql = "select b.MaSC,a.TenPhim,c.TenPhong,b.NgayChieu,d.GioBD,d.GioKT from Phim a,SuatChieu b,Phong c,LichChieu d Where a.MaPhim=b.MaPhim and b.MaLC=d.MaLC and c.MaPhong=b.MaPhong " +
                "and a.TenPhim=N'" + txttimkiem.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Sql.DB.Connection.Close();

        }
        public void TKTheoNgayChieu()
        {

            DateTime ngaychieu;
            ngaychieu = DateTime.Parse(txttimkiem.Text);
            string nam = ngaychieu.ToString("yyyy");
            string thang = ngaychieu.ToString("MM");
            string ngay = ngaychieu.ToString("dd");
            Sql.DB.Connection.Open();
            string sql = "select b.MaSC,a.TenPhim,c.TenPhong,b.NgayChieu,d.GioBD,d.GioKT from Phim a, SuatChieu b,Phong c, LichChieu d Where a.MaPhim = b.MaPhim and b.MaLC = d.MaLC and c.MaPhong = b.MaPhong" +
                " and YEAR(b.NgayChieu)='" + nam + "'and MONTH(b.NgayChieu)='" + thang + "' and DAY(b.NgayChieu)='" + ngay + "' ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Sql.DB.Connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string chon = cbbtimkiem.SelectedItem.ToString();
            if (chon == "Tên phim")
            {
                TKTheoTenphim();
            }
            else
            {
                TKTheoNgayChieu();
            }
        }
    }
}
