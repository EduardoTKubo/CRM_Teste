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
    public partial class frmUsuario : Form
    {
        private string strAcao = string.Empty;
        clsUsuario CadUsu = new clsUsuario();


        public frmUsuario()
        {
            InitializeComponent();

            P01_PreencherCombos();
            P02_PreencherGrids();

            strAcao = "INCLUSAO";
            TrataBotoes(strAcao);
        }


        private void P01_PreencherCombos()
        {
            cboStatus.Items.Clear();
            listStatus.Items.Clear();
            cboEquipe.Items.Clear();

            DataTable dt1 = new DataTable();
            dt1 = clsConexao.Consulta("select descricao ,descricao2 from Tab_Geral where Titulo = 'USU_STATUS' and Descricao2 >= '" + clsUsuLogado.Log_Rank + "' and Ativo = 1 order by Descricao");
            foreach (DataRow item in dt1.Rows)
            {
                cboStatus.Items.Add(item[0].ToString());
                listStatus.Items.Add(item[1].ToString());
            }

            dt1 = clsConexao.Consulta("select descricao from Tab_Geral where Titulo = 'EQUIPE' and Ativo = 1 order by Descricao");
            foreach (DataRow item in dt1.Rows)
            {
                cboEquipe.Items.Add(item[0].ToString());
            }
        }


        private void P02_PreencherGrids()
        {
            //  Configurar nas propriedades do datagridview
            //  AllowUserToResizeColumns    = True
            //  AutoSizeColumnsMode         = None
            //  ColumnHeadresHeightSizeMode = EnableResizing

            try
            {
                DataTable dt1 = new DataTable();
                dt1 = clsConexao.Consulta("select IdUsu ,Equipe ,Nome ,Doc as CPF from Usuario where Status = 'OPERADOR' and Ativo = 1 order by Equipe ,Nome");
                dtGridOper.DataSource = dt1;
                foreach (DataGridViewColumn coluna in dtGridOper.Columns)
                {
                    if (coluna.DataPropertyName == "IdUsu")
                        coluna.Visible = false;
                    else
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dt1 = clsConexao.Consulta("select IdUsu ,Status ,Nome from Usuario where Status <> 'OPERADOR' and Ativo = 1 order by Status ,Nome");
                dtGridUsu.DataSource = dt1;
                foreach (DataGridViewColumn coluna in dtGridUsu.Columns)
                {
                    if (coluna.DataPropertyName == "IdUsu")
                        coluna.Visible = false;
                    else
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Preenchendo os Grids", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void P03_PreencherTela(string tipo, string idcod)
        {
            try
            {
                Limpar();
                txtCPF.PasswordChar = Convert.ToChar("*");

                clsVariaveis.StrSQL = string.Empty;
                if (tipo == "CPF")
                {
                    clsVariaveis.StrSQL = ("select * from Usuario where Ativo = 1 and Doc = '@cpf' ").Replace("@cpf", idcod);
                }
                else if (tipo == "COD")
                {
                    clsVariaveis.StrSQL = ("select * from Usuario where Ativo = 1 and IdUsu = @idcod ").Replace("@idcod", idcod);
                }
                DataTable dtUsu = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
                if (dtUsu.Rows.Count > 0)
                {
                    lblCod.Text = dtUsu.Rows[0]["idusu"].ToString();
                    txtCPF.Text = dtUsu.Rows[0]["doc"].ToString();
                    txtNome.Text = dtUsu.Rows[0]["nome"].ToString();

                    cboStatus.Text = dtUsu.Rows[0]["status"].ToString();
                    listStatus.SelectedIndex = cboStatus.FindStringExact(cboStatus.Text, listStatus.SelectedIndex);
                    cboStatus.SelectedIndex = listStatus.SelectedIndex;

                    if(cboStatus.Text == "OPERADOR")
                    {
                        txtSenha.Enabled = false;
                        chkSenha.Enabled = false;
                    }

                    cboEquipe.Text = dtUsu.Rows[0]["equipe"].ToString();

                    txtSenha.Text = dtUsu.Rows[0]["senha"].ToString();
                    if (Convert.ToBoolean(dtUsu.Rows[0]["solicitasenha"].ToString()) == true)
                    {
                        chkSenha.Checked = true;
                    }
                    else
                    {
                        chkSenha.Checked = false;
                    }


                    // preenchendo Acesso
                    foreach (DataRow Acesso in clsConexao.Consulta("select NomeMenu from Usuario_Acesso_Menu where IdUsu = " + lblCod.Text + "").Rows)
                    {
                        foreach (Control c in this.groupBoxMenu.Controls)
                        {
                            if (c is CheckBox)
                            {
                                CheckBox chk = c as CheckBox;
                                if (chk.Name == Acesso["NomeMenu"].ToString())
                                {
                                    chk.Checked = true;
                                }
                            }
                        }
                    }
                    TrataBotoes("ALTERACAO");
                }
                else
                {
                    TrataBotoes("INCLUSAO");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Preenche a Tela", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void P04_AtualizaClasseUsuario()
        {
            CadUsu.Usu_Id = Convert.ToInt32(lblCod.Text);
            CadUsu.Usu_Cpf = txtCPF.Text.ToString();
            CadUsu.Usu_Nome = txtNome.Text.ToString();

            CadUsu.Usu_Status = cboStatus.Text.ToString();
            listStatus.SelectedIndex = cboStatus.FindStringExact(cboStatus.Text, listStatus.SelectedIndex);
            CadUsu.Usu_Rank = listStatus.Text.ToString();
            CadUsu.Usu_Equipe = cboEquipe.Text.ToString();

            CadUsu.Usu_Senha = txtSenha.Text.ToString();
            CadUsu.Usu_PedeSenha = chkSenha.Checked.ToString();
        }

        private void Limpar()
        {
            lblCod.Text = "0";
            txtCPF.PasswordChar = '\0';
            txtCPF.Enabled = true;

            txtSenha.Enabled = true;
            chkSenha.Enabled = true;

            clsFuncoes.LimpaCampos(this, groupBoxCad);
            clsFuncoes.LimpaCampos(this, groupBoxMenu);
        }

        private void SomenteLetrasMaiusculas(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void TrataBotoes(string acao)
        {
            tabControl1.SelectedIndex = 0;
            switch (acao)
            {
                case "INCLUSAO":
                    btnIncluir.Enabled = true;
                    btnAlterar.Enabled = false;
                    btnExcluir.Enabled = false;
                    break;
                case "ALTERACAO":
                    btnIncluir.Enabled = false;
                    btnAlterar.Enabled = true;
                    btnExcluir.Enabled = true;
                    txtCPF.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void frmUsuario_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        private void dtGridOper_DoubleClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dtGridOper[0, dtGridOper.CurrentRow.Index].Value);
            P03_PreencherTela("COD", ID.ToString());
        }

        private void dtGridUsu_DoubleClick(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dtGridUsu[0, dtGridUsu.CurrentRow.Index].Value);
            P03_PreencherTela("COD", ID.ToString());
        }


        private async void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja incluir ?", "Inclusão de Usuário", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    P04_AtualizaClasseUsuario();

                    try
                    {
                        // 01 incluindo em Usuario
                        DataTable dt = new DataTable();
                        dt = await clsConexao.ExecuteQueryRetornoAsync(clsUsuario.ComandoInsertUsuario(CadUsu));


                        // 02 incluindo em Usuario_Acesso_Menu
                        DataTable dtUsu = new DataTable();
                        dtUsu = clsConexao.Consulta("select top 1 IdUsu from Usuario where Doc = '" + txtCPF.Text + "' and Ativo = 1 order by IdUsu desc");
                        if (dtUsu.Rows.Count > 0)
                        {
                            lblCod.Text = dtUsu.Rows[0]["IdUsu"].ToString();

                            foreach (Control c in this.groupBoxMenu.Controls)
                            {
                                if (c is CheckBox)
                                {
                                    CheckBox chk = c as CheckBox;
                                    if (chk.Checked == true)
                                    {
                                        clsVariaveis.StrSQL = ("insert into Usuario_Acesso_Menu ( IdUsu ,NomeMenu ) values ( @idcod ,'@acesso' )").Replace("@idcod", lblCod.Text).Replace("@acesso", chk.Name.ToString());
                                        bool booIncl = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Incluído com sucesso", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        TrataBotoes("INCLUSAO");
                        P02_PreencherGrids();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private async void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCPF.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja alterar ?", "Alteração / Usuário", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    P04_AtualizaClasseUsuario();

                    try
                    {
                        // alteracao em Usuario
                        DataTable dt = await clsConexao.ExecuteQueryRetornoAsync(clsUsuario.ComandoUpdateUsuario(CadUsu));


                        // alteracao em Usuario_Acesso_Menu
                        clsVariaveis.StrSQL = ("delete from Usuario_Acesso_Menu where IdUsu = @idcod").Replace("@idcod", lblCod.Text);
                        bool booDel = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);
                        if (booDel)
                        {
                            // INCLUINDO EM USUARIO_ACESSO_MENU
                            foreach (Control c in this.groupBoxMenu.Controls)
                            {
                                if (c is CheckBox)
                                {
                                    CheckBox chk = c as CheckBox;
                                    if (chk.Checked == true)
                                    {
                                        clsVariaveis.StrSQL = ("Insert into Usuario_Acesso_Menu ( IdUsu ,NomeMenu ) VALUES ( @idcod ,'@acesso' )").Replace("@idcod", lblCod.Text).Replace("@acesso", chk.Name.ToString());
                                        bool booIncl = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);
                                    }
                                }
                            }

                            MessageBox.Show("Alterado com sucesso", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Limpar();
                            TrataBotoes("INCLUSAO");
                            P02_PreencherGrids();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao excluir", "Excluir / Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lblCod.Text != "0")
            {
                DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir o usuário ?", "Excluir / Usuário", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    clsVariaveis.StrSQL = ("update Usuario set Ativo = 0 where IdUsu = @idcod").Replace("@idcod", lblCod.Text);
                    bool booDel = await clsConexao.ExecuteQueryAsync (clsVariaveis.StrSQL);
                    if (booDel)
                    {
                        MessageBox.Show("Excluído com sucesso", "Excluir / Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        TrataBotoes("INCLUSAO");
                        P02_PreencherGrids();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir", "Excluir / Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
            TrataBotoes("INCLUSAO");
        }

        private void cboStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboStatus.Text == "OPERADOR")
            {
                txtSenha.Text = "";
                txtSenha.Enabled = false;
                chkSenha.Checked = false;
                chkSenha.Enabled = false;
            }
            else
            {
                txtSenha.Enabled = true;
                chkSenha.Enabled = true;
            }
        }
    }
}
