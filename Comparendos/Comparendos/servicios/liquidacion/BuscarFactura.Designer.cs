namespace Comparendos.servicios.liquidacion
{
    partial class BuscarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarFactura));
            this.tblRecibos = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.chkIdentifiacion = new System.Windows.Forms.CheckBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.chkNroRecibo = new System.Windows.Forms.CheckBox();
            this.chkNroComparendo = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtNumeroRecibo = new System.Windows.Forms.TextBox();
            this.labNumeroRecibo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroComparendo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadRegistros = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnEliminarLiquidacion = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnReimprimir = new System.Windows.Forms.Button();
            this.btnAnularPago = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tblComparendos = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtValorFactura = new System.Windows.Forms.TextBox();
            this.labValorFactura = new System.Windows.Forms.Label();
            this.txtRecibido = new System.Windows.Forms.TextBox();
            this.labRecibido = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.labSaldo = new System.Windows.Forms.Label();
            this.txtTotalDeuda = new System.Windows.Forms.TextBox();
            this.labTotalDeuda = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.labTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.labDireccion = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.labApellido = new System.Windows.Forms.Label();
            this.txtIdentificacionRes = new System.Windows.Forms.TextBox();
            this.labIdenfificacion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblRecibos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblRecibos
            // 
            this.tblRecibos.AllowUserToAddRows = false;
            this.tblRecibos.AllowUserToDeleteRows = false;
            this.tblRecibos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblRecibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblRecibos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRecibos.Location = new System.Drawing.Point(3, 3);
            this.tblRecibos.Name = "tblRecibos";
            this.tblRecibos.ReadOnly = true;
            this.tblRecibos.Size = new System.Drawing.Size(843, 113);
            this.tblRecibos.TabIndex = 0;
            this.tblRecibos.SelectionChanged += new System.EventHandler(this.tblRecibos_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFecha);
            this.groupBox2.Controls.Add(this.chkIdentifiacion);
            this.groupBox2.Controls.Add(this.chkEstado);
            this.groupBox2.Controls.Add(this.chkNroRecibo);
            this.groupBox2.Controls.Add(this.chkNroComparendo);
            this.groupBox2.Location = new System.Drawing.Point(636, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 124);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterios de búsqueda";
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(166, 42);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(56, 17);
            this.chkFecha.TabIndex = 13;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // chkIdentifiacion
            // 
            this.chkIdentifiacion.AutoSize = true;
            this.chkIdentifiacion.Location = new System.Drawing.Point(6, 42);
            this.chkIdentifiacion.Name = "chkIdentifiacion";
            this.chkIdentifiacion.Size = new System.Drawing.Size(65, 17);
            this.chkIdentifiacion.TabIndex = 11;
            this.chkIdentifiacion.Text = "Infractor";
            this.chkIdentifiacion.UseVisualStyleBackColor = true;
            this.chkIdentifiacion.CheckedChanged += new System.EventHandler(this.chkIdentifiacion_CheckedChanged);
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(95, 42);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 12;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            this.chkEstado.CheckedChanged += new System.EventHandler(this.chkEstado_CheckedChanged);
            // 
            // chkNroRecibo
            // 
            this.chkNroRecibo.AutoSize = true;
            this.chkNroRecibo.Location = new System.Drawing.Point(6, 19);
            this.chkNroRecibo.Name = "chkNroRecibo";
            this.chkNroRecibo.Size = new System.Drawing.Size(83, 17);
            this.chkNroRecibo.TabIndex = 9;
            this.chkNroRecibo.Text = "Nro. Recibo";
            this.chkNroRecibo.UseVisualStyleBackColor = true;
            this.chkNroRecibo.CheckedChanged += new System.EventHandler(this.chkNroRecibo_CheckedChanged);
            // 
            // chkNroComparendo
            // 
            this.chkNroComparendo.AutoSize = true;
            this.chkNroComparendo.Location = new System.Drawing.Point(95, 19);
            this.chkNroComparendo.Name = "chkNroComparendo";
            this.chkNroComparendo.Size = new System.Drawing.Size(109, 17);
            this.chkNroComparendo.TabIndex = 10;
            this.chkNroComparendo.Text = "Nro. Comparendo";
            this.chkNroComparendo.UseVisualStyleBackColor = true;
            this.chkNroComparendo.CheckedChanged += new System.EventHandler(this.chkNroComparendo_CheckedChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DisplayMember = "DESCRIPCION";
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(9, 92);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(114, 21);
            this.cmbEstado.TabIndex = 5;
            this.cmbEstado.ValueMember = "ID_ESTADO";
            this.cmbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbEstado_KeyDown);
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.DisplayMember = "DESCRIPCION";
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(333, 42);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(107, 21);
            this.cmbTipoDocumento.TabIndex = 3;
            this.cmbTipoDocumento.ValueMember = "ID_DOCCOMP";
            this.cmbTipoDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoDocumento_KeyPress);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(222, 70);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(65, 13);
            this.lblFechaFin.TabIndex = 45;
            this.lblFechaFin.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFinal.Location = new System.Drawing.Point(225, 91);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(83, 20);
            this.dtpFechaFinal.TabIndex = 7;
            this.dtpFechaFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFechaFinal_KeyDown);
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.AutoSize = true;
            this.lblFechaInicial.Location = new System.Drawing.Point(129, 70);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(70, 13);
            this.lblFechaInicial.TabIndex = 43;
            this.lblFechaInicial.Text = "Fecha Inicial:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicial.Location = new System.Drawing.Point(129, 91);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(86, 20);
            this.dtpFechaInicial.TabIndex = 6;
            this.dtpFechaInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaInicial_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageKey = "magnify.png";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(516, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 26);
            this.btnBuscar.TabIndex = 21;
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
            this.imageList1.Images.SetKeyName(0, "applications-system.png");
            this.imageList1.Images.SetKeyName(1, "audio-volume-high.png");
            this.imageList1.Images.SetKeyName(2, "audio-x-generic.png");
            this.imageList1.Images.SetKeyName(3, "button_ok16.png");
            this.imageList1.Images.SetKeyName(4, "computer.png");
            this.imageList1.Images.SetKeyName(5, "delete16.png");
            this.imageList1.Images.SetKeyName(6, "dialog-error.png");
            this.imageList1.Images.SetKeyName(7, "dialog-information.png");
            this.imageList1.Images.SetKeyName(8, "dialog-warning.png");
            this.imageList1.Images.SetKeyName(9, "dollar.png");
            this.imageList1.Images.SetKeyName(10, "emblem-important.png");
            this.imageList1.Images.SetKeyName(11, "emblem-readonly.png");
            this.imageList1.Images.SetKeyName(12, "emblem-system.png");
            this.imageList1.Images.SetKeyName(13, "emblem-unreadable.png");
            this.imageList1.Images.SetKeyName(14, "folder.png");
            this.imageList1.Images.SetKeyName(15, "font-x-generic.png");
            this.imageList1.Images.SetKeyName(16, "image-x-generic.png");
            this.imageList1.Images.SetKeyName(17, "magnify.png");
            this.imageList1.Images.SetKeyName(18, "mail-attachment.png");
            this.imageList1.Images.SetKeyName(19, "media-floppy.png");
            this.imageList1.Images.SetKeyName(20, "network-idle.png");
            this.imageList1.Images.SetKeyName(21, "package-x-generic.png");
            this.imageList1.Images.SetKeyName(22, "Plus__Orange16.png");
            this.imageList1.Images.SetKeyName(23, "preferences-system.png");
            this.imageList1.Images.SetKeyName(24, "search.png");
            this.imageList1.Images.SetKeyName(25, "software-update-urgent.png");
            this.imageList1.Images.SetKeyName(26, "start-here.png");
            this.imageList1.Images.SetKeyName(27, "text-html.png");
            this.imageList1.Images.SetKeyName(28, "text-x-generic.png");
            this.imageList1.Images.SetKeyName(29, "video-display.png");
            this.imageList1.Images.SetKeyName(30, "x-office-calendar.png");
            this.imageList1.Images.SetKeyName(31, "system-log-out.png");
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ImageKey = "view-refresh.png";
            this.btnLimpiar.ImageList = this.imageList2;
            this.btnLimpiar.Location = new System.Drawing.Point(419, 86);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(91, 26);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.TabStop = false;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
            this.imageList2.Images.SetKeyName(13, "remove.gif");
            this.imageList2.Images.SetKeyName(14, "stop.gif");
            this.imageList2.Images.SetKeyName(15, "editdelete.gif");
            this.imageList2.Images.SetKeyName(16, "save.bmp");
            this.imageList2.Images.SetKeyName(17, "edit16.bmp");
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtIdentificacion.Location = new System.Drawing.Point(446, 42);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(134, 21);
            this.txtIdentificacion.TabIndex = 4;
            this.txtIdentificacion.TabStop = false;
            this.txtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacion_KeyDown);
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            // 
            // txtNumeroRecibo
            // 
            this.txtNumeroRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNumeroRecibo.Location = new System.Drawing.Point(9, 42);
            this.txtNumeroRecibo.Name = "txtNumeroRecibo";
            this.txtNumeroRecibo.Size = new System.Drawing.Size(148, 21);
            this.txtNumeroRecibo.TabIndex = 1;
            this.txtNumeroRecibo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroRecibo_KeyDown);
            this.txtNumeroRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroRecibo_KeyPress);
            // 
            // labNumeroRecibo
            // 
            this.labNumeroRecibo.Location = new System.Drawing.Point(6, 16);
            this.labNumeroRecibo.Name = "labNumeroRecibo";
            this.labNumeroRecibo.Size = new System.Drawing.Size(151, 23);
            this.labNumeroRecibo.TabIndex = 37;
            this.labNumeroRecibo.Text = "Número recibo:";
            this.labNumeroRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFechaInicial);
            this.groupBox1.Controls.Add(this.lblFechaInicial);
            this.groupBox1.Controls.Add(this.txtNroComparendo);
            this.groupBox1.Controls.Add(this.lblFechaFin);
            this.groupBox1.Controls.Add(this.labNumeroRecibo);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Controls.Add(this.txtNumeroRecibo);
            this.groupBox1.Controls.Add(this.cmbTipoDocumento);
            this.groupBox1.Controls.Add(this.txtIdentificacion);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Valores de búsqueda";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 23);
            this.label3.TabIndex = 51;
            this.label3.Text = "Estado:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(333, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 23);
            this.label2.TabIndex = 50;
            this.label2.Text = "Identificación:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(163, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 48;
            this.label1.Text = "Número comparendo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNroComparendo
            // 
            this.txtNroComparendo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNroComparendo.Location = new System.Drawing.Point(163, 42);
            this.txtNroComparendo.Name = "txtNroComparendo";
            this.txtNroComparendo.Size = new System.Drawing.Size(164, 21);
            this.txtNroComparendo.TabIndex = 2;
            this.txtNroComparendo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroComparendo_KeyDown);
            this.txtNroComparendo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroComparendo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Cantidad de facturas:";
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadRegistros.Location = new System.Drawing.Point(781, 92);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.ReadOnly = true;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(59, 20);
            this.txtCantidadRegistros.TabIndex = 40;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnCerrar);
            this.groupBox3.Controls.Add(this.btnEliminarLiquidacion);
            this.groupBox3.Controls.Add(this.btnReimprimir);
            this.groupBox3.Controls.Add(this.btnAnularPago);
            this.groupBox3.Controls.Add(this.btnPagar);
            this.groupBox3.Location = new System.Drawing.Point(320, 421);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(547, 60);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acciones";
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageKey = "delete16.png";
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(6, 20);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(83, 26);
            this.btnCerrar.TabIndex = 51;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Text = "&Salir";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminarLiquidacion
            // 
            this.btnEliminarLiquidacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarLiquidacion.ImageIndex = 9;
            this.btnEliminarLiquidacion.ImageList = this.imageList3;
            this.btnEliminarLiquidacion.Location = new System.Drawing.Point(248, 16);
            this.btnEliminarLiquidacion.Name = "btnEliminarLiquidacion";
            this.btnEliminarLiquidacion.Size = new System.Drawing.Size(96, 35);
            this.btnEliminarLiquidacion.TabIndex = 53;
            this.btnEliminarLiquidacion.TabStop = false;
            this.btnEliminarLiquidacion.Text = "&Eliminar liquidación";
            this.btnEliminarLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarLiquidacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarLiquidacion.UseVisualStyleBackColor = true;
            this.btnEliminarLiquidacion.Click += new System.EventHandler(this.btnEliminarLiquidacion_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "system-log-out.png");
            this.imageList3.Images.SetKeyName(1, "system-search.png");
            this.imageList3.Images.SetKeyName(2, "view-refresh.png");
            this.imageList3.Images.SetKeyName(3, "edit-find.png");
            this.imageList3.Images.SetKeyName(4, "go-first.png");
            this.imageList3.Images.SetKeyName(5, "go-last.png");
            this.imageList3.Images.SetKeyName(6, "go-next.png");
            this.imageList3.Images.SetKeyName(7, "go-previous.png");
            this.imageList3.Images.SetKeyName(8, "list-add.png");
            this.imageList3.Images.SetKeyName(9, "list-remove.png");
            this.imageList3.Images.SetKeyName(10, "search.ico");
            this.imageList3.Images.SetKeyName(11, "button_cancel.ico");
            this.imageList3.Images.SetKeyName(12, "button_ok.ico");
            this.imageList3.Images.SetKeyName(13, "remove.gif");
            this.imageList3.Images.SetKeyName(14, "stop.gif");
            this.imageList3.Images.SetKeyName(15, "editdelete.gif");
            this.imageList3.Images.SetKeyName(16, "save.bmp");
            this.imageList3.Images.SetKeyName(17, "edit16.bmp");
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.ImageKey = "media-floppy.png";
            this.btnReimprimir.ImageList = this.imageList1;
            this.btnReimprimir.Location = new System.Drawing.Point(115, 16);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(127, 35);
            this.btnReimprimir.TabIndex = 52;
            this.btnReimprimir.TabStop = false;
            this.btnReimprimir.Text = "&Reimprimir factura";
            this.btnReimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // btnAnularPago
            // 
            this.btnAnularPago.ImageIndex = 15;
            this.btnAnularPago.ImageList = this.imageList3;
            this.btnAnularPago.Location = new System.Drawing.Point(350, 16);
            this.btnAnularPago.Name = "btnAnularPago";
            this.btnAnularPago.Size = new System.Drawing.Size(103, 35);
            this.btnAnularPago.TabIndex = 54;
            this.btnAnularPago.TabStop = false;
            this.btnAnularPago.Text = "&Anular pago";
            this.btnAnularPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnularPago.UseVisualStyleBackColor = true;
            this.btnAnularPago.Click += new System.EventHandler(this.btnAnularPago_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.ImageKey = "button_ok16.png";
            this.btnPagar.ImageList = this.imageList1;
            this.btnPagar.Location = new System.Drawing.Point(460, 15);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(81, 35);
            this.btnPagar.TabIndex = 55;
            this.btnPagar.TabStop = false;
            this.btnPagar.Text = "&Pagar";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 270);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(857, 145);
            this.tabControl1.TabIndex = 52;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tblRecibos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(849, 119);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recibos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tblComparendos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(849, 119);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Comparendos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tblComparendos
            // 
            this.tblComparendos.AllowUserToAddRows = false;
            this.tblComparendos.AllowUserToDeleteRows = false;
            this.tblComparendos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblComparendos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tblComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblComparendos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblComparendos.Location = new System.Drawing.Point(3, 3);
            this.tblComparendos.Name = "tblComparendos";
            this.tblComparendos.ReadOnly = true;
            this.tblComparendos.Size = new System.Drawing.Size(843, 113);
            this.tblComparendos.TabIndex = 1;
            this.tblComparendos.SelectionChanged += new System.EventHandler(this.tblComparendos_SelectionChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtValorFactura);
            this.groupBox4.Controls.Add(this.labValorFactura);
            this.groupBox4.Controls.Add(this.txtRecibido);
            this.groupBox4.Controls.Add(this.txtCantidadRegistros);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.labRecibido);
            this.groupBox4.Controls.Add(this.txtSaldo);
            this.groupBox4.Controls.Add(this.labSaldo);
            this.groupBox4.Controls.Add(this.txtTotalDeuda);
            this.groupBox4.Controls.Add(this.labTotalDeuda);
            this.groupBox4.Controls.Add(this.txtTelefono);
            this.groupBox4.Controls.Add(this.labTelefono);
            this.groupBox4.Controls.Add(this.txtDireccion);
            this.groupBox4.Controls.Add(this.labDireccion);
            this.groupBox4.Controls.Add(this.txtApellido);
            this.groupBox4.Controls.Add(this.labApellido);
            this.groupBox4.Controls.Add(this.txtIdentificacionRes);
            this.groupBox4.Controls.Add(this.labIdenfificacion);
            this.groupBox4.Controls.Add(this.txtNombre);
            this.groupBox4.Controls.Add(this.labNombre);
            this.groupBox4.Location = new System.Drawing.Point(12, 142);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(857, 122);
            this.groupBox4.TabIndex = 53;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Infractor";
            // 
            // txtValorFactura
            // 
            this.txtValorFactura.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtValorFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.txtValorFactura.Location = new System.Drawing.Point(426, 91);
            this.txtValorFactura.Name = "txtValorFactura";
            this.txtValorFactura.ReadOnly = true;
            this.txtValorFactura.Size = new System.Drawing.Size(134, 21);
            this.txtValorFactura.TabIndex = 39;
            this.txtValorFactura.TabStop = false;
            // 
            // labValorFactura
            // 
            this.labValorFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labValorFactura.Location = new System.Drawing.Point(426, 65);
            this.labValorFactura.Name = "labValorFactura";
            this.labValorFactura.Size = new System.Drawing.Size(134, 23);
            this.labValorFactura.TabIndex = 48;
            this.labValorFactura.Text = "Valor factura ($):";
            this.labValorFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRecibido
            // 
            this.txtRecibido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtRecibido.Location = new System.Drawing.Point(286, 92);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.ReadOnly = true;
            this.txtRecibido.Size = new System.Drawing.Size(134, 21);
            this.txtRecibido.TabIndex = 38;
            this.txtRecibido.TabStop = false;
            // 
            // labRecibido
            // 
            this.labRecibido.Location = new System.Drawing.Point(286, 66);
            this.labRecibido.Name = "labRecibido";
            this.labRecibido.Size = new System.Drawing.Size(134, 23);
            this.labRecibido.TabIndex = 46;
            this.labRecibido.Text = "Recibido ($):";
            this.labRecibido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtSaldo.Location = new System.Drawing.Point(146, 92);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(134, 21);
            this.txtSaldo.TabIndex = 37;
            this.txtSaldo.TabStop = false;
            // 
            // labSaldo
            // 
            this.labSaldo.Location = new System.Drawing.Point(146, 66);
            this.labSaldo.Name = "labSaldo";
            this.labSaldo.Size = new System.Drawing.Size(134, 23);
            this.labSaldo.TabIndex = 45;
            this.labSaldo.Text = "Saldo ($):";
            this.labSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalDeuda
            // 
            this.txtTotalDeuda.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTotalDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtTotalDeuda.Location = new System.Drawing.Point(6, 92);
            this.txtTotalDeuda.Name = "txtTotalDeuda";
            this.txtTotalDeuda.ReadOnly = true;
            this.txtTotalDeuda.Size = new System.Drawing.Size(134, 21);
            this.txtTotalDeuda.TabIndex = 36;
            this.txtTotalDeuda.TabStop = false;
            // 
            // labTotalDeuda
            // 
            this.labTotalDeuda.Location = new System.Drawing.Point(3, 66);
            this.labTotalDeuda.Name = "labTotalDeuda";
            this.labTotalDeuda.Size = new System.Drawing.Size(137, 23);
            this.labTotalDeuda.TabIndex = 44;
            this.labTotalDeuda.Text = "Total deuda ($):";
            this.labTotalDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtTelefono.Location = new System.Drawing.Point(566, 42);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(134, 21);
            this.txtTelefono.TabIndex = 35;
            this.txtTelefono.TabStop = false;
            // 
            // labTelefono
            // 
            this.labTelefono.Location = new System.Drawing.Point(566, 16);
            this.labTelefono.Name = "labTelefono";
            this.labTelefono.Size = new System.Drawing.Size(134, 23);
            this.labTelefono.TabIndex = 43;
            this.labTelefono.Text = "Teléfono:";
            this.labTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDireccion.Location = new System.Drawing.Point(426, 42);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(134, 21);
            this.txtDireccion.TabIndex = 34;
            this.txtDireccion.TabStop = false;
            // 
            // labDireccion
            // 
            this.labDireccion.Location = new System.Drawing.Point(423, 16);
            this.labDireccion.Name = "labDireccion";
            this.labDireccion.Size = new System.Drawing.Size(137, 23);
            this.labDireccion.TabIndex = 39;
            this.labDireccion.Text = "Dirección:";
            this.labDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtApellido.Location = new System.Drawing.Point(146, 42);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(134, 21);
            this.txtApellido.TabIndex = 32;
            this.txtApellido.TabStop = false;
            // 
            // labApellido
            // 
            this.labApellido.Location = new System.Drawing.Point(149, 16);
            this.labApellido.Name = "labApellido";
            this.labApellido.Size = new System.Drawing.Size(123, 23);
            this.labApellido.TabIndex = 37;
            this.labApellido.Text = "Apellido:";
            this.labApellido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIdentificacionRes
            // 
            this.txtIdentificacionRes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtIdentificacionRes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentificacionRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtIdentificacionRes.Location = new System.Drawing.Point(286, 42);
            this.txtIdentificacionRes.Name = "txtIdentificacionRes";
            this.txtIdentificacionRes.ReadOnly = true;
            this.txtIdentificacionRes.Size = new System.Drawing.Size(134, 21);
            this.txtIdentificacionRes.TabIndex = 33;
            this.txtIdentificacionRes.TabStop = false;
            // 
            // labIdenfificacion
            // 
            this.labIdenfificacion.Location = new System.Drawing.Point(289, 16);
            this.labIdenfificacion.Name = "labIdenfificacion";
            this.labIdenfificacion.Size = new System.Drawing.Size(123, 23);
            this.labIdenfificacion.TabIndex = 34;
            this.labIdenfificacion.Text = "Identificación:";
            this.labIdenfificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNombre.Location = new System.Drawing.Point(6, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(134, 21);
            this.txtNombre.TabIndex = 31;
            this.txtNombre.TabStop = false;
            // 
            // labNombre
            // 
            this.labNombre.Location = new System.Drawing.Point(6, 16);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(137, 23);
            this.labNombre.TabIndex = 31;
            this.labNombre.Text = "Nombre:";
            this.labNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BuscarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 493);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "BuscarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar factura";
            ((System.ComponentModel.ISupportInitialize)(this.tblRecibos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tblRecibos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.CheckBox chkIdentifiacion;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.CheckBox chkNroRecibo;
        private System.Windows.Forms.CheckBox chkNroComparendo;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtNumeroRecibo;
        private System.Windows.Forms.Label labNumeroRecibo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroComparendo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidadRegistros;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEliminarLiquidacion;
        private System.Windows.Forms.Button btnReimprimir;
        private System.Windows.Forms.Button btnAnularPago;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView tblComparendos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtValorFactura;
        private System.Windows.Forms.Label labValorFactura;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label labRecibido;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label labSaldo;
        private System.Windows.Forms.TextBox txtTotalDeuda;
        private System.Windows.Forms.Label labTotalDeuda;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label labTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label labDireccion;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label labApellido;
        private System.Windows.Forms.TextBox txtIdentificacionRes;
        private System.Windows.Forms.Label labIdenfificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
    }
}