namespace Comparendos.servicios.liquidacion
{
    partial class LiquidacionComparendos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiquidacionComparendos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNroIdentificacion = new System.Windows.Forms.TextBox();
            this.cmbTipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.labInfractor = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tblConceptos = new System.Windows.Forms.DataGridView();
            this.tblComparendos = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lnkVerFactura = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTarifas = new System.Windows.Forms.ComboBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNroIdentificacion);
            this.groupBox1.Controls.Add(this.cmbTipoIdentificacion);
            this.groupBox1.Controls.Add(this.labInfractor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 108);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Solicitante";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageKey = "search.ico";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(6, 67);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(101, 26);
            this.btnBuscar.TabIndex = 19;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.imageList1.Images.SetKeyName(13, "applications-system.png");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Documento:";
            this.label11.UseWaitCursor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Tipo Documento:";
            this.label10.UseWaitCursor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-151, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tipo Documento";
            this.label9.UseWaitCursor = true;
            // 
            // txtNroIdentificacion
            // 
            this.txtNroIdentificacion.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtNroIdentificacion.Location = new System.Drawing.Point(194, 41);
            this.txtNroIdentificacion.Name = "txtNroIdentificacion";
            this.txtNroIdentificacion.Size = new System.Drawing.Size(188, 20);
            this.txtNroIdentificacion.TabIndex = 16;
            this.txtNroIdentificacion.TextChanged += new System.EventHandler(this.txtNroIdentificacion_TextChanged);
            this.txtNroIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroIdentificacion_KeyDown);
            // 
            // cmbTipoIdentificacion
            // 
            this.cmbTipoIdentificacion.DisplayMember = "DESCRIPCION";
            this.cmbTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentificacion.FormattingEnabled = true;
            this.cmbTipoIdentificacion.Location = new System.Drawing.Point(6, 40);
            this.cmbTipoIdentificacion.Name = "cmbTipoIdentificacion";
            this.cmbTipoIdentificacion.Size = new System.Drawing.Size(182, 21);
            this.cmbTipoIdentificacion.TabIndex = 15;
            this.cmbTipoIdentificacion.ValueMember = "ID_DOCCOMP";
            this.cmbTipoIdentificacion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIdentificacion_SelectedIndexChanged);
            // 
            // labInfractor
            // 
            this.labInfractor.BackColor = System.Drawing.Color.LightGray;
            this.labInfractor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labInfractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labInfractor.Location = new System.Drawing.Point(113, 67);
            this.labInfractor.Name = "labInfractor";
            this.labInfractor.Size = new System.Drawing.Size(269, 26);
            this.labInfractor.TabIndex = 13;
            this.labInfractor.Text = "                       ";
            this.labInfractor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tblConceptos);
            this.groupBox2.Controls.Add(this.tblComparendos);
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(948, 416);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Comparendos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Detalle";
            // 
            // tblConceptos
            // 
            this.tblConceptos.AllowUserToAddRows = false;
            this.tblConceptos.AllowUserToDeleteRows = false;
            this.tblConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblConceptos.Location = new System.Drawing.Point(14, 217);
            this.tblConceptos.Name = "tblConceptos";
            this.tblConceptos.ReadOnly = true;
            this.tblConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblConceptos.Size = new System.Drawing.Size(928, 179);
            this.tblConceptos.TabIndex = 42;
            // 
            // tblComparendos
            // 
            this.tblComparendos.AllowUserToAddRows = false;
            this.tblComparendos.AllowUserToDeleteRows = false;
            this.tblComparendos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblComparendos.Location = new System.Drawing.Point(14, 19);
            this.tblComparendos.Name = "tblComparendos";
            this.tblComparendos.ReadOnly = true;
            this.tblComparendos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblComparendos.Size = new System.Drawing.Size(928, 179);
            this.tblComparendos.TabIndex = 40;
            this.tblComparendos.SelectionChanged += new System.EventHandler(this.tblComparendos_SelectionChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lnkVerFactura);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(418, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(542, 102);
            this.panel3.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 42);
            this.label3.Name = "label3";
            this.label3.ReadOnly = true;
            this.label3.Size = new System.Drawing.Size(152, 26);
            this.label3.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(92, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 31);
            this.label15.TabIndex = 17;
            this.label15.Text = "$0.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 31);
            this.label14.TabIndex = 16;
            this.label14.Text = "Total";
            // 
            // lnkVerFactura
            // 
            this.lnkVerFactura.BackColor = System.Drawing.Color.LightGray;
            this.lnkVerFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lnkVerFactura.Enabled = false;
            this.lnkVerFactura.Location = new System.Drawing.Point(296, 42);
            this.lnkVerFactura.Name = "lnkVerFactura";
            this.lnkVerFactura.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lnkVerFactura.Size = new System.Drawing.Size(84, 26);
            this.lnkVerFactura.TabIndex = 15;
            this.lnkVerFactura.TabStop = true;
            this.lnkVerFactura.Text = "Ver Factura";
            this.lnkVerFactura.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVerFactura_LinkClicked);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número Factura Local:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 550);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 29);
            this.label1.TabIndex = 42;
            this.label1.Text = "Tarifas:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTarifas
            // 
            this.cmbTarifas.DisplayMember = "LT_NOMBRE";
            this.cmbTarifas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarifas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTarifas.FormattingEnabled = true;
            this.cmbTarifas.Location = new System.Drawing.Point(86, 553);
            this.cmbTarifas.Name = "cmbTarifas";
            this.cmbTarifas.Size = new System.Drawing.Size(346, 24);
            this.cmbTarifas.TabIndex = 41;
            this.cmbTarifas.ValueMember = "LT_ID";
            this.cmbTarifas.SelectedIndexChanged += new System.EventHandler(this.cmbTarifa_SelectedIndexChanged);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.ImageKey = "button_ok.ico";
            this.btnFacturar.ImageList = this.imageList1;
            this.btnFacturar.Location = new System.Drawing.Point(741, 546);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(102, 37);
            this.btnFacturar.TabIndex = 43;
            this.btnFacturar.Text = "&Facturar";
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ImageKey = "view-refresh.png";
            this.btnLimpiar.ImageList = this.imageList1;
            this.btnLimpiar.Location = new System.Drawing.Point(628, 546);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(98, 37);
            this.btnLimpiar.TabIndex = 44;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ImageKey = "button_cancel.ico";
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(856, 546);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 37);
            this.btnSalir.TabIndex = 45;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // LiquidacionComparendos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 613);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTarifas);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LiquidacionComparendos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquidación de Comparendos";
            this.Load += new System.EventHandler(this.LiquidacionComparendos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNroIdentificacion;
        private System.Windows.Forms.ComboBox cmbTipoIdentificacion;
        private System.Windows.Forms.Label labInfractor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tblComparendos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTarifas;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.LinkLabel lnkVerFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView tblConceptos;
        private System.Windows.Forms.TextBox label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalir;
    }
}