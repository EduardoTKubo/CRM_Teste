using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.Classes;
using Teste.Forms;


namespace Teste
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

            if(clsUsuLogado.Log_Status == "OPERADOR")
            {
                Application.Run(new frmAtivo());
            }
            else
            {
                Application.Run(new frmMDI());
            }
        }

    }
}
