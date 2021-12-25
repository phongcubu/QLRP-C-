using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP.NhanVien
{
    class NhanVien
    {
        public string MaNV { get; }

        public string TenNV { get; }

       

        public NhanVien(string maNV, string tenNV)
        {
            MaNV = maNV;
            TenNV = tenNV;
         
        }
    }
}
