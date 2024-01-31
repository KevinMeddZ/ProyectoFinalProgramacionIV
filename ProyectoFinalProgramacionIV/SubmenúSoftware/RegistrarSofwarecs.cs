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

namespace ProyectoFinalProgramacionIV
{
    public partial class RegistrarSofwarecs : Form
    {
        public RegistrarSofwarecs()
        {
            InitializeComponent();

        }

        private void LimpiarTXT()
        {

            txtNombreSofware.Text = "";
            txtVersion.Text = "";

            txtFuncionalidad.Text = "";
        }


        private void txtNombreSofware_Enter(object sender, EventArgs e)
        {
            if (txtNombreSofware.Text.Equals("Nombre del software"))
            {
                txtNombreSofware.Text = "";
                txtNombreSofware.ForeColor = Color.LightGray;
            }
        }

        private void btnRegistrarSoftware_Click(object sender, EventArgs e)
        {


            //SE OBTIENE LOS DATOS
            string NombreSofware = txtNombreSofware.Text;
            string VersionSofware = txtVersion.Text;
            string TipoLicencia = comboBoxLicencia.SelectedItem.ToString();
            string Funcionalidad = txtFuncionalidad.Text;
            string cantidad = txtCantidad.Text;
            string vencimiento = comboBoxVencimiento.SelectedItem.ToString();


            // Validar las entradas
            if ((NombreSofware.Equals("Nombre del software")) || (VersionSofware.Equals("Version")) || (Funcionalidad.Equals("Funcionalidad del software")))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de registrar el software.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreSofware.Text = "Nombre del software";
                txtVersion.Text = "Version";
                txtFuncionalidad.Text = "Funcionalidad del software";
                txtCantidad.Text = "Cantidad";

            } else
            {
                // Validar que la versión sea un número con puntos
                if (!EsNumeroConPuntos(VersionSofware))
                {
                    MessageBox.Show("Por favor, ingrese una versión válida. Solo se aceptan números y puntos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // Validar que el tipo de licencia y la funcionalidad contengan solo letras
                else if (!ContieneSoloLetras(TipoLicencia) || !ContieneSoloLetras(Funcionalidad))
                {
                    MessageBox.Show("El tipo de licencia y la funcionalidad solo deben contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {

                    //INGRESA LOS DATOS A LA BASE DE DATOS
                    try
                    {
                        //VALIDA LA CANTIDAD
                        if (cantidad.Equals("Cantidad"))
                        {
                            cantidad = "";

                        }

                        string registrarSoftware = "spAsignarSoftware";
                        SqlCommand cmd = new SqlCommand(registrarSoftware, Conexion.conectar());
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombreSoftware", NombreSofware);
                        cmd.Parameters.AddWithValue("@version", VersionSofware);
                        cmd.Parameters.AddWithValue("@tipoLicencia", TipoLicencia);
                        cmd.Parameters.AddWithValue("@funcionalidad", Funcionalidad);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@vencimiento", vencimiento);
                        cmd.ExecuteNonQuery();

                        
                        
                        MessageBox.Show("Sofware agregado a nuestro stock de IT", "Software agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombreSofware.Text = "Nombre del software";
                        txtVersion.Text = "Version";
                        comboBoxLicencia.SelectedIndex = 0;
                        txtFuncionalidad.Text = "Funcionalidad del software";
                        txtCantidad.Text = "Cantidad";
                        comboBoxVencimiento.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private bool EsNumeroConPuntos(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^[0-9.]+$");
        }

        private bool ContieneSoloLetras(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^[a-zA-Z\s]+$");
        }
        private void txtNombreSofware_Leave(object sender, EventArgs e)
        {
            if (txtNombreSofware.Text.Equals(""))
            {
                txtNombreSofware.Text = "Nombre del software";
                txtNombreSofware.ForeColor = Color.White;
            }
        }

        private void txtVersion_Enter(object sender, EventArgs e)
        {
            if (txtVersion.Text.Equals("Version"))
            {
                txtVersion.Text = "";
                txtVersion.ForeColor = Color.White;
            }

        }

        private void txtVersion_Leave(object sender, EventArgs e)
        {
            if (txtVersion.Text.Equals(""))
            {
                txtVersion.Text = "Version";
                txtVersion.ForeColor = Color.White;
            }
        }

        private void txtFuncionalidad_Enter(object sender, EventArgs e)
        {
            if (txtFuncionalidad.Text.Equals("Funcionalidad del software"))
            {
                txtFuncionalidad.Text = "";
                txtFuncionalidad.ForeColor = Color.White;
            }
        }

        private void txtFuncionalidad_Leave(object sender, EventArgs e)
        {
            if (txtFuncionalidad.Text.Equals(""))
            {
                txtFuncionalidad.Text = "Funcionalidad del software";
                txtFuncionalidad.ForeColor = Color.White;
            }
        }

        private void RegistrarSofwarecs_Load(object sender, EventArgs e)
        {
            comboBoxLicencia.SelectedIndex = 0;
            cargarCombox();
            comboBoxVencimiento.SelectedIndex = 0;
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Equals("Cantidad"))
            {
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.White;
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Equals(""))
            {
                txtCantidad.Text = "Cantidad";
                txtCantidad.ForeColor = Color.White;
            }
        }

        //DEPENDIENDO DEL TIPO DE LICENCIA SE ACTIVA EL TEXTBOX DE CANTIDAD
        private void comboBoxLicencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBoxLicencia.SelectedItem.Equals("Shareware")) || (comboBoxLicencia.SelectedItem.Equals("Freeware")) || (comboBoxLicencia.SelectedItem.Equals("Trial Licence")))
            {
                comboBoxVencimiento.Items.Clear();
                comboBoxVencimiento.Items.Add("Sin vencimiento");
                comboBoxVencimiento.SelectedIndex = 0;
                comboBoxVencimiento.Enabled = false;
                txtCantidad.Enabled = false;
            }else
            {
                comboBoxVencimiento.Enabled=true;
                txtCantidad.Enabled = true;
                cargarCombox();
                comboBoxVencimiento.SelectedIndex=0;
            }
        }

        //LLENA EL COMBOX
        private void cargarCombox()
        {
            comboBoxVencimiento.Items.Clear();

            string[] vencimientos = { "3 meses", "6 meses", "9 meses", "12 meses", "24 meses", "36 meses" };

            foreach (string str in vencimientos)
            {
                comboBoxVencimiento.Items.Add(str);
            }





        }

        
    }
}
