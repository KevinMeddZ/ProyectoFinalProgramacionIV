using ProyectoFinalProgramacionIV.Pantallas_programa;
using ProyectoFinalProgramacionIV.SubmenúInstalaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoFinalProgramacionIV
{
    public partial class Login : Form
    {

        


        string tipo = "";
      
        public Login()
        {
            InitializeComponent();
            this.Text = "PCCONTROL - LOGIN";
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("CÉDULA"))
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals(""))
            {
                txtUsuario.Text = "CÉDULA";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals("CONTRASEÑA"))
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals(""))
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtToken_Enter(object sender, EventArgs e)
        {
            if (txtToken.Text.Equals("TOKEN"))
            {
                txtToken.Text = "";
                txtToken.ForeColor = Color.LightGray;
                txtToken.UseSystemPasswordChar = true;
            }
        }

        private void txtToken_Leave(object sender, EventArgs e)
        {
            if (txtToken.Text.Equals(""))
            {
                txtToken.Text = "TOKEN";
                txtToken.ForeColor = Color.DimGray;
                txtToken.UseSystemPasswordChar = false;
            }
        }


        //CUANDO EL FORM CARGA SE CONECTA A LA BASE DE DATOS
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Conexion.conectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        //FUNCION QUE OBTIENE EL ROL DEL USUARIO
        private string obtenerTipo(string cedula)
        {
            string consulta = "SELECT * FROM tblUsuario WHERE cedula = @cedula";
            try
            {
                using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
                {
                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    string tipo = cmd.ExecuteScalar().ToString();
                    
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tipo;
        }


        
        
        //BOTON DE INICIAR SESION
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //OBTENGO LOS DATOS LAS VARIABLES
            string cedula = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            string token = txtToken.Text;

            //LLAMO A LA FUNCION QUE LE DA ACCESO AL USUARIO, SE LE ENVÍA LA CEDULA, CONTRASEÑA Y EL TOKEN
            if (this.validarLogin(cedula, contraseña, token) == true)
            {
                MessageBox.Show("ACCESO PERMITIDO", "Logeado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SE ENVIA LA CEDULA Y EL ROL A LA CLASE DE DATOS COMPARTIDOS
                DatosCompartidos.Cedula = cedula;
                string tipo = obtenerTipo(cedula);
                DatosCompartidos.tipo = tipo;


                this.Hide();
                // ABRE EL FORM DEL MENU PRINCIPAL
                MenuPrincipal mp = new MenuPrincipal();
                mp.Show();
                

            }
            else
            {
                MessageBox.Show("ACCESO DENEGADO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        


        //FUNCION QUE VALIDA EL ACCESO DEL USUARIO
        private Boolean validarLogin(string cedula, string contraseña, string token)
        {
            //STRING DE CONSULTA
            string consulta = "";
            //BOOLEANO QUE LE DA ACCESO AL USUARIO
            bool acceso = false;


            //VERIFICO DATOS EN LA BASE DE DATOS

            //CONSULTA PARA SABER LA CEDULA DEL USUARIO EN LA BASE DE DATOS
            consulta = "SELECT cedula FROM tblUsuario WHERE cedula = @cedula";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@cedula", cedula);

            //VALIDO EL TIPO DE USUARIO



            //VALIDO QUE LA CEDULA ESTE EN LA BASE DE DATOS
            try
            {
                //EN CASO DE QUE SI EXISTA REGISTRO DE LA CEDULA
                if (cmd.ExecuteScalar() != null)
                {
                    //VALIDO QUE TIPO DE USUARIO ES
                    consulta = "SELECT tipo FROM tblUsuario WHERE cedula = @cedula";
                    cmd = new SqlCommand(consulta, Conexion.conectar());
                    cmd.Parameters.AddWithValue("@cedula", cedula);


                    //SI EL EMPLEADO ES DE TI O ADMINISTRADOR
                    if ((cmd.ExecuteScalar().ToString() == "empleadoTI") || (cmd.ExecuteScalar().ToString() == "empleadoAdmin"))
                    {
                        //PARA SABER EL TIPO DE EMPLEADO
                        if (cmd.ExecuteScalar().ToString() == "empleadoTI")
                        {
                            tipo = "Usuario de TI";
                        }
                        if (cmd.ExecuteScalar().ToString() == "empleadoAdmin")
                        {
                            tipo = "Usuario administrador";
                        }
                        

                        //CONSULTA PARA OBTENER LA CONTRASEÑA MEDIANTE LA CEDULA DEL USUARIO
                        consulta = "SELECT clave FROM tblUsuario WHERE cedula = @cedula";
                        cmd = new SqlCommand(consulta, Conexion.conectar());
                        cmd.Parameters.AddWithValue("@cedula", cedula);

                        //VALIDO LA CONTRASEÑA
                        if (contraseña == cmd.ExecuteScalar().ToString())
                        {
                            //VALIDO EL TOKEN
                            consulta = "SELECT token FROM tblUsuario WHERE cedula = @cedula";
                            cmd = new SqlCommand(consulta, Conexion.conectar());
                            cmd.Parameters.AddWithValue("@cedula", cedula);

                            if (cmd.ExecuteScalar().ToString() == token)
                            {
                                //SE DA ACCESO AL USUARIO
                                acceso = true;
                                
                            }
                            else
                            {
                                acceso = false;
                                MessageBox.Show("Token incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {

                            MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //SE NIEGA EL ACCESO AL USUARIO
                            acceso = false;
                        }
                    }else
                    {
                        //CONSULTA PARA OBTENER LA CONTRASEÑA MEDIANTE LA CEDULA DEL USUARIO
                        consulta = "SELECT clave FROM tblUsuario WHERE cedula = @cedula";
                        cmd = new SqlCommand(consulta, Conexion.conectar());
                        cmd.Parameters.AddWithValue("@cedula", cedula);

                        //VALIDO LA CONTRASEÑA
                        if (contraseña == cmd.ExecuteScalar().ToString())
                        {
                            tipo = "Usuario de la empresa";
                            acceso = true;
                        }else
                        {
                            MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //SE NIEGA EL ACCESO AL USUARIO
                            acceso = false;
                        }
                    }

                    //SI NO EXISTE REGISTRO DE LA CEDULA
                }
                else
                {
                    MessageBox.Show("Usuario no registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return acceso;
        }

        

       

        

    }
}

