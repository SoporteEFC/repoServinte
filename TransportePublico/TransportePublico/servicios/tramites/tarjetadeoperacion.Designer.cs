namespace TransportePublico.servicios.tramites
{
    partial class tarjetadeoperacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tarjetadeoperacion));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttons = new System.Windows.Forms.GroupBox();
            this.btnimprimir = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.txtplacaunica = new System.Windows.Forms.TextBox();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblplacaunica = new System.Windows.Forms.Label();
            this.lblclasevehiculo = new System.Windows.Forms.Label();
            this.txtclasevehiculo = new System.Windows.Forms.TextBox();
            this.lbltipocarroceria = new System.Windows.Forms.Label();
            this.txttipocarroceria = new System.Windows.Forms.TextBox();
            this.lblmarca = new System.Windows.Forms.Label();
            this.txtmarca = new System.Windows.Forms.TextBox();
            this.lblmodelo = new System.Windows.Forms.Label();
            this.txtmodelo = new System.Windows.Forms.TextBox();
            this.lblclasecombustible = new System.Windows.Forms.Label();
            this.txtclasecombustible = new System.Windows.Forms.TextBox();
            this.lblnromotor = new System.Windows.Forms.Label();
            this.txtnumeromotor = new System.Windows.Forms.TextBox();
            this.lblnivelservicio = new System.Windows.Forms.Label();
            this.txtnivelservicio = new System.Windows.Forms.TextBox();
            this.lblcapacidad = new System.Windows.Forms.Label();
            this.lblpasajeros = new System.Windows.Forms.Label();
            this.txtpasajeros = new System.Windows.Forms.TextBox();
            this.lbltoneladas = new System.Windows.Forms.Label();
            this.txttoneladas = new System.Windows.Forms.TextBox();
            this.lblrazonsocial = new System.Windows.Forms.Label();
            this.txtrazonsocial = new System.Windows.Forms.TextBox();
            this.lblnrocupo = new System.Windows.Forms.Label();
            this.txtnrocupo = new System.Windows.Forms.TextBox();
            this.lblradioaccion = new System.Windows.Forms.Label();
            this.lblzonaoperacion = new System.Windows.Forms.Label();
            this.txtzonaoperacion = new System.Windows.Forms.TextBox();
            this.lblnrotarjeta = new System.Windows.Forms.Label();
            this.txtnrotarjeta = new System.Windows.Forms.TextBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.cmbRadioAccion = new System.Windows.Forms.ComboBox();
            this.buttons.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(13, "96.ico");
            // 
            // buttons
            // 
            this.buttons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons.Controls.Add(this.btnimprimir);
            this.buttons.Controls.Add(this.btnExit);
            this.buttons.Controls.Add(this.btnSave);
            this.buttons.Location = new System.Drawing.Point(265, 363);
            this.buttons.Name = "buttons";
            this.buttons.Size = new System.Drawing.Size(195, 43);
            this.buttons.TabIndex = 6;
            this.buttons.TabStop = false;
            // 
            // btnimprimir
            // 
            this.btnimprimir.ImageKey = "96.ico";
            this.btnimprimir.ImageList = this.imageList1;
            this.btnimprimir.Location = new System.Drawing.Point(10, 11);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(30, 29);
            this.btnimprimir.TabIndex = 74;
            this.btnimprimir.TabStop = false;
            this.btnimprimir.UseVisualStyleBackColor = true;
            this.btnimprimir.Visible = false;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 0;
            this.btnExit.ImageList = this.imageList1;
            this.btnExit.Location = new System.Drawing.Point(130, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(56, 28);
            this.btnExit.TabIndex = 29;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "&Salir";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(50, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 28);
            this.btnSave.TabIndex = 73;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "&Guardar";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(31, 47);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaVencimiento.TabIndex = 1;
            this.dtpFechaVencimiento.Visible = false;
            this.dtpFechaVencimiento.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            this.dtpFechaVencimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // txtplacaunica
            // 
            this.txtplacaunica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtplacaunica.Location = new System.Drawing.Point(252, 45);
            this.txtplacaunica.Name = "txtplacaunica";
            this.txtplacaunica.Size = new System.Drawing.Size(100, 20);
            this.txtplacaunica.TabIndex = 2;
            this.txtplacaunica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtplacaunica_KeyPress);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(28, 31);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(116, 13);
            this.lblfecha.TabIndex = 42;
            this.lblfecha.Text = "Fecha de Vencimiento:";
            this.lblfecha.Visible = false;
            // 
            // lblplacaunica
            // 
            this.lblplacaunica.AutoSize = true;
            this.lblplacaunica.Location = new System.Drawing.Point(251, 31);
            this.lblplacaunica.Name = "lblplacaunica";
            this.lblplacaunica.Size = new System.Drawing.Size(68, 13);
            this.lblplacaunica.TabIndex = 43;
            this.lblplacaunica.Text = "Placa Unica:";
            // 
            // lblclasevehiculo
            // 
            this.lblclasevehiculo.AutoSize = true;
            this.lblclasevehiculo.Location = new System.Drawing.Point(28, 94);
            this.lblclasevehiculo.Name = "lblclasevehiculo";
            this.lblclasevehiculo.Size = new System.Drawing.Size(97, 13);
            this.lblclasevehiculo.TabIndex = 44;
            this.lblclasevehiculo.Text = "Clase de Vehículo:";
            // 
            // txtclasevehiculo
            // 
            this.txtclasevehiculo.Enabled = false;
            this.txtclasevehiculo.Location = new System.Drawing.Point(31, 111);
            this.txtclasevehiculo.Name = "txtclasevehiculo";
            this.txtclasevehiculo.Size = new System.Drawing.Size(100, 20);
            this.txtclasevehiculo.TabIndex = 45;
            this.txtclasevehiculo.TabStop = false;
            // 
            // lbltipocarroceria
            // 
            this.lbltipocarroceria.AutoSize = true;
            this.lbltipocarroceria.Location = new System.Drawing.Point(139, 94);
            this.lbltipocarroceria.Name = "lbltipocarroceria";
            this.lbltipocarroceria.Size = new System.Drawing.Size(97, 13);
            this.lbltipocarroceria.TabIndex = 46;
            this.lbltipocarroceria.Text = "Tipo de Carroceria:";
            // 
            // txttipocarroceria
            // 
            this.txttipocarroceria.Enabled = false;
            this.txttipocarroceria.Location = new System.Drawing.Point(142, 110);
            this.txttipocarroceria.Name = "txttipocarroceria";
            this.txttipocarroceria.Size = new System.Drawing.Size(100, 20);
            this.txttipocarroceria.TabIndex = 47;
            this.txttipocarroceria.TabStop = false;
            // 
            // lblmarca
            // 
            this.lblmarca.AutoSize = true;
            this.lblmarca.Location = new System.Drawing.Point(248, 94);
            this.lblmarca.Name = "lblmarca";
            this.lblmarca.Size = new System.Drawing.Size(40, 13);
            this.lblmarca.TabIndex = 48;
            this.lblmarca.Text = "Marca:";
            // 
            // txtmarca
            // 
            this.txtmarca.Enabled = false;
            this.txtmarca.Location = new System.Drawing.Point(251, 110);
            this.txtmarca.Name = "txtmarca";
            this.txtmarca.Size = new System.Drawing.Size(100, 20);
            this.txtmarca.TabIndex = 49;
            this.txtmarca.TabStop = false;
            // 
            // lblmodelo
            // 
            this.lblmodelo.AutoSize = true;
            this.lblmodelo.Location = new System.Drawing.Point(357, 94);
            this.lblmodelo.Name = "lblmodelo";
            this.lblmodelo.Size = new System.Drawing.Size(45, 13);
            this.lblmodelo.TabIndex = 50;
            this.lblmodelo.Text = "Modelo:";
            // 
            // txtmodelo
            // 
            this.txtmodelo.Enabled = false;
            this.txtmodelo.Location = new System.Drawing.Point(360, 110);
            this.txtmodelo.Name = "txtmodelo";
            this.txtmodelo.Size = new System.Drawing.Size(100, 20);
            this.txtmodelo.TabIndex = 51;
            this.txtmodelo.TabStop = false;
            // 
            // lblclasecombustible
            // 
            this.lblclasecombustible.AutoSize = true;
            this.lblclasecombustible.Location = new System.Drawing.Point(28, 150);
            this.lblclasecombustible.Name = "lblclasecombustible";
            this.lblclasecombustible.Size = new System.Drawing.Size(111, 13);
            this.lblclasecombustible.TabIndex = 52;
            this.lblclasecombustible.Text = "Clase de Combustible:";
            // 
            // txtclasecombustible
            // 
            this.txtclasecombustible.Enabled = false;
            this.txtclasecombustible.Location = new System.Drawing.Point(31, 166);
            this.txtclasecombustible.Name = "txtclasecombustible";
            this.txtclasecombustible.Size = new System.Drawing.Size(100, 20);
            this.txtclasecombustible.TabIndex = 53;
            this.txtclasecombustible.TabStop = false;
            // 
            // lblnromotor
            // 
            this.lblnromotor.AutoSize = true;
            this.lblnromotor.Location = new System.Drawing.Point(150, 150);
            this.lblnromotor.Name = "lblnromotor";
            this.lblnromotor.Size = new System.Drawing.Size(92, 13);
            this.lblnromotor.TabIndex = 54;
            this.lblnromotor.Text = "Número de Motor:";
            // 
            // txtnumeromotor
            // 
            this.txtnumeromotor.Enabled = false;
            this.txtnumeromotor.Location = new System.Drawing.Point(153, 166);
            this.txtnumeromotor.Name = "txtnumeromotor";
            this.txtnumeromotor.Size = new System.Drawing.Size(307, 20);
            this.txtnumeromotor.TabIndex = 55;
            this.txtnumeromotor.TabStop = false;
            // 
            // lblnivelservicio
            // 
            this.lblnivelservicio.AutoSize = true;
            this.lblnivelservicio.Location = new System.Drawing.Point(28, 201);
            this.lblnivelservicio.Name = "lblnivelservicio";
            this.lblnivelservicio.Size = new System.Drawing.Size(90, 13);
            this.lblnivelservicio.TabIndex = 56;
            this.lblnivelservicio.Text = "Nivel de Servicio:";
            // 
            // txtnivelservicio
            // 
            this.txtnivelservicio.Enabled = false;
            this.txtnivelservicio.Location = new System.Drawing.Point(31, 218);
            this.txtnivelservicio.Name = "txtnivelservicio";
            this.txtnivelservicio.Size = new System.Drawing.Size(211, 20);
            this.txtnivelservicio.TabIndex = 57;
            this.txtnivelservicio.TabStop = false;
            // 
            // lblcapacidad
            // 
            this.lblcapacidad.AutoSize = true;
            this.lblcapacidad.Location = new System.Drawing.Point(251, 201);
            this.lblcapacidad.Name = "lblcapacidad";
            this.lblcapacidad.Size = new System.Drawing.Size(61, 13);
            this.lblcapacidad.TabIndex = 58;
            this.lblcapacidad.Text = "Capacidad:";
            // 
            // lblpasajeros
            // 
            this.lblpasajeros.AutoSize = true;
            this.lblpasajeros.Location = new System.Drawing.Point(248, 221);
            this.lblpasajeros.Name = "lblpasajeros";
            this.lblpasajeros.Size = new System.Drawing.Size(56, 13);
            this.lblpasajeros.TabIndex = 59;
            this.lblpasajeros.Text = "Pasajeros:";
            // 
            // txtpasajeros
            // 
            this.txtpasajeros.Enabled = false;
            this.txtpasajeros.Location = new System.Drawing.Point(301, 218);
            this.txtpasajeros.Name = "txtpasajeros";
            this.txtpasajeros.Size = new System.Drawing.Size(38, 20);
            this.txtpasajeros.TabIndex = 60;
            this.txtpasajeros.TabStop = false;
            // 
            // lbltoneladas
            // 
            this.lbltoneladas.AutoSize = true;
            this.lbltoneladas.Location = new System.Drawing.Point(345, 221);
            this.lbltoneladas.Name = "lbltoneladas";
            this.lbltoneladas.Size = new System.Drawing.Size(60, 13);
            this.lbltoneladas.TabIndex = 61;
            this.lbltoneladas.Text = "Toneladas:";
            // 
            // txttoneladas
            // 
            this.txttoneladas.Enabled = false;
            this.txttoneladas.Location = new System.Drawing.Point(411, 218);
            this.txttoneladas.Name = "txttoneladas";
            this.txttoneladas.Size = new System.Drawing.Size(49, 20);
            this.txttoneladas.TabIndex = 62;
            this.txttoneladas.TabStop = false;
            // 
            // lblrazonsocial
            // 
            this.lblrazonsocial.AutoSize = true;
            this.lblrazonsocial.Location = new System.Drawing.Point(28, 258);
            this.lblrazonsocial.Name = "lblrazonsocial";
            this.lblrazonsocial.Size = new System.Drawing.Size(73, 13);
            this.lblrazonsocial.TabIndex = 63;
            this.lblrazonsocial.Text = "Razón Social:";
            // 
            // txtrazonsocial
            // 
            this.txtrazonsocial.Enabled = false;
            this.txtrazonsocial.Location = new System.Drawing.Point(31, 274);
            this.txtrazonsocial.Name = "txtrazonsocial";
            this.txtrazonsocial.Size = new System.Drawing.Size(429, 20);
            this.txtrazonsocial.TabIndex = 64;
            this.txtrazonsocial.TabStop = false;
            // 
            // lblnrocupo
            // 
            this.lblnrocupo.AutoSize = true;
            this.lblnrocupo.Location = new System.Drawing.Point(28, 311);
            this.lblnrocupo.Name = "lblnrocupo";
            this.lblnrocupo.Size = new System.Drawing.Size(58, 13);
            this.lblnrocupo.TabIndex = 65;
            this.lblnrocupo.Text = "Nro. Cupo:";
            // 
            // txtnrocupo
            // 
            this.txtnrocupo.Enabled = false;
            this.txtnrocupo.Location = new System.Drawing.Point(31, 327);
            this.txtnrocupo.Name = "txtnrocupo";
            this.txtnrocupo.Size = new System.Drawing.Size(108, 20);
            this.txtnrocupo.TabIndex = 66;
            this.txtnrocupo.TabStop = false;
            // 
            // lblradioaccion
            // 
            this.lblradioaccion.AutoSize = true;
            this.lblradioaccion.Location = new System.Drawing.Point(153, 311);
            this.lblradioaccion.Name = "lblradioaccion";
            this.lblradioaccion.Size = new System.Drawing.Size(89, 13);
            this.lblradioaccion.TabIndex = 67;
            this.lblradioaccion.Text = "Radio de Acción:";
            this.lblradioaccion.Visible = false;
            // 
            // lblzonaoperacion
            // 
            this.lblzonaoperacion.AutoSize = true;
            this.lblzonaoperacion.Location = new System.Drawing.Point(286, 311);
            this.lblzonaoperacion.Name = "lblzonaoperacion";
            this.lblzonaoperacion.Size = new System.Drawing.Size(102, 13);
            this.lblzonaoperacion.TabIndex = 69;
            this.lblzonaoperacion.Text = "Zona de Operación:";
            this.lblzonaoperacion.Visible = false;
            // 
            // txtzonaoperacion
            // 
            this.txtzonaoperacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtzonaoperacion.Location = new System.Drawing.Point(289, 326);
            this.txtzonaoperacion.Name = "txtzonaoperacion";
            this.txtzonaoperacion.Size = new System.Drawing.Size(171, 20);
            this.txtzonaoperacion.TabIndex = 4;
            this.txtzonaoperacion.Visible = false;
            this.txtzonaoperacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtzonaoperacion_KeyPress);
            // 
            // lblnrotarjeta
            // 
            this.lblnrotarjeta.AutoSize = true;
            this.lblnrotarjeta.Location = new System.Drawing.Point(31, 363);
            this.lblnrotarjeta.Name = "lblnrotarjeta";
            this.lblnrotarjeta.Size = new System.Drawing.Size(66, 13);
            this.lblnrotarjeta.TabIndex = 71;
            this.lblnrotarjeta.Text = "Tarjeta Nro.:";
            this.lblnrotarjeta.Visible = false;
            // 
            // txtnrotarjeta
            // 
            this.txtnrotarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtnrotarjeta.Location = new System.Drawing.Point(31, 379);
            this.txtnrotarjeta.Name = "txtnrotarjeta";
            this.txtnrotarjeta.Size = new System.Drawing.Size(228, 20);
            this.txtnrotarjeta.TabIndex = 5;
            this.txtnrotarjeta.Visible = false;
            this.txtnrotarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnrotarjeta_KeyPress);
            // 
            // btnbuscar
            // 
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscar.ImageKey = "search.ico";
            this.btnbuscar.ImageList = this.imageList1;
            this.btnbuscar.Location = new System.Drawing.Point(374, 42);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(86, 25);
            this.btnbuscar.TabIndex = 80;
            this.btnbuscar.TabStop = false;
            this.btnbuscar.Text = "&Buscar";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // cmbRadioAccion
            // 
            this.cmbRadioAccion.FormattingEnabled = true;
            this.cmbRadioAccion.Location = new System.Drawing.Point(156, 324);
            this.cmbRadioAccion.Name = "cmbRadioAccion";
            this.cmbRadioAccion.Size = new System.Drawing.Size(121, 21);
            this.cmbRadioAccion.TabIndex = 81;
            this.cmbRadioAccion.TextChanged += new System.EventHandler(this.cmbRadioAccion_TextChanged);
            // 
            // tarjetadeoperacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 415);
            this.Controls.Add(this.cmbRadioAccion);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.txtnrotarjeta);
            this.Controls.Add(this.lblnrotarjeta);
            this.Controls.Add(this.txtzonaoperacion);
            this.Controls.Add(this.lblzonaoperacion);
            this.Controls.Add(this.lblradioaccion);
            this.Controls.Add(this.txtnrocupo);
            this.Controls.Add(this.lblnrocupo);
            this.Controls.Add(this.txtrazonsocial);
            this.Controls.Add(this.lblrazonsocial);
            this.Controls.Add(this.txttoneladas);
            this.Controls.Add(this.lbltoneladas);
            this.Controls.Add(this.txtpasajeros);
            this.Controls.Add(this.lblpasajeros);
            this.Controls.Add(this.lblcapacidad);
            this.Controls.Add(this.txtnivelservicio);
            this.Controls.Add(this.lblnivelservicio);
            this.Controls.Add(this.txtnumeromotor);
            this.Controls.Add(this.lblnromotor);
            this.Controls.Add(this.txtclasecombustible);
            this.Controls.Add(this.lblclasecombustible);
            this.Controls.Add(this.txtmodelo);
            this.Controls.Add(this.lblmodelo);
            this.Controls.Add(this.txtmarca);
            this.Controls.Add(this.lblmarca);
            this.Controls.Add(this.txttipocarroceria);
            this.Controls.Add(this.lbltipocarroceria);
            this.Controls.Add(this.txtclasevehiculo);
            this.Controls.Add(this.lblclasevehiculo);
            this.Controls.Add(this.lblplacaunica);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.txtplacaunica);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.buttons);
            this.Name = "tarjetadeoperacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tarjeta de Operación";
            this.Load += new System.EventHandler(this.tarjetadeoperacion_Load);
            this.buttons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox buttons;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.TextBox txtplacaunica;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblplacaunica;
        private System.Windows.Forms.Label lblclasevehiculo;
        private System.Windows.Forms.TextBox txtclasevehiculo;
        private System.Windows.Forms.Label lbltipocarroceria;
        private System.Windows.Forms.TextBox txttipocarroceria;
        private System.Windows.Forms.Label lblmarca;
        private System.Windows.Forms.TextBox txtmarca;
        private System.Windows.Forms.Label lblmodelo;
        private System.Windows.Forms.TextBox txtmodelo;
        private System.Windows.Forms.Label lblclasecombustible;
        private System.Windows.Forms.TextBox txtclasecombustible;
        private System.Windows.Forms.Label lblnromotor;
        private System.Windows.Forms.TextBox txtnumeromotor;
        private System.Windows.Forms.Label lblnivelservicio;
        private System.Windows.Forms.TextBox txtnivelservicio;
        private System.Windows.Forms.Label lblcapacidad;
        private System.Windows.Forms.Label lblpasajeros;
        private System.Windows.Forms.TextBox txtpasajeros;
        private System.Windows.Forms.Label lbltoneladas;
        private System.Windows.Forms.TextBox txttoneladas;
        private System.Windows.Forms.Label lblrazonsocial;
        private System.Windows.Forms.TextBox txtrazonsocial;
        private System.Windows.Forms.Label lblnrocupo;
        private System.Windows.Forms.TextBox txtnrocupo;
        private System.Windows.Forms.Label lblradioaccion;
        private System.Windows.Forms.Label lblzonaoperacion;
        private System.Windows.Forms.TextBox txtzonaoperacion;
        private System.Windows.Forms.Label lblnrotarjeta;
        private System.Windows.Forms.TextBox txtnrotarjeta;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Button btnimprimir;
        private System.Windows.Forms.ComboBox cmbRadioAccion;
    }
}