namespace TransportePublico.servicios.vehiculos
{
    partial class informesgenerales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(informesgenerales));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.acciones = new System.Windows.Forms.GroupBox();
            this.btnDocumentos = new System.Windows.Forms.Button();
            this.btntarjetas = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSearchVehiculos = new System.Windows.Forms.Button();
            this.btnpropietarios = new System.Windows.Forms.Button();
            this.contenedordatoscupo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numerocupo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.contenedorgrilla = new System.Windows.Forms.GroupBox();
            this.grillavehiculos = new System.Windows.Forms.DataGridView();
            this.acciones.SuspendLayout();
            this.contenedordatoscupo.SuspendLayout();
            this.contenedorgrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillavehiculos)).BeginInit();
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
            // acciones
            // 
            this.acciones.Controls.Add(this.btnDocumentos);
            this.acciones.Controls.Add(this.btntarjetas);
            this.acciones.Controls.Add(this.btnExit);
            this.acciones.Controls.Add(this.btnSearchVehiculos);
            this.acciones.Controls.Add(this.btnpropietarios);
            this.acciones.Location = new System.Drawing.Point(669, 12);
            this.acciones.Name = "acciones";
            this.acciones.Size = new System.Drawing.Size(551, 62);
            this.acciones.TabIndex = 3;
            this.acciones.TabStop = false;
            this.acciones.Text = "[Acciones]";
            // 
            // btnDocumentos
            // 
            this.btnDocumentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDocumentos.ImageIndex = 3;
            this.btnDocumentos.ImageList = this.imageList1;
            this.btnDocumentos.Location = new System.Drawing.Point(392, 25);
            this.btnDocumentos.Name = "btnDocumentos";
            this.btnDocumentos.Size = new System.Drawing.Size(107, 28);
            this.btnDocumentos.TabIndex = 7;
            this.btnDocumentos.Text = "Ver &Documentos";
            this.btnDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDocumentos.UseVisualStyleBackColor = true;
            this.btnDocumentos.Click += new System.EventHandler(this.btnDocumentos_Click);
            // 
            // btntarjetas
            // 
            this.btntarjetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntarjetas.ImageIndex = 3;
            this.btntarjetas.ImageList = this.imageList1;
            this.btntarjetas.Location = new System.Drawing.Point(256, 25);
            this.btntarjetas.Name = "btntarjetas";
            this.btntarjetas.Size = new System.Drawing.Size(137, 28);
            this.btntarjetas.TabIndex = 6;
            this.btntarjetas.Text = "Ver &Tarjetas Operación";
            this.btntarjetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntarjetas.UseVisualStyleBackColor = true;
            this.btntarjetas.Click += new System.EventHandler(this.btntarjetas_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 0;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(498, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 28);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearchVehiculos
            // 
            this.btnSearchVehiculos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchVehiculos.ImageIndex = 10;
            this.btnSearchVehiculos.ImageList = this.imageList1;
            this.btnSearchVehiculos.Location = new System.Drawing.Point(6, 25);
            this.btnSearchVehiculos.Name = "btnSearchVehiculos";
            this.btnSearchVehiculos.Size = new System.Drawing.Size(150, 28);
            this.btnSearchVehiculos.TabIndex = 4;
            this.btnSearchVehiculos.Text = "&Buscar Información Cupo";
            this.btnSearchVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchVehiculos.UseVisualStyleBackColor = true;
            this.btnSearchVehiculos.Click += new System.EventHandler(this.btnSearchVehiculos_Click);
            // 
            // btnpropietarios
            // 
            this.btnpropietarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpropietarios.ImageIndex = 3;
            this.btnpropietarios.ImageList = this.imageList1;
            this.btnpropietarios.Location = new System.Drawing.Point(155, 25);
            this.btnpropietarios.Name = "btnpropietarios";
            this.btnpropietarios.Size = new System.Drawing.Size(102, 28);
            this.btnpropietarios.TabIndex = 5;
            this.btnpropietarios.Text = "Ver &Propietarios";
            this.btnpropietarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnpropietarios.UseVisualStyleBackColor = true;
            this.btnpropietarios.Click += new System.EventHandler(this.btnpropietarios_Click);
            // 
            // contenedordatoscupo
            // 
            this.contenedordatoscupo.Controls.Add(this.label1);
            this.contenedordatoscupo.Controls.Add(this.numerocupo);
            this.contenedordatoscupo.Controls.Add(this.label2);
            this.contenedordatoscupo.Controls.Add(this.cmbTipoVehiculo);
            this.contenedordatoscupo.Location = new System.Drawing.Point(10, 10);
            this.contenedordatoscupo.Name = "contenedordatoscupo";
            this.contenedordatoscupo.Size = new System.Drawing.Size(653, 62);
            this.contenedordatoscupo.TabIndex = 0;
            this.contenedordatoscupo.TabStop = false;
            this.contenedordatoscupo.Text = "[Critérios de Búsqueda]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(474, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Número Cúpo:";
            // 
            // numerocupo
            // 
            this.numerocupo.Location = new System.Drawing.Point(477, 33);
            this.numerocupo.Name = "numerocupo";
            this.numerocupo.Size = new System.Drawing.Size(170, 20);
            this.numerocupo.TabIndex = 2;
            this.numerocupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numerocupo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tipo de Vehículo:";
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(9, 32);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(462, 21);
            this.cmbTipoVehiculo.TabIndex = 1;
            this.cmbTipoVehiculo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVehiculo_SelectedIndexChanged);
            this.cmbTipoVehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoVehiculo_KeyPress);
            // 
            // contenedorgrilla
            // 
            this.contenedorgrilla.Controls.Add(this.grillavehiculos);
            this.contenedorgrilla.Location = new System.Drawing.Point(10, 78);
            this.contenedorgrilla.Name = "contenedorgrilla";
            this.contenedorgrilla.Size = new System.Drawing.Size(1213, 349);
            this.contenedorgrilla.TabIndex = 6;
            this.contenedorgrilla.TabStop = false;
            // 
            // grillavehiculos
            // 
            this.grillavehiculos.AllowUserToAddRows = false;
            this.grillavehiculos.AllowUserToDeleteRows = false;
            this.grillavehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillavehiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillavehiculos.Location = new System.Drawing.Point(3, 16);
            this.grillavehiculos.Name = "grillavehiculos";
            this.grillavehiculos.ReadOnly = true;
            this.grillavehiculos.Size = new System.Drawing.Size(1207, 330);
            this.grillavehiculos.TabIndex = 0;
            this.grillavehiculos.TabStop = false;
            this.grillavehiculos.SelectionChanged += new System.EventHandler(this.grillavehiculos_SelectionChanged);
            // 
            // informesgenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 432);
            this.Controls.Add(this.contenedorgrilla);
            this.Controls.Add(this.contenedordatoscupo);
            this.Controls.Add(this.acciones);
            this.Name = "informesgenerales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Informes Generales]";
            this.Load += new System.EventHandler(this.informesgenerales_Load);
            this.acciones.ResumeLayout(false);
            this.contenedordatoscupo.ResumeLayout(false);
            this.contenedordatoscupo.PerformLayout();
            this.contenedorgrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillavehiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox acciones;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSearchVehiculos;
        private System.Windows.Forms.Button btnpropietarios;
        private System.Windows.Forms.GroupBox contenedordatoscupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.TextBox numerocupo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox contenedorgrilla;
        private System.Windows.Forms.DataGridView grillavehiculos;
        private System.Windows.Forms.Button btntarjetas;
        private System.Windows.Forms.Button btnDocumentos;
    }
}