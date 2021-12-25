using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP
{
    class Phim
    {
        public string MaPhim { get; }
        public string TenPhim { get; }
        public Phim(string maphim, string tenphim)
        {
            MaPhim = maphim;
            TenPhim = tenphim;

        }
    }
}
