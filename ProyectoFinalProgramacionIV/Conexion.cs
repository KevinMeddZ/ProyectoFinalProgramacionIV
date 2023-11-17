using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacionIV
{
    internal class Conexion
    {

        public static SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=KEVIN\\SQLEXPRESS; DATABASE = db_ProyectoPrograIV; Integrated security=true");
            cn.Open();
            return cn;
        }
    }
}
