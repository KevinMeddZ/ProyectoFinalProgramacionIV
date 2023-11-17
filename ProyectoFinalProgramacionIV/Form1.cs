using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProyectoFinalProgramacionIV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("CÉDULA")) {
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
                txtContraseña.ForeColor= Color.DimGray;
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
                txtToken    .ForeColor = Color.DimGray;
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


        //ABRE EL OTRO FORMULARIO PARA CREAR LA CUENTA
        private void labelCrearCuenta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            FormCrearCuenta crearCuenta = new FormCrearCuenta();
            crearCuenta.ShowDialog(this);
            Show();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string cedula = "";
            string contraseña = "";


        }
    }
}
