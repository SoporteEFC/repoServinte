namespace TransportePublico.servicios.reportes.generales
{
    partial class VerReportePropietarios
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
            this.viewerReportePropietarios = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewerReportePropietarios
            // 
            this.viewerReportePropietarios.ActiveViewIndex = -1;
            this.viewerReportePropietarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewerReportePropietarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerReportePropietarios.Location = new System.Drawing.Point(0, 0);
            this.viewerReportePropietarios.Name = "viewerReportePropietarios";
            this.viewerReportePropietarios.SelectionFormula = "";
            this.viewerReportePropietarios.Size = new System.Drawing.Size(1008, 498);
            this.viewerReportePropietarios.TabIndex = 0;
            this.viewerReportePropietarios.ViewTimeSelectionFormula = "";
            // 
            // VerReportePropietarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 498);
            this.Controls.Add(this.viewerReportePropietarios);
            this.Name = "VerReportePropietarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Reporte Propietarios Cupo]";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewerReportePropietarios;
    }
}