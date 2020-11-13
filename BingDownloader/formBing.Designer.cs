namespace BingDownloader
{
	partial class FormBing
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBing));
			this.lsbPaises = new System.Windows.Forms.ListBox();
			this.dgvResultado = new System.Windows.Forms.DataGridView();
			this.dgcDataPublicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcNomeArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.grbIdioma = new System.Windows.Forms.GroupBox();
			this.rdbIdioma1 = new System.Windows.Forms.RadioButton();
			this.rdbIdioma2 = new System.Windows.Forms.RadioButton();
			this.rdbIdioma3 = new System.Windows.Forms.RadioButton();
			this.grbDimensoes = new System.Windows.Forms.GroupBox();
			this.cboDimensoes = new System.Windows.Forms.ComboBox();
			this.wbbResultado = new System.Windows.Forms.WebBrowser();
			this.grbLayout = new System.Windows.Forms.GroupBox();
			this.rdbLayout1 = new System.Windows.Forms.RadioButton();
			this.rdbLayout2 = new System.Windows.Forms.RadioButton();
			this.rdbLayout3 = new System.Windows.Forms.RadioButton();
			this.grbNavegacao = new System.Windows.Forms.GroupBox();
			this.cmdCidadeSeg = new System.Windows.Forms.Button();
			this.cmdCidadeAnt = new System.Windows.Forms.Button();
			this.dgvDisponibilidade = new System.Windows.Forms.DataGridView();
			this.sstStatus = new System.Windows.Forms.StatusStrip();
			this.tsslCopyright = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslProcessamento = new System.Windows.Forms.ToolStripStatusLabel();
			this.cmdSaveAll = new System.Windows.Forms.Button();
			this.grbPaises = new System.Windows.Forms.GroupBox();
			this.pcbTeste = new System.Windows.Forms.PictureBox();
			this.dgcCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDispPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDispDataPublicacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDispBase = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDispNomeArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDispURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgcDispDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
			this.grbIdioma.SuspendLayout();
			this.grbDimensoes.SuspendLayout();
			this.grbLayout.SuspendLayout();
			this.grbNavegacao.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisponibilidade)).BeginInit();
			this.sstStatus.SuspendLayout();
			this.grbPaises.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pcbTeste)).BeginInit();
			this.SuspendLayout();
			// 
			// lsbPaises
			// 
			this.lsbPaises.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lsbPaises.FormattingEnabled = true;
			this.lsbPaises.HorizontalScrollbar = true;
			this.lsbPaises.Location = new System.Drawing.Point(6, 19);
			this.lsbPaises.Name = "lsbPaises";
			this.lsbPaises.Size = new System.Drawing.Size(277, 56);
			this.lsbPaises.TabIndex = 1;
			this.lsbPaises.Click += new System.EventHandler(this.LsbPaises_Click);
			// 
			// dgvResultado
			// 
			this.dgvResultado.AllowUserToAddRows = false;
			this.dgvResultado.AllowUserToDeleteRows = false;
			this.dgvResultado.AllowUserToOrderColumns = true;
			this.dgvResultado.AllowUserToResizeColumns = false;
			this.dgvResultado.AllowUserToResizeRows = false;
			this.dgvResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcDataPublicacao,
            this.dgcBase,
            this.dgcNomeArquivo,
            this.dgcURL,
            this.dgcDescricao,
            this.dgcStatus});
			this.dgvResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvResultado.Location = new System.Drawing.Point(12, 603);
			this.dgvResultado.MultiSelect = false;
			this.dgvResultado.Name = "dgvResultado";
			this.dgvResultado.ReadOnly = true;
			this.dgvResultado.RowHeadersVisible = false;
			this.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvResultado.Size = new System.Drawing.Size(984, 101);
			this.dgvResultado.TabIndex = 4;
			this.dgvResultado.Visible = false;
			// 
			// dgcDataPublicacao
			// 
			this.dgcDataPublicacao.HeaderText = "DATA";
			this.dgcDataPublicacao.Name = "dgcDataPublicacao";
			this.dgcDataPublicacao.ReadOnly = true;
			this.dgcDataPublicacao.Width = 61;
			// 
			// dgcBase
			// 
			this.dgcBase.HeaderText = "BASE";
			this.dgcBase.Name = "dgcBase";
			this.dgcBase.ReadOnly = true;
			this.dgcBase.Width = 60;
			// 
			// dgcNomeArquivo
			// 
			this.dgcNomeArquivo.HeaderText = "NOME DO ARQUIVO";
			this.dgcNomeArquivo.Name = "dgcNomeArquivo";
			this.dgcNomeArquivo.ReadOnly = true;
			this.dgcNomeArquivo.Width = 135;
			// 
			// dgcURL
			// 
			this.dgcURL.HeaderText = "URL";
			this.dgcURL.Name = "dgcURL";
			this.dgcURL.ReadOnly = true;
			this.dgcURL.Width = 54;
			// 
			// dgcDescricao
			// 
			this.dgcDescricao.HeaderText = "DESCRIÇÃO";
			this.dgcDescricao.Name = "dgcDescricao";
			this.dgcDescricao.ReadOnly = true;
			this.dgcDescricao.Width = 94;
			// 
			// dgcStatus
			// 
			this.dgcStatus.HeaderText = "STATUS";
			this.dgcStatus.Name = "dgcStatus";
			this.dgcStatus.ReadOnly = true;
			this.dgcStatus.Width = 75;
			// 
			// grbIdioma
			// 
			this.grbIdioma.Controls.Add(this.rdbIdioma1);
			this.grbIdioma.Controls.Add(this.rdbIdioma2);
			this.grbIdioma.Controls.Add(this.rdbIdioma3);
			this.grbIdioma.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grbIdioma.ForeColor = System.Drawing.Color.Blue;
			this.grbIdioma.Location = new System.Drawing.Point(12, 12);
			this.grbIdioma.Name = "grbIdioma";
			this.grbIdioma.Size = new System.Drawing.Size(100, 89);
			this.grbIdioma.TabIndex = 2;
			this.grbIdioma.TabStop = false;
			this.grbIdioma.Text = " IDIOMA ";
			// 
			// rdbIdioma1
			// 
			this.rdbIdioma1.AutoSize = true;
			this.rdbIdioma1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbIdioma1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rdbIdioma1.Location = new System.Drawing.Point(6, 19);
			this.rdbIdioma1.Name = "rdbIdioma1";
			this.rdbIdioma1.Size = new System.Drawing.Size(82, 17);
			this.rdbIdioma1.TabIndex = 0;
			this.rdbIdioma1.Text = "&Português";
			this.rdbIdioma1.UseVisualStyleBackColor = true;
			this.rdbIdioma1.CheckedChanged += new System.EventHandler(this.RdbIdioma1_CheckedChanged);
			// 
			// rdbIdioma2
			// 
			this.rdbIdioma2.AutoSize = true;
			this.rdbIdioma2.Checked = true;
			this.rdbIdioma2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbIdioma2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rdbIdioma2.Location = new System.Drawing.Point(6, 42);
			this.rdbIdioma2.Name = "rdbIdioma2";
			this.rdbIdioma2.Size = new System.Drawing.Size(60, 17);
			this.rdbIdioma2.TabIndex = 1;
			this.rdbIdioma2.TabStop = true;
			this.rdbIdioma2.Text = "&Inglês";
			this.rdbIdioma2.UseVisualStyleBackColor = true;
			this.rdbIdioma2.CheckedChanged += new System.EventHandler(this.RdbIdioma2_CheckedChanged);
			// 
			// rdbIdioma3
			// 
			this.rdbIdioma3.AutoSize = true;
			this.rdbIdioma3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbIdioma3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rdbIdioma3.Location = new System.Drawing.Point(6, 65);
			this.rdbIdioma3.Name = "rdbIdioma3";
			this.rdbIdioma3.Size = new System.Drawing.Size(76, 17);
			this.rdbIdioma3.TabIndex = 2;
			this.rdbIdioma3.Text = "&Espanhol";
			this.rdbIdioma3.UseVisualStyleBackColor = true;
			this.rdbIdioma3.CheckedChanged += new System.EventHandler(this.RdbIdioma3_CheckedChanged);
			// 
			// grbDimensoes
			// 
			this.grbDimensoes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.grbDimensoes.Controls.Add(this.cboDimensoes);
			this.grbDimensoes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grbDimensoes.ForeColor = System.Drawing.Color.Blue;
			this.grbDimensoes.Location = new System.Drawing.Point(413, 12);
			this.grbDimensoes.Name = "grbDimensoes";
			this.grbDimensoes.Size = new System.Drawing.Size(133, 89);
			this.grbDimensoes.TabIndex = 3;
			this.grbDimensoes.TabStop = false;
			this.grbDimensoes.Text = " RESOLUÇÃO ";
			// 
			// cboDimensoes
			// 
			this.cboDimensoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDimensoes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboDimensoes.FormattingEnabled = true;
			this.cboDimensoes.Location = new System.Drawing.Point(6, 19);
			this.cboDimensoes.MaxDropDownItems = 5;
			this.cboDimensoes.Name = "cboDimensoes";
			this.cboDimensoes.Size = new System.Drawing.Size(121, 21);
			this.cboDimensoes.TabIndex = 0;
			this.cboDimensoes.Click += new System.EventHandler(this.CboDimensoes_Click);
			// 
			// wbbResultado
			// 
			this.wbbResultado.AllowWebBrowserDrop = false;
			this.wbbResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wbbResultado.Location = new System.Drawing.Point(12, 223);
			this.wbbResultado.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbbResultado.Name = "wbbResultado";
			this.wbbResultado.Size = new System.Drawing.Size(984, 481);
			this.wbbResultado.TabIndex = 7;
			// 
			// grbLayout
			// 
			this.grbLayout.Controls.Add(this.rdbLayout1);
			this.grbLayout.Controls.Add(this.rdbLayout2);
			this.grbLayout.Controls.Add(this.rdbLayout3);
			this.grbLayout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grbLayout.ForeColor = System.Drawing.Color.Blue;
			this.grbLayout.Location = new System.Drawing.Point(552, 12);
			this.grbLayout.Name = "grbLayout";
			this.grbLayout.Size = new System.Drawing.Size(195, 89);
			this.grbLayout.TabIndex = 5;
			this.grbLayout.TabStop = false;
			this.grbLayout.Text = " LAYOUT ";
			// 
			// rdbLayout1
			// 
			this.rdbLayout1.AutoSize = true;
			this.rdbLayout1.Checked = true;
			this.rdbLayout1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbLayout1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rdbLayout1.Location = new System.Drawing.Point(6, 19);
			this.rdbLayout1.Name = "rdbLayout1";
			this.rdbLayout1.Size = new System.Drawing.Size(83, 17);
			this.rdbLayout1.TabIndex = 0;
			this.rdbLayout1.TabStop = true;
			this.rdbLayout1.Text = "&Detalhado";
			this.rdbLayout1.UseVisualStyleBackColor = true;
			this.rdbLayout1.Click += new System.EventHandler(this.RdbLayout1_Click);
			// 
			// rdbLayout2
			// 
			this.rdbLayout2.AutoSize = true;
			this.rdbLayout2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbLayout2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rdbLayout2.Location = new System.Drawing.Point(6, 42);
			this.rdbLayout2.Name = "rdbLayout2";
			this.rdbLayout2.Size = new System.Drawing.Size(83, 17);
			this.rdbLayout2.TabIndex = 1;
			this.rdbLayout2.Text = "&Compacto";
			this.rdbLayout2.UseVisualStyleBackColor = true;
			this.rdbLayout2.Click += new System.EventHandler(this.RdbLayout2_Click);
			// 
			// rdbLayout3
			// 
			this.rdbLayout3.AutoSize = true;
			this.rdbLayout3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdbLayout3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rdbLayout3.Location = new System.Drawing.Point(6, 65);
			this.rdbLayout3.Name = "rdbLayout3";
			this.rdbLayout3.Size = new System.Drawing.Size(155, 17);
			this.rdbLayout3.TabIndex = 2;
			this.rdbLayout3.Text = "&Todos os não baixados";
			this.rdbLayout3.UseVisualStyleBackColor = true;
			this.rdbLayout3.Click += new System.EventHandler(this.RdbLayout3_Click);
			// 
			// grbNavegacao
			// 
			this.grbNavegacao.Controls.Add(this.cmdCidadeSeg);
			this.grbNavegacao.Controls.Add(this.cmdCidadeAnt);
			this.grbNavegacao.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grbNavegacao.ForeColor = System.Drawing.Color.Blue;
			this.grbNavegacao.Location = new System.Drawing.Point(753, 12);
			this.grbNavegacao.Name = "grbNavegacao";
			this.grbNavegacao.Size = new System.Drawing.Size(137, 89);
			this.grbNavegacao.TabIndex = 6;
			this.grbNavegacao.TabStop = false;
			this.grbNavegacao.Text = " NAVEGAÇÃO ";
			// 
			// cmdCidadeSeg
			// 
			this.cmdCidadeSeg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCidadeSeg.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCidadeSeg.Location = new System.Drawing.Point(6, 48);
			this.cmdCidadeSeg.Name = "cmdCidadeSeg";
			this.cmdCidadeSeg.Size = new System.Drawing.Size(120, 23);
			this.cmdCidadeSeg.TabIndex = 1;
			this.cmdCidadeSeg.Text = "&Próxima cidade";
			this.cmdCidadeSeg.UseVisualStyleBackColor = true;
			this.cmdCidadeSeg.Click += new System.EventHandler(this.CmdCidadeSeg_Click);
			// 
			// cmdCidadeAnt
			// 
			this.cmdCidadeAnt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmdCidadeAnt.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCidadeAnt.Location = new System.Drawing.Point(6, 19);
			this.cmdCidadeAnt.Name = "cmdCidadeAnt";
			this.cmdCidadeAnt.Size = new System.Drawing.Size(120, 23);
			this.cmdCidadeAnt.TabIndex = 0;
			this.cmdCidadeAnt.Text = "&Cidade anterior";
			this.cmdCidadeAnt.UseVisualStyleBackColor = true;
			this.cmdCidadeAnt.Click += new System.EventHandler(this.CmdCidadeAnt_Click);
			// 
			// dgvDisponibilidade
			// 
			this.dgvDisponibilidade.AllowUserToAddRows = false;
			this.dgvDisponibilidade.AllowUserToDeleteRows = false;
			this.dgvDisponibilidade.AllowUserToOrderColumns = true;
			this.dgvDisponibilidade.AllowUserToResizeColumns = false;
			this.dgvDisponibilidade.AllowUserToResizeRows = false;
			this.dgvDisponibilidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDisponibilidade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dgvDisponibilidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dgvDisponibilidade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcCodigo,
            this.dgcDispPais,
            this.dgcDispDataPublicacao,
            this.dgcDispBase,
            this.dgcDispNomeArquivo,
            this.dgcDispURL,
            this.dgcDispDescricao});
			this.dgvDisponibilidade.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvDisponibilidade.Location = new System.Drawing.Point(12, 107);
			this.dgvDisponibilidade.MultiSelect = false;
			this.dgvDisponibilidade.Name = "dgvDisponibilidade";
			this.dgvDisponibilidade.ReadOnly = true;
			this.dgvDisponibilidade.RowHeadersVisible = false;
			this.dgvDisponibilidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDisponibilidade.Size = new System.Drawing.Size(984, 490);
			this.dgvDisponibilidade.TabIndex = 8;
			// 
			// sstStatus
			// 
			this.sstStatus.BackColor = global::BingDownloader.Properties.Settings.Default.backgroundColor;
			this.sstStatus.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BingDownloader.Properties.Settings.Default, "backgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.sstStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslCopyright,
            this.tsslProcessamento});
			this.sstStatus.Location = new System.Drawing.Point(0, 707);
			this.sstStatus.Name = "sstStatus";
			this.sstStatus.Size = new System.Drawing.Size(1008, 22);
			this.sstStatus.TabIndex = 9;
			this.sstStatus.Text = "statusStrip1";
			// 
			// tsslCopyright
			// 
			this.tsslCopyright.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsslCopyright.ForeColor = System.Drawing.Color.Blue;
			this.tsslCopyright.Name = "tsslCopyright";
			this.tsslCopyright.Size = new System.Drawing.Size(322, 17);
			this.tsslCopyright.Text = "© COPYRIGHT 2020 BY VITOR HUGO FALCÃO MONTAN";
			// 
			// tsslProcessamento
			// 
			this.tsslProcessamento.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsslProcessamento.Name = "tsslProcessamento";
			this.tsslProcessamento.Size = new System.Drawing.Size(671, 17);
			this.tsslProcessamento.Spring = true;
			this.tsslProcessamento.Text = "STATUS DO PROCESSAMENTO DA LISTA";
			this.tsslProcessamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmdSaveAll
			// 
			this.cmdSaveAll.AutoSize = true;
			this.cmdSaveAll.Enabled = false;
			this.cmdSaveAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdSaveAll.Image")));
			this.cmdSaveAll.Location = new System.Drawing.Point(896, 17);
			this.cmdSaveAll.Name = "cmdSaveAll";
			this.cmdSaveAll.Size = new System.Drawing.Size(76, 77);
			this.cmdSaveAll.TabIndex = 10;
			this.cmdSaveAll.Text = "&Salvar todas";
			this.cmdSaveAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.cmdSaveAll.UseVisualStyleBackColor = true;
			this.cmdSaveAll.Click += new System.EventHandler(this.CmdSaveAll_Click);
			// 
			// grbPaises
			// 
			this.grbPaises.Controls.Add(this.lsbPaises);
			this.grbPaises.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.grbPaises.ForeColor = System.Drawing.Color.Blue;
			this.grbPaises.Location = new System.Drawing.Point(118, 12);
			this.grbPaises.Name = "grbPaises";
			this.grbPaises.Size = new System.Drawing.Size(289, 89);
			this.grbPaises.TabIndex = 11;
			this.grbPaises.TabStop = false;
			this.grbPaises.Text = " LISTA DE PAÍSES DISPONÍVEIS ";
			// 
			// pcbTeste
			// 
			this.pcbTeste.Location = new System.Drawing.Point(978, 12);
			this.pcbTeste.Name = "pcbTeste";
			this.pcbTeste.Size = new System.Drawing.Size(100, 50);
			this.pcbTeste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pcbTeste.TabIndex = 12;
			this.pcbTeste.TabStop = false;
			this.pcbTeste.Visible = false;
			// 
			// dgcCodigo
			// 
			this.dgcCodigo.HeaderText = "CÓDIGO";
			this.dgcCodigo.Name = "dgcCodigo";
			this.dgcCodigo.ReadOnly = true;
			this.dgcCodigo.Width = 74;
			// 
			// dgcDispPais
			// 
			this.dgcDispPais.HeaderText = "PAÍS";
			this.dgcDispPais.Name = "dgcDispPais";
			this.dgcDispPais.ReadOnly = true;
			this.dgcDispPais.Width = 56;
			// 
			// dgcDispDataPublicacao
			// 
			this.dgcDispDataPublicacao.HeaderText = "DATA";
			this.dgcDispDataPublicacao.Name = "dgcDispDataPublicacao";
			this.dgcDispDataPublicacao.ReadOnly = true;
			this.dgcDispDataPublicacao.Width = 61;
			// 
			// dgcDispBase
			// 
			this.dgcDispBase.HeaderText = "BASE";
			this.dgcDispBase.Name = "dgcDispBase";
			this.dgcDispBase.ReadOnly = true;
			this.dgcDispBase.Width = 60;
			// 
			// dgcDispNomeArquivo
			// 
			this.dgcDispNomeArquivo.HeaderText = "NOME DO ARQUIVO";
			this.dgcDispNomeArquivo.Name = "dgcDispNomeArquivo";
			this.dgcDispNomeArquivo.ReadOnly = true;
			this.dgcDispNomeArquivo.Width = 135;
			// 
			// dgcDispURL
			// 
			this.dgcDispURL.HeaderText = "URL";
			this.dgcDispURL.Name = "dgcDispURL";
			this.dgcDispURL.ReadOnly = true;
			this.dgcDispURL.Width = 54;
			// 
			// dgcDispDescricao
			// 
			this.dgcDispDescricao.HeaderText = "DESCRIÇÃO";
			this.dgcDispDescricao.Name = "dgcDispDescricao";
			this.dgcDispDescricao.ReadOnly = true;
			this.dgcDispDescricao.Width = 94;
			// 
			// FormBing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::BingDownloader.Properties.Settings.Default.backgroundColor;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.pcbTeste);
			this.Controls.Add(this.grbPaises);
			this.Controls.Add(this.cmdSaveAll);
			this.Controls.Add(this.sstStatus);
			this.Controls.Add(this.grbNavegacao);
			this.Controls.Add(this.grbLayout);
			this.Controls.Add(this.wbbResultado);
			this.Controls.Add(this.grbDimensoes);
			this.Controls.Add(this.grbIdioma);
			this.Controls.Add(this.dgvResultado);
			this.Controls.Add(this.dgvDisponibilidade);
			this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BingDownloader.Properties.Settings.Default, "backgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormBing";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BING WALLPAPER DOWNLOADER 2.1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormBing_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
			this.grbIdioma.ResumeLayout(false);
			this.grbIdioma.PerformLayout();
			this.grbDimensoes.ResumeLayout(false);
			this.grbLayout.ResumeLayout(false);
			this.grbLayout.PerformLayout();
			this.grbNavegacao.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDisponibilidade)).EndInit();
			this.sstStatus.ResumeLayout(false);
			this.sstStatus.PerformLayout();
			this.grbPaises.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pcbTeste)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lsbPaises;
		private System.Windows.Forms.DataGridView dgvResultado;
		private System.Windows.Forms.GroupBox grbIdioma;
		private System.Windows.Forms.RadioButton rdbIdioma1;
		private System.Windows.Forms.RadioButton rdbIdioma2;
		private System.Windows.Forms.RadioButton rdbIdioma3;
		private System.Windows.Forms.GroupBox grbDimensoes;
		private System.Windows.Forms.ComboBox cboDimensoes;
		private System.Windows.Forms.WebBrowser wbbResultado;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDataPublicacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcBase;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcNomeArquivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcURL;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDescricao;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcStatus;
		private System.Windows.Forms.GroupBox grbLayout;
		private System.Windows.Forms.RadioButton rdbLayout1;
		private System.Windows.Forms.RadioButton rdbLayout2;
		private System.Windows.Forms.RadioButton rdbLayout3;
		private System.Windows.Forms.GroupBox grbNavegacao;
		private System.Windows.Forms.Button cmdCidadeSeg;
		private System.Windows.Forms.Button cmdCidadeAnt;
		private System.Windows.Forms.DataGridView dgvDisponibilidade;
		private System.Windows.Forms.StatusStrip sstStatus;
		private System.Windows.Forms.ToolStripStatusLabel tsslCopyright;
		private System.Windows.Forms.ToolStripStatusLabel tsslProcessamento;
		private System.Windows.Forms.Button cmdSaveAll;
		private System.Windows.Forms.GroupBox grbPaises;
		private System.Windows.Forms.PictureBox pcbTeste;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcCodigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDispPais;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDispDataPublicacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDispBase;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDispNomeArquivo;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDispURL;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgcDispDescricao;
	}
}

