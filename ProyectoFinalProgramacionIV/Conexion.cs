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
        //CLASE PARA CONEXION  A BASE DE DATOS//
        public static SqlConnection conectar()
        {
            string kevin = "KEVIN\\SQLEXPRESS";
            string ronald = "DESKTOP-T1V2NRK\\SQLEXPRESS";

            // Cadena de conexion SQL SERVER//

            SqlConnection cn = new SqlConnection("Data Source=KEVIN\\SQLEXPRESS;Initial Catalog=db_ProyectoPrograIV;Integrated Security=True;");

            //SI LA CONEXION ESTA CERRADA LA ABRE
            if (cn.State == System.Data.ConnectionState.Closed) {
                cn.Open();
                  
            }

            return cn;

        }
    }
}
