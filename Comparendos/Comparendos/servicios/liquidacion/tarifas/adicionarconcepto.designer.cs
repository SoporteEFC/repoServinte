namespace Comparendos
{
    partial class adicionarconcepto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adicionarconcepto));
            this.lblItemLiquidacion = new System.Windows.Forms.Label();
            this.cmbItemLiquidacion = new System.Windows.Forms.ComboBox();
            this.chkDescontable = new System.Windows.Forms.CheckBox();
            this.cmbTipoConcepto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.acciones = new System.Windows.Forms.GroupBox();
            this.btndatos = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFactor = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.txtDatoBase = new System.Windows.Forms.TextBox();
            this.datostabla = new System.Windows.Forms.GroupBox();
            this.grdConceptosCobro = new System.Windows.Forms.DataGridView();
            this.btnocultar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.acciones.SuspendLayout();
            this.datostabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptosCobro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItemLiquidacion
            // 
            this.lblItemLiquidacion.AutoSize = true;
            this.lblItemLiquidacion.Location = new System.Drawing.Point(15, 52);
            this.lblItemLiquidacion.Name = "lblItemLiquidacion";
            this.lblItemLiquidacion.Size = new System.Drawing.Size(84, 13);
            this.lblItemLiquidacion.TabIndex = 0;
            this.lblItemLiquidacion.Text = "Item Liquidación";
            // 
            // cmbItemLiquidacion
            // 
            this.cmbItemLiquidacion.DisplayMember = "DESCRIPCION";
            this.cmbItemLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemLiquidacion.FormattingEnabled = true;
            this.cmbItemLiquidacion.Location = new System.Drawing.Point(15, 68);
            this.cmbItemLiquidacion.Name = "cmbItemLiquidacion";
            this.cmbItemLiquidacion.Size = new System.Drawing.Size(305, 21);
            this.cmbItemLiquidacion.TabIndex = 1;
            this.cmbItemLiquidacion.ValueMember = "ID_ITEM";
            this.cmbItemLiquidacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.claseconcepto_KeyPress);
            // 
            // chkDescontable
            // 
            this.chkDescontable.AutoSize = true;
            this.chkDescontable.Location = new System.Drawing.Point(234, 27);
            this.chkDescontable.Name = "chkDescontable";
            this.chkDescontable.Size = new System.Drawing.Size(86, 17);
            this.chkDescontable.TabIndex = 4;
            this.chkDescontable.Text = "Descontable";
            this.chkDescontable.UseVisualStyleBackColor = true;
            this.chkDescontable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descontable_KeyPress);
            // 
            // cmbTipoConcepto
            // 
            this.cmbTipoConcepto.DisplayMember = "NOMBRETIPO";
            this.cmbTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoConcepto.FormattingEnabled = true;
            this.cmbTipoConcepto.Location = new System.Drawing.Point(15, 25);
            this.cmbTipoConcepto.Name = "cmbTipoConcepto";
            this.cmbTipoConcepto.Size = new System.Drawing.Size(213, 21);
            this.cmbTipoConcepto.TabIndex = 3;
            this.cmbTipoConcepto.ValueMember = "LTCC_ID";
            this.cmbTipoConcepto.SelectedIndexChanged += new System.EventHandler(this.tipoconcepto_SelectedIndexChanged);
            this.cmbTipoConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoconcepto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Valor";
            // 
            // txtFormula
            // 
            this.txtFormula.Location = new System.Drawing.Point(15, 192);
            this.txtFormula.Multiline = true;
            this.txtFormula.Name = "txtFormula";
            this.txtFormula.Size = new System.Drawing.Size(305, 101);
            this.txtFormula.TabIndex = 8;
            // 
            // acciones
            // 
            this.acciones.Controls.Add(this.btndatos);
            this.acciones.Controls.Add(this.btnOk);
            this.acciones.Controls.Add(this.btnCancel);
            this.acciones.Location = new System.Drawing.Point(63, 299);
            this.acciones.Name = "acciones";
            this.acciones.Size = new System.Drawing.Size(160, 73);
            this.acciones.TabIndex = 12;
            this.acciones.TabStop = false;
            this.acciones.Text = "Acciones";
            // 
            // btndatos
            // 
            this.btndatos.Image = ((System.Drawing.Image)(resources.GetObject("btndatos.Image")));
            this.btndatos.Location = new System.Drawing.Point(15, 22);
            this.btndatos.Name = "btndatos";
            this.btndatos.Size = new System.Drawing.Size(39, 37);
            this.btndatos.TabIndex = 32;
            this.btndatos.TabStop = false;
            this.btndatos.UseVisualStyleBackColor = true;
            this.btndatos.Click += new System.EventHandler(this.btndatos_Click);
            // 
            // btnOk
            // 
            this.btnOk.ImageIndex = 12;
            this.btnOk.ImageList = this.imageList1;
            this.btnOk.Location = new System.Drawing.Point(60, 22);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(39, 37);
            this.btnOk.TabIndex = 31;
            this.btnOk.TabStop = false;
            this.toolTip1.SetToolTip(this.btnOk, "Guardar");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            // 
            // btnCancel
            // 
            this.btnCancel.ImageIndex = 11;
            this.btnCancel.ImageList = this.imageList1;
            this.btnCancel.Location = new System.Drawing.Point(105, 22);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(39, 37);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.TabStop = false;
            this.toolTip1.SetToolTip(this.btnCancel, "Salir");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fórmula";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Dato base";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Factor";
            // 
            // txtFactor
            // 
            this.txtFactor.Location = new System.Drawing.Point(15, 152);
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Size = new System.Drawing.Size(138, 20);
            this.txtFactor.TabIndex = 7;
            this.txtFactor.TextChanged += new System.EventHandler(this.factor_TextChanged);
            this.txtFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.factor_KeyPress);
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(15, 113);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(138, 20);
            this.txtValor.TabIndex = 5;
            this.txtValor.TextChanged += new System.EventHandler(this.valor_TextChanged);
            this.txtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valor_KeyPress);
            // 
            // txtDatoBase
            // 
            this.txtDatoBase.Location = new System.Drawing.Point(160, 152);
            this.txtDatoBase.Name = "txtDatoBase";
            this.txtDatoBase.Size = new System.Drawing.Size(160, 20);
            this.txtDatoBase.TabIndex = 6;
            this.txtDatoBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.datobase_KeyPress);
            // 
            // datostabla
            // 
            this.datostabla.Controls.Add(this.grdConceptosCobro);
            this.datostabla.Location = new System.Drawing.Point(338, 49);
            this.datostabla.Name = "datostabla";
            this.datostabla.Size = new System.Drawing.Size(656, 284);
            this.datostabla.TabIndex = 19;
            this.datostabla.TabStop = false;
            this.datostabla.Text = "[Conceptos Cobro]";
            // 
            // grdConceptosCobro
            // 
            this.grdConceptosCobro.AllowUserToAddRows = false;
            this.grdConceptosCobro.AllowUserToDeleteRows = false;
            this.grdConceptosCobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConceptosCobro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdConceptosCobro.Location = new System.Drawing.Point(3, 16);
            this.grdConceptosCobro.Name = "grdConceptosCobro";
            this.grdConceptosCobro.ReadOnly = true;
            this.grdConceptosCobro.Size = new System.Drawing.Size(650, 265);
            this.grdConceptosCobro.TabIndex = 20;
            // 
            // btnocultar
            // 
            this.btnocultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnocultar.ImageIndex = 0;
            this.btnocultar.ImageList = this.imageList1;
            this.btnocultar.Location = new System.Drawing.Point(925, 14);
            this.btnocultar.Name = "btnocultar";
            this.btnocultar.Size = new System.Drawing.Size(69, 28);
            this.btnocultar.TabIndex = 31;
            this.btnocultar.TabStop = false;
            this.btnocultar.Text = "&Ocultar";
            this.btnocultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnocultar.UseVisualStyleBackColor = true;
            this.btnocultar.Click += new System.EventHandler(this.btnocultar_Click);
            // 
            // adicionarconcepto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 384);
            this.Controls.Add(this.btnocultar);
            this.Controls.Add(this.datostabla);
            this.Controls.Add(this.txtDatoBase);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtFactor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.acciones);
            this.Controls.Add(this.txtFormula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipoConcepto);
            this.Controls.Add(this.chkDescontable);
            this.Controls.Add(this.cmbItemLiquidacion);
            this.Controls.Add(this.lblItemLiquidacion);
            this.Name = "adicionarconcepto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Adicionar Concepto]";
            this.Load += new System.EventHandler(this.adicionarconcepto_Load);
            this.acciones.ResumeLayout(false);
            this.datostabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptosCobro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblItemLiquidacion;
        private System.Windows.Forms.ComboBox cmbItemLiquidacion;
        private System.Windows.Forms.CheckBox chkDescontable;
        private System.Windows.Forms.ComboBox cmbTipoConcepto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.GroupBox acciones;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.TextBox txtDatoBase;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btndatos;
        private System.Windows.Forms.GroupBox datostabla;
        private System.Windows.Forms.DataGridView grdConceptosCobro;
        private System.Windows.Forms.Button btnocultar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}