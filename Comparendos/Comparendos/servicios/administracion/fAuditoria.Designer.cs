namespace Comparendos.servicios.administracion
{
    partial class fAuditoria
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAuditoria));
            this.lblTabla = new System.Windows.Forms.Label();
            this.grpBoxFiltros = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chckBoxFecha = new System.Windows.Forms.CheckBox();
            this.dtPickFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.dtPickFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.cmbBoxUsuarios = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbBoxTabla = new System.Windows.Forms.ComboBox();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.dtGrdViewAuditorias = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grpBoxFiltros.SuspendLayout();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdViewAuditorias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTabla
            // 
            this.lblTabla.AutoSize = true;
            this.lblTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabla.Location = new System.Drawing.Point(24, 27);
            this.lblTabla.Name = "lblTabla";
            this.lblTabla.Size = new System.Drawing.Size(43, 13);
            this.lblTabla.TabIndex = 0;
            this.lblTabla.Text = "Tabla:";
            // 
            // grpBoxFiltros
            // 
            this.grpBoxFiltros.Controls.Add(this.btnBuscar);
            this.grpBoxFiltros.Controls.Add(this.chckBoxFecha);
            this.grpBoxFiltros.Controls.Add(this.dtPickFechaFinal);
            this.grpBoxFiltros.Controls.Add(this.lblFechaFinal);
            this.grpBoxFiltros.Controls.Add(this.dtPickFechaInicial);
            this.grpBoxFiltros.Controls.Add(this.lblFechaInicial);
            this.grpBoxFiltros.Controls.Add(this.txtValor);
            this.grpBoxFiltros.Controls.Add(this.lblValor);
            this.grpBoxFiltros.Controls.Add(this.cmbBoxUsuarios);
            this.grpBoxFiltros.Controls.Add(this.lblUsuario);
            this.grpBoxFiltros.Controls.Add(this.cmbBoxTabla);
            this.grpBoxFiltros.Controls.Add(this.lblTabla);
            this.grpBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpBoxFiltros.Name = "grpBoxFiltros";
            this.grpBoxFiltros.Size = new System.Drawing.Size(710, 166);
            this.grpBoxFiltros.TabIndex = 0;
            this.grpBoxFiltros.TabStop = false;
            this.grpBoxFiltros.Text = "Filtros";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ImageIndex = 10;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(622, 123);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(70, 28);
            this.btnBuscar.TabIndex = 33;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "system-log-out.png");
            this.imageList1.Images.SetKeyName(1, "system-search.png");
            this.imageList1.Images.SetKeyName(2, "view-refresh.png");
            this.imageList1.Images.SetKeyName(3, "edit-find.png");
            this.imageList1.Images.SetKeyName(4, "go-first.png");
            this.imageList1.Images.SetKeyName(5, "go-last.png");
            this.imageList1.Images.SetKeyName(6, "go-next.png");
            this.imageList1.Images.SetKeyName(7, "go-previous.png");
            this.imageList1.Images.SetKeyName(8, "list-add.png");
            this.imageList1.Images.SetKeyName(9, "list-remove.png");
            this.imageList1.Images.SetKeyName(10, "search.ico");
            this.imageList1.Images.SetKeyName(11, "button_cancel.ico");
            this.imageList1.Images.SetKeyName(12, "button_ok.ico");
            this.imageList1.Images.SetKeyName(13, "remove.gif");
            this.imageList1.Images.SetKeyName(14, "stop.gif");
            this.imageList1.Images.SetKeyName(15, "editdelete.gif");
            this.imageList1.Images.SetKeyName(16, "save.bmp");
            this.imageList1.Images.SetKeyName(17, "edit16.bmp");
            // 
            // chckBoxFecha
            // 
            this.chckBoxFecha.AutoSize = true;
            this.chckBoxFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBoxFecha.Location = new System.Drawing.Point(470, 100);
            this.chckBoxFecha.Name = "chckBoxFecha";
            this.chckBoxFecha.Size = new System.Drawing.Size(119, 17);
            this.chckBoxFecha.TabIndex = 6;
            this.chckBoxFecha.Text = "Filtrar por Fecha";
            this.chckBoxFecha.UseVisualStyleBackColor = true;
            this.chckBoxFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chckBoxFecha_KeyPress);
            // 
            // dtPickFechaFinal
            // 
            this.dtPickFechaFinal.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaFinal.Location = new System.Drawing.Point(321, 97);
            this.dtPickFechaFinal.Name = "dtPickFechaFinal";
            this.dtPickFechaFinal.Size = new System.Drawing.Size(91, 20);
            this.dtPickFechaFinal.TabIndex = 5;
            this.dtPickFechaFinal.ValueChanged += new System.EventHandler(this.dtPickFechaFinal_ValueChanged);
            this.dtPickFechaFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaFinal_KeyPress);
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinal.Location = new System.Drawing.Point(231, 101);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(77, 13);
            this.lblFechaFinal.TabIndex = 8;
            this.lblFechaFinal.Text = "Fecha Final:";
            // 
            // dtPickFechaInicial
            // 
            this.dtPickFechaInicial.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaInicial.Location = new System.Drawing.Point(114, 97);
            this.dtPickFechaInicial.Name = "dtPickFechaInicial";
            this.dtPickFechaInicial.Size = new System.Drawing.Size(91, 20);
            this.dtPickFechaInicial.TabIndex = 4;
            this.dtPickFechaInicial.ValueChanged += new System.EventHandler(this.dtPickFechaInicial_ValueChanged);
            this.dtPickFechaInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaInicial_KeyPress);
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicial.Location = new System.Drawing.Point(24, 101);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(84, 13);
            this.lblFechaInicial.TabIndex = 6;
            this.lblFechaInicial.Text = "Fecha Inicial:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(73, 61);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(84, 20);
            this.txtValor.TabIndex = 3;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(24, 64);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(40, 13);
            this.lblValor.TabIndex = 4;
            this.lblValor.Text = "Valor:";
            // 
            // cmbBoxUsuarios
            // 
            this.cmbBoxUsuarios.DisplayMember = "LOGIN";
            this.cmbBoxUsuarios.FormattingEnabled = true;
            this.cmbBoxUsuarios.Location = new System.Drawing.Point(495, 24);
            this.cmbBoxUsuarios.Name = "cmbBoxUsuarios";
            this.cmbBoxUsuarios.Size = new System.Drawing.Size(197, 21);
            this.cmbBoxUsuarios.TabIndex = 2;
            this.cmbBoxUsuarios.ValueMember = "ID_USUARIO";
            this.cmbBoxUsuarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxUsuarios_KeyPress);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(435, 27);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 13);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario:";
            // 
            // cmbBoxTabla
            // 
            this.cmbBoxTabla.DisplayMember = "TABLAAFECTADA";
            this.cmbBoxTabla.FormattingEnabled = true;
            this.cmbBoxTabla.Location = new System.Drawing.Point(73, 24);
            this.cmbBoxTabla.Name = "cmbBoxTabla";
            this.cmbBoxTabla.Size = new System.Drawing.Size(290, 21);
            this.cmbBoxTabla.TabIndex = 1;
            this.cmbBoxTabla.ValueMember = "TABLAAFECTADA";
            this.cmbBoxTabla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxTabla_KeyPress);
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.dtGrdViewAuditorias);
            this.grpBox.Location = new System.Drawing.Point(12, 184);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(832, 273);
            this.grpBox.TabIndex = 7;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Información";
            // 
            // dtGrdViewAuditorias
            // 
            this.dtGrdViewAuditorias.AllowUserToAddRows = false;
            this.dtGrdViewAuditorias.AllowUserToDeleteRows = false;
            this.dtGrdViewAuditorias.AllowUserToOrderColumns = true;
            this.dtGrdViewAuditorias.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dtGrdViewAuditorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdViewAuditorias.Location = new System.Drawing.Point(7, 19);
            this.dtGrdViewAuditorias.Name = "dtGrdViewAuditorias";
            this.dtGrdViewAuditorias.ReadOnly = true;
            this.dtGrdViewAuditorias.Size = new System.Drawing.Size(819, 248);
            this.dtGrdViewAuditorias.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.ImageIndex = 40;
            this.btnExport.ImageList = this.imageList2;
            this.btnExport.Location = new System.Drawing.Point(730, 481);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(114, 31);
            this.btnExport.TabIndex = 3;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Exportar a &Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "system-log-out.png");
            this.imageList2.Images.SetKeyName(1, "system-search.png");
            this.imageList2.Images.SetKeyName(2, "view-refresh.png");
            this.imageList2.Images.SetKeyName(3, "edit-find.png");
            this.imageList2.Images.SetKeyName(4, "go-first.png");
            this.imageList2.Images.SetKeyName(5, "go-last.png");
            this.imageList2.Images.SetKeyName(6, "go-next.png");
            this.imageList2.Images.SetKeyName(7, "go-previous.png");
            this.imageList2.Images.SetKeyName(8, "list-add.png");
            this.imageList2.Images.SetKeyName(9, "list-remove.png");
            this.imageList2.Images.SetKeyName(10, "search.ico");
            this.imageList2.Images.SetKeyName(11, "button_cancel.ico");
            this.imageList2.Images.SetKeyName(12, "button_ok.ico");
            this.imageList2.Images.SetKeyName(13, "Users.ico");
            this.imageList2.Images.SetKeyName(14, "User.ico");
            this.imageList2.Images.SetKeyName(15, "printer.gif");
            this.imageList2.Images.SetKeyName(16, "16 (Find).ico");
            this.imageList2.Images.SetKeyName(17, "16 (Flag blue).ico");
            this.imageList2.Images.SetKeyName(18, "16 (Folder).ico");
            this.imageList2.Images.SetKeyName(19, "16 (Lock off).ico");
            this.imageList2.Images.SetKeyName(20, "16 (Lock on).ico");
            this.imageList2.Images.SetKeyName(21, "16 (Print preview).ico");
            this.imageList2.Images.SetKeyName(22, "16 (Print).ico");
            this.imageList2.Images.SetKeyName(23, "16 (Save).ico");
            this.imageList2.Images.SetKeyName(24, "16 (User).ico");
            this.imageList2.Images.SetKeyName(25, "16 (Users).ico");
            this.imageList2.Images.SetKeyName(26, "16 (Contents).ico");
            this.imageList2.Images.SetKeyName(27, "16 (Db cancel).ico");
            this.imageList2.Images.SetKeyName(28, "16 (Db delete).ico");
            this.imageList2.Images.SetKeyName(29, "16 (Db edit).ico");
            this.imageList2.Images.SetKeyName(30, "16 (Db first).ico");
            this.imageList2.Images.SetKeyName(31, "16 (Db insert).ico");
            this.imageList2.Images.SetKeyName(32, "16 (Db last).ico");
            this.imageList2.Images.SetKeyName(33, "16 (Db next).ico");
            this.imageList2.Images.SetKeyName(34, "16 (Db post).ico");
            this.imageList2.Images.SetKeyName(35, "16 (Db previous).ico");
            this.imageList2.Images.SetKeyName(36, "16 (Db refresh).ico");
            this.imageList2.Images.SetKeyName(37, "16 (Execute).ico");
            this.imageList2.Images.SetKeyName(38, "16 (Exit).ico");
            this.imageList2.Images.SetKeyName(39, "16 (Fill up).ico");
            this.imageList2.Images.SetKeyName(40, "ToExcel.png");
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.xls";
            this.saveFileDialog1.Filter = "Archivos Excel |*.xls";
            // 
            // fAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 533);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.grpBoxFiltros);
            this.Name = "fAuditoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoría";
            this.Load += new System.EventHandler(this.fAuditoria_Load);
            this.grpBoxFiltros.ResumeLayout(false);
            this.grpBoxFiltros.PerformLayout();
            this.grpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdViewAuditorias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTabla;
        private System.Windows.Forms.GroupBox grpBoxFiltros;
        private System.Windows.Forms.ComboBox cmbBoxTabla;
        private System.Windows.Forms.ComboBox cmbBoxUsuarios;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.DataGridView dtGrdViewAuditorias;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.DateTimePicker dtPickFechaFinal;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.DateTimePicker dtPickFechaInicial;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.CheckBox chckBoxFecha;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}