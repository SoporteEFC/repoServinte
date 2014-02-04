namespace Comparendos.servicios.generales
{
    partial class fGestionAgentes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGestionAgentes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchPlaca = new System.Windows.Forms.Button();
            this.btnSearchTransito = new System.Windows.Forms.Button();
            this.cmbTransito = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrimerApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroIdentificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.buttons.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttons);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 66);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnCancelar);
            this.buttons.Controls.Add(this.btnDelete);
            this.buttons.Controls.Add(this.btnEditar);
            this.buttons.Controls.Add(this.btnRefresh);
            this.buttons.Controls.Add(this.btnPost);
            this.buttons.Controls.Add(this.btnAdd);
            this.buttons.Controls.Add(this.btnLast);
            this.buttons.Controls.Add(this.btnNext);
            this.buttons.Controls.Add(this.btnPrevious);
            this.buttons.Controls.Add(this.btnFirst);
            this.buttons.Location = new System.Drawing.Point(56, 11);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(332, 43);
            this.buttons.TabIndex = 12;
            this.buttons.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ImageIndex = 11;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(264, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(30, 28);
            this.btnCancelar.TabIndex = 224;
            this.toolTip1.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.imageList1.Images.SetKeyName(40, "edit.png");
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 9;
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(138, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(30, 28);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.btnDelete, "Eliminar Agente");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.ImageKey = "edit.png";
            this.btnEditar.ImageList = this.imageList1;
            this.btnEditar.Location = new System.Drawing.Point(232, 11);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(30, 28);
            this.btnEditar.TabIndex = 223;
            this.btnEditar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnEditar, "Editar Agente");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageIndex = 2;
            this.btnRefresh.ImageList = this.imageList1;
            this.btnRefresh.Location = new System.Drawing.Point(295, 11);
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
            this.btnPost.Location = new System.Drawing.Point(200, 11);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(30, 28);
            this.btnPost.TabIndex = 11;
            this.btnPost.TabStop = false;
            this.toolTip1.SetToolTip(this.btnPost, "Guardar Agente");
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 8;
            this.btnAdd.ImageList = this.imageList1;
            this.btnAdd.Location = new System.Drawing.Point(169, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 28);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.TabStop = false;
            this.toolTip1.SetToolTip(this.btnAdd, "Nuevo Agente");
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
            this.toolTip1.SetToolTip(this.btnLast, "Ultimo Elemento");
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
            this.toolTip1.SetToolTip(this.btnFirst, "Primer Elemento");
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchPlaca);
            this.groupBox2.Controls.Add(this.btnSearchTransito);
            this.groupBox2.Controls.Add(this.cmbTransito);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSegundoApellido);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPrimerApellido);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNombres);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNroIdentificacion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbTipoDoc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPlaca);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 232);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[Datos Básicos]";
            // 
            // btnSearchPlaca
            // 
            this.btnSearchPlaca.ImageIndex = 10;
            this.btnSearchPlaca.ImageList = this.imageList1;
            this.btnSearchPlaca.Location = new System.Drawing.Point(247, 36);
            this.btnSearchPlaca.Name = "btnSearchPlaca";
            this.btnSearchPlaca.Size = new System.Drawing.Size(24, 24);
            this.btnSearchPlaca.TabIndex = 2;
            this.btnSearchPlaca.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSearchPlaca, "Buscar Agente");
            this.btnSearchPlaca.UseVisualStyleBackColor = true;
            this.btnSearchPlaca.Click += new System.EventHandler(this.btnSearchPlaca_Click);
            // 
            // btnSearchTransito
            // 
            this.btnSearchTransito.ImageIndex = 10;
            this.btnSearchTransito.ImageList = this.imageList1;
            this.btnSearchTransito.Location = new System.Drawing.Point(384, 194);
            this.btnSearchTransito.Name = "btnSearchTransito";
            this.btnSearchTransito.Size = new System.Drawing.Size(24, 24);
            this.btnSearchTransito.TabIndex = 9;
            this.btnSearchTransito.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSearchTransito, "Buscar Organismo de Transito");
            this.btnSearchTransito.UseVisualStyleBackColor = true;
            this.btnSearchTransito.Click += new System.EventHandler(this.btnSearchTransito_Click);
            // 
            // cmbTransito
            // 
            this.cmbTransito.DisplayMember = "NOMBRESECRETARIA";
            this.cmbTransito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransito.Enabled = false;
            this.cmbTransito.FormattingEnabled = true;
            this.cmbTransito.Location = new System.Drawing.Point(15, 195);
            this.cmbTransito.Name = "cmbTransito";
            this.cmbTransito.Size = new System.Drawing.Size(366, 21);
            this.cmbTransito.TabIndex = 8;
            this.cmbTransito.ValueMember = "IDORGTRANSITO";
            this.cmbTransito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTransito_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Organismo de Tránsito";
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSegundoApellido.Location = new System.Drawing.Point(220, 155);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(190, 20);
            this.txtSegundoApellido.TabIndex = 7;
            this.txtSegundoApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSegundoApellido_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Segundo Apellido";
            // 
            // txtPrimerApellido
            // 
            this.txtPrimerApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrimerApellido.Location = new System.Drawing.Point(15, 155);
            this.txtPrimerApellido.Name = "txtPrimerApellido";
            this.txtPrimerApellido.Size = new System.Drawing.Size(199, 20);
            this.txtPrimerApellido.TabIndex = 6;
            this.txtPrimerApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrimerApellido_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Primer Apellido *";
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Location = new System.Drawing.Point(15, 118);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(395, 20);
            this.txtNombres.TabIndex = 5;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombres *";
            // 
            // txtNroIdentificacion
            // 
            this.txtNroIdentificacion.Location = new System.Drawing.Point(201, 80);
            this.txtNroIdentificacion.Name = "txtNroIdentificacion";
            this.txtNroIdentificacion.Size = new System.Drawing.Size(209, 20);
            this.txtNroIdentificacion.TabIndex = 4;
            this.txtNroIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroIdentificacion_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nro. Identificación *";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DisplayMember = "DESCRIPCION";
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(15, 79);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(180, 21);
            this.cmbTipoDoc.TabIndex = 3;
            this.cmbTipoDoc.ValueMember = "ID_DOCCOMP";
            this.cmbTipoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoDoc_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo Documento *";
            // 
            // txtPlaca
            // 
            this.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaca.Location = new System.Drawing.Point(15, 38);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(228, 20);
            this.txtPlaca.TabIndex = 1;
            this.txtPlaca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlaca_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Placa *";
            // 
            // fGestionAgentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 298);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "fGestionAgentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Gestión de Agentes]";
            this.groupBox1.ResumeLayout(false);
            this.buttons.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.TextBox txtNroIdentificacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchPlaca;
        private System.Windows.Forms.Button btnSearchTransito;
        private System.Windows.Forms.ComboBox cmbTransito;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrimerApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
    }
}