namespace Comparendos.servicios.generales
{
    partial class fInfractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fInfractor));
            this.cmbTipoDocBusq = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtIdentificacionBusq = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNroLicencia = new System.Windows.Forms.TextBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarInfractor = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnNuevo = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.imageList4 = new System.Windows.Forms.ImageList(this.components);
            this.btnPost = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnBuscarCiudad = new System.Windows.Forms.Button();
            this.cmbCiudadRes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCatLicencia = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscarlugar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbOrgExpide = new System.Windows.Forms.ComboBox();
            this.txtFecVenLic = new System.Windows.Forms.DateTimePicker();
            this.label56 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.grbDatosUsuario = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grbDatosBusqueda = new System.Windows.Forms.GroupBox();
            this.buttons.SuspendLayout();
            this.grbDatosUsuario.SuspendLayout();
            this.grbDatosBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTipoDocBusq
            // 
            this.cmbTipoDocBusq.DisplayMember = "DESCRIPCION";
            this.cmbTipoDocBusq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocBusq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocBusq.FormattingEnabled = true;
            this.cmbTipoDocBusq.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbTipoDocBusq.Location = new System.Drawing.Point(94, 33);
            this.cmbTipoDocBusq.Name = "cmbTipoDocBusq";
            this.cmbTipoDocBusq.Size = new System.Drawing.Size(157, 21);
            this.cmbTipoDocBusq.TabIndex = 0;
            this.cmbTipoDocBusq.ValueMember = "ID_DOCCOMP";
            this.cmbTipoDocBusq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoDoc_KeyPress);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(91, 16);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(86, 13);
            this.label54.TabIndex = 203;
            this.label54.Text = "Tipo Documento\r\n";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(257, 17);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(70, 13);
            this.label42.TabIndex = 206;
            this.label42.Text = "Identificación";
            // 
            // txtIdentificacionBusq
            // 
            this.txtIdentificacionBusq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacionBusq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacionBusq.Location = new System.Drawing.Point(257, 33);
            this.txtIdentificacionBusq.MaxLength = 20;
            this.txtIdentificacionBusq.Name = "txtIdentificacionBusq";
            this.txtIdentificacionBusq.Size = new System.Drawing.Size(211, 20);
            this.txtIdentificacionBusq.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtIdentificacionBusq, "Buscar Infractor");
            this.txtIdentificacionBusq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacionBusq_KeyDown);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.Location = new System.Drawing.Point(322, 66);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(49, 13);
            this.label59.TabIndex = 216;
            this.label59.Text = "Apellidos";
            // 
            // txtApellidos
            // 
            this.txtApellidos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(325, 82);
            this.txtApellidos.MaxLength = 20;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(299, 20);
            this.txtApellidos.TabIndex = 4;
            this.txtApellidos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidos_KeyPress);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(21, 66);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(49, 13);
            this.label57.TabIndex = 214;
            this.label57.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(24, 82);
            this.txtNombres.MaxLength = 20;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(294, 20);
            this.txtNombres.TabIndex = 3;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 218;
            this.label1.Text = "Nro. Licencia Conducción";
            // 
            // txtNroLicencia
            // 
            this.txtNroLicencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroLicencia.Location = new System.Drawing.Point(325, 166);
            this.txtNroLicencia.MaxLength = 20;
            this.txtNroLicencia.Name = "txtNroLicencia";
            this.txtNroLicencia.Size = new System.Drawing.Size(145, 20);
            this.txtNroLicencia.TabIndex = 10;
            this.txtNroLicencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroLicencia_KeyPress);
            // 
            // cmbSexo
            // 
            this.cmbSexo.DisplayMember = "DESCRIPCION";
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbSexo.Location = new System.Drawing.Point(433, 38);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(193, 21);
            this.cmbSexo.TabIndex = 2;
            this.cmbSexo.ValueMember = "ID_SEXO";
            this.cmbSexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSexo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(430, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 219;
            this.label2.Text = "Sexo";
            // 
            // btnBuscarInfractor
            // 
            this.btnBuscarInfractor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarInfractor.ImageIndex = 10;
            this.btnBuscarInfractor.ImageList = this.imageList1;
            this.btnBuscarInfractor.Location = new System.Drawing.Point(471, 31);
            this.btnBuscarInfractor.Name = "btnBuscarInfractor";
            this.btnBuscarInfractor.Size = new System.Drawing.Size(67, 23);
            this.btnBuscarInfractor.TabIndex = 4;
            this.btnBuscarInfractor.TabStop = false;
            this.btnBuscarInfractor.Text = "Buscar";
            this.btnBuscarInfractor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnBuscarInfractor, "Buscar Infractor");
            this.btnBuscarInfractor.UseVisualStyleBackColor = true;
            this.btnBuscarInfractor.Click += new System.EventHandler(this.btnBuscarInfractor_Click);
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
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnCancelar);
            this.buttons.Controls.Add(this.btnNuevo);
            this.buttons.Controls.Add(this.btnClose);
            this.buttons.Controls.Add(this.btnEdit);
            this.buttons.Controls.Add(this.btnPost);
            this.buttons.Location = new System.Drawing.Point(155, 239);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(390, 45);
            this.buttons.TabIndex = 221;
            this.buttons.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "16 (Db cancel).ico";
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(235, 11);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 28);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            // btnNuevo
            // 
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.ImageIndex = 8;
            this.btnNuevo.ImageList = this.imageList3;
            this.btnNuevo.Location = new System.Drawing.Point(7, 11);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(72, 28);
            this.btnNuevo.TabIndex = 22;
            this.btnNuevo.TabStop = false;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.imageList3.Images.SetKeyName(18, "bold.png");
            this.imageList3.Images.SetKeyName(19, "70.ico");
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageKey = "button_cancel.ico";
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(311, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 28);
            this.btnClose.TabIndex = 21;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "&Salir";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.ImageIndex = 15;
            this.btnEdit.ImageList = this.imageList4;
            this.btnEdit.Location = new System.Drawing.Point(159, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 28);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "&Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // imageList4
            // 
            this.imageList4.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList4.ImageStream")));
            this.imageList4.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList4.Images.SetKeyName(0, "system-log-out.png");
            this.imageList4.Images.SetKeyName(1, "system-search.png");
            this.imageList4.Images.SetKeyName(2, "view-refresh.png");
            this.imageList4.Images.SetKeyName(3, "edit-find.png");
            this.imageList4.Images.SetKeyName(4, "go-first.png");
            this.imageList4.Images.SetKeyName(5, "go-last.png");
            this.imageList4.Images.SetKeyName(6, "go-next.png");
            this.imageList4.Images.SetKeyName(7, "go-previous.png");
            this.imageList4.Images.SetKeyName(8, "list-add.png");
            this.imageList4.Images.SetKeyName(9, "list-remove.png");
            this.imageList4.Images.SetKeyName(10, "search.ico");
            this.imageList4.Images.SetKeyName(11, "button_cancel.ico");
            this.imageList4.Images.SetKeyName(12, "button_ok.ico");
            this.imageList4.Images.SetKeyName(13, "car.ico");
            this.imageList4.Images.SetKeyName(14, "user.png");
            this.imageList4.Images.SetKeyName(15, "edit.png");
            this.imageList4.Images.SetKeyName(16, "filesave.ico");
            this.imageList4.Images.SetKeyName(17, "star.png");
            this.imageList4.Images.SetKeyName(18, "busy.png");
            // 
            // btnPost
            // 
            this.btnPost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPost.ImageIndex = 23;
            this.btnPost.ImageList = this.imageList1;
            this.btnPost.Location = new System.Drawing.Point(83, 11);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(72, 28);
            this.btnPost.TabIndex = 19;
            this.btnPost.TabStop = false;
            this.btnPost.Text = "&Guardar";
            this.btnPost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnPost, "Guardar Infractor");
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 225;
            this.label3.Text = "Edad";
            // 
            // txtEdad
            // 
            this.txtEdad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.Location = new System.Drawing.Point(24, 121);
            this.txtEdad.MaxLength = 3;
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(34, 20);
            this.txtEdad.TabIndex = 5;
            this.txtEdad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEdad_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 227;
            this.label4.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(62, 121);
            this.txtDireccion.MaxLength = 50;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(256, 20);
            this.txtDireccion.TabIndex = 6;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(322, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 229;
            this.label5.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(325, 121);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(99, 20);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(422, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 231;
            this.label6.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(425, 121);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(201, 20);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // btnBuscarCiudad
            // 
            this.btnBuscarCiudad.ImageIndex = 10;
            this.btnBuscarCiudad.ImageList = this.imageList1;
            this.btnBuscarCiudad.Location = new System.Drawing.Point(295, 165);
            this.btnBuscarCiudad.Name = "btnBuscarCiudad";
            this.btnBuscarCiudad.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarCiudad.TabIndex = 13;
            this.btnBuscarCiudad.TabStop = false;
            this.toolTip1.SetToolTip(this.btnBuscarCiudad, "Buscar Ciudad");
            this.btnBuscarCiudad.UseVisualStyleBackColor = true;
            this.btnBuscarCiudad.Click += new System.EventHandler(this.btnBuscarCiudad_Click);
            // 
            // cmbCiudadRes
            // 
            this.cmbCiudadRes.DisplayMember = "NOMBRE";
            this.cmbCiudadRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudadRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCiudadRes.FormattingEnabled = true;
            this.cmbCiudadRes.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbCiudadRes.Location = new System.Drawing.Point(24, 166);
            this.cmbCiudadRes.Name = "cmbCiudadRes";
            this.cmbCiudadRes.Size = new System.Drawing.Size(269, 21);
            this.cmbCiudadRes.TabIndex = 9;
            this.cmbCiudadRes.ValueMember = "ID_CIUDAD";
            this.cmbCiudadRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCiudadRes_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(21, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 232;
            this.label7.Text = "Ciudad Residencia";
            // 
            // cmbCatLicencia
            // 
            this.cmbCatLicencia.DisplayMember = "NUEVA_CATEGORIA";
            this.cmbCatLicencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCatLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCatLicencia.FormattingEnabled = true;
            this.cmbCatLicencia.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbCatLicencia.Location = new System.Drawing.Point(475, 165);
            this.cmbCatLicencia.Name = "cmbCatLicencia";
            this.cmbCatLicencia.Size = new System.Drawing.Size(151, 21);
            this.cmbCatLicencia.TabIndex = 11;
            this.cmbCatLicencia.ValueMember = "COD_CATEGORIA";
            this.cmbCatLicencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCatLicencia_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(472, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 235;
            this.label8.Text = "Categoria Licencia";
            // 
            // btnBuscarlugar
            // 
            this.btnBuscarlugar.ImageIndex = 10;
            this.btnBuscarlugar.ImageList = this.imageList1;
            this.btnBuscarlugar.Location = new System.Drawing.Point(447, 204);
            this.btnBuscarlugar.Name = "btnBuscarlugar";
            this.btnBuscarlugar.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarlugar.TabIndex = 17;
            this.btnBuscarlugar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnBuscarlugar, "Buscar Transito");
            this.btnBuscarlugar.UseVisualStyleBackColor = true;
            this.btnBuscarlugar.Click += new System.EventHandler(this.btnBuscarlugar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 13);
            this.label9.TabIndex = 238;
            this.label9.Text = "Tránsito Expide Licencia";
            // 
            // cmbOrgExpide
            // 
            this.cmbOrgExpide.DisplayMember = "NOMBRESECRETARIA";
            this.cmbOrgExpide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrgExpide.FormattingEnabled = true;
            this.cmbOrgExpide.Location = new System.Drawing.Point(24, 206);
            this.cmbOrgExpide.Name = "cmbOrgExpide";
            this.cmbOrgExpide.Size = new System.Drawing.Size(421, 21);
            this.cmbOrgExpide.TabIndex = 12;
            this.cmbOrgExpide.ValueMember = "IDORGTRANSITO";
            this.cmbOrgExpide.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbOrgExpide_KeyPress);
            // 
            // txtFecVenLic
            // 
            this.txtFecVenLic.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecVenLic.CustomFormat = "dd/MM/yyyy";
            this.txtFecVenLic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecVenLic.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFecVenLic.Location = new System.Drawing.Point(475, 206);
            this.txtFecVenLic.Name = "txtFecVenLic";
            this.txtFecVenLic.Size = new System.Drawing.Size(151, 20);
            this.txtFecVenLic.TabIndex = 13;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.Location = new System.Drawing.Point(472, 189);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(141, 13);
            this.label56.TabIndex = 240;
            this.label56.Text = "Fecha Vencimiento Licencia";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.Location = new System.Drawing.Point(188, 38);
            this.txtIdentificacion.MaxLength = 20;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(211, 20);
            this.txtIdentificacion.TabIndex = 208;
            this.toolTip1.SetToolTip(this.txtIdentificacion, "Buscar Infractor");
            // 
            // grbDatosUsuario
            // 
            this.grbDatosUsuario.Controls.Add(this.label10);
            this.grbDatosUsuario.Controls.Add(this.txtFecVenLic);
            this.grbDatosUsuario.Controls.Add(this.cmbTipoDoc);
            this.grbDatosUsuario.Controls.Add(this.label56);
            this.grbDatosUsuario.Controls.Add(this.label11);
            this.grbDatosUsuario.Controls.Add(this.btnBuscarlugar);
            this.grbDatosUsuario.Controls.Add(this.txtIdentificacion);
            this.grbDatosUsuario.Controls.Add(this.label59);
            this.grbDatosUsuario.Controls.Add(this.label9);
            this.grbDatosUsuario.Controls.Add(this.txtNombres);
            this.grbDatosUsuario.Controls.Add(this.cmbOrgExpide);
            this.grbDatosUsuario.Controls.Add(this.label57);
            this.grbDatosUsuario.Controls.Add(this.cmbCatLicencia);
            this.grbDatosUsuario.Controls.Add(this.txtApellidos);
            this.grbDatosUsuario.Controls.Add(this.label8);
            this.grbDatosUsuario.Controls.Add(this.btnBuscarCiudad);
            this.grbDatosUsuario.Controls.Add(this.txtNroLicencia);
            this.grbDatosUsuario.Controls.Add(this.cmbCiudadRes);
            this.grbDatosUsuario.Controls.Add(this.label1);
            this.grbDatosUsuario.Controls.Add(this.label7);
            this.grbDatosUsuario.Controls.Add(this.label2);
            this.grbDatosUsuario.Controls.Add(this.label6);
            this.grbDatosUsuario.Controls.Add(this.cmbSexo);
            this.grbDatosUsuario.Controls.Add(this.txtEmail);
            this.grbDatosUsuario.Controls.Add(this.buttons);
            this.grbDatosUsuario.Controls.Add(this.label5);
            this.grbDatosUsuario.Controls.Add(this.txtTelefono);
            this.grbDatosUsuario.Controls.Add(this.txtEdad);
            this.grbDatosUsuario.Controls.Add(this.label4);
            this.grbDatosUsuario.Controls.Add(this.label3);
            this.grbDatosUsuario.Controls.Add(this.txtDireccion);
            this.grbDatosUsuario.Location = new System.Drawing.Point(12, 97);
            this.grbDatosUsuario.Name = "grbDatosUsuario";
            this.grbDatosUsuario.Size = new System.Drawing.Size(651, 296);
            this.grbDatosUsuario.TabIndex = 241;
            this.grbDatosUsuario.TabStop = false;
            this.grbDatosUsuario.Text = "Datos Usuario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 209;
            this.label10.Text = "Tipo Documento\r\n";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DisplayMember = "DESCRIPCION";
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbTipoDoc.Location = new System.Drawing.Point(25, 38);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(157, 21);
            this.cmbTipoDoc.TabIndex = 207;
            this.cmbTipoDoc.ValueMember = "ID_DOCCOMP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(188, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 210;
            this.label11.Text = "Identificación";
            // 
            // grbDatosBusqueda
            // 
            this.grbDatosBusqueda.Controls.Add(this.label54);
            this.grbDatosBusqueda.Controls.Add(this.cmbTipoDocBusq);
            this.grbDatosBusqueda.Controls.Add(this.btnBuscarInfractor);
            this.grbDatosBusqueda.Controls.Add(this.label42);
            this.grbDatosBusqueda.Controls.Add(this.txtIdentificacionBusq);
            this.grbDatosBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grbDatosBusqueda.Name = "grbDatosBusqueda";
            this.grbDatosBusqueda.Size = new System.Drawing.Size(651, 71);
            this.grbDatosBusqueda.TabIndex = 242;
            this.grbDatosBusqueda.TabStop = false;
            this.grbDatosBusqueda.Text = "Datos Búsqueda";
            // 
            // fInfractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 405);
            this.Controls.Add(this.grbDatosBusqueda);
            this.Controls.Add(this.grbDatosUsuario);
            this.Name = "fInfractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion Infractor";
            this.Load += new System.EventHandler(this.fInfractor_Load);
            this.buttons.ResumeLayout(false);
            this.grbDatosUsuario.ResumeLayout(false);
            this.grbDatosUsuario.PerformLayout();
            this.grbDatosBusqueda.ResumeLayout(false);
            this.grbDatosBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoDocBusq;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtIdentificacionBusq;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNroLicencia;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarInfractor;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnBuscarCiudad;
        private System.Windows.Forms.ComboBox cmbCiudadRes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCatLicencia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscarlugar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbOrgExpide;
        private System.Windows.Forms.DateTimePicker txtFecVenLic;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ImageList imageList4;
        private System.Windows.Forms.GroupBox grbDatosUsuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.GroupBox grbDatosBusqueda;
    }
}