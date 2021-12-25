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
    public partial class FXemPhim : Form
    {
        public FXemPhim()
        {
            InitializeComponent();
            getData();
           

        }
        public void getData()
        {
            Sql.DB.Connection.Open();
            string sql = "select a.TenPhim,a.DaoDien,a.TheLoai,a.ThoiLuong,a.NgayKC,a.NgayKT from Phim a";
            SqlDataAdapter adapt = new SqlDataAdapter(sql,Sql.DB.Connection);//chuyen du lieu ve//bat dau truy van
            DataSet ds = new DataSet();    // tạo một kho ảo để lưu trữ dữ liệu
            adapt.Fill(ds);                // đổ dữ liệu vào kho
            dataGridView1.DataSource = ds.Tables[0];//đổ dữ liệu vào datagridview
            Sql.DB.Connection.Close();

        }
        public void TKTheoTenphim()
        {
          
            Sql.DB.Connection.Open();
            string sql = "select a.TenPhim,a.DaoDien,a.TheLoai,a.ThoiLuong,a.NgayKC,a.NgayKT from Phim a where a.TenPhim=N'" + txttimkiem.Text + "'";
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
            string sql = "select DISTINCT a.TenPhim,a.DaoDien,a.TheLoai,a.ThoiLuong,a.NgayKC,a.NgayKT from Phim a, SuatChieu b where a.MaPhim=b.MaPhim and YEAR(b.NgayChieu)='" + nam + "' " +
                "and MONTH(b.NgayChieu)='"+ thang + "' and DAY(b.NgayChieu)='" + ngay + "' ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Sql.DB.Connection.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            string chon = cbbtimkiem.SelectedItem.ToString();
            if(chon=="Tên phim")
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
