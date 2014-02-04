namespace Comparendos.servicios.liquidacion
{
    partial class fPagosSimit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPagosSimit));
            this.lblNumeroReciboSimit = new System.Windows.Forms.Label();
            this.txtNumeroReciboSimit = new System.Windows.Forms.TextBox();
            this.lblTipoIdentificacion = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.btnBucar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tblComparendos = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.labNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.dtpFechaPagoSimit = new System.Windows.Forms.DateTimePicker();
            this.lblFechaSimit = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblValor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumeroReciboSimit
            // 
            this.lblNumeroReciboSimit.AutoSize = true;
            this.lblNumeroReciboSimit.Location = new System.Drawing.Point(28, 101);
            this.lblNumeroReciboSimit.Name = "lblNumeroReciboSimit";
            this.lblNumeroReciboSimit.Size = new System.Drawing.Size(109, 13);
            this.lblNumeroReciboSimit.TabIndex = 0;
            this.lblNumeroReciboSimit.Text = "Número Recibo Simit:";
            // 
            // txtNumeroReciboSimit
            // 
            this.txtNumeroReciboSimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroReciboSimit.Enabled = false;
            this.txtNumeroReciboSimit.Location = new System.Drawing.Point(31, 119);
            this.txtNumeroReciboSimit.MaxLength = 40;
            this.txtNumeroReciboSimit.Name = "txtNumeroReciboSimit";
            this.txtNumeroReciboSimit.Size = new System.Drawing.Size(165, 20);
            this.txtNumeroReciboSimit.TabIndex = 3;
            this.txtNumeroReciboSimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroReciboSimit_KeyPress);
            // 
            // lblTipoIdentificacion
            // 
            this.lblTipoIdentificacion.AutoSize = true;
            this.lblTipoIdentificacion.Location = new System.Drawing.Point(26, 9);
            this.lblTipoIdentificacion.Name = "lblTipoIdentificacion";
            this.lblTipoIdentificacion.Size = new System.Drawing.Size(89, 13);
            this.lblTipoIdentificacion.TabIndex = 2;
            this.lblTipoIdentificacion.Text = "Tipo Documento:";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.DisplayMember = "DESCRIPCION";
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(29, 26);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(210, 21);
            this.cmbTipoDocumento.TabIndex = 1;
            this.cmbTipoDocumento.ValueMember = "ID_DOCCOMP";
            this.cmbTipoDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoDocumento_KeyPress);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(254, 25);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(188, 20);
            this.txtIdentificacion.TabIndex = 2;
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.AutoSize = true;
            this.lblIdentificacion.Location = new System.Drawing.Point(251, 9);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(73, 13);
            this.lblIdentificacion.TabIndex = 5;
            this.lblIdentificacion.Text = "Identificación:";
            // 
            // btnBucar
            // 
            this.btnBucar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBucar.ImageKey = "magnify.png";
            this.btnBucar.ImageList = this.imageList1;
            this.btnBucar.Location = new System.Drawing.Point(460, 22);
            this.btnBucar.Name = "btnBucar";
            this.btnBucar.Size = new System.Drawing.Size(75, 23);
            this.btnBucar.TabIndex = 6;
            this.btnBucar.TabStop = false;
            this.btnBucar.Text = "&Buscar";
            this.btnBucar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBucar.UseVisualStyleBackColor = true;
            this.btnBucar.Click += new System.EventHandler(this.btnBucar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "magnify.png");
            this.imageList1.Images.SetKeyName(1, "button_ok16.png");
            this.imageList1.Images.SetKeyName(2, "system-log-out.png");
            // 
            // tblComparendos
            // 
            this.tblComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblComparendos.Location = new System.Drawing.Point(29, 156);
            this.tblComparendos.MultiSelect = false;
            this.tblComparendos.Name = "tblComparendos";
            this.tblComparendos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblComparendos.Size = new System.Drawing.Size(506, 187);
            this.tblComparendos.TabIndex = 7;
            // 
            // btnSalir
            // 
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageIndex = 1;
            this.btnSalir.ImageList = this.imageList2;
            this.btnSalir.Location = new System.Drawing.Point(379, 359);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(63, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "button_ok16.png");
            this.imageList2.Images.SetKeyName(1, "delete16.png");
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.ImageKey = "button_ok16.png";
            this.btnRegistrar.ImageList = this.imageList2;
            this.btnRegistrar.Location = new System.Drawing.Point(460, 359);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "&Registrar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.Location = new System.Drawing.Point(29, 52);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(47, 13);
            this.labNombre.TabIndex = 10;
            this.labNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(29, 69);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(233, 20);
            this.txtNombre.TabIndex = 11;
            this.txtNombre.TabStop = false;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(283, 52);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 12;
            this.lblApellido.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(286, 68);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(249, 20);
            this.txtApellido.TabIndex = 13;
            this.txtApellido.TabStop = false;
            // 
            // dtpFechaPagoSimit
            // 
            this.dtpFechaPagoSimit.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaPagoSimit.Enabled = false;
            this.dtpFechaPagoSimit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaPagoSimit.Location = new System.Drawing.Point(214, 118);
            this.dtpFechaPagoSimit.Name = "dtpFechaPagoSimit";
            this.dtpFechaPagoSimit.Size = new System.Drawing.Size(141, 20);
            this.dtpFechaPagoSimit.TabIndex = 4;
            this.dtpFechaPagoSimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaPagoSimit_KeyPress);
            // 
            // lblFechaSimit
            // 
            this.lblFechaSimit.AutoSize = true;
            this.lblFechaSimit.Location = new System.Drawing.Point(212, 101);
            this.lblFechaSimit.Name = "lblFechaSimit";
            this.lblFechaSimit.Size = new System.Drawing.Size(93, 13);
            this.lblFechaSimit.TabIndex = 15;
            this.lblFechaSimit.Text = "Fecha Pago Simit:";
            // 
            // txtValor
            // 
            this.txtValor.Enabled = false;
            this.txtValor.Location = new System.Drawing.Point(371, 119);
            this.txtValor.MaxLength = 20;
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(164, 20);
            this.txtValor.TabIndex = 5;
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(368, 101);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 17;
            this.lblValor.Text = "Valor:";
            // 
            // fPagosSimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 403);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblFechaSimit);
            this.Controls.Add(this.dtpFechaPagoSimit);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labNombre);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tblComparendos);
            this.Controls.Add(this.btnBucar);
            this.Controls.Add(this.lblIdentificacion);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.cmbTipoDocumento);
            this.Controls.Add(this.lblTipoIdentificacion);
            this.Controls.Add(this.txtNumeroReciboSimit);
            this.Controls.Add(this.lblNumeroReciboSimit);
            this.Name = "fPagosSimit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos Simit";
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumeroReciboSimit;
        private System.Windows.Forms.TextBox txtNumeroReciboSimit;
        private System.Windows.Forms.Label lblTipoIdentificacion;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.Button btnBucar;
        private System.Windows.Forms.DataGridView tblComparendos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.DateTimePicker dtpFechaPagoSimit;
        private System.Windows.Forms.Label lblFechaSimit;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.ImageList imageList2;
    }
}