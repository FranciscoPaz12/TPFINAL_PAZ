using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFINAL_PAZ.Models;

namespace TPFINAL_PAZ
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Cargamos los ingredientes de prueba al iniciar la aplicacion
            DatosAlquimia.CargarIngredientesPrueba();
            Application.Run(new Form1());
        }
    }
}
