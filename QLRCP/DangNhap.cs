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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            this.Close();

        }
        public void gettrang()
        {
            txtdn.Text = " ";
            txtmk.Text = " ";
            cbbquyen.Text = " ";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string quyen = cbbquyen.Text;
            if(quyen=="Admin")
            {
                Sql.DB.Connection.Open();
                string sql = "SELECT * FROM NguoiDung WHERE TenND ='"+txtdn.Text+"' AND MatKhau = '"+txtmk.Text+"'";
                SqlCommand cmd = new SqlCommand(sql, Sql.DB.Connection);
                SqlDataReader re = cmd.ExecuteReader();
                if (re.Read()==true)
                {
                    this.Hide();
                    HeThong a = new HeThong();
                    a.Show();
                   

                }
                
                else
                {
                  
                    MessageBox.Show("Tên người dùng hoặc Mật khẩu không đúng!");
                    gettrang();
                    
                }
               Sql.DB.Connection.Close();

             }
            else
            {
                Sql.DB.Connection.Open();
                string sql = "SELECT * FROM NhanVien WHERE MaNV ='" + txtdn.Text + "' AND MatKhau = '" + txtmk.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Sql.DB.Connection);
                SqlDataReader re = cmd.ExecuteReader();
                if (re.Read() == true)
                {
                    this.Hide();
                    NhanVien.HeThongNV a = new NhanVien.HeThongNV();
                    a.Show();


                }

                else
                {

                    MessageBox.Show("Tên người dùng hoặc Mật khẩu không đúng!");
                    gettrang();

                }
                Sql.DB.Connection.Close();
            }


        }

        private void tbtdn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
