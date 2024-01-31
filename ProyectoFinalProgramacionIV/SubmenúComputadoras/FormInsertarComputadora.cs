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

namespace ProyectoFinalProgramacionIV.SubmenúComputadoras
{
    public partial class FormInsertarComputadora : Form
    {
        public FormInsertarComputadora()
        {
            InitializeComponent();
        }

        private void FormInsertarComputadora_Load(object sender, EventArgs e)
        {
            // Obtener el consecutivo de la tabla de computadoras
            int consecutivo = ObtenerConsecutivoComputadoras();
            // Construir el patrimonio con el formato "M" seguido por el consecutivo
            string patrimonio = "PCC" + consecutivo.ToString("D3");
            txtPatrimonio.Text = patrimonio;
        }


        //METODO QUE CARGA LOS DATOS DE LOS DEPARTAMENTOS EN UN COMBOBOX
        private string ObtenerIniciales(string texto)
        {
            // Obtener las cuatro iniciales del texto
            if (texto.Length >= 4)
            {
                return texto.Substring(0, 4);
            }
            else
            {
                return texto;
            }
        }

        //GENERA UN NUMEROS ALEATORIO
        private int GenerarNumeroAleatorio()
        {
            // Generar un número aleatorio de tres dígitos
            Random random = new Random();
            return random.Next(1, 1000);
        }


        //OBTIENE EL CODIGO DEL DEPARTAMENTO DE BODEGA
        private string obtenerCodBodega()
        {
            string resultado = "";
            try
            {
                string consulta = "SELECT codigoDepartamento FROM tblDepartamento WHERE nombre = 'Bodega'";
                using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
                {
                    if (cmd.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Por favor, crear el departamento con el nombre 'Bodega'", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        resultado = "";
                    }else
                    {
                        resultado = cmd.ExecuteScalar().ToString();
                    }
                    
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return resultado;

        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //OBTENEMOS LOS DATOS
            string patrimonio = txtPatrimonio.Text;
            string numeroSerie = txtNumSerie.Text;
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;

            //SE OBTIENE EL CODIGO DE BODEGA
            string codBodega = obtenerCodBodega();

            if (codBodega.Equals(""))
            {
                MessageBox.Show("No se registró la computadora", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }else
            {
                if (patrimonio.Equals("") || numeroSerie.Equals("") || marca.Equals("") || modelo.Equals(""))
                {
                    MessageBox.Show("Algunos campos se encuentran en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //SE INSERTA LOS DATOS
                    try
                    {
                        string spInsertarComputadora = "spAsignarComputadora";
                        SqlCommand cmd = new SqlCommand(spInsertarComputadora, Conexion.conectar());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigoDepartamento", codBodega);
                        cmd.Parameters.AddWithValue("@patrimonioCPU", patrimonio);
                        cmd.Parameters.AddWithValue("@numeroSerie", numeroSerie);
                        cmd.Parameters.AddWithValue("@marca", marca);
                        cmd.Parameters.AddWithValue("@modelo", modelo);

                        //SE EJECUTA EL COMANDO
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Computadora registrada", "Registro completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //SE REINICIA LOS DATOS
                        /*  cmbDepartamento.SelectedIndex = 0;*/
                        txtPatrimonio.Text = "";
                        txtNumSerie.Text = "";
                        txtMarca.Text = "";
                        txtModelo.Text = "";


                        // Obtener el consecutivo de la tabla de computadoras
                        int consecutivo = ObtenerConsecutivoComputadoras();

                        // Construir el patrimonio con el formato "M" seguido por el consecutivo
                        patrimonio = "PCC" + consecutivo.ToString("D3");



                        txtPatrimonio.Text = patrimonio;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            

            
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto ingresado en el TextBox
            string textoIngresado = txtMarca.Text;

            // Verificar si el TextBox no está vacío
            if (!string.IsNullOrEmpty(textoIngresado))
            {
                string iniciales = ObtenerIniciales(textoIngresado);
                string codigoAleatorio = GenerarNumeroAleatorio().ToString("D3");

                // Combinar las iniciales con el número aleatorio
                string codigoGenerado = iniciales + codigoAleatorio;

                // Mostrar el código en el TextBox
                txtNumSerie.Text = codigoGenerado;
            }
            else
            {
                // Si el TextBox está vacío, se podría limpiar el TextBox de código generado
                txtNumSerie.Text = string.Empty;
            }
        }

        

        private int ObtenerConsecutivoComputadoras()
        {
            int consecutivo = 0;

            try
            {
                // Obtener el consecutivo de la tabla de computadoras
                string consultaConsecutivo = "SELECT TOP 1 patrimonioCPU FROM tblComputadora ORDER BY patrimonioCPU DESC";
                SqlCommand cmd = new SqlCommand(consultaConsecutivo, Conexion.conectar());

                // Obtener el máximo consecutivo
                object result = cmd.ExecuteScalar();
                string patrimonioMax = Convert.ToString(result);
                if (!string.IsNullOrEmpty(patrimonioMax) && patrimonioMax.Length >= 3)
                {
                    string consecutivoStr = patrimonioMax.Substring(3); // Obtener los últimos caracteres después de "PPC"
                    consecutivo = Convert.ToInt32(consecutivoStr) + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return consecutivo;
        }



    }
}

