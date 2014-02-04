namespace TransportePublico.servicios
{
    partial class FrmInventarioCupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInventarioCupos));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBuscarEmpresa = new System.Windows.Forms.Button();
            this.chkEmpresa = new System.Windows.Forms.CheckBox();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.chkTipoVehiculo = new System.Windows.Forms.CheckBox();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgwResultados = new System.Windows.Forms.DataGridView();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.lblInfoEstadoAsignado = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageKey = "edit-find.png";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(1078, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(68, 35);
            this.btnBuscar.TabIndex = 8;
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnBuscarEmpresa);
            this.groupBox1.Controls.Add(this.chkEmpresa);
            this.groupBox1.Controls.Add(this.cmbEmpresa);
            this.groupBox1.Controls.Add(this.chkTipoVehiculo);
            this.groupBox1.Controls.Add(this.cmbTipoVehiculo);
            this.groupBox1.Controls.Add(this.chkEstado);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cmbEstado);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1226, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criterios de busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(764, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Resultados:_";
            // 
            // btnSalir
            // 
            this.btnSalir.ImageKey = "system-log-out.png";
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(1152, 24);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(68, 35);
            this.btnSalir.TabIndex = 9;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBuscarEmpresa
            // 
            this.btnBuscarEmpresa.ImageKey = "search.ico";
            this.btnBuscarEmpresa.ImageList = this.imageList1;
            this.btnBuscarEmpresa.Location = new System.Drawing.Point(658, 36);
            this.btnBuscarEmpresa.Name = "btnBuscarEmpresa";
            this.btnBuscarEmpresa.Size = new System.Drawing.Size(31, 23);
            this.btnBuscarEmpresa.TabIndex = 7;
            this.btnBuscarEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarEmpresa.UseVisualStyleBackColor = true;
            this.btnBuscarEmpresa.Click += new System.EventHandler(this.btnBuscarEmpresa_Click);
            // 
            // chkEmpresa
            // 
            this.chkEmpresa.AutoSize = true;
            this.chkEmpresa.Location = new System.Drawing.Point(307, 19);
            this.chkEmpresa.Name = "chkEmpresa";
            this.chkEmpresa.Size = new System.Drawing.Size(108, 17);
            this.chkEmpresa.TabIndex = 5;
            this.chkEmpresa.Text = "Empresa Servicio";
            this.chkEmpresa.UseVisualStyleBackColor = true;
            this.chkEmpresa.CheckedChanged += new System.EventHandler(this.chkEmpresa_CheckedChanged);
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DisplayMember = "NOMBRE";
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(307, 38);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(345, 21);
            this.cmbEmpresa.TabIndex = 6;
            this.cmbEmpresa.ValueMember = "ID_EMPSERVICIO";
            // 
            // chkTipoVehiculo
            // 
            this.chkTipoVehiculo.AutoSize = true;
            this.chkTipoVehiculo.Location = new System.Drawing.Point(150, 19);
            this.chkTipoVehiculo.Name = "chkTipoVehiculo";
            this.chkTipoVehiculo.Size = new System.Drawing.Size(91, 17);
            this.chkTipoVehiculo.TabIndex = 3;
            this.chkTipoVehiculo.Text = "Tipo Vehiculo";
            this.chkTipoVehiculo.UseVisualStyleBackColor = true;
            this.chkTipoVehiculo.CheckedChanged += new System.EventHandler(this.chkTipoVehiculo_CheckedChanged);
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.DisplayMember = "DESCRIPCION";
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Items.AddRange(new object[] {
            "TAXI",
            "BUS",
            "BUSETA",
            "MICROBUS"});
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(150, 38);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(145, 21);
            this.cmbTipoVehiculo.TabIndex = 4;
            this.cmbTipoVehiculo.ValueMember = "ID_CVEHICULO";
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(16, 19);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(59, 17);
            this.chkEstado.TabIndex = 1;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            this.chkEstado.CheckedChanged += new System.EventHandler(this.chkEstado_CheckedChanged);
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "ASIGNADO",
            "DISPONIBLE"});
            this.cmbEstado.Location = new System.Drawing.Point(16, 38);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 21);
            this.cmbEstado.TabIndex = 2;
            // 
            // dgwResultados
            // 
            this.dgwResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwResultados.Location = new System.Drawing.Point(12, 100);
            this.dgwResultados.Name = "dgwResultados";
            this.dgwResultados.Size = new System.Drawing.Size(1226, 470);
            this.dgwResultados.TabIndex = 1;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.ImageList = this.imageList1;
            this.btnExportarExcel.Location = new System.Drawing.Point(1118, 576);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(120, 33);
            this.btnExportarExcel.TabIndex = 2;
            this.btnExportarExcel.Text = "&Generar Reporte";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // lblInfoEstadoAsignado
            // 
            this.lblInfoEstadoAsignado.AutoSize = true;
            this.lblInfoEstadoAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoEstadoAsignado.Location = new System.Drawing.Point(25, 586);
            this.lblInfoEstadoAsignado.Name = "lblInfoEstadoAsignado";
            this.lblInfoEstadoAsignado.Size = new System.Drawing.Size(25, 15);
            this.lblInfoEstadoAsignado.TabIndex = 3;
            this.lblInfoEstadoAsignado.Text = "***";
            // 
            // FrmInventarioCupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 621);
            this.Controls.Add(this.lblInfoEstadoAsignado);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.dgwResultados);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInventarioCupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe de Cupos ";
            this.Load += new System.EventHandler(this.FrmInventarioRango_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.CheckBox chkTipoVehiculo;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Button btnBuscarEmpresa;
        private System.Windows.Forms.CheckBox chkEmpresa;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgwResultados;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfoEstadoAsignado;
    }
}