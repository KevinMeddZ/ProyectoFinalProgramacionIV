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
    public partial class FormCrearCuenta : Form
    {
        public FormCrearCuenta()
        {
            InitializeComponent();
            
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtCedula.Text.Equals("CÉDULA"))
            {
                txtCedula.Text = "";
                txtCedula.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtCedula.Text.Equals(""))
            {
                txtCedula.Text = "CÉDULA";
                txtCedula.ForeColor = Color.DimGray;
            }
        }

        private void txtContraNueva_Enter(object sender, EventArgs e)
        {
            if (txtContraNueva.Text.Equals("CREAR CONTRASEÑA"))
            {
                txtContraNueva.Text = "";
                txtContraNueva.ForeColor = Color.LightGray;
                txtContraNueva.UseSystemPasswordChar = true;
            }
        }

        private void txtContraNueva_Leave(object sender, EventArgs e)
        {
            if (txtContraNueva.Text.Equals(""))
            {
                txtContraNueva.Text = "CREAR CONTRASEÑA";
                txtContraNueva.ForeColor = Color.DimGray;
                txtContraNueva.UseSystemPasswordChar = false;
            }
        }

        private void txtContraNueva1_Enter(object sender, EventArgs e)
        {
            if (txtContraNueva1.Text.Equals("REPETIR CONTRASEÑA"))
            {
                txtContraNueva1.Text = "";
                txtContraNueva1.ForeColor = Color.LightGray;
                txtContraNueva1.UseSystemPasswordChar = true;
            }
        }

        private void txtContraNueva1_Leave(object sender, EventArgs e)
        {
            if (txtContraNueva1.Text.Equals(""))
            {
                txtContraNueva1.Text = "REPETIR CONTRASEÑA";
                txtContraNueva1.ForeColor = Color.DimGray;
                txtContraNueva1.UseSystemPasswordChar = false;
            }
        }



        //ABRE LA VENTANA DE INICIAR SESIÓN
        private void labelIniciarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();

        }


        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string tipo = "empleado";
            string cedula = "";
            string contraseña = "";
            string nombre = string.Empty;
            string primerApellido = string.Empty;
            string segundoApellido = string.Empty;
            string codDepartamento = "";

            
            

            // OBTENGO LOS DEMÁS DATOS
            nombre = txtNombre.Text;
            primerApellido = txtPrimerApellido.Text;
            segundoApellido = txtSegundoApellido.Text;
            cedula = txtCedula.Text;
            codDepartamento = ObtenerPrimerosNCaracteres(cmbID_Departamento.Text.ToString(), 6);

            if (cedula.Equals("CÉDULA"))
            {
               MessageBox.Show("Cedula incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else
            {
                if (verificarCedula(cedula) == true)
                {
                    MessageBox.Show("Ya existe un usuario con la misma cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //VERIFICO LA CEDULA
            

            // VALIDACIONES DE DATOS DE ENTRADA
            if (!EsNumeroDe9Digitos(cedula))
            {
                MessageBox.Show("Ingrese una cédula válida de 9 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!SoloLetras(nombre) || !SoloLetras(primerApellido) || !SoloLetras(segundoApellido))
            {
                MessageBox.Show("Ingrese nombres y apellidos válidos (solo letras).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // OBTENGO LA CONTRASEÑA
            contraseña = txtContraNueva.Text;

            // VERIFICO QUE LAS CONTRASEÑAS SEAN IGUALES
            if (txtContraNueva1.Text != contraseña)
            {
                MessageBox.Show("Las contraseñas no son iguales, por favor verifique los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //VERIFICO QUE SE ESCOGA UN DEPARTAMENTO
            if (cmbID_Departamento.SelectedItem is null)
            {
                MessageBox.Show("No ha seleccionado un departamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // INSERTO LOS DATOS A LA BASE DE DATOS
            try
            {
                string crearUsuario = "spCrearUsuario";

                //SE OBTIENE EL NOMBRE DEL DEPARTAMENTO
                string nombreDep = obtenerUltimosCaracteres(cmbID_Departamento.Text.ToString());

                // OBTENGO EL TIPO DE EMPLEADO
                if (radioEmpleadoAdmin.Checked) { tipo = "empleadoAdmin"; }

                //SI NO ESTA SELECCIONADO EL CHECK DE ADMIN Y ESTA SELECCIONADO EL DEPARTAMENTO DE SISTEMAS
                if ((!radioEmpleadoAdmin.Checked) && (nombreDep.Equals("Sistemas"))) { 
                    tipo = "empleadoTI"; 
                }

                    using (SqlCommand cmd = new SqlCommand(crearUsuario, Conexion.conectar()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@primerApellido", primerApellido);
                    cmd.Parameters.AddWithValue("@segundoApellido", segundoApellido);
                    cmd.Parameters.AddWithValue("@clave", contraseña);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@codigoDepartamento", codDepartamento);

                    
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario creado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //SETEA LOS CAMPOS 
                setearCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals("NOMBRE"))
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LightGray;

            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(""))
            {
                txtNombre.Text = "NOMBRE";
                txtNombre.ForeColor = Color.DimGray;

            }
        }

        private void txtPrimerApellido_Enter(object sender, EventArgs e)
        {
            if (txtPrimerApellido.Text.Equals("PRIMER APELLIDO"))
            {
                txtPrimerApellido.Text = "";
                txtPrimerApellido.ForeColor = Color.LightGray;

            }
        }

        private void txtPrimerApellido_Leave(object sender, EventArgs e)
        {
            if (txtPrimerApellido.Text.Equals(""))
            {
                txtPrimerApellido.Text = "PRIMER APELLIDO";
                txtPrimerApellido.ForeColor = Color.DimGray;

            }
        }

        private void txtSegundoApellido_Enter(object sender, EventArgs e)
        {
            if (txtSegundoApellido.Text.Equals("SEGUNDO APELLIDO"))
            {
                txtSegundoApellido.Text = "";
                txtSegundoApellido.ForeColor = Color.LightGray;

            }
        }

        private void txtSegundoApellido_Leave(object sender, EventArgs e)
        {
            if (txtSegundoApellido.Text.Equals(""))
            {
                txtSegundoApellido.Text = "SEGUNDO APELLIDO";
                txtSegundoApellido.ForeColor = Color.DimGray;

            }
        }

        private void LlenarCMB()
        {
            string query = "SELECT codigoDepartamento, nombre FROM tblDepartamento";



            // Crear un comando SQL y asignar la conexión y la consulta
            using (SqlCommand command = new SqlCommand(query, Conexion.conectar()))

            {
                // Crear un lector de datos
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Limpiar los elementos existentes en el ComboBox
                    cmbID_Departamento.Items.Clear();

                    // Leer los datos y agregarlos al ComboBox
                    while (reader.Read())
                    {
                        // Combina el código y el nombre del departamento antes de agregarlos al ComboBox
                        string codigoNombre = $"{reader["codigoDepartamento"].ToString()}-{reader["nombre"].ToString()}";
                        // Agregar el valor de la columna al ComboBox
                        cmbID_Departamento.Items.Add( codigoNombre );
                    }
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

        // Función para verificar si una cadena es un número de 9 dígitos
        private bool EsNumeroDe9Digitos(string input)
        {
            return input.Length == 9 && input.All(char.IsDigit);
        }

        // Función para verificar si una cadena contiene solo letras
        private bool SoloLetras(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
        }


        private void FormCrearCuenta_Load(object sender, EventArgs e)
        {
            LlenarCMB();
            cmbID_Departamento.DropDownStyle = ComboBoxStyle.DropDownList;
            radioEmpleadoAdmin.Enabled = false;
            radioEmpleadoAdmin.Checked = false;
        }

        private void setearCampos ()
        {
            txtCedula.Text = "CÉDULA";
            txtCedula.ForeColor = Color.DimGray;


            txtNombre.Text = "NOMBRE";
            txtNombre.ForeColor = Color.DimGray;

            txtPrimerApellido.Text = "PRIMER APELLIDO";
            txtPrimerApellido.ForeColor = Color.DimGray;

            txtSegundoApellido.Text = "SEGUNDO APELLIDO";
            txtSegundoApellido.ForeColor = Color.DimGray;

            txtContraNueva.Text = "CREAR CONTRASEÑA";
            txtContraNueva.ForeColor = Color.DimGray;
            txtContraNueva.UseSystemPasswordChar = false;


            txtContraNueva1.Text = "REPETIR CONTRASEÑA";
            txtContraNueva1.ForeColor = Color.DimGray;
            txtContraNueva1.UseSystemPasswordChar = false;

            
        }


        private string obtenerUltimosCaracteres(string texto)
        {
            string texto2 = "";

            // Encuentra la posición del guion
            int indiceGuion = texto.IndexOf('-');

            // Verifica si se encontró el guion y obtiene los caracteres después de él
            if (indiceGuion != -1 && indiceGuion < texto.Length - 1)
            {
                texto2 = texto.Substring(indiceGuion + 1);
                
            }

            //RETORNA EL TEXTO DESPUES DEL GUIN
            return texto2;
        }

        private void cmbID_Departamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OBTIENE EL NOMBRE DEL DEPARTAMENTO
            string nombre = obtenerUltimosCaracteres(cmbID_Departamento.Text.ToString());

            if (nombre.Equals("Sistemas"))
            {
                radioEmpleadoAdmin.Enabled = true;
            }else
            {

                radioEmpleadoAdmin.Checked = false;
                radioEmpleadoAdmin.Enabled=false;
            }
            
        }


        private Boolean verificarCedula(string cedula)
        {
            string consulta = "SELECT * FROM tblUsuario WHERE cedula = @cedula";
            bool bandera = false;

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@cedula", cedula);
           

                //SI LA CEDULA ES NO ES IGUAL RETORNA NULL
                if (cmd.ExecuteScalar() is null)
                {
                    bandera = false;
                }else
                {
                    bandera = true;
                }
            }

            return bandera;
        }
    }
}
