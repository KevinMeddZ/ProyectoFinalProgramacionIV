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

namespace ProyectoFinalProgramacionIV.SubmenúComputadoras
{
    public partial class FormEliminarCPU : Form
    {
        public FormEliminarCPU()
        {
            InitializeComponent();
            

        }

        //OBTIENE LOS PRIMEROS N CARACTERES DE UN STRING
        private string ObtenerPrimerosNCaracteres(string cadena, int n)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length >= n)
            {
                return cadena.Substring(0, n);
            }

            return string.Empty;
        }

        //OBTIENE LOS DATOS DE CPU EN UN DATATABLE PARA ENVIARLOS AL DATAGRIDVIEW
        private DataTable obtenerDatos(string codigo)
        {
            Conexion.conectar();
            DataTable dt = new DataTable();

            //CONSULTA POR TIPO 
            string consulta = "SELECT patrimonioCPU, marca, modelo, numeroSerie, cedulaUsuario AS CedulaUsuarioAsignado, tblUsuario.nombre AS NombreUsuario, tblUsuario.primerApellido + ' ' + tblUsuario.segundoApellido AS apellidos FROM tblComputadora LEFT JOIN tblUsuario ON tblComputadora.cedulaUsuario = tblUsuario.cedula WHERE tblComputadora.codigoDepartamento = @codigoDepartamento AND (tblComputadora.cedulaUsuario IS NULL OR @codigoDepartamento = 'Bodega')";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@codigoDepartamento", codigo);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        //CARGA EL COMBOBOX DE DEPARTAMENTOS
        private void CargarCMB()
        {
            
            // Realiza la consulta para obtener los datos de la columna codigoDepartamento
            string consulta = "SELECT codigoDepartamento, nombre FROM tblDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                cmbDepartamentos.Items.Clear();

                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina el código y el nombre del departamento antes de agregarlos al ComboBox
                    string codigoNombre = $"{reader["codigoDepartamento"].ToString()} - {reader["nombre"].ToString()}";
                    cmbDepartamentos.Items.Add(codigoNombre);
                }
            }
        }

     
        
        //CUADNO SELECCIONA UN ELEMENTO DEL COMBOBOX...
        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OBTIENE EL CODIGO DEL DEPARTAMENTO...
            string codigo = ObtenerPrimerosNCaracteres(cmbDepartamentos.SelectedItem.ToString(), 7);
            //LO SETEA EN EL DATAGRIDVIEW CON LA FUNCION DE OBTENER DATOS
            dtgCompu.DataSource = obtenerDatos(codigo);

            hayDatos();
        }


        //CUANDO CLICKEA EL BOTON DE ELIMINAR
        private void btnEliminarComputadora_Click(object sender, EventArgs e)
        {
            try
            {
                //OBTIENE EL ID DEL SOFTWARE DEL DATAGRIDVIEW
                string patrimonioCPU = (dtgCompu.CurrentRow.Cells[0].Value.ToString());
                //SE REALIZA LA CONSULTA
                string consulta = "DELETE FROM tblComputadora WHERE patrimonioCPU = @patrimonioCPU";

                SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                cmd.Parameters.AddWithValue("@patrimonioCPU", patrimonioCPU);
                //SE EJECUTA EL PROGRAMA
                cmd.ExecuteNonQuery();
                MessageBox.Show("CPU eliminado");
                //ACTUALIZA LA TABLA
                string codigo = cmbDepartamentos.SelectedItem.ToString();
                dtgCompu.DataSource = obtenerDatos(codigo);

                hayDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imposible eliminar este CPU ESTANDO EN USO " + ex.Message);
            }
        }

        //CUANDO CARGA EL FORM
        private void FormEliminarCPU_Load(object sender, EventArgs e)
        {
            //CARGA LOS DATOS EN EL COMBOBOX
            CargarCMB();

            //VERIFICA SI HAY DATOS
            hayDatos();
        }

        private void hayDatos()
        {
            Boolean existeDatos = false;
            //RECORRE EL DATAGRIDVIEW
            foreach (DataGridViewRow fila in dtgCompu.Rows)
            {
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (celda.Value != null && celda.Value.ToString() != "")
                    {
                        //Hay datos en alguna celda
                        existeDatos = true;
                        break;
                    }
                }
            }
            //RETORNA SI EXISTE DATOS O NO
            if (existeDatos == true)
            {
                btnEliminarComputadora.Enabled = true;
            }
            else
            {
                btnEliminarComputadora.Enabled = false;
            }
        }
    }
}
