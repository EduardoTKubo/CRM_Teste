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

namespace Teste
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void SomenteLetrasMaiusculas(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Classes.clsFuncoes.IsNumeric(e);

            ////if (e.KeyChar == (char)Keys.Enter)
            ////{               
            //    // se der Enter ....
            ////}
        }

        private async void txtLogin_Leave(object sender, EventArgs e)
        {
            if(txtLogin.Text.Trim() != "")
            {
                txtSenha.Text = "";
                txtSenha.Enabled = false;

                string resp = clsFuncoes.ValidarDoc(this, txtLogin);
                if (resp != "")
                {
                    MessageBox.Show(resp, "CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLogin.Focus();
                }
                else
                {
                    clsVariaveis.StrSQL = "select SolicitaSenha from Usuario where Ativo = 1 and Doc = '" + txtLogin.Text + "'";
                    DataTable dt = new DataTable();
                    dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["SolicitaSenha"].ToString() == "True")
                        {
                            txtSenha.Enabled = true;
                            txtSenha.Focus();
                        }
                    }
                    else
                    {
                        btnAcesso.Focus();
                    }
                }
            }
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        private async void btnAcesso_Click(object sender, EventArgs e)
        {
            if (await clsUsuLogado.IsLoginOK(txtLogin.Text, txtSenha.Text))
            {
                if (await clsUsuLogado.ObterDadosUsuarioLogado(txtLogin.Text))
                {
                    clsUsuLogado.MapOperacional(clsUsuLogado.Log_Cpf);
                    this.Close();
                }        
            }
            else
            {
                MessageBox.Show("Usuario não localizado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            btnAcesso.PerformClick();   // vai executar o evento > btnAcesso_Click
        }
    }
}
