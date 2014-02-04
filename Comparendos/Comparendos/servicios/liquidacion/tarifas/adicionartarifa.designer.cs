namespace Comparendos
{
    partial class AdicionarTarifa
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarTarifa));
            this.tipotarifa = new System.Windows.Forms.GroupBox();
            this.rbtTramite = new System.Windows.Forms.RadioButton();
            this.rbtImpuesto = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreTarifa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVigencia = new System.Windows.Forms.TextBox();
            this.cmbTramiteAsociado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.acciones = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkLiquidacionMultiple = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tipotarifa.SuspendLayout();
            this.acciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipotarifa
            // 
            this.tipotarifa.Controls.Add(this.rbtTramite);
            this.tipotarifa.Controls.Add(this.rbtImpuesto);
            this.tipotarifa.Location = new System.Drawing.Point(12, 12);
            this.tipotarifa.Name = "tipotarifa";
            this.tipotarifa.Size = new System.Drawing.Size(82, 74);
            this.tipotarifa.TabIndex = 0;
            this.tipotarifa.TabStop = false;
            this.tipotarifa.Text = "Tipo";
            // 
            // rbtTramite
            // 
            this.rbtTramite.AutoSize = true;
            this.rbtTramite.Location = new System.Drawing.Point(8, 21);
            this.rbtTramite.Name = "rbtTramite";
            this.rbtTramite.Size = new System.Drawing.Size(60, 17);
            this.rbtTramite.TabIndex = 1;
            this.rbtTramite.TabStop = true;
            this.rbtTramite.Text = "Trámite";
            this.rbtTramite.UseVisualStyleBackColor = true;
            this.rbtTramite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tramite_KeyPress);
            // 
            // rbtImpuesto
            // 
            this.rbtImpuesto.AutoSize = true;
            this.rbtImpuesto.Location = new System.Drawing.Point(8, 44);
            this.rbtImpuesto.Name = "rbtImpuesto";
            this.rbtImpuesto.Size = new System.Drawing.Size(68, 17);
            this.rbtImpuesto.TabIndex = 2;
            this.rbtImpuesto.TabStop = true;
            this.rbtImpuesto.Text = "Impuesto";
            this.rbtImpuesto.UseVisualStyleBackColor = true;
            this.rbtImpuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.impuesto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // txtNombreTarifa
            // 
            this.txtNombreTarifa.Location = new System.Drawing.Point(103, 28);
            this.txtNombreTarifa.Name = "txtNombreTarifa";
            this.txtNombreTarifa.Size = new System.Drawing.Size(177, 20);
            this.txtNombreTarifa.TabIndex = 3;
            this.txtNombreTarifa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nombretarifa_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescripcion.Location = new System.Drawing.Point(103, 66);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(266, 59);
            this.txtDescripcion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vigencia";
            this.label3.Visible = false;
            // 
            // txtVigencia
            // 
            this.txtVigencia.Location = new System.Drawing.Point(287, 28);
            this.txtVigencia.Name = "txtVigencia";
            this.txtVigencia.Size = new System.Drawing.Size(82, 20);
            this.txtVigencia.TabIndex = 4;
            this.txtVigencia.Visible = false;
            this.txtVigencia.TextChanged += new System.EventHandler(this.vigentarifa_TextChanged);
            this.txtVigencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vigentarifa_KeyPress);
            // 
            // cmbTramiteAsociado
            // 
            this.cmbTramiteAsociado.DisplayMember = "DESCTRAMITE";
            this.cmbTramiteAsociado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTramiteAsociado.FormattingEnabled = true;
            this.cmbTramiteAsociado.Location = new System.Drawing.Point(103, 151);
            this.cmbTramiteAsociado.Name = "cmbTramiteAsociado";
            this.cmbTramiteAsociado.Size = new System.Drawing.Size(268, 21);
            this.cmbTramiteAsociado.TabIndex = 6;
            this.cmbTramiteAsociado.ValueMember = "IDTRAM_INTERNO";
            this.cmbTramiteAsociado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tramiteasoc_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Trámite Asociado";
            // 
            // acciones
            // 
            this.acciones.Controls.Add(this.btnOk);
            this.acciones.Controls.Add(this.btnCancel);
            this.acciones.Location = new System.Drawing.Point(12, 103);
            this.acciones.Name = "acciones";
            this.acciones.Size = new System.Drawing.Size(82, 135);
            this.acciones.TabIndex = 9;
            this.acciones.TabStop = false;
            this.acciones.Text = "Acciones";
            // 
            // btnOk
            // 
            this.btnOk.ImageIndex = 12;
            this.btnOk.ImageList = this.imageList1;
            this.btnOk.Location = new System.Drawing.Point(20, 32);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(39, 37);
            this.btnOk.TabIndex = 29;
            this.btnOk.TabStop = false;
            this.toolTip1.SetToolTip(this.btnOk, "Guardar Tarifa");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            // btnCancel
            // 
            this.btnCancel.ImageIndex = 11;
            this.btnCancel.ImageList = this.imageList1;
            this.btnCancel.Location = new System.Drawing.Point(20, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(39, 37);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCancel, "Cancelar");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkLiquidacionMultiple
            // 
            this.chkLiquidacionMultiple.AutoSize = true;
            this.chkLiquidacionMultiple.Location = new System.Drawing.Point(103, 195);
            this.chkLiquidacionMultiple.Name = "chkLiquidacionMultiple";
            this.chkLiquidacionMultiple.Size = new System.Drawing.Size(228, 17);
            this.chkLiquidacionMultiple.TabIndex = 8;
            this.chkLiquidacionMultiple.Text = "Se puede liquidar varias veces por factura.";
            this.chkLiquidacionMultiple.UseVisualStyleBackColor = true;
            this.chkLiquidacionMultiple.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.variasliquidaciones_KeyPress);
            // 
            // AdicionarTarifa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 250);
            this.Controls.Add(this.chkLiquidacionMultiple);
            this.Controls.Add(this.acciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTramiteAsociado);
            this.Controls.Add(this.txtVigencia);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreTarifa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tipotarifa);
            this.Name = "AdicionarTarifa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Adicionar Tarifa]";
            this.Load += new System.EventHandler(this.AdicionarTarifa_Load);
            this.tipotarifa.ResumeLayout(false);
            this.tipotarifa.PerformLayout();
            this.acciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tipotarifa;
        private System.Windows.Forms.RadioButton rbtTramite;
        private System.Windows.Forms.RadioButton rbtImpuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreTarifa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVigencia;
        private System.Windows.Forms.ComboBox cmbTramiteAsociado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox acciones;
        private System.Windows.Forms.CheckBox chkLiquidacionMultiple;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

