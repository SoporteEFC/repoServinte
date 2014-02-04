using Comparendos.Properties;
namespace Comparendos.servicios.liquidacion
{
    partial class PagarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagarFactura));
            this.labNumeroRecibo = new System.Windows.Forms.Label();
            this.txtNumeroRecibo = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labNombre = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.labIdenfificacion = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.labApellido = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.labDireccion = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.labTelefono = new System.Windows.Forms.Label();
            this.txtTotalDeuda = new System.Windows.Forms.TextBox();
            this.labTotalDeuda = new System.Windows.Forms.Label();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.labSaldo = new System.Windows.Forms.Label();
            this.txtRecibido = new System.Windows.Forms.TextBox();
            this.labRecibido = new System.Windows.Forms.Label();
            this.tblComparendos = new System.Windows.Forms.DataGridView();
            this.labComparendos = new System.Windows.Forms.Label();
            this.labOrigenPago = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calFechaPago = new System.Windows.Forms.DateTimePicker();
            this.labFechaPago = new System.Windows.Forms.Label();
            this.txtFormaPago = new System.Windows.Forms.TextBox();
            this.labFormaPago = new System.Windows.Forms.Label();
            this.txtNroReciboEntBancaria = new System.Windows.Forms.TextBox();
            this.labNroReciboEntBancaria = new System.Windows.Forms.Label();
            this.btnFormaPago = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.calFechaOrigen = new System.Windows.Forms.DateTimePicker();
            this.labFechaOrigen = new System.Windows.Forms.Label();
            this.txtNumeroOrigen = new System.Windows.Forms.TextBox();
            this.labNumeroOrigen = new System.Windows.Forms.Label();
            this.cmbOrigenPago = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.Label();
            this.labValor = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnAnularPago = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtValorFactura = new System.Windows.Forms.TextBox();
            this.labValorFactura = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labNumeroRecibo
            // 
            this.labNumeroRecibo.Location = new System.Drawing.Point(21, 18);
            this.labNumeroRecibo.Name = "labNumeroRecibo";
            this.labNumeroRecibo.Size = new System.Drawing.Size(137, 23);
            this.labNumeroRecibo.TabIndex = 0;
            this.labNumeroRecibo.Text = "Número recibo:";
            this.labNumeroRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumeroRecibo
            // 
            this.txtNumeroRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNumeroRecibo.Location = new System.Drawing.Point(24, 44);
            this.txtNumeroRecibo.Name = "txtNumeroRecibo";
            this.txtNumeroRecibo.Size = new System.Drawing.Size(134, 21);
            this.txtNumeroRecibo.TabIndex = 1;
            this.txtNumeroRecibo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroRecibo_KeyDown);
            this.txtNumeroRecibo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroRecibo_KeyPress);
            this.txtNumeroRecibo.Leave += new System.EventHandler(this.txtNumeroRecibo_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNombre.Location = new System.Drawing.Point(247, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(134, 21);
            this.txtNombre.TabIndex = 3;
            this.txtNombre.TabStop = false;
            // 
            // labNombre
            // 
            this.labNombre.Location = new System.Drawing.Point(247, 18);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(137, 23);
            this.labNombre.TabIndex = 2;
            this.labNombre.Text = "Nombre:";
            this.labNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtIdentificacion.Location = new System.Drawing.Point(527, 44);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.ReadOnly = true;
            this.txtIdentificacion.Size = new System.Drawing.Size(134, 21);
            this.txtIdentificacion.TabIndex = 5;
            this.txtIdentificacion.TabStop = false;
            // 
            // labIdenfificacion
            // 
            this.labIdenfificacion.Location = new System.Drawing.Point(530, 18);
            this.labIdenfificacion.Name = "labIdenfificacion";
            this.labIdenfificacion.Size = new System.Drawing.Size(123, 23);
            this.labIdenfificacion.TabIndex = 4;
            this.labIdenfificacion.Text = "Identificación:";
            this.labIdenfificacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtApellido.Location = new System.Drawing.Point(387, 44);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(134, 21);
            this.txtApellido.TabIndex = 4;
            this.txtApellido.TabStop = false;
            // 
            // labApellido
            // 
            this.labApellido.Location = new System.Drawing.Point(390, 18);
            this.labApellido.Name = "labApellido";
            this.labApellido.Size = new System.Drawing.Size(123, 23);
            this.labApellido.TabIndex = 6;
            this.labApellido.Text = "Apellido:";
            this.labApellido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtDireccion.Location = new System.Drawing.Point(24, 94);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(134, 21);
            this.txtDireccion.TabIndex = 6;
            this.txtDireccion.TabStop = false;
            // 
            // labDireccion
            // 
            this.labDireccion.Location = new System.Drawing.Point(21, 68);
            this.labDireccion.Name = "labDireccion";
            this.labDireccion.Size = new System.Drawing.Size(137, 23);
            this.labDireccion.TabIndex = 8;
            this.labDireccion.Text = "Dirección:";
            this.labDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtTelefono.Location = new System.Drawing.Point(164, 94);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(134, 21);
            this.txtTelefono.TabIndex = 7;
            this.txtTelefono.TabStop = false;
            // 
            // labTelefono
            // 
            this.labTelefono.Location = new System.Drawing.Point(164, 68);
            this.labTelefono.Name = "labTelefono";
            this.labTelefono.Size = new System.Drawing.Size(134, 23);
            this.labTelefono.TabIndex = 10;
            this.labTelefono.Text = "Teléfono:";
            this.labTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalDeuda
            // 
            this.txtTotalDeuda.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtTotalDeuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtTotalDeuda.Location = new System.Drawing.Point(24, 144);
            this.txtTotalDeuda.Name = "txtTotalDeuda";
            this.txtTotalDeuda.ReadOnly = true;
            this.txtTotalDeuda.Size = new System.Drawing.Size(134, 21);
            this.txtTotalDeuda.TabIndex = 8;
            this.txtTotalDeuda.TabStop = false;
            // 
            // labTotalDeuda
            // 
            this.labTotalDeuda.Location = new System.Drawing.Point(21, 118);
            this.labTotalDeuda.Name = "labTotalDeuda";
            this.labTotalDeuda.Size = new System.Drawing.Size(137, 23);
            this.labTotalDeuda.TabIndex = 12;
            this.labTotalDeuda.Text = "Total deuda ($):";
            this.labTotalDeuda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSaldo
            // 
            this.txtSaldo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtSaldo.Location = new System.Drawing.Point(164, 144);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(134, 21);
            this.txtSaldo.TabIndex = 9;
            this.txtSaldo.TabStop = false;
            // 
            // labSaldo
            // 
            this.labSaldo.Location = new System.Drawing.Point(164, 118);
            this.labSaldo.Name = "labSaldo";
            this.labSaldo.Size = new System.Drawing.Size(134, 23);
            this.labSaldo.TabIndex = 14;
            this.labSaldo.Text = "Saldo ($):";
            this.labSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRecibido
            // 
            this.txtRecibido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtRecibido.Location = new System.Drawing.Point(304, 144);
            this.txtRecibido.Name = "txtRecibido";
            this.txtRecibido.ReadOnly = true;
            this.txtRecibido.Size = new System.Drawing.Size(134, 21);
            this.txtRecibido.TabIndex = 10;
            this.txtRecibido.TabStop = false;
            // 
            // labRecibido
            // 
            this.labRecibido.Location = new System.Drawing.Point(304, 118);
            this.labRecibido.Name = "labRecibido";
            this.labRecibido.Size = new System.Drawing.Size(134, 23);
            this.labRecibido.TabIndex = 16;
            this.labRecibido.Text = "Recibido ($):";
            this.labRecibido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblComparendos
            // 
            this.tblComparendos.AllowUserToAddRows = false;
            this.tblComparendos.AllowUserToDeleteRows = false;
            this.tblComparendos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblComparendos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblComparendos.Location = new System.Drawing.Point(12, 194);
            this.tblComparendos.Name = "tblComparendos";
            this.tblComparendos.ReadOnly = true;
            this.tblComparendos.Size = new System.Drawing.Size(649, 121);
            this.tblComparendos.TabIndex = 18;
            // 
            // labComparendos
            // 
            this.labComparendos.Location = new System.Drawing.Point(21, 168);
            this.labComparendos.Name = "labComparendos";
            this.labComparendos.Size = new System.Drawing.Size(137, 23);
            this.labComparendos.TabIndex = 19;
            this.labComparendos.Text = "Comparendos:";
            this.labComparendos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labOrigenPago
            // 
            this.labOrigenPago.Location = new System.Drawing.Point(12, 16);
            this.labOrigenPago.Name = "labOrigenPago";
            this.labOrigenPago.Size = new System.Drawing.Size(274, 23);
            this.labOrigenPago.TabIndex = 21;
            this.labOrigenPago.Text = "Origen de pago:";
            this.labOrigenPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calFechaPago);
            this.groupBox1.Controls.Add(this.labFechaPago);
            this.groupBox1.Controls.Add(this.txtFormaPago);
            this.groupBox1.Controls.Add(this.labFormaPago);
            this.groupBox1.Controls.Add(this.txtNroReciboEntBancaria);
            this.groupBox1.Controls.Add(this.labNroReciboEntBancaria);
            this.groupBox1.Controls.Add(this.btnFormaPago);
            this.groupBox1.Controls.Add(this.calFechaOrigen);
            this.groupBox1.Controls.Add(this.labFechaOrigen);
            this.groupBox1.Controls.Add(this.txtNumeroOrigen);
            this.groupBox1.Controls.Add(this.labNumeroOrigen);
            this.groupBox1.Controls.Add(this.cmbOrigenPago);
            this.groupBox1.Controls.Add(this.labOrigenPago);
            this.groupBox1.Location = new System.Drawing.Point(12, 321);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 138);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pago";
            // 
            // calFechaPago
            // 
            this.calFechaPago.CustomFormat = "dd/MM/yyyy";
            this.calFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.calFechaPago.Location = new System.Drawing.Point(509, 90);
            this.calFechaPago.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.calFechaPago.Name = "calFechaPago";
            this.calFechaPago.Size = new System.Drawing.Size(134, 20);
            this.calFechaPago.TabIndex = 19;
            // 
            // labFechaPago
            // 
            this.labFechaPago.Location = new System.Drawing.Point(506, 65);
            this.labFechaPago.Name = "labFechaPago";
            this.labFechaPago.Size = new System.Drawing.Size(137, 23);
            this.labFechaPago.TabIndex = 32;
            this.labFechaPago.Text = "Fecha pago (dd/MM/yyyy):";
            this.labFechaPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFormaPago
            // 
            this.txtFormaPago.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFormaPago.Enabled = false;
            this.txtFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtFormaPago.Location = new System.Drawing.Point(455, 41);
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.ReadOnly = true;
            this.txtFormaPago.Size = new System.Drawing.Size(188, 21);
            this.txtFormaPago.TabIndex = 18;
            this.txtFormaPago.TabStop = false;
            // 
            // labFormaPago
            // 
            this.labFormaPago.Location = new System.Drawing.Point(455, 15);
            this.labFormaPago.Name = "labFormaPago";
            this.labFormaPago.Size = new System.Drawing.Size(86, 23);
            this.labFormaPago.TabIndex = 30;
            this.labFormaPago.Text = "Forma de pago:";
            this.labFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNroReciboEntBancaria
            // 
            this.txtNroReciboEntBancaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNroReciboEntBancaria.Location = new System.Drawing.Point(315, 40);
            this.txtNroReciboEntBancaria.Name = "txtNroReciboEntBancaria";
            this.txtNroReciboEntBancaria.Size = new System.Drawing.Size(134, 21);
            this.txtNroReciboEntBancaria.TabIndex = 16;
            // 
            // labNroReciboEntBancaria
            // 
            this.labNroReciboEntBancaria.Location = new System.Drawing.Point(315, 14);
            this.labNroReciboEntBancaria.Name = "labNroReciboEntBancaria";
            this.labNroReciboEntBancaria.Size = new System.Drawing.Size(134, 23);
            this.labNroReciboEntBancaria.TabIndex = 24;
            this.labNroReciboEntBancaria.Text = "Nro. Recibo ent Bancaria:";
            this.labNroReciboEntBancaria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFormaPago
            // 
            this.btnFormaPago.ImageKey = "applications-system.png";
            this.btnFormaPago.ImageList = this.imageList1;
            this.btnFormaPago.Location = new System.Drawing.Point(561, 13);
            this.btnFormaPago.Name = "btnFormaPago";
            this.btnFormaPago.Size = new System.Drawing.Size(82, 26);
            this.btnFormaPago.TabIndex = 17;
            this.btnFormaPago.Text = "&Forma";
            this.btnFormaPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFormaPago.UseVisualStyleBackColor = true;
            this.btnFormaPago.Click += new System.EventHandler(this.btnFormaPago_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "applications-system.png");
            this.imageList1.Images.SetKeyName(1, "audio-volume-high.png");
            this.imageList1.Images.SetKeyName(2, "audio-x-generic.png");
            this.imageList1.Images.SetKeyName(3, "button_ok16.png");
            this.imageList1.Images.SetKeyName(4, "computer.png");
            this.imageList1.Images.SetKeyName(5, "delete16.png");
            this.imageList1.Images.SetKeyName(6, "dialog-error.png");
            this.imageList1.Images.SetKeyName(7, "dialog-information.png");
            this.imageList1.Images.SetKeyName(8, "dialog-warning.png");
            this.imageList1.Images.SetKeyName(9, "dollar.png");
            this.imageList1.Images.SetKeyName(10, "emblem-important.png");
            this.imageList1.Images.SetKeyName(11, "emblem-readonly.png");
            this.imageList1.Images.SetKeyName(12, "emblem-system.png");
            this.imageList1.Images.SetKeyName(13, "emblem-unreadable.png");
            this.imageList1.Images.SetKeyName(14, "folder.png");
            this.imageList1.Images.SetKeyName(15, "font-x-generic.png");
            this.imageList1.Images.SetKeyName(16, "image-x-generic.png");
            this.imageList1.Images.SetKeyName(17, "magnify.png");
            this.imageList1.Images.SetKeyName(18, "mail-attachment.png");
            this.imageList1.Images.SetKeyName(19, "media-floppy.png");
            this.imageList1.Images.SetKeyName(20, "network-idle.png");
            this.imageList1.Images.SetKeyName(21, "package-x-generic.png");
            this.imageList1.Images.SetKeyName(22, "Plus__Orange16.png");
            this.imageList1.Images.SetKeyName(23, "preferences-system.png");
            this.imageList1.Images.SetKeyName(24, "search.png");
            this.imageList1.Images.SetKeyName(25, "software-update-urgent.png");
            this.imageList1.Images.SetKeyName(26, "start-here.png");
            this.imageList1.Images.SetKeyName(27, "text-html.png");
            this.imageList1.Images.SetKeyName(28, "text-x-generic.png");
            this.imageList1.Images.SetKeyName(29, "video-display.png");
            this.imageList1.Images.SetKeyName(30, "x-office-calendar.png");
            this.imageList1.Images.SetKeyName(31, "system-log-out.png");
            // 
            // calFechaOrigen
            // 
            this.calFechaOrigen.CustomFormat = "dd/MM/yyyy";
            this.calFechaOrigen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.calFechaOrigen.Location = new System.Drawing.Point(152, 91);
            this.calFechaOrigen.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.calFechaOrigen.Name = "calFechaOrigen";
            this.calFechaOrigen.Size = new System.Drawing.Size(134, 20);
            this.calFechaOrigen.TabIndex = 15;
            // 
            // labFechaOrigen
            // 
            this.labFechaOrigen.Location = new System.Drawing.Point(149, 66);
            this.labFechaOrigen.Name = "labFechaOrigen";
            this.labFechaOrigen.Size = new System.Drawing.Size(143, 23);
            this.labFechaOrigen.TabIndex = 25;
            this.labFechaOrigen.Text = "Fecha origen (dd/MM/yyyy):";
            this.labFechaOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumeroOrigen
            // 
            this.txtNumeroOrigen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNumeroOrigen.Location = new System.Drawing.Point(12, 92);
            this.txtNumeroOrigen.Name = "txtNumeroOrigen";
            this.txtNumeroOrigen.Size = new System.Drawing.Size(134, 21);
            this.txtNumeroOrigen.TabIndex = 14;
            // 
            // labNumeroOrigen
            // 
            this.labNumeroOrigen.Location = new System.Drawing.Point(9, 66);
            this.labNumeroOrigen.Name = "labNumeroOrigen";
            this.labNumeroOrigen.Size = new System.Drawing.Size(137, 23);
            this.labNumeroOrigen.TabIndex = 23;
            this.labNumeroOrigen.Text = "Número origen:";
            this.labNumeroOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbOrigenPago
            // 
            this.cmbOrigenPago.FormattingEnabled = true;
            this.cmbOrigenPago.Location = new System.Drawing.Point(12, 42);
            this.cmbOrigenPago.Name = "cmbOrigenPago";
            this.cmbOrigenPago.Size = new System.Drawing.Size(274, 21);
            this.cmbOrigenPago.TabIndex = 13;
            this.cmbOrigenPago.SelectedIndexChanged += new System.EventHandler(this.cmbOrigenPago_SelectedIndexChanged);
            // 
            // txtValor
            // 
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtValor.ForeColor = System.Drawing.Color.Brown;
            this.txtValor.Location = new System.Drawing.Point(387, 464);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(167, 35);
            this.txtValor.TabIndex = 20;
            this.txtValor.Text = "500000";
            this.txtValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labValor
            // 
            this.labValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labValor.Location = new System.Drawing.Point(305, 464);
            this.labValor.Name = "labValor";
            this.labValor.Size = new System.Drawing.Size(76, 35);
            this.labValor.TabIndex = 28;
            this.labValor.Text = "Valor:";
            this.labValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageKey = "magnify.png";
            this.btnBuscar.ImageList = this.imageList1;
            this.btnBuscar.Location = new System.Drawing.Point(164, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(77, 23);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnAnularPago
            // 
            this.btnAnularPago.ImageIndex = 15;
            this.btnAnularPago.ImageList = this.imageList3;
            this.btnAnularPago.Location = new System.Drawing.Point(562, 465);
            this.btnAnularPago.Name = "btnAnularPago";
            this.btnAnularPago.Size = new System.Drawing.Size(103, 35);
            this.btnAnularPago.TabIndex = 21;
            this.btnAnularPago.Text = "&Anular Pago";
            this.btnAnularPago.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnularPago.UseVisualStyleBackColor = true;
            this.btnAnularPago.Click += new System.EventHandler(this.btnAnularPago_Click);
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
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.ImageKey = "view-refresh.png";
            this.btnLimpiar.ImageList = this.imageList2;
            this.btnLimpiar.Location = new System.Drawing.Point(462, 141);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(91, 26);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
            // btnPagar
            // 
            this.btnPagar.ImageKey = "button_ok16.png";
            this.btnPagar.ImageList = this.imageList1;
            this.btnPagar.Location = new System.Drawing.Point(562, 464);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(103, 35);
            this.btnPagar.TabIndex = 20;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // txtValorFactura
            // 
            this.txtValorFactura.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtValorFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.txtValorFactura.Location = new System.Drawing.Point(304, 94);
            this.txtValorFactura.Name = "txtValorFactura";
            this.txtValorFactura.ReadOnly = true;
            this.txtValorFactura.Size = new System.Drawing.Size(134, 21);
            this.txtValorFactura.TabIndex = 29;
            this.txtValorFactura.TabStop = false;
            // 
            // labValorFactura
            // 
            this.labValorFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labValorFactura.Location = new System.Drawing.Point(304, 68);
            this.labValorFactura.Name = "labValorFactura";
            this.labValorFactura.Size = new System.Drawing.Size(134, 23);
            this.labValorFactura.TabIndex = 30;
            this.labValorFactura.Text = "Valor factura ($):";
            this.labValorFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCerrar
            // 
            this.btnCerrar.ImageKey = "delete16.png";
            this.btnCerrar.ImageList = this.imageList1;
            this.btnCerrar.Location = new System.Drawing.Point(215, 472);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(83, 26);
            this.btnCerrar.TabIndex = 46;
            this.btnCerrar.Text = "&Salir";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PagarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 512);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtValorFactura);
            this.Controls.Add(this.labValorFactura);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnAnularPago);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labComparendos);
            this.Controls.Add(this.tblComparendos);
            this.Controls.Add(this.txtRecibido);
            this.Controls.Add(this.labRecibido);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.labValor);
            this.Controls.Add(this.labSaldo);
            this.Controls.Add(this.txtTotalDeuda);
            this.Controls.Add(this.labTotalDeuda);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.labTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.labDireccion);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.labApellido);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.labIdenfificacion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labNombre);
            this.Controls.Add(this.txtNumeroRecibo);
            this.Controls.Add(this.labNumeroRecibo);
            this.Name = "PagarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar Factura";
            ((System.ComponentModel.ISupportInitialize)(this.tblComparendos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNumeroRecibo;
        private System.Windows.Forms.TextBox txtNumeroRecibo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label labIdenfificacion;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label labApellido;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label labDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label labTelefono;
        private System.Windows.Forms.TextBox txtTotalDeuda;
        private System.Windows.Forms.Label labTotalDeuda;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label labSaldo;
        private System.Windows.Forms.TextBox txtRecibido;
        private System.Windows.Forms.Label labRecibido;
        private System.Windows.Forms.DataGridView tblComparendos;
        private System.Windows.Forms.Label labComparendos;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label labOrigenPago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbOrigenPago;
        private System.Windows.Forms.Label labNumeroOrigen;
        private System.Windows.Forms.TextBox txtNumeroOrigen;
        private System.Windows.Forms.DateTimePicker calFechaOrigen;
        private System.Windows.Forms.Label labFechaOrigen;
        private System.Windows.Forms.Button btnFormaPago;
        private System.Windows.Forms.Label labValor;
        private System.Windows.Forms.Label txtValor;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtFormaPago;
        private System.Windows.Forms.Label labFormaPago;
        private System.Windows.Forms.TextBox txtNroReciboEntBancaria;
        private System.Windows.Forms.Label labNroReciboEntBancaria;
        private System.Windows.Forms.DateTimePicker calFechaPago;
        private System.Windows.Forms.Label labFechaPago;
        private System.Windows.Forms.Button btnAnularPago;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtValorFactura;
        private System.Windows.Forms.Label labValorFactura;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
    }
}