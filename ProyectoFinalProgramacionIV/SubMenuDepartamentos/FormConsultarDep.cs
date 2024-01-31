using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinalProgramacionIV
{
    public partial class FormConsultarDep : Form
    {
        public FormConsultarDep()
        {
            InitializeComponent();
        }

        
        //FUNCION QUE OBTIENE LOS PRIMEROS CARACTERES DE UN STRING
        private string ObtenerPrimerosNCaracteres(string cadena, int n)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length >= n)
            {
                return cadena.Substring(0, n);
            }

            return string.Empty;
        }

        
        //FUNCION QUE OBTIENE LOS DATOS DE LOS USUARIOS DEL DEPARTAMENTO
        private DataTable mostrarUsuarios(string codDepartamento)
        {
            DataTable dt = new DataTable();
            try
            {
                string consulta = "SELECT tblDepartamento.nombre as Departamento, tblUsuario.cedula as CedulaUsuario, tblUsuario.nombre as NombreUsuario, primerApellido, segundoApellido FROM tblUsuario INNER JOIN tblDepartamento ON tblUsuario.codigoDepartamento = tblDepartamento.codigoDepartamento WHERE tblDepartamento.codigoDepartamento = @codDepartamento";
                
                using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
                {
                    cmd.Parameters.AddWithValue("@codDepartamento", codDepartamento);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
            
        }

        private DataTable mostrarCantidadCompus()
        {
            DataTable dt = new DataTable();
            try
            {
                string consulta = "select tblDepartamento.nombre as Departamento, count(tblComputadora.codigoDepartamento) as CantidadComputadoras from tblComputadora INNER JOIN tblDepartamento ON tblComputadora.codigoDepartamento = tblDepartamento.codigoDepartamento GROUP BY tblComputadora.codigoDepartamento, tblDepartamento.nombre";

                using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
                {
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }
       

        //FUNCION QUE CARGA LOS CODIGOS DE LOS DEPARTAMENTOS EN EL COMBOX
        private void CargarCMB_Dep()
        {
            // Realiza la consulta para obtener los datos del código y nombre del departamento
            string consulta = "SELECT codigoDepartamento, nombre FROM tblDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                cmb_Dep.Items.Clear();


                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina el código y el nombre del departamento antes de agregarlos al ComboBox
                    string codigoNombre = $"{reader["codigoDepartamento"].ToString()} - {reader["nombre"].ToString()}";
                    cmb_Dep.Items.Add(codigoNombre);

                }
            }
        }

        //CUANDO CARGA EL FORM SE CARGA EL COMBOBOX
        private void FormConsultarDep_Load(object sender, EventArgs e)
        {
            CargarCMB_Dep();
            dgvDatosCompus.DataSource = mostrarCantidadCompus();
        }

        //CUANDO CAMBIA LA SELECCION DEL COMBOBOX SE MUESTRA LOS RESULTADOS
        private void cmb_Dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDatosEmpleados.DataSource = mostrarUsuarios(ObtenerPrimerosNCaracteres(cmb_Dep.SelectedItem.ToString(), 7));
            

        }
    }
}
