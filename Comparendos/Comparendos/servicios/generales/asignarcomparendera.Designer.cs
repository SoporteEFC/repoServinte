namespace Comparendos.servicios.generales
{
    partial class asignarcomparendera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(asignarcomparendera));
            this.infocomparendera = new System.Windows.Forms.GroupBox();
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRangoFinal = new System.Windows.Forms.TextBox();
            this.txtRangoInicial = new System.Windows.Forms.TextBox();
            this.btnSearchrango = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRangoComparendos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoComparendera = new System.Windows.Forms.ComboBox();
            this.btnSearchAgente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombreAgente = new System.Windows.Forms.TextBox();
            this.txtPlacaAgente = new System.Windows.Forms.TextBox();
            this.distribucioncomp = new System.Windows.Forms.GroupBox();
            this.grillacomparenderas = new System.Windows.Forms.DataGridView();
            this.infocomparendera.SuspendLayout();
            this.buttons.SuspendLayout();
            this.distribucioncomp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillacomparenderas)).BeginInit();
            this.SuspendLayout();
            // 
            // infocomparendera
            // 
            this.infocomparendera.Controls.Add(this.buttons);
            this.infocomparendera.Controls.Add(this.txtFechaRegistro);
            this.infocomparendera.Controls.Add(this.label6);
            this.infocomparendera.Controls.Add(this.label5);
            this.infocomparendera.Controls.Add(this.label4);
            this.infocomparendera.Controls.Add(this.txtRangoFinal);
            this.infocomparendera.Controls.Add(this.txtRangoInicial);
            this.infocomparendera.Controls.Add(this.btnSearchrango);
            this.infocomparendera.Controls.Add(this.label3);
            this.infocomparendera.Controls.Add(this.txtRangoComparendos);
            this.infocomparendera.Controls.Add(this.label2);
            this.infocomparendera.Controls.Add(this.cmbTipoComparendera);
            this.infocomparendera.Controls.Add(this.btnSearchAgente);
            this.infocomparendera.Controls.Add(this.label1);
            this.infocomparendera.Controls.Add(this.txtNombreAgente);
            this.infocomparendera.Controls.Add(this.txtPlacaAgente);
            this.infocomparendera.Location = new System.Drawing.Point(12, 22);
            this.infocomparendera.Name = "infocomparendera";
            this.infocomparendera.Size = new System.Drawing.Size(689, 177);
            this.infocomparendera.TabIndex = 0;
            this.infocomparendera.TabStop = false;
            this.infocomparendera.Text = "[Información de Registro]";
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnExit);
            this.buttons.Controls.Add(this.btnSave);
            this.buttons.Location = new System.Drawing.Point(514, 112);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(162, 43);
            this.buttons.TabIndex = 26;
            this.buttons.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(93, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 28);
            this.btnExit.TabIndex = 8;
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
            this.btnSave.Location = new System.Drawing.Point(6, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "&Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.CustomFormat = "dd/MM/yyyy";
            this.txtFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFechaRegistro.Location = new System.Drawing.Point(395, 128);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(100, 20);
            this.txtFechaRegistro.TabIndex = 6;
            this.txtFechaRegistro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.fecharegistro_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(392, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Fecha Registro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Rango Final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Rango Inicial";
            // 
            // txtRangoFinal
            // 
            this.txtRangoFinal.Location = new System.Drawing.Point(206, 128);
            this.txtRangoFinal.MaxLength = 20;
            this.txtRangoFinal.Name = "txtRangoFinal";
            this.txtRangoFinal.Size = new System.Drawing.Size(183, 20);
            this.txtRangoFinal.TabIndex = 5;
            this.txtRangoFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangofinal_KeyPress);
            // 
            // txtRangoInicial
            // 
            this.txtRangoInicial.Location = new System.Drawing.Point(12, 128);
            this.txtRangoInicial.MaxLength = 20;
            this.txtRangoInicial.Name = "txtRangoInicial";
            this.txtRangoInicial.Size = new System.Drawing.Size(188, 20);
            this.txtRangoInicial.TabIndex = 4;
            this.txtRangoInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rangoinicial_KeyPress);
            // 
            // btnSearchrango
            // 
            this.btnSearchrango.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchrango.ImageIndex = 10;
            this.btnSearchrango.ImageList = this.imageList1;
            this.btnSearchrango.Location = new System.Drawing.Point(575, 74);
            this.btnSearchrango.Name = "btnSearchrango";
            this.btnSearchrango.Size = new System.Drawing.Size(99, 28);
            this.btnSearchrango.TabIndex = 3;
            this.btnSearchrango.Text = "Buscar &Rango";
            this.btnSearchrango.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchrango.UseVisualStyleBackColor = true;
            this.btnSearchrango.Click += new System.EventHandler(this.btnSearchrango_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Rango de Comparendos";
            // 
            // txtRangoComparendos
            // 
            this.txtRangoComparendos.Location = new System.Drawing.Point(12, 79);
            this.txtRangoComparendos.Name = "txtRangoComparendos";
            this.txtRangoComparendos.ReadOnly = true;
            this.txtRangoComparendos.Size = new System.Drawing.Size(552, 20);
            this.txtRangoComparendos.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tipo Comparendera";
            // 
            // cmbTipoComparendera
            // 
            this.cmbTipoComparendera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoComparendera.FormattingEnabled = true;
            this.cmbTipoComparendera.Location = new System.Drawing.Point(576, 34);
            this.cmbTipoComparendera.Name = "cmbTipoComparendera";
            this.cmbTipoComparendera.Size = new System.Drawing.Size(100, 21);
            this.cmbTipoComparendera.TabIndex = 2;
            this.cmbTipoComparendera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipocomparendera_KeyPress);
            // 
            // btnSearchAgente
            // 
            this.btnSearchAgente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchAgente.ImageIndex = 10;
            this.btnSearchAgente.ImageList = this.imageList1;
            this.btnSearchAgente.Location = new System.Drawing.Point(462, 19);
            this.btnSearchAgente.Name = "btnSearchAgente";
            this.btnSearchAgente.Size = new System.Drawing.Size(100, 36);
            this.btnSearchAgente.TabIndex = 1;
            this.btnSearchAgente.Text = "Buscar &Agente";
            this.btnSearchAgente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchAgente.UseVisualStyleBackColor = true;
            this.btnSearchAgente.Click += new System.EventHandler(this.btnSearchAgente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agente";
            // 
            // txtNombreAgente
            // 
            this.txtNombreAgente.Location = new System.Drawing.Point(127, 35);
            this.txtNombreAgente.Name = "txtNombreAgente";
            this.txtNombreAgente.ReadOnly = true;
            this.txtNombreAgente.Size = new System.Drawing.Size(321, 20);
            this.txtNombreAgente.TabIndex = 0;
            // 
            // txtPlacaAgente
            // 
            this.txtPlacaAgente.Location = new System.Drawing.Point(12, 35);
            this.txtPlacaAgente.Name = "txtPlacaAgente";
            this.txtPlacaAgente.ReadOnly = true;
            this.txtPlacaAgente.Size = new System.Drawing.Size(100, 20);
            this.txtPlacaAgente.TabIndex = 0;
            // 
            // distribucioncomp
            // 
            this.distribucioncomp.Controls.Add(this.grillacomparenderas);
            this.distribucioncomp.Location = new System.Drawing.Point(12, 213);
            this.distribucioncomp.Name = "distribucioncomp";
            this.distribucioncomp.Size = new System.Drawing.Size(689, 259);
            this.distribucioncomp.TabIndex = 2;
            this.distribucioncomp.TabStop = false;
            this.distribucioncomp.Text = "[Distribución de Comparenderas]";
            // 
            // grillacomparenderas
            // 
            this.grillacomparenderas.AllowUserToAddRows = false;
            this.grillacomparenderas.AllowUserToDeleteRows = false;
            this.grillacomparenderas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillacomparenderas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillacomparenderas.Location = new System.Drawing.Point(3, 16);
            this.grillacomparenderas.Name = "grillacomparenderas";
            this.grillacomparenderas.ReadOnly = true;
            this.grillacomparenderas.Size = new System.Drawing.Size(683, 240);
            this.grillacomparenderas.TabIndex = 0;
            // 
            // asignarcomparendera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 496);
            this.Controls.Add(this.distribucioncomp);
            this.Controls.Add(this.infocomparendera);
            this.Name = "asignarcomparendera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Asignar Comparendera]";
            this.Load += new System.EventHandler(this.asignarcomparendera_Load);
            this.infocomparendera.ResumeLayout(false);
            this.infocomparendera.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.distribucioncomp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillacomparenderas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox infocomparendera;
        private System.Windows.Forms.GroupBox distribucioncomp;
        private System.Windows.Forms.TextBox txtPlacaAgente;
        private System.Windows.Forms.TextBox txtNombreAgente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnSearchAgente;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoComparendera;
        private System.Windows.Forms.TextBox txtRangoComparendos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchrango;
        private System.Windows.Forms.TextBox txtRangoInicial;
        private System.Windows.Forms.TextBox txtRangoFinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker txtFechaRegistro;
        private System.Windows.Forms.DataGridView grillacomparenderas;
    }
}