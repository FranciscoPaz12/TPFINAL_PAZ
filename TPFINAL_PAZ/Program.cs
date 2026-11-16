using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFINAL_PAZ.Models;
using TPFINAL_PAZ.Data;
using DotNetEnv;

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

            //Cargar las variables del archivo .env
            Env.Load();

            Application.Run(new Form1());
        }
    }
}
