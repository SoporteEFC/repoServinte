namespace TransportePublico.servicios.reportes.vidaUtilVehiculo
{
    partial class VerReporteVidaUtil
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
            this.viewerReporteVidaUtil = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewerReporteVidaUtil
            // 
            this.viewerReporteVidaUtil.ActiveViewIndex = -1;
            this.viewerReporteVidaUtil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewerReporteVidaUtil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerReporteVidaUtil.Location = new System.Drawing.Point(0, 0);
            this.viewerReporteVidaUtil.Name = "viewerReporteVidaUtil";
            this.viewerReporteVidaUtil.SelectionFormula = "";
            this.viewerReporteVidaUtil.Size = new System.Drawing.Size(1008, 498);
            this.viewerReporteVidaUtil.TabIndex = 0;
            this.viewerReporteVidaUtil.ViewTimeSelectionFormula = "";
            // 
            // VerReporteVidaUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 498);
            this.Controls.Add(this.viewerReporteVidaUtil);
            this.Name = "VerReporteVidaUtil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Reporte Vida Util Vehículo]";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewerReporteVidaUtil;
    }
}