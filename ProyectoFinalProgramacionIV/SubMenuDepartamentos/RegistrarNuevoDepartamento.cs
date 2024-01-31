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
    public partial class RegistrarNuevoDepartamento : Form
    {
        public RegistrarNuevoDepartamento()
        {
            InitializeComponent();
            this.Text = "Registrar departamento al sistema";
        }

        //CUANDO PRESIONA EL BOTON DE REGISTRAR
        private void btnRegistrarDep_Click(object sender, EventArgs e)
        {
            //SE OBTIENE EL NOMBRE DEL DEPARTAMENTO
            string NombreDepartamento = txtNombreDepartamento.Text;
            //SI NO HAY DATOS EN EL TEXTBOX SE MUESTRA UN ERROR
            if ( string.IsNullOrEmpty(NombreDepartamento))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de registrar el departamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (NombreDepartamento.Equals("Nombre del departamento"))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de registrar el departamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                // Generar el código del departamento
                string CodigoDepartamento = GenerarCodigoDepartamento(NombreDepartamento);
                txtCodigoDepartamento.Text = CodigoDepartamento;

                try
                {
                    //MEDIANTE EL PROCEDIMIENTO ALMACENADO SE INGRESA LOS DATOS A LA BASE DE DATOS
                    string registrarDepartamento = "spInsertarDepartamento";
                    SqlCommand cmd = new SqlCommand(registrarDepartamento, Conexion.conectar());
                    cmd.CommandType = CommandType.StoredProcedure;
                    //SE LE ENVÍA LOS PARÁMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("@codDepartamento", CodigoDepartamento);
                    cmd.Parameters.AddWithValue("@nombre", NombreDepartamento);
                    //SE EJECUTA EL COMANDO
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro de departamento exitoso. Código generado: " + CodigoDepartamento, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtNombreDepartamento.Text = "Nombre del departamento";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        //GENERA EL CODIGO DEL DEPARTAMENTO UTILIZANDO LAS PRIMERAS 3 LETRAS DEL NOMBRE DEL DEPARTAMENTO Y 3 NUMEROS RANDOM
        private string GenerarCodigoDepartamento(string nombreDepartamento)
        {
            // Tomar las tres primeras letras del nombre del departamento
            string iniciales = nombreDepartamento.Substring(0, Math.Min(nombreDepartamento.Length, 3)).ToUpper();

            // Generar un número aleatorio de tres dígitos
            Random rand = new Random();
            int numeroAleatorio = rand.Next(100, 1000);

            // Combinar las iniciales y el número aleatorio para formar el código del departamento
            string codigoDepartamento = iniciales + numeroAleatorio.ToString();

            return codigoDepartamento;
        }

        
       
        //CUANDO EL TXTBOX GANA EL FOCO SE SETEA EN BLANCO
        private void txtNombreDepartamento_Enter(object sender, EventArgs e)
        {
            if (txtNombreDepartamento.Text.Equals("Nombre del departamento"))
            {
                txtNombreDepartamento.Text = "";
                txtNombreDepartamento.ForeColor = Color.LightGray;
            }
        }

        private void txtNombreDepartamento_Leave(object sender, EventArgs e)
        {
            if(txtNombreDepartamento.Text.Equals(""))
            {
                txtNombreDepartamento.Text = "Nombre del departamento";
                txtNombreDepartamento.ForeColor = Color.White;
            }
        }

        //VALIDA QUE LO QUE SE ESCRIBA SEA SOLAMENTE LETRAS
        private void txtNombreDepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //VERIFICA QUE LO QUE SE INGRESA NO ES UNA LETRA
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                //BLOQUEA LA ENTRADA SI NO ES UNA ENTRADA
                e.Handled = true;
            }
        }
    }
}
