namespace Comparendos.servicios.documentos
{
    partial class ResolCambioCodigo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResolCambioCodigo));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtGrViewComparendos = new System.Windows.Forms.DataGridView();
            this.btnGenerarResolucion = new System.Windows.Forms.Button();
            this.grpNuevoCodigo = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtInfraccion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtNuevoCodigo = new System.Windows.Forms.TextBox();
            this.lblNuevoCodigo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.dtPickFechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPickFechaAudiencia = new System.Windows.Forms.DateTimePicker();
            this.lblFecAudi = new System.Windows.Forms.Label();
            this.lblNumResol = new System.Windows.Forms.Label();
            this.txtNumResol = new System.Windows.Forms.TextBox();
            this.grbInfoAdicional = new System.Windows.Forms.GroupBox();
            this.txtConsidJurid = new System.Windows.Forms.TextBox();
            this.lblConsidJurid = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.grpBoxInfoInfrac = new System.Windows.Forms.GroupBox();
            this.btn = new System.Windows.Forms.Button();
            this.cmbBoxPlantillas = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtInfractor = new System.Windows.Forms.TextBox();
            this.lblInfractor = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblTipoResol = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cmbBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewComparendos)).BeginInit();
            this.grpNuevoCodigo.SuspendLayout();
            this.grbInfoAdicional.SuspendLayout();
            this.grpBoxInfoInfrac.SuspendLayout();
            this.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(18, "bold.png");
            this.imageList1.Images.SetKeyName(19, "70.ico");
            // 
            // dtGrViewComparendos
            // 
            this.dtGrViewComparendos.AllowUserToAddRows = false;
            this.dtGrViewComparendos.AllowUserToDeleteRows = false;
            this.dtGrViewComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrViewComparendos.Location = new System.Drawing.Point(12, 118);
            this.dtGrViewComparendos.Name = "dtGrViewComparendos";
            this.dtGrViewComparendos.ReadOnly = true;
            this.dtGrViewComparendos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrViewComparendos.Size = new System.Drawing.Size(1093, 235);
            this.dtGrViewComparendos.TabIndex = 5;
            // 
            // btnGenerarResolucion
            // 
            this.btnGenerarResolucion.ImageIndex = 5;
            this.btnGenerarResolucion.ImageList = this.imageList1;
            this.btnGenerarResolucion.Location = new System.Drawing.Point(910, 597);
            this.btnGenerarResolucion.Name = "btnGenerarResolucion";
            this.btnGenerarResolucion.Size = new System.Drawing.Size(133, 37);
            this.btnGenerarResolucion.TabIndex = 12;
            this.btnGenerarResolucion.TabStop = false;
            this.btnGenerarResolucion.Text = "&Generar Resolución";
            this.btnGenerarResolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerarResolucion.UseVisualStyleBackColor = true;
            this.btnGenerarResolucion.Click += new System.EventHandler(this.btnGenerarResolucion_Click);
            // 
            // grpNuevoCodigo
            // 
            this.grpNuevoCodigo.Controls.Add(this.btnBuscar);
            this.grpNuevoCodigo.Controls.Add(this.txtInfraccion);
            this.grpNuevoCodigo.Controls.Add(this.lblDescripcion);
            this.grpNuevoCodigo.Controls.Add(this.txtNuevoCodigo);
            this.grpNuevoCodigo.Controls.Add(this.lblNuevoCodigo);
            this.grpNuevoCodigo.Location = new System.Drawing.Point(296, 496);
            this.grpNuevoCodigo.Name = "grpNuevoCodigo";
            this.grpNuevoCodigo.Size = new System.Drawing.Size(809, 46);
            this.grpNuevoCodigo.TabIndex = 16;
            this.grpNuevoCodigo.TabStop = false;
            this.grpNuevoCodigo.Text = "Nuevo Código";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageIndex = 10;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(737, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(64, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnBuscar, "Buscar Codigo Infracción");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtInfraccion
            // 
            this.txtInfraccion.Location = new System.Drawing.Point(228, 15);
            this.txtInfraccion.Name = "txtInfraccion";
            this.txtInfraccion.ReadOnly = true;
            this.txtInfraccion.Size = new System.Drawing.Size(503, 20);
            this.txtInfraccion.TabIndex = 33;
            this.txtInfraccion.TabStop = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(154, 18);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(68, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Infracción:";
            // 
            // txtNuevoCodigo
            // 
            this.txtNuevoCodigo.Location = new System.Drawing.Point(103, 15);
            this.txtNuevoCodigo.Name = "txtNuevoCodigo";
            this.txtNuevoCodigo.ReadOnly = true;
            this.txtNuevoCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtNuevoCodigo.TabIndex = 12;
            this.txtNuevoCodigo.TabStop = false;
            // 
            // lblNuevoCodigo
            // 
            this.lblNuevoCodigo.AutoSize = true;
            this.lblNuevoCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNuevoCodigo.Location = new System.Drawing.Point(6, 18);
            this.lblNuevoCodigo.Name = "lblNuevoCodigo";
            this.lblNuevoCodigo.Size = new System.Drawing.Size(91, 13);
            this.lblNuevoCodigo.TabIndex = 0;
            this.lblNuevoCodigo.Text = "Nuevo Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Presione Enter para verificar el número de resolución.";
            // 
            // dtPickFechaResolucion
            // 
            this.dtPickFechaResolucion.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaResolucion.Location = new System.Drawing.Point(137, 620);
            this.dtPickFechaResolucion.Name = "dtPickFechaResolucion";
            this.dtPickFechaResolucion.Size = new System.Drawing.Size(103, 20);
            this.dtPickFechaResolucion.TabIndex = 25;
            this.dtPickFechaResolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaResolucion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 624);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Fecha Resolución:";
            // 
            // dtPickFechaAudiencia
            // 
            this.dtPickFechaAudiencia.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaAudiencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaAudiencia.Location = new System.Drawing.Point(137, 594);
            this.dtPickFechaAudiencia.Name = "dtPickFechaAudiencia";
            this.dtPickFechaAudiencia.Size = new System.Drawing.Size(103, 20);
            this.dtPickFechaAudiencia.TabIndex = 24;
            this.dtPickFechaAudiencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaAudiencia_KeyPress);
            // 
            // lblFecAudi
            // 
            this.lblFecAudi.AutoSize = true;
            this.lblFecAudi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecAudi.Location = new System.Drawing.Point(27, 598);
            this.lblFecAudi.Name = "lblFecAudi";
            this.lblFecAudi.Size = new System.Drawing.Size(106, 13);
            this.lblFecAudi.TabIndex = 27;
            this.lblFecAudi.Text = "Fecha Audiencia:";
            // 
            // lblNumResol
            // 
            this.lblNumResol.AutoSize = true;
            this.lblNumResol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumResol.Location = new System.Drawing.Point(12, 572);
            this.lblNumResol.Name = "lblNumResol";
            this.lblNumResol.Size = new System.Drawing.Size(121, 13);
            this.lblNumResol.TabIndex = 26;
            this.lblNumResol.Text = "Número Resolución:";
            // 
            // txtNumResol
            // 
            this.txtNumResol.Location = new System.Drawing.Point(137, 568);
            this.txtNumResol.Name = "txtNumResol";
            this.txtNumResol.Size = new System.Drawing.Size(103, 20);
            this.txtNumResol.TabIndex = 23;
            this.txtNumResol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumResol_KeyDown);
            this.txtNumResol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumResol_KeyPress);
            // 
            // grbInfoAdicional
            // 
            this.grbInfoAdicional.Controls.Add(this.txtConsidJurid);
            this.grbInfoAdicional.Controls.Add(this.lblConsidJurid);
            this.grbInfoAdicional.Controls.Add(this.lblMotivo);
            this.grbInfoAdicional.Controls.Add(this.txtMotivo);
            this.grbInfoAdicional.Location = new System.Drawing.Point(12, 373);
            this.grbInfoAdicional.Name = "grbInfoAdicional";
            this.grbInfoAdicional.Size = new System.Drawing.Size(1093, 107);
            this.grbInfoAdicional.TabIndex = 30;
            this.grbInfoAdicional.TabStop = false;
            this.grbInfoAdicional.Text = "Info Adicional";
            // 
            // txtConsidJurid
            // 
            this.txtConsidJurid.Location = new System.Drawing.Point(139, 60);
            this.txtConsidJurid.Multiline = true;
            this.txtConsidJurid.Name = "txtConsidJurid";
            this.txtConsidJurid.Size = new System.Drawing.Size(919, 28);
            this.txtConsidJurid.TabIndex = 11;
            // 
            // lblConsidJurid
            // 
            this.lblConsidJurid.AutoSize = true;
            this.lblConsidJurid.Location = new System.Drawing.Point(15, 63);
            this.lblConsidJurid.Name = "lblConsidJurid";
            this.lblConsidJurid.Size = new System.Drawing.Size(118, 13);
            this.lblConsidJurid.TabIndex = 10;
            this.lblConsidJurid.Text = "Consideración Jurídica:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(91, 25);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 9;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(139, 22);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(919, 28);
            this.txtMotivo.TabIndex = 8;
            // 
            // grpBoxInfoInfrac
            // 
            this.grpBoxInfoInfrac.Controls.Add(this.btn);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbBoxPlantillas);
            this.grpBoxInfoInfrac.Controls.Add(this.txtTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.txtInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTipoResol);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDocumento);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbBoxTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDocumento);
            this.grpBoxInfoInfrac.Location = new System.Drawing.Point(12, 12);
            this.grpBoxInfoInfrac.Name = "grpBoxInfoInfrac";
            this.grpBoxInfoInfrac.Size = new System.Drawing.Size(1093, 100);
            this.grpBoxInfoInfrac.TabIndex = 31;
            this.grpBoxInfoInfrac.TabStop = false;
            this.grpBoxInfoInfrac.Text = "Información del Infractor";
            // 
            // btn
            // 
            this.btn.ImageIndex = 10;
            this.btn.ImageList = this.imageList1;
            this.btn.Location = new System.Drawing.Point(492, 21);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(30, 23);
            this.btn.TabIndex = 9;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // cmbBoxPlantillas
            // 
            this.cmbBoxPlantillas.DisplayMember = "NOMBRE";
            this.cmbBoxPlantillas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxPlantillas.FormattingEnabled = true;
            this.cmbBoxPlantillas.Location = new System.Drawing.Point(704, 23);
            this.cmbBoxPlantillas.Name = "cmbBoxPlantillas";
            this.cmbBoxPlantillas.Size = new System.Drawing.Size(243, 21);
            this.cmbBoxPlantillas.TabIndex = 3;
            this.cmbBoxPlantillas.ValueMember = "ID";
            this.cmbBoxPlantillas.SelectedIndexChanged += new System.EventHandler(this.cmbBoxPlantillas_SelectedIndexChanged);
            this.cmbBoxPlantillas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxPlantillas_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(836, 60);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(111, 20);
            this.txtTelefono.TabIndex = 0;
            this.txtTelefono.TabStop = false;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(769, 63);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(460, 60);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(285, 20);
            this.txtDireccion.TabIndex = 0;
            this.txtDireccion.TabStop = false;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(389, 63);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 13);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtInfractor
            // 
            this.txtInfractor.Enabled = false;
            this.txtInfractor.Location = new System.Drawing.Point(80, 60);
            this.txtInfractor.Name = "txtInfractor";
            this.txtInfractor.Size = new System.Drawing.Size(283, 20);
            this.txtInfractor.TabIndex = 0;
            this.txtInfractor.TabStop = false;
            // 
            // lblInfractor
            // 
            this.lblInfractor.AutoSize = true;
            this.lblInfractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfractor.Location = new System.Drawing.Point(15, 63);
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
            // lblTipoResol
            // 
            this.lblTipoResol.AutoSize = true;
            this.lblTipoResol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoResol.Location = new System.Drawing.Point(642, 26);
            this.lblTipoResol.Name = "lblTipoResol";
            this.lblTipoResol.Size = new System.Drawing.Size(56, 13);
            this.lblTipoResol.TabIndex = 8;
            this.lblTipoResol.Text = "Plantilla:";
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
            this.cmbBoxTipoDoc.TabStop = false;
            this.cmbBoxTipoDoc.ValueMember = "IDREPORTECOMPARENDO";
            this.cmbBoxTipoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxTipoDoc_KeyPress);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(268, 26);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(99, 13);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "No. Documento:";
            // 
            // ResolCambioCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 655);
            this.Controls.Add(this.grpBoxInfoInfrac);
            this.Controls.Add(this.grbInfoAdicional);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPickFechaResolucion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPickFechaAudiencia);
            this.Controls.Add(this.lblFecAudi);
            this.Controls.Add(this.lblNumResol);
            this.Controls.Add(this.txtNumResol);
            this.Controls.Add(this.grpNuevoCodigo);
            this.Controls.Add(this.btnGenerarResolucion);
            this.Controls.Add(this.dtGrViewComparendos);
            this.Name = "ResolCambioCodigo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Resolución Exoneracion por Cambio de Código";
            this.Load += new System.EventHandler(this.ResolImpoInfrac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewComparendos)).EndInit();
            this.grpNuevoCodigo.ResumeLayout(false);
            this.grpNuevoCodigo.PerformLayout();
            this.grbInfoAdicional.ResumeLayout(false);
            this.grbInfoAdicional.PerformLayout();
            this.grpBoxInfoInfrac.ResumeLayout(false);
            this.grpBoxInfoInfrac.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGrViewComparendos;
        private System.Windows.Forms.Button btnGenerarResolucion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox grpNuevoCodigo;
        private System.Windows.Forms.TextBox txtInfraccion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtNuevoCodigo;
        private System.Windows.Forms.Label lblNuevoCodigo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPickFechaResolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPickFechaAudiencia;
        private System.Windows.Forms.Label lblFecAudi;
        private System.Windows.Forms.Label lblNumResol;
        private System.Windows.Forms.TextBox txtNumResol;
        private System.Windows.Forms.GroupBox grbInfoAdicional;
        private System.Windows.Forms.TextBox txtConsidJurid;
        private System.Windows.Forms.Label lblConsidJurid;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.GroupBox grpBoxInfoInfrac;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox cmbBoxPlantillas;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtInfractor;
        private System.Windows.Forms.Label lblInfractor;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblTipoResol;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.ComboBox cmbBoxTipoDoc;
        private System.Windows.Forms.Label lblDocumento;
    }
}