using ProyectoFinalProgramacionIV.SubmenúComputadoras;
using ProyectoFinalProgramacionIV.SubmenúCuentas;
using ProyectoFinalProgramacionIV.SubmenúInstalaciones;
using ProyectoFinalProgramacionIV.SubmenúSoftware;

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace ProyectoFinalProgramacionIV.Pantallas_programa
  
{
    public partial class MenuPrincipal : Form
    {
        //RECIBE PARAMENTROS
        private string cedula = "";
        private string tipo = "";
        //CONTROLA LA HORA
        private Timer temporizador;

        public MenuPrincipal()
        {
            InitializeComponent();

            this.Text = "PCCONTROL";
            
            //SE CREA UN TEMPORIZADOR DE 1000 MILISEGUNDOS
            temporizador = new Timer();
            temporizador.Interval = 1000;

            //SE ASOCIA EL EVENTO TICK CON EL MANEJADOR DE EVENTOS
            temporizador.Tick += actualizarHora;

            temporizador.Start();
            
            //SE OCULTA LOS SUBMENU
            ocultarSubMenus();



            //COMENTAR//////////////////////////
            //SE OBTIENE LA CEDULA
            cedula = DatosCompartidos.Cedula;
            labelCedula.Text = cedula;

            //SE OBTIENE EL ROL
            tipo = DatosCompartidos.tipo;
            labelTipo.Text = tipo;
            ////////////////////////////////////
        }

        //ACTUALIZA LA HORA DEL SISTEMA
        public void actualizarHora(object sender, EventArgs e)
        {
            //OBTIENE LA HORA ACTUAL
            DateTime horaActual = DateTime.Now;

            labelHora.Text = horaActual.ToString("HH:mm:ss");
            
        }

        
        


        //SE DECLARA UNA VARIABLE PARA GUARDAR EL FORM
        private Form formActivo = null;

        //METODO PARA ABRIR OTROS FORMULARIOS DENTRO DEL PANEL
        private void abrirForm(Form formularioHijo)
        {
            //SI EXISTE UN FORM ABIERTO SE CIERRA
            if (formularioHijo != null)
            {
                //formActivo.Close();
                formActivo = formularioHijo;
                //ESTABLECEMOS QUE EL FORM NO ES DE NIVEL SUPERIOR
                formularioHijo.TopLevel = false;
                formularioHijo.FormBorderStyle = FormBorderStyle.None;
                formularioHijo.Dock = DockStyle.Fill;
                //SE AGREGA EL FORM AL PANEL
                PanelDatos.Controls.Add(formularioHijo);
                //SE ASOCIA
                PanelDatos.Tag = formularioHijo;
                formularioHijo.BringToFront();
                formularioHijo.Show();
            }
        }
        

        




        //PANELES


        //PARA MOVER EL PANEL
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        //CIERRA EL FORM
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

        //FUNCIONES QUE OCULTA LOS PANELES DE SUBMENU
        private void ocultarSubMenus()
        {
            subMenuComputadoras.Visible =   false;
            subMenuCuentas.Visible      =   false;
            subMenuDepartamento.Visible =   false;
            subMenuInstalaciones.Visible=   false;
            subMenuSoftware.Visible     =   false;
        }

        //SI LOS SUBMENUS ESTAN VISIBLES SE OCULTAS
        private void ocultarSubMenus2()
        {
            if (subMenuComputadoras.Visible == true)
            {
                subMenuComputadoras.Visible = false;
            }
            if (subMenuCuentas.Visible == true)
            {
                subMenuCuentas.Visible = false;
            }
            
            if (subMenuInstalaciones.Visible == true)
            {
                subMenuInstalaciones.Visible = false;
            }
            if (subMenuSoftware.Visible == true)
            {
                subMenuSoftware.Visible = false;
            }
            if (subMenuDepartamento.Visible == true)
            {
                subMenuDepartamento .Visible = false;
            }
        }

        //FUNCION QUE MUESTRA EL SUBMENU
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false) { 
                ocultarSubMenus2();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }


        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            //SE ABRE EL FORM EN EL PANEL
            mostrarSubMenu(subMenuDepartamento);
        }

        private void btnInsertarSoftware_Click_1(object sender, EventArgs e)
        {
            abrirForm(new RegistrarSofwarecs());


            ocultarSubMenus2();
        }

        private void btnEliminarSoftware_Click_1(object sender, EventArgs e)
        {
            abrirForm(new FormEliminarSoftware());


            ocultarSubMenus2();
        }

        private void btnActualizarSoftware_Click_1(object sender, EventArgs e)
        {
            abrirForm(new FormActualizarSoftware());


            ocultarSubMenus2();
        }

        private void btnConsultarSoftware_Click(object sender, EventArgs e)
        {
            abrirForm(new FormConsultaSoftware());


            ocultarSubMenus2();
        }

        private void btnComputadoras_Click_1(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuComputadoras);
        }

        private void btnSoftware_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuSoftware);
        }

        private void btnInstalaciones_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuInstalaciones);
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(subMenuCuentas);
        }

        private void btnInsertarComputadoras_Click(object sender, EventArgs e)
        {
            abrirForm(new FormInsertarComputadora());


            ocultarSubMenus2();
        }

        private void btnEliminarComputadoras_Click(object sender, EventArgs e)
        {

            abrirForm(new FormEliminarCPU());

            ocultarSubMenus2();
        }

        private void btnActualizarComputadoras_Click(object sender, EventArgs e)
        {
            
            abrirForm(new FormAsignarCPU());

            ocultarSubMenus2();
        }

        private void btnConsultarComputadoras_Click(object sender, EventArgs e)
        {
            abrirForm(new FormConsultarCpus());

            ocultarSubMenus2();
        }

        private void btnInstalar_Click(object sender, EventArgs e)
        {
            abrirForm(new FormInstalarSoftware());


            ocultarSubMenus2();
        }

        private void btnEliminarInstalaciones_Click(object sender, EventArgs e)
        {
            abrirForm(new FormEliminarInstalaciones());


            ocultarSubMenus2();
        }

        private void btnActualizarInstalaciones_Click(object sender, EventArgs e)
        {
            abrirForm(new FormActualizarInstalacion());

            ocultarSubMenus2();
        }

        private void btnConsultarInstalaciones_Click(object sender, EventArgs e)
        {
            abrirForm(new FormConsultarInstalaciones());


            ocultarSubMenus2();
        }

        private void btnCrearCuentas_Click(object sender, EventArgs e)
        {
            abrirForm(new FormCrearCuenta());


            ocultarSubMenus2();
        }

        private void btnEliminarCuentas_Click(object sender, EventArgs e)
        {
            abrirForm(new FormEliminarCuenta());


            ocultarSubMenus2();
        }

        private void btnActualizarCuentas_Click(object sender, EventArgs e)
        {
            abrirForm(new FormActualizarCuenta());


            ocultarSubMenus2();
        }

        private void btnConsultarCuentas_Click(object sender, EventArgs e)
        {
            abrirForm(new FormConsultarCuentas());


            ocultarSubMenus2();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCrearDepartamento_Click(object sender, EventArgs e)
        {
            abrirForm(new RegistrarNuevoDepartamento());
            ocultarSubMenus2();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            labelFecha.Text = DateTime.Now.ToShortDateString();

            //SE LE DA ACCESO DEPENDIENDO DEL TIPO DE USUARIO QUE INGRESA AL SISTEMA
            if (tipo.Equals("Usuario de TI"))
            {
                btnCuentas.Enabled = false;
                btnDepartamentos.Enabled = false;
            }else if (tipo.Equals("Usuario de la empresa"))
            {
                btnSoftware.Enabled = false;
                btnComputadoras.Enabled = false;
                btnInstalaciones.Enabled = false;
                btnCuentas.Enabled = false;
                btnDepartamentos.Enabled = false;
            }
            
        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarDepartamento_Click(object sender, EventArgs e)
        {
            abrirForm(new FormEliminarDep());
            ocultarSubMenus2();
        }

        private void btnConsultarDepartamento_Click(object sender, EventArgs e)
        {
            abrirForm(new FormConsultarDep());
            ocultarSubMenus2();
        }

        private void PanelDatos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAcercaDe ad = new FormAcercaDe();
            ad.Show();
        }
    }
    }
