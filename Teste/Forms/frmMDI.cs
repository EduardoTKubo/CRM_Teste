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

            this.Text = Application.ProductName.ToString();

            toolStripStatusLabel1.Text = "v." + Application.ProductVersion.ToString();
            toolStripStatusLabel2.Text = clsUsuLogado.Log_Nome.ToString();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            TrataMenus();
        }

        private async void TrataMenus()
        {
            DataTable dt = new DataTable();
            dt = await clsConexao.ConsultaAsync("SELECT * FROM USUARIO_ACESSO_MENU WHERE IdUsu = " + clsUsuLogado.Log_Id);

            foreach (DataRow Acesso in dt.Rows)
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    if (item.Name == Acesso["NomeMenu"].ToString())
                    {
                        item.Enabled = true;
                    }

                    foreach (ToolStripItem subitem in (item as ToolStripMenuItem).DropDownItems)
                    {
                        if (subitem.Name == Acesso["NomeMenu"].ToString())
                        {
                            subitem.Enabled = true;
                        }
                    }
                }
            }
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuCadUsu_Click(object sender, EventArgs e)
        {
            Classes.clsFuncoes.OpenForm(new Forms.frmUsuario(), this, "1");
        }

        private void frmMDI_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
