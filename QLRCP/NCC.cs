using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRCP
{
    class NCC
    {
        public string MaNCC { get; }

        public string TenNCC { get; }



        public NCC(string mancc, string tenncc)
        {
            MaNCC = mancc;
            TenNCC = tenncc;

        }
    }
}
