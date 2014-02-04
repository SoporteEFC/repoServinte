namespace Comparendos.servicios.liquidacion
{
    partial class FFormaPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFormaPago));
            this.txtValorRecibo = new System.Windows.Forms.TextBox();
            this.labValorRecibo = new System.Windows.Forms.Label();
            this.txtAcumulado = new System.Windows.Forms.TextBox();
            this.labAcumulado = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.labFormaPago = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.labValor = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tblTipoPago = new System.Windows.Forms.DataGridView();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.labTipoTarjeta = new System.Windows.Forms.Label();
            this.labBanco = new System.Windows.Forms.Label();
            this.cmbBanco = new System.Windows.Forms.ComboBox();
            this.txtNroCheque = new System.Windows.Forms.TextBox();
            this.labNroCheque = new System.Windows.Forms.Label();
            this.cmbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.btnTomarValorFaltante = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoPago)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValorRecibo
            // 
            this.txtValorRecibo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorRecibo.Enabled = false;
            this.txtValorRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtValorRecibo.Location = new System.Drawing.Point(12, 35);
            this.txtValorRecibo.Name = "txtValorRecibo";
            this.txtValorRecibo.ReadOnly = true;
            this.txtValorRecibo.Size = new System.Drawing.Size(134, 21);
            this.txtValorRecibo.TabIndex = 1;
            this.txtValorRecibo.TabStop = false;
            // 
            // labValorRecibo
            // 
            this.labValorRecibo.Location = new System.Drawing.Point(12, 9);
            this.labValorRecibo.Name = "labValorRecibo";
            this.labValorRecibo.Size = new System.Drawing.Size(137, 23);
            this.labValorRecibo.TabIndex = 4;
            this.labValorRecibo.Text = "Valor recibo:";
            this.labValorRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAcumulado
            // 
            this.txtAcumulado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcumulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtAcumulado.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtAcumulado.Location = new System.Drawing.Point(364, 35);
            this.txtAcumulado.Name = "txtAcumulado";
            this.txtAcumulado.ReadOnly = true;
            this.txtAcumulado.Size = new System.Drawing.Size(154, 24);
            this.txtAcumulado.TabIndex = 3;
            this.txtAcumulado.TabStop = false;
            // 
            // labAcumulado
            // 
            this.labAcumulado.Location = new System.Drawing.Point(361, 9);
            this.labAcumulado.Name = "labAcumulado";
            this.labAcumulado.Size = new System.Drawing.Size(157, 23);
            this.labAcumulado.TabIndex = 6;
            this.labAcumulado.Text = "Acumulado:";
            this.labAcumulado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(12, 85);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(134, 21);
            this.cmbFormaPago.TabIndex = 1;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago_SelectedIndexChanged);
            this.cmbFormaPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFormaPago_KeyPress);
            // 
            // labFormaPago
            // 
            this.labFormaPago.Location = new System.Drawing.Point(12, 59);
            this.labFormaPago.Name = "labFormaPago";
            this.labFormaPago.Size = new System.Drawing.Size(137, 23);
            this.labFormaPago.TabIndex = 9;
            this.labFormaPago.Text = "Forma pago:";
            this.labFormaPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtValor.Location = new System.Drawing.Point(152, 84);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(134, 21);
            this.txtValor.TabIndex = 2;
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            this.txtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValor_KeyDown);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            // 
            // labValor
            // 
            this.labValor.Location = new System.Drawing.Point(152, 58);
            this.labValor.Name = "labValor";
            this.labValor.Size = new System.Drawing.Size(137, 23);
            this.labValor.TabIndex = 10;
            this.labValor.Text = "Valor:";
            this.labValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Enabled = false;
            this.btnAceptar.ImageKey = "button_ok16.png";
            this.btnAceptar.ImageList = this.imageList1;
            this.btnAceptar.Location = new System.Drawing.Point(434, 320);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 26);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.TabStop = false;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "button_ok16.png");
            this.imageList1.Images.SetKeyName(1, "edit-redo.png");
            this.imageList1.Images.SetKeyName(2, "emblem-system.png");
            this.imageList1.Images.SetKeyName(3, "go-bottom.png");
            this.imageList1.Images.SetKeyName(4, "go-down.png");
            this.imageList1.Images.SetKeyName(5, "go-first.png");
            this.imageList1.Images.SetKeyName(6, "go-jump.png");
            this.imageList1.Images.SetKeyName(7, "go-last.png");
            this.imageList1.Images.SetKeyName(8, "go-next.png");
            this.imageList1.Images.SetKeyName(9, "go-previous.png");
            this.imageList1.Images.SetKeyName(10, "go-top.png");
            this.imageList1.Images.SetKeyName(11, "go-up.png");
            this.imageList1.Images.SetKeyName(12, "applications-system.png");
            this.imageList1.Images.SetKeyName(13, "list-add.png");
            this.imageList1.Images.SetKeyName(14, "list-remove.png");
            // 
            // tblTipoPago
            // 
            this.tblTipoPago.AllowUserToAddRows = false;
            this.tblTipoPago.AllowUserToDeleteRows = false;
            this.tblTipoPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblTipoPago.Location = new System.Drawing.Point(12, 188);
            this.tblTipoPago.Name = "tblTipoPago";
            this.tblTipoPago.ReadOnly = true;
            this.tblTipoPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tblTipoPago.Size = new System.Drawing.Size(506, 126);
            this.tblTipoPago.TabIndex = 13;
            // 
            // btnMas
            // 
            this.btnMas.ImageKey = "list-add.png";
            this.btnMas.ImageList = this.imageList1;
            this.btnMas.Location = new System.Drawing.Point(432, 128);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(41, 33);
            this.btnMas.TabIndex = 10;
            this.btnMas.TabStop = false;
            this.btnMas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMas.UseVisualStyleBackColor = true;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.ImageKey = "list-remove.png";
            this.btnMenos.ImageList = this.imageList1;
            this.btnMenos.Location = new System.Drawing.Point(479, 128);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(39, 33);
            this.btnMenos.TabIndex = 11;
            this.btnMenos.TabStop = false;
            this.btnMenos.UseVisualStyleBackColor = true;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // labTipoTarjeta
            // 
            this.labTipoTarjeta.Location = new System.Drawing.Point(12, 109);
            this.labTipoTarjeta.Name = "labTipoTarjeta";
            this.labTipoTarjeta.Size = new System.Drawing.Size(137, 23);
            this.labTipoTarjeta.TabIndex = 18;
            this.labTipoTarjeta.Text = "Tipo tarjeta:";
            this.labTipoTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labBanco
            // 
            this.labBanco.Location = new System.Drawing.Point(155, 108);
            this.labBanco.Name = "labBanco";
            this.labBanco.Size = new System.Drawing.Size(137, 23);
            this.labBanco.TabIndex = 17;
            this.labBanco.Text = "Banco:";
            this.labBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBanco
            // 
            this.cmbBanco.FormattingEnabled = true;
            this.cmbBanco.Location = new System.Drawing.Point(152, 135);
            this.cmbBanco.Name = "cmbBanco";
            this.cmbBanco.Size = new System.Drawing.Size(134, 21);
            this.cmbBanco.TabIndex = 4;
            this.cmbBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBanco_KeyPress);
            // 
            // txtNroCheque
            // 
            this.txtNroCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.txtNroCheque.Location = new System.Drawing.Point(292, 135);
            this.txtNroCheque.Name = "txtNroCheque";
            this.txtNroCheque.Size = new System.Drawing.Size(134, 21);
            this.txtNroCheque.TabIndex = 5;
            this.txtNroCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCheque_KeyPress);
            // 
            // labNroCheque
            // 
            this.labNroCheque.Location = new System.Drawing.Point(292, 107);
            this.labNroCheque.Name = "labNroCheque";
            this.labNroCheque.Size = new System.Drawing.Size(137, 23);
            this.labNroCheque.TabIndex = 20;
            this.labNroCheque.Text = "Nro. cheque:";
            this.labNroCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTipoTarjeta
            // 
            this.cmbTipoTarjeta.FormattingEnabled = true;
            this.cmbTipoTarjeta.Location = new System.Drawing.Point(12, 135);
            this.cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            this.cmbTipoTarjeta.Size = new System.Drawing.Size(134, 21);
            this.cmbTipoTarjeta.TabIndex = 3;
            this.cmbTipoTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoTarjeta_KeyPress);
            // 
            // btnTomarValorFaltante
            // 
            this.btnTomarValorFaltante.ImageKey = "go-previous.png";
            this.btnTomarValorFaltante.ImageList = this.imageList1;
            this.btnTomarValorFaltante.Location = new System.Drawing.Point(292, 83);
            this.btnTomarValorFaltante.Name = "btnTomarValorFaltante";
            this.btnTomarValorFaltante.Size = new System.Drawing.Size(83, 23);
            this.btnTomarValorFaltante.TabIndex = 6;
            this.btnTomarValorFaltante.TabStop = false;
            this.btnTomarValorFaltante.Text = "&Resto";
            this.btnTomarValorFaltante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTomarValorFaltante.UseVisualStyleBackColor = true;
            this.btnTomarValorFaltante.Click += new System.EventHandler(this.btnTomarValorFaltante_Click);
            // 
            // FFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 358);
            this.Controls.Add(this.btnTomarValorFaltante);
            this.Controls.Add(this.cmbTipoTarjeta);
            this.Controls.Add(this.txtNroCheque);
            this.Controls.Add(this.labNroCheque);
            this.Controls.Add(this.labTipoTarjeta);
            this.Controls.Add(this.labBanco);
            this.Controls.Add(this.cmbBanco);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.tblTipoPago);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.labValor);
            this.Controls.Add(this.labFormaPago);
            this.Controls.Add(this.cmbFormaPago);
            this.Controls.Add(this.txtAcumulado);
            this.Controls.Add(this.labAcumulado);
            this.Controls.Add(this.txtValorRecibo);
            this.Controls.Add(this.labValorRecibo);
            this.Name = "FFormaPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forma de pago";
            ((System.ComponentModel.ISupportInitialize)(this.tblTipoPago)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorRecibo;
        private System.Windows.Forms.Label labValorRecibo;
        private System.Windows.Forms.TextBox txtAcumulado;
        private System.Windows.Forms.Label labAcumulado;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label labFormaPago;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label labValor;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView tblTipoPago;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Label labTipoTarjeta;
        private System.Windows.Forms.Label labBanco;
        private System.Windows.Forms.ComboBox cmbBanco;
        private System.Windows.Forms.TextBox txtNroCheque;
        private System.Windows.Forms.Label labNroCheque;
        private System.Windows.Forms.ComboBox cmbTipoTarjeta;
        private System.Windows.Forms.Button btnTomarValorFaltante;
        private System.Windows.Forms.ImageList imageList1;

    }
}