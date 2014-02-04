namespace Comparendos.servicios.documentos
{
    partial class ResolRevocatoria
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
            this.grpBoxInfoInfrac = new System.Windows.Forms.GroupBox();
            this.btn = new System.Windows.Forms.Button();
            this.cmbBoxPlantillas = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtInfractor = new System.Windows.Forms.TextBox();
            this.lblInfractor = new System.Windows.Forms.Label();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.lblTipoResol = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.cmbBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPickFechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPickFechaAudiencia = new System.Windows.Forms.DateTimePicker();
            this.lblFecAudi = new System.Windows.Forms.Label();
            this.txtNumResol = new System.Windows.Forms.TextBox();
            this.lblNumResol = new System.Windows.Forms.Label();
            this.btnGenerarResolucion = new System.Windows.Forms.Button();
            this.dtGrViewComparendos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSolicitudRevocatoria = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHechosRevocatoria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMotivoRevocatoria = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpBoxInfoInfrac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewComparendos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxInfoInfrac
            // 
            this.grpBoxInfoInfrac.Controls.Add(this.btn);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbBoxPlantillas);
            this.grpBoxInfoInfrac.Controls.Add(this.txtTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.txtInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTipoResol);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDocumento);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbBoxTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDocumento);
            this.grpBoxInfoInfrac.Location = new System.Drawing.Point(12, 12);
            this.grpBoxInfoInfrac.Name = "grpBoxInfoInfrac";
            this.grpBoxInfoInfrac.Size = new System.Drawing.Size(1093, 100);
            this.grpBoxInfoInfrac.TabIndex = 36;
            this.grpBoxInfoInfrac.TabStop = false;
            this.grpBoxInfoInfrac.Text = "Información del Infractor";
            // 
            // btn
            // 
            this.btn.Image = global::Comparendos.Properties.Resources.search;
            this.btn.Location = new System.Drawing.Point(492, 13);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(39, 41);
            this.btn.TabIndex = 9;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // cmbBoxPlantillas
            // 
            this.cmbBoxPlantillas.DisplayMember = "NOMBRE";
            this.cmbBoxPlantillas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxPlantillas.FormattingEnabled = true;
            this.cmbBoxPlantillas.Location = new System.Drawing.Point(704, 23);
            this.cmbBoxPlantillas.Name = "cmbBoxPlantillas";
            this.cmbBoxPlantillas.Size = new System.Drawing.Size(243, 21);
            this.cmbBoxPlantillas.TabIndex = 3;
            this.cmbBoxPlantillas.ValueMember = "ID";
            this.cmbBoxPlantillas.SelectedIndexChanged += new System.EventHandler(this.cmbBoxPlantillas_SelectedIndexChanged);
            this.cmbBoxPlantillas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxPlantillas_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(836, 60);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(111, 20);
            this.txtTelefono.TabIndex = 0;
            this.txtTelefono.TabStop = false;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(769, 63);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(460, 60);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(285, 20);
            this.txtDireccion.TabIndex = 0;
            this.txtDireccion.TabStop = false;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(389, 63);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 13);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtInfractor
            // 
            this.txtInfractor.Enabled = false;
            this.txtInfractor.Location = new System.Drawing.Point(80, 60);
            this.txtInfractor.Name = "txtInfractor";
            this.txtInfractor.Size = new System.Drawing.Size(283, 20);
            this.txtInfractor.TabIndex = 0;
            this.txtInfractor.TabStop = false;
            // 
            // lblInfractor
            // 
            this.lblInfractor.AutoSize = true;
            this.lblInfractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfractor.Location = new System.Drawing.Point(15, 63);
            this.lblInfractor.Name = "lblInfractor";
            this.lblInfractor.Size = new System.Drawing.Size(59, 13);
            this.lblInfractor.TabIndex = 4;
            this.lblInfractor.Text = "Infractor:";
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(15, 26);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(104, 13);
            this.lblTipoDoc.TabIndex = 0;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // lblTipoResol
            // 
            this.lblTipoResol.AutoSize = true;
            this.lblTipoResol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoResol.Location = new System.Drawing.Point(642, 26);
            this.lblTipoResol.Name = "lblTipoResol";
            this.lblTipoResol.Size = new System.Drawing.Size(56, 13);
            this.lblTipoResol.TabIndex = 8;
            this.lblTipoResol.Text = "Plantilla:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(369, 23);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(117, 20);
            this.txtDocumento.TabIndex = 2;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // cmbBoxTipoDoc
            // 
            this.cmbBoxTipoDoc.DisplayMember = "DESCRIPCION";
            this.cmbBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTipoDoc.FormattingEnabled = true;
            this.cmbBoxTipoDoc.Location = new System.Drawing.Point(125, 23);
            this.cmbBoxTipoDoc.Name = "cmbBoxTipoDoc";
            this.cmbBoxTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxTipoDoc.TabIndex = 1;
            this.cmbBoxTipoDoc.TabStop = false;
            this.cmbBoxTipoDoc.ValueMember = "IDREPORTECOMPARENDO";
            this.cmbBoxTipoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxTipoDoc_KeyPress);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(268, 26);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(99, 13);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "No. Documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 581);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Presione Enter para verificar el número de resolución.";
            // 
            // dtPickFechaResolucion
            // 
            this.dtPickFechaResolucion.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaResolucion.Location = new System.Drawing.Point(137, 630);
            this.dtPickFechaResolucion.Name = "dtPickFechaResolucion";
            this.dtPickFechaResolucion.Size = new System.Drawing.Size(103, 20);
            this.dtPickFechaResolucion.TabIndex = 30;
            this.dtPickFechaResolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaResolucion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 634);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Fecha Resolución:";
            // 
            // dtPickFechaAudiencia
            // 
            this.dtPickFechaAudiencia.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaAudiencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaAudiencia.Location = new System.Drawing.Point(137, 604);
            this.dtPickFechaAudiencia.Name = "dtPickFechaAudiencia";
            this.dtPickFechaAudiencia.Size = new System.Drawing.Size(103, 20);
            this.dtPickFechaAudiencia.TabIndex = 29;
            this.dtPickFechaAudiencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaAudiencia_KeyPress);
            // 
            // lblFecAudi
            // 
            this.lblFecAudi.AutoSize = true;
            this.lblFecAudi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecAudi.Location = new System.Drawing.Point(27, 608);
            this.lblFecAudi.Name = "lblFecAudi";
            this.lblFecAudi.Size = new System.Drawing.Size(106, 13);
            this.lblFecAudi.TabIndex = 32;
            this.lblFecAudi.Text = "Fecha Audiencia:";
            // 
            // txtNumResol
            // 
            this.txtNumResol.Location = new System.Drawing.Point(137, 578);
            this.txtNumResol.Name = "txtNumResol";
            this.txtNumResol.Size = new System.Drawing.Size(103, 20);
            this.txtNumResol.TabIndex = 28;
            this.txtNumResol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumResol_KeyDown_1);
            this.txtNumResol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumResol_KeyPress);
            // 
            // lblNumResol
            // 
            this.lblNumResol.AutoSize = true;
            this.lblNumResol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumResol.Location = new System.Drawing.Point(12, 582);
            this.lblNumResol.Name = "lblNumResol";
            this.lblNumResol.Size = new System.Drawing.Size(121, 13);
            this.lblNumResol.TabIndex = 31;
            this.lblNumResol.Text = "Número Resolución:";
            // 
            // btnGenerarResolucion
            // 
            this.btnGenerarResolucion.ImageIndex = 5;
            this.btnGenerarResolucion.Location = new System.Drawing.Point(961, 598);
            this.btnGenerarResolucion.Name = "btnGenerarResolucion";
            this.btnGenerarResolucion.Size = new System.Drawing.Size(129, 32);
            this.btnGenerarResolucion.TabIndex = 27;
            this.btnGenerarResolucion.TabStop = false;
            this.btnGenerarResolucion.Text = "&Generar Resolución";
            this.btnGenerarResolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerarResolucion.UseVisualStyleBackColor = true;
            this.btnGenerarResolucion.Click += new System.EventHandler(this.btnGenerarResolucion_Click);
            // 
            // dtGrViewComparendos
            // 
            this.dtGrViewComparendos.AllowUserToAddRows = false;
            this.dtGrViewComparendos.AllowUserToDeleteRows = false;
            this.dtGrViewComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrViewComparendos.Location = new System.Drawing.Point(12, 118);
            this.dtGrViewComparendos.Name = "dtGrViewComparendos";
            this.dtGrViewComparendos.ReadOnly = true;
            this.dtGrViewComparendos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrViewComparendos.Size = new System.Drawing.Size(1093, 235);
            this.dtGrViewComparendos.TabIndex = 26;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSolicitudRevocatoria);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHechosRevocatoria);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMotivoRevocatoria);
            this.groupBox1.Location = new System.Drawing.Point(12, 359);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1093, 213);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consideraciones Despacho";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Solicitud de Revocatoria:";
            // 
            // txtSolicitudRevocatoria
            // 
            this.txtSolicitudRevocatoria.Location = new System.Drawing.Point(139, 152);
            this.txtSolicitudRevocatoria.Multiline = true;
            this.txtSolicitudRevocatoria.Name = "txtSolicitudRevocatoria";
            this.txtSolicitudRevocatoria.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtSolicitudRevocatoria.Size = new System.Drawing.Size(919, 55);
            this.txtSolicitudRevocatoria.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Hechos  Revocatoria:";
            // 
            // txtHechosRevocatoria
            // 
            this.txtHechosRevocatoria.Location = new System.Drawing.Point(139, 86);
            this.txtHechosRevocatoria.Multiline = true;
            this.txtHechosRevocatoria.Name = "txtHechosRevocatoria";
            this.txtHechosRevocatoria.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtHechosRevocatoria.Size = new System.Drawing.Size(919, 60);
            this.txtHechosRevocatoria.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Motivo Revocatoria:";
            // 
            // txtMotivoRevocatoria
            // 
            this.txtMotivoRevocatoria.Location = new System.Drawing.Point(139, 22);
            this.txtMotivoRevocatoria.Multiline = true;
            this.txtMotivoRevocatoria.Name = "txtMotivoRevocatoria";
            this.txtMotivoRevocatoria.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtMotivoRevocatoria.Size = new System.Drawing.Size(919, 58);
            this.txtMotivoRevocatoria.TabIndex = 8;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ResolRevocatoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 659);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxInfoInfrac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPickFechaResolucion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPickFechaAudiencia);
            this.Controls.Add(this.lblFecAudi);
            this.Controls.Add(this.txtNumResol);
            this.Controls.Add(this.lblNumResol);
            this.Controls.Add(this.btnGenerarResolucion);
            this.Controls.Add(this.dtGrViewComparendos);
            this.Name = "ResolRevocatoria";
            this.Text = "Resolución Revocatoria";
            this.Load += new System.EventHandler(this.ResolRevocatoria_Load_1);
            this.grpBoxInfoInfrac.ResumeLayout(false);
            this.grpBoxInfoInfrac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewComparendos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxInfoInfrac;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.ComboBox cmbBoxPlantillas;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtInfractor;
        private System.Windows.Forms.Label lblInfractor;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.Label lblTipoResol;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.ComboBox cmbBoxTipoDoc;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtPickFechaResolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPickFechaAudiencia;
        private System.Windows.Forms.Label lblFecAudi;
        private System.Windows.Forms.TextBox txtNumResol;
        private System.Windows.Forms.Label lblNumResol;
        private System.Windows.Forms.Button btnGenerarResolucion;
        private System.Windows.Forms.DataGridView dtGrViewComparendos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSolicitudRevocatoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHechosRevocatoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMotivoRevocatoria;
        private System.Windows.Forms.ImageList imageList1;
    }
}