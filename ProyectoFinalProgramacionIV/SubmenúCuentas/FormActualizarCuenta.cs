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

namespace ProyectoFinalProgramacionIV.SubmenúCuentas
{
    public partial class FormActualizarCuenta : Form
    {
        public FormActualizarCuenta()
        {
            InitializeComponent();
        }

        private void FormActualizarCuenta_Load(object sender, EventArgs e)
        {
            dataGridViewConsulta.DataSource = obtenerDatos();
            txtContraNueva.Enabled = false;
            button1.Enabled = false;
        }


        private DataTable obtenerDatos()
        {
            string consulta = "SELECT * FROM tblUsuario";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        

        private void dataGridViewConsulta_SelectionChanged(object sender, EventArgs e)
        {
            //SE VERIFICA QUE HAY UNA FILA SELECCIONADA
            if (dataGridViewConsulta.SelectedRows.Count > 0)
            {
                //SE OBTIENE LA FILA SELECCIONADA
                DataGridViewRow filaSeleccionada = dataGridViewConsulta.SelectedRows[0];

                //SE OBTIENE LOS VALORES DE LAS CELDAS EN LA FILA SELECCIONADA
                string cedula = filaSeleccionada.Cells["cedula"].Value.ToString();
                string contraseña = filaSeleccionada.Cells["clave"].Value.ToString();

                //SE LLENA LOS TEXTBOX
                txtCedula.Text = cedula;
                txtContraseña.Text = contraseña;
                txtContraNueva.Enabled = true;
                button1.Enabled = true;

            }

            if (txtCedula.Text.Equals(""))
            {
                txtContraNueva.Enabled = false;
                button1.Enabled = false;
            }
        }

        //CUANDO PRESIONA EL BOTON DE ACTUALIZAR
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //SE OBTIENE EL NUMERO DE CEDULA DEL USUARIO SELECCIONADO
                string cedula = dataGridViewConsulta.CurrentRow.Cells[0].Value.ToString();
                //SE OBTIENE LA CONTRASEÑA NUEVA
                string contraNueva = txtContraNueva.Text;

                //CONSULTA PARA ACTUALIZAR
                string consulta = "UPDATE tblUsuario SET clave = @contraNueva WHERE cedula = @cedula";
                SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                cmd.Parameters.AddWithValue("@contraNueva", contraNueva);
                cmd.Parameters.AddWithValue("@cedula", cedula);

                //SI EL TAMAÑO DE LA CONTRASEÑA ES MAYOR A 8
                if (txtContraNueva.TextLength >= 8)
                {
                    //SE EJECUTA EL COMANDO
                    cmd.ExecuteNonQuery();

                    //SE ACTUALIZA LOS DATOS
                    dataGridViewConsulta.DataSource = obtenerDatos();
                    MessageBox.Show("CONTRASEÑA ACTUALIZADA PARA EL USUARIO CON CEDULA " + cedula);

                    txtContraseña.Text = "";
                    txtContraNueva.Text = "";
                    txtCedula.Text = "";

                    txtContraNueva.Enabled = false;
                    button1.Enabled = false;
                }else
                {
                    MessageBox.Show("La contraseña debe tener un tamaño mínimo de 8 carácteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
