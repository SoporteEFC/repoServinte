namespace TransportePublico.servicios.vehiculos
{
    partial class frmVehiculosActivosEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehiculosActivosEmpresa));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contenedordatoscupo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.btnBuscarEmpresa = new System.Windows.Forms.Button();
            this.nombreempresa = new System.Windows.Forms.TextBox();
            this.siglaempresa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedorgrilla = new System.Windows.Forms.GroupBox();
            this.dgwVehivulos = new System.Windows.Forms.DataGridView();
            this.acciones = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnSearchVehiculos = new System.Windows.Forms.Button();
            this.btnInformeVehiculos = new System.Windows.Forms.Button();
            this.contenedordatoscupo.SuspendLayout();
            this.contenedorgrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVehivulos)).BeginInit();
            this.acciones.SuspendLayout();
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
            // 
            // contenedordatoscupo
            // 
            this.contenedordatoscupo.Controls.Add(this.label3);
            this.contenedordatoscupo.Controls.Add(this.label2);
            this.contenedordatoscupo.Controls.Add(this.cmbTipoVehiculo);
            this.contenedordatoscupo.Controls.Add(this.btnBuscarEmpresa);
            this.contenedordatoscupo.Controls.Add(this.nombreempresa);
            this.contenedordatoscupo.Controls.Add(this.siglaempresa);
            this.contenedordatoscupo.Controls.Add(this.label1);
            this.contenedordatoscupo.Location = new System.Drawing.Point(12, 12);
            this.contenedordatoscupo.Name = "contenedordatoscupo";
            this.contenedordatoscupo.Size = new System.Drawing.Size(579, 113);
            this.contenedordatoscupo.TabIndex = 0;
            this.contenedordatoscupo.TabStop = false;
            this.contenedordatoscupo.Text = "[Critérios de Búsqueda]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "NIT:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tipo de Vehículo:";
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(9, 82);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(241, 21);
            this.cmbTipoVehiculo.TabIndex = 2;
            this.cmbTipoVehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoVehiculo_KeyPress);
            // 
            // btnBuscarEmpresa
            // 
            this.btnBuscarEmpresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarEmpresa.ImageIndex = 10;
            this.btnBuscarEmpresa.ImageList = this.imageList1;
            this.btnBuscarEmpresa.Location = new System.Drawing.Point(457, 36);
            this.btnBuscarEmpresa.Name = "btnBuscarEmpresa";
            this.btnBuscarEmpresa.Size = new System.Drawing.Size(112, 28);
            this.btnBuscarEmpresa.TabIndex = 1;
            this.btnBuscarEmpresa.Text = "Buscar &Empresa";
            this.btnBuscarEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarEmpresa.UseVisualStyleBackColor = true;
            this.btnBuscarEmpresa.Click += new System.EventHandler(this.btnbuscarempresa_Click);
            // 
            // nombreempresa
            // 
            this.nombreempresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreempresa.Location = new System.Drawing.Point(115, 41);
            this.nombreempresa.Name = "nombreempresa";
            this.nombreempresa.ReadOnly = true;
            this.nombreempresa.Size = new System.Drawing.Size(336, 20);
            this.nombreempresa.TabIndex = 0;
            this.nombreempresa.TabStop = false;
            // 
            // siglaempresa
            // 
            this.siglaempresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.siglaempresa.Location = new System.Drawing.Point(9, 41);
            this.siglaempresa.Name = "siglaempresa";
            this.siglaempresa.ReadOnly = true;
            this.siglaempresa.Size = new System.Drawing.Size(100, 20);
            this.siglaempresa.TabIndex = 1;
            this.siglaempresa.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa Asociada: ";
            // 
            // contenedorgrilla
            // 
            this.contenedorgrilla.Controls.Add(this.dgwVehivulos);
            this.contenedorgrilla.Location = new System.Drawing.Point(12, 131);
            this.contenedorgrilla.Name = "contenedorgrilla";
            this.contenedorgrilla.Size = new System.Drawing.Size(929, 301);
            this.contenedorgrilla.TabIndex = 2;
            this.contenedorgrilla.TabStop = false;
            // 
            // dgwVehivulos
            // 
            this.dgwVehivulos.AllowUserToAddRows = false;
            this.dgwVehivulos.AllowUserToDeleteRows = false;
            this.dgwVehivulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVehivulos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwVehivulos.Location = new System.Drawing.Point(3, 16);
            this.dgwVehivulos.Name = "dgwVehivulos";
            this.dgwVehivulos.ReadOnly = true;
            this.dgwVehivulos.Size = new System.Drawing.Size(923, 282);
            this.dgwVehivulos.TabIndex = 0;
            this.dgwVehivulos.TabStop = false;
            // 
            // acciones
            // 
            this.acciones.Controls.Add(this.btnExcel);
            this.acciones.Controls.Add(this.btnSalir);
            this.acciones.Controls.Add(this.btnSearchVehiculos);
            this.acciones.Controls.Add(this.btnInformeVehiculos);
            this.acciones.Location = new System.Drawing.Point(597, 12);
            this.acciones.Name = "acciones";
            this.acciones.Size = new System.Drawing.Size(325, 113);
            this.acciones.TabIndex = 3;
            this.acciones.TabStop = false;
            this.acciones.Text = "[Acciones]";
            this.acciones.Enter += new System.EventHandler(this.acciones_Enter);
            // 
            // btnExcel
            // 
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.ImageKey = "edit-find.png";
            this.btnExcel.ImageList = this.imageList1;
            this.btnExcel.Location = new System.Drawing.Point(196, 51);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(110, 28);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "Exportar a &Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageIndex = 0;
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(127, 29);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(50, 28);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearchVehiculos
            // 
            this.btnSearchVehiculos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchVehiculos.ImageIndex = 10;
            this.btnSearchVehiculos.ImageList = this.imageList1;
            this.btnSearchVehiculos.Location = new System.Drawing.Point(6, 29);
            this.btnSearchVehiculos.Name = "btnSearchVehiculos";
            this.btnSearchVehiculos.Size = new System.Drawing.Size(115, 28);
            this.btnSearchVehiculos.TabIndex = 4;
            this.btnSearchVehiculos.Text = "Buscar &Vehículos";
            this.btnSearchVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchVehiculos.UseVisualStyleBackColor = true;
            this.btnSearchVehiculos.Click += new System.EventHandler(this.btnSearchVehiculos_Click);
            // 
            // btnInformeVehiculos
            // 
            this.btnInformeVehiculos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformeVehiculos.ImageIndex = 12;
            this.btnInformeVehiculos.ImageList = this.imageList1;
            this.btnInformeVehiculos.Location = new System.Drawing.Point(6, 70);
            this.btnInformeVehiculos.Name = "btnInformeVehiculos";
            this.btnInformeVehiculos.Size = new System.Drawing.Size(171, 28);
            this.btnInformeVehiculos.TabIndex = 7;
            this.btnInformeVehiculos.Text = "Generar &Informe Vehículos";
            this.btnInformeVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInformeVehiculos.UseVisualStyleBackColor = true;
            this.btnInformeVehiculos.Click += new System.EventHandler(this.btninformevehiculos_Click);
            // 
            // frmVehiculosActivosEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 460);
            this.Controls.Add(this.acciones);
            this.Controls.Add(this.contenedorgrilla);
            this.Controls.Add(this.contenedordatoscupo);
            this.Name = "frmVehiculosActivosEmpresa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Vehículos Activos por Empresa]";
            this.Load += new System.EventHandler(this.vehiculosactivosempresa_Load);
            this.contenedordatoscupo.ResumeLayout(false);
            this.contenedordatoscupo.PerformLayout();
            this.contenedorgrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwVehivulos)).EndInit();
            this.acciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox contenedordatoscupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Button btnBuscarEmpresa;
        private System.Windows.Forms.TextBox nombreempresa;
        private System.Windows.Forms.TextBox siglaempresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox contenedorgrilla;
        private System.Windows.Forms.GroupBox acciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnSearchVehiculos;
        private System.Windows.Forms.Button btnInformeVehiculos;
        private System.Windows.Forms.DataGridView dgwVehivulos;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label3;

    }
}