namespace Comparendos.servicios.generales
{
    partial class infraccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(infraccion));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contenedorinfraccion = new System.Windows.Forms.GroupBox();
            this.reportarsimit = new System.Windows.Forms.CheckBox();
            this.fechahasta = new System.Windows.Forms.DateTimePicker();
            this.fechadesde = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nuevocodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numerosalarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.codigoinfraccion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.contenedorinfraccion.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
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
            // contenedorinfraccion
            // 
            this.contenedorinfraccion.Controls.Add(this.cmbEstado);
            this.contenedorinfraccion.Controls.Add(this.reportarsimit);
            this.contenedorinfraccion.Controls.Add(this.fechahasta);
            this.contenedorinfraccion.Controls.Add(this.fechadesde);
            this.contenedorinfraccion.Controls.Add(this.label6);
            this.contenedorinfraccion.Controls.Add(this.label7);
            this.contenedorinfraccion.Controls.Add(this.nuevocodigo);
            this.contenedorinfraccion.Controls.Add(this.label5);
            this.contenedorinfraccion.Controls.Add(this.label4);
            this.contenedorinfraccion.Controls.Add(this.descripcion);
            this.contenedorinfraccion.Controls.Add(this.label3);
            this.contenedorinfraccion.Controls.Add(this.numerosalarios);
            this.contenedorinfraccion.Controls.Add(this.label2);
            this.contenedorinfraccion.Controls.Add(this.codigoinfraccion);
            this.contenedorinfraccion.Controls.Add(this.label1);
            this.contenedorinfraccion.Location = new System.Drawing.Point(12, 12);
            this.contenedorinfraccion.Name = "contenedorinfraccion";
            this.contenedorinfraccion.Size = new System.Drawing.Size(369, 273);
            this.contenedorinfraccion.TabIndex = 30;
            this.contenedorinfraccion.TabStop = false;
            this.contenedorinfraccion.Text = "Infracción";
            // 
            // reportarsimit
            // 
            this.reportarsimit.AutoSize = true;
            this.reportarsimit.Location = new System.Drawing.Point(242, 241);
            this.reportarsimit.Name = "reportarsimit";
            this.reportarsimit.Size = new System.Drawing.Size(116, 17);
            this.reportarsimit.TabIndex = 8;
            this.reportarsimit.Text = "Reportar al SIMIT?";
            this.reportarsimit.UseVisualStyleBackColor = true;
            this.reportarsimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.reportarsimit_KeyPress);
            // 
            // fechahasta
            // 
            this.fechahasta.CustomFormat = "dd/MM/yyyy";
            this.fechahasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechahasta.Location = new System.Drawing.Point(121, 238);
            this.fechahasta.Name = "fechahasta";
            this.fechahasta.Size = new System.Drawing.Size(106, 20);
            this.fechahasta.TabIndex = 7;
            this.fechahasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fechahasta_KeyPress);
            // 
            // fechadesde
            // 
            this.fechadesde.CustomFormat = "dd/MM/yyyy";
            this.fechadesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fechadesde.Location = new System.Drawing.Point(9, 238);
            this.fechadesde.Name = "fechadesde";
            this.fechadesde.Size = new System.Drawing.Size(106, 20);
            this.fechadesde.TabIndex = 6;
            this.fechadesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fechadesde_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Desde:";
            // 
            // nuevocodigo
            // 
            this.nuevocodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nuevocodigo.Location = new System.Drawing.Point(121, 189);
            this.nuevocodigo.Name = "nuevocodigo";
            this.nuevocodigo.Size = new System.Drawing.Size(106, 20);
            this.nuevocodigo.TabIndex = 5;
            this.nuevocodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nuevocodigo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nuevo Código:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estado:";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(9, 81);
            this.descripcion.Multiline = true;
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(349, 80);
            this.descripcion.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción:";
            // 
            // numerosalarios
            // 
            this.numerosalarios.Location = new System.Drawing.Point(121, 33);
            this.numerosalarios.Name = "numerosalarios";
            this.numerosalarios.Size = new System.Drawing.Size(106, 20);
            this.numerosalarios.TabIndex = 2;
            this.numerosalarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numerosalarios_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Número Salarios:";
            // 
            // codigoinfraccion
            // 
            this.codigoinfraccion.Location = new System.Drawing.Point(9, 33);
            this.codigoinfraccion.Name = "codigoinfraccion";
            this.codigoinfraccion.Size = new System.Drawing.Size(106, 20);
            this.codigoinfraccion.TabIndex = 1;
            this.codigoinfraccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoinfraccion_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnExit);
            this.buttons.Controls.Add(this.btnSave);
            this.buttons.Location = new System.Drawing.Point(115, 289);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(162, 43);
            this.buttons.TabIndex = 31;
            this.buttons.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(93, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 28);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(6, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "s",
            "n"});
            this.cmbEstado.Location = new System.Drawing.Point(9, 187);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(106, 21);
            this.cmbEstado.TabIndex = 13;
            // 
            // infraccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 341);
            this.Controls.Add(this.buttons);
            this.Controls.Add(this.contenedorinfraccion);
            this.Name = "infraccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Infracción]";
            this.contenedorinfraccion.ResumeLayout(false);
            this.contenedorinfraccion.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox contenedorinfraccion;
        private System.Windows.Forms.CheckBox reportarsimit;
        private System.Windows.Forms.DateTimePicker fechahasta;
        private System.Windows.Forms.DateTimePicker fechadesde;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox nuevocodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numerosalarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox codigoinfraccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}