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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProyectoFinalProgramacionIV.SubmenúComputadoras
{
    public partial class FormConsultarCpus : Form
    {
        public FormConsultarCpus()
        {
            InitializeComponent();
        }

        //FUNCION QUE CARGA LOS DEPARTAMENTOS EN EL COMBOX
        private void CargarCMB_Dep()
        {
            // Realiza la consulta para obtener los datos del código y nombre del departamento
            string consulta = "SELECT codigoDepartamento, nombre FROM tblDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                comboBox1.Items.Clear();
                

                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina el código y el nombre del departamento antes de agregarlos al ComboBox
                    string codigoNombre = $"{reader["codigoDepartamento"].ToString()} - {reader["nombre"].ToString()}";
                    comboBox1.Items.Add(codigoNombre);
                    
                }
            }
        }

        //OBTIENE LOS DATOS EN UN DATATABLE
        private DataTable obtenerDatos(string codigo)
        {
            Conexion.conectar();
            DataTable dt = new DataTable();

            //CONSULTA POR TIPO 
            string consulta = "select patrimonioCPU, marca, modelo, cedulaUsuario, tblDepartamento.nombre as NombreDepartamento from tblComputadora INNER JOIN tblDepartamento ON tblComputadora.codigoDepartamento = tblDepartamento.codigoDepartamento WHERE tblDepartamento.codigoDepartamento = @codigoDepartamento";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@codigoDepartamento", codigo);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }
        

        //CUANDO CARGA EL FORM SE CARGA EL COMBOX
        private void FormConsultarCpus_Load(object sender, EventArgs e)
        {
            CargarCMB_Dep();
            foreach (Control control in dtgCPU.Controls)
            {
                control.ForeColor = Color.Black;
            }
            try
            {
                comboBox1.SelectedIndex = 0;
            }catch (Exception ex)
            {

            }

            
        }

       
        //OBTIENE LOS PRIMEROS CARACTERES DE UN STRING
        private string ObtenerPrimerosNCaracteres(string cadena, int n)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length >= n)
            {
                return cadena.Substring(0, n);
            }

            return string.Empty;
        }

        //CUANDO SE SELECCIONA ALGO DEL COMBOX SE CARGA LOS DATOS
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgCPU.DataSource = obtenerDatos(ObtenerPrimerosNCaracteres(comboBox1.SelectedItem.ToString(), 7));
        }
    }
}
