using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP.NhanVien
{
    class Ghe
    {
        public string MaGhe { get; }

        public string TenGhe { get; }

        public Ghe(string maghe, string tenghe)
        {
            MaGhe = maghe;
            TenGhe = tenghe;

        }
    }
}
