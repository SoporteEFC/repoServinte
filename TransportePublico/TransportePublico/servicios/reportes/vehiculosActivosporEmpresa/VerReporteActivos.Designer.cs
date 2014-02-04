namespace TransportePublico.servicios.reportes.vehiculosActivosporEmpresa
{
    partial class VerReporteActivos
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
            this.viewerActivosporEmpresa = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewerActivosporEmpresa
            // 
            this.viewerActivosporEmpresa.ActiveViewIndex = -1;
            this.viewerActivosporEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewerActivosporEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerActivosporEmpresa.Location = new System.Drawing.Point(0, 0);
            this.viewerActivosporEmpresa.Name = "viewerActivosporEmpresa";
            this.viewerActivosporEmpresa.SelectionFormula = "";
            this.viewerActivosporEmpresa.Size = new System.Drawing.Size(1008, 498);
            this.viewerActivosporEmpresa.TabIndex = 0;
            this.viewerActivosporEmpresa.ViewTimeSelectionFormula = "";
            // 
            // VerReporteActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 498);
            this.Controls.Add(this.viewerActivosporEmpresa);
            this.Name = "VerReporteActivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Reporte Vehículos Activos por Empresa]";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewerActivosporEmpresa;
    }
}