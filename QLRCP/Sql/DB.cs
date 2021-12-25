using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QLRCP.Sql
{
    public static class DB
    {
        public const string ConnectionString = @"Data Source=DESKTOP-QCESI1E\PHONG;Initial Catalog=QuanLyRapPhim;Integrated Security=True";
        public static SqlConnection Connection = new SqlConnection(ConnectionString);

    }
}
