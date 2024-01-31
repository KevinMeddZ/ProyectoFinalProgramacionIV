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
    public partial class FormConsultarInstalaciones : Form
    {
        public FormConsultarInstalaciones()
        {
            InitializeComponent();
        }

        private void FormConsultarInstalaciones_Load(object sender, EventArgs e)
        {
            cargarComboBoxComputadora();
            
        }


        //FUNCION QUE CARGA LAS COMPUTADORAS EN EL COMBOX DE COMPUTADORAS
        private void cargarComboBoxComputadora()
        {
            string consulta = "SELECT patrimonioCPU, marca, modelo FROM tblComputadora";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar())) { 
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

       

        //SEPARA LOS CARACTERES DEL COMBOBOX
        private string ObtenerPrimerosNCaracteres(string cadena, int n)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length >= n)
            {
                return cadena.Substring(0, n);
            }

            return string.Empty;
        }


        //CARGA LOS DATOS AL DATAGRIDVIEW 
        private DataTable cargarDatos(string patrimonio)
        {

            string consulta = "select nombre, tipoLicencia, versionSoftware, funcionalidad, tblInstalacion.cedulaUsuario as cedulaInstalo, fechaInstalacion,fechaVencimiento from tblInstalacion INNER JOIN tblSoftware ON tblInstalacion.idSoftware = tblSoftware.idSoftware INNER JOIN tblComputadora ON tblInstalacion.patrimonioCPU = tblComputadora.patrimonioCPU WHERE tblComputadora.patrimonioCPU = @patrimonio";
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@patrimonio", patrimonio);
           

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
            

        }
        

       

        private void comboBoxComputadora_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SE OBTIENE LOS DATOS A CONSULTAR
            string patrimonio = ObtenerPrimerosNCaracteres(comboBoxComputadora.SelectedItem.ToString(), 7);

            //CARGA LOS DATOS EN EL DATAGRIDVIEW
            dataGridViewInstalaciones.DataSource = cargarDatos(patrimonio);
        }
    }
}
