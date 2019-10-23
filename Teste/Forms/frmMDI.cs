using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Teste.Classes;

namespace Teste.Forms
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();

            toolStripStatusLabel1.Text = Application.ProductName.ToString();
            toolStripStatusLabel2.Text = clsUsuLogado.Log_Nome.ToString();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //foreach (DataRow Acesso in clsConexao.ConsultaAsync("SELECT * FROM USUARIO_ACESSO_MENU WHERE IdUsu = " + clsUsuLogado.Log_Id).Rows)
            //{
            //    foreach (ToolStripMenuItem item in menuStrip1.Items)
            //    {
            //        if (item.Name == Acesso["ACESSO"].ToString())
            //        {
            //            item.Enabled = true;
            //        }

            //        foreach (ToolStripItem subitem in (item as ToolStripMenuItem).DropDownItems)
            //        {
            //            if (subitem.Name == Acesso["ACESSO"].ToString())
            //            {
            //                subitem.Enabled = true;
            //            }
            //        }
            //    }
            //}


        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
