using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP.NhanVien
{
    class LoaiVe
    {
        public string MaLV { get; }

        public string TenLV { get; }

        

        public LoaiVe(string malv, string tenlv)
        {
            MaLV = malv;
            TenLV = tenlv;

        }
    }
}
