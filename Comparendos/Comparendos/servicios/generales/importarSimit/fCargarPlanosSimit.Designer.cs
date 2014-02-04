namespace Comparendos.servicios.generales
{
    partial class fCargarPlanosSimit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCargarInfo = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnBuscarArchivos = new System.Windows.Forms.Button();
            this.directory = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.barRecaudos = new System.Windows.Forms.ProgressBar();
            this.lblRecaudosCargue = new System.Windows.Forms.Label();
            this.barResoluciones = new System.Windows.Forms.ProgressBar();
            this.lblResolucionesCargue = new System.Windows.Forms.Label();
            this.barComparendos = new System.Windows.Forms.ProgressBar();
            this.lblComparendosCargue = new System.Windows.Forms.Label();
            this.hiloComparendos = new System.ComponentModel.BackgroundWorker();
            this.hiloResoluciones = new System.ComponentModel.BackgroundWorker();
            this.hiloRecaudos = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCargarInfo);
            this.panel1.Controls.Add(this.lstFiles);
            this.panel1.Controls.Add(this.btnBuscarArchivos);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 105);
            this.panel1.TabIndex = 1;
            // 
            // btnCargarInfo
            // 
            this.btnCargarInfo.Enabled = false;
            this.btnCargarInfo.Image = global::Comparendos.Properties.Resources.download;
            this.btnCargarInfo.Location = new System.Drawing.Point(3, 53);
            this.btnCargarInfo.Name = "btnCargarInfo";
            this.btnCargarInfo.Size = new System.Drawing.Size(112, 46);
            this.btnCargarInfo.TabIndex = 2;
            this.btnCargarInfo.Text = "Cargar Información";
            this.btnCargarInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargarInfo.UseVisualStyleBackColor = true;
            this.btnCargarInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.HorizontalScrollbar = true;
            this.lstFiles.Location = new System.Drawing.Point(121, 3);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(560, 95);
            this.lstFiles.TabIndex = 2;
            // 
            // btnBuscarArchivos
            // 
            this.btnBuscarArchivos.Image = global::Comparendos.Properties.Resources.file;
            this.btnBuscarArchivos.Location = new System.Drawing.Point(3, 3);
            this.btnBuscarArchivos.Name = "btnBuscarArchivos";
            this.btnBuscarArchivos.Size = new System.Drawing.Size(112, 46);
            this.btnBuscarArchivos.TabIndex = 1;
            this.btnBuscarArchivos.Text = "Buscar Archivos";
            this.btnBuscarArchivos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarArchivos.UseVisualStyleBackColor = true;
            this.btnBuscarArchivos.Click += new System.EventHandler(this.btnBuscarArchivos_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.barRecaudos);
            this.panel2.Controls.Add(this.lblRecaudosCargue);
            this.panel2.Controls.Add(this.barResoluciones);
            this.panel2.Controls.Add(this.lblResolucionesCargue);
            this.panel2.Controls.Add(this.barComparendos);
            this.panel2.Controls.Add(this.lblComparendosCargue);
            this.panel2.Location = new System.Drawing.Point(3, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 103);
            this.panel2.TabIndex = 2;
            // 
            // barRecaudos
            // 
            this.barRecaudos.Location = new System.Drawing.Point(8, 81);
            this.barRecaudos.Name = "barRecaudos";
            this.barRecaudos.Size = new System.Drawing.Size(670, 10);
            this.barRecaudos.TabIndex = 5;
            // 
            // lblRecaudosCargue
            // 
            this.lblRecaudosCargue.AutoSize = true;
            this.lblRecaudosCargue.Location = new System.Drawing.Point(9, 65);
            this.lblRecaudosCargue.Name = "lblRecaudosCargue";
            this.lblRecaudosCargue.Size = new System.Drawing.Size(56, 13);
            this.lblRecaudosCargue.TabIndex = 4;
            this.lblRecaudosCargue.Text = "Recaudos";
            // 
            // barResoluciones
            // 
            this.barResoluciones.Location = new System.Drawing.Point(8, 51);
            this.barResoluciones.Name = "barResoluciones";
            this.barResoluciones.Size = new System.Drawing.Size(670, 10);
            this.barResoluciones.TabIndex = 3;
            // 
            // lblResolucionesCargue
            // 
            this.lblResolucionesCargue.AutoSize = true;
            this.lblResolucionesCargue.Location = new System.Drawing.Point(9, 35);
            this.lblResolucionesCargue.Name = "lblResolucionesCargue";
            this.lblResolucionesCargue.Size = new System.Drawing.Size(71, 13);
            this.lblResolucionesCargue.TabIndex = 2;
            this.lblResolucionesCargue.Text = "Resoluciones";
            this.lblResolucionesCargue.Click += new System.EventHandler(this.lblResolucionesCargue_Click);
            // 
            // barComparendos
            // 
            this.barComparendos.Location = new System.Drawing.Point(7, 20);
            this.barComparendos.Name = "barComparendos";
            this.barComparendos.Size = new System.Drawing.Size(670, 10);
            this.barComparendos.TabIndex = 1;
            // 
            // lblComparendosCargue
            // 
            this.lblComparendosCargue.AutoSize = true;
            this.lblComparendosCargue.Location = new System.Drawing.Point(8, 4);
            this.lblComparendosCargue.Name = "lblComparendosCargue";
            this.lblComparendosCargue.Size = new System.Drawing.Size(72, 13);
            this.lblComparendosCargue.TabIndex = 0;
            this.lblComparendosCargue.Text = "Comparendos";
            // 
            // hiloComparendos
            // 
            this.hiloComparendos.WorkerReportsProgress = true;
            this.hiloComparendos.WorkerSupportsCancellation = true;
            this.hiloComparendos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.hiloComparendos_DoWork);
            this.hiloComparendos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.hiloComparendos_ProgressChanged);
            this.hiloComparendos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.hiloComparendos_RunWorkerCompleted);
            // 
            // hiloResoluciones
            // 
            this.hiloResoluciones.WorkerReportsProgress = true;
            this.hiloResoluciones.WorkerSupportsCancellation = true;
            this.hiloResoluciones.DoWork += new System.ComponentModel.DoWorkEventHandler(this.hiloResoluciones_DoWork);
            this.hiloResoluciones.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.hiloResoluciones_ProgressChanged);
            this.hiloResoluciones.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.hiloResoluciones_RunWorkerCompleted);
            // 
            // hiloRecaudos
            // 
            this.hiloRecaudos.WorkerReportsProgress = true;
            this.hiloRecaudos.WorkerSupportsCancellation = true;
            this.hiloRecaudos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.hiloRecaudos_DoWork);
            this.hiloRecaudos.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.hiloRecaudos_ProgressChanged);
            this.hiloRecaudos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.hiloRecaudos_RunWorkerCompleted);
            // 
            // fCargarPlanosSimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 217);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fCargarPlanosSimit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Planos Simit";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnBuscarArchivos;
        private System.Windows.Forms.Button btnCargarInfo;
        private System.Windows.Forms.FolderBrowserDialog directory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar barComparendos;
        private System.Windows.Forms.Label lblComparendosCargue;
        private System.ComponentModel.BackgroundWorker hiloComparendos;
        private System.Windows.Forms.ProgressBar barRecaudos;
        private System.Windows.Forms.Label lblRecaudosCargue;
        private System.Windows.Forms.ProgressBar barResoluciones;
        private System.Windows.Forms.Label lblResolucionesCargue;
        private System.ComponentModel.BackgroundWorker hiloResoluciones;
        private System.ComponentModel.BackgroundWorker hiloRecaudos;
    }
}