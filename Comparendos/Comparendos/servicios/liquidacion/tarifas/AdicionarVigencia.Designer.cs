namespace Comparendos
{
    partial class AdicionarVigencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarVigencia));
            this.tipos = new System.Windows.Forms.GroupBox();
            this.impuesto = new System.Windows.Forms.RadioButton();
            this.tramite = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.vigencia = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.acciones = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tipos.SuspendLayout();
            this.acciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipos
            // 
            this.tipos.Controls.Add(this.impuesto);
            this.tipos.Controls.Add(this.tramite);
            this.tipos.Location = new System.Drawing.Point(26, 12);
            this.tipos.Name = "tipos";
            this.tipos.Size = new System.Drawing.Size(128, 69);
            this.tipos.TabIndex = 0;
            this.tipos.TabStop = false;
            this.tipos.Text = "[Tipo]";
            // 
            // impuesto
            // 
            this.impuesto.AutoSize = true;
            this.impuesto.Location = new System.Drawing.Point(6, 42);
            this.impuesto.Name = "impuesto";
            this.impuesto.Size = new System.Drawing.Size(68, 17);
            this.impuesto.TabIndex = 2;
            this.impuesto.TabStop = true;
            this.impuesto.Text = "Impuesto";
            this.impuesto.UseVisualStyleBackColor = true;
            this.impuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.impuesto_KeyPress);
            // 
            // tramite
            // 
            this.tramite.AutoSize = true;
            this.tramite.Location = new System.Drawing.Point(6, 19);
            this.tramite.Name = "tramite";
            this.tramite.Size = new System.Drawing.Size(60, 17);
            this.tramite.TabIndex = 1;
            this.tramite.TabStop = true;
            this.tramite.Text = "Trámite";
            this.tramite.UseVisualStyleBackColor = true;
            this.tramite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tramite_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vigencia:";
            // 
            // vigencia
            // 
            this.vigencia.Location = new System.Drawing.Point(26, 106);
            this.vigencia.Name = "vigencia";
            this.vigencia.Size = new System.Drawing.Size(128, 20);
            this.vigencia.TabIndex = 3;
            this.vigencia.TextChanged += new System.EventHandler(this.vigencia_TextChanged);
            this.vigencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vigencia_KeyPress);
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
            this.acciones.Controls.Add(this.btnOk);
            this.acciones.Controls.Add(this.btnCancel);
            this.acciones.Location = new System.Drawing.Point(177, 12);
            this.acciones.Name = "acciones";
            this.acciones.Size = new System.Drawing.Size(82, 145);
            this.acciones.TabIndex = 5;
            this.acciones.TabStop = false;
            this.acciones.Text = "Acciones";
            // 
            // btnOk
            // 
            this.btnOk.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.Image")));
            this.btnOk.Location = new System.Drawing.Point(21, 25);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(42, 42);
            this.btnOk.TabIndex = 31;
            this.btnOk.TabStop = false;
            this.toolTip1.SetToolTip(this.btnOk, "Guardar Vigencia");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ImageIndex = 11;
            this.btnCancel.ImageList = this.imageList1;
            this.btnCancel.Location = new System.Drawing.Point(21, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(42, 42);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCancel, "Salir");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // modificar
            // 
            this.modificar.AutoSize = true;
            this.modificar.Location = new System.Drawing.Point(26, 140);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(69, 17);
            this.modificar.TabIndex = 4;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.modificar_KeyPress);
            // 
            // AdicionarVigencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.acciones);
            this.Controls.Add(this.vigencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tipos);
            this.Name = "AdicionarVigencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Vigencia]";
            this.Load += new System.EventHandler(this.AdicionarVigencia_Load);
            this.tipos.ResumeLayout(false);
            this.tipos.PerformLayout();
            this.acciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tipos;
        private System.Windows.Forms.RadioButton tramite;
        private System.Windows.Forms.RadioButton impuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vigencia;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox acciones;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox modificar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}