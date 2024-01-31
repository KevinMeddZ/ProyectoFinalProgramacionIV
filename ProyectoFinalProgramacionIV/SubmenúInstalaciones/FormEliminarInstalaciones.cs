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

namespace ProyectoFinalProgramacionIV.SubmenúInstalaciones
{
    public partial class FormEliminarInstalaciones : Form
    {
        public FormEliminarInstalaciones()
        {
            InitializeComponent();
        }


        

        //FUNCION QUE CARGA LAS COMPUTADORAS EN EL COMBOX DE COMPUTADORAS
        private void cargarComboBoxComputadora()
        {
            string consulta = "SELECT patrimonioCPU, marca, modelo FROM tblComputadora";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                //LIMPIA LOS ELEMENTOS DEL COMBOBOX
                comboBoxComputadora.Items.Clear();

                //AGREGA LOS DATOS AL COMBOBOX
                while (dr.Read())
                {
                    //FORMATO PARA QUE SEA VEA BIEN
                    string comp = $"{dr["patrimonioCPU"].ToString()} - {dr["marca"].ToString()} - {dr["modelo"].ToString()}";
                    //SE AGREGA AL COMBOBOX
                    comboBoxComputadora.Items.Add(comp);
                }

            }
        }


        //CARGA EL DATAGRIDVIEW
        private DataTable cargarDW(string patrimonio)
        {
            string consulta = "select nombre, cedulaUsuario as cedulaInstalo, fechaInstalacion, tblSoftware.vencimiento as VencimientoLicencia from tblInstalacion \r\n\tINNER JOIN tblSoftware ON tblInstalacion.idSoftware = tblSoftware.idSoftware WHERE patrimonioCPU = @patrimonio";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@patrimonio", patrimonio);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;

        }

        //SEPARA LOS CARACTERES DEL COMBOBOX
        private string ObtenerPrimerosNCaracteres(string cadena, int n)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length >= n)
            {
                return cadena.Substring(0, n);
            }

            return string.Empty;
        }

        private void comboBoxComputadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SE OBTIENE LOS DATOS A CONSULTAR
            string patrimonio = ObtenerPrimerosNCaracteres(comboBoxComputadora.SelectedItem.ToString(), 7);

            dataGridViewSoftware.DataSource = cargarDW(patrimonio);

            hayDatos();

        }



        //CUANDO CARGA EL FORM
        private void FormEliminarInstalaciones_Load(object sender, EventArgs e)
        {
            cargarComboBoxComputadora();
            hayDatos();
        }


        //FUNCION QUE OBTIENE EL ID DEL SOFTWARE POR EL NOMBRE
        private string obtenerIdSoftware(string nombre)
        {
            //SE OBTIENE EL ID DEL SOFTWARE POR EL NOMBRE DEL SOFTWARE
            string idSoftware = "SELECT idSoftware FROM tblSoftware WHERE nombre = @nombre";
            SqlCommand cmd = new SqlCommand(idSoftware, Conexion.conectar());
            cmd.Parameters.AddWithValue("@nombre", nombre);
            string id = cmd.ExecuteScalar().ToString();

            return id;
        }



        





        //CUANDO PULSA EL BOTON ELIMINA EL SOFTWARE DE LA COMPUTADORA SELECCIONANDO EL PATRIMONIO DEL CPU Y MEDIANTE EL NOMBRE SE OBTIENE EL ID Y SE REALIZA EL COMANDO
        private void btnDesinstalar_Click(object sender, EventArgs e)
        {
            //COMANDO PARA ELIMINAR
            string comando = "DELETE FROM tblInstalacion WHERE patrimonioCPU = @patrimonio AND idSoftware = @idSoftware";
            try
            {
                //SE OBTIENE LOS DATOS A CONSULTAR
                string patrimonio = ObtenerPrimerosNCaracteres(comboBoxComputadora.SelectedItem.ToString(), 7);
                string nombreSoftware = dataGridViewSoftware.CurrentRow.Cells[0].Value.ToString();
                string idSoftware = obtenerIdSoftware(nombreSoftware);

                using (SqlCommand cmd = new SqlCommand(comando, Conexion.conectar()))
                {
                    cmd.Parameters.AddWithValue("@patrimonio", patrimonio);
                    cmd.Parameters.AddWithValue("@idSoftware", idSoftware);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Software desintalado", "Desinstalado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                    
                    //CARGA EL DATAGRIDVIEW
                    dataGridViewSoftware.DataSource = cargarDW(patrimonio);
                    hayDatos();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void hayDatos()
        {
            Boolean existeDatos = false;
            //RECORRE EL DATAGRIDVIEW
            foreach (DataGridViewRow fila in dataGridViewSoftware.Rows)
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
                btnDesinstalar.Enabled = true;
            }
            else
            {
                btnDesinstalar.Enabled = false;
            }
        }


    }
}
