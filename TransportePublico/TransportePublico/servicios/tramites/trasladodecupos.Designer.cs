namespace TransportePublico.servicios.tramites
{
    partial class trasladodecupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trasladodecupos));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.contenedordatoscupo = new System.Windows.Forms.GroupBox();
            this.numerocupo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tipovehiculo = new System.Windows.Forms.ComboBox();
            this.btnbuscarempresa = new System.Windows.Forms.Button();
            this.nombreempresa = new System.Windows.Forms.TextBox();
            this.siglaempresa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_SearchDestino = new System.Windows.Forms.Button();
            this.nombredestino = new System.Windows.Forms.TextBox();
            this.codigodestino = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttons.SuspendLayout();
            this.contenedordatoscupo.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnExit);
            this.buttons.Controls.Add(this.btnSave);
            this.buttons.Location = new System.Drawing.Point(207, 198);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(176, 43);
            this.buttons.TabIndex = 8;
            this.buttons.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 0;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(116, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 28);
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
            this.btnSave.Location = new System.Drawing.Point(4, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Trasladar Cupo";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // contenedordatoscupo
            // 
            this.contenedordatoscupo.Controls.Add(this.numerocupo);
            this.contenedordatoscupo.Controls.Add(this.label3);
            this.contenedordatoscupo.Controls.Add(this.label2);
            this.contenedordatoscupo.Controls.Add(this.tipovehiculo);
            this.contenedordatoscupo.Controls.Add(this.btnbuscarempresa);
            this.contenedordatoscupo.Controls.Add(this.nombreempresa);
            this.contenedordatoscupo.Controls.Add(this.siglaempresa);
            this.contenedordatoscupo.Controls.Add(this.label1);
            this.contenedordatoscupo.Location = new System.Drawing.Point(7, 4);
            this.contenedordatoscupo.Name = "contenedordatoscupo";
            this.contenedordatoscupo.Size = new System.Drawing.Size(576, 100);
            this.contenedordatoscupo.TabIndex = 0;
            this.contenedordatoscupo.TabStop = false;
            // 
            // numerocupo
            // 
            this.numerocupo.DisplayMember = "TT_NUMCUPO";
            this.numerocupo.FormattingEnabled = true;
            this.numerocupo.Location = new System.Drawing.Point(256, 73);
            this.numerocupo.Name = "numerocupo";
            this.numerocupo.Size = new System.Drawing.Size(121, 21);
            this.numerocupo.TabIndex = 3;
            this.numerocupo.ValueMember = "TT_IDCUPOTAXI";
            this.numerocupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numerocupo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Número Cupo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tipo de Vehículo:";
            // 
            // tipovehiculo
            // 
            this.tipovehiculo.FormattingEnabled = true;
            this.tipovehiculo.Location = new System.Drawing.Point(9, 73);
            this.tipovehiculo.Name = "tipovehiculo";
            this.tipovehiculo.Size = new System.Drawing.Size(241, 21);
            this.tipovehiculo.TabIndex = 2;
            this.tipovehiculo.SelectedValueChanged += new System.EventHandler(this.tipovehiculo_SelectedValueChanged);
            this.tipovehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipovehiculo_KeyPress);
            // 
            // btnbuscarempresa
            // 
            this.btnbuscarempresa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscarempresa.ImageIndex = 10;
            this.btnbuscarempresa.ImageList = this.imageList1;
            this.btnbuscarempresa.Location = new System.Drawing.Point(421, 27);
            this.btnbuscarempresa.Name = "btnbuscarempresa";
            this.btnbuscarempresa.Size = new System.Drawing.Size(148, 28);
            this.btnbuscarempresa.TabIndex = 1;
            this.btnbuscarempresa.Text = "Buscar Empresa &Origen";
            this.btnbuscarempresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarempresa.UseVisualStyleBackColor = true;
            this.btnbuscarempresa.Click += new System.EventHandler(this.btnbuscarempresa_Click);
            // 
            // nombreempresa
            // 
            this.nombreempresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombreempresa.Location = new System.Drawing.Point(115, 32);
            this.nombreempresa.Name = "nombreempresa";
            this.nombreempresa.ReadOnly = true;
            this.nombreempresa.Size = new System.Drawing.Size(300, 20);
            this.nombreempresa.TabIndex = 2;
            this.nombreempresa.TabStop = false;
            // 
            // siglaempresa
            // 
            this.siglaempresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.siglaempresa.Location = new System.Drawing.Point(9, 32);
            this.siglaempresa.Name = "siglaempresa";
            this.siglaempresa.ReadOnly = true;
            this.siglaempresa.Size = new System.Drawing.Size(100, 20);
            this.siglaempresa.TabIndex = 1;
            this.siglaempresa.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa Orígen: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_SearchDestino);
            this.groupBox1.Controls.Add(this.nombredestino);
            this.groupBox1.Controls.Add(this.codigodestino);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(7, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // btn_SearchDestino
            // 
            this.btn_SearchDestino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SearchDestino.ImageIndex = 10;
            this.btn_SearchDestino.ImageList = this.imageList1;
            this.btn_SearchDestino.Location = new System.Drawing.Point(421, 27);
            this.btn_SearchDestino.Name = "btn_SearchDestino";
            this.btn_SearchDestino.Size = new System.Drawing.Size(148, 28);
            this.btn_SearchDestino.TabIndex = 7;
            this.btn_SearchDestino.Text = "Buscar Empresa &Destino";
            this.btn_SearchDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SearchDestino.UseVisualStyleBackColor = true;
            this.btn_SearchDestino.Click += new System.EventHandler(this.btn_SearchDestino_Click);
            // 
            // nombredestino
            // 
            this.nombredestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nombredestino.Location = new System.Drawing.Point(115, 32);
            this.nombredestino.Name = "nombredestino";
            this.nombredestino.ReadOnly = true;
            this.nombredestino.Size = new System.Drawing.Size(300, 20);
            this.nombredestino.TabIndex = 6;
            this.nombredestino.TabStop = false;
            // 
            // codigodestino
            // 
            this.codigodestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.codigodestino.Location = new System.Drawing.Point(9, 32);
            this.codigodestino.Name = "codigodestino";
            this.codigodestino.ReadOnly = true;
            this.codigodestino.Size = new System.Drawing.Size(100, 20);
            this.codigodestino.TabIndex = 5;
            this.codigodestino.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Empresa Destino: ";
            // 
            // trasladodecupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 249);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.contenedordatoscupo);
            this.Controls.Add(this.buttons);
            this.Name = "trasladodecupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Traslado de Cupos entre Empresas]";
            this.Load += new System.EventHandler(this.trasladodecupos_Load);
            this.buttons.ResumeLayout(false);
            this.contenedordatoscupo.ResumeLayout(false);
            this.contenedordatoscupo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox contenedordatoscupo;
        private System.Windows.Forms.ComboBox numerocupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tipovehiculo;
        private System.Windows.Forms.Button btnbuscarempresa;
        private System.Windows.Forms.TextBox nombreempresa;
        private System.Windows.Forms.TextBox siglaempresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_SearchDestino;
        private System.Windows.Forms.TextBox nombredestino;
        private System.Windows.Forms.TextBox codigodestino;
        private System.Windows.Forms.Label label6;
    }
}