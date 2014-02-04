namespace utilidades.configuracionIni
{
    partial class FrmConfigurarAplicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfigurarAplicacion));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkRecargarAhora = new System.Windows.Forms.CheckBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.chkRecargarTodos = new System.Windows.Forms.CheckBox();
            this.chkAutoCrear = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAplicacionNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProtocolo = new System.Windows.Forms.ComboBox();
            this.numPuerto = new System.Windows.Forms.NumericUpDown();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblLogs = new System.Windows.Forms.DataGridView();
            this.btnCargarLog = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnRestablecer = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuerto)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 267);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkRecargarAhora);
            this.tabPage2.Controls.Add(this.txtIp);
            this.tabPage2.Controls.Add(this.chkRecargarTodos);
            this.tabPage2.Controls.Add(this.chkAutoCrear);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtAplicacionNombre);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cmbProtocolo);
            this.tabPage2.Controls.Add(this.numPuerto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Servicios Web";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkRecargarAhora
            // 
            this.chkRecargarAhora.AutoSize = true;
            this.chkRecargarAhora.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecargarAhora.Checked = true;
            this.chkRecargarAhora.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecargarAhora.Location = new System.Drawing.Point(18, 157);
            this.chkRecargarAhora.Name = "chkRecargarAhora";
            this.chkRecargarAhora.Size = new System.Drawing.Size(250, 17);
            this.chkRecargarAhora.TabIndex = 7;
            this.chkRecargarAhora.Text = "Recargar las referencias a servicios web ahora:";
            this.chkRecargarAhora.UseVisualStyleBackColor = true;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(259, 6);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 20);
            this.txtIp.TabIndex = 2;
            // 
            // chkRecargarTodos
            // 
            this.chkRecargarTodos.AutoSize = true;
            this.chkRecargarTodos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRecargarTodos.Location = new System.Drawing.Point(18, 113);
            this.chkRecargarTodos.Name = "chkRecargarTodos";
            this.chkRecargarTodos.Size = new System.Drawing.Size(173, 17);
            this.chkRecargarTodos.TabIndex = 6;
            this.chkRecargarTodos.Text = "Recargar todas las referencias:";
            this.chkRecargarTodos.UseVisualStyleBackColor = true;
            // 
            // chkAutoCrear
            // 
            this.chkAutoCrear.AutoSize = true;
            this.chkAutoCrear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoCrear.Location = new System.Drawing.Point(18, 90);
            this.chkAutoCrear.Name = "chkAutoCrear";
            this.chkAutoCrear.Size = new System.Drawing.Size(184, 17);
            this.chkAutoCrear.TabIndex = 5;
            this.chkAutoCrear.Text = "Auto cargar todas las referencias:";
            this.chkAutoCrear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Protocolo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Aplicación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Puerto:";
            // 
            // txtAplicacionNombre
            // 
            this.txtAplicacionNombre.Location = new System.Drawing.Point(80, 33);
            this.txtAplicacionNombre.Name = "txtAplicacionNombre";
            this.txtAplicacionNombre.Size = new System.Drawing.Size(100, 20);
            this.txtAplicacionNombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "IP:";
            // 
            // cmbProtocolo
            // 
            this.cmbProtocolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProtocolo.FormattingEnabled = true;
            this.cmbProtocolo.Items.AddRange(new object[] {
            "http",
            "https"});
            this.cmbProtocolo.Location = new System.Drawing.Point(80, 6);
            this.cmbProtocolo.Name = "cmbProtocolo";
            this.cmbProtocolo.Size = new System.Drawing.Size(100, 21);
            this.cmbProtocolo.TabIndex = 1;
            // 
            // numPuerto
            // 
            this.numPuerto.Location = new System.Drawing.Point(441, 6);
            this.numPuerto.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.numPuerto.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPuerto.Name = "numPuerto";
            this.numPuerto.Size = new System.Drawing.Size(100, 20);
            this.numPuerto.TabIndex = 3;
            this.numPuerto.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btnCargarLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 241);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Logs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblLogs);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 220);
            this.panel1.TabIndex = 2;
            // 
            // tblLogs
            // 
            this.tblLogs.AllowUserToAddRows = false;
            this.tblLogs.AllowUserToDeleteRows = false;
            this.tblLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLogs.Location = new System.Drawing.Point(0, 0);
            this.tblLogs.Name = "tblLogs";
            this.tblLogs.ReadOnly = true;
            this.tblLogs.Size = new System.Drawing.Size(479, 220);
            this.tblLogs.TabIndex = 1;
            // 
            // btnCargarLog
            // 
            this.btnCargarLog.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargarLog.ImageKey = "edit-find.png";
            this.btnCargarLog.ImageList = this.imageList1;
            this.btnCargarLog.Location = new System.Drawing.Point(491, 6);
            this.btnCargarLog.Name = "btnCargarLog";
            this.btnCargarLog.Size = new System.Drawing.Size(119, 23);
            this.btnCargarLog.TabIndex = 0;
            this.btnCargarLog.Text = "Cargar log";
            this.btnCargarLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargarLog.UseVisualStyleBackColor = true;
            this.btnCargarLog.Click += new System.EventHandler(this.btnCargarLog_Click);
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
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ImageKey = "16 (Save).ico";
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(554, 285);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(82, 26);
            this.btnGuardar.TabIndex = 101;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.ImageKey = "stop.gif";
            this.btnCancelar.ImageList = this.imageList2;
            this.btnCancelar.Location = new System.Drawing.Point(464, 285);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 26);
            this.btnCancelar.TabIndex = 102;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestablecer.ImageKey = "view-refresh.png";
            this.btnRestablecer.ImageList = this.imageList1;
            this.btnRestablecer.Location = new System.Drawing.Point(356, 285);
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Size = new System.Drawing.Size(102, 26);
            this.btnRestablecer.TabIndex = 103;
            this.btnRestablecer.Text = "Restablecer";
            this.btnRestablecer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestablecer.UseVisualStyleBackColor = true;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "system-log-out.png");
            this.imageList2.Images.SetKeyName(1, "system-search.png");
            this.imageList2.Images.SetKeyName(2, "view-refresh.png");
            this.imageList2.Images.SetKeyName(3, "edit-find.png");
            this.imageList2.Images.SetKeyName(4, "go-first.png");
            this.imageList2.Images.SetKeyName(5, "go-last.png");
            this.imageList2.Images.SetKeyName(6, "go-next.png");
            this.imageList2.Images.SetKeyName(7, "go-previous.png");
            this.imageList2.Images.SetKeyName(8, "list-add.png");
            this.imageList2.Images.SetKeyName(9, "list-remove.png");
            this.imageList2.Images.SetKeyName(10, "search.ico");
            this.imageList2.Images.SetKeyName(11, "button_cancel.ico");
            this.imageList2.Images.SetKeyName(12, "button_ok.ico");
            this.imageList2.Images.SetKeyName(13, "remove.gif");
            this.imageList2.Images.SetKeyName(14, "stop.gif");
            this.imageList2.Images.SetKeyName(15, "editdelete.gif");
            this.imageList2.Images.SetKeyName(16, "save.bmp");
            this.imageList2.Images.SetKeyName(17, "edit16.bmp");
            // 
            // FrmConfigurarAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 323);
            this.Controls.Add(this.btnRestablecer);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmConfigurarAplicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Aplicación";
            this.Load += new System.EventHandler(this.FrmConfigurarAplicacion_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPuerto)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtAplicacionNombre;
        private System.Windows.Forms.CheckBox chkRecargarTodos;
        private System.Windows.Forms.CheckBox chkAutoCrear;
        private System.Windows.Forms.ComboBox cmbProtocolo;
        private System.Windows.Forms.NumericUpDown numPuerto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Button btnRestablecer;
        private System.Windows.Forms.CheckBox chkRecargarAhora;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView tblLogs;
        private System.Windows.Forms.Button btnCargarLog;
        private System.Windows.Forms.ImageList imageList2;
    }
}