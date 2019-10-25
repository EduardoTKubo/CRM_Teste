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
    public partial class frmAtivo : Form
    {
        bool booFechaForm = false;

        public frmAtivo()
        {
            InitializeComponent();

            this.Text = Application.ProductName.ToString() + " | Operação";

            toolStripStatusLabel1.Text = "v." + Application.ProductVersion.ToString();
            toolStripStatusLabel2.Text = clsUsuLogado.Log_Nome.ToString();
            toolStripStatusLabel4.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }


        private void frmAtivo_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza ?", "Deseja fechar a tela", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                booFechaForm = true;
                this.Close();
            }
        }

        private void frmAtivo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(booFechaForm == false)
            {
                e.Cancel = true;
            }
        }
    }






}
