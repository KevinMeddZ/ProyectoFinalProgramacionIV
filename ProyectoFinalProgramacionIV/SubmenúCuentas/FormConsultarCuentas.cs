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

namespace ProyectoFinalProgramacionIV.SubmenúCuentas
{
    public partial class FormConsultarCuentas : Form
    {
        public FormConsultarCuentas()
        {
            InitializeComponent();
        }

        private void FormConsultarCuentas_Load(object sender, EventArgs e)
        {
            CargarCMB_Dep();
            
        }

        //CARGA LOS DEPARTAMENTOS EN EL COMBOBOX
        private void CargarCMB_Dep()
        {
            // Realiza la consulta para obtener los datos del código y nombre del departamento
            string consulta = "SELECT codigoDepartamento, nombre FROM tblDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                comboBoxDepartamentos.Items.Clear();


                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina el código y el nombre del departamento antes de agregarlos al ComboBox
                    string codigoNombre = $"{reader["codigoDepartamento"].ToString()} - {reader["nombre"].ToString()}";
                    comboBoxDepartamentos.Items.Add(codigoNombre);

                }
            }
        }

        //OBTIENE LOS DATOS DE LA CONSULTA DE USUARIOS DEPENDIENDO DEL CODIGO DEL DEPARTAMENTOS
        private DataTable obtenerDatos(string codigo)
        {
            DataTable dt = new DataTable();
            //CONSULTA POR DEPARTAMENTO
            string consulta = "SELECT * FROM tblUsuario WHERE codigoDepartamento = @codigo";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@codigo", codigo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


        private void comboBoxDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = comboBoxDepartamentos.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(seleccion))
            {
                // Dividir la cadena por el guion y obtener el primer elemento (código)
                string[] partes = seleccion.Split('-');

                if (partes.Length > 0)
                {
                    string codigo = partes[0].Trim();
                    dataGridViewCuentas.DataSource = obtenerDatos(codigo);

                }
            }
        }
    }
}
