namespace Comparendos
{
    partial class administradortarifas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(administradortarifas));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVigencias = new System.Windows.Forms.ComboBox();
            this.cabezera = new System.Windows.Forms.GroupBox();
            this.grdTarifas = new System.Windows.Forms.DataGridView();
            this.btnSearchTarifa = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnAgregarVigencia = new System.Windows.Forms.Button();
            this.btnQuittarifa = new System.Windows.Forms.Button();
            this.btnAddtarifa = new System.Windows.Forms.Button();
            this.grbDatosTarifa = new System.Windows.Forms.GroupBox();
            this.btnGuardarTarifa = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnEditTarifa = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelTarifa = new System.Windows.Forms.Button();
            this.chkActiva = new System.Windows.Forms.CheckBox();
            this.chkMultipleliquidacion = new System.Windows.Forms.CheckBox();
            this.txtCondiciones = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.cmbTramite = new System.Windows.Forms.ComboBox();
            this.cmbTipoTarifa = new System.Windows.Forms.ComboBox();
            this.chkMultiplegrupo = new System.Windows.Forms.CheckBox();
            this.txtTarifa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grbConceptos = new System.Windows.Forms.GroupBox();
            this.btnEditConceptoForm = new System.Windows.Forms.Button();
            this.grdConceptos = new System.Windows.Forms.DataGridView();
            this.btnQuitconcepto = new System.Windows.Forms.Button();
            this.btnAddconcepto = new System.Windows.Forms.Button();
            this.txtCalculo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbItemLiquidacion = new System.Windows.Forms.ComboBox();
            this.btnCancelconcepto = new System.Windows.Forms.Button();
            this.cmbTipoConcepto = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.btnOkconcepto = new System.Windows.Forms.Button();
            this.btnEditconcepto = new System.Windows.Forms.Button();
            this.chkConceptdescontable = new System.Windows.Forms.CheckBox();
            this.grbDatosConcepto = new System.Windows.Forms.GroupBox();
            this.txtDatobase = new System.Windows.Forms.TextBox();
            this.txtFactor = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cabezera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarifas)).BeginInit();
            this.grbDatosTarifa.SuspendLayout();
            this.grbConceptos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).BeginInit();
            this.grbDatosConcepto.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busca:";
            // 
            // cmbVigencias
            // 
            this.cmbVigencias.DisplayMember = "LTV_DESCRIPCION";
            this.cmbVigencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVigencias.FormattingEnabled = true;
            this.cmbVigencias.Location = new System.Drawing.Point(52, 18);
            this.cmbVigencias.Name = "cmbVigencias";
            this.cmbVigencias.Size = new System.Drawing.Size(246, 21);
            this.cmbVigencias.TabIndex = 1;
            this.cmbVigencias.ValueMember = "LTV_ID";
            this.cmbVigencias.SelectedIndexChanged += new System.EventHandler(this.cmbVigencias_SelectedIndexChanged);
            this.cmbVigencias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listatarifastram_KeyPress);
            // 
            // cabezera
            // 
            this.cabezera.Controls.Add(this.grdTarifas);
            this.cabezera.Controls.Add(this.btnSearchTarifa);
            this.cabezera.Controls.Add(this.btnsalir);
            this.cabezera.Controls.Add(this.btnAgregarVigencia);
            this.cabezera.Controls.Add(this.btnQuittarifa);
            this.cabezera.Controls.Add(this.btnAddtarifa);
            this.cabezera.Controls.Add(this.cmbVigencias);
            this.cabezera.Controls.Add(this.label1);
            this.cabezera.Location = new System.Drawing.Point(12, 3);
            this.cabezera.Name = "cabezera";
            this.cabezera.Size = new System.Drawing.Size(895, 161);
            this.cabezera.TabIndex = 0;
            this.cabezera.TabStop = false;
            this.cabezera.Text = "[Tarifas]";
            // 
            // grdTarifas
            // 
            this.grdTarifas.AllowUserToAddRows = false;
            this.grdTarifas.AllowUserToDeleteRows = false;
            this.grdTarifas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTarifas.Location = new System.Drawing.Point(8, 50);
            this.grdTarifas.Name = "grdTarifas";
            this.grdTarifas.ReadOnly = true;
            this.grdTarifas.Size = new System.Drawing.Size(880, 99);
            this.grdTarifas.TabIndex = 0;
            this.grdTarifas.SelectionChanged += new System.EventHandler(this.grdTarifas_SelectionChanged);
            // 
            // btnSearchTarifa
            // 
            this.btnSearchTarifa.ImageKey = "search.ico";
            this.btnSearchTarifa.ImageList = this.imageList1;
            this.btnSearchTarifa.Location = new System.Drawing.Point(783, 14);
            this.btnSearchTarifa.Name = "btnSearchTarifa";
            this.btnSearchTarifa.Size = new System.Drawing.Size(32, 27);
            this.btnSearchTarifa.TabIndex = 36;
            this.btnSearchTarifa.TabStop = false;
            this.btnSearchTarifa.UseVisualStyleBackColor = true;
            this.btnSearchTarifa.Click += new System.EventHandler(this.btnSearchTarifa_Click);
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
            // 
            // btnsalir
            // 
            this.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsalir.ImageKey = "button_cancel.ico";
            this.btnsalir.ImageList = this.imageList1;
            this.btnsalir.Location = new System.Drawing.Point(488, 13);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(60, 29);
            this.btnsalir.TabIndex = 35;
            this.btnsalir.TabStop = false;
            this.btnsalir.Text = "&Salir";
            this.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnAgregarVigencia
            // 
            this.btnAgregarVigencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarVigencia.ImageIndex = 8;
            this.btnAgregarVigencia.ImageList = this.imageList1;
            this.btnAgregarVigencia.Location = new System.Drawing.Point(307, 13);
            this.btnAgregarVigencia.Name = "btnAgregarVigencia";
            this.btnAgregarVigencia.Size = new System.Drawing.Size(175, 29);
            this.btnAgregarVigencia.TabIndex = 30;
            this.btnAgregarVigencia.TabStop = false;
            this.btnAgregarVigencia.Text = "&Agregar ó Modificar Vigencias";
            this.btnAgregarVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarVigencia.UseVisualStyleBackColor = true;
            this.btnAgregarVigencia.Click += new System.EventHandler(this.btnAgregarVigencia_Click);
            // 
            // btnQuittarifa
            // 
            this.btnQuittarifa.ImageIndex = 9;
            this.btnQuittarifa.ImageList = this.imageList1;
            this.btnQuittarifa.Location = new System.Drawing.Point(853, 14);
            this.btnQuittarifa.Name = "btnQuittarifa";
            this.btnQuittarifa.Size = new System.Drawing.Size(32, 27);
            this.btnQuittarifa.TabIndex = 28;
            this.btnQuittarifa.TabStop = false;
            this.toolTip1.SetToolTip(this.btnQuittarifa, "Eliminar Tarifa a la Vigencia");
            this.btnQuittarifa.UseVisualStyleBackColor = true;
            this.btnQuittarifa.Click += new System.EventHandler(this.btnQuittarifa_Click);
            // 
            // btnAddtarifa
            // 
            this.btnAddtarifa.ImageIndex = 8;
            this.btnAddtarifa.ImageList = this.imageList1;
            this.btnAddtarifa.Location = new System.Drawing.Point(818, 14);
            this.btnAddtarifa.Name = "btnAddtarifa";
            this.btnAddtarifa.Size = new System.Drawing.Size(32, 27);
            this.btnAddtarifa.TabIndex = 27;
            this.btnAddtarifa.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAddtarifa, "Adicionar Tarifa a la Vigencia");
            this.btnAddtarifa.UseVisualStyleBackColor = true;
            this.btnAddtarifa.Click += new System.EventHandler(this.btnAddtarifa_Click);
            // 
            // grbDatosTarifa
            // 
            this.grbDatosTarifa.Controls.Add(this.btnGuardarTarifa);
            this.grbDatosTarifa.Controls.Add(this.label14);
            this.grbDatosTarifa.Controls.Add(this.btnEditTarifa);
            this.grbDatosTarifa.Controls.Add(this.btnCancelTarifa);
            this.grbDatosTarifa.Controls.Add(this.chkActiva);
            this.grbDatosTarifa.Controls.Add(this.chkMultipleliquidacion);
            this.grbDatosTarifa.Controls.Add(this.txtCondiciones);
            this.grbDatosTarifa.Controls.Add(this.txtDescripcion);
            this.grbDatosTarifa.Controls.Add(this.cmbTramite);
            this.grbDatosTarifa.Controls.Add(this.cmbTipoTarifa);
            this.grbDatosTarifa.Controls.Add(this.chkMultiplegrupo);
            this.grbDatosTarifa.Controls.Add(this.txtTarifa);
            this.grbDatosTarifa.Controls.Add(this.label7);
            this.grbDatosTarifa.Controls.Add(this.label6);
            this.grbDatosTarifa.Controls.Add(this.label4);
            this.grbDatosTarifa.Controls.Add(this.label3);
            this.grbDatosTarifa.Location = new System.Drawing.Point(12, 170);
            this.grbDatosTarifa.Name = "grbDatosTarifa";
            this.grbDatosTarifa.Size = new System.Drawing.Size(385, 407);
            this.grbDatosTarifa.TabIndex = 2;
            this.grbDatosTarifa.TabStop = false;
            this.grbDatosTarifa.Text = "[Datos Tarifa]";
            // 
            // btnGuardarTarifa
            // 
            this.btnGuardarTarifa.ImageIndex = 12;
            this.btnGuardarTarifa.ImageList = this.imageList1;
            this.btnGuardarTarifa.Location = new System.Drawing.Point(312, 12);
            this.btnGuardarTarifa.Name = "btnGuardarTarifa";
            this.btnGuardarTarifa.Size = new System.Drawing.Size(32, 27);
            this.btnGuardarTarifa.TabIndex = 36;
            this.btnGuardarTarifa.TabStop = false;
            this.toolTip1.SetToolTip(this.btnGuardarTarifa, "Guardar");
            this.btnGuardarTarifa.UseVisualStyleBackColor = true;
            this.btnGuardarTarifa.Click += new System.EventHandler(this.btnGuardarTarifa_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 191);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Condiciones";
            // 
            // btnEditTarifa
            // 
            this.btnEditTarifa.ImageIndex = 15;
            this.btnEditTarifa.ImageList = this.imageList2;
            this.btnEditTarifa.Location = new System.Drawing.Point(277, 12);
            this.btnEditTarifa.Name = "btnEditTarifa";
            this.btnEditTarifa.Size = new System.Drawing.Size(32, 27);
            this.btnEditTarifa.TabIndex = 33;
            this.btnEditTarifa.TabStop = false;
            this.btnEditTarifa.UseVisualStyleBackColor = true;
            this.btnEditTarifa.Click += new System.EventHandler(this.btnEditTarifa_Click);
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
            this.imageList2.Images.SetKeyName(13, "car.ico");
            this.imageList2.Images.SetKeyName(14, "user.png");
            this.imageList2.Images.SetKeyName(15, "edit.png");
            this.imageList2.Images.SetKeyName(16, "filesave.ico");
            this.imageList2.Images.SetKeyName(17, "star.png");
            this.imageList2.Images.SetKeyName(18, "busy.png");
            // 
            // btnCancelTarifa
            // 
            this.btnCancelTarifa.ImageIndex = 11;
            this.btnCancelTarifa.ImageList = this.imageList1;
            this.btnCancelTarifa.Location = new System.Drawing.Point(346, 12);
            this.btnCancelTarifa.Name = "btnCancelTarifa";
            this.btnCancelTarifa.Size = new System.Drawing.Size(32, 27);
            this.btnCancelTarifa.TabIndex = 31;
            this.btnCancelTarifa.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCancelTarifa, "Cancelar");
            this.btnCancelTarifa.UseVisualStyleBackColor = true;
            this.btnCancelTarifa.Click += new System.EventHandler(this.btnCancelTarifa_Click);
            // 
            // chkActiva
            // 
            this.chkActiva.AutoSize = true;
            this.chkActiva.Location = new System.Drawing.Point(280, 157);
            this.chkActiva.Name = "chkActiva";
            this.chkActiva.Size = new System.Drawing.Size(56, 17);
            this.chkActiva.TabIndex = 10;
            this.chkActiva.Text = "Activa";
            this.chkActiva.UseVisualStyleBackColor = true;
            this.chkActiva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.activa_KeyPress);
            // 
            // chkMultipleliquidacion
            // 
            this.chkMultipleliquidacion.AutoSize = true;
            this.chkMultipleliquidacion.Location = new System.Drawing.Point(137, 157);
            this.chkMultipleliquidacion.Name = "chkMultipleliquidacion";
            this.chkMultipleliquidacion.Size = new System.Drawing.Size(119, 17);
            this.chkMultipleliquidacion.TabIndex = 9;
            this.chkMultipleliquidacion.Text = "Multiple Liquidación";
            this.chkMultipleliquidacion.UseVisualStyleBackColor = true;
            this.chkMultipleliquidacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.multipleliquidacion_KeyPress);
            // 
            // txtCondiciones
            // 
            this.txtCondiciones.Location = new System.Drawing.Point(9, 209);
            this.txtCondiciones.Multiline = true;
            this.txtCondiciones.Name = "txtCondiciones";
            this.txtCondiciones.Size = new System.Drawing.Size(369, 167);
            this.txtCondiciones.TabIndex = 11;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(102, 115);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(234, 20);
            this.txtDescripcion.TabIndex = 7;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descripcion_KeyPress);
            // 
            // cmbTramite
            // 
            this.cmbTramite.DisplayMember = "DESC_TRAMITECONTRAVENCIONAL";
            this.cmbTramite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTramite.FormattingEnabled = true;
            this.cmbTramite.Location = new System.Drawing.Point(102, 88);
            this.cmbTramite.Name = "cmbTramite";
            this.cmbTramite.Size = new System.Drawing.Size(234, 21);
            this.cmbTramite.TabIndex = 6;
            this.cmbTramite.ValueMember = "IDTRAMITE_CONTRAVENCIONAL";
            this.cmbTramite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tramiteas_KeyPress);
            // 
            // cmbTipoTarifa
            // 
            this.cmbTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoTarifa.FormattingEnabled = true;
            this.cmbTipoTarifa.Location = new System.Drawing.Point(102, 34);
            this.cmbTipoTarifa.Name = "cmbTipoTarifa";
            this.cmbTipoTarifa.Size = new System.Drawing.Size(142, 21);
            this.cmbTipoTarifa.TabIndex = 3;
            this.cmbTipoTarifa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipo_KeyPress);
            // 
            // chkMultiplegrupo
            // 
            this.chkMultiplegrupo.AutoSize = true;
            this.chkMultiplegrupo.Location = new System.Drawing.Point(9, 157);
            this.chkMultiplegrupo.Name = "chkMultiplegrupo";
            this.chkMultiplegrupo.Size = new System.Drawing.Size(101, 17);
            this.chkMultiplegrupo.TabIndex = 8;
            this.chkMultiplegrupo.Text = "Mult. Group. Liq";
            this.chkMultiplegrupo.UseVisualStyleBackColor = true;
            this.chkMultiplegrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.multiplegrupo_KeyPress);
            // 
            // txtTarifa
            // 
            this.txtTarifa.Location = new System.Drawing.Point(102, 61);
            this.txtTarifa.Name = "txtTarifa";
            this.txtTarifa.Size = new System.Drawing.Size(234, 20);
            this.txtTarifa.TabIndex = 4;
            this.txtTarifa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tarifa_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Descripción";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Trámite";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tarifa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo";
            // 
            // grbConceptos
            // 
            this.grbConceptos.Controls.Add(this.grdConceptos);
            this.grbConceptos.Location = new System.Drawing.Point(413, 197);
            this.grbConceptos.Name = "grbConceptos";
            this.grbConceptos.Size = new System.Drawing.Size(494, 135);
            this.grbConceptos.TabIndex = 12;
            this.grbConceptos.TabStop = false;
            this.grbConceptos.Text = "[Conceptos]";
            // 
            // btnEditConceptoForm
            // 
            this.btnEditConceptoForm.ImageIndex = 15;
            this.btnEditConceptoForm.ImageList = this.imageList2;
            this.btnEditConceptoForm.Location = new System.Drawing.Point(795, 171);
            this.btnEditConceptoForm.Name = "btnEditConceptoForm";
            this.btnEditConceptoForm.Size = new System.Drawing.Size(32, 27);
            this.btnEditConceptoForm.TabIndex = 30;
            this.btnEditConceptoForm.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEditConceptoForm, "Editar Concepto");
            this.btnEditConceptoForm.UseVisualStyleBackColor = true;
            this.btnEditConceptoForm.Click += new System.EventHandler(this.btnEditConceptoForm_Click);
            // 
            // grdConceptos
            // 
            this.grdConceptos.AllowUserToAddRows = false;
            this.grdConceptos.AllowUserToDeleteRows = false;
            this.grdConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConceptos.Location = new System.Drawing.Point(6, 19);
            this.grdConceptos.Name = "grdConceptos";
            this.grdConceptos.ReadOnly = true;
            this.grdConceptos.Size = new System.Drawing.Size(478, 110);
            this.grdConceptos.TabIndex = 0;
            this.grdConceptos.SelectionChanged += new System.EventHandler(this.grdConceptos_SelectionChanged);
            // 
            // btnQuitconcepto
            // 
            this.btnQuitconcepto.ImageIndex = 9;
            this.btnQuitconcepto.ImageList = this.imageList1;
            this.btnQuitconcepto.Location = new System.Drawing.Point(865, 171);
            this.btnQuitconcepto.Name = "btnQuitconcepto";
            this.btnQuitconcepto.Size = new System.Drawing.Size(32, 27);
            this.btnQuitconcepto.TabIndex = 30;
            this.btnQuitconcepto.TabStop = false;
            this.toolTip1.SetToolTip(this.btnQuitconcepto, "Eliminar Concepto");
            this.btnQuitconcepto.UseVisualStyleBackColor = true;
            this.btnQuitconcepto.Click += new System.EventHandler(this.btnQuitconcepto_Click);
            // 
            // btnAddconcepto
            // 
            this.btnAddconcepto.ImageIndex = 8;
            this.btnAddconcepto.ImageList = this.imageList1;
            this.btnAddconcepto.Location = new System.Drawing.Point(830, 171);
            this.btnAddconcepto.Name = "btnAddconcepto";
            this.btnAddconcepto.Size = new System.Drawing.Size(32, 27);
            this.btnAddconcepto.TabIndex = 29;
            this.btnAddconcepto.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAddconcepto, "Agregar Concepto");
            this.btnAddconcepto.UseVisualStyleBackColor = true;
            this.btnAddconcepto.Click += new System.EventHandler(this.btnAddconcepto_Click);
            // 
            // txtCalculo
            // 
            this.txtCalculo.Location = new System.Drawing.Point(238, 79);
            this.txtCalculo.Multiline = true;
            this.txtCalculo.Name = "txtCalculo";
            this.txtCalculo.Size = new System.Drawing.Size(247, 144);
            this.txtCalculo.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Cálculo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ítem Liquidación";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Tipo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Valor";
            // 
            // cmbItemLiquidacion
            // 
            this.cmbItemLiquidacion.DisplayMember = "DESCRIPCION";
            this.cmbItemLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemLiquidacion.FormattingEnabled = true;
            this.cmbItemLiquidacion.Location = new System.Drawing.Point(87, 106);
            this.cmbItemLiquidacion.Name = "cmbItemLiquidacion";
            this.cmbItemLiquidacion.Size = new System.Drawing.Size(145, 21);
            this.cmbItemLiquidacion.TabIndex = 20;
            this.cmbItemLiquidacion.ValueMember = "ID_ITEM";
            this.cmbItemLiquidacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.concepto_KeyPress);
            // 
            // btnCancelconcepto
            // 
            this.btnCancelconcepto.ImageIndex = 11;
            this.btnCancelconcepto.ImageList = this.imageList1;
            this.btnCancelconcepto.Location = new System.Drawing.Point(452, 16);
            this.btnCancelconcepto.Name = "btnCancelconcepto";
            this.btnCancelconcepto.Size = new System.Drawing.Size(32, 27);
            this.btnCancelconcepto.TabIndex = 34;
            this.btnCancelconcepto.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCancelconcepto, "Calcelar");
            this.btnCancelconcepto.UseVisualStyleBackColor = true;
            this.btnCancelconcepto.Click += new System.EventHandler(this.btnCancelconcepto_Click);
            // 
            // cmbTipoConcepto
            // 
            this.cmbTipoConcepto.DisplayMember = "NOMBRETIPO";
            this.cmbTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoConcepto.FormattingEnabled = true;
            this.cmbTipoConcepto.Location = new System.Drawing.Point(87, 79);
            this.cmbTipoConcepto.Name = "cmbTipoConcepto";
            this.cmbTipoConcepto.Size = new System.Drawing.Size(145, 21);
            this.cmbTipoConcepto.TabIndex = 19;
            this.cmbTipoConcepto.ValueMember = "LTCC_ID";
            this.cmbTipoConcepto.SelectedIndexChanged += new System.EventHandler(this.tipoconcepto_SelectedIndexChanged);
            this.cmbTipoConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoconcepto_KeyPress);
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(87, 133);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(145, 20);
            this.txtValor.TabIndex = 21;
            this.txtValor.TextChanged += new System.EventHandler(this.valor_TextChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valor_KeyPress);
            // 
            // btnOkconcepto
            // 
            this.btnOkconcepto.ImageIndex = 12;
            this.btnOkconcepto.ImageList = this.imageList1;
            this.btnOkconcepto.Location = new System.Drawing.Point(417, 16);
            this.btnOkconcepto.Name = "btnOkconcepto";
            this.btnOkconcepto.Size = new System.Drawing.Size(32, 27);
            this.btnOkconcepto.TabIndex = 35;
            this.btnOkconcepto.TabStop = false;
            this.toolTip1.SetToolTip(this.btnOkconcepto, "Guardar");
            this.btnOkconcepto.UseVisualStyleBackColor = true;
            this.btnOkconcepto.Click += new System.EventHandler(this.btnOkconcepto_Click);
            // 
            // btnEditconcepto
            // 
            this.btnEditconcepto.ImageIndex = 15;
            this.btnEditconcepto.ImageList = this.imageList2;
            this.btnEditconcepto.Location = new System.Drawing.Point(382, 16);
            this.btnEditconcepto.Name = "btnEditconcepto";
            this.btnEditconcepto.Size = new System.Drawing.Size(32, 27);
            this.btnEditconcepto.TabIndex = 36;
            this.btnEditconcepto.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEditconcepto, "Editar Concepto");
            this.btnEditconcepto.UseVisualStyleBackColor = true;
            this.btnEditconcepto.Click += new System.EventHandler(this.btnEditconcepto_Click);
            // 
            // chkConceptdescontable
            // 
            this.chkConceptdescontable.AutoSize = true;
            this.chkConceptdescontable.Location = new System.Drawing.Point(8, 26);
            this.chkConceptdescontable.Name = "chkConceptdescontable";
            this.chkConceptdescontable.Size = new System.Drawing.Size(86, 17);
            this.chkConceptdescontable.TabIndex = 18;
            this.chkConceptdescontable.Text = "Descontable";
            this.chkConceptdescontable.UseVisualStyleBackColor = true;
            this.chkConceptdescontable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.conceptdescontable_KeyPress);
            // 
            // grbDatosConcepto
            // 
            this.grbDatosConcepto.Controls.Add(this.chkConceptdescontable);
            this.grbDatosConcepto.Controls.Add(this.btnEditconcepto);
            this.grbDatosConcepto.Controls.Add(this.txtDatobase);
            this.grbDatosConcepto.Controls.Add(this.btnOkconcepto);
            this.grbDatosConcepto.Controls.Add(this.txtFactor);
            this.grbDatosConcepto.Controls.Add(this.txtValor);
            this.grbDatosConcepto.Controls.Add(this.cmbTipoConcepto);
            this.grbDatosConcepto.Controls.Add(this.btnCancelconcepto);
            this.grbDatosConcepto.Controls.Add(this.cmbItemLiquidacion);
            this.grbDatosConcepto.Controls.Add(this.label13);
            this.grbDatosConcepto.Controls.Add(this.label12);
            this.grbDatosConcepto.Controls.Add(this.label11);
            this.grbDatosConcepto.Controls.Add(this.label10);
            this.grbDatosConcepto.Controls.Add(this.label9);
            this.grbDatosConcepto.Controls.Add(this.label8);
            this.grbDatosConcepto.Controls.Add(this.txtCalculo);
            this.grbDatosConcepto.Location = new System.Drawing.Point(413, 340);
            this.grbDatosConcepto.Name = "grbDatosConcepto";
            this.grbDatosConcepto.Size = new System.Drawing.Size(494, 237);
            this.grbDatosConcepto.TabIndex = 13;
            this.grbDatosConcepto.TabStop = false;
            this.grbDatosConcepto.Text = "[Datos Concepto]";
            // 
            // txtDatobase
            // 
            this.txtDatobase.Location = new System.Drawing.Point(87, 188);
            this.txtDatobase.Name = "txtDatobase";
            this.txtDatobase.Size = new System.Drawing.Size(145, 20);
            this.txtDatobase.TabIndex = 23;
            this.txtDatobase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.datobase_KeyPress);
            // 
            // txtFactor
            // 
            this.txtFactor.Enabled = false;
            this.txtFactor.Location = new System.Drawing.Point(87, 161);
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Size = new System.Drawing.Size(145, 20);
            this.txtFactor.TabIndex = 22;
            this.txtFactor.TextChanged += new System.EventHandler(this.factor_TextChanged);
            this.txtFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.factor_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Dato base";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Factor";
            // 
            // administradortarifas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 589);
            this.Controls.Add(this.btnEditConceptoForm);
            this.Controls.Add(this.grbDatosConcepto);
            this.Controls.Add(this.grbConceptos);
            this.Controls.Add(this.btnQuitconcepto);
            this.Controls.Add(this.btnAddconcepto);
            this.Controls.Add(this.grbDatosTarifa);
            this.Controls.Add(this.cabezera);
            this.Name = "administradortarifas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Administrador de tarifas]";
            this.Load += new System.EventHandler(this.administradortarifas_Load);
            this.cabezera.ResumeLayout(false);
            this.cabezera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarifas)).EndInit();
            this.grbDatosTarifa.ResumeLayout(false);
            this.grbDatosTarifa.PerformLayout();
            this.grbConceptos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).EndInit();
            this.grbDatosConcepto.ResumeLayout(false);
            this.grbDatosConcepto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbVigencias;
        private System.Windows.Forms.GroupBox cabezera;
        private System.Windows.Forms.GroupBox grbDatosTarifa;
        private System.Windows.Forms.GroupBox grbConceptos;
        private System.Windows.Forms.DataGridView grdConceptos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTramite;
        private System.Windows.Forms.ComboBox cmbTipoTarifa;
        private System.Windows.Forms.TextBox txtTarifa;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCondiciones;
        private System.Windows.Forms.CheckBox chkMultiplegrupo;
        private System.Windows.Forms.CheckBox chkMultipleliquidacion;
        private System.Windows.Forms.CheckBox chkActiva;
        private System.Windows.Forms.Button btnAddtarifa;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnQuittarifa;
        private System.Windows.Forms.Button btnQuitconcepto;
        private System.Windows.Forms.Button btnAddconcepto;
        private System.Windows.Forms.Button btnEditConceptoForm;
        private System.Windows.Forms.Button btnCancelTarifa;
        private System.Windows.Forms.Button btnEditTarifa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAgregarVigencia;
        private System.Windows.Forms.Button btnGuardarTarifa;
        private System.Windows.Forms.TextBox txtCalculo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbItemLiquidacion;
        private System.Windows.Forms.Button btnCancelconcepto;
        private System.Windows.Forms.ComboBox cmbTipoConcepto;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Button btnOkconcepto;
        private System.Windows.Forms.Button btnEditconcepto;
        private System.Windows.Forms.CheckBox chkConceptdescontable;
        private System.Windows.Forms.GroupBox grbDatosConcepto;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSearchTarifa;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridView grdTarifas;
        private System.Windows.Forms.TextBox txtDatobase;
        private System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}