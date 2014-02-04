namespace Comparendos.servicios.generales
{
    partial class configurarinfracciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configurarinfracciones));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contenedorinfracciones = new System.Windows.Forms.GroupBox();
            this.grillainfracciones = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.contenedorinfracciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillainfracciones)).BeginInit();
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
            // contenedorinfracciones
            // 
            this.contenedorinfracciones.Controls.Add(this.grillainfracciones);
            this.contenedorinfracciones.Location = new System.Drawing.Point(6, 39);
            this.contenedorinfracciones.Name = "contenedorinfracciones";
            this.contenedorinfracciones.Size = new System.Drawing.Size(973, 451);
            this.contenedorinfracciones.TabIndex = 28;
            this.contenedorinfracciones.TabStop = false;
            this.contenedorinfracciones.Text = "Infracciones";
            // 
            // grillainfracciones
            // 
            this.grillainfracciones.AllowUserToAddRows = false;
            this.grillainfracciones.AllowUserToDeleteRows = false;
            this.grillainfracciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillainfracciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grillainfracciones.Location = new System.Drawing.Point(3, 16);
            this.grillainfracciones.Name = "grillainfracciones";
            this.grillainfracciones.ReadOnly = true;
            this.grillainfracciones.Size = new System.Drawing.Size(967, 432);
            this.grillainfracciones.TabIndex = 0;
            this.grillainfracciones.SelectionChanged += new System.EventHandler(this.grillainfracciones_SelectionChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageIndex = 10;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(339, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 28);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.ImageIndex = 8;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(516, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(126, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Adicionar Infracción";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.ImageIndex = 9;
            this.btnDel.ImageList = this.imageList1;
            this.btnDel.Location = new System.Drawing.Point(784, 12);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(126, 28);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "&Eliminar Infracción";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.ImageKey = "edit.png";
            this.btnEdit.ImageList = this.imageList2;
            this.btnEdit.Location = new System.Drawing.Point(650, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(126, 28);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "&Editar Infracción";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.imageList2.Images.SetKeyName(13, "car.ico");
            this.imageList2.Images.SetKeyName(14, "user.png");
            this.imageList2.Images.SetKeyName(15, "edit.png");
            this.imageList2.Images.SetKeyName(16, "filesave.ico");
            this.imageList2.Images.SetKeyName(17, "star.png");
            this.imageList2.Images.SetKeyName(18, "busy.png");
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 11;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(918, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.ImageIndex = 2;
            this.btnActualizar.ImageList = this.imageList1;
            this.btnActualizar.Location = new System.Drawing.Point(422, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(86, 28);
            this.btnActualizar.TabIndex = 29;
            this.btnActualizar.Text = "&Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // configurarinfracciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 502);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.contenedorinfracciones);
            this.Name = "configurarinfracciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Gestión de Infracciones]";
            this.Load += new System.EventHandler(this.configurarinfracciones_Load);
            this.contenedorinfracciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grillainfracciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox contenedorinfracciones;
        private System.Windows.Forms.DataGridView grillainfracciones;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnActualizar;
    }
}