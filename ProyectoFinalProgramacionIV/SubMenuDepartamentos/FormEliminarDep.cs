using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinalProgramacionIV
{
    public partial class FormEliminarDep : Form
    {
        public FormEliminarDep()
        {
            InitializeComponent();
        }

        private void CargarCMB()
        {
            string consulta = "SELECT codigoDepartamento, nombre\r\nFROM tblDepartamento\r\nWHERE codigoDepartamento NOT IN (\r\n    SELECT DISTINCT codigoDepartamento\r\n    FROM tblUsuario\r\n    UNION\r\n    SELECT DISTINCT codigoDepartamento\r\n    FROM tblComputadora);";
            try
            {
                using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
                {
           
                   
                    
                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    // Agregar los datos al ComboBox
                  
                      

                    

                    cmb_Departamentos.DataSource = tabla;
                    cmb_Departamentos.DisplayMember = "nombre";
                    cmb_Departamentos.ValueMember = "codigoDepartamento";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnEliminarDep_Click(object sender, EventArgs e)
        {
            try
            {

                //SI EXISTE DATOS EN EL COMBOBOX
                if (cmb_Departamentos.SelectedItem != null)
                {
                    //OBTIENE EL ID DEL SOFTWARE
                    string idDep = cmb_Departamentos.SelectedValue.ToString();
                    //
                    string consulta = "DELETE FROM tblDepartamento WHERE codigoDepartamento = @codigoDepartamento";

                    SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                    cmd.Parameters.AddWithValue("codigoDepartamento", idDep);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Departamento eliminado", "Datos eliminaods", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCMB();
                }else
                {
                    MessageBox.Show("No hay departamento seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormEliminarDep_Load(object sender, EventArgs e)
        {
            CargarCMB();
            cmb_Departamentos.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
