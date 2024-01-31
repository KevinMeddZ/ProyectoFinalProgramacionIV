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
    public partial class FormConsultaSoftware : Form
    {
        public FormConsultaSoftware()
        {
            InitializeComponent();
            string licencia = comboBox1.SelectedIndex.ToString();
            dataGridViewConsultaSoftware.DataSource = obtenerDatos(licencia);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string licencia = comboBox1.SelectedItem.ToString();
            dataGridViewConsultaSoftware.DataSource = obtenerDatos(licencia);
        }

        private void FormConsultaSoftware_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }


        //OBTIENE LOS DATOS POR TIPO DE LICENCIA
        private DataTable obtenerDatos(string licencia)
        {
            Conexion.conectar();
            DataTable dt = new DataTable();

            //CONSULTA POR TIPO DE LICENCIA
            string consulta = "SELECT * FROM tblSoftware WHERE tipoLicencia = @licencia";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@licencia", licencia);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
