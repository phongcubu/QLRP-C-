using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRCP.NhanVien
{
    public partial class HeThongNV : Form
    {
        public HeThongNV()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FDatve a = new FDatve();
            a.ShowDialog();
        }

        private void phimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FXemPhim a = new FXemPhim();
            a.ShowDialog();
        }

        private void suấtChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FSuatChieu a = new FSuatChieu();
            a.ShowDialog();
        }

        private void đặtVéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FHoaDon a = new FHoaDon();
            a.ShowDialog();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDatve a = new FDatve();
            a.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FXemPhim a = new FXemPhim();
            a.ShowDialog();
        }

        private void btxemsuatchieu_Click(object sender, EventArgs e)
        {
            FSuatChieu a = new FSuatChieu();
            a.ShowDialog();
        }

        private void btdatve_Click(object sender, EventArgs e)
        {
            FHoaDon a = new FHoaDon();
            a.ShowDialog();
        }
    }
}
