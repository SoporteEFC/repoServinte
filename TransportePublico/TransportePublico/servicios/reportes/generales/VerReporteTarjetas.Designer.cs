namespace TransportePublico.servicios.reportes.generales
{
    partial class VerReporteTarjetas
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
            this.viewerTarjetas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewerTarjetas
            // 
            this.viewerTarjetas.ActiveViewIndex = -1;
            this.viewerTarjetas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewerTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerTarjetas.Location = new System.Drawing.Point(0, 0);
            this.viewerTarjetas.Name = "viewerTarjetas";
            this.viewerTarjetas.SelectionFormula = "";
            this.viewerTarjetas.Size = new System.Drawing.Size(1008, 498);
            this.viewerTarjetas.TabIndex = 0;
            this.viewerTarjetas.ViewTimeSelectionFormula = "";
            // 
            // VerReporteTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 498);
            this.Controls.Add(this.viewerTarjetas);
            this.Name = "VerReporteTarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Reporte Tarjetas de Operación por Cupo]";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewerTarjetas;
    }
}