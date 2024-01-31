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

namespace ProyectoFinalProgramacionIV.SubmenúSoftware
{
    public partial class FormActualizarSoftware : Form
    {
        public FormActualizarSoftware()
        {
            InitializeComponent();
            dataGridViewActualizarSoftware.DataSource = obtenerDatos();
        }

        //CAMBIAR EL FONT DEL GRIDVIEW
        private void FormActualizarSoftware_Load(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                control.ForeColor = Color.Black;
            }

            //VERIFICA SI HAY DATOS
            hayDatos();
        }

        //VERIFICA SI HAY DATOS O SI NO DESACTIVA EL BOTON
        private void hayDatos()
        {
            Boolean existeDatos = false;
            //RECORRE EL DATAGRIDVIEW
            foreach (DataGridViewRow fila in dataGridViewActualizarSoftware.Rows)
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
            if (existeDatos == true )
            {
                btnConfirmar.Enabled = true;
            }else
            {
                btnConfirmar.Enabled=false;
            }
        }


        //METODO PARA OBTENER LOS DATOS AL DATAGRIDVIEW
        private DataTable obtenerDatos()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT idSoftware, nombre, versionSoftware, tipoLicencia, funcionalidad, cantidad, vencimiento FROM tblSoftware where vencimiento != 'Sin vencimiento'";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                //OBTIENE EL ID DEL SOFTWARE
                int idSoftware = int.Parse(dataGridViewActualizarSoftware.CurrentRow.Cells[0].Value.ToString());

                //OBTIENE LA CANTIDAD DE LICENCIAS DISPONIBLES
                int cantidadActual = int.Parse(dataGridViewActualizarSoftware.CurrentRow.Cells[5].Value.ToString());

                //SE OBTIENE LA CANTIDAD QUE SE QUIERE AGREGAR
                int cantidadNueva = int.Parse(txtCantidadLicencias.Text);

                //SE OBTIENE LA VERSION ACTUAL DEL SOFTWARE
                int versionActual = int.Parse(dataGridViewActualizarSoftware.CurrentRow.Cells[2].Value.ToString());

                //SE LE SUMA
                cantidadActual += cantidadNueva;

                //SE LE ACTUALIZA LA VERSION DEL SOFTWARE
                versionActual += 1;

                //UPDATE
                string consulta = "UPDATE tblSoftware SET cantidad = @cantidadNueva, versionSoftware = @versionNueva WHERE idSoftware = @idSoftware";

                SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                cmd.Parameters.AddWithValue("@cantidadNueva", cantidadActual.ToString());
                cmd.Parameters.AddWithValue("@versionNueva", versionActual.ToString());
                cmd.Parameters.AddWithValue("@idSoftware", idSoftware);

                //SI LA CANTIDAD ES UN NUMERO MAYOR O IGUAL A 1
                if (cantidadNueva >= 1)
                {
                    //SE EJECUTA EL COMANDO
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cantidad de licencias actualizadas");
                    //ACTUALIZA LA TABLA
                    dataGridViewActualizarSoftware.DataSource = obtenerDatos();
                    //RESETEO DE DATOS
                    cantidadActual = 0;
                    cantidadNueva = 0;
                    txtCantidadLicencias.Text = "";

                    
                }else
                {
                    MessageBox.Show("Cantidad de licencias nuevas debe ser un numero mayor o igual a 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCantidadLicencias_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter ingresado no es un número o la tecla de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número o la tecla de retroceso, cancela el evento KeyPress
                e.Handled = true;
            }
        }
    }
}
