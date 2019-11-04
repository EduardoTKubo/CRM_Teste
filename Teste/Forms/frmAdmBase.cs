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
    public partial class frmAdmBase : Form
    {
        //bool booFechaForm = false;


        public frmAdmBase()
        {
            InitializeComponent();

            this.Text = Application.ProductName.ToString() + " | Adm";

            toolStripStatusLabel1.Text = "v." + Application.ProductVersion.ToString();
            toolStripStatusLabel2.Text = clsUsuLogado.Log_Nome.ToString();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("dd/MM/yyyy");

            PreencherCombos();

            tabControl1.SelectedIndex = 0;
            ListarAcao();
        }

        private async void ListarAcao()
        {
            bool booRet = await ListarAcaoAsync();
        }

        private async Task<bool> ListarAcaoAsync()
        {
            try
            {
                clsVariaveis.StrSQL = "select ID ,Atrab ,Acao ,Seq from Tab_Acao where Ativo = 1 order by Acao";
                DataTable dt = new DataTable();
                dt = await clsConexao.ConsultaAsync(clsVariaveis.StrSQL);

                dtGridBases1.DataSource = dt;

                dtGridBases1.Columns[1].Width = 40;
                dtGridBases1.Columns[2].Width = 150;
                dtGridBases1.Columns[3].Width = 50;

                foreach (DataGridViewColumn column in dtGridBases1.Columns)
                {
                    if (column.DataPropertyName == "")
                    { column.Width = 10; }
                    else if (column.DataPropertyName == "ID")
                    { column.Visible = false; }
                    else
                    { column.SortMode = DataGridViewColumnSortMode.NotSortable; }
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Listar Acao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void PreencherCombos()
        {
            cbo1Seq.Items.Clear();
            cbo1Seq.Items.Add("ASC");
            cbo1Seq.Items.Add("DESC");


        }
        
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    bool booRet = await ListarAcaoAsync();
                    break;

                case 1:
                    ////dtPicker1.Value = DateTime.Today.Subtract(TimeSpan.FromDays(DateTime.Today.Day - 1));
                    ////dtPicker2.Value = DateTime.Now;
                    //PreencheCboEmpresa(dtPicker1.Value.ToString("yyyy-MM-dd"), dtPicker2.Value.ToString("yyyy-MM-dd"));
                    break;

                case 2:
                    //LimpaTabPage3();
                    //PreencherTabPage3();
                    break;
            }
        }

        private async void btn1_AtuBaseTrab_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Atualizar ?", "Deseja alterar as bases de trabalho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgv in dtGridBases1.Rows)                // percorrendo datagridview
                    {
                        if (dgv.Cells[0].Value != null)
                        {
                            if (dgv.Cells[1].Value.ToString() == "True")              // se estiver ticado
                            {
                                clsVariaveis.StrSQL = "update Tab_Acao set ATrab = 1 where Ativo = 1 and Acao = '" + dgv.Cells[2].Value.ToString()  + "'";
                            }
                            else
                            {
                                clsVariaveis.StrSQL = "update Tab_Acao set ATrab = 0 where Ativo = 1 and Acao = '" + dgv.Cells[2].Value.ToString() + "'";
                            }

                            bool booRet = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);
                        }
                    }
                    MessageBox.Show("Alterado com sucesso", "Alterar bases de trabalho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    await ListarAcaoAsync();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Alterar bases de trabalho", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private async void btn1AltSeq_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Atualizar ?", "Deseja alterar a sequência de base", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    clsVariaveis.StrSQL = "update Tab_Acao set SEQ = '" + cbo1Seq.Text + "' where Ativo = 1 ";
                    bool booRet = await clsConexao.ExecuteQueryAsync(clsVariaveis.StrSQL);
                    if (booRet)
                    {
                        MessageBox.Show("Alterado com sucesso", "Atualizar Sequencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        await ListarAcaoAsync();
                    }
                }
            }
            catch(Exception e1)
            {
 //               MessageBox.Show(e1.Message, "Atualizar Sequencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(e1.Message, "Atualizar Sequencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
