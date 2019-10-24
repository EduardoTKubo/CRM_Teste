namespace Teste.Forms
{
    partial class frmUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCad = new System.Windows.Forms.TabPage();
            this.groupBoxCad = new System.Windows.Forms.GroupBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.listStatus = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSenha = new System.Windows.Forms.CheckBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.cboEquipe = new System.Windows.Forms.ComboBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.tabPageOper = new System.Windows.Forms.TabPage();
            this.dtGridOper = new System.Windows.Forms.DataGridView();
            this.tabPageOutrosUsuarios = new System.Windows.Forms.TabPage();
            this.dtGridUsu = new System.Windows.Forms.DataGridView();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.mnuCadUsu = new System.Windows.Forms.CheckBox();
            this.mnuSistema = new System.Windows.Forms.CheckBox();
            this.mnuRelat = new System.Windows.Forms.CheckBox();
            this.mnuBases = new System.Windows.Forms.CheckBox();
            this.mnuManut = new System.Windows.Forms.CheckBox();
            this.mnuAtivo = new System.Windows.Forms.CheckBox();
            this.mnuOperacao = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPageCad.SuspendLayout();
            this.groupBoxCad.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageOper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOper)).BeginInit();
            this.tabPageOutrosUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridUsu)).BeginInit();
            this.groupBoxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCad);
            this.tabControl1.Controls.Add(this.tabPageOper);
            this.tabControl1.Controls.Add(this.tabPageOutrosUsuarios);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(639, 365);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageCad
            // 
            this.tabPageCad.BackColor = System.Drawing.Color.Silver;
            this.tabPageCad.Controls.Add(this.groupBoxCad);
            this.tabPageCad.Location = new System.Drawing.Point(4, 22);
            this.tabPageCad.Name = "tabPageCad";
            this.tabPageCad.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCad.Size = new System.Drawing.Size(631, 339);
            this.tabPageCad.TabIndex = 0;
            this.tabPageCad.Text = "Cadastro";
            // 
            // groupBoxCad
            // 
            this.groupBoxCad.Controls.Add(this.groupBoxMenu);
            this.groupBoxCad.Controls.Add(this.lblCod);
            this.groupBoxCad.Controls.Add(this.listStatus);
            this.groupBoxCad.Controls.Add(this.groupBox3);
            this.groupBoxCad.Controls.Add(this.label5);
            this.groupBoxCad.Controls.Add(this.label4);
            this.groupBoxCad.Controls.Add(this.label3);
            this.groupBoxCad.Controls.Add(this.label2);
            this.groupBoxCad.Controls.Add(this.label1);
            this.groupBoxCad.Controls.Add(this.chkSenha);
            this.groupBoxCad.Controls.Add(this.txtSenha);
            this.groupBoxCad.Controls.Add(this.cboEquipe);
            this.groupBoxCad.Controls.Add(this.cboStatus);
            this.groupBoxCad.Controls.Add(this.txtNome);
            this.groupBoxCad.Controls.Add(this.txtCPF);
            this.groupBoxCad.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCad.Name = "groupBoxCad";
            this.groupBoxCad.Size = new System.Drawing.Size(619, 327);
            this.groupBoxCad.TabIndex = 1;
            this.groupBoxCad.TabStop = false;
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(333, 30);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(13, 13);
            this.lblCod.TabIndex = 18;
            this.lblCod.Text = "0";
            // 
            // listStatus
            // 
            this.listStatus.FormattingEnabled = true;
            this.listStatus.Location = new System.Drawing.Point(190, 85);
            this.listStatus.Name = "listStatus";
            this.listStatus.Size = new System.Drawing.Size(89, 30);
            this.listStatus.TabIndex = 2;
            this.listStatus.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Silver;
            this.groupBox3.Controls.Add(this.btnLimpar);
            this.groupBox3.Controls.Add(this.btnExcluir);
            this.groupBox3.Controls.Add(this.btnAlterar);
            this.groupBox3.Controls.Add(this.btnIncluir);
            this.groupBox3.Location = new System.Drawing.Point(18, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(579, 62);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpar.Location = new System.Drawing.Point(306, 15);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 37);
            this.btnLimpar.TabIndex = 17;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Silver;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.Black;
            this.btnExcluir.Location = new System.Drawing.Point(213, 15);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 37);
            this.btnExcluir.TabIndex = 16;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.Silver;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.Color.Black;
            this.btnAlterar.Location = new System.Drawing.Point(118, 15);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 37);
            this.btnAlterar.TabIndex = 15;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.BackColor = System.Drawing.Color.Silver;
            this.btnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.ForeColor = System.Drawing.Color.Black;
            this.btnIncluir.Location = new System.Drawing.Point(21, 15);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(78, 37);
            this.btnIncluir.TabIndex = 14;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Senha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Equipe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "CPF";
            // 
            // chkSenha
            // 
            this.chkSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSenha.Location = new System.Drawing.Point(66, 188);
            this.chkSenha.Name = "chkSenha";
            this.chkSenha.Size = new System.Drawing.Size(281, 20);
            this.chkSenha.TabIndex = 6;
            this.chkSenha.Text = "Solicitar esta senha ao acessar o App";
            this.chkSenha.UseVisualStyleBackColor = true;
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(66, 161);
            this.txtSenha.MaxLength = 20;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(281, 21);
            this.txtSenha.TabIndex = 4;
            // 
            // cboEquipe
            // 
            this.cboEquipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEquipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEquipe.FormattingEnabled = true;
            this.cboEquipe.Location = new System.Drawing.Point(66, 121);
            this.cboEquipe.Name = "cboEquipe";
            this.cboEquipe.Size = new System.Drawing.Size(281, 23);
            this.cboEquipe.TabIndex = 3;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(66, 92);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(281, 23);
            this.cboStatus.TabIndex = 2;
            this.cboStatus.SelectedValueChanged += new System.EventHandler(this.cboStatus_SelectedValueChanged);
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(66, 57);
            this.txtNome.MaxLength = 60;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(281, 21);
            this.txtNome.TabIndex = 1;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SomenteLetrasMaiusculas);
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(66, 30);
            this.txtCPF.MaxLength = 11;
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(109, 21);
            this.txtCPF.TabIndex = 0;
            // 
            // tabPageOper
            // 
            this.tabPageOper.Controls.Add(this.dtGridOper);
            this.tabPageOper.Location = new System.Drawing.Point(4, 22);
            this.tabPageOper.Name = "tabPageOper";
            this.tabPageOper.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOper.Size = new System.Drawing.Size(631, 339);
            this.tabPageOper.TabIndex = 1;
            this.tabPageOper.Text = "Operadores";
            this.tabPageOper.UseVisualStyleBackColor = true;
            // 
            // dtGridOper
            // 
            this.dtGridOper.Location = new System.Drawing.Point(20, 20);
            this.dtGridOper.Name = "dtGridOper";
            this.dtGridOper.Size = new System.Drawing.Size(588, 302);
            this.dtGridOper.TabIndex = 0;
            this.dtGridOper.DoubleClick += new System.EventHandler(this.dtGridOper_DoubleClick);
            // 
            // tabPageOutrosUsuarios
            // 
            this.tabPageOutrosUsuarios.Controls.Add(this.dtGridUsu);
            this.tabPageOutrosUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabPageOutrosUsuarios.Name = "tabPageOutrosUsuarios";
            this.tabPageOutrosUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOutrosUsuarios.Size = new System.Drawing.Size(631, 339);
            this.tabPageOutrosUsuarios.TabIndex = 2;
            this.tabPageOutrosUsuarios.Text = "Outros Usuários";
            this.tabPageOutrosUsuarios.UseVisualStyleBackColor = true;
            // 
            // dtGridUsu
            // 
            this.dtGridUsu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dtGridUsu.Location = new System.Drawing.Point(20, 20);
            this.dtGridUsu.Name = "dtGridUsu";
            this.dtGridUsu.Size = new System.Drawing.Size(592, 303);
            this.dtGridUsu.TabIndex = 0;
            this.dtGridUsu.DoubleClick += new System.EventHandler(this.dtGridUsu_DoubleClick);
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Controls.Add(this.mnuCadUsu);
            this.groupBoxMenu.Controls.Add(this.mnuSistema);
            this.groupBoxMenu.Controls.Add(this.mnuRelat);
            this.groupBoxMenu.Controls.Add(this.mnuBases);
            this.groupBoxMenu.Controls.Add(this.mnuManut);
            this.groupBoxMenu.Controls.Add(this.mnuAtivo);
            this.groupBoxMenu.Controls.Add(this.mnuOperacao);
            this.groupBoxMenu.Location = new System.Drawing.Point(374, 10);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(223, 230);
            this.groupBoxMenu.TabIndex = 19;
            this.groupBoxMenu.TabStop = false;
            // 
            // mnuCadUsu
            // 
            this.mnuCadUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuCadUsu.Location = new System.Drawing.Point(47, 192);
            this.mnuCadUsu.Name = "mnuCadUsu";
            this.mnuCadUsu.Size = new System.Drawing.Size(153, 20);
            this.mnuCadUsu.TabIndex = 8;
            this.mnuCadUsu.Text = "Cadastro de Usuários";
            this.mnuCadUsu.UseVisualStyleBackColor = true;
            // 
            // mnuSistema
            // 
            this.mnuSistema.BackColor = System.Drawing.Color.DarkGray;
            this.mnuSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSistema.ForeColor = System.Drawing.Color.Black;
            this.mnuSistema.Location = new System.Drawing.Point(28, 166);
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(172, 20);
            this.mnuSistema.TabIndex = 7;
            this.mnuSistema.Text = "Sistema";
            this.mnuSistema.UseVisualStyleBackColor = false;
            // 
            // mnuRelat
            // 
            this.mnuRelat.BackColor = System.Drawing.Color.DarkGray;
            this.mnuRelat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuRelat.ForeColor = System.Drawing.Color.Black;
            this.mnuRelat.Location = new System.Drawing.Point(28, 126);
            this.mnuRelat.Name = "mnuRelat";
            this.mnuRelat.Size = new System.Drawing.Size(172, 20);
            this.mnuRelat.TabIndex = 6;
            this.mnuRelat.Text = "Relatórios";
            this.mnuRelat.UseVisualStyleBackColor = false;
            // 
            // mnuBases
            // 
            this.mnuBases.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBases.Location = new System.Drawing.Point(47, 97);
            this.mnuBases.Name = "mnuBases";
            this.mnuBases.Size = new System.Drawing.Size(153, 20);
            this.mnuBases.TabIndex = 5;
            this.mnuBases.Text = "Bases";
            this.mnuBases.UseVisualStyleBackColor = true;
            // 
            // mnuManut
            // 
            this.mnuManut.BackColor = System.Drawing.Color.DarkGray;
            this.mnuManut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuManut.ForeColor = System.Drawing.Color.Black;
            this.mnuManut.Location = new System.Drawing.Point(28, 71);
            this.mnuManut.Name = "mnuManut";
            this.mnuManut.Size = new System.Drawing.Size(172, 20);
            this.mnuManut.TabIndex = 4;
            this.mnuManut.Text = "Manutenção";
            this.mnuManut.UseVisualStyleBackColor = false;
            // 
            // mnuAtivo
            // 
            this.mnuAtivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuAtivo.Location = new System.Drawing.Point(47, 45);
            this.mnuAtivo.Name = "mnuAtivo";
            this.mnuAtivo.Size = new System.Drawing.Size(153, 20);
            this.mnuAtivo.TabIndex = 3;
            this.mnuAtivo.Text = "Ativo";
            this.mnuAtivo.UseVisualStyleBackColor = true;
            // 
            // mnuOperacao
            // 
            this.mnuOperacao.BackColor = System.Drawing.Color.DarkGray;
            this.mnuOperacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuOperacao.ForeColor = System.Drawing.Color.Black;
            this.mnuOperacao.Location = new System.Drawing.Point(28, 19);
            this.mnuOperacao.Name = "mnuOperacao";
            this.mnuOperacao.Size = new System.Drawing.Size(172, 20);
            this.mnuOperacao.TabIndex = 2;
            this.mnuOperacao.Text = "Operação";
            this.mnuOperacao.UseVisualStyleBackColor = false;
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(663, 386);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuários";
            this.Resize += new System.EventHandler(this.frmUsuario_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPageCad.ResumeLayout(false);
            this.groupBoxCad.ResumeLayout(false);
            this.groupBoxCad.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPageOper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOper)).EndInit();
            this.tabPageOutrosUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridUsu)).EndInit();
            this.groupBoxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCad;
        private System.Windows.Forms.TabPage tabPageOper;
        private System.Windows.Forms.DataGridView dtGridOper;
        private System.Windows.Forms.TabPage tabPageOutrosUsuarios;
        private System.Windows.Forms.DataGridView dtGridUsu;
        private System.Windows.Forms.GroupBox groupBoxCad;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.ComboBox cboEquipe;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.ListBox listStatus;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.CheckBox mnuCadUsu;
        private System.Windows.Forms.CheckBox mnuSistema;
        private System.Windows.Forms.CheckBox mnuRelat;
        private System.Windows.Forms.CheckBox mnuBases;
        private System.Windows.Forms.CheckBox mnuManut;
        private System.Windows.Forms.CheckBox mnuAtivo;
        private System.Windows.Forms.CheckBox mnuOperacao;
    }
}