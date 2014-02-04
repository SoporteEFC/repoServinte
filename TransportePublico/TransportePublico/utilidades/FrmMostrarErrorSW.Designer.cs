namespace TransportePublico.utilidades
{
    partial class FrmMostrarErrorSW
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMensajeAmigable = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPosibleSolucion = new System.Windows.Forms.RichTextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtExcepcion = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcionRapida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoServicio = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMensajeAmigable);
            this.groupBox1.Location = new System.Drawing.Point(12, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensaje de error amigable";
            // 
            // txtMensajeAmigable
            // 
            this.txtMensajeAmigable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMensajeAmigable.Location = new System.Drawing.Point(3, 16);
            this.txtMensajeAmigable.Name = "txtMensajeAmigable";
            this.txtMensajeAmigable.Size = new System.Drawing.Size(345, 282);
            this.txtMensajeAmigable.TabIndex = 0;
            this.txtMensajeAmigable.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPosibleSolucion);
            this.groupBox2.Location = new System.Drawing.Point(369, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 301);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Posible Solución";
            // 
            // txtPosibleSolucion
            // 
            this.txtPosibleSolucion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPosibleSolucion.Location = new System.Drawing.Point(3, 16);
            this.txtPosibleSolucion.Name = "txtPosibleSolucion";
            this.txtPosibleSolucion.Size = new System.Drawing.Size(345, 282);
            this.txtPosibleSolucion.TabIndex = 2;
            this.txtPosibleSolucion.Text = "";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(366, 487);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(89, 31);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(271, 487);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 31);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtExcepcion);
            this.groupBox3.Location = new System.Drawing.Point(15, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(702, 118);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Excepción";
            // 
            // txtExcepcion
            // 
            this.txtExcepcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExcepcion.Location = new System.Drawing.Point(3, 16);
            this.txtExcepcion.Name = "txtExcepcion";
            this.txtExcepcion.Size = new System.Drawing.Size(696, 99);
            this.txtExcepcion.TabIndex = 1;
            this.txtExcepcion.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Descripción Rápida";
            // 
            // txtDescripcionRapida
            // 
            this.txtDescripcionRapida.Location = new System.Drawing.Point(20, 31);
            this.txtDescripcionRapida.Name = "txtDescripcionRapida";
            this.txtDescripcionRapida.Size = new System.Drawing.Size(445, 20);
            this.txtDescripcionRapida.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripción Rápida";
            // 
            // cmbTipoServicio
            // 
            this.cmbTipoServicio.FormattingEnabled = true;
            this.cmbTipoServicio.Items.AddRange(new object[] {
            "LOCAL",
            "RUNT"});
            this.cmbTipoServicio.Location = new System.Drawing.Point(480, 29);
            this.cmbTipoServicio.Name = "cmbTipoServicio";
            this.cmbTipoServicio.Size = new System.Drawing.Size(234, 21);
            this.cmbTipoServicio.TabIndex = 9;
            // 
            // FrmMostrarErrorSW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 527);
            this.Controls.Add(this.cmbTipoServicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescripcionRapida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMostrarErrorSW";
            this.Text = "Error En Servicios Web";
            this.Load += new System.EventHandler(this.FrmMostrarErrorSW_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtMensajeAmigable;
        private System.Windows.Forms.RichTextBox txtPosibleSolucion;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtExcepcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcionRapida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoServicio;
    }
}