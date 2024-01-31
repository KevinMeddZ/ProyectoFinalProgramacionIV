using ProyectoFinalProgramacionIV.Pantallas_programa;
using System;
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

namespace ProyectoFinalProgramacionIV.SubmenúInstalaciones
{
    public partial class FormInstalarSoftware : Form
    {
        string cedula;
        
        public FormInstalarSoftware()
        {
            InitializeComponent();

            //OBTENGO LA CEDULA DEL USUARIO DE TI
            cedula = DatosCompartidos.Cedula;
            
            
        }

        //CUANDO CARGA LA PANTALLA
        private void FormInstalarSoftware_Load(object sender, EventArgs e)
        {
            //CARGA LAS COMPUTADORAS DISPONIBLES
            CargarCMB_Compu();
            //CARGAR LOS SOFTWARE DISPONIBLES
            CargarCMB_Software();

            try
            {
                comBoxComputadora.SelectedIndex = 0;
                comBoxSoftware.SelectedIndex = 0;
            }catch (Exception ex)
            {

            }
            
        }

        //CARGA EL COMBOX CON LAS COMPUTADORAS
        private void CargarCMB_Compu()
        {
            // Realiza la consulta para obtener los datos específicos de las computadoras
            string consulta = "SELECT patrimonioCPU, marca, modelo FROM tblComputadora";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                comBoxComputadora.Items.Clear();

                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina los datos antes de agregarlos al ComboBox
                    string patrimonio = reader["patrimonioCPU"].ToString();
                    string marca = reader["marca"].ToString();
                    string modelo = reader["modelo"].ToString();

                    string datosComputadora = $"{patrimonio} - {marca} - {modelo}";

                    comBoxComputadora.Items.Add(datosComputadora);
                }
            }
        }

        //CARGA EL COMBOBOX DE SOFTWARE CON LOS SOFTWARES DISPONIBLES
        private void CargarCMB_Software()
        {
            // Realiza la consulta para obtener los datos del código y nombre del departamento
            string consulta = "SELECT nombre FROM tblSoftware";

            using (SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                // Limpiar los elementos existentes en el ComboBox
                comBoxSoftware.Items.Clear();


                // Agregar los datos al ComboBox
                while (reader.Read())
                {
                    // Combina el código y el nombre del del software antes de agregarlos al ComboBox
                    string codigoNombre = reader["nombre"].ToString();

                    comBoxSoftware.Items.Add(codigoNombre);

                }
            }
        }

        private void actualizarDatos()
        {
            string consulta = "";
            //SE OBTIENE EL NOMBRE DEL SOFTWARE
            string nombre = comBoxSoftware.SelectedItem.ToString();

            //SE HACE LA CONSULTA PARA SABER EL TIPO DE LICENCIA DEL SOFTWARE
            consulta = "SELECT tipoLicencia FROM tblSoftware WHERE nombre = @nombre";

            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@nombre", nombre);

            string tipo = cmd.ExecuteScalar().ToString();

            if ((tipo.Equals("Shareware") || (tipo.Equals("Freeware")) || (tipo.Equals("Trial Licence"))))
            {
                txtLicenciasDisp.Text = "Ilimitidas";
            }
            else
            {
                //SE HACE LA CONSULTA PARA SABER LA CANTIDAD DE LICENCIAS DISPONIBLES DEL SOFTWARE
                consulta = "SELECT cantidad FROM tblSoftware WHERE nombre = @nombre";
                SqlCommand cmd2 = new SqlCommand(consulta, Conexion.conectar());
                cmd2.Parameters.AddWithValue("@nombre", nombre);

                //SE ACTUALIZA EL CAMPO DE LAS LICENCIAS CON LAS LICENCIAS DISPONIBLES DEL SOFTWARE SELECCIONADO
                string cantidadDisp = cmd2.ExecuteScalar().ToString();
                txtLicenciasDisp.Text = cantidadDisp;
            }
        }


        //SEPARA LOS CARACTERES DEL COMBOBOX
        private string ObtenerPrimerosNCaracteres(string cadena, int n)
        {
            if (!string.IsNullOrEmpty(cadena) && cadena.Length >= n)
            {
                return cadena.Substring(0, n);
            }

            return string.Empty;
        }

        private void comBoxSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta = "";
            //SE OBTIENE EL NOMBRE DEL SOFTWARE
            string nombre = comBoxSoftware.SelectedItem.ToString();

            //SE HACE LA CONSULTA PARA SABER EL TIPO DE LICENCIA DEL SOFTWARE
            consulta = "SELECT tipoLicencia FROM tblSoftware WHERE nombre = @nombre";

            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@nombre", nombre);

            string tipo = cmd.ExecuteScalar().ToString();

            if ((tipo.Equals("Shareware") || (tipo.Equals("Freeware")) || (tipo.Equals("Trial Licence"))))
            {
                txtLicenciasDisp.Text = "Ilimitidas";
            }else
            {
                //SE HACE LA CONSULTA PARA SABER LA CANTIDAD DE LICENCIAS DISPONIBLES DEL SOFTWARE
                consulta = "SELECT cantidad FROM tblSoftware WHERE nombre = @nombre";
                SqlCommand cmd2 = new SqlCommand(consulta, Conexion.conectar());
                cmd2.Parameters.AddWithValue("@nombre", nombre);

                //SE ACTUALIZA EL CAMPO DE LAS LICENCIAS CON LAS LICENCIAS DISPONIBLES DEL SOFTWARE SELECCIONADO
                string cantidadDisp = cmd2.ExecuteScalar().ToString();
                txtLicenciasDisp.Text = cantidadDisp;
            }
            
        }

        private void btnInstalar_Click(object sender, EventArgs e)
        {
            if (comBoxComputadora.SelectedItem == null || comBoxSoftware.SelectedItem == null)
            {
                MessageBox.Show("No hay computadora o software seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                DateTime? fechaVencimiento;
                string vencimiento = "";

                //SE ACTUALIZA LA CANTIDAD DE LICENCIAS DEL SOFTWARE INSTALADO, DEPENDIENDO DEL TIPO
                string nombre = comBoxSoftware.SelectedItem.ToString();

                //SE HACE LA CONSULTA PARA SABER EL TIPO DE LICENCIA DEL SOFTWARE
                string consulta = "SELECT tipoLicencia,vencimiento FROM tblSoftware WHERE nombre = @nombre";

                SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                cmd.Parameters.AddWithValue("@nombre", nombre);

                string tipo = cmd.ExecuteScalar().ToString();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Obtener el valor de vencimiento y almacenarlo en una variable
                        vencimiento = reader["vencimiento"].ToString();

                    }
                }
                //SI EL TIPO DE LICENCIA ES DE PAGA
                if (!(tipo.Equals("Shareware") || (tipo.Equals("Freeware")) || (tipo.Equals("Trial Licence"))))
                {
                    //SELECCIONO LA CANTIDAD DE LICENCIA DISPONIBLE
                    int cantidad = int.Parse(txtLicenciasDisp.Text);
                    //SI LA CANTIDAD DE LICENCIA ES IGUAL A 0...
                    if (cantidad >= 1)
                    {


                        //SE OBTIENE EL CODIGO DEL SOFTWARE
                        string idSoftware = returnIdSoftware(comBoxSoftware.SelectedItem.ToString());

                        //SE OBTIENE EL PATRIMONIO DEL CPU
                        string patrimonioCPU = ObtenerPrimerosNCaracteres(comBoxComputadora.SelectedItem.ToString(), 6);

                        if (patrimonioCPU.Equals(""))
                        {
                            MessageBox.Show("No hay computadora seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Convierte el string a un valor numérico (por ejemplo, meses)
                            ObtenerDuracionEnMeses(vencimiento, out int mesesVencimiento);

                            fechaVencimiento = DateTime.Now.AddMonths(mesesVencimiento).Date;


                            DateTime fechaV = (DateTime)fechaVencimiento;

                            //MessageBox.Show(fechaV.ToString());

                            Boolean seInstalo = instalarSoftware(cedula, idSoftware, patrimonioCPU, fechaV);

                            if (seInstalo)
                            {

                                MessageBox.Show("Software instalado, con licencia", "Instalado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //ACTUALIZO LOS DATOS
                                actualizarDatos();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya no hay licencias disponibles", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {


                    fechaVencimiento = null;

                    //SE OBTIENE EL CODIGO DEL SOFTWARE
                    string idSoftware = returnIdSoftware(comBoxSoftware.SelectedItem.ToString());

                    //SE OBTIENE EL PATRIMONIO DEL CPU
                    string patrimonioCPU = ObtenerPrimerosNCaracteres(comBoxComputadora.SelectedItem.ToString(), 6);

                    if (patrimonioCPU.Equals(""))
                    {
                        MessageBox.Show("No hay computadora seleccionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Boolean seInstalo = instalarSoftware(cedula, idSoftware, patrimonioCPU, fechaVencimiento);

                        if (seInstalo)
                        {
                            MessageBox.Show("Software instalado, sin licencia", "Instalado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Software no instalado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

        }


        //FUNCION QUE INSTALA EL SOFTWARE Y RETORNA TRUE SI SE INSTALA CORRECTAMENTE O FALSE SI NO SE INSTALA
        private bool instalarSoftware(string cedula3, string idSoftware, string patrimonioCPU,DateTime? fechaVencimiento)
        {
            bool bandera;
            try
            {
                string consulta = "spInstalarSoftware";
                SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patrimonioCPU", patrimonioCPU);
                cmd.Parameters.AddWithValue("@idSoftware", idSoftware);
                cmd.Parameters.AddWithValue("@cedulaUsuarioInstalo", cedula3);
                cmd.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);

                cmd.ExecuteNonQuery();
                bandera = true;
            }catch (SqlException ex)
            {
                MessageBox.Show("El software ya está instalado en esta computadora","Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bandera = false;
            }

            return bandera;
            
        }


        

        //RETORNA EL ID DEL SOFTWARE
        private string returnIdSoftware(string nombreSoftware)
        {
            string consulta = "SELECT idSoftware FROM tblSoftware WHERE nombre = @nombre";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.conectar());
            cmd.Parameters.AddWithValue("@nombre", nombreSoftware);
            string id = cmd.ExecuteScalar().ToString();
            return id;
        }



        private bool ObtenerDuracionEnMeses(string vencimiento, out int mesesVencimiento)
        {
            // Mapa para convertir los términos de vencimiento a su equivalente en meses
            Dictionary<string, int> mapaVencimiento = new Dictionary<string, int>
    {
        {"3 meses", 3},
        {"6 meses", 6},
        {"12 meses", 12},
        {"24 meses", 24},
        {"36 meses", 36},
        {"Sin vencimiento", 0} // Valor grande para indicar que no hay vencimiento
    };

            // Intenta obtener el valor de duración en meses desde el mapa
            if (mapaVencimiento.TryGetValue(vencimiento, out mesesVencimiento))
            {
                return true;
            }

            // Si no se encuentra en el mapa, intenta convertir directamente a int
            return int.TryParse(vencimiento, out mesesVencimiento);
        }



    }
}
