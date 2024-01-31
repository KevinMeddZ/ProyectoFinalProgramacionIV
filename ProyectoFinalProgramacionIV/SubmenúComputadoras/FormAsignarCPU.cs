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
    public partial class FormAsignarCPU : Form
    {
        public FormAsignarCPU()
        {
            InitializeComponent();
        }

        private void CargarCMB_Dep()
        {
            // Realiza la consulta para obtener los datos del código y nombre del departamento
            string consulta = "SELECT codigoDepartamento, nombre FROM tblDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                cmb_Dep.Items.Clear();
                cmb_Dep2.Items.Clear();

                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina el código y el nombre del departamento antes de agregarlos al ComboBox
                    string codigoNombre = $"{reader["codigoDepartamento"].ToString()} - {reader["nombre"].ToString()}";
                    cmb_Dep.Items.Add(codigoNombre);
                    cmb_Dep2.Items.Add(codigoNombre);
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

        private void btnAsignar_Click(object sender, EventArgs e)
        {

            // Extraer cédula de usuario del ComboBox de usuarios
            string seleccionUsuario = cmb_Usuario.SelectedItem?.ToString();
            string cedula = ObtenerPrimerosNCaracteres(seleccionUsuario, 9);

            // Extraer patrimonio de CPU del ComboBox de CPU
            string seleccionCPU = cmb_CPU.SelectedItem?.ToString();
            string patrimonioCPU = ObtenerPrimerosNCaracteres(seleccionCPU, 7);

            // Extraer patrimonio de codigo de Departamento del ComboBox de CPU
            string codigoDepartamento = cmb_Dep.SelectedItem?.ToString();
            codigoDepartamento = ObtenerPrimerosNCaracteres(codigoDepartamento, 6);




            Conexion.conectar();

            // Consulta de actualización
            string consulta = "UPDATE tblComputadora SET cedulaUsuario = @cedulaUsuario,codigoDepartamento = @codigoDepartamento WHERE patrimonioCPU = @patrimonioCPU";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@cedulaUsuario", cedula);
                cmd.Parameters.AddWithValue("@codigoDepartamento", codigoDepartamento);
                cmd.Parameters.AddWithValue("@patrimonioCPU", patrimonioCPU);

                try
                {
                    // Ejecutar la consulta de actualización
                    int filasActualizadas = cmd.ExecuteNonQuery();

                    if (filasActualizadas > 0)
                    {
                        MessageBox.Show("Actualización exitosa", "Actualización completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmb_CPU.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el patrimonioCPU en la tabla tbComputadora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            cmb_Usuario.Text = "";
            cmb_CPU.Text = "";

            string seleccion = cmb_Dep.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(seleccion))
            {
                // Dividir la cadena por el guion y obtener el primer elemento (código)
                string[] partes = seleccion.Split('-');

                if (partes.Length > 0)
                {
                    string codigo = partes[0].Trim();
                    obtenerDatosUser(codigo);
                    obtenerDatosCpus();
                }
            }

            cmb_Dep.SelectedIndex = -1;

        }

        private void FormAsignarCPU_Load(object sender, EventArgs e)
        {
            CargarCMB_Dep();

        }

        private void obtenerDatosUser(string codigo)
        {
            Conexion.conectar();

            // CONSULTA POR TIPO 
            string consulta = "SELECT cedula, nombre FROM tblUsuario WHERE codigoDepartamento = @codigoDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@codigoDepartamento", codigo);

                SqlDataReader reader = cmd.ExecuteReader();

                cmb_Usuario.Items.Clear();
                

                while (reader.Read())
                {
                    // Combina la cédula y el nombre antes de agregarlos al ComboBox
                    string cedulaNombre = $"{reader["cedula"].ToString()} - {reader["nombre"].ToString()}";
                    cmb_Usuario.Items.Add(cedulaNombre);
                    
                }
            }

        }


        private void obtenerDatosUser2(string codigo)
        {
            Conexion.conectar();

            // CONSULTA POR TIPO 
            string consulta = "SELECT cedula, nombre FROM tblUsuario WHERE codigoDepartamento = @codigoDepartamento";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@codigoDepartamento", codigo);

                SqlDataReader reader = cmd.ExecuteReader();

                cmb_Usuario2.Items.Clear();

                while (reader.Read())
                {
                    // Combina la cédula y el nombre antes de agregarlos al ComboBox
                    string cedulaNombre = $"{reader["cedula"].ToString()} - {reader["nombre"].ToString()}";
                  
                    cmb_Usuario2.Items.Add(cedulaNombre);
                }
            }

        }

        //CARGA LAS COMPUTADORAS EN EL COMBOX, CARGA LAS COMPUTADORAS QUE ESTAN EN EL DEPARTAMENTO DE BODEGA
        private void obtenerDatosCpus()
        {
            Conexion.conectar();

            // CONSULTA POR TIPO 
            string consulta = "SELECT patrimonioCPU, marca, modelo FROM tblComputadora WHERE codigoDepartamento = @codigoDepartamento AND cedulaUsuario IS NULL";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@codigoDepartamento", obtenerCodBodega());

                SqlDataReader reader = cmd.ExecuteReader();

                cmb_CPU.Items.Clear();

                while (reader.Read())
                {
                    // Combina el número de patrimonio, la marca y el modelo antes de agregarlos al ComboBox
                    string infoCPU = $"{reader["patrimonioCPU"].ToString()} - {reader["marca"].ToString()} - {reader["modelo"].ToString()}";
                    cmb_CPU.Items.Add(infoCPU);
                }
            }


        }


        private void obtenerDatosCpus2(string codigo)
        {
            Conexion.conectar();

            // CONSULTA POR TIPO 
            string consulta = "SELECT patrimonioCPU, marca, modelo FROM tblComputadora WHERE codigoDepartamento = @codigoDepartamento and cedulaUsuario IS NOT NULL";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@codigoDepartamento", codigo);

                SqlDataReader reader = cmd.ExecuteReader();

                cmb_CPU2.Items.Clear();

                while (reader.Read())
                {
                    // Combina el número de patrimonio, la marca y el modelo antes de agregarlos al ComboBox
                    string infoCPU = $"{reader["patrimonioCPU"].ToString()} - {reader["marca"].ToString()} - {reader["modelo"].ToString()}";
                    cmb_CPU2.Items.Add(infoCPU);
                }
            }
        }
        //OBTIENE EL CODIGO DE BODEGA
        private string obtenerCodBodega()
        {
            string resultado = "";
            try
            {
                string consulta = "SELECT codigoDepartamento FROM tblDepartamento WHERE nombre = 'Bodega'";
                using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
                {
                    resultado = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return resultado;

        }


        private void cmb_Dep_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string seleccion = cmb_Dep.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(seleccion))
            {
                // Dividir la cadena por el guion y obtener el primer elemento (código)
                string[] partes = seleccion.Split('-');

                if (partes.Length > 0)
                {
                    string codigo = partes[0].Trim();
                    obtenerDatosUser(codigo);
                    obtenerDatosCpus();
                    cmb_Usuario.Enabled = true;
                }
            }
            
        }

        private void cmb_Dep_SelectedValueChanged(object sender, EventArgs e)
        {
            cmb_Usuario.Text = "";
            cmb_CPU.Text = "";
        }

        private void btn_Desvincular_Click(object sender, EventArgs e)
        {
            // Extraer cédula de usuario del ComboBox de usuarios
            string seleccionUsuario = cmb_Usuario2.SelectedItem?.ToString();
            string cedula = ObtenerPrimerosNCaracteres(seleccionUsuario, 9);

            // Extraer patrimonio de CPU del ComboBox de CPU
            string seleccionCPU = cmb_CPU2.SelectedItem?.ToString();
            string patrimonioCPU = ObtenerPrimerosNCaracteres(seleccionCPU, 7);

            Conexion.conectar();

            // Consulta de actualización
            string consulta = "UPDATE tblComputadora SET cedulaUsuario = NULL,codigoDepartamento= @codigoBodega WHERE cedulaUsuario = @cedulaUsuario and patrimonioCPU = @patrimonio";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                cmd.Parameters.AddWithValue("@cedulaUsuario", cedula);
                cmd.Parameters.AddWithValue("@patrimonio", patrimonioCPU);
                cmd.Parameters.AddWithValue("@codigoBodega", obtenerCodBodega());
                try
                {
                    // Ejecutar la consulta de actualización
                    int filasActualizadas = cmd.ExecuteNonQuery();

                    if (filasActualizadas > 0)
                    {
                        MessageBox.Show("Actualización exitosa", "Actualización completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obtenerDatosCpus();
                        cmb_CPU2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el patrimonioCPU en la tabla tbComputadora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

           

            string seleccion = cmb_Dep2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(seleccion))
            {
                // Dividir la cadena por el guion y obtener el primer elemento (código)
                string[] partes = seleccion.Split('-');

                if (partes.Length > 0)
                {
                    string codigo = partes[0].Trim();
                    obtenerDatosUser(codigo);
                    obtenerDatosCpus2(codigo);
                }
            }

           
            
        }

        private void cmb_Dep2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = cmb_Dep2.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(seleccion))
            {
                // Dividir la cadena por el guion y obtener el primer elemento (código)
                string[] partes = seleccion.Split('-');

                if (partes.Length > 0)
                {
                    string codigo = partes[0].Trim();
                    obtenerDatosUser2(codigo);
                    
                }
            }
        }

    
        //CARGA EL COMBOBOX DE COMPUTADORAS
        private void cmb_Usuario2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta = "SELECT patrimonioCPU, marca, modelo FROM tblComputadora WHERE cedulaUsuario = @cedula";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                //SE OBTIENE LA CEDULA
                string cedula = ObtenerPrimerosNCaracteres(cmb_Usuario2.SelectedItem.ToString(), 9);
                cmd.Parameters.AddWithValue("@cedula", cedula);
                SqlDataReader dr = cmd.ExecuteReader();

                //LIMPIAR EL COMBOBOX
                cmb_CPU2.Items.Clear();

                //SE AGREGA LOS DATOS
                while (dr.Read())
                {
                    //DA FORMATO E INSERTA EN EL COMBOX
                    string cpu = $"{dr["patrimonioCPU"].ToString()} - {dr["marca"].ToString()} - {dr["modelo"].ToString()}";
                    cmb_CPU2.Items.Add(cpu);
                }

                cmb_CPU2.Enabled = true;
            }
        }

        private void cmb_Usuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_CPU.Enabled = true;
        }
    }
}
