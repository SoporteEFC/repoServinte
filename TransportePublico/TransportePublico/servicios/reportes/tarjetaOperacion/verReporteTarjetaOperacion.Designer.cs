namespace TransportePublico
{
    partial class visor
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
            this.viewercrystalReportTarjetaO = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewercrystalReportTarjetaO
            // 
            this.viewercrystalReportTarjetaO.ActiveViewIndex = -1;
            this.viewercrystalReportTarjetaO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewercrystalReportTarjetaO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewercrystalReportTarjetaO.Location = new System.Drawing.Point(0, 0);
            this.viewercrystalReportTarjetaO.Name = "viewercrystalReportTarjetaO";
            this.viewercrystalReportTarjetaO.SelectionFormula = "";
            this.viewercrystalReportTarjetaO.Size = new System.Drawing.Size(973, 525);
            this.viewercrystalReportTarjetaO.TabIndex = 0;
            this.viewercrystalReportTarjetaO.ViewTimeSelectionFormula = "";
            // 
            // visor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 525);
            this.Controls.Add(this.viewercrystalReportTarjetaO);
            this.Name = "visor";
            this.Text = "[Visor Tarjeta Operación]";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewercrystalReportTarjetaO;
    }
}