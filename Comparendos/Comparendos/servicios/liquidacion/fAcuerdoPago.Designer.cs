namespace Comparendos.servicios.liquidacion
{
    partial class fAcuerdoPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAcuerdoPago));
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblFechaCompr = new System.Windows.Forms.Label();
            this.dtpFechaCompr = new System.Windows.Forms.DateTimePicker();
            this.lblCedulaDeud = new System.Windows.Forms.Label();
            this.txtCeduDeu = new System.Windows.Forms.TextBox();
            this.lblDeudor = new System.Windows.Forms.Label();
            this.txtDeudor = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelef = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombCodeu = new System.Windows.Forms.TextBox();
            this.lblNombCodeu = new System.Windows.Forms.Label();
            this.txtCedCodeu = new System.Windows.Forms.TextBox();
            this.lblCedCodeu = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.infoFinanc = new System.Windows.Forms.GroupBox();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.txtInicial = new System.Windows.Forms.TextBox();
            this.lblInicial = new System.Windows.Forms.Label();
            this.txtTotalDeu = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtCuotas = new System.Windows.Forms.TextBox();
            this.lblNroCuotas = new System.Windows.Forms.Label();
            this.lblComparendos = new System.Windows.Forms.Label();
            this.txtComparendos = new System.Windows.Forms.TextBox();
            this.dtGrdDetalle = new System.Windows.Forms.DataGridView();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.cmbBoxTipoDocumento = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnImprAcuePag = new System.Windows.Forms.Button();
            this.btnImpFinanc = new System.Windows.Forms.Button();
            this.btnCrearAcuerdo = new System.Windows.Forms.Button();
            this.btnBuscarAcuerdo = new System.Windows.Forms.Button();
            this.pnlDireccion = new System.Windows.Forms.GroupBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.lblValLiqu = new System.Windows.Forms.Label();
            this.txtValLiqui = new System.Windows.Forms.TextBox();
            this.btnAExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRefinanciar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.infoFinanc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdDetalle)).BeginInit();
            this.pnlDireccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(21, 19);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(54, 13);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(77, 16);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // lblFechaCompr
            // 
            this.lblFechaCompr.AutoSize = true;
            this.lblFechaCompr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCompr.Location = new System.Drawing.Point(199, 19);
            this.lblFechaCompr.Name = "lblFechaCompr";
            this.lblFechaCompr.Size = new System.Drawing.Size(117, 13);
            this.lblFechaCompr.TabIndex = 2;
            this.lblFechaCompr.Text = "Fecha Compromiso:";
            // 
            // dtpFechaCompr
            // 
            this.dtpFechaCompr.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaCompr.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaCompr.Location = new System.Drawing.Point(322, 16);
            this.dtpFechaCompr.Name = "dtpFechaCompr";
            this.dtpFechaCompr.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaCompr.TabIndex = 2;
            this.dtpFechaCompr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaCompr_KeyPress);
            // 
            // lblCedulaDeud
            // 
            this.lblCedulaDeud.AutoSize = true;
            this.lblCedulaDeud.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedulaDeud.Location = new System.Drawing.Point(319, 52);
            this.lblCedulaDeud.Name = "lblCedulaDeud";
            this.lblCedulaDeud.Size = new System.Drawing.Size(50, 13);
            this.lblCedulaDeud.TabIndex = 37;
            this.lblCedulaDeud.Text = "Cédula:";
            // 
            // txtCeduDeu
            // 
            this.txtCeduDeu.Location = new System.Drawing.Point(377, 49);
            this.txtCeduDeu.Name = "txtCeduDeu";
            this.txtCeduDeu.Size = new System.Drawing.Size(98, 20);
            this.txtCeduDeu.TabIndex = 4;
            this.txtCeduDeu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCeduDeu_KeyDown);
            // 
            // lblDeudor
            // 
            this.lblDeudor.AutoSize = true;
            this.lblDeudor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeudor.Location = new System.Drawing.Point(21, 88);
            this.lblDeudor.Name = "lblDeudor";
            this.lblDeudor.Size = new System.Drawing.Size(56, 13);
            this.lblDeudor.TabIndex = 39;
            this.lblDeudor.Text = "Deudor: ";
            // 
            // txtDeudor
            // 
            this.txtDeudor.Location = new System.Drawing.Point(83, 85);
            this.txtDeudor.Name = "txtDeudor";
            this.txtDeudor.Size = new System.Drawing.Size(238, 20);
            this.txtDeudor.TabIndex = 40;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(348, 88);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 13);
            this.lblDireccion.TabIndex = 41;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(419, 85);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 20);
            this.txtDireccion.TabIndex = 42;
            // 
            // lblTelef
            // 
            this.lblTelef.AutoSize = true;
            this.lblTelef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelef.Location = new System.Drawing.Point(21, 135);
            this.lblTelef.Name = "lblTelef";
            this.lblTelef.Size = new System.Drawing.Size(61, 13);
            this.lblTelef.TabIndex = 43;
            this.lblTelef.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(88, 132);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(111, 20);
            this.txtTelefono.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNombCodeu);
            this.groupBox1.Controls.Add(this.lblNombCodeu);
            this.groupBox1.Controls.Add(this.txtCedCodeu);
            this.groupBox1.Controls.Add(this.lblCedCodeu);
            this.groupBox1.Location = new System.Drawing.Point(246, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 49);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Codeudor";
            // 
            // txtNombCodeu
            // 
            this.txtNombCodeu.Location = new System.Drawing.Point(299, 20);
            this.txtNombCodeu.Name = "txtNombCodeu";
            this.txtNombCodeu.Size = new System.Drawing.Size(238, 20);
            this.txtNombCodeu.TabIndex = 49;
            // 
            // lblNombCodeu
            // 
            this.lblNombCodeu.AutoSize = true;
            this.lblNombCodeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombCodeu.Location = new System.Drawing.Point(235, 23);
            this.lblNombCodeu.Name = "lblNombCodeu";
            this.lblNombCodeu.Size = new System.Drawing.Size(58, 13);
            this.lblNombCodeu.TabIndex = 48;
            this.lblNombCodeu.Text = "Nombre: ";
            // 
            // txtCedCodeu
            // 
            this.txtCedCodeu.Location = new System.Drawing.Point(73, 20);
            this.txtCedCodeu.Name = "txtCedCodeu";
            this.txtCedCodeu.Size = new System.Drawing.Size(143, 20);
            this.txtCedCodeu.TabIndex = 47;
            // 
            // lblCedCodeu
            // 
            this.lblCedCodeu.AutoSize = true;
            this.lblCedCodeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedCodeu.Location = new System.Drawing.Point(17, 23);
            this.lblCedCodeu.Name = "lblCedCodeu";
            this.lblCedCodeu.Size = new System.Drawing.Size(50, 13);
            this.lblCedCodeu.TabIndex = 46;
            this.lblCedCodeu.Text = "Cédula:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(21, 175);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(78, 13);
            this.lblDescripcion.TabIndex = 46;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(66, 202);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(212, 53);
            this.txtDescripcion.TabIndex = 47;
            this.txtDescripcion.Text = "Incapacidad Financiera";
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(300, 175);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(38, 13);
            this.lblNota.TabIndex = 48;
            this.lblNota.Text = "Nota:";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(327, 202);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(212, 53);
            this.txtNota.TabIndex = 49;
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(592, 202);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(212, 53);
            this.txtConcepto.TabIndex = 51;
            this.txtConcepto.Text = "Multa Transito";
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConcepto.Location = new System.Drawing.Point(565, 175);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(61, 13);
            this.lblConcepto.TabIndex = 50;
            this.lblConcepto.Text = "Concepto";
            // 
            // infoFinanc
            // 
            this.infoFinanc.Controls.Add(this.txtSaldo);
            this.infoFinanc.Controls.Add(this.lblSaldo);
            this.infoFinanc.Controls.Add(this.txtInicial);
            this.infoFinanc.Controls.Add(this.lblInicial);
            this.infoFinanc.Controls.Add(this.txtTotalDeu);
            this.infoFinanc.Controls.Add(this.lblTotal);
            this.infoFinanc.Controls.Add(this.txtCuotas);
            this.infoFinanc.Controls.Add(this.lblNroCuotas);
            this.infoFinanc.Location = new System.Drawing.Point(24, 313);
            this.infoFinanc.Name = "infoFinanc";
            this.infoFinanc.Size = new System.Drawing.Size(438, 95);
            this.infoFinanc.TabIndex = 52;
            this.infoFinanc.TabStop = false;
            this.infoFinanc.Text = "Información Financiación";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Location = new System.Drawing.Point(279, 62);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(116, 20);
            this.txtSaldo.TabIndex = 7;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(229, 65);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(43, 13);
            this.lblSaldo.TabIndex = 6;
            this.lblSaldo.Text = "Saldo:";
            // 
            // txtInicial
            // 
            this.txtInicial.Location = new System.Drawing.Point(64, 62);
            this.txtInicial.Name = "txtInicial";
            this.txtInicial.Size = new System.Drawing.Size(116, 20);
            this.txtInicial.TabIndex = 5;
            // 
            // lblInicial
            // 
            this.lblInicial.AutoSize = true;
            this.lblInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicial.Location = new System.Drawing.Point(13, 65);
            this.lblInicial.Name = "lblInicial";
            this.lblInicial.Size = new System.Drawing.Size(45, 13);
            this.lblInicial.TabIndex = 4;
            this.lblInicial.Text = "Inicial:";
            // 
            // txtTotalDeu
            // 
            this.txtTotalDeu.BackColor = System.Drawing.Color.Black;
            this.txtTotalDeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDeu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtTotalDeu.Location = new System.Drawing.Point(99, 27);
            this.txtTotalDeu.Name = "txtTotalDeu";
            this.txtTotalDeu.Size = new System.Drawing.Size(100, 20);
            this.txtTotalDeu.TabIndex = 3;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total Deuda:";
            // 
            // txtCuotas
            // 
            this.txtCuotas.Location = new System.Drawing.Point(279, 27);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(45, 20);
            this.txtCuotas.TabIndex = 1;
            // 
            // lblNroCuotas
            // 
            this.lblNroCuotas.AutoSize = true;
            this.lblNroCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroCuotas.Location = new System.Drawing.Point(222, 30);
            this.lblNroCuotas.Name = "lblNroCuotas";
            this.lblNroCuotas.Size = new System.Drawing.Size(50, 13);
            this.lblNroCuotas.TabIndex = 0;
            this.lblNroCuotas.Text = "Cuotas:";
            // 
            // lblComparendos
            // 
            this.lblComparendos.AutoSize = true;
            this.lblComparendos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComparendos.Location = new System.Drawing.Point(21, 279);
            this.lblComparendos.Name = "lblComparendos";
            this.lblComparendos.Size = new System.Drawing.Size(87, 13);
            this.lblComparendos.TabIndex = 53;
            this.lblComparendos.Text = "Comparendos:";
            // 
            // txtComparendos
            // 
            this.txtComparendos.Location = new System.Drawing.Point(114, 276);
            this.txtComparendos.Name = "txtComparendos";
            this.txtComparendos.Size = new System.Drawing.Size(773, 20);
            this.txtComparendos.TabIndex = 54;
            // 
            // dtGrdDetalle
            // 
            this.dtGrdDetalle.AllowUserToAddRows = false;
            this.dtGrdDetalle.AllowUserToDeleteRows = false;
            this.dtGrdDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtGrdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdDetalle.Location = new System.Drawing.Point(24, 423);
            this.dtGrdDetalle.Name = "dtGrdDetalle";
            this.dtGrdDetalle.ReadOnly = true;
            this.dtGrdDetalle.Size = new System.Drawing.Size(438, 135);
            this.dtGrdDetalle.TabIndex = 55;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(21, 53);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(104, 13);
            this.lblTipoDoc.TabIndex = 56;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // cmbBoxTipoDocumento
            // 
            this.cmbBoxTipoDocumento.DisplayMember = "DESCRIPCION";
            this.cmbBoxTipoDocumento.FormattingEnabled = true;
            this.cmbBoxTipoDocumento.Location = new System.Drawing.Point(134, 49);
            this.cmbBoxTipoDocumento.Name = "cmbBoxTipoDocumento";
            this.cmbBoxTipoDocumento.Size = new System.Drawing.Size(162, 21);
            this.cmbBoxTipoDocumento.TabIndex = 3;
            this.cmbBoxTipoDocumento.ValueMember = "IDCONSULTASIMIT";
            this.cmbBoxTipoDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxTipoDocumento_KeyPress);
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
            this.imageList1.Images.SetKeyName(18, "39.ico");
            this.imageList1.Images.SetKeyName(19, "EXCEL 1.png");
            // 
            // btnGuardar
            // 
            this.btnGuardar.ImageIndex = 16;
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(663, 473);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 28);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnImprAcuePag
            // 
            this.btnImprAcuePag.ImageIndex = 18;
            this.btnImprAcuePag.ImageList = this.imageList1;
            this.btnImprAcuePag.Location = new System.Drawing.Point(517, 530);
            this.btnImprAcuePag.Name = "btnImprAcuePag";
            this.btnImprAcuePag.Size = new System.Drawing.Size(169, 28);
            this.btnImprAcuePag.TabIndex = 8;
            this.btnImprAcuePag.TabStop = false;
            this.btnImprAcuePag.Text = "Imprimir &Acuerdo de Pago";
            this.btnImprAcuePag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprAcuePag.UseVisualStyleBackColor = true;
            this.btnImprAcuePag.Click += new System.EventHandler(this.btnImprAcuePag_Click);
            // 
            // btnImpFinanc
            // 
            this.btnImpFinanc.ImageIndex = 18;
            this.btnImpFinanc.ImageList = this.imageList1;
            this.btnImpFinanc.Location = new System.Drawing.Point(704, 530);
            this.btnImpFinanc.Name = "btnImpFinanc";
            this.btnImpFinanc.Size = new System.Drawing.Size(170, 28);
            this.btnImpFinanc.TabIndex = 9;
            this.btnImpFinanc.TabStop = false;
            this.btnImpFinanc.Text = "&Imprimir Cuota";
            this.btnImpFinanc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImpFinanc.UseVisualStyleBackColor = true;
            this.btnImpFinanc.Click += new System.EventHandler(this.btnImpFinanc_Click);
            // 
            // btnCrearAcuerdo
            // 
            this.btnCrearAcuerdo.ImageIndex = 8;
            this.btnCrearAcuerdo.ImageList = this.imageList1;
            this.btnCrearAcuerdo.Location = new System.Drawing.Point(524, 47);
            this.btnCrearAcuerdo.Name = "btnCrearAcuerdo";
            this.btnCrearAcuerdo.Size = new System.Drawing.Size(102, 23);
            this.btnCrearAcuerdo.TabIndex = 5;
            this.btnCrearAcuerdo.Text = "&Crear Acuerdo";
            this.btnCrearAcuerdo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrearAcuerdo.UseVisualStyleBackColor = true;
            this.btnCrearAcuerdo.Click += new System.EventHandler(this.btnCrearAcuerdo_Click);
            // 
            // btnBuscarAcuerdo
            // 
            this.btnBuscarAcuerdo.ImageIndex = 10;
            this.btnBuscarAcuerdo.ImageList = this.imageList1;
            this.btnBuscarAcuerdo.Location = new System.Drawing.Point(647, 47);
            this.btnBuscarAcuerdo.Name = "btnBuscarAcuerdo";
            this.btnBuscarAcuerdo.Size = new System.Drawing.Size(117, 23);
            this.btnBuscarAcuerdo.TabIndex = 62;
            this.btnBuscarAcuerdo.Text = "Buscar Acuerdos";
            this.btnBuscarAcuerdo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarAcuerdo.UseVisualStyleBackColor = true;
            this.btnBuscarAcuerdo.Click += new System.EventHandler(this.btnBuscarAcuerdo_Click);
            // 
            // pnlDireccion
            // 
            this.pnlDireccion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDireccion.Controls.Add(this.btnLast);
            this.pnlDireccion.Controls.Add(this.btnNext);
            this.pnlDireccion.Controls.Add(this.btnPrevious);
            this.pnlDireccion.Controls.Add(this.btnFirst);
            this.pnlDireccion.Location = new System.Drawing.Point(632, 33);
            this.pnlDireccion.Name = "pnlDireccion";
            this.pnlDireccion.Size = new System.Drawing.Size(139, 43);
            this.pnlDireccion.TabIndex = 63;
            this.pnlDireccion.TabStop = false;
            // 
            // btnLast
            // 
            this.btnLast.ImageIndex = 5;
            this.btnLast.ImageList = this.imageList1;
            this.btnLast.Location = new System.Drawing.Point(99, 11);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 28);
            this.btnLast.TabIndex = 14;
            this.btnLast.TabStop = false;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageIndex = 6;
            this.btnNext.ImageList = this.imageList1;
            this.btnNext.Location = new System.Drawing.Point(68, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 28);
            this.btnNext.TabIndex = 13;
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ImageIndex = 7;
            this.btnPrevious.ImageList = this.imageList1;
            this.btnPrevious.Location = new System.Drawing.Point(37, 11);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 28);
            this.btnPrevious.TabIndex = 12;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageIndex = 4;
            this.btnFirst.ImageList = this.imageList1;
            this.btnFirst.Location = new System.Drawing.Point(6, 11);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 28);
            this.btnFirst.TabIndex = 11;
            this.btnFirst.TabStop = false;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // lblValLiqu
            // 
            this.lblValLiqu.AutoSize = true;
            this.lblValLiqu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValLiqu.Location = new System.Drawing.Point(490, 353);
            this.lblValLiqu.Name = "lblValLiqu";
            this.lblValLiqu.Size = new System.Drawing.Size(189, 13);
            this.lblValLiqu.TabIndex = 64;
            this.lblValLiqu.Text = "Valor liquidación (sin Intereses):";
            // 
            // txtValLiqui
            // 
            this.txtValLiqui.BackColor = System.Drawing.Color.Black;
            this.txtValLiqui.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValLiqui.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtValLiqui.Location = new System.Drawing.Point(692, 350);
            this.txtValLiqui.Name = "txtValLiqui";
            this.txtValLiqui.Size = new System.Drawing.Size(100, 20);
            this.txtValLiqui.TabIndex = 65;
            // 
            // btnAExcel
            // 
            this.btnAExcel.ImageIndex = 19;
            this.btnAExcel.ImageList = this.imageList1;
            this.btnAExcel.Location = new System.Drawing.Point(750, 82);
            this.btnAExcel.Name = "btnAExcel";
            this.btnAExcel.Size = new System.Drawing.Size(151, 23);
            this.btnAExcel.TabIndex = 10;
            this.btnAExcel.TabStop = false;
            this.btnAExcel.Text = "&Exportar listado a Excel";
            this.btnAExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAExcel.UseVisualStyleBackColor = true;
            this.btnAExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(493, 423);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(38, 25);
            this.dataGridView1.TabIndex = 67;
            // 
            // btnRefinanciar
            // 
            this.btnRefinanciar.ImageIndex = 2;
            this.btnRefinanciar.ImageList = this.imageList1;
            this.btnRefinanciar.Location = new System.Drawing.Point(517, 473);
            this.btnRefinanciar.Name = "btnRefinanciar";
            this.btnRefinanciar.Size = new System.Drawing.Size(102, 27);
            this.btnRefinanciar.TabIndex = 6;
            this.btnRefinanciar.TabStop = false;
            this.btnRefinanciar.Text = "&Refinanciar";
            this.btnRefinanciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefinanciar.UseVisualStyleBackColor = true;
            this.btnRefinanciar.Click += new System.EventHandler(this.btnRefinanciar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageKey = "button_cancel.ico";
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(799, 473);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 28);
            this.btnSalir.TabIndex = 68;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // fAcuerdoPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 609);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRefinanciar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAExcel);
            this.Controls.Add(this.txtValLiqui);
            this.Controls.Add(this.lblValLiqu);
            this.Controls.Add(this.pnlDireccion);
            this.Controls.Add(this.btnBuscarAcuerdo);
            this.Controls.Add(this.btnCrearAcuerdo);
            this.Controls.Add(this.btnImpFinanc);
            this.Controls.Add(this.btnImprAcuePag);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbBoxTipoDocumento);
            this.Controls.Add(this.lblTipoDoc);
            this.Controls.Add(this.dtGrdDetalle);
            this.Controls.Add(this.txtComparendos);
            this.Controls.Add(this.lblComparendos);
            this.Controls.Add(this.infoFinanc);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.lblConcepto);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblTelef);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDeudor);
            this.Controls.Add(this.lblDeudor);
            this.Controls.Add(this.txtCeduDeu);
            this.Controls.Add(this.lblCedulaDeud);
            this.Controls.Add(this.dtpFechaCompr);
            this.Controls.Add(this.lblFechaCompr);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblNumero);
            this.Name = "fAcuerdoPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acuerdos de Pago";
            this.Load += new System.EventHandler(this.fAcuerdoPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.infoFinanc.ResumeLayout(false);
            this.infoFinanc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdDetalle)).EndInit();
            this.pnlDireccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblFechaCompr;
        private System.Windows.Forms.DateTimePicker dtpFechaCompr;
        private System.Windows.Forms.Label lblCedulaDeud;
        private System.Windows.Forms.TextBox txtCeduDeu;
        private System.Windows.Forms.Label lblDeudor;
        private System.Windows.Forms.TextBox txtDeudor;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelef;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCedCodeu;
        private System.Windows.Forms.TextBox txtCedCodeu;
        private System.Windows.Forms.TextBox txtNombCodeu;
        private System.Windows.Forms.Label lblNombCodeu;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.GroupBox infoFinanc;
        private System.Windows.Forms.Label lblNroCuotas;
        private System.Windows.Forms.Label lblInicial;
        private System.Windows.Forms.TextBox txtTotalDeu;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtCuotas;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.TextBox txtInicial;
        private System.Windows.Forms.Label lblComparendos;
        private System.Windows.Forms.TextBox txtComparendos;
        private System.Windows.Forms.DataGridView dtGrdDetalle;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.ComboBox cmbBoxTipoDocumento;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnImprAcuePag;
        private System.Windows.Forms.Button btnImpFinanc;
        private System.Windows.Forms.Button btnCrearAcuerdo;
        private System.Windows.Forms.Button btnBuscarAcuerdo;
        private System.Windows.Forms.GroupBox pnlDireccion;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Label lblValLiqu;
        private System.Windows.Forms.TextBox txtValLiqui;
        private System.Windows.Forms.Button btnAExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefinanciar;
        private System.Windows.Forms.Button btnSalir;
    }
}