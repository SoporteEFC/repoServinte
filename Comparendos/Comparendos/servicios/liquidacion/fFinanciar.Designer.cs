namespace Comparendos.servicios.liquidacion
{
    partial class fFinanciar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFinanciar));
            this.lblDeuda = new System.Windows.Forms.Label();
            this.txtDeuda = new System.Windows.Forms.TextBox();
            this.lblCuotas = new System.Windows.Forms.Label();
            this.txtCuotas = new System.Windows.Forms.TextBox();
            this.lblPorcPriCuota = new System.Windows.Forms.Label();
            this.lblIntFinan = new System.Windows.Forms.Label();
            this.txtIntFinan = new System.Windows.Forms.TextBox();
            this.lblporc = new System.Windows.Forms.Label();
            this.lblDeudaTotal = new System.Windows.Forms.Label();
            this.txtPorc1a = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtGrdDetalle = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTotalRedondeado = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeuda
            // 
            this.lblDeuda.AutoSize = true;
            this.lblDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeuda.Location = new System.Drawing.Point(27, 28);
            this.lblDeuda.Name = "lblDeuda";
            this.lblDeuda.Size = new System.Drawing.Size(48, 13);
            this.lblDeuda.TabIndex = 0;
            this.lblDeuda.Text = "Deuda:";
            // 
            // txtDeuda
            // 
            this.txtDeuda.Location = new System.Drawing.Point(81, 25);
            this.txtDeuda.Name = "txtDeuda";
            this.txtDeuda.Size = new System.Drawing.Size(100, 20);
            this.txtDeuda.TabIndex = 1;
            this.txtDeuda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDeuda_KeyPress);
            // 
            // lblCuotas
            // 
            this.lblCuotas.AutoSize = true;
            this.lblCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuotas.Location = new System.Drawing.Point(262, 69);
            this.lblCuotas.Name = "lblCuotas";
            this.lblCuotas.Size = new System.Drawing.Size(78, 13);
            this.lblCuotas.TabIndex = 2;
            this.lblCuotas.Text = "Nro. Cuotas:";
            // 
            // txtCuotas
            // 
            this.txtCuotas.Location = new System.Drawing.Point(346, 66);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(35, 20);
            this.txtCuotas.TabIndex = 3;
            this.txtCuotas.Text = "2";
            this.txtCuotas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCuotas_KeyDown);
            this.txtCuotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuotas_KeyPress);
            // 
            // lblPorcPriCuota
            // 
            this.lblPorcPriCuota.AutoSize = true;
            this.lblPorcPriCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcPriCuota.Location = new System.Drawing.Point(27, 106);
            this.lblPorcPriCuota.Name = "lblPorcPriCuota";
            this.lblPorcPriCuota.Size = new System.Drawing.Size(127, 13);
            this.lblPorcPriCuota.TabIndex = 4;
            this.lblPorcPriCuota.Text = "Porcentaje 1a Cuota:";
            // 
            // lblIntFinan
            // 
            this.lblIntFinan.AutoSize = true;
            this.lblIntFinan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntFinan.Location = new System.Drawing.Point(27, 69);
            this.lblIntFinan.Name = "lblIntFinan";
            this.lblIntFinan.Size = new System.Drawing.Size(126, 13);
            this.lblIntFinan.TabIndex = 5;
            this.lblIntFinan.Text = "Interes Financiacion:";
            // 
            // txtIntFinan
            // 
            this.txtIntFinan.Location = new System.Drawing.Point(159, 66);
            this.txtIntFinan.MaxLength = 3;
            this.txtIntFinan.Name = "txtIntFinan";
            this.txtIntFinan.Size = new System.Drawing.Size(34, 20);
            this.txtIntFinan.TabIndex = 2;
            this.txtIntFinan.Text = "0";
            this.txtIntFinan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIntFinan_KeyDown);
            this.txtIntFinan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntFinan_KeyPress);
            // 
            // lblporc
            // 
            this.lblporc.AutoSize = true;
            this.lblporc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblporc.Location = new System.Drawing.Point(198, 69);
            this.lblporc.Name = "lblporc";
            this.lblporc.Size = new System.Drawing.Size(16, 13);
            this.lblporc.TabIndex = 7;
            this.lblporc.Text = "%";
            // 
            // lblDeudaTotal
            // 
            this.lblDeudaTotal.AutoSize = true;
            this.lblDeudaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeudaTotal.Location = new System.Drawing.Point(267, 9);
            this.lblDeudaTotal.Name = "lblDeudaTotal";
            this.lblDeudaTotal.Size = new System.Drawing.Size(81, 13);
            this.lblDeudaTotal.TabIndex = 8;
            this.lblDeudaTotal.Text = "Deuda Total:";
            this.lblDeudaTotal.Visible = false;
            // 
            // txtPorc1a
            // 
            this.txtPorc1a.Location = new System.Drawing.Point(159, 103);
            this.txtPorc1a.MaxLength = 3;
            this.txtPorc1a.Name = "txtPorc1a";
            this.txtPorc1a.Size = new System.Drawing.Size(34, 20);
            this.txtPorc1a.TabIndex = 4;
            this.txtPorc1a.Text = "30";
            this.txtPorc1a.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPorc1a_KeyDown);
            this.txtPorc1a.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorc1a_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(198, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "%";
            // 
            // dtGrdDetalle
            // 
            this.dtGrdDetalle.AllowUserToAddRows = false;
            this.dtGrdDetalle.AllowUserToDeleteRows = false;
            this.dtGrdDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtGrdDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdDetalle.Location = new System.Drawing.Point(30, 154);
            this.dtGrdDetalle.Name = "dtGrdDetalle";
            this.dtGrdDetalle.Size = new System.Drawing.Size(398, 215);
            this.dtGrdDetalle.TabIndex = 11;
            this.dtGrdDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdDetalle_CellEndEdit);
            // 
            // btnGuardar
            // 
            this.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGuardar.ImageIndex = 16;
            this.btnGuardar.ImageList = this.imageList1;
            this.btnGuardar.Location = new System.Drawing.Point(265, 407);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 26);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageIndex = 14;
            this.btnCancelar.ImageList = this.imageList1;
            this.btnCancelar.Location = new System.Drawing.Point(366, 407);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 26);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTotalRedondeado
            // 
            this.lblTotalRedondeado.AutoSize = true;
            this.lblTotalRedondeado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRedondeado.Location = new System.Drawing.Point(237, 32);
            this.lblTotalRedondeado.Name = "lblTotalRedondeado";
            this.lblTotalRedondeado.Size = new System.Drawing.Size(111, 13);
            this.lblTotalRedondeado.TabIndex = 12;
            this.lblTotalRedondeado.Text = "Deuda Total Real:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.ImageKey = "view-refresh.png";
            this.btnActualizar.ImageList = this.imageList1;
            this.btnActualizar.Location = new System.Drawing.Point(327, 122);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(101, 26);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.TabStop = false;
            this.btnActualizar.Text = "&Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // fFinanciar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 445);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblTotalRedondeado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtGrdDetalle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPorc1a);
            this.Controls.Add(this.lblDeudaTotal);
            this.Controls.Add(this.lblporc);
            this.Controls.Add(this.txtIntFinan);
            this.Controls.Add(this.lblIntFinan);
            this.Controls.Add(this.lblPorcPriCuota);
            this.Controls.Add(this.txtCuotas);
            this.Controls.Add(this.lblCuotas);
            this.Controls.Add(this.txtDeuda);
            this.Controls.Add(this.lblDeuda);
            this.Name = "fFinanciar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financiación";
            this.Load += new System.EventHandler(this.fFinanciar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeuda;
        private System.Windows.Forms.TextBox txtDeuda;
        private System.Windows.Forms.Label lblCuotas;
        private System.Windows.Forms.TextBox txtCuotas;
        private System.Windows.Forms.Label lblPorcPriCuota;
        private System.Windows.Forms.Label lblIntFinan;
        private System.Windows.Forms.TextBox txtIntFinan;
        private System.Windows.Forms.Label lblporc;
        private System.Windows.Forms.Label lblDeudaTotal;
        private System.Windows.Forms.TextBox txtPorc1a;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtGrdDetalle;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTotalRedondeado;
        private System.Windows.Forms.Button btnActualizar;
    }
}