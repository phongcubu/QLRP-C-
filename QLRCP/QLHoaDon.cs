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
    public partial class QLHoaDon : Form
    {
        public QLHoaDon()
        {
            InitializeComponent();
            getData();
        }
        public void getData()
        {

            Sql.DB.Connection.Open();

            string sql = "SELECT a.MaHD,c.TenKH,b.TenNV,a.NgayHD,Count(d.MaVe)as SLV,Sum(e.GiaVe) as TT " +
                "FROM HoaDon a,NhanVien b, KhachHang c,Ve d, LoaiVe e" +
                " Where a.MaKH = c.MaKH and a.MaNV = b.MaNV  and d.MaLV = e.MaLV and a.MaHD = d.MaHD " +
                "Group by  a.MaHD,c.TenKH,b.TenNV,a.NgayHD ,d.MaHD,d.MaHD ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            txthd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();

            string sql = "SELECT d.MaVe,d.TenVe,b.TenPhim,e.TenLV,e.GiaVe,c.TenPhong,k.TenGhe,l.GioBD,l.GioKT " +
                "FROM HoaDon a,Phim b, Phong c,Ve d, LoaiVe e ,Ghe k, SuatChieu s,LichChieu l" +
                " Where a.MaHD = d.MaHD and e.MaLV = d.MaLV and d.MaSC = s.MaSC and s.MaLC = l.MaLC and d.MaGhe = k.MaGhe " +
                "and c.MaPhong = k.MaPhong and b.MaPhim = s.MaPhim and s.MaPhong = c.MaPhong " +
                "and a.MaHD = '"+txthd.Text+"' ";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }
    }
}
