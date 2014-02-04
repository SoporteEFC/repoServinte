namespace Comparendos.servicios.generales
{
    partial class fVehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fVehiculos));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlacaBusq = new System.Windows.Forms.TextBox();
            this.cmbCVehiculo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNroLicencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTServicio = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnPost = new System.Windows.Forms.Button();
            this.grbInfoPublicos = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTOperacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTransPas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbModalidad = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRadioAccion = new System.Windows.Forms.ComboBox();
            this.btnBuscarEmpresa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEmpresa = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLugarMatricula = new System.Windows.Forms.ComboBox();
            this.btnBuscarlugar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearchVehi = new System.Windows.Forms.Button();
            this.grbDatosBusqueda = new System.Windows.Forms.GroupBox();
            this.grbDatosVehiculo = new System.Windows.Forms.GroupBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttons.SuspendLayout();
            this.grbInfoPublicos.SuspendLayout();
            this.grbDatosBusqueda.SuspendLayout();
            this.grbDatosVehiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Clase de Vehículo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Placa";
            // 
            // txtPlacaBusq
            // 
            this.txtPlacaBusq.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlacaBusq.Enabled = false;
            this.txtPlacaBusq.Location = new System.Drawing.Point(82, 37);
            this.txtPlacaBusq.MaxLength = 6;
            this.txtPlacaBusq.Name = "txtPlacaBusq";
            this.txtPlacaBusq.Size = new System.Drawing.Size(97, 20);
            this.txtPlacaBusq.TabIndex = 0;
            this.txtPlacaBusq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlacaBusq_KeyDown);
            // 
            // cmbCVehiculo
            // 
            this.cmbCVehiculo.DisplayMember = "DESCRIPCION";
            this.cmbCVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCVehiculo.FormattingEnabled = true;
            this.cmbCVehiculo.Location = new System.Drawing.Point(335, 34);
            this.cmbCVehiculo.Name = "cmbCVehiculo";
            this.cmbCVehiculo.Size = new System.Drawing.Size(138, 21);
            this.cmbCVehiculo.TabIndex = 3;
            this.cmbCVehiculo.ValueMember = "ID_CVEHICULO";
            this.cmbCVehiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbCVehiculo_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nro. Licencia de Tránsito";
            // 
            // txtNroLicencia
            // 
            this.txtNroLicencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNroLicencia.Location = new System.Drawing.Point(151, 35);
            this.txtNroLicencia.Name = "txtNroLicencia";
            this.txtNroLicencia.Size = new System.Drawing.Size(174, 20);
            this.txtNroLicencia.TabIndex = 2;
            this.txtNroLicencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroLicencia_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo de Servicio";
            // 
            // cmbTServicio
            // 
            this.cmbTServicio.DisplayMember = "DESCRIPCION";
            this.cmbTServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTServicio.FormattingEnabled = true;
            this.cmbTServicio.Location = new System.Drawing.Point(482, 34);
            this.cmbTServicio.Name = "cmbTServicio";
            this.cmbTServicio.Size = new System.Drawing.Size(138, 21);
            this.cmbTServicio.TabIndex = 4;
            this.cmbTServicio.ValueMember = "ID_SERVICIO";
            this.cmbTServicio.SelectedIndexChanged += new System.EventHandler(this.cmbTServicio_SelectedIndexChanged);
            this.cmbTServicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTServicio_KeyPress);
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
            this.buttons.Controls.Add(this.btnNuevo);
            this.buttons.Controls.Add(this.btnCancelar);
            this.buttons.Controls.Add(this.btnSalir);
            this.buttons.Controls.Add(this.btnEdit);
            this.buttons.Controls.Add(this.btnPost);
            this.buttons.Location = new System.Drawing.Point(135, 215);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(372, 41);
            this.buttons.TabIndex = 192;
            this.buttons.TabStop = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.ImageIndex = 8;
            this.btnNuevo.ImageList = this.imageList1;
            this.btnNuevo.Location = new System.Drawing.Point(6, 9);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(72, 28);
            this.btnNuevo.TabIndex = 198;
            this.btnNuevo.TabStop = false;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.ImageKey = "16 (Db cancel).ico";
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(222, 9);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(72, 28);
            this.btnCancelar.TabIndex = 197;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.ImageKey = "button_cancel.ico";
            this.btnSalir.ImageList = this.imageList1;
            this.btnSalir.Location = new System.Drawing.Point(294, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(72, 28);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.ImageIndex = 15;
            this.btnEdit.ImageList = this.imageList2;
            this.btnEdit.Location = new System.Drawing.Point(150, 9);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(72, 28);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "&Editar";
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
            // btnPost
            // 
            this.btnPost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPost.ImageIndex = 23;
            this.btnPost.ImageList = this.imageList1;
            this.btnPost.Location = new System.Drawing.Point(78, 9);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(72, 28);
            this.btnPost.TabIndex = 10;
            this.btnPost.TabStop = false;
            this.btnPost.Text = "&Guardar";
            this.btnPost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // grbInfoPublicos
            // 
            this.grbInfoPublicos.Controls.Add(this.label10);
            this.grbInfoPublicos.Controls.Add(this.txtTOperacion);
            this.grbInfoPublicos.Controls.Add(this.label9);
            this.grbInfoPublicos.Controls.Add(this.cmbTransPas);
            this.grbInfoPublicos.Controls.Add(this.label8);
            this.grbInfoPublicos.Controls.Add(this.cmbModalidad);
            this.grbInfoPublicos.Controls.Add(this.label7);
            this.grbInfoPublicos.Controls.Add(this.cmbRadioAccion);
            this.grbInfoPublicos.Controls.Add(this.btnBuscarEmpresa);
            this.grbInfoPublicos.Controls.Add(this.label6);
            this.grbInfoPublicos.Controls.Add(this.cmbEmpresa);
            this.grbInfoPublicos.Location = new System.Drawing.Point(20, 109);
            this.grbInfoPublicos.Name = "grbInfoPublicos";
            this.grbInfoPublicos.Size = new System.Drawing.Size(600, 100);
            this.grbInfoPublicos.TabIndex = 193;
            this.grbInfoPublicos.TabStop = false;
            this.grbInfoPublicos.Text = "[Solamente para vehículos públicos]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(357, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 13);
            this.label10.TabIndex = 208;
            this.label10.Text = "Nro. Tarjeta de Operación";
            // 
            // txtTOperacion
            // 
            this.txtTOperacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTOperacion.Location = new System.Drawing.Point(360, 71);
            this.txtTOperacion.MaxLength = 6;
            this.txtTOperacion.Name = "txtTOperacion";
            this.txtTOperacion.Size = new System.Drawing.Size(233, 20);
            this.txtTOperacion.TabIndex = 9;
            this.txtTOperacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTOperacion_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 206;
            this.label9.Text = "Transporte de Pasajeros";
            // 
            // cmbTransPas
            // 
            this.cmbTransPas.DisplayMember = "DESC_TIPOTRANSPORTE";
            this.cmbTransPas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransPas.FormattingEnabled = true;
            this.cmbTransPas.Location = new System.Drawing.Point(191, 71);
            this.cmbTransPas.Name = "cmbTransPas";
            this.cmbTransPas.Size = new System.Drawing.Size(160, 21);
            this.cmbTransPas.TabIndex = 9;
            this.cmbTransPas.ValueMember = "ID_TIPOTRANSPORTE";
            this.cmbTransPas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTransPas_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 204;
            this.label8.Text = "Modalidad de Transporte";
            // 
            // cmbModalidad
            // 
            this.cmbModalidad.DisplayMember = "DESCRIPCION";
            this.cmbModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalidad.FormattingEnabled = true;
            this.cmbModalidad.Location = new System.Drawing.Point(6, 71);
            this.cmbModalidad.Name = "cmbModalidad";
            this.cmbModalidad.Size = new System.Drawing.Size(177, 21);
            this.cmbModalidad.TabIndex = 8;
            this.cmbModalidad.ValueMember = "ID_MODALIDAD";
            this.cmbModalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbModalidad_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(357, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 202;
            this.label7.Text = "Radio de Acción";
            // 
            // cmbRadioAccion
            // 
            this.cmbRadioAccion.DisplayMember = "DESC_RADIOACCION";
            this.cmbRadioAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRadioAccion.FormattingEnabled = true;
            this.cmbRadioAccion.Location = new System.Drawing.Point(360, 32);
            this.cmbRadioAccion.Name = "cmbRadioAccion";
            this.cmbRadioAccion.Size = new System.Drawing.Size(233, 21);
            this.cmbRadioAccion.TabIndex = 7;
            this.cmbRadioAccion.ValueMember = "ID_RADIODEACCION";
            this.cmbRadioAccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRadioAccion_KeyPress);
            // 
            // btnBuscarEmpresa
            // 
            this.btnBuscarEmpresa.ImageIndex = 10;
            this.btnBuscarEmpresa.ImageList = this.imageList1;
            this.btnBuscarEmpresa.Location = new System.Drawing.Point(330, 30);
            this.btnBuscarEmpresa.Name = "btnBuscarEmpresa";
            this.btnBuscarEmpresa.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarEmpresa.TabIndex = 9;
            this.btnBuscarEmpresa.TabStop = false;
            this.toolTip1.SetToolTip(this.btnBuscarEmpresa, "Buscar Empresa");
            this.btnBuscarEmpresa.UseVisualStyleBackColor = true;
            this.btnBuscarEmpresa.Click += new System.EventHandler(this.btnBuscarEmpresa_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 199;
            this.label6.Text = "Empresa";
            // 
            // cmbEmpresa
            // 
            this.cmbEmpresa.DisplayMember = "NOMBRE";
            this.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpresa.FormattingEnabled = true;
            this.cmbEmpresa.Location = new System.Drawing.Point(6, 31);
            this.cmbEmpresa.Name = "cmbEmpresa";
            this.cmbEmpresa.Size = new System.Drawing.Size(321, 21);
            this.cmbEmpresa.TabIndex = 6;
            this.cmbEmpresa.ValueMember = "ID_EMPSERVICIO";
            this.cmbEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbEmpresa_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 195;
            this.label5.Text = "Vehículo Matriculado En:";
            // 
            // cmbLugarMatricula
            // 
            this.cmbLugarMatricula.DisplayMember = "NOMBRESECRETARIA";
            this.cmbLugarMatricula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLugarMatricula.FormattingEnabled = true;
            this.cmbLugarMatricula.Location = new System.Drawing.Point(23, 74);
            this.cmbLugarMatricula.Name = "cmbLugarMatricula";
            this.cmbLugarMatricula.Size = new System.Drawing.Size(571, 21);
            this.cmbLugarMatricula.TabIndex = 5;
            this.cmbLugarMatricula.ValueMember = "IDORGTRANSITO";
            this.cmbLugarMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbLugarMatricula_KeyPress);
            // 
            // btnBuscarlugar
            // 
            this.btnBuscarlugar.ImageIndex = 10;
            this.btnBuscarlugar.ImageList = this.imageList1;
            this.btnBuscarlugar.Location = new System.Drawing.Point(595, 73);
            this.btnBuscarlugar.Name = "btnBuscarlugar";
            this.btnBuscarlugar.Size = new System.Drawing.Size(23, 23);
            this.btnBuscarlugar.TabIndex = 7;
            this.btnBuscarlugar.TabStop = false;
            this.toolTip1.SetToolTip(this.btnBuscarlugar, "Buscar Transito");
            this.btnBuscarlugar.UseVisualStyleBackColor = true;
            this.btnBuscarlugar.Click += new System.EventHandler(this.btnBuscarlugar_Click);
            // 
            // btnSearchVehi
            // 
            this.btnSearchVehi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchVehi.ImageKey = "search.ico";
            this.btnSearchVehi.ImageList = this.imageList1;
            this.btnSearchVehi.Location = new System.Drawing.Point(182, 35);
            this.btnSearchVehi.Name = "btnSearchVehi";
            this.btnSearchVehi.Size = new System.Drawing.Size(65, 23);
            this.btnSearchVehi.TabIndex = 196;
            this.btnSearchVehi.TabStop = false;
            this.btnSearchVehi.Text = "Buscar";
            this.btnSearchVehi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchVehi.UseVisualStyleBackColor = true;
            this.btnSearchVehi.Click += new System.EventHandler(this.btnSearchVehi_Click);
            // 
            // grbDatosBusqueda
            // 
            this.grbDatosBusqueda.Controls.Add(this.txtPlacaBusq);
            this.grbDatosBusqueda.Controls.Add(this.btnSearchVehi);
            this.grbDatosBusqueda.Controls.Add(this.label1);
            this.grbDatosBusqueda.Location = new System.Drawing.Point(148, 12);
            this.grbDatosBusqueda.Name = "grbDatosBusqueda";
            this.grbDatosBusqueda.Size = new System.Drawing.Size(322, 70);
            this.grbDatosBusqueda.TabIndex = 197;
            this.grbDatosBusqueda.TabStop = false;
            this.grbDatosBusqueda.Text = "Datos Búsqueda";
            // 
            // grbDatosVehiculo
            // 
            this.grbDatosVehiculo.Controls.Add(this.txtPlaca);
            this.grbDatosVehiculo.Controls.Add(this.txtNroLicencia);
            this.grbDatosVehiculo.Controls.Add(this.label11);
            this.grbDatosVehiculo.Controls.Add(this.cmbCVehiculo);
            this.grbDatosVehiculo.Controls.Add(this.btnBuscarlugar);
            this.grbDatosVehiculo.Controls.Add(this.label2);
            this.grbDatosVehiculo.Controls.Add(this.label5);
            this.grbDatosVehiculo.Controls.Add(this.label3);
            this.grbDatosVehiculo.Controls.Add(this.cmbLugarMatricula);
            this.grbDatosVehiculo.Controls.Add(this.cmbTServicio);
            this.grbDatosVehiculo.Controls.Add(this.buttons);
            this.grbDatosVehiculo.Controls.Add(this.label4);
            this.grbDatosVehiculo.Controls.Add(this.grbInfoPublicos);
            this.grbDatosVehiculo.Location = new System.Drawing.Point(20, 94);
            this.grbDatosVehiculo.Name = "grbDatosVehiculo";
            this.grbDatosVehiculo.Size = new System.Drawing.Size(646, 270);
            this.grbDatosVehiculo.TabIndex = 198;
            this.grbDatosVehiculo.TabStop = false;
            this.grbDatosVehiculo.Text = "Datos Vehículo";
            // 
            // txtPlaca
            // 
            this.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaca.Enabled = false;
            this.txtPlaca.Location = new System.Drawing.Point(23, 35);
            this.txtPlaca.MaxLength = 6;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(97, 20);
            this.txtPlaca.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 198;
            this.label11.Text = "Placa";
            // 
            // fVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 381);
            this.Controls.Add(this.grbDatosVehiculo);
            this.Controls.Add(this.grbDatosBusqueda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "fVehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Gestión de Vehículos]";
            this.buttons.ResumeLayout(false);
            this.grbInfoPublicos.ResumeLayout(false);
            this.grbInfoPublicos.PerformLayout();
            this.grbDatosBusqueda.ResumeLayout(false);
            this.grbDatosBusqueda.PerformLayout();
            this.grbDatosVehiculo.ResumeLayout(false);
            this.grbDatosVehiculo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlacaBusq;
        private System.Windows.Forms.ComboBox cmbCVehiculo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNroLicencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTServicio;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.GroupBox grbInfoPublicos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbLugarMatricula;
        private System.Windows.Forms.Button btnBuscarlugar;
        private System.Windows.Forms.Button btnBuscarEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEmpresa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbRadioAccion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTOperacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTransPas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbModalidad;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSearchVehi;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox grbDatosBusqueda;
        private System.Windows.Forms.GroupBox grbDatosVehiculo;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label11;
    }
}