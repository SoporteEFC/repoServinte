namespace TransportePublico.servicios.vehiculos
{
    partial class vidautilporvehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(vidautilporvehiculo));
            this.contenedorgrilla = new System.Windows.Forms.GroupBox();
            this.grillavehiculos = new System.Windows.Forms.DataGridView();
            this.contenedordatoscupo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tipovehiculo = new System.Windows.Forms.ComboBox();
            this.acciones = new System.Windows.Forms.GroupBox();
            this.btninformevehiculos = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSearchVehiculos = new System.Windows.Forms.Button();
            this.contenedorgrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillavehiculos)).BeginInit();
            this.contenedordatoscupo.SuspendLayout();
            this.acciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // contenedorgrilla
            // 
            this.contenedorgrilla.Controls.Add(this.grillavehiculos);
            this.contenedorgrilla.Location = new System.Drawing.Point(6, 72);
            this.contenedorgrilla.Name = "contenedorgrilla";
            this.contenedorgrilla.Size = new System.Drawing.Size(773, 349);
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
            this.grillavehiculos.Size = new System.Drawing.Size(767, 330);
            this.grillavehiculos.TabIndex = 0;
            // 
            // contenedordatoscupo
            // 
            this.contenedordatoscupo.Controls.Add(this.label2);
            this.contenedordatoscupo.Controls.Add(this.tipovehiculo);
            this.contenedordatoscupo.Location = new System.Drawing.Point(6, 4);
            this.contenedordatoscupo.Name = "contenedordatoscupo";
            this.contenedordatoscupo.Size = new System.Drawing.Size(296, 62);
            this.contenedordatoscupo.TabIndex = 0;
            this.contenedordatoscupo.TabStop = false;
            this.contenedordatoscupo.Text = "[Critérios de Búsqueda]";
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
            // tipovehiculo
            // 
            this.tipovehiculo.FormattingEnabled = true;
            this.tipovehiculo.Location = new System.Drawing.Point(9, 32);
            this.tipovehiculo.Name = "tipovehiculo";
            this.tipovehiculo.Size = new System.Drawing.Size(279, 21);
            this.tipovehiculo.TabIndex = 1;
            this.tipovehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipovehiculo_KeyPress);
            // 
            // acciones
            // 
            this.acciones.Controls.Add(this.btninformevehiculos);
            this.acciones.Controls.Add(this.btnExit);
            this.acciones.Controls.Add(this.btnSearchVehiculos);
            this.acciones.Location = new System.Drawing.Point(308, 4);
            this.acciones.Name = "acciones";
            this.acciones.Size = new System.Drawing.Size(335, 62);
            this.acciones.TabIndex = 2;
            this.acciones.TabStop = false;
            this.acciones.Text = "[Acciones]";
            // 
            // btninformevehiculos
            // 
            this.btninformevehiculos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninformevehiculos.ImageIndex = 12;
            this.btninformevehiculos.ImageList = this.imageList1;
            this.btninformevehiculos.Location = new System.Drawing.Point(122, 25);
            this.btninformevehiculos.Name = "btninformevehiculos";
            this.btninformevehiculos.Size = new System.Drawing.Size(156, 28);
            this.btninformevehiculos.TabIndex = 4;
            this.btninformevehiculos.Text = "Generar &Informe Vehículos";
            this.btninformevehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btninformevehiculos.UseVisualStyleBackColor = true;
            this.btninformevehiculos.Click += new System.EventHandler(this.btninformevehiculos_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 0;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(280, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // btnSearchVehiculos
            // 
            this.btnSearchVehiculos.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchVehiculos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchVehiculos.ImageIndex = 10;
            this.btnSearchVehiculos.ImageList = this.imageList1;
            this.btnSearchVehiculos.Location = new System.Drawing.Point(6, 25);
            this.btnSearchVehiculos.Name = "btnSearchVehiculos";
            this.btnSearchVehiculos.Size = new System.Drawing.Size(114, 28);
            this.btnSearchVehiculos.TabIndex = 3;
            this.btnSearchVehiculos.Text = "&Buscar Vehículos";
            this.btnSearchVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchVehiculos.UseVisualStyleBackColor = false;
            this.btnSearchVehiculos.Click += new System.EventHandler(this.btnSearchVehiculos_Click);
            // 
            // vidautilporvehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 424);
            this.Controls.Add(this.contenedorgrilla);
            this.Controls.Add(this.contenedordatoscupo);
            this.Controls.Add(this.acciones);
            this.Name = "vidautilporvehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Vida Util por Vehículo]";
            this.Load += new System.EventHandler(this.vidautilporvehiculo_Load);
            this.contenedorgrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillavehiculos)).EndInit();
            this.contenedordatoscupo.ResumeLayout(false);
            this.contenedordatoscupo.PerformLayout();
            this.acciones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox contenedorgrilla;
        private System.Windows.Forms.DataGridView grillavehiculos;
        private System.Windows.Forms.GroupBox contenedordatoscupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipovehiculo;
        private System.Windows.Forms.GroupBox acciones;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSearchVehiculos;
        private System.Windows.Forms.Button btninformevehiculos;
    }
}