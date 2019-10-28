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

            P01_BuscaRegistro();

        }
        

        private void LimparTela()
        {
            clsFuncoes.LimpaCampos(this, groupBox1);
            clsFuncoes.LimpaCampos(this, groupBox2);
            clsFuncoes.LimpaCampos(this, groupBox3);

            dtGridTel.DataSource = "";

            LimparClasseBase();
            //LimpaClsVariaveis();
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
        }


        private async void P01_BuscaRegistro()
        {
            LimparTela();

            // verifica se houve alteração na base de trab do operador
            clsUsuLogado.InicializaConfigOperador();
            
            if(await P02_BuscaAgenda(clsUsuLogado.Log_Cpf) == false)
            {
                if (await P03_BuscarRegLivre(clsUsuLogado.Log_Cpf ,clsUsuLogado.Log_Base ))
                {

                }
            }
        }

        private async Task<bool> P02_BuscaAgenda(string _cpf)
        {
            clsVariaveis.StrSQL = "select top 1 * from Agenda where Ativo = 1 and Operador = '" + _cpf +
                                  "' and Data <= '" + DateTime.Now.ToString("yyyy-MM-dd") +
                                  "' and Hora <= '" + DateTime.Now.ToString("HH:mm:ss") + "' order by Data desc ,Hora desc ";

            DataTable dt = new DataTable();
            dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if(dt.Rows.Count > 0)
            {
                bool booEhPos = await TemPositivoAsync(dt.Rows[0]["ordem"].ToString(), dt.Rows[0]["arquivo"].ToString(), dt.Rows[0]["acao"].ToString());

                if (booEhPos )
                {
                    // se existir um POS para o agendamento, des-ativar o Ag
                    clsVariaveis.StrSQL = "update Agenda set Ativo = 0 where IdAg = " + dt.Rows[0]["IdAg"].ToString();
                    bool booProc = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);

                    return false;
                }
                else
                {
                    // preencher tela
                    Base.Bs_ObsDDD = dt.Rows[0]["DDD"].ToString();
                    Base.Bs_ObsTel = dt.Rows[0]["Telefone"].ToString();
                    Base.Bs_ObsAg = dt.Rows[0]["Obs"].ToString();

                    PreencheTela( _cpf, dt.Rows[0]["ordem"].ToString(), dt.Rows[0]["arquivo"].ToString(), dt.Rows[0]["acao"].ToString(), "SIM");

                    return true;
                }
            }
            else
            {
                return false;
            }
        }


        private async Task<bool> P03_BuscarRegLivre(string _cpf ,string _base)
        {
            clsVariaveis.StrSQL = "exec sp_BuscaRegistro '" + _cpf + "' ,'" + clsUsuLogado.Log_NomePC + "' ,'" + clsUsuLogado.Log_Base + "' ,'ASC' " ;

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


        private async void PreencheTela(string _cpf, string _ordem, string _arquivo, string _acao, string _ehAg)
        {
            if (_ehAg == "SIM")
            {
                clsVariaveis.StrSQL = ("select * from Base where uso = 9 and Ordem = '" + _ordem +
                                       "' and Arquivo = '" + _arquivo + "' and Acao = '" + _acao + "' ");
            }
            else
            {
                clsVariaveis.StrSQL = ("select * from Base where Uso in (0,8) and Em_Uso = 1 and Ordem = '" + _ordem  + 
                                       "' and Arquivo = '" + _arquivo + "' and Acao = '" + _acao + "' ");
            }
            DataTable dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            if (dt.Rows.Count > 0)
            {
                Base.Bs_Ordem = dt.Rows[0]["Ordem"].ToString();
                Base.Bs_Arquivo = dt.Rows[0]["Arquivo"].ToString();
                Base.Bs_Acao = dt.Rows[0]["Acao"].ToString();
                Base.Bs_Nome = dt.Rows[0]["Nome"].ToString();
                Base.Bs_Doc = dt.Rows[0]["Doc"].ToString();

                lblOrdem.Text = Base.Bs_Ordem;
                lblNome.Text = Base.Bs_Nome;

                PreencheGridTel();

            }
        }

        private async void PreencheGridTel()
        {
            dtGridTel.DataSource = "";

            clsVariaveis.StrSQL = "select ddd ,telefone from Base_Tel where Ordem = '" + Base.Bs_Ordem +
                     "' and Arquivo = '" + Base.Bs_Arquivo + "' and Acao = '" + Base.Bs_Acao +
                     "' order by Enriquecido ,Sim_Por";
            DataTable dt1 = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);
            dtGridTel.DataSource = dt1;
        }


        private async Task<bool> TemPositivoAsync(string _ordem ,string _arquivo ,string _acao)
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
