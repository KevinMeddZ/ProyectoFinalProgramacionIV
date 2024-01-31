using ProyectoFinalProgramacionIV.Pantallas_programa;
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
    public partial class FormEliminarCuenta : Form
    {
        public FormEliminarCuenta()
        {
            InitializeComponent();
        }

        private void FormEliminarCuenta_Load(object sender, EventArgs e)
        {
            dataGridViewEliminarCuenta.DataSource = obtenerDatos();
            hayDatos();
        }

        //VERIFICA SI HAY DATOS EN EL DATAGRIDVIEW
        private void hayDatos()
        {
            Boolean existeDatos = false;
            //RECORRE EL DATAGRIDVIEW
            foreach (DataGridViewRow fila in dataGridViewEliminarCuenta.Rows)
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
                btnEliminarCuenta.Enabled = true;
            }
            else
            {
                btnEliminarCuenta.Enabled = false;
            }
        }


        //OBTIENE LOS DATOS DE LAS CUENTAS
        private DataTable obtenerDatos ()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            //CONSULTA
            string consulta = "SELECT * FROM tblUsuario";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                //OBTIENE LA CEDULA DEL USUARIO
                String cedula = dataGridViewEliminarCuenta.CurrentRow.Cells[0].Value.ToString();
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                
                
                //VERIFICA QUE NO SEA EL MISMO USUARIO (NO FUNCIONA)
                if (cedula == menuPrincipal.labelCedula.Text)
                {
                    MessageBox.Show("NO PUEDES ELIMINAR TU CUENTA SI ESTAS LOGEADO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                {
                    //CONSULTA SI EL USUARIO TIENE UNA COMPUTADORA ASIGNADA...
                    string consultaCompu = "SELECT cedulaUsuario FROM tblComputadora INNER JOIN tblUsuario ON tblComputadora.cedulaUsuario = tblUsuario.cedula WHERE tblComputadora.cedulaUsuario = @cedula";
                    SqlCommand cmd1 = new SqlCommand(consultaCompu, Conexion.conectar());

                    //SI EL USUARIO NO TIENE UNA COMPUTADORA REGISTRADA SE ELIMINA
                    cmd1.Parameters.AddWithValue("@cedula", cedula);
                    if (cmd1.ExecuteScalar() == null)
                    {
                        string consulta = "DELETE FROM tblUsuario WHERE cedula = @cedula";
                        SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                        cmd.Parameters.AddWithValue("@cedula", cedula);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cuenta eliminada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //ACTUALIZA LOS CAMPOS
                        dataGridViewEliminarCuenta.DataSource = obtenerDatos();
                        hayDatos();
                        
                    }
                    //SI EL USUARIO TIENE UNA COMPUTADORA REGISTRADA SE LE ENVÍA UN MENSAJE DE QUE TIENE QUE QUITAR LA ASIGNACION DE LA COMPUTADORA
                    else
                    {
                        MessageBox.Show("ERROR, EL USUARIO TIENE ASIGNADA UNA COMPUTADORA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }catch (SqlException ex)
            {
                MessageBox.Show("No se puede eliminar este usuario porque está asignado a otra tabla", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
