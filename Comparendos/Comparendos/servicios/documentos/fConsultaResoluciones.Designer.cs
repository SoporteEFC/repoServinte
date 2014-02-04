namespace Comparendos.servicios.documentos
{
    partial class fConsultaResoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fConsultaResoluciones));
            this.grpBoxInfoInfrac = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpBoxRngoFecha = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chBoxFiltroFecha = new System.Windows.Forms.CheckBox();
            this.dateTPickFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dateTPickFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtInfractor = new System.Windows.Forms.TextBox();
            this.lblInfractor = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cmbBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.grpBxResoluciones = new System.Windows.Forms.GroupBox();
            this.dtGrWiewResoluciones = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnReImprimir = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.grpBoxInfoInfrac.SuspendLayout();
            this.grpBoxRngoFecha.SuspendLayout();
            this.grpBxResoluciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrWiewResoluciones)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxInfoInfrac
            // 
            this.grpBoxInfoInfrac.Controls.Add(this.btnConsultar);
            this.grpBoxInfoInfrac.Controls.Add(this.grpBoxRngoFecha);
            this.grpBoxInfoInfrac.Controls.Add(this.txtTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.txtInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDocumento);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbBoxTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDocumento);
            this.grpBoxInfoInfrac.Location = new System.Drawing.Point(12, 12);
            this.grpBoxInfoInfrac.Name = "grpBoxInfoInfrac";
            this.grpBoxInfoInfrac.Size = new System.Drawing.Size(966, 140);
            this.grpBoxInfoInfrac.TabIndex = 0;
            this.grpBoxInfoInfrac.TabStop = false;
            this.grpBoxInfoInfrac.Text = "Información del Infractor";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.ImageIndex = 10;
            this.btnConsultar.ImageList = this.imageList1;
            this.btnConsultar.Location = new System.Drawing.Point(501, 22);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(107, 24);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.TabStop = false;
            this.btnConsultar.Text = "Buscar &Infractor";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.button1_Click);
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
            this.imageList1.Images.SetKeyName(13, "Users.ico");
            this.imageList1.Images.SetKeyName(14, "User.ico");
            this.imageList1.Images.SetKeyName(15, "printer.gif");
            this.imageList1.Images.SetKeyName(16, "16 (Find).ico");
            this.imageList1.Images.SetKeyName(17, "16 (Flag blue).ico");
            this.imageList1.Images.SetKeyName(18, "16 (Folder).ico");
            this.imageList1.Images.SetKeyName(19, "16 (Lock off).ico");
            this.imageList1.Images.SetKeyName(20, "16 (Lock on).ico");
            this.imageList1.Images.SetKeyName(21, "16 (Print preview).ico");
            this.imageList1.Images.SetKeyName(22, "16 (Print).ico");
            this.imageList1.Images.SetKeyName(23, "16 (Save).ico");
            this.imageList1.Images.SetKeyName(24, "16 (User).ico");
            this.imageList1.Images.SetKeyName(25, "16 (Users).ico");
            this.imageList1.Images.SetKeyName(26, "16 (Contents).ico");
            this.imageList1.Images.SetKeyName(27, "16 (Db cancel).ico");
            this.imageList1.Images.SetKeyName(28, "16 (Db delete).ico");
            this.imageList1.Images.SetKeyName(29, "16 (Db edit).ico");
            this.imageList1.Images.SetKeyName(30, "16 (Db first).ico");
            this.imageList1.Images.SetKeyName(31, "16 (Db insert).ico");
            this.imageList1.Images.SetKeyName(32, "16 (Db last).ico");
            this.imageList1.Images.SetKeyName(33, "16 (Db next).ico");
            this.imageList1.Images.SetKeyName(34, "16 (Db post).ico");
            this.imageList1.Images.SetKeyName(35, "16 (Db previous).ico");
            this.imageList1.Images.SetKeyName(36, "16 (Db refresh).ico");
            this.imageList1.Images.SetKeyName(37, "16 (Execute).ico");
            this.imageList1.Images.SetKeyName(38, "16 (Exit).ico");
            this.imageList1.Images.SetKeyName(39, "16 (Fill up).ico");
            this.imageList1.Images.SetKeyName(40, "ToExcel.png");
            // 
            // grpBoxRngoFecha
            // 
            this.grpBoxRngoFecha.Controls.Add(this.button1);
            this.grpBoxRngoFecha.Controls.Add(this.chBoxFiltroFecha);
            this.grpBoxRngoFecha.Controls.Add(this.dateTPickFechaFinal);
            this.grpBoxRngoFecha.Controls.Add(this.dateTPickFechaInicial);
            this.grpBoxRngoFecha.Controls.Add(this.lblFechaInicial);
            this.grpBoxRngoFecha.Controls.Add(this.lblFechaFinal);
            this.grpBoxRngoFecha.Location = new System.Drawing.Point(6, 82);
            this.grpBoxRngoFecha.Name = "grpBoxRngoFecha";
            this.grpBoxRngoFecha.Size = new System.Drawing.Size(678, 52);
            this.grpBoxRngoFecha.TabIndex = 12;
            this.grpBoxRngoFecha.TabStop = false;
            this.grpBoxRngoFecha.Text = "Rango de Fechas";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 10;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(599, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 23);
            this.button1.TabIndex = 14;
            this.button1.TabStop = false;
            this.button1.Text = "&Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chBoxFiltroFecha
            // 
            this.chBoxFiltroFecha.AutoSize = true;
            this.chBoxFiltroFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBoxFiltroFecha.Location = new System.Drawing.Point(468, 21);
            this.chBoxFiltroFecha.Name = "chBoxFiltroFecha";
            this.chBoxFiltroFecha.Size = new System.Drawing.Size(116, 17);
            this.chBoxFiltroFecha.TabIndex = 5;
            this.chBoxFiltroFecha.Text = "Filtrar por fecha";
            this.chBoxFiltroFecha.UseVisualStyleBackColor = true;
            this.chBoxFiltroFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chBoxFiltroFecha_KeyPress);
            // 
            // dateTPickFechaFinal
            // 
            this.dateTPickFechaFinal.CustomFormat = "dd/MM/yyyy";
            this.dateTPickFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPickFechaFinal.Location = new System.Drawing.Point(302, 18);
            this.dateTPickFechaFinal.Name = "dateTPickFechaFinal";
            this.dateTPickFechaFinal.Size = new System.Drawing.Size(98, 20);
            this.dateTPickFechaFinal.TabIndex = 4;
            this.dateTPickFechaFinal.Value = new System.DateTime(2013, 3, 25, 0, 0, 0, 0);
            this.dateTPickFechaFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTPickFechaFinal_KeyPress);
            // 
            // dateTPickFechaInicial
            // 
            this.dateTPickFechaInicial.CustomFormat = "dd/MM/yyyy";
            this.dateTPickFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPickFechaInicial.Location = new System.Drawing.Point(96, 18);
            this.dateTPickFechaInicial.Name = "dateTPickFechaInicial";
            this.dateTPickFechaInicial.Size = new System.Drawing.Size(98, 20);
            this.dateTPickFechaInicial.TabIndex = 3;
            this.dateTPickFechaInicial.Value = new System.DateTime(2013, 3, 25, 0, 0, 0, 0);
            this.dateTPickFechaInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTPickFechaInicial_KeyPress);
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicial.Location = new System.Drawing.Point(6, 22);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(84, 13);
            this.lblFechaInicial.TabIndex = 10;
            this.lblFechaInicial.Text = "Fecha Inicial:";
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.AutoSize = true;
            this.lblFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFinal.Location = new System.Drawing.Point(219, 22);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(77, 13);
            this.lblFechaFinal.TabIndex = 11;
            this.lblFechaFinal.Text = "Fecha Final:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(836, 56);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(111, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(769, 59);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(460, 56);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(285, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(389, 59);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 13);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtInfractor
            // 
            this.txtInfractor.Location = new System.Drawing.Point(80, 56);
            this.txtInfractor.Name = "txtInfractor";
            this.txtInfractor.ReadOnly = true;
            this.txtInfractor.Size = new System.Drawing.Size(283, 20);
            this.txtInfractor.TabIndex = 5;
            // 
            // lblInfractor
            // 
            this.lblInfractor.AutoSize = true;
            this.lblInfractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfractor.Location = new System.Drawing.Point(15, 59);
            this.lblInfractor.Name = "lblInfractor";
            this.lblInfractor.Size = new System.Drawing.Size(59, 13);
            this.lblInfractor.TabIndex = 4;
            this.lblInfractor.Text = "Infractor:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(15, 26);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(104, 13);
            this.lblTipoDoc.TabIndex = 0;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(369, 23);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(117, 20);
            this.txtDocumento.TabIndex = 2;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // cmbBoxTipoDoc
            // 
            this.cmbBoxTipoDoc.DisplayMember = "DESCRIPCION";
            this.cmbBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTipoDoc.FormattingEnabled = true;
            this.cmbBoxTipoDoc.Location = new System.Drawing.Point(125, 23);
            this.cmbBoxTipoDoc.Name = "cmbBoxTipoDoc";
            this.cmbBoxTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxTipoDoc.TabIndex = 1;
            this.cmbBoxTipoDoc.ValueMember = "IDREPORTECOMPARENDO";
            this.cmbBoxTipoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxTipoDoc_KeyPress);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(268, 26);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(95, 13);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "No Documento:";
            // 
            // grpBxResoluciones
            // 
            this.grpBxResoluciones.Controls.Add(this.dtGrWiewResoluciones);
            this.grpBxResoluciones.Location = new System.Drawing.Point(12, 177);
            this.grpBxResoluciones.Name = "grpBxResoluciones";
            this.grpBxResoluciones.Size = new System.Drawing.Size(965, 296);
            this.grpBxResoluciones.TabIndex = 6;
            this.grpBxResoluciones.TabStop = false;
            this.grpBxResoluciones.Text = "Resoluciones Infractor";
            // 
            // dtGrWiewResoluciones
            // 
            this.dtGrWiewResoluciones.AllowUserToAddRows = false;
            this.dtGrWiewResoluciones.AllowUserToDeleteRows = false;
            this.dtGrWiewResoluciones.AllowUserToOrderColumns = true;
            this.dtGrWiewResoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrWiewResoluciones.Location = new System.Drawing.Point(6, 20);
            this.dtGrWiewResoluciones.MultiSelect = false;
            this.dtGrWiewResoluciones.Name = "dtGrWiewResoluciones";
            this.dtGrWiewResoluciones.ReadOnly = true;
            this.dtGrWiewResoluciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrWiewResoluciones.Size = new System.Drawing.Size(953, 270);
            this.dtGrWiewResoluciones.TabIndex = 0;
            this.dtGrWiewResoluciones.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtGrWiewResoluciones_CellMouseDoubleClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.xls";
            this.saveFileDialog1.Filter = "Archivos Excel |*.xls";
            // 
            // btnReImprimir
            // 
            this.btnReImprimir.ImageIndex = 22;
            this.btnReImprimir.ImageList = this.imageList1;
            this.btnReImprimir.Location = new System.Drawing.Point(617, 498);
            this.btnReImprimir.Name = "btnReImprimir";
            this.btnReImprimir.Size = new System.Drawing.Size(114, 31);
            this.btnReImprimir.TabIndex = 8;
            this.btnReImprimir.TabStop = false;
            this.btnReImprimir.Text = "&Reimprimir";
            this.btnReImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReImprimir.UseVisualStyleBackColor = true;
            this.btnReImprimir.Click += new System.EventHandler(this.btnReImprimir_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.ImageKey = "button_cancel.ico";
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(857, 498);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(114, 31);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnExport
            // 
            this.btnExport.ImageIndex = 40;
            this.btnExport.ImageList = this.imageList1;
            this.btnExport.Location = new System.Drawing.Point(737, 498);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(114, 31);
            this.btnExport.TabIndex = 6;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "Exportar a &Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // fConsultaResoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 541);
            this.Controls.Add(this.btnReImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grpBxResoluciones);
            this.Controls.Add(this.grpBoxInfoInfrac);
            this.Name = "fConsultaResoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Resoluciones";
            this.Load += new System.EventHandler(this.fConsultaResoluciones_Load);
            this.grpBoxInfoInfrac.ResumeLayout(false);
            this.grpBoxInfoInfrac.PerformLayout();
            this.grpBoxRngoFecha.ResumeLayout(false);
            this.grpBoxRngoFecha.PerformLayout();
            this.grpBxResoluciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrWiewResoluciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxInfoInfrac;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtInfractor;
        private System.Windows.Forms.Label lblInfractor;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.ComboBox cmbBoxTipoDoc;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.GroupBox grpBxResoluciones;
        private System.Windows.Forms.DataGridView dtGrWiewResoluciones;
        private System.Windows.Forms.GroupBox grpBoxRngoFecha;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.DateTimePicker dateTPickFechaFinal;
        private System.Windows.Forms.DateTimePicker dateTPickFechaInicial;
        private System.Windows.Forms.CheckBox chBoxFiltroFecha;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReImprimir;
        private System.Windows.Forms.Button button1;

    }
}