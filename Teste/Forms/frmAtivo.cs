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

        clsBase Base = new clsBase();



        public frmAtivo()
        {
            InitializeComponent();

            this.Text = Application.ProductName.ToString() + " | Operação";

            toolStripStatusLabel1.Text = "v." + Application.ProductVersion.ToString();
            toolStripStatusLabel2.Text = clsUsuLogado.Log_Nome.ToString();
            toolStripStatusLabel4.Text = DateTime.Now.ToString("dd/MM/yyyy");

            CarregarCombos();
            P01_BuscaRegistro();
        }
        

        private void CarregarCombos()
        {
            cboTabulacao.Items.Clear();
            lstTabulacao.Items.Clear();
            foreach (DataRow item in clsConexao.Consulta("select Descricao ,Uso from Tabulacoes where Ativo = 1 order by Descricao").Rows)
            {
                cboTabulacao.Items.Add(item[0].ToString());
                lstTabulacao.Items.Add(item[1].ToString());
            }

            cboFPagto.Items.Clear();
            foreach (DataRow item in clsConexao.Consulta("select Descricao from Tab_Geral where Ativo = 1 and Titulo = 'FPAGTO' order by Descricao").Rows)
            {
                cboFPagto.Items.Add(item[0].ToString());
            }
        }


        private void LimparTela()
        {
            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, groupBox2);
            clsFuncoes.LimpaCampos(this, groupBox3);

            dtGridTel.DataSource = "";

            LimparClasseBase();
            this.Refresh();
        }


        private void LimparClasseBase()
        {
            Base.Bs_Dt_Arquivo = "";
            Base.Bs_Dt_Limite = "";
            Base.Bs_Acao = "";
            Base.Bs_Arquivo = "";
            Base.Bs_Ordem = "";
            Base.Bs_Nr_Ciclo_Atual = "";
            Base.Bs_Nr_Item_Ordem = "";
            Base.Bs_Cd_Prod_Midia = "";
            Base.Bs_Nome = "";
            Base.Bs_Doc = "";
            Base.Bs_Operador = "";
            Base.Bs_Tipo_Tab = "";
            Base.Bs_Tabulacao = "";
            Base.Bs_Data = "";
            Base.Bs_Hora = "";
            Base.Bs_Obs = "";
            Base.Bs_Uso = "";
            Base.Bs_Repasses = "";
            Base.Bs_Em_Uso = "";
            Base.Bs_Em_UsoHora  = "";

            Base.Bs_ObsDDD = "";
            Base.Bs_ObsTel = "";
            Base.Bs_ObsAg = "";

            Base.Bs_TotTel = 0;
            Base.Bs_LinhaGrid = 0;
        }


        private async void P01_BuscaRegistro()
        {
            LimparTela();

            // verifica se houve alteração na base de trab do operador
            clsUsuLogado.InicializaConfigOperador();
            
            if(await P02_BuscaAgenda(clsUsuLogado.Log_Cpf) == false)
            {
                if (await P03_BuscarRegLivre(clsUsuLogado.Log_Cpf ,clsUsuLogado.Log_Base) == false)
                {
                    MessageBox.Show("Sem Registros", "Base : " + clsUsuLogado.Log_Base , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async Task<bool> P02_BuscaAgenda(string _cpf)
        {
            Inicio:
            clsVariaveis.StrSQL = "select top 1 * from Agenda where Ativo = 1 and Operador = '" + _cpf +
                                  "' and Data <= '" + DateTime.Now.ToString("yyyy-MM-dd") +
                                  "' and Hora <= '" + DateTime.Now.ToString("HH:mm:ss") + "' order by Data desc ,Hora desc ";

            DataTable dt = new DataTable();
            dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dt.Rows.Count > 0)
            {
                bool booEhPos = await TemPositivoAsync(dt.Rows[0]["ordem"].ToString(), dt.Rows[0]["arquivo"].ToString(), dt.Rows[0]["acao"].ToString());

                if (booEhPos)
                {
                    // se existir um POS para o agendamento, des-ativar o Ag
                    clsVariaveis.StrSQL = "update Agenda set Ativo = 0 where IdAg = " + dt.Rows[0]["IdAg"].ToString();
                    bool booProc = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);

                    goto Inicio;
                    //return false;
                }
                else
                {
                    // preencher tela
                    Base.Bs_ObsDDD = dt.Rows[0]["DDD"].ToString();
                    Base.Bs_ObsTel = dt.Rows[0]["Telefone"].ToString();
                    Base.Bs_ObsAg = dt.Rows[0]["Obs"].ToString();

                    PreencheTela(_cpf, dt.Rows[0]["ordem"].ToString(), dt.Rows[0]["arquivo"].ToString(), dt.Rows[0]["acao"].ToString(), "SIM");

                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        private async Task<bool> P03_BuscarRegLivre(string _cpf, string _base)
        {
            clsVariaveis.StrSQL = "exec sp_BuscaRegistro '" + _cpf + "' ,'" + clsUsuLogado.Log_NomePC + "' ,'" + clsUsuLogado.Log_Base + "' ,'ASC' ";

            DataTable dt = new DataTable();
            dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dt.Rows.Count > 0)
            {
                PreencheTela(_cpf, dt.Rows[0]["ordem"].ToString(), dt.Rows[0]["arquivo"].ToString(), _base, "NAO");

                return true;
            }
            else
            {
                return false;
            }
        }


        public async void PreencheTela(string _cpf, string _ordem, string _arquivo, string _acao, string _ehAg)
        {
            if (_ehAg == "SIM")
            {
                clsVariaveis.StrSQL = ("select * from Base where uso = 9 and Ordem = '" + _ordem +
                                       "' and Arquivo = '" + _arquivo + "' and Acao = '" + _acao + "' ");
            }
            else
            {
                clsVariaveis.StrSQL = ("select * from Base where Uso in (0,8) and Em_Uso = 1 and Ordem = '" + _ordem +
                                       "' and Arquivo = '" + _arquivo + "' and Acao = '" + _acao + "' ");
            }
            DataTable dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dt.Rows.Count > 0)
            {
                // carregando alguns dados da classe : Base
                Base.Bs_Ordem = dt.Rows[0]["Ordem"].ToString();
                Base.Bs_Arquivo = dt.Rows[0]["Arquivo"].ToString();
                Base.Bs_Acao = dt.Rows[0]["Acao"].ToString();
                Base.Bs_Nome = dt.Rows[0]["Nome"].ToString();
                Base.Bs_Doc = dt.Rows[0]["Doc"].ToString();


                lblOrdem.Text = Base.Bs_Ordem;
                lblNome.Text = Base.Bs_Nome;

                PreencheGridTel();

                if (_ehAg == "SIM")
                {
                    lblDDD.Text = Base.Bs_ObsDDD;
                    lblFone.Text = Base.Bs_ObsTel;
                    lblAgendamento.Text = Base.Bs_ObsAg;
                }
                else
                {

                }

            }
        }


        private async void PreencheGridTel()
        {
            dtGridTel.DataSource = "";

            try
            {
                clsVariaveis.StrSQL = "select ddd ,telefone ,'' as Status from Base_Tel where Ordem = '" + Base.Bs_Ordem +
                     "' and Arquivo = '" + Base.Bs_Arquivo + "' and Acao = '" + Base.Bs_Acao +
                     "' order by Enriquecido ,Sim_Por";
                DataTable dt1 = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
                if (dt1.Rows.Count > 0)
                {
                    Base.Bs_TotTel = dt1.Rows.Count;
                    Base.Bs_LinhaGrid = 0;

                    dtGridTel.DataSource = dt1;
                    foreach (DataGridViewColumn coluna in dtGridTel.Columns)
                    {
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    SelecFoneDoGrid(Base.Bs_TotTel, Base.Bs_LinhaGrid);
                }
                else
                {
                    MessageBox.Show("Não foram localizados telefones para a Ordem", "PreencheGridTel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "PreencheGridTel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void SelecFoneDoGrid(int intTotLin ,int intLin)
        {
            if(intLin <= intTotLin)
            {
                lblDDD.Text = (dtGridTel[0, intLin].Value).ToString();
                lblFone.Text = (dtGridTel[1, intLin].Value).ToString();
            }
            else
            {

            }
        }


        private async Task<bool> TemPositivoAsync(string _ordem, string _arquivo, string _acao)
        {
            clsVariaveis.StrSQL = "select top 1 * from Base where Orderm = '" + _ordem +
                                  "' and Arquivo = '" + _arquivo + "' and acao = '" + _acao +
                                  "' and Resultado = 'POSITIVO' ";
            DataTable dt = new DataTable();
            dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void frmAtivo_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }

        private async void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Tem certeza ?", "Deseja fechar a tela", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                clsVariaveis.StrSQL = "update Base set Em_Uso = 0 where Em_Uso = 1 and Ordem = '" + Base.Bs_Ordem +
                            "' and Acao = '" + Base.Bs_Acao + "' and Arquivo = '" + Base.Bs_Arquivo +
                            "' and Operador = '" + clsUsuLogado.Log_Cpf + "'";
                bool booRes = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);

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

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if(lblDDD.Text != "" && cboTabulacao.Text != "")
            {
                switch (cboTabulacao.Text)
                {
                    case "AG":

                        break;

                    case "POSITIVO":

                        break;

                    default:

                        break;
                    
                }



            }
        }
    }






}
