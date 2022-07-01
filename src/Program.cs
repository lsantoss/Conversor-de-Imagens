using System;
using System.Windows.Forms;

namespace ConversorImagens
{
    static class Program
    {
        /// <summary>
        /// Main entry point for the app.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}