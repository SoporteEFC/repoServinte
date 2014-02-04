namespace Comparendos.servicios.generales
{
    partial class FrmCancelacionAnulacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCancelacionAnulacion));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumResolucionMotivo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnQuitarAnulacion = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "guardar3.png");
            this.imageList1.Images.SetKeyName(1, "cerrar.bmp");
            this.imageList1.Images.SetKeyName(2, "cancelar.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpFecha);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtNumResolucionMotivo);
            this.groupBox2.Location = new System.Drawing.Point(12, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 64);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(365, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(368, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(132, 20);
            this.dtpFecha.TabIndex = 9;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nº Resuloción/Motivo";
            // 
            // txtNumResolucionMotivo
            // 
            this.txtNumResolucionMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumResolucionMotivo.Location = new System.Drawing.Point(9, 32);
            this.txtNumResolucionMotivo.Name = "txtNumResolucionMotivo";
            this.txtNumResolucionMotivo.Size = new System.Drawing.Size(341, 20);
            this.txtNumResolucionMotivo.TabIndex = 8;
            this.txtNumResolucionMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumResolucionMotivo_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNumDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbTipoIdentificacion);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 337);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.ImageIndex = 10;
            this.button1.ImageList = this.imageList2;
            this.button1.Location = new System.Drawing.Point(327, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 31);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 119);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(748, 212);
            this.dataGridView1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(212, 93);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(185, 20);
            this.txtTelefono.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(9, 93);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(185, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Enabled = false;
            this.txtApellido.Location = new System.Drawing.Point(563, 53);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(187, 20);
            this.txtApellido.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(378, 53);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(178, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Número Documento";
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Location = new System.Drawing.Point(159, 53);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(162, 20);
            this.txtNumDocumento.TabIndex = 2;
            this.txtNumDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumDocumento_KeyDown);
            this.txtNumDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumDocumento_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Identificación";
            // 
            // cmbTipoIdentificacion
            // 
            this.cmbTipoIdentificacion.DisplayMember = "DESCRIPCION";
            this.cmbTipoIdentificacion.FormattingEnabled = true;
            this.cmbTipoIdentificacion.Location = new System.Drawing.Point(9, 53);
            this.cmbTipoIdentificacion.Name = "cmbTipoIdentificacion";
            this.cmbTipoIdentificacion.Size = new System.Drawing.Size(145, 21);
            this.cmbTipoIdentificacion.TabIndex = 1;
            this.cmbTipoIdentificacion.ValueMember = "ID_DOCCOMP";
            this.cmbTipoIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoIdentificacion_KeyPress);
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnExit);
            this.buttons.Controls.Add(this.btnQuitarAnulacion);
            this.buttons.Location = new System.Drawing.Point(557, 371);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(215, 43);
            this.buttons.TabIndex = 10;
            this.buttons.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 2;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(148, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 28);
            this.btnExit.TabIndex = 4;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnQuitarAnulacion
            // 
            this.btnQuitarAnulacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarAnulacion.ImageIndex = 0;
            this.btnQuitarAnulacion.ImageList = this.imageList1;
            this.btnQuitarAnulacion.Location = new System.Drawing.Point(6, 11);
            this.btnQuitarAnulacion.Name = "btnQuitarAnulacion";
            this.btnQuitarAnulacion.Size = new System.Drawing.Size(136, 28);
            this.btnQuitarAnulacion.TabIndex = 3;
            this.btnQuitarAnulacion.TabStop = false;
            this.btnQuitarAnulacion.Text = "&Deshacer Anulación";
            this.btnQuitarAnulacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitarAnulacion.UseVisualStyleBackColor = true;
            this.btnQuitarAnulacion.Click += new System.EventHandler(this.btnEliminarAcuerdo_Click);
            // 
            // FrmCancelacionAnulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 431);
            this.Controls.Add(this.buttons);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCancelacionAnulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cancelar Anulación Comparendo";
            this.Load += new System.EventHandler(this.FrmCancelacionAnulacion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumResolucionMotivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoIdentificacion;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnQuitarAnulacion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList2;

    }
}