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
    public partial class FormActualizarInstalacion : Form
    {
        public FormActualizarInstalacion()
        {
            InitializeComponent();
        }

        private void FormActualizarInstalacion_Load(object sender, EventArgs e)
        {
            CargarCMB_Dep();
            cmbCPU.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDep.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTiempo.DropDownStyle = ComboBoxStyle.DropDownList; 
            
            cmbDep.SelectedIndex = 0;
            cmbTiempo.SelectedIndex = 0;

            btnConfirmar.Enabled = false;
        }

        private void CargarCMB_Dep()
        {
            // Realiza la consulta para obtener los datos del código y nombre del departamento
            string consulta = "SELECT codigoDepartamento, nombre FROM tblDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                cmbDep.Items.Clear();
                

                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina el código y el nombre del departamento antes de agregarlos al ComboBox
                    string codigoNombre = $"{reader["codigoDepartamento"].ToString()} - {reader["nombre"].ToString()}";
                    cmbDep.Items.Add(codigoNombre);
                    
                }
            }
        }

        private DataTable obtenerDatos(string patrimonioCPU)
        {
            Conexion.conectar();
            DataTable dt = new DataTable();

            //CONSULTA POR TIPO 
            string consulta = "select tblInstalacion.idSoftware, tblSoftware.nombre, fechaInstalacion, fechaVencimiento, tblSoftware.tipoLicencia from tblInstalacion INNER JOIN tblSoftware ON tblInstalacion.idSoftware = tblSoftware.idSoftware WHERE patrimonioCPU = @patrimonioCPU and fechaVencimiento is not null";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@patrimonioCPU", patrimonioCPU);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }


        private void cmdDep_SelectedIndexChanged(object sender, EventArgs e)
        {

            string seleccion = cmbDep.SelectedItem?.ToString();
            

            if (!string.IsNullOrEmpty(seleccion))
            {
                // Dividir la cadena por el guion y obtener el primer elemento (código)
                string[] partes = seleccion.Split('-');

                if (partes.Length > 0)
                {
                    string codigo = partes[0].Trim();
                   
                    obtenerDatosCpus(codigo);
                    cmbCPU.Enabled = true;
                }
            }


            btnConfirmar.Enabled = false;
            dgvActualizarInstalacion.DataSource = null;
        }

        private void obtenerDatosCpus(string codigo)
        {
            Conexion.conectar();

            // CONSULTA POR TIPO 
            string consulta = "SELECT patrimonioCPU, marca, modelo FROM tblComputadora WHERE codigoDepartamento = @codigoDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@codigoDepartamento", codigo );

                SqlDataReader reader = cmd.ExecuteReader();

                cmbCPU.Items.Clear();

                while (reader.Read())
                {
                    // Combina el número de patrimonio, la marca y el modelo antes de agregarlos al ComboBox
                    string infoCPU = $"{reader["patrimonioCPU"].ToString()} - {reader["marca"].ToString()} - {reader["modelo"].ToString()}";
                    cmbCPU.Items.Add(infoCPU);
                }
            }


        }

        private string ObtenerPrimerosNCaracteres(string cadena, int n)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length >= n)
            {
                return cadena.Substring(0, n);
            }

            return string.Empty;
        }

        private void cmbDep_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbCPU.Text = "";
        }

        private void cmbCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Extraer patrimonio de CPU del ComboBox de CPU
            string seleccionCPU = cmbCPU.SelectedItem?.ToString();
            string patrimonioCPU = ObtenerPrimerosNCaracteres(seleccionCPU, 6);

            dgvActualizarInstalacion.DataSource = obtenerDatos(patrimonioCPU);

            //SI EL DATAGRIDVIEW ESTA VACIO...
            if (hayDatos() == true)
            {
                btnConfirmar.Enabled = true;
            }else
            {
                btnConfirmar.Enabled = false;
            }
            

        }


        //VERIFICA SI EXISTE DATO EN DATAGRID VIEW
        private Boolean hayDatos()
        {
            Boolean existeDatos = false;
            //RECORRE EL DATAGRIDVIEW
            foreach (DataGridViewRow fila in dgvActualizarInstalacion.Rows)
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
            return existeDatos;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                //OBTIENE EL ID DEL SOFTWARE
                int idSoftware = int.Parse(dgvActualizarInstalacion.CurrentRow.Cells[0].Value.ToString());

                int mesesAñadidos;
                if (int.TryParse(cmbTiempo.SelectedItem.ToString(), out mesesAñadidos))
                {
                    string fechaActualStr = dgvActualizarInstalacion.CurrentRow.Cells[3].Value.ToString();

                    // Convertir la cadena a DateTime
                    if (DateTime.TryParse(fechaActualStr, out DateTime fechaActual))
                    {
                        // Agregar meses a la fecha
                        DateTime nuevaFechaVencimiento = fechaActual.AddMonths(mesesAñadidos);

                        // UPDATE
                        string consulta = "UPDATE tblInstalacion SET fechaVencimiento = @fechaVencimiento WHERE idSoftware = @idSoftware";

                        SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());

                        cmd.Parameters.AddWithValue("@idSoftware", idSoftware);
                        cmd.Parameters.AddWithValue("@fechaVencimiento", nuevaFechaVencimiento);

                        // SE EJECUTA EL COMANDO
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Licencia extendida exitosamente");

                        // ACTUALIZA LA TABLA

                        // Extraer patrimonio de CPU del ComboBox de CPU
                        string seleccionCPU = cmbCPU.SelectedItem?.ToString();
                        string patrimonioCPU = ObtenerPrimerosNCaracteres(seleccionCPU, 6);

                        dgvActualizarInstalacion.DataSource = obtenerDatos(patrimonioCPU);

                        // RESETEO DE DATOS
                        cmbTiempo.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("La fecha actual no es válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un tiempo para extender la licencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
