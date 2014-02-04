namespace Comparendos.servicios.generales
{
    partial class FrmAcuerdoPagoPorInfractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcuerdoPagoPorInfractor));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtApeliidos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnVerDocumento = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbVerOficioNotificacion = new System.Windows.Forms.RadioButton();
            this.rbVerResolucion = new System.Windows.Forms.RadioButton();
            this.btnExprotarExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tblAcuerdos = new System.Windows.Forms.DataGridView();
            this.cbObtenerAcuerdoPagoMora = new System.Windows.Forms.CheckBox();
            this.dtpFechaAcuerdoFin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaAcuerdoInicio = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccionResidencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumIdentificacion = new System.Windows.Forms.TextBox();
            this.cmbTipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblAcuerdos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.txtApeliidos);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnVerDocumento);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnExprotarExcel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbObtenerAcuerdoPagoMora);
            this.groupBox1.Controls.Add(this.dtpFechaAcuerdoFin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpFechaAcuerdoInicio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDireccionResidencia);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumIdentificacion);
            this.groupBox1.Controls.Add(this.cmbTipoIdentificacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 552);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageKey = "magnify.png";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(432, 48);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(63, 23);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "system-log-out.png");
            this.imageList1.Images.SetKeyName(1, "magnify.png");
            this.imageList1.Images.SetKeyName(2, "text-x-generic.png");
            this.imageList1.Images.SetKeyName(3, "icono_excel.v1.cache.gif");
            // 
            // txtApeliidos
            // 
            this.txtApeliidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApeliidos.Enabled = false;
            this.txtApeliidos.Location = new System.Drawing.Point(227, 109);
            this.txtApeliidos.Name = "txtApeliidos";
            this.txtApeliidos.Size = new System.Drawing.Size(195, 20);
            this.txtApeliidos.TabIndex = 19;
            this.txtApeliidos.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Apellidos:";
            // 
            // btnSalir
            // 
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageKey = "button_cancel.ico";
            this.btnSalir.ImageList = this.imageList2;
            this.btnSalir.Location = new System.Drawing.Point(530, 502);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(73, 23);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.imageList2.Images.SetKeyName(13, "Users.ico");
            this.imageList2.Images.SetKeyName(14, "User.ico");
            this.imageList2.Images.SetKeyName(15, "printer.gif");
            this.imageList2.Images.SetKeyName(16, "16 (Find).ico");
            this.imageList2.Images.SetKeyName(17, "16 (Flag blue).ico");
            this.imageList2.Images.SetKeyName(18, "16 (Folder).ico");
            this.imageList2.Images.SetKeyName(19, "16 (Lock off).ico");
            this.imageList2.Images.SetKeyName(20, "16 (Lock on).ico");
            this.imageList2.Images.SetKeyName(21, "16 (Print preview).ico");
            this.imageList2.Images.SetKeyName(22, "16 (Print).ico");
            this.imageList2.Images.SetKeyName(23, "16 (Save).ico");
            this.imageList2.Images.SetKeyName(24, "16 (User).ico");
            this.imageList2.Images.SetKeyName(25, "16 (Users).ico");
            this.imageList2.Images.SetKeyName(26, "16 (Contents).ico");
            this.imageList2.Images.SetKeyName(27, "16 (Db cancel).ico");
            this.imageList2.Images.SetKeyName(28, "16 (Db delete).ico");
            this.imageList2.Images.SetKeyName(29, "16 (Db edit).ico");
            this.imageList2.Images.SetKeyName(30, "16 (Db first).ico");
            this.imageList2.Images.SetKeyName(31, "16 (Db insert).ico");
            this.imageList2.Images.SetKeyName(32, "16 (Db last).ico");
            this.imageList2.Images.SetKeyName(33, "16 (Db next).ico");
            this.imageList2.Images.SetKeyName(34, "16 (Db post).ico");
            this.imageList2.Images.SetKeyName(35, "16 (Db previous).ico");
            this.imageList2.Images.SetKeyName(36, "16 (Db refresh).ico");
            this.imageList2.Images.SetKeyName(37, "16 (Execute).ico");
            this.imageList2.Images.SetKeyName(38, "16 (Exit).ico");
            this.imageList2.Images.SetKeyName(39, "16 (Fill up).ico");
            this.imageList2.Images.SetKeyName(40, "open2.png");
            this.imageList2.Images.SetKeyName(41, "Cool Blue Floppy Drive 3.png");
            // 
            // btnVerDocumento
            // 
            this.btnVerDocumento.Enabled = false;
            this.btnVerDocumento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDocumento.ImageIndex = 3;
            this.btnVerDocumento.ImageList = this.imageList2;
            this.btnVerDocumento.Location = new System.Drawing.Point(387, 502);
            this.btnVerDocumento.Name = "btnVerDocumento";
            this.btnVerDocumento.Size = new System.Drawing.Size(108, 23);
            this.btnVerDocumento.TabIndex = 16;
            this.btnVerDocumento.TabStop = false;
            this.btnVerDocumento.Text = "Ver &Documento";
            this.btnVerDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerDocumento.UseVisualStyleBackColor = true;
            this.btnVerDocumento.Click += new System.EventHandler(this.btnVerDocumento_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbVerOficioNotificacion);
            this.groupBox3.Controls.Add(this.rbVerResolucion);
            this.groupBox3.Location = new System.Drawing.Point(145, 480);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 66);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acuerdo de Pago Incumplido";
            // 
            // rbVerOficioNotificacion
            // 
            this.rbVerOficioNotificacion.AutoSize = true;
            this.rbVerOficioNotificacion.Location = new System.Drawing.Point(6, 43);
            this.rbVerOficioNotificacion.Name = "rbVerOficioNotificacion";
            this.rbVerOficioNotificacion.Size = new System.Drawing.Size(145, 17);
            this.rbVerOficioNotificacion.TabIndex = 7;
            this.rbVerOficioNotificacion.TabStop = true;
            this.rbVerOficioNotificacion.Text = "Ver Oficio de Notificación";
            this.rbVerOficioNotificacion.UseVisualStyleBackColor = true;
            // 
            // rbVerResolucion
            // 
            this.rbVerResolucion.AutoSize = true;
            this.rbVerResolucion.Location = new System.Drawing.Point(6, 22);
            this.rbVerResolucion.Name = "rbVerResolucion";
            this.rbVerResolucion.Size = new System.Drawing.Size(97, 17);
            this.rbVerResolucion.TabIndex = 6;
            this.rbVerResolucion.TabStop = true;
            this.rbVerResolucion.Text = "Ver Resolución";
            this.rbVerResolucion.UseVisualStyleBackColor = true;
            // 
            // btnExprotarExcel
            // 
            this.btnExprotarExcel.Enabled = false;
            this.btnExprotarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExprotarExcel.ImageKey = "icono_excel.v1.cache.gif";
            this.btnExprotarExcel.ImageList = this.imageList1;
            this.btnExprotarExcel.Location = new System.Drawing.Point(12, 502);
            this.btnExprotarExcel.Name = "btnExprotarExcel";
            this.btnExprotarExcel.Size = new System.Drawing.Size(108, 23);
            this.btnExprotarExcel.TabIndex = 14;
            this.btnExprotarExcel.TabStop = false;
            this.btnExprotarExcel.Text = "Exportar a &Excel";
            this.btnExprotarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExprotarExcel.UseVisualStyleBackColor = true;
            this.btnExprotarExcel.Click += new System.EventHandler(this.btnExprotarExcel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tblAcuerdos);
            this.groupBox2.Location = new System.Drawing.Point(6, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(684, 262);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LISTADO DE ACUERDOS";
            // 
            // tblAcuerdos
            // 
            this.tblAcuerdos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblAcuerdos.Location = new System.Drawing.Point(6, 19);
            this.tblAcuerdos.Name = "tblAcuerdos";
            this.tblAcuerdos.Size = new System.Drawing.Size(672, 237);
            this.tblAcuerdos.TabIndex = 0;
            // 
            // cbObtenerAcuerdoPagoMora
            // 
            this.cbObtenerAcuerdoPagoMora.AutoSize = true;
            this.cbObtenerAcuerdoPagoMora.Location = new System.Drawing.Point(307, 176);
            this.cbObtenerAcuerdoPagoMora.Name = "cbObtenerAcuerdoPagoMora";
            this.cbObtenerAcuerdoPagoMora.Size = new System.Drawing.Size(209, 17);
            this.cbObtenerAcuerdoPagoMora.TabIndex = 5;
            this.cbObtenerAcuerdoPagoMora.Text = "¿Obtener Acuerdos de Pago en Mora?";
            this.cbObtenerAcuerdoPagoMora.UseVisualStyleBackColor = true;
            // 
            // dtpFechaAcuerdoFin
            // 
            this.dtpFechaAcuerdoFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaAcuerdoFin.Enabled = false;
            this.dtpFechaAcuerdoFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaAcuerdoFin.Location = new System.Drawing.Point(172, 176);
            this.dtpFechaAcuerdoFin.Name = "dtpFechaAcuerdoFin";
            this.dtpFechaAcuerdoFin.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaAcuerdoFin.TabIndex = 4;
            this.dtpFechaAcuerdoFin.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(169, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha Acuerdo Fin:";
            this.label6.Visible = false;
            // 
            // dtpFechaAcuerdoInicio
            // 
            this.dtpFechaAcuerdoInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaAcuerdoInicio.Enabled = false;
            this.dtpFechaAcuerdoInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaAcuerdoInicio.Location = new System.Drawing.Point(20, 176);
            this.dtpFechaAcuerdoInicio.Name = "dtpFechaAcuerdoInicio";
            this.dtpFechaAcuerdoInicio.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaAcuerdoInicio.TabIndex = 3;
            this.dtpFechaAcuerdoInicio.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(17, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha Acuerdo Inicio:";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dirección de Residencia:";
            // 
            // txtDireccionResidencia
            // 
            this.txtDireccionResidencia.Enabled = false;
            this.txtDireccionResidencia.Location = new System.Drawing.Point(432, 109);
            this.txtDireccionResidencia.Name = "txtDireccionResidencia";
            this.txtDireccionResidencia.Size = new System.Drawing.Size(236, 20);
            this.txtDireccionResidencia.TabIndex = 6;
            this.txtDireccionResidencia.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.CausesValidation = false;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(20, 109);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(193, 20);
            this.txtNombre.TabIndex = 4;
            this.txtNombre.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número Identificación:";
            // 
            // txtNumIdentificacion
            // 
            this.txtNumIdentificacion.Location = new System.Drawing.Point(227, 52);
            this.txtNumIdentificacion.Name = "txtNumIdentificacion";
            this.txtNumIdentificacion.Size = new System.Drawing.Size(193, 20);
            this.txtNumIdentificacion.TabIndex = 2;
            this.txtNumIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumIdentificacion_KeyPress);
            // 
            // cmbTipoIdentificacion
            // 
            this.cmbTipoIdentificacion.DisplayMember = "DESCRIPCION";
            this.cmbTipoIdentificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIdentificacion.FormattingEnabled = true;
            this.cmbTipoIdentificacion.Location = new System.Drawing.Point(20, 51);
            this.cmbTipoIdentificacion.Name = "cmbTipoIdentificacion";
            this.cmbTipoIdentificacion.Size = new System.Drawing.Size(193, 21);
            this.cmbTipoIdentificacion.TabIndex = 1;
            this.cmbTipoIdentificacion.ValueMember = "ID_DOCCOMP";
            this.cmbTipoIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoIdentificacion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Identidicación:";
            // 
            // FrmAcuerdoPagoPorInfractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 576);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAcuerdoPagoPorInfractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acuerdos Pago por Infractor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblAcuerdos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTipoIdentificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccionResidencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumIdentificacion;
        private System.Windows.Forms.DateTimePicker dtpFechaAcuerdoInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbObtenerAcuerdoPagoMora;
        private System.Windows.Forms.DateTimePicker dtpFechaAcuerdoFin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView tblAcuerdos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExprotarExcel;
        private System.Windows.Forms.RadioButton rbVerOficioNotificacion;
        private System.Windows.Forms.RadioButton rbVerResolucion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnVerDocumento;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtApeliidos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ImageList imageList2;
    }
}