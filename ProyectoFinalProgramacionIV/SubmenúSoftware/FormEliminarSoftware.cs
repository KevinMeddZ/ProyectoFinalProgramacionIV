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
    public partial class FormEliminarSoftware : Form
    {
        public FormEliminarSoftware()
        {
            InitializeComponent();
            dataGridViewEliminarSoftware.DataSource = obtenerDatos();
        }

        //METODO PARA OBTENER LOS DATOS AL DATAGRIDVIEW
        private DataTable obtenerDatos()
        {
            Conexion.conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM tblSoftware";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }


        //ELIMINA EL SOFTWARE
        private void btnEliminarSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                //OBTIENE EL ID DEL SOFTWARE
                int idSoftware = int.Parse(dataGridViewEliminarSoftware.CurrentRow.Cells[0].Value.ToString());
                //
                string consulta = "DELETE FROM tblSoftware WHERE idSoftware = @idSoftware";

                SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                cmd.Parameters.AddWithValue("@idSoftware", idSoftware);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Software eliminado", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ACTUALIZA LA TABLA
                dataGridViewEliminarSoftware.DataSource =  obtenerDatos();

                //VERIFICA SI HAY DATOS O NO PARA HABILITAR EL BOTON
                if (hayDatos() == true)
                {
                    btnEliminarSoftware.Enabled = true;
                }
                else
                {
                    btnEliminarSoftware.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //CAMBIAR EL FONT DEL GRIDVIEW
        private void FormEliminarSoftware_Load(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                control.ForeColor = Color.Black;
            }

            //VERIFICA QUE EXISTA DATOS
            if (hayDatos() == true)
            {
                btnEliminarSoftware.Enabled = true;
            }else
            {
                btnEliminarSoftware.Enabled=false;
            }
        }

        //VERIFICA SI EXISTE DATO EN DATAGRID VIEW
        private Boolean hayDatos()
        {
            Boolean existeDatos = false;
            //RECORRE EL DATAGRIDVIEW
            foreach (DataGridViewRow fila in dataGridViewEliminarSoftware.Rows)
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


    }
}
