namespace Comparendos.servicios.documentos
{
    partial class fGenerarResolucionFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGenerarResolucionFecha));
            this.grpBoxInfoInfrac = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPlantillaImposicion = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlantillaMotoTaxi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPlantillaAlcoholemia = new System.Windows.Forms.ComboBox();
            this.btnBuscarComparendos = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtGrViewComparendos = new System.Windows.Forms.DataGridView();
            this.btnGenerarResolucion = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroResolucion = new System.Windows.Forms.TextBox();
            this.grbInfoAdicional = new System.Windows.Forms.GroupBox();
            this.txtConsidJurid = new System.Windows.Forms.TextBox();
            this.lblConsidJurid = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtPickFechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtPickFechaAudiencia = new System.Windows.Forms.DateTimePicker();
            this.lblFecAudi = new System.Windows.Forms.Label();
            this.chkSeleccionarTodos = new System.Windows.Forms.CheckBox();
            this.grbAccionAlcoholemia = new System.Windows.Forms.GroupBox();
            this.lblMeses = new System.Windows.Forms.Label();
            this.lblTipoSuspension = new System.Windows.Forms.Label();
            this.txtTiempoSuspension = new System.Windows.Forms.TextBox();
            this.rbtEspecificarAccion = new System.Windows.Forms.RadioButton();
            this.rbtPorDefecto = new System.Windows.Forms.RadioButton();
            this.lblTipoAccion = new System.Windows.Forms.Label();
            this.cmbTipoAccionAlcoholemia = new System.Windows.Forms.ComboBox();
            this.grpBoxInfoInfrac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewComparendos)).BeginInit();
            this.grbInfoAdicional.SuspendLayout();
            this.grbAccionAlcoholemia.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxInfoInfrac
            // 
            this.grpBoxInfoInfrac.Controls.Add(this.label8);
            this.grpBoxInfoInfrac.Controls.Add(this.label5);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbPlantillaImposicion);
            this.grpBoxInfoInfrac.Controls.Add(this.label4);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbPlantillaMotoTaxi);
            this.grpBoxInfoInfrac.Controls.Add(this.label1);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbPlantillaAlcoholemia);
            this.grpBoxInfoInfrac.Controls.Add(this.btnBuscarComparendos);
            this.grpBoxInfoInfrac.Controls.Add(this.dtFechaFin);
            this.grpBoxInfoInfrac.Controls.Add(this.label2);
            this.grpBoxInfoInfrac.Controls.Add(this.dtFechaInicio);
            this.grpBoxInfoInfrac.Controls.Add(this.label3);
            this.grpBoxInfoInfrac.Location = new System.Drawing.Point(12, 12);
            this.grpBoxInfoInfrac.Name = "grpBoxInfoInfrac";
            this.grpBoxInfoInfrac.Size = new System.Drawing.Size(1093, 109);
            this.grpBoxInfoInfrac.TabIndex = 0;
            this.grpBoxInfoInfrac.TabStop = false;
            this.grpBoxInfoInfrac.Text = "Búsqueda Comparendos y Selección Plantillas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Seleccione la plantilla a utilizar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(622, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Imposición:";
            // 
            // cmbPlantillaImposicion
            // 
            this.cmbPlantillaImposicion.DisplayMember = "NOMBRE";
            this.cmbPlantillaImposicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlantillaImposicion.FormattingEnabled = true;
            this.cmbPlantillaImposicion.Location = new System.Drawing.Point(700, 19);
            this.cmbPlantillaImposicion.Name = "cmbPlantillaImposicion";
            this.cmbPlantillaImposicion.Size = new System.Drawing.Size(258, 21);
            this.cmbPlantillaImposicion.TabIndex = 24;
            this.cmbPlantillaImposicion.ValueMember = "ID";
            this.cmbPlantillaImposicion.SelectedIndexChanged += new System.EventHandler(this.cmbPlantillaImposicion_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(612, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Mototaxismo:";
            // 
            // cmbPlantillaMotoTaxi
            // 
            this.cmbPlantillaMotoTaxi.DisplayMember = "NOMBRE";
            this.cmbPlantillaMotoTaxi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlantillaMotoTaxi.FormattingEnabled = true;
            this.cmbPlantillaMotoTaxi.Location = new System.Drawing.Point(700, 75);
            this.cmbPlantillaMotoTaxi.Name = "cmbPlantillaMotoTaxi";
            this.cmbPlantillaMotoTaxi.Size = new System.Drawing.Size(258, 21);
            this.cmbPlantillaMotoTaxi.TabIndex = 22;
            this.cmbPlantillaMotoTaxi.ValueMember = "ID";
            this.cmbPlantillaMotoTaxi.SelectedIndexChanged += new System.EventHandler(this.cmbPlantillaMotoTaxi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(614, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Alcoholemia:";
            // 
            // cmbPlantillaAlcoholemia
            // 
            this.cmbPlantillaAlcoholemia.DisplayMember = "NOMBRE";
            this.cmbPlantillaAlcoholemia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlantillaAlcoholemia.FormattingEnabled = true;
            this.cmbPlantillaAlcoholemia.Location = new System.Drawing.Point(700, 48);
            this.cmbPlantillaAlcoholemia.Name = "cmbPlantillaAlcoholemia";
            this.cmbPlantillaAlcoholemia.Size = new System.Drawing.Size(258, 21);
            this.cmbPlantillaAlcoholemia.TabIndex = 20;
            this.cmbPlantillaAlcoholemia.ValueMember = "ID";
            this.cmbPlantillaAlcoholemia.SelectedIndexChanged += new System.EventHandler(this.cmbPlantillaAlcoholemia_SelectedIndexChanged);
            // 
            // btnBuscarComparendos
            // 
            this.btnBuscarComparendos.ImageIndex = 10;
            this.btnBuscarComparendos.ImageList = this.imageList1;
            this.btnBuscarComparendos.Location = new System.Drawing.Point(260, 35);
            this.btnBuscarComparendos.Name = "btnBuscarComparendos";
            this.btnBuscarComparendos.Size = new System.Drawing.Size(111, 45);
            this.btnBuscarComparendos.TabIndex = 19;
            this.btnBuscarComparendos.Text = "Buscar Comparendos";
            this.btnBuscarComparendos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarComparendos.UseVisualStyleBackColor = true;
            this.btnBuscarComparendos.Click += new System.EventHandler(this.btnBuscarComparendos_Click);
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
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaFin.Location = new System.Drawing.Point(131, 64);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(110, 20);
            this.dtFechaFin.TabIndex = 2;
            this.dtFechaFin.Value = new System.DateTime(2013, 4, 12, 0, 0, 0, 0);
            this.dtFechaFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtFin_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Fecha Fin:";
            // 
            // dtFechaInicio
            // 
            this.dtFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaInicio.Location = new System.Drawing.Point(131, 35);
            this.dtFechaInicio.Name = "dtFechaInicio";
            this.dtFechaInicio.Size = new System.Drawing.Size(110, 20);
            this.dtFechaInicio.TabIndex = 1;
            this.dtFechaInicio.Value = new System.DateTime(2013, 4, 12, 0, 0, 0, 0);
            this.dtFechaInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtInicio_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Fecha Inicio:";
            // 
            // dtGrViewComparendos
            // 
            this.dtGrViewComparendos.AllowUserToAddRows = false;
            this.dtGrViewComparendos.AllowUserToDeleteRows = false;
            this.dtGrViewComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrViewComparendos.Location = new System.Drawing.Point(12, 154);
            this.dtGrViewComparendos.Name = "dtGrViewComparendos";
            this.dtGrViewComparendos.ReadOnly = true;
            this.dtGrViewComparendos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrViewComparendos.Size = new System.Drawing.Size(1093, 248);
            this.dtGrViewComparendos.TabIndex = 5;
            // 
            // btnGenerarResolucion
            // 
            this.btnGenerarResolucion.ImageKey = "go-last.png";
            this.btnGenerarResolucion.ImageList = this.imageList1;
            this.btnGenerarResolucion.Location = new System.Drawing.Point(941, 577);
            this.btnGenerarResolucion.Name = "btnGenerarResolucion";
            this.btnGenerarResolucion.Size = new System.Drawing.Size(129, 34);
            this.btnGenerarResolucion.TabIndex = 6;
            this.btnGenerarResolucion.TabStop = false;
            this.btnGenerarResolucion.Text = "&Generar Resolucion";
            this.btnGenerarResolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerarResolucion.UseVisualStyleBackColor = true;
            this.btnGenerarResolucion.Click += new System.EventHandler(this.btnGenerarResolucion_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 534);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Núm. Resolución Inicio:";
            // 
            // txtNumeroResolucion
            // 
            this.txtNumeroResolucion.Location = new System.Drawing.Point(175, 530);
            this.txtNumeroResolucion.Name = "txtNumeroResolucion";
            this.txtNumeroResolucion.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroResolucion.TabIndex = 27;
            this.txtNumeroResolucion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroResolucion_KeyDown);
            this.txtNumeroResolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroResolucion_KeyPress);
            // 
            // grbInfoAdicional
            // 
            this.grbInfoAdicional.Controls.Add(this.txtConsidJurid);
            this.grbInfoAdicional.Controls.Add(this.lblConsidJurid);
            this.grbInfoAdicional.Controls.Add(this.lblMotivo);
            this.grbInfoAdicional.Controls.Add(this.txtMotivo);
            this.grbInfoAdicional.Location = new System.Drawing.Point(12, 408);
            this.grbInfoAdicional.Name = "grbInfoAdicional";
            this.grbInfoAdicional.Size = new System.Drawing.Size(1093, 107);
            this.grbInfoAdicional.TabIndex = 28;
            this.grbInfoAdicional.TabStop = false;
            this.grbInfoAdicional.Text = "Info Adicional";
            // 
            // txtConsidJurid
            // 
            this.txtConsidJurid.Location = new System.Drawing.Point(139, 60);
            this.txtConsidJurid.Multiline = true;
            this.txtConsidJurid.Name = "txtConsidJurid";
            this.txtConsidJurid.Size = new System.Drawing.Size(919, 28);
            this.txtConsidJurid.TabIndex = 11;
            this.txtConsidJurid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsidJurid_KeyPress);
            // 
            // lblConsidJurid
            // 
            this.lblConsidJurid.AutoSize = true;
            this.lblConsidJurid.Location = new System.Drawing.Point(15, 63);
            this.lblConsidJurid.Name = "lblConsidJurid";
            this.lblConsidJurid.Size = new System.Drawing.Size(118, 13);
            this.lblConsidJurid.TabIndex = 10;
            this.lblConsidJurid.Text = "Consideración Jurídica:";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(91, 25);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(42, 13);
            this.lblMotivo.TabIndex = 9;
            this.lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(139, 22);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(919, 28);
            this.txtMotivo.TabIndex = 8;
            this.txtMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMotivo_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(281, 534);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Presione Enter para verificar el número de resolución.";
            // 
            // dtPickFechaResolucion
            // 
            this.dtPickFechaResolucion.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaResolucion.Location = new System.Drawing.Point(175, 582);
            this.dtPickFechaResolucion.Name = "dtPickFechaResolucion";
            this.dtPickFechaResolucion.Size = new System.Drawing.Size(100, 20);
            this.dtPickFechaResolucion.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(56, 586);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Fecha Resolución:";
            // 
            // dtPickFechaAudiencia
            // 
            this.dtPickFechaAudiencia.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaAudiencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaAudiencia.Location = new System.Drawing.Point(175, 556);
            this.dtPickFechaAudiencia.Name = "dtPickFechaAudiencia";
            this.dtPickFechaAudiencia.Size = new System.Drawing.Size(100, 20);
            this.dtPickFechaAudiencia.TabIndex = 30;
            // 
            // lblFecAudi
            // 
            this.lblFecAudi.AutoSize = true;
            this.lblFecAudi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecAudi.Location = new System.Drawing.Point(63, 560);
            this.lblFecAudi.Name = "lblFecAudi";
            this.lblFecAudi.Size = new System.Drawing.Size(106, 13);
            this.lblFecAudi.TabIndex = 32;
            this.lblFecAudi.Text = "Fecha Audiencia:";
            // 
            // chkSeleccionarTodos
            // 
            this.chkSeleccionarTodos.AutoSize = true;
            this.chkSeleccionarTodos.Location = new System.Drawing.Point(12, 131);
            this.chkSeleccionarTodos.Name = "chkSeleccionarTodos";
            this.chkSeleccionarTodos.Size = new System.Drawing.Size(115, 17);
            this.chkSeleccionarTodos.TabIndex = 34;
            this.chkSeleccionarTodos.Text = "Seleccionar Todos";
            this.chkSeleccionarTodos.UseVisualStyleBackColor = true;
            this.chkSeleccionarTodos.CheckedChanged += new System.EventHandler(this.chkSeleccionarTodos_CheckedChanged);
            // 
            // grbAccionAlcoholemia
            // 
            this.grbAccionAlcoholemia.Controls.Add(this.lblMeses);
            this.grbAccionAlcoholemia.Controls.Add(this.lblTipoSuspension);
            this.grbAccionAlcoholemia.Controls.Add(this.txtTiempoSuspension);
            this.grbAccionAlcoholemia.Controls.Add(this.rbtEspecificarAccion);
            this.grbAccionAlcoholemia.Controls.Add(this.rbtPorDefecto);
            this.grbAccionAlcoholemia.Controls.Add(this.lblTipoAccion);
            this.grbAccionAlcoholemia.Controls.Add(this.cmbTipoAccionAlcoholemia);
            this.grbAccionAlcoholemia.Location = new System.Drawing.Point(577, 530);
            this.grbAccionAlcoholemia.Name = "grbAccionAlcoholemia";
            this.grbAccionAlcoholemia.Size = new System.Drawing.Size(277, 122);
            this.grbAccionAlcoholemia.TabIndex = 35;
            this.grbAccionAlcoholemia.TabStop = false;
            this.grbAccionAlcoholemia.Text = "Acción en caso de Alcoholemia";
            // 
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(185, 91);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(40, 13);
            this.lblMeses.TabIndex = 6;
            this.lblMeses.Text = "meses.";
            // 
            // lblTipoSuspension
            // 
            this.lblTipoSuspension.AutoSize = true;
            this.lblTipoSuspension.Location = new System.Drawing.Point(27, 91);
            this.lblTipoSuspension.Name = "lblTipoSuspension";
            this.lblTipoSuspension.Size = new System.Drawing.Size(101, 13);
            this.lblTipoSuspension.TabIndex = 5;
            this.lblTipoSuspension.Text = "Tiempo suspensión:";
            // 
            // txtTiempoSuspension
            // 
            this.txtTiempoSuspension.Location = new System.Drawing.Point(134, 87);
            this.txtTiempoSuspension.Name = "txtTiempoSuspension";
            this.txtTiempoSuspension.Size = new System.Drawing.Size(45, 20);
            this.txtTiempoSuspension.TabIndex = 4;
            this.txtTiempoSuspension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiempoSuspension_KeyPress_1);
            // 
            // rbtEspecificarAccion
            // 
            this.rbtEspecificarAccion.AutoSize = true;
            this.rbtEspecificarAccion.Location = new System.Drawing.Point(22, 43);
            this.rbtEspecificarAccion.Name = "rbtEspecificarAccion";
            this.rbtEspecificarAccion.Size = new System.Drawing.Size(112, 17);
            this.rbtEspecificarAccion.TabIndex = 3;
            this.rbtEspecificarAccion.TabStop = true;
            this.rbtEspecificarAccion.Text = "Especificar acción";
            this.rbtEspecificarAccion.UseVisualStyleBackColor = true;
            // 
            // rbtPorDefecto
            // 
            this.rbtPorDefecto.AutoSize = true;
            this.rbtPorDefecto.Location = new System.Drawing.Point(22, 20);
            this.rbtPorDefecto.Name = "rbtPorDefecto";
            this.rbtPorDefecto.Size = new System.Drawing.Size(80, 17);
            this.rbtPorDefecto.TabIndex = 2;
            this.rbtPorDefecto.TabStop = true;
            this.rbtPorDefecto.Text = "Por defecto";
            this.rbtPorDefecto.UseVisualStyleBackColor = true;
            // 
            // lblTipoAccion
            // 
            this.lblTipoAccion.AutoSize = true;
            this.lblTipoAccion.Location = new System.Drawing.Point(85, 67);
            this.lblTipoAccion.Name = "lblTipoAccion";
            this.lblTipoAccion.Size = new System.Drawing.Size(43, 13);
            this.lblTipoAccion.TabIndex = 1;
            this.lblTipoAccion.Text = "Acción:";
            // 
            // cmbTipoAccionAlcoholemia
            // 
            this.cmbTipoAccionAlcoholemia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAccionAlcoholemia.FormattingEnabled = true;
            this.cmbTipoAccionAlcoholemia.Location = new System.Drawing.Point(134, 63);
            this.cmbTipoAccionAlcoholemia.Name = "cmbTipoAccionAlcoholemia";
            this.cmbTipoAccionAlcoholemia.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoAccionAlcoholemia.TabIndex = 0;
            this.cmbTipoAccionAlcoholemia.SelectedIndexChanged += new System.EventHandler(this.cmbTipoAccionAlcoholemia_SelectedIndexChanged);
            // 
            // fGenerarResolucionFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 658);
            this.Controls.Add(this.grbAccionAlcoholemia);
            this.Controls.Add(this.chkSeleccionarTodos);
            this.Controls.Add(this.dtPickFechaResolucion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtPickFechaAudiencia);
            this.Controls.Add(this.lblFecAudi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grbInfoAdicional);
            this.Controls.Add(this.txtNumeroResolucion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGenerarResolucion);
            this.Controls.Add(this.dtGrViewComparendos);
            this.Controls.Add(this.grpBoxInfoInfrac);
            this.Name = "fGenerarResolucionFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Resolución";
            this.Load += new System.EventHandler(this.fGenerarResolucionFecha_Load);
            this.grpBoxInfoInfrac.ResumeLayout(false);
            this.grpBoxInfoInfrac.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewComparendos)).EndInit();
            this.grbInfoAdicional.ResumeLayout(false);
            this.grbInfoAdicional.PerformLayout();
            this.grbAccionAlcoholemia.ResumeLayout(false);
            this.grbAccionAlcoholemia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxInfoInfrac;
        private System.Windows.Forms.DataGridView dtGrViewComparendos;
        private System.Windows.Forms.Button btnGenerarResolucion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarComparendos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPlantillaImposicion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlantillaMotoTaxi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPlantillaAlcoholemia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroResolucion;
        private System.Windows.Forms.GroupBox grbInfoAdicional;
        private System.Windows.Forms.TextBox txtConsidJurid;
        private System.Windows.Forms.Label lblConsidJurid;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtPickFechaResolucion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtPickFechaAudiencia;
        private System.Windows.Forms.Label lblFecAudi;
        private System.Windows.Forms.CheckBox chkSeleccionarTodos;
        private System.Windows.Forms.GroupBox grbAccionAlcoholemia;
        private System.Windows.Forms.Label lblMeses;
        private System.Windows.Forms.Label lblTipoSuspension;
        private System.Windows.Forms.TextBox txtTiempoSuspension;
        private System.Windows.Forms.RadioButton rbtEspecificarAccion;
        private System.Windows.Forms.RadioButton rbtPorDefecto;
        private System.Windows.Forms.Label lblTipoAccion;
        private System.Windows.Forms.ComboBox cmbTipoAccionAlcoholemia;
    }
}