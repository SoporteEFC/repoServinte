using System.Windows.Forms;
namespace Comparendos.servicios.documentos
{
    partial class ResolImpoInfrac
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResolImpoInfrac));
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.cmbBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.grpBoxInfoInfrac = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPlantillaMotoTaxi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPlantillaAlcoholemia = new System.Windows.Forms.ComboBox();
            this.btn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbBoxPlantillas = new System.Windows.Forms.ComboBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtInfractor = new System.Windows.Forms.TextBox();
            this.lblInfractor = new System.Windows.Forms.Label();
            this.lblTipoResol = new System.Windows.Forms.Label();
            this.dtGrViewComparendos = new System.Windows.Forms.DataGridView();
            this.btnGenerarResolucion = new System.Windows.Forms.Button();
            this.lblNumResol = new System.Windows.Forms.Label();
            this.txtNumResol = new System.Windows.Forms.TextBox();
            this.lblFecAudi = new System.Windows.Forms.Label();
            this.dtPickFechaAudiencia = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPickFechaResolucion = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.grbInfoAdicional = new System.Windows.Forms.GroupBox();
            this.txtConsidJurid = new System.Windows.Forms.TextBox();
            this.lblConsidJurid = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.grbAccionAlcoholemia = new System.Windows.Forms.GroupBox();
            this.cmbTipoAccionAlcoholemia = new System.Windows.Forms.ComboBox();
            this.lblTipoAccion = new System.Windows.Forms.Label();
            this.rbtPorDefecto = new System.Windows.Forms.RadioButton();
            this.rbtEspecificarAccion = new System.Windows.Forms.RadioButton();
            this.txtTiempoSuspension = new System.Windows.Forms.TextBox();
            this.lblTipoSuspension = new System.Windows.Forms.Label();
            this.lblMeses = new System.Windows.Forms.Label();
            this.grpBoxInfoInfrac.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrViewComparendos)).BeginInit();
            this.grbInfoAdicional.SuspendLayout();
            this.grbAccionAlcoholemia.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDoc.Location = new System.Drawing.Point(15, 26);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(104, 13);
            this.lblTipoDoc.TabIndex = 0;
            this.lblTipoDoc.Text = "Tipo Documento:";
            // 
            // cmbBoxTipoDoc
            // 
            this.cmbBoxTipoDoc.DisplayMember = "DESCRIPCION";
            this.cmbBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxTipoDoc.FormattingEnabled = true;
            this.cmbBoxTipoDoc.Location = new System.Drawing.Point(125, 23);
            this.cmbBoxTipoDoc.Name = "cmbBoxTipoDoc";
            this.cmbBoxTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cmbBoxTipoDoc.TabIndex = 1;
            this.cmbBoxTipoDoc.TabStop = false;
            this.cmbBoxTipoDoc.ValueMember = "IDREPORTECOMPARENDO";
            this.cmbBoxTipoDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxTipoDoc_KeyPress);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.Location = new System.Drawing.Point(268, 26);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(99, 13);
            this.lblDocumento.TabIndex = 2;
            this.lblDocumento.Text = "No. Documento:";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(369, 23);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(117, 20);
            this.txtDocumento.TabIndex = 2;
            this.txtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumento_KeyDown);
            this.txtDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumento_KeyPress);
            // 
            // grpBoxInfoInfrac
            // 
            this.grpBoxInfoInfrac.Controls.Add(this.label4);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbPlantillaMotoTaxi);
            this.grpBoxInfoInfrac.Controls.Add(this.label3);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbPlantillaAlcoholemia);
            this.grpBoxInfoInfrac.Controls.Add(this.btn);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbBoxPlantillas);
            this.grpBoxInfoInfrac.Controls.Add(this.txtTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTelefono);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDireccion);
            this.grpBoxInfoInfrac.Controls.Add(this.txtInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblInfractor);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.lblTipoResol);
            this.grpBoxInfoInfrac.Controls.Add(this.txtDocumento);
            this.grpBoxInfoInfrac.Controls.Add(this.cmbBoxTipoDoc);
            this.grpBoxInfoInfrac.Controls.Add(this.lblDocumento);
            this.grpBoxInfoInfrac.Location = new System.Drawing.Point(12, 12);
            this.grpBoxInfoInfrac.Name = "grpBoxInfoInfrac";
            this.grpBoxInfoInfrac.Size = new System.Drawing.Size(1093, 142);
            this.grpBoxInfoInfrac.TabIndex = 0;
            this.grpBoxInfoInfrac.TabStop = false;
            this.grpBoxInfoInfrac.Text = "Información del Infractor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(598, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Mototaxismo:";
            // 
            // cmbPlantillaMotoTaxi
            // 
            this.cmbPlantillaMotoTaxi.DisplayMember = "NOMBRE";
            this.cmbPlantillaMotoTaxi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlantillaMotoTaxi.FormattingEnabled = true;
            this.cmbPlantillaMotoTaxi.Location = new System.Drawing.Point(686, 70);
            this.cmbPlantillaMotoTaxi.Name = "cmbPlantillaMotoTaxi";
            this.cmbPlantillaMotoTaxi.Size = new System.Drawing.Size(258, 21);
            this.cmbPlantillaMotoTaxi.TabIndex = 26;
            this.cmbPlantillaMotoTaxi.ValueMember = "ID";
            this.cmbPlantillaMotoTaxi.SelectedIndexChanged += new System.EventHandler(this.cmbPlantillaMotoTaxi_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(600, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Alcoholemia:";
            // 
            // cmbPlantillaAlcoholemia
            // 
            this.cmbPlantillaAlcoholemia.DisplayMember = "NOMBRE";
            this.cmbPlantillaAlcoholemia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlantillaAlcoholemia.FormattingEnabled = true;
            this.cmbPlantillaAlcoholemia.Location = new System.Drawing.Point(686, 43);
            this.cmbPlantillaAlcoholemia.Name = "cmbPlantillaAlcoholemia";
            this.cmbPlantillaAlcoholemia.Size = new System.Drawing.Size(258, 21);
            this.cmbPlantillaAlcoholemia.TabIndex = 24;
            this.cmbPlantillaAlcoholemia.ValueMember = "ID";
            this.cmbPlantillaAlcoholemia.SelectedIndexChanged += new System.EventHandler(this.cmbPlantillaAlcoholemia_SelectedIndexChanged);
            // 
            // btn
            // 
            this.btn.ImageIndex = 10;
            this.btn.ImageList = this.imageList1;
            this.btn.Location = new System.Drawing.Point(492, 21);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(30, 23);
            this.btn.TabIndex = 9;
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
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
            // cmbBoxPlantillas
            // 
            this.cmbBoxPlantillas.DisplayMember = "NOMBRE";
            this.cmbBoxPlantillas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxPlantillas.FormattingEnabled = true;
            this.cmbBoxPlantillas.Location = new System.Drawing.Point(685, 18);
            this.cmbBoxPlantillas.Name = "cmbBoxPlantillas";
            this.cmbBoxPlantillas.Size = new System.Drawing.Size(258, 21);
            this.cmbBoxPlantillas.TabIndex = 3;
            this.cmbBoxPlantillas.ValueMember = "ID";
            this.cmbBoxPlantillas.SelectedIndexChanged += new System.EventHandler(this.cmbBoxPlantillas_SelectedIndexChanged);
            this.cmbBoxPlantillas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBoxPlantillas_KeyPress);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(832, 107);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(111, 20);
            this.txtTelefono.TabIndex = 0;
            this.txtTelefono.TabStop = false;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(765, 110);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 13);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(456, 107);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(285, 20);
            this.txtDireccion.TabIndex = 0;
            this.txtDireccion.TabStop = false;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(385, 110);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(65, 13);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtInfractor
            // 
            this.txtInfractor.Enabled = false;
            this.txtInfractor.Location = new System.Drawing.Point(76, 107);
            this.txtInfractor.Name = "txtInfractor";
            this.txtInfractor.Size = new System.Drawing.Size(283, 20);
            this.txtInfractor.TabIndex = 0;
            this.txtInfractor.TabStop = false;
            // 
            // lblInfractor
            // 
            this.lblInfractor.AutoSize = true;
            this.lblInfractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfractor.Location = new System.Drawing.Point(11, 110);
            this.lblInfractor.Name = "lblInfractor";
            this.lblInfractor.Size = new System.Drawing.Size(59, 13);
            this.lblInfractor.TabIndex = 4;
            this.lblInfractor.Text = "Infractor:";
            // 
            // lblTipoResol
            // 
            this.lblTipoResol.AutoSize = true;
            this.lblTipoResol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoResol.Location = new System.Drawing.Point(559, 21);
            this.lblTipoResol.Name = "lblTipoResol";
            this.lblTipoResol.Size = new System.Drawing.Size(120, 13);
            this.lblTipoResol.TabIndex = 8;
            this.lblTipoResol.Text = "Plantilla Imposición:";
            // 
            // dtGrViewComparendos
            // 
            this.dtGrViewComparendos.AllowUserToAddRows = false;
            this.dtGrViewComparendos.AllowUserToDeleteRows = false;
            this.dtGrViewComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrViewComparendos.Location = new System.Drawing.Point(12, 160);
            this.dtGrViewComparendos.Name = "dtGrViewComparendos";
            this.dtGrViewComparendos.ReadOnly = true;
            this.dtGrViewComparendos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrViewComparendos.Size = new System.Drawing.Size(1093, 235);
            this.dtGrViewComparendos.TabIndex = 5;
            // 
            // btnGenerarResolucion
            // 
            this.btnGenerarResolucion.ImageIndex = 5;
            this.btnGenerarResolucion.ImageList = this.imageList1;
            this.btnGenerarResolucion.Location = new System.Drawing.Point(967, 568);
            this.btnGenerarResolucion.Name = "btnGenerarResolucion";
            this.btnGenerarResolucion.Size = new System.Drawing.Size(138, 32);
            this.btnGenerarResolucion.TabIndex = 8;
            this.btnGenerarResolucion.TabStop = false;
            this.btnGenerarResolucion.Text = "Generar &Resolución";
            this.btnGenerarResolucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerarResolucion.UseVisualStyleBackColor = true;
            this.btnGenerarResolucion.Click += new System.EventHandler(this.btnGenerarResolucion_Click);
            // 
            // lblNumResol
            // 
            this.lblNumResol.AutoSize = true;
            this.lblNumResol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumResol.Location = new System.Drawing.Point(27, 535);
            this.lblNumResol.Name = "lblNumResol";
            this.lblNumResol.Size = new System.Drawing.Size(121, 13);
            this.lblNumResol.TabIndex = 10;
            this.lblNumResol.Text = "Número Resolución:";
            // 
            // txtNumResol
            // 
            this.txtNumResol.Location = new System.Drawing.Point(152, 531);
            this.txtNumResol.Name = "txtNumResol";
            this.txtNumResol.Size = new System.Drawing.Size(103, 20);
            this.txtNumResol.TabIndex = 6;
            this.txtNumResol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumResol_KeyDown);
            this.txtNumResol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumResol_KeyPress);
            // 
            // lblFecAudi
            // 
            this.lblFecAudi.AutoSize = true;
            this.lblFecAudi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecAudi.Location = new System.Drawing.Point(42, 561);
            this.lblFecAudi.Name = "lblFecAudi";
            this.lblFecAudi.Size = new System.Drawing.Size(106, 13);
            this.lblFecAudi.TabIndex = 12;
            this.lblFecAudi.Text = "Fecha Audiencia:";
            // 
            // dtPickFechaAudiencia
            // 
            this.dtPickFechaAudiencia.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaAudiencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaAudiencia.Location = new System.Drawing.Point(152, 557);
            this.dtPickFechaAudiencia.Name = "dtPickFechaAudiencia";
            this.dtPickFechaAudiencia.Size = new System.Drawing.Size(103, 20);
            this.dtPickFechaAudiencia.TabIndex = 7;
            this.dtPickFechaAudiencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaAudiencia_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 587);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Fecha Resolución:";
            // 
            // dtPickFechaResolucion
            // 
            this.dtPickFechaResolucion.CustomFormat = "dd/MM/yyyy";
            this.dtPickFechaResolucion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickFechaResolucion.Location = new System.Drawing.Point(152, 583);
            this.dtPickFechaResolucion.Name = "dtPickFechaResolucion";
            this.dtPickFechaResolucion.Size = new System.Drawing.Size(103, 20);
            this.dtPickFechaResolucion.TabIndex = 8;
            this.dtPickFechaResolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtPickFechaResolucion_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Presione Enter para verificar el número de resolución.";
            // 
            // grbInfoAdicional
            // 
            this.grbInfoAdicional.Controls.Add(this.txtConsidJurid);
            this.grbInfoAdicional.Controls.Add(this.lblConsidJurid);
            this.grbInfoAdicional.Controls.Add(this.lblMotivo);
            this.grbInfoAdicional.Controls.Add(this.txtMotivo);
            this.grbInfoAdicional.Location = new System.Drawing.Point(12, 410);
            this.grbInfoAdicional.Name = "grbInfoAdicional";
            this.grbInfoAdicional.Size = new System.Drawing.Size(1093, 107);
            this.grbInfoAdicional.TabIndex = 16;
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
            this.grbAccionAlcoholemia.Location = new System.Drawing.Point(603, 523);
            this.grbAccionAlcoholemia.Name = "grbAccionAlcoholemia";
            this.grbAccionAlcoholemia.Size = new System.Drawing.Size(277, 122);
            this.grbAccionAlcoholemia.TabIndex = 17;
            this.grbAccionAlcoholemia.TabStop = false;
            this.grbAccionAlcoholemia.Text = "Acción en caso de Alcoholemia";
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
            // lblTipoAccion
            // 
            this.lblTipoAccion.AutoSize = true;
            this.lblTipoAccion.Location = new System.Drawing.Point(85, 67);
            this.lblTipoAccion.Name = "lblTipoAccion";
            this.lblTipoAccion.Size = new System.Drawing.Size(43, 13);
            this.lblTipoAccion.TabIndex = 1;
            this.lblTipoAccion.Text = "Acción:";
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
            // txtTiempoSuspension
            // 
            this.txtTiempoSuspension.Location = new System.Drawing.Point(134, 87);
            this.txtTiempoSuspension.Name = "txtTiempoSuspension";
            this.txtTiempoSuspension.Size = new System.Drawing.Size(45, 20);
            this.txtTiempoSuspension.TabIndex = 4;
            this.txtTiempoSuspension.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiempoSuspension_KeyPress);
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
            // lblMeses
            // 
            this.lblMeses.AutoSize = true;
            this.lblMeses.Location = new System.Drawing.Point(185, 91);
            this.lblMeses.Name = "lblMeses";
            this.lblMeses.Size = new System.Drawing.Size(40, 13);
            this.lblMeses.TabIndex = 6;
            this.lblMeses.Text = "meses.";
            // 
            // ResolImpoInfrac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 657);
            this.Controls.Add(this.grbAccionAlcoholemia);
            this.Controls.Add(this.grbInfoAdicional);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPickFechaResolucion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtPickFechaAudiencia);
            this.Controls.Add(this.lblFecAudi);
            this.Controls.Add(this.txtNumResol);
            this.Controls.Add(this.lblNumResol);
            this.Controls.Add(this.btnGenerarResolucion);
            this.Controls.Add(this.dtGrViewComparendos);
            this.Controls.Add(this.grpBoxInfoInfrac);
            this.Name = "ResolImpoInfrac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar Resolución Imposición por Infractor";
            this.Load += new System.EventHandler(this.ResolImpoInfrac_Load);
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

        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.ComboBox cmbBoxTipoDoc;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.GroupBox grpBoxInfoInfrac;
        private System.Windows.Forms.Label lblInfractor;
        private System.Windows.Forms.TextBox txtInfractor;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.DataGridView dtGrViewComparendos;
        private System.Windows.Forms.Button btnGenerarResolucion;
        private System.Windows.Forms.Label lblTipoResol;
        private System.Windows.Forms.Label lblNumResol;
        private System.Windows.Forms.TextBox txtNumResol;
        private System.Windows.Forms.Label lblFecAudi;
        private System.Windows.Forms.DateTimePicker dtPickFechaAudiencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPickFechaResolucion;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox cmbBoxPlantillas;
        private System.Windows.Forms.TextBox txtTelefono;
        private Button btn;
        private Label label2;
        private GroupBox grbInfoAdicional;
        private TextBox txtConsidJurid;
        private Label lblConsidJurid;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label label4;
        private ComboBox cmbPlantillaMotoTaxi;
        private Label label3;
        private ComboBox cmbPlantillaAlcoholemia;
        private GroupBox grbAccionAlcoholemia;
        private Label lblTipoSuspension;
        private TextBox txtTiempoSuspension;
        private RadioButton rbtEspecificarAccion;
        private RadioButton rbtPorDefecto;
        private Label lblTipoAccion;
        private ComboBox cmbTipoAccionAlcoholemia;
        private Label lblMeses;
    }
}