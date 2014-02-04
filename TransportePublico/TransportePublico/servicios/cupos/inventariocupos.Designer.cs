namespace TransportePublico.servicios.cupos
{
    partial class inventariocupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inventariocupos));
            this.contenedordatoscupo = new System.Windows.Forms.GroupBox();
            this.rangofinal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rangoinicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipovehiculo = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.contenedordatoscupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // contenedordatoscupo
            // 
            this.contenedordatoscupo.Controls.Add(this.rangofinal);
            this.contenedordatoscupo.Controls.Add(this.label3);
            this.contenedordatoscupo.Controls.Add(this.rangoinicial);
            this.contenedordatoscupo.Controls.Add(this.label1);
            this.contenedordatoscupo.Controls.Add(this.label2);
            this.contenedordatoscupo.Controls.Add(this.tipovehiculo);
            this.contenedordatoscupo.Location = new System.Drawing.Point(12, 12);
            this.contenedordatoscupo.Name = "contenedordatoscupo";
            this.contenedordatoscupo.Size = new System.Drawing.Size(261, 100);
            this.contenedordatoscupo.TabIndex = 0;
            this.contenedordatoscupo.TabStop = false;
            this.contenedordatoscupo.Text = "Datos Cupos";
            // 
            // rangofinal
            // 
            this.rangofinal.Location = new System.Drawing.Point(140, 74);
            this.rangofinal.Name = "rangofinal";
            this.rangofinal.Size = new System.Drawing.Size(109, 20);
            this.rangofinal.TabIndex = 3;
            this.rangofinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangofinal_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Rango Final:";
            // 
            // rangoinicial
            // 
            this.rangoinicial.Location = new System.Drawing.Point(9, 74);
            this.rangoinicial.Name = "rangoinicial";
            this.rangoinicial.Size = new System.Drawing.Size(109, 20);
            this.rangoinicial.TabIndex = 2;
            this.rangoinicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangoinicial_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Rango Inicial:";
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
            this.tipovehiculo.Size = new System.Drawing.Size(241, 21);
            this.tipovehiculo.TabIndex = 1;
            this.tipovehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipovehiculo_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 0;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(141, 127);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 28);
            this.btnExit.TabIndex = 6;
            this.btnExit.TabStop = false;
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
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(59, 127);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 28);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // inventariocupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 167);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.contenedordatoscupo);
            this.Name = "inventariocupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Rangos";
            this.Load += new System.EventHandler(this.inventariocupos_Load);
            this.contenedordatoscupo.ResumeLayout(false);
            this.contenedordatoscupo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox contenedordatoscupo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipovehiculo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rangoinicial;
        private System.Windows.Forms.TextBox rangofinal;
    }
}