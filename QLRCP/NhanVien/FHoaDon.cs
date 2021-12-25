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
  
    public partial class FHoaDon : Form

    {
        
        Dictionary<string, NhanVien> nhanviend = new Dictionary<string, NhanVien>();
    
        public FHoaDon()
        {
            InitializeComponent();
            cbbnhanvien.DisplayMember = "TenNV";
            cbbnhanvien.ValueMember = "MaNV";

            getCBBNV();

        }
        private void getCBBNV()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT a.MaNV, a.TenNV FROM NhanVien a", Sql.DB.Connection);

            Sql. DB.Connection.Open();
            SqlDataReader dr = sqlCmd.ExecuteReader();

            nhanviend = new Dictionary<string, NhanVien>();
            while (dr.Read())
            {
                NhanVien nv = new NhanVien((string)dr[0], (string)dr[1]);
                cbbnhanvien.Items.Add(nv);
                nhanviend[nv.MaNV] = nv;
            }

            Sql.DB.Connection.Close();
        }

        public void themKH()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO KhachHang(MaKH,TenKH,DiaChi,SDT) " +
               "VALUES('" + txtmakh.Text + "',N'" + txttenkh.Text + "',N'" + txtdiachi.Text + "','" + txtsdt.Text + "' )", Sql.DB.Connection);
            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();

            Sql.DB.Connection.Close();

            MessageBox.Show("Thêm khách hàng thành công!!!");
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            themKH();
        }
        public void themHD()
        {
            DateTime ngay= DateTime.Now;
            SqlCommand cmd = new SqlCommand("INSERT INTO HoaDon(MaHD,MaNV,MaKH,NgayHD) VALUES(@mahd, @manv, @makh, @ngayhd)", Sql.DB.Connection);
            Sql.DB.Connection.Open();

            cmd.Parameters.AddWithValue("@mahd", txtmahd.Text);
            cmd.Parameters.AddWithValue("@manv", ((NhanVien)cbbnhanvien.SelectedItem).MaNV);
            cmd.Parameters.AddWithValue("@makh", txtmakh.Text);
            cmd.Parameters.AddWithValue("@ngayhd", ngay);
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Thêm hóa đơn thành công!!!");
        }
        public void getData()
        {

            Sql.DB.Connection.Open();

            string sql = "SELECT a.MaHD,b.TenNV,c.TenKH,a.NgayHD FROM HoaDon a,NhanVien b, KhachHang c Where a.MaKH=c.MaKH and a.MaNV=b.MaNV and a.MaHD='"+txtmahd.Text+"'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql,Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }
            private void button1_Click(object sender, EventArgs e)
        {
            themHD();
            getData();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FDatve a = new FDatve();
            a.MaHD = txtmahd.Text;
            a.Show();

           
        }

        
    }
}
