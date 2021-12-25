using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP
{
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();

        }
   

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void phimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLPhim a = new QLPhim();
            a.ShowDialog();

        }

        private void phòngChiéuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLPChieu a = new QLPChieu();
            a.ShowDialog();
        }

        private void lịchChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSChieu a = new QLSChieu();
            a.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLKhachHang a = new QLKhachHang();
            a.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNhanViencs a = new QLNhanViencs();
            a.ShowDialog();
        }

       

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLHoaDon a = new QLHoaDon();
            a.ShowDialog();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLNCC a = new QLNCC();
            a.ShowDialog();
        }
    }
}
