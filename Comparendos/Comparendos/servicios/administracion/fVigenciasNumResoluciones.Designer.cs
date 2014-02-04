namespace Comparendos.servicios.administracion
{
    partial class fVigenciasNumResoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fVigenciasNumResoluciones));
            this.grdVigencias = new System.Windows.Forms.DataGridView();
            this.lblVigencias = new System.Windows.Forms.Label();
            this.grbDetalleVigencia = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNuevaVigencia = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtNumResolucionInicio = new System.Windows.Forms.TextBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.lblNumResolucionInicio = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdVigencias)).BeginInit();
            this.grbDetalleVigencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdVigencias
            // 
            this.grdVigencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVigencias.Location = new System.Drawing.Point(12, 36);
            this.grdVigencias.Name = "grdVigencias";
            this.grdVigencias.ReadOnly = true;
            this.grdVigencias.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdVigencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdVigencias.Size = new System.Drawing.Size(399, 214);
            this.grdVigencias.TabIndex = 0;
            this.grdVigencias.SelectionChanged += new System.EventHandler(this.grdVigencias_SelectionChanged);
            // 
            // lblVigencias
            // 
            this.lblVigencias.AutoSize = true;
            this.lblVigencias.Location = new System.Drawing.Point(12, 17);
            this.lblVigencias.Name = "lblVigencias";
            this.lblVigencias.Size = new System.Drawing.Size(93, 13);
            this.lblVigencias.TabIndex = 1;
            this.lblVigencias.Text = "Lista de Vigencias";
            // 
            // grbDetalleVigencia
            // 
            this.grbDetalleVigencia.Controls.Add(this.btnEliminar);
            this.grbDetalleVigencia.Controls.Add(this.btnCancelar);
            this.grbDetalleVigencia.Controls.Add(this.btnNuevaVigencia);
            this.grbDetalleVigencia.Controls.Add(this.btnGuardar);
            this.grbDetalleVigencia.Controls.Add(this.btnEditar);
            this.grbDetalleVigencia.Controls.Add(this.txtNumResolucionInicio);
            this.grbDetalleVigencia.Controls.Add(this.txtAno);
            this.grbDetalleVigencia.Controls.Add(this.lblNumResolucionInicio);
            this.grbDetalleVigencia.Controls.Add(this.lblAno);
            this.grbDetalleVigencia.Location = new System.Drawing.Point(430, 36);
            this.grbDetalleVigencia.Name = "grbDetalleVigencia";
            this.grbDetalleVigencia.Size = new System.Drawing.Size(359, 214);
            this.grbDetalleVigencia.TabIndex = 2;
            this.grbDetalleVigencia.TabStop = false;
            this.grbDetalleVigencia.Text = "Detalle Vigencia";
            // 
            // btnEliminar
            // 
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.ImageIndex = 9;
            this.btnEliminar.ImageList = this.imageList1;
            this.btnEliminar.Location = new System.Drawing.Point(119, 103);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(109, 26);
            this.btnEliminar.TabIndex = 14;
            this.btnEliminar.Text = "&Eliminar Vigencia";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.imageList1.Images.SetKeyName(13, "car.ico");
            this.imageList1.Images.SetKeyName(14, "user.png");
            this.imageList1.Images.SetKeyName(15, "edit.png");
            this.imageList1.Images.SetKeyName(16, "filesave.ico");
            this.imageList1.Images.SetKeyName(17, "star.png");
            this.imageList1.Images.SetKeyName(18, "busy.png");
            this.imageList1.Images.SetKeyName(19, "cancel.png");
            this.imageList1.Images.SetKeyName(20, "edit.gif");
            this.imageList1.Images.SetKeyName(21, "edit.png");
            this.imageList1.Images.SetKeyName(22, "eliminar.png");
            this.imageList1.Images.SetKeyName(23, "guardar.png");
            this.imageList1.Images.SetKeyName(24, "nuevo.png");
            this.imageList1.Images.SetKeyName(25, "nuevoTramite.png");
            // 
            // btnCancelar
            // 
            this.btnCancelar.CausesValidation = false;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "cancel.png";
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(178, 147);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 26);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNuevaVigencia
            // 
            this.btnNuevaVigencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaVigencia.ImageIndex = 8;
            this.btnNuevaVigencia.ImageList = this.imageList1;
            this.btnNuevaVigencia.Location = new System.Drawing.Point(234, 103);
            this.btnNuevaVigencia.Name = "btnNuevaVigencia";
            this.btnNuevaVigencia.Size = new System.Drawing.Size(106, 26);
            this.btnNuevaVigencia.TabIndex = 15;
            this.btnNuevaVigencia.Text = "&Nueva Vigencia";
            this.btnNuevaVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaVigencia.UseVisualStyleBackColor = true;
            this.btnNuevaVigencia.Click += new System.EventHandler(this.btnNuevaVigencia_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.ImageKey = "guardar.png";
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(97, 147);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 26);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.ImageIndex = 15;
            this.btnEditar.ImageList = this.imageList1;
            this.btnEditar.Location = new System.Drawing.Point(7, 103);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(106, 26);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Editar &Vigencia";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // txtNumResolucionInicio
            // 
            this.txtNumResolucionInicio.Location = new System.Drawing.Point(179, 56);
            this.txtNumResolucionInicio.Name = "txtNumResolucionInicio";
            this.txtNumResolucionInicio.Size = new System.Drawing.Size(100, 20);
            this.txtNumResolucionInicio.TabIndex = 3;
            this.txtNumResolucionInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumResolucionInicio_KeyPress);
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(179, 29);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(100, 20);
            this.txtAno.TabIndex = 2;
            // 
            // lblNumResolucionInicio
            // 
            this.lblNumResolucionInicio.AutoSize = true;
            this.lblNumResolucionInicio.Location = new System.Drawing.Point(54, 59);
            this.lblNumResolucionInicio.Name = "lblNumResolucionInicio";
            this.lblNumResolucionInicio.Size = new System.Drawing.Size(119, 13);
            this.lblNumResolucionInicio.TabIndex = 1;
            this.lblNumResolucionInicio.Text = "Núm. Resolución Inicio:";
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(144, 32);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(29, 13);
            this.lblAno.TabIndex = 0;
            this.lblAno.Text = "Año:";
            // 
            // fVigenciasNumResoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 262);
            this.Controls.Add(this.grbDetalleVigencia);
            this.Controls.Add(this.lblVigencias);
            this.Controls.Add(this.grdVigencias);
            this.Name = "fVigenciasNumResoluciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vigencias y Numeración Resoluciones";
            ((System.ComponentModel.ISupportInitialize)(this.grdVigencias)).EndInit();
            this.grbDetalleVigencia.ResumeLayout(false);
            this.grbDetalleVigencia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdVigencias;
        private System.Windows.Forms.Label lblVigencias;
        private System.Windows.Forms.GroupBox grbDetalleVigencia;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevaVigencia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtNumResolucionInicio;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Label lblNumResolucionInicio;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.ImageList imageList1;
    }
}