namespace Comparendos.servicios.documentos
{
    partial class fPlantilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPlantilla));
            this.ricTxtContenido = new System.Windows.Forms.RichTextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lstVieCampos = new System.Windows.Forms.ListView();
            this.lblCampos = new System.Windows.Forms.Label();
            this.lblNomPlantilla = new System.Windows.Forms.Label();
            this.txtNomPlantilla = new System.Windows.Forms.TextBox();
            this.ricTxtEncabezado = new System.Windows.Forms.RichTextBox();
            this.lblContenido = new System.Windows.Forms.Label();
            this.lblEncabezado = new System.Windows.Forms.Label();
            this.lblTipoResol = new System.Windows.Forms.Label();
            this.cmbBoxTipoResol = new System.Windows.Forms.ComboBox();
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNroRelacionPlantillas = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.groupBoxSentencia = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttons.SuspendLayout();
            this.groupBoxSentencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // ricTxtContenido
            // 
            this.ricTxtContenido.Location = new System.Drawing.Point(21, 170);
            this.ricTxtContenido.Name = "ricTxtContenido";
            this.ricTxtContenido.Size = new System.Drawing.Size(615, 276);
            this.ricTxtContenido.TabIndex = 7;
            this.ricTxtContenido.Text = "";
            // 
            // txtQuery
            // 
            this.txtQuery.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQuery.Location = new System.Drawing.Point(6, 13);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(676, 64);
            this.txtQuery.TabIndex = 1;
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
            this.imageList1.Images.SetKeyName(13, "remove.gif");
            this.imageList1.Images.SetKeyName(14, "stop.gif");
            this.imageList1.Images.SetKeyName(15, "editdelete.gif");
            this.imageList1.Images.SetKeyName(16, "save.bmp");
            this.imageList1.Images.SetKeyName(17, "edit16.bmp");
            this.imageList1.Images.SetKeyName(18, "bold.png");
            this.imageList1.Images.SetKeyName(19, "70.ico");
            this.imageList1.Images.SetKeyName(20, "edit.png");
            // 
            // lstVieCampos
            // 
            this.lstVieCampos.Location = new System.Drawing.Point(673, 55);
            this.lstVieCampos.Name = "lstVieCampos";
            this.lstVieCampos.Size = new System.Drawing.Size(177, 391);
            this.lstVieCampos.TabIndex = 3;
            this.lstVieCampos.UseCompatibleStateImageBehavior = false;
            this.lstVieCampos.View = System.Windows.Forms.View.List;
            this.lstVieCampos.DoubleClick += new System.EventHandler(this.lstVieCampos_DoubleClick);
            // 
            // lblCampos
            // 
            this.lblCampos.AutoSize = true;
            this.lblCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampos.Location = new System.Drawing.Point(670, 27);
            this.lblCampos.Name = "lblCampos";
            this.lblCampos.Size = new System.Drawing.Size(120, 13);
            this.lblCampos.TabIndex = 4;
            this.lblCampos.Text = "Campos Disponibles";
            // 
            // lblNomPlantilla
            // 
            this.lblNomPlantilla.AutoSize = true;
            this.lblNomPlantilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomPlantilla.Location = new System.Drawing.Point(18, 27);
            this.lblNomPlantilla.Name = "lblNomPlantilla";
            this.lblNomPlantilla.Size = new System.Drawing.Size(103, 13);
            this.lblNomPlantilla.TabIndex = 6;
            this.lblNomPlantilla.Text = "Nombre Plantilla:";
            // 
            // txtNomPlantilla
            // 
            this.txtNomPlantilla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNomPlantilla.Location = new System.Drawing.Point(127, 24);
            this.txtNomPlantilla.Name = "txtNomPlantilla";
            this.txtNomPlantilla.Size = new System.Drawing.Size(167, 20);
            this.txtNomPlantilla.TabIndex = 0;
            // 
            // ricTxtEncabezado
            // 
            this.ricTxtEncabezado.Location = new System.Drawing.Point(21, 79);
            this.ricTxtEncabezado.Name = "ricTxtEncabezado";
            this.ricTxtEncabezado.Size = new System.Drawing.Size(615, 55);
            this.ricTxtEncabezado.TabIndex = 8;
            this.ricTxtEncabezado.Text = "";
            // 
            // lblContenido
            // 
            this.lblContenido.AutoSize = true;
            this.lblContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContenido.Location = new System.Drawing.Point(18, 154);
            this.lblContenido.Name = "lblContenido";
            this.lblContenido.Size = new System.Drawing.Size(68, 13);
            this.lblContenido.TabIndex = 9;
            this.lblContenido.Text = "Contenido:";
            // 
            // lblEncabezado
            // 
            this.lblEncabezado.AutoSize = true;
            this.lblEncabezado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncabezado.Location = new System.Drawing.Point(18, 63);
            this.lblEncabezado.Name = "lblEncabezado";
            this.lblEncabezado.Size = new System.Drawing.Size(81, 13);
            this.lblEncabezado.TabIndex = 10;
            this.lblEncabezado.Text = "Encabezado:";
            // 
            // lblTipoResol
            // 
            this.lblTipoResol.AutoSize = true;
            this.lblTipoResol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoResol.Location = new System.Drawing.Point(367, 27);
            this.lblTipoResol.Name = "lblTipoResol";
            this.lblTipoResol.Size = new System.Drawing.Size(103, 13);
            this.lblTipoResol.TabIndex = 13;
            this.lblTipoResol.Text = "Tipo Resolución:";
            // 
            // cmbBoxTipoResol
            // 
            this.cmbBoxTipoResol.DisplayMember = "DES_TIPORESOLUCION";
            this.cmbBoxTipoResol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTipoResol.FormattingEnabled = true;
            this.cmbBoxTipoResol.Location = new System.Drawing.Point(476, 23);
            this.cmbBoxTipoResol.Name = "cmbBoxTipoResol";
            this.cmbBoxTipoResol.Size = new System.Drawing.Size(160, 21);
            this.cmbBoxTipoResol.TabIndex = 14;
            this.cmbBoxTipoResol.ValueMember = "IDTIPORESOLUCION";
            this.cmbBoxTipoResol.SelectedValueChanged += new System.EventHandler(this.cmbBoxTipoResol_SelectedValueChanged);
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnCancelar);
            this.buttons.Controls.Add(this.lblNroRelacionPlantillas);
            this.buttons.Controls.Add(this.btnEditar);
            this.buttons.Controls.Add(this.btnRefresh);
            this.buttons.Controls.Add(this.btnPost);
            this.buttons.Controls.Add(this.btnDelete);
            this.buttons.Controls.Add(this.btnAdd);
            this.buttons.Controls.Add(this.btnLast);
            this.buttons.Controls.Add(this.btnNext);
            this.buttons.Controls.Add(this.btnPrevious);
            this.buttons.Controls.Add(this.btnFirst);
            this.buttons.Location = new System.Drawing.Point(21, 560);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(548, 44);
            this.buttons.TabIndex = 16;
            this.buttons.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleDescription = "Cancelar";
            this.btnCancelar.ImageIndex = 11;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(511, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(30, 28);
            this.btnCancelar.TabIndex = 225;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNroRelacionPlantillas
            // 
            this.lblNroRelacionPlantillas.AutoSize = true;
            this.lblNroRelacionPlantillas.Location = new System.Drawing.Point(135, 20);
            this.lblNroRelacionPlantillas.Name = "lblNroRelacionPlantillas";
            this.lblNroRelacionPlantillas.Size = new System.Drawing.Size(13, 13);
            this.lblNroRelacionPlantillas.TabIndex = 224;
            this.lblNroRelacionPlantillas.Text = "0";
            // 
            // btnEditar
            // 
            this.btnEditar.ImageIndex = 20;
            this.btnEditar.ImageList = this.imageList1;
            this.btnEditar.Location = new System.Drawing.Point(382, 11);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(30, 28);
            this.btnEditar.TabIndex = 223;
            this.btnEditar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEditar, "Editar plantilla");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageIndex = 2;
            this.btnRefresh.ImageList = this.imageList1;
            this.btnRefresh.Location = new System.Drawing.Point(310, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 28);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.TabStop = false;
            this.toolTip1.SetToolTip(this.btnRefresh, "Refrescar");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPost
            // 
            this.btnPost.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPost.ImageIndex = 12;
            this.btnPost.ImageList = this.imageList1;
            this.btnPost.Location = new System.Drawing.Point(475, 11);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(30, 28);
            this.btnPost.TabIndex = 11;
            this.btnPost.TabStop = false;
            this.toolTip1.SetToolTip(this.btnPost, "Confirmar");
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 9;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(418, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 28);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "Eliminar plantilla");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 8;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(346, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 28);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAdd, "Adicionar plantilla");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLast
            // 
            this.btnLast.ImageIndex = 5;
            this.btnLast.ImageList = this.imageList1;
            this.btnLast.Location = new System.Drawing.Point(99, 11);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 28);
            this.btnLast.TabIndex = 14;
            this.btnLast.TabStop = false;
            this.toolTip1.SetToolTip(this.btnLast, "Último");
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.ImageIndex = 6;
            this.btnNext.ImageList = this.imageList1;
            this.btnNext.Location = new System.Drawing.Point(68, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 28);
            this.btnNext.TabIndex = 13;
            this.btnNext.TabStop = false;
            this.toolTip1.SetToolTip(this.btnNext, "Siguiente");
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.ImageIndex = 7;
            this.btnPrevious.ImageList = this.imageList1;
            this.btnPrevious.Location = new System.Drawing.Point(37, 11);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 28);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.TabStop = false;
            this.toolTip1.SetToolTip(this.btnPrevious, "Anterior");
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ImageIndex = 4;
            this.btnFirst.ImageList = this.imageList1;
            this.btnFirst.Location = new System.Drawing.Point(6, 11);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 28);
            this.btnFirst.TabIndex = 16;
            this.btnFirst.TabStop = false;
            this.toolTip1.SetToolTip(this.btnFirst, "Primero");
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // groupBoxSentencia
            // 
            this.groupBoxSentencia.Controls.Add(this.txtQuery);
            this.groupBoxSentencia.Controls.Add(this.btnQuery);
            this.groupBoxSentencia.Location = new System.Drawing.Point(21, 462);
            this.groupBoxSentencia.Name = "groupBoxSentencia";
            this.groupBoxSentencia.Size = new System.Drawing.Size(829, 86);
            this.groupBoxSentencia.TabIndex = 17;
            this.groupBoxSentencia.TabStop = false;
            this.groupBoxSentencia.Text = "Sentencia";
            // 
            // btnQuery
            // 
            this.btnQuery.ImageIndex = 12;
            this.btnQuery.ImageList = this.imageList1;
            this.btnQuery.Location = new System.Drawing.Point(700, 54);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(111, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "&Obtener Campos";
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.ImageKey = "search.ico";
            this.btnPreview.ImageList = this.imageList1;
            this.btnPreview.Location = new System.Drawing.Point(747, 573);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(103, 26);
            this.btnPreview.TabIndex = 15;
            this.btnPreview.Text = "       Vista &Previa ";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.ImageIndex = 10;
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(299, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(65, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 618);
            this.Controls.Add(this.groupBoxSentencia);
            this.Controls.Add(this.buttons);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbBoxTipoResol);
            this.Controls.Add(this.lblTipoResol);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblEncabezado);
            this.Controls.Add(this.lblContenido);
            this.Controls.Add(this.ricTxtEncabezado);
            this.Controls.Add(this.txtNomPlantilla);
            this.Controls.Add(this.lblNomPlantilla);
            this.Controls.Add(this.lblCampos);
            this.Controls.Add(this.lstVieCampos);
            this.Controls.Add(this.ricTxtContenido);
            this.Name = "fPlantilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plantilla";
            this.Load += new System.EventHandler(this.fPlantilla_Load);
            this.buttons.ResumeLayout(false);
            this.buttons.PerformLayout();
            this.groupBoxSentencia.ResumeLayout(false);
            this.groupBoxSentencia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ricTxtContenido;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lstVieCampos;
        private System.Windows.Forms.Label lblCampos;
        private System.Windows.Forms.Label lblNomPlantilla;
        private System.Windows.Forms.TextBox txtNomPlantilla;
        private System.Windows.Forms.RichTextBox ricTxtEncabezado;
        private System.Windows.Forms.Label lblContenido;
        private System.Windows.Forms.Label lblEncabezado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTipoResol;
        private System.Windows.Forms.ComboBox cmbBoxTipoResol;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.GroupBox groupBoxSentencia;
        private System.Windows.Forms.Label lblNroRelacionPlantillas;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}