

using GestorDatos;
using System;
using System.Windows.Forms;

namespace WfVistaSplitBuddies
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
            // Crear la instancia concreta
            IGestorDatos gestorDatos = new GestorDatos.GestorDatos();

            // Application.Run(new Form1(gestorDatos));
            Application.Run(new Form1(gestorDatos));
        }
    }
}
