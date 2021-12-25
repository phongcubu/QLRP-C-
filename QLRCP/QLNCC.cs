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
    public partial class QLNCC : Form
    {
        public QLNCC()
        {
            InitializeComponent();
            getData();
        }
        public void getData()
        {
            Sql.DB.Connection.Open();

            string sql = "select * from NhaCungCap";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();

        }
        public void gettrang()
        {
            tbmncc.Text = string.Empty;
            tbtncc.Text = string.Empty;
            tbdc.Text = string.Empty;
            tbe.Text = string.Empty;
            tbsdt.Text = string.Empty;
            tbtk.Text = string.Empty;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sql.DB.Connection.Open();
            string sql = "select * from NhaCungCap Where TenNCC=N'" + tbtk.Text + "'";
            SqlDataAdapter adapt = new SqlDataAdapter(sql, Sql.DB.Connection);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            Sql.DB.Connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO NhaCungCap(MaNCC,TenNCC,DiaChi,SDT,Email) " +
                "VALUES('" + tbmncc.Text + "',N'" + tbtncc.Text + "',N'" + tbdc.Text + "',N'" + tbsdt.Text + "',N'" + tbe.Text + "')", Sql.DB.Connection);
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

            tbmncc.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbtncc.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbdc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            tbsdt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbe.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update NhaCungCap set TenNCC=N'" + tbtncc.Text + "',DiaChi=N'" + tbdc.Text + "'," +
                " SDT=N'" + tbsdt.Text + "', Email=N'" + tbe.Text + "'" +
                " Where MaNCC='" + tbmncc.Text + "'", Sql.DB.Connection);

            Sql.DB.Connection.Open();
            cmd.ExecuteNonQuery();
            Sql.DB.Connection.Close();
            MessageBox.Show("Sửa thành công!!!");
            getData();
            gettrang();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete NhaCungCap Where MaNCC='" + tbmncc.Text + "' ", Sql.DB.Connection);
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
