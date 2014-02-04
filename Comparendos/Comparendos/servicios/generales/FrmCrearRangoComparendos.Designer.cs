namespace Comparendos.servicios.generales
{
    partial class FrmCrearRangoComparendos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrearRangoComparendos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFechaAsignacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAsignacion = new System.Windows.Forms.Label();
            this.txtNumeroDocumentoAsignacion = new System.Windows.Forms.TextBox();
            this.lblNumeroDocumentoAsignacion = new System.Windows.Forms.Label();
            this.txtCantidadRango = new System.Windows.Forms.TextBox();
            this.lblCantidadRango = new System.Windows.Forms.Label();
            this.txtRangoFinal = new System.Windows.Forms.TextBox();
            this.lblRangoFinal = new System.Windows.Forms.Label();
            this.txtRangoInicial = new System.Windows.Forms.TextBox();
            this.lblRangoInicial = new System.Windows.Forms.Label();
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnEdit = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFechaAsignacion);
            this.groupBox1.Controls.Add(this.lblFechaAsignacion);
            this.groupBox1.Controls.Add(this.txtNumeroDocumentoAsignacion);
            this.groupBox1.Controls.Add(this.lblNumeroDocumentoAsignacion);
            this.groupBox1.Controls.Add(this.txtCantidadRango);
            this.groupBox1.Controls.Add(this.lblCantidadRango);
            this.groupBox1.Controls.Add(this.txtRangoFinal);
            this.groupBox1.Controls.Add(this.lblRangoFinal);
            this.groupBox1.Controls.Add(this.txtRangoInicial);
            this.groupBox1.Controls.Add(this.lblRangoInicial);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dtpFechaAsignacion
            // 
            this.dtpFechaAsignacion.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaAsignacion.Location = new System.Drawing.Point(201, 151);
            this.dtpFechaAsignacion.Name = "dtpFechaAsignacion";
            this.dtpFechaAsignacion.Size = new System.Drawing.Size(122, 20);
            this.dtpFechaAsignacion.TabIndex = 4;
            this.dtpFechaAsignacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFechaAsignacion_KeyPress);
            // 
            // lblFechaAsignacion
            // 
            this.lblFechaAsignacion.AutoSize = true;
            this.lblFechaAsignacion.Location = new System.Drawing.Point(198, 135);
            this.lblFechaAsignacion.Name = "lblFechaAsignacion";
            this.lblFechaAsignacion.Size = new System.Drawing.Size(92, 13);
            this.lblFechaAsignacion.TabIndex = 8;
            this.lblFechaAsignacion.Text = "Fecha Asignación";
            // 
            // txtNumeroDocumentoAsignacion
            // 
            this.txtNumeroDocumentoAsignacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroDocumentoAsignacion.Location = new System.Drawing.Point(19, 151);
            this.txtNumeroDocumentoAsignacion.Name = "txtNumeroDocumentoAsignacion";
            this.txtNumeroDocumentoAsignacion.Size = new System.Drawing.Size(173, 20);
            this.txtNumeroDocumentoAsignacion.TabIndex = 3;
            this.txtNumeroDocumentoAsignacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumentoAsignacion_KeyPress);
            // 
            // lblNumeroDocumentoAsignacion
            // 
            this.lblNumeroDocumentoAsignacion.AutoSize = true;
            this.lblNumeroDocumentoAsignacion.Location = new System.Drawing.Point(16, 135);
            this.lblNumeroDocumentoAsignacion.Name = "lblNumeroDocumentoAsignacion";
            this.lblNumeroDocumentoAsignacion.Size = new System.Drawing.Size(157, 13);
            this.lblNumeroDocumentoAsignacion.TabIndex = 6;
            this.lblNumeroDocumentoAsignacion.Text = "Número Documento Asignación";
            // 
            // txtCantidadRango
            // 
            this.txtCantidadRango.Enabled = false;
            this.txtCantidadRango.Location = new System.Drawing.Point(331, 151);
            this.txtCantidadRango.Name = "txtCantidadRango";
            this.txtCantidadRango.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadRango.TabIndex = 5;
            // 
            // lblCantidadRango
            // 
            this.lblCantidadRango.AutoSize = true;
            this.lblCantidadRango.Location = new System.Drawing.Point(328, 135);
            this.lblCantidadRango.Name = "lblCantidadRango";
            this.lblCantidadRango.Size = new System.Drawing.Size(84, 13);
            this.lblCantidadRango.TabIndex = 4;
            this.lblCantidadRango.Text = "Cantidad Rango";
            // 
            // txtRangoFinal
            // 
            this.txtRangoFinal.Location = new System.Drawing.Point(19, 93);
            this.txtRangoFinal.MaxLength = 20;
            this.txtRangoFinal.Name = "txtRangoFinal";
            this.txtRangoFinal.Size = new System.Drawing.Size(412, 20);
            this.txtRangoFinal.TabIndex = 2;
            this.txtRangoFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRangoFinal_KeyPress);
            this.txtRangoFinal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRangoFinal_KeyUp);
            // 
            // lblRangoFinal
            // 
            this.lblRangoFinal.AutoSize = true;
            this.lblRangoFinal.Location = new System.Drawing.Point(16, 77);
            this.lblRangoFinal.Name = "lblRangoFinal";
            this.lblRangoFinal.Size = new System.Drawing.Size(64, 13);
            this.lblRangoFinal.TabIndex = 2;
            this.lblRangoFinal.Text = "Rango Final";
            // 
            // txtRangoInicial
            // 
            this.txtRangoInicial.Location = new System.Drawing.Point(19, 47);
            this.txtRangoInicial.MaxLength = 20;
            this.txtRangoInicial.Name = "txtRangoInicial";
            this.txtRangoInicial.Size = new System.Drawing.Size(412, 20);
            this.txtRangoInicial.TabIndex = 1;
            this.txtRangoInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRangoInicial_KeyPress);
            this.txtRangoInicial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRangoInicial_KeyUp);
            // 
            // lblRangoInicial
            // 
            this.lblRangoInicial.AutoSize = true;
            this.lblRangoInicial.Location = new System.Drawing.Point(16, 31);
            this.lblRangoInicial.Name = "lblRangoInicial";
            this.lblRangoInicial.Size = new System.Drawing.Size(69, 13);
            this.lblRangoInicial.TabIndex = 0;
            this.lblRangoInicial.Text = "Rango Inicial";
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnDelete);
            this.buttons.Controls.Add(this.btnEdit);
            this.buttons.Controls.Add(this.btnCancel);
            this.buttons.Controls.Add(this.btnSave);
            this.buttons.Controls.Add(this.btnAdd);
            this.buttons.Controls.Add(this.btnLast);
            this.buttons.Controls.Add(this.btnNext);
            this.buttons.Controls.Add(this.btnPrevious);
            this.buttons.Controls.Add(this.btnFirst);
            this.buttons.Location = new System.Drawing.Point(112, 214);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(299, 43);
            this.buttons.TabIndex = 193;
            this.buttons.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 44;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(191, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 28);
            this.btnDelete.TabIndex = 194;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "Eliminar");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "go-first.png");
            this.imageList1.Images.SetKeyName(1, "address-book-new.png");
            this.imageList1.Images.SetKeyName(2, "appointment-new.png");
            this.imageList1.Images.SetKeyName(3, "bookmark-new.png");
            this.imageList1.Images.SetKeyName(4, "contact-new.png");
            this.imageList1.Images.SetKeyName(5, "document-new.png");
            this.imageList1.Images.SetKeyName(6, "document-open.png");
            this.imageList1.Images.SetKeyName(7, "document-print.png");
            this.imageList1.Images.SetKeyName(8, "document-print-preview.png");
            this.imageList1.Images.SetKeyName(9, "document-properties.png");
            this.imageList1.Images.SetKeyName(10, "document-save.png");
            this.imageList1.Images.SetKeyName(11, "document-save-as.png");
            this.imageList1.Images.SetKeyName(12, "edit-clear.png");
            this.imageList1.Images.SetKeyName(13, "edit-copy.png");
            this.imageList1.Images.SetKeyName(14, "edit-cut.png");
            this.imageList1.Images.SetKeyName(15, "edit-delete.png");
            this.imageList1.Images.SetKeyName(16, "edit-find.png");
            this.imageList1.Images.SetKeyName(17, "edit-find-replace.png");
            this.imageList1.Images.SetKeyName(18, "edit-paste.png");
            this.imageList1.Images.SetKeyName(19, "edit-redo.png");
            this.imageList1.Images.SetKeyName(20, "edit-select-all.png");
            this.imageList1.Images.SetKeyName(21, "edit-undo.png");
            this.imageList1.Images.SetKeyName(22, "folder-new.png");
            this.imageList1.Images.SetKeyName(23, "format-indent-less.png");
            this.imageList1.Images.SetKeyName(24, "format-indent-more.png");
            this.imageList1.Images.SetKeyName(25, "format-justify-center.png");
            this.imageList1.Images.SetKeyName(26, "format-justify-fill.png");
            this.imageList1.Images.SetKeyName(27, "format-justify-left.png");
            this.imageList1.Images.SetKeyName(28, "format-justify-right.png");
            this.imageList1.Images.SetKeyName(29, "format-text-bold.png");
            this.imageList1.Images.SetKeyName(30, "format-text-italic.png");
            this.imageList1.Images.SetKeyName(31, "format-text-strikethrough.png");
            this.imageList1.Images.SetKeyName(32, "format-text-underline.png");
            this.imageList1.Images.SetKeyName(33, "go-bottom.png");
            this.imageList1.Images.SetKeyName(34, "go-down.png");
            this.imageList1.Images.SetKeyName(35, "go-first.png");
            this.imageList1.Images.SetKeyName(36, "go-home.png");
            this.imageList1.Images.SetKeyName(37, "go-jump.png");
            this.imageList1.Images.SetKeyName(38, "go-last.png");
            this.imageList1.Images.SetKeyName(39, "go-next.png");
            this.imageList1.Images.SetKeyName(40, "go-previous.png");
            this.imageList1.Images.SetKeyName(41, "go-top.png");
            this.imageList1.Images.SetKeyName(42, "go-up.png");
            this.imageList1.Images.SetKeyName(43, "list-add.png");
            this.imageList1.Images.SetKeyName(44, "list-remove.png");
            this.imageList1.Images.SetKeyName(45, "mail-forward.png");
            this.imageList1.Images.SetKeyName(46, "mail-mark-junk.png");
            this.imageList1.Images.SetKeyName(47, "mail-mark-not-junk.png");
            this.imageList1.Images.SetKeyName(48, "mail-message-new.png");
            this.imageList1.Images.SetKeyName(49, "mail-reply-all.png");
            this.imageList1.Images.SetKeyName(50, "mail-reply-sender.png");
            this.imageList1.Images.SetKeyName(51, "mail-send-receive.png");
            this.imageList1.Images.SetKeyName(52, "media-eject.png");
            this.imageList1.Images.SetKeyName(53, "media-playback-pause.png");
            this.imageList1.Images.SetKeyName(54, "media-playback-start.png");
            this.imageList1.Images.SetKeyName(55, "media-playback-stop.png");
            this.imageList1.Images.SetKeyName(56, "media-record.png");
            this.imageList1.Images.SetKeyName(57, "media-seek-backward.png");
            this.imageList1.Images.SetKeyName(58, "media-seek-forward.png");
            this.imageList1.Images.SetKeyName(59, "media-skip-backward.png");
            this.imageList1.Images.SetKeyName(60, "media-skip-forward.png");
            this.imageList1.Images.SetKeyName(61, "process-stop.png");
            this.imageList1.Images.SetKeyName(62, "system-lock-screen.png");
            this.imageList1.Images.SetKeyName(63, "system-log-out.png");
            this.imageList1.Images.SetKeyName(64, "system-search.png");
            this.imageList1.Images.SetKeyName(65, "system-shutdown.png");
            this.imageList1.Images.SetKeyName(66, "tab-new.png");
            this.imageList1.Images.SetKeyName(67, "view-fullscreen.png");
            this.imageList1.Images.SetKeyName(68, "view-refresh.png");
            this.imageList1.Images.SetKeyName(69, "window-new.png");
            this.imageList1.Images.SetKeyName(70, "button_ok.ico");
            // 
            // btnEdit
            // 
            this.btnEdit.ImageIndex = 15;
            this.btnEdit.ImageList = this.imageList2;
            this.btnEdit.Location = new System.Drawing.Point(130, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 28);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEdit, "Editar");
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
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.ImageIndex = 61;
            this.btnCancel.ImageList = this.imageList1;
            this.btnCancel.Location = new System.Drawing.Point(259, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(30, 28);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCancel, "Cancelar");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageIndex = 70;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(227, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(30, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSave, "Guardar");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 43;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(160, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 28);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAdd, "Nuevo");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLast
            // 
            this.btnLast.ImageIndex = 38;
            this.btnLast.ImageList = this.imageList1;
            this.btnLast.Location = new System.Drawing.Point(99, 11);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 28);
            this.btnLast.TabIndex = 13;
            this.btnLast.TabStop = false;
            this.toolTip1.SetToolTip(this.btnLast, "Ultimo Elemento");
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageIndex = 39;
            this.btnNext.ImageList = this.imageList1;
            this.btnNext.Location = new System.Drawing.Point(68, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 28);
            this.btnNext.TabIndex = 12;
            this.btnNext.TabStop = false;
            this.toolTip1.SetToolTip(this.btnNext, "Siguiente");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ImageIndex = 40;
            this.btnPrevious.ImageList = this.imageList1;
            this.btnPrevious.Location = new System.Drawing.Point(37, 11);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 28);
            this.btnPrevious.TabIndex = 11;
            this.btnPrevious.TabStop = false;
            this.toolTip1.SetToolTip(this.btnPrevious, "Atras");
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageIndex = 0;
            this.btnFirst.ImageList = this.imageList1;
            this.btnFirst.Location = new System.Drawing.Point(6, 11);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 28);
            this.btnFirst.TabIndex = 10;
            this.btnFirst.TabStop = false;
            this.toolTip1.SetToolTip(this.btnFirst, "Primer Elemento");
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // FrmCrearRangoComparendos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 283);
            this.Controls.Add(this.buttons);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCrearRangoComparendos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Rango de Comparendos";
            this.Load += new System.EventHandler(this.FrmCrearRangoComparendos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFechaAsignacion;
        private System.Windows.Forms.Label lblFechaAsignacion;
        private System.Windows.Forms.TextBox txtNumeroDocumentoAsignacion;
        private System.Windows.Forms.Label lblNumeroDocumentoAsignacion;
        private System.Windows.Forms.TextBox txtCantidadRango;
        private System.Windows.Forms.Label lblCantidadRango;
        private System.Windows.Forms.TextBox txtRangoFinal;
        private System.Windows.Forms.Label lblRangoFinal;
        private System.Windows.Forms.TextBox txtRangoInicial;
        private System.Windows.Forms.Label lblRangoInicial;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ImageList imageList2;
    }
}