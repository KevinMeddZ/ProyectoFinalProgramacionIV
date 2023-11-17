﻿using System;
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
            string tipo = "";
            string cedula = "";
            string contraseña = "";
            string nombre = string.Empty;
            string primerApellido = string.Empty;
            string segundoApellido = string.Empty;
            int idEmpleado = 0;


            //OBTENGO EL TIPO DE EMPLEADO
            if (radioEmpleado.Checked) { tipo = "empleadoEmpresa"; }

            if (radioEmpleadoTI.Checked) { tipo = "empleadoTI"; }

            if (radioAdministrador.Checked) { tipo = "administrador"; }

            //OBTENGO LOS DEMAS DATOS
            nombre = txtNombre.Text;
            primerApellido = txtPrimerApellido.Text;
            segundoApellido = txtSegundoApellido.Text;
            cedula = txtCedula.Text;
            idEmpleado = int.Parse(txtIdEmpleadoEmpresa.Text);

            //Obtengo la contraseña
            contraseña = txtContraNueva.Text;

            //Verifico que las contraseñas sean iguales

            if (txtContraNueva1.Text != contraseña)
            {
                MessageBox.Show("Las contraseñas no son iguales, por favor verifique los campos");
            }else
            {
                //INSERTO LOS DATOS A LA BASE DE DATOS
                try
                {
                    string crearUsuario = "spCrearUsuario";
                    SqlCommand cmd = new SqlCommand(crearUsuario, Conexion.conectar());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@cedula", cedula);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@primerApellido", primerApellido);
                    cmd.Parameters.AddWithValue("@segundoApellido", segundoApellido);
                    cmd.Parameters.AddWithValue("@clave", contraseña);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario creado con éxito, por favor inicie sesión");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void txtIdEmpleadoEmpresa_Enter(object sender, EventArgs e)
        {
            if (txtIdEmpleadoEmpresa.Text.Equals("ID EMPLEADO EMPRESA"))
            {
                txtIdEmpleadoEmpresa.Text = "";
                txtIdEmpleadoEmpresa.ForeColor = Color.LightGray;

            }
        }

        private void txtIdEmpleadoEmpresa_Leave(object sender, EventArgs e)
        {
            if (txtIdEmpleadoEmpresa.Text.Equals(""))
            {
                txtIdEmpleadoEmpresa.Text = "ID EMPLEADO EMPRESA";
                txtIdEmpleadoEmpresa.ForeColor = Color.DimGray;

            }
        }
    }
}
