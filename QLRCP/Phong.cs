using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP
{
    class Phong
    {
        public string MaPhong { get; }

        public string TenPhong { get; }



        public Phong(string map, string tenp)
        {
            MaPhong = map;
            TenPhong = tenp;

        }
    }
}
