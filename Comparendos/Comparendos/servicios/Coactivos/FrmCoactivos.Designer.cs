namespace Comparendos.servicios.Coativos
{
    partial class FrmCoativos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCoativos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dateTPickFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTPickFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdInfractor = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvComparendos = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfractor)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparendos)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.dateTPickFechaFinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTPickFechaInicial);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(13, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageKey = "search.ico";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(417, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(85, 26);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
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
            this.imageList1.Images.SetKeyName(13, "Users.ico");
            this.imageList1.Images.SetKeyName(14, "User.ico");
            this.imageList1.Images.SetKeyName(15, "printer.gif");
            this.imageList1.Images.SetKeyName(16, "16 (Find).ico");
            this.imageList1.Images.SetKeyName(17, "16 (Flag blue).ico");
            this.imageList1.Images.SetKeyName(18, "16 (Folder).ico");
            this.imageList1.Images.SetKeyName(19, "16 (Lock off).ico");
            this.imageList1.Images.SetKeyName(20, "16 (Lock on).ico");
            this.imageList1.Images.SetKeyName(21, "16 (Print preview).ico");
            this.imageList1.Images.SetKeyName(22, "16 (Print).ico");
            this.imageList1.Images.SetKeyName(23, "16 (Save).ico");
            this.imageList1.Images.SetKeyName(24, "16 (User).ico");
            this.imageList1.Images.SetKeyName(25, "16 (Users).ico");
            this.imageList1.Images.SetKeyName(26, "16 (Contents).ico");
            this.imageList1.Images.SetKeyName(27, "16 (Db cancel).ico");
            this.imageList1.Images.SetKeyName(28, "16 (Db delete).ico");
            this.imageList1.Images.SetKeyName(29, "16 (Db edit).ico");
            this.imageList1.Images.SetKeyName(30, "16 (Db first).ico");
            this.imageList1.Images.SetKeyName(31, "16 (Db insert).ico");
            this.imageList1.Images.SetKeyName(32, "16 (Db last).ico");
            this.imageList1.Images.SetKeyName(33, "16 (Db next).ico");
            this.imageList1.Images.SetKeyName(34, "16 (Db post).ico");
            this.imageList1.Images.SetKeyName(35, "16 (Db previous).ico");
            this.imageList1.Images.SetKeyName(36, "16 (Db refresh).ico");
            this.imageList1.Images.SetKeyName(37, "16 (Execute).ico");
            this.imageList1.Images.SetKeyName(38, "16 (Exit).ico");
            this.imageList1.Images.SetKeyName(39, "16 (Fill up).ico");
            this.imageList1.Images.SetKeyName(40, "open2.png");
            this.imageList1.Images.SetKeyName(41, "Cool Blue Floppy Drive 3.png");
            // 
            // dateTPickFechaFinal
            // 
            this.dateTPickFechaFinal.CustomFormat = "dd/MM/yyyy";
            this.dateTPickFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPickFechaFinal.Location = new System.Drawing.Point(276, 21);
            this.dateTPickFechaFinal.Name = "dateTPickFechaFinal";
            this.dateTPickFechaFinal.Size = new System.Drawing.Size(100, 20);
            this.dateTPickFechaFinal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha Inicio";
            // 
            // dateTPickFechaInicial
            // 
            this.dateTPickFechaInicial.CustomFormat = "dd/MM/yyyy";
            this.dateTPickFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPickFechaInicial.Location = new System.Drawing.Point(82, 21);
            this.dateTPickFechaInicial.Name = "dateTPickFechaInicial";
            this.dateTPickFechaInicial.Size = new System.Drawing.Size(100, 20);
            this.dateTPickFechaInicial.TabIndex = 1;
            this.dateTPickFechaInicial.Value = new System.DateTime(2013, 3, 24, 0, 0, 0, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdInfractor);
            this.groupBox3.Location = new System.Drawing.Point(12, 94);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(833, 209);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Listado De Infractores Entre las Fechas";
            // 
            // grdInfractor
            // 
            this.grdInfractor.AllowUserToAddRows = false;
            this.grdInfractor.AllowUserToDeleteRows = false;
            this.grdInfractor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdInfractor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInfractor.Location = new System.Drawing.Point(16, 25);
            this.grdInfractor.Name = "grdInfractor";
            this.grdInfractor.ReadOnly = true;
            this.grdInfractor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInfractor.Size = new System.Drawing.Size(811, 163);
            this.grdInfractor.TabIndex = 0;
            this.grdInfractor.TabStop = false;
            this.grdInfractor.SelectionChanged += new System.EventHandler(this.grdInfractor_SelectionChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvComparendos);
            this.groupBox4.Location = new System.Drawing.Point(12, 309);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(834, 187);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Comparendos";
            // 
            // dgvComparendos
            // 
            this.dgvComparendos.AllowUserToAddRows = false;
            this.dgvComparendos.AllowUserToDeleteRows = false;
            this.dgvComparendos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComparendos.Location = new System.Drawing.Point(16, 19);
            this.dgvComparendos.Name = "dgvComparendos";
            this.dgvComparendos.ReadOnly = true;
            this.dgvComparendos.Size = new System.Drawing.Size(811, 150);
            this.dgvComparendos.TabIndex = 0;
            this.dgvComparendos.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnGenerar);
            this.groupBox5.Location = new System.Drawing.Point(659, 502);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(187, 58);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.ImageKey = "go-last.png";
            this.btnGenerar.ImageList = this.imageList1;
            this.btnGenerar.Location = new System.Drawing.Point(17, 19);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(152, 26);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "&Generar Notificaciones";
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // FrmCoativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 572);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCoativos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.FrmCoativos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInfractor)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComparendos)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTPickFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTPickFechaFinal;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdInfractor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.DataGridView dgvComparendos;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;

    }
}