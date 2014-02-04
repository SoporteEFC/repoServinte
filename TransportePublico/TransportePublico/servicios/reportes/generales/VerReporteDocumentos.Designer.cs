namespace TransportePublico.servicios.reportes.generales
{
    partial class VerReporteDocumentos
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
            this.viewerDocumentos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewerDocumentos
            // 
            this.viewerDocumentos.ActiveViewIndex = -1;
            this.viewerDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewerDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerDocumentos.Location = new System.Drawing.Point(0, 0);
            this.viewerDocumentos.Name = "viewerDocumentos";
            this.viewerDocumentos.SelectionFormula = "";
            this.viewerDocumentos.Size = new System.Drawing.Size(1008, 498);
            this.viewerDocumentos.TabIndex = 0;
            this.viewerDocumentos.ViewTimeSelectionFormula = "";
            // 
            // VerReporteDocumentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 498);
            this.Controls.Add(this.viewerDocumentos);
            this.Name = "VerReporteDocumentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Reporte Documentos por Cupo]";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewerDocumentos;
    }
}