using ProyectoFinalProgramacionIV.Pantallas_programa;
using ProyectoFinalProgramacionIV.SubmenúInstalaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalProgramacionIV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {   //Habilida estilos visuales de la app//
            Application.EnableVisualStyles();
            //Establece valor prederterminado para el uso de controles //   
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia ejecucion del programa en respectivo FORM //
            Application.Run(new Login());
        }
    }
}
