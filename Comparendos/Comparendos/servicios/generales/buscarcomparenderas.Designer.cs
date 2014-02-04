namespace Comparendos.servicios.generales
{
    partial class buscarcomparenderas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(buscarcomparenderas));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.infocomparendera = new System.Windows.Forms.GroupBox();
            this.btnSearchAgente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nombreagente = new System.Windows.Forms.TextBox();
            this.codigoagente = new System.Windows.Forms.TextBox();
            this.lblNoRegistrados = new System.Windows.Forms.Label();
            this.noregistrados = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grillaasignadas = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDetalleCOmparenderas = new System.Windows.Forms.Label();
            this.distribucioncomp = new System.Windows.Forms.GroupBox();
            this.grillacomparenderas = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblResumen1 = new System.Windows.Forms.Label();
            this.lblResumen2 = new System.Windows.Forms.Label();
            this.lblResumen3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.infocomparendera.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaasignadas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.distribucioncomp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillacomparenderas)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            // infocomparendera
            // 
            this.infocomparendera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.infocomparendera.Controls.Add(this.btnSearchAgente);
            this.infocomparendera.Controls.Add(this.label1);
            this.infocomparendera.Controls.Add(this.nombreagente);
            this.infocomparendera.Controls.Add(this.codigoagente);
            this.infocomparendera.Location = new System.Drawing.Point(6, 19);
            this.infocomparendera.Name = "infocomparendera";
            this.infocomparendera.Size = new System.Drawing.Size(571, 68);
            this.infocomparendera.TabIndex = 1;
            this.infocomparendera.TabStop = false;
            this.infocomparendera.Text = "[Parámetros de Búsqueda]";
            // 
            // btnSearchAgente
            // 
            this.btnSearchAgente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchAgente.ImageIndex = 10;
            this.btnSearchAgente.ImageList = this.imageList1;
            this.btnSearchAgente.Location = new System.Drawing.Point(454, 27);
            this.btnSearchAgente.Name = "btnSearchAgente";
            this.btnSearchAgente.Size = new System.Drawing.Size(100, 28);
            this.btnSearchAgente.TabIndex = 1;
            this.btnSearchAgente.Text = "&Buscar Agente";
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
            // nombreagente
            // 
            this.nombreagente.Location = new System.Drawing.Point(127, 35);
            this.nombreagente.Name = "nombreagente";
            this.nombreagente.ReadOnly = true;
            this.nombreagente.Size = new System.Drawing.Size(321, 20);
            this.nombreagente.TabIndex = 1;
            this.nombreagente.TabStop = false;
            // 
            // codigoagente
            // 
            this.codigoagente.Location = new System.Drawing.Point(12, 35);
            this.codigoagente.Name = "codigoagente";
            this.codigoagente.ReadOnly = true;
            this.codigoagente.Size = new System.Drawing.Size(100, 20);
            this.codigoagente.TabIndex = 0;
            this.codigoagente.TabStop = false;
            // 
            // lblNoRegistrados
            // 
            this.lblNoRegistrados.AutoSize = true;
            this.lblNoRegistrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRegistrados.Location = new System.Drawing.Point(15, 18);
            this.lblNoRegistrados.Name = "lblNoRegistrados";
            this.lblNoRegistrados.Size = new System.Drawing.Size(200, 17);
            this.lblNoRegistrados.TabIndex = 4;
            this.lblNoRegistrados.Text = "Comparendos no Registrados:";
            // 
            // noregistrados
            // 
            this.noregistrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noregistrados.Location = new System.Drawing.Point(18, 41);
            this.noregistrados.Multiline = true;
            this.noregistrados.Name = "noregistrados";
            this.noregistrados.ReadOnly = true;
            this.noregistrados.Size = new System.Drawing.Size(430, 75);
            this.noregistrados.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grillaasignadas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 320);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comparendos Registrados:";
            // 
            // grillaasignadas
            // 
            this.grillaasignadas.AllowUserToAddRows = false;
            this.grillaasignadas.AllowUserToDeleteRows = false;
            this.grillaasignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaasignadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillaasignadas.Location = new System.Drawing.Point(3, 19);
            this.grillaasignadas.Name = "grillaasignadas";
            this.grillaasignadas.ReadOnly = true;
            this.grillaasignadas.Size = new System.Drawing.Size(424, 298);
            this.grillaasignadas.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblDetalleCOmparenderas);
            this.groupBox2.Controls.Add(this.infocomparendera);
            this.groupBox2.Controls.Add(this.distribucioncomp);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 455);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblDetalleCOmparenderas
            // 
            this.lblDetalleCOmparenderas.AutoSize = true;
            this.lblDetalleCOmparenderas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleCOmparenderas.Location = new System.Drawing.Point(21, 106);
            this.lblDetalleCOmparenderas.Name = "lblDetalleCOmparenderas";
            this.lblDetalleCOmparenderas.Size = new System.Drawing.Size(198, 20);
            this.lblDetalleCOmparenderas.TabIndex = 1;
            this.lblDetalleCOmparenderas.Text = "Detalle Comparenderas";
            // 
            // distribucioncomp
            // 
            this.distribucioncomp.Controls.Add(this.grillacomparenderas);
            this.distribucioncomp.Location = new System.Drawing.Point(8, 138);
            this.distribucioncomp.Name = "distribucioncomp";
            this.distribucioncomp.Size = new System.Drawing.Size(571, 304);
            this.distribucioncomp.TabIndex = 3;
            this.distribucioncomp.TabStop = false;
            this.distribucioncomp.Text = "[Comparenderas]";
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
            this.grillacomparenderas.Size = new System.Drawing.Size(565, 285);
            this.grillacomparenderas.TabIndex = 0;
            this.grillacomparenderas.SelectionChanged += new System.EventHandler(this.grillacomparenderas_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblNoRegistrados);
            this.groupBox3.Controls.Add(this.noregistrados);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(618, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 455);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado Comparendera";
            // 
            // lblResumen1
            // 
            this.lblResumen1.AutoSize = true;
            this.lblResumen1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen1.Location = new System.Drawing.Point(320, 476);
            this.lblResumen1.Name = "lblResumen1";
            this.lblResumen1.Size = new System.Drawing.Size(0, 20);
            this.lblResumen1.TabIndex = 10;
            // 
            // lblResumen2
            // 
            this.lblResumen2.AutoSize = true;
            this.lblResumen2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen2.Location = new System.Drawing.Point(320, 510);
            this.lblResumen2.Name = "lblResumen2";
            this.lblResumen2.Size = new System.Drawing.Size(0, 20);
            this.lblResumen2.TabIndex = 11;
            // 
            // lblResumen3
            // 
            this.lblResumen3.AutoSize = true;
            this.lblResumen3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen3.Location = new System.Drawing.Point(368, 510);
            this.lblResumen3.Name = "lblResumen3";
            this.lblResumen3.Size = new System.Drawing.Size(0, 20);
            this.lblResumen3.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.ImageIndex = 11;
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(986, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 41);
            this.button1.TabIndex = 3;
            this.button1.TabStop = false;
            this.button1.Text = "&Salir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.ImageIndex = 15;
            this.btnAnular.ImageList = this.imageList3;
            this.btnAnular.Location = new System.Drawing.Point(20, 489);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(129, 41);
            this.btnAnular.TabIndex = 2;
            this.btnAnular.TabStop = false;
            this.btnAnular.Text = "&Anular Comparendo";
            this.btnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Visible = false;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "system-log-out.png");
            this.imageList3.Images.SetKeyName(1, "system-search.png");
            this.imageList3.Images.SetKeyName(2, "view-refresh.png");
            this.imageList3.Images.SetKeyName(3, "edit-find.png");
            this.imageList3.Images.SetKeyName(4, "go-first.png");
            this.imageList3.Images.SetKeyName(5, "go-last.png");
            this.imageList3.Images.SetKeyName(6, "go-next.png");
            this.imageList3.Images.SetKeyName(7, "go-previous.png");
            this.imageList3.Images.SetKeyName(8, "list-add.png");
            this.imageList3.Images.SetKeyName(9, "list-remove.png");
            this.imageList3.Images.SetKeyName(10, "search.ico");
            this.imageList3.Images.SetKeyName(11, "button_cancel.ico");
            this.imageList3.Images.SetKeyName(12, "button_ok.ico");
            this.imageList3.Images.SetKeyName(13, "remove.gif");
            this.imageList3.Images.SetKeyName(14, "stop.gif");
            this.imageList3.Images.SetKeyName(15, "editdelete.gif");
            this.imageList3.Images.SetKeyName(16, "save.bmp");
            this.imageList3.Images.SetKeyName(17, "edit16.bmp");
            // 
            // buscarcomparenderas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 584);
            this.Controls.Add(this.lblResumen3);
            this.Controls.Add(this.lblResumen2);
            this.Controls.Add(this.lblResumen1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAnular);
            this.Name = "buscarcomparenderas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Buscar Comparenderas]";
            this.Load += new System.EventHandler(this.buscarcomparenderas_Load);
            this.infocomparendera.ResumeLayout(false);
            this.infocomparendera.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillaasignadas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.distribucioncomp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillacomparenderas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox infocomparendera;
        private System.Windows.Forms.Button btnSearchAgente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreagente;
        private System.Windows.Forms.TextBox codigoagente;
        private System.Windows.Forms.Label lblNoRegistrados;
        private System.Windows.Forms.TextBox noregistrados;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grillaasignadas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox distribucioncomp;
        private System.Windows.Forms.DataGridView grillacomparenderas;
        private System.Windows.Forms.Label lblDetalleCOmparenderas;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblResumen1;
        private System.Windows.Forms.Label lblResumen2;
        private System.Windows.Forms.Label lblResumen3;
        private System.Windows.Forms.ImageList imageList3;
    }
}