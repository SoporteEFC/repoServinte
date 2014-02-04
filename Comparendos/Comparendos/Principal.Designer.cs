using Comparendos.servicios.administracion;
namespace Comparendos
{
    partial class FPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confuguracionDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionTransitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparendosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearComparendoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarComparendoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarComparendoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularComparendoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelaranulacionComparendoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.gestionInfractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.plantillasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.imposiciónInfractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioCódigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prescripciónInfractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exoneraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masivasRangoFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revocatoriaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reesolucionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarAgentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearRangoComparendoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarComparenderasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarComparenderasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infraccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarInfraccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivosPlanosSimitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarPlanosSimitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liquidaciónComparendoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acuerdosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acuerdosDePagoPorInfractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAcuerdoDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarFacturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularPagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarPagoSimitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesGeneralesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CoactivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsultarInfractorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imposicionPorFechaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListFinal = new System.Windows.Forms.ImageList(this.components);
            this.cargarPlanosSimitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administracionToolStripMenuItem,
            this.comparendosToolStripMenuItem,
            this.resolucionesToolStripMenuItem,
            this.agentesToolStripMenuItem,
            this.infraccionesToolStripMenuItem,
            this.archivosPlanosSimitToolStripMenuItem,
            this.liquidacionToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.CoactivosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1143, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confuguracionDeUsuariosToolStripMenuItem,
            this.auditoriaToolStripMenuItem,
            this.configuracionTransitoToolStripMenuItem});
            this.administracionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("administracionToolStripMenuItem.Image")));
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.administracionToolStripMenuItem.Text = "Administración";
            // 
            // confuguracionDeUsuariosToolStripMenuItem
            // 
            this.confuguracionDeUsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rolesToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.confuguracionDeUsuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("confuguracionDeUsuariosToolStripMenuItem.Image")));
            this.confuguracionDeUsuariosToolStripMenuItem.Name = "confuguracionDeUsuariosToolStripMenuItem";
            this.confuguracionDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.confuguracionDeUsuariosToolStripMenuItem.Text = "Usuarios y Roles";
            // 
            // rolesToolStripMenuItem
            // 
            this.rolesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rolesToolStripMenuItem.Image")));
            this.rolesToolStripMenuItem.Name = "rolesToolStripMenuItem";
            this.rolesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.rolesToolStripMenuItem.Text = "Roles";
            this.rolesToolStripMenuItem.Click += new System.EventHandler(this.rolesToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuarioToolStripMenuItem.Image")));
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.usuarioToolStripMenuItem.Text = "Mi Cuenta";
            this.usuarioToolStripMenuItem.Click += new System.EventHandler(this.usuarioToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usuariosToolStripMenuItem.Image")));
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.usuariosToolStripMenuItem.Text = "Cuentas de Usuario";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // auditoriaToolStripMenuItem
            // 
            this.auditoriaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("auditoriaToolStripMenuItem.Image")));
            this.auditoriaToolStripMenuItem.Name = "auditoriaToolStripMenuItem";
            this.auditoriaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.auditoriaToolStripMenuItem.Text = "Auditoría";
            this.auditoriaToolStripMenuItem.Click += new System.EventHandler(this.auditoriaToolStripMenuItem_Click);
            // 
            // configuracionTransitoToolStripMenuItem
            // 
            this.configuracionTransitoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configuracionTransitoToolStripMenuItem.Image")));
            this.configuracionTransitoToolStripMenuItem.Name = "configuracionTransitoToolStripMenuItem";
            this.configuracionTransitoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.configuracionTransitoToolStripMenuItem.Text = "Configurar Tránsito";
            this.configuracionTransitoToolStripMenuItem.Click += new System.EventHandler(this.configuracionTransitoToolStripMenuItem_Click);
            // 
            // comparendosToolStripMenuItem
            // 
            this.comparendosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearComparendoToolStripMenuItem,
            this.modificarComparendoToolStripMenuItem,
            this.consultarComparendoToolStripMenuItem,
            this.anularComparendoToolStripMenuItem,
            this.cancelaranulacionComparendoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.gestionInfractorToolStripMenuItem,
            this.gestionVehiculoToolStripMenuItem});
            this.comparendosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("comparendosToolStripMenuItem.Image")));
            this.comparendosToolStripMenuItem.Name = "comparendosToolStripMenuItem";
            this.comparendosToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.comparendosToolStripMenuItem.Text = "Comparendos";
            this.comparendosToolStripMenuItem.Click += new System.EventHandler(this.comparendosToolStripMenuItem_Click);
            // 
            // crearComparendoToolStripMenuItem
            // 
            this.crearComparendoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("crearComparendoToolStripMenuItem.Image")));
            this.crearComparendoToolStripMenuItem.Name = "crearComparendoToolStripMenuItem";
            this.crearComparendoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.crearComparendoToolStripMenuItem.Text = "Crear Comparendo";
            this.crearComparendoToolStripMenuItem.Click += new System.EventHandler(this.crearComparendoToolStripMenuItem_Click);
            // 
            // modificarComparendoToolStripMenuItem
            // 
            this.modificarComparendoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarComparendoToolStripMenuItem.Image")));
            this.modificarComparendoToolStripMenuItem.Name = "modificarComparendoToolStripMenuItem";
            this.modificarComparendoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.modificarComparendoToolStripMenuItem.Text = "Modificar Comparendo";
            this.modificarComparendoToolStripMenuItem.Click += new System.EventHandler(this.modificarComparendoToolStripMenuItem_Click);
            // 
            // consultarComparendoToolStripMenuItem
            // 
            this.consultarComparendoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarComparendoToolStripMenuItem.Image")));
            this.consultarComparendoToolStripMenuItem.Name = "consultarComparendoToolStripMenuItem";
            this.consultarComparendoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.consultarComparendoToolStripMenuItem.Text = "Consultar Comparendo";
            this.consultarComparendoToolStripMenuItem.Click += new System.EventHandler(this.consultarComparendoToolStripMenuItem_Click);
            // 
            // anularComparendoToolStripMenuItem
            // 
            this.anularComparendoToolStripMenuItem.Image = global::Comparendos.Properties.Resources.undo;
            this.anularComparendoToolStripMenuItem.Name = "anularComparendoToolStripMenuItem";
            this.anularComparendoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.anularComparendoToolStripMenuItem.Text = "Anular Comparendo";
            this.anularComparendoToolStripMenuItem.Click += new System.EventHandler(this.anularComparendoToolStripMenuItem_Click);
            // 
            // cancelaranulacionComparendoToolStripMenuItem
            // 
            this.cancelaranulacionComparendoToolStripMenuItem.Name = "cancelaranulacionComparendoToolStripMenuItem";
            this.cancelaranulacionComparendoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.cancelaranulacionComparendoToolStripMenuItem.Text = "Cancelar Anulacion Comparendo";
            this.cancelaranulacionComparendoToolStripMenuItem.Click += new System.EventHandler(this.cancelaranulacionComparendoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(247, 6);
            // 
            // gestionInfractorToolStripMenuItem
            // 
            this.gestionInfractorToolStripMenuItem.Name = "gestionInfractorToolStripMenuItem";
            this.gestionInfractorToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.gestionInfractorToolStripMenuItem.Text = "Gestión Infractor";
            this.gestionInfractorToolStripMenuItem.Click += new System.EventHandler(this.gestionInfractorToolStripMenuItem_Click);
            // 
            // gestionVehiculoToolStripMenuItem
            // 
            this.gestionVehiculoToolStripMenuItem.Name = "gestionVehiculoToolStripMenuItem";
            this.gestionVehiculoToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.gestionVehiculoToolStripMenuItem.Text = "Gestión Vehículo";
            this.gestionVehiculoToolStripMenuItem.Click += new System.EventHandler(this.gestionVehiculoToolStripMenuItem_Click);
            // 
            // resolucionesToolStripMenuItem
            // 
            this.resolucionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.reesolucionesToolStripMenuItem});
            this.resolucionesToolStripMenuItem.Name = "resolucionesToolStripMenuItem";
            this.resolucionesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.resolucionesToolStripMenuItem.Text = "Resoluciones";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plantillasToolStripMenuItem});
            this.toolStripMenuItem2.Image = global::Comparendos.Properties.Resources.cogs;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem2.Text = "Gestión Plantillas";
            // 
            // plantillasToolStripMenuItem
            // 
            this.plantillasToolStripMenuItem.Image = global::Comparendos.Properties.Resources.signup;
            this.plantillasToolStripMenuItem.Name = "plantillasToolStripMenuItem";
            this.plantillasToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.plantillasToolStripMenuItem.Text = "Plantillas";
            this.plantillasToolStripMenuItem.Click += new System.EventHandler(this.plantillasToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imposiciónInfractorToolStripMenuItem,
            this.cambioCódigoToolStripMenuItem,
            this.prescripciónInfractorToolStripMenuItem,
            this.exoneraciónToolStripMenuItem,
            this.masivasRangoFechasToolStripMenuItem,
            this.revocatoriaToolStripMenuItem1});
            this.toolStripMenuItem3.Image = global::Comparendos.Properties.Resources.lightning;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(197, 22);
            this.toolStripMenuItem3.Text = "Generar Resolución";
            // 
            // imposiciónInfractorToolStripMenuItem
            // 
            this.imposiciónInfractorToolStripMenuItem.Name = "imposiciónInfractorToolStripMenuItem";
            this.imposiciónInfractorToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.imposiciónInfractorToolStripMenuItem.Text = "Imposición Infractor";
            this.imposiciónInfractorToolStripMenuItem.Click += new System.EventHandler(this.imposiciónInfractorToolStripMenuItem_Click);
            // 
            // cambioCódigoToolStripMenuItem
            // 
            this.cambioCódigoToolStripMenuItem.Name = "cambioCódigoToolStripMenuItem";
            this.cambioCódigoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.cambioCódigoToolStripMenuItem.Text = "Cambio Código";
            this.cambioCódigoToolStripMenuItem.Click += new System.EventHandler(this.cambioCódigoToolStripMenuItem_Click);
            // 
            // prescripciónInfractorToolStripMenuItem
            // 
            this.prescripciónInfractorToolStripMenuItem.Name = "prescripciónInfractorToolStripMenuItem";
            this.prescripciónInfractorToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.prescripciónInfractorToolStripMenuItem.Text = "Prescripción Infractor";
            this.prescripciónInfractorToolStripMenuItem.Click += new System.EventHandler(this.prescripciónInfractorToolStripMenuItem_Click);
            // 
            // exoneraciónToolStripMenuItem
            // 
            this.exoneraciónToolStripMenuItem.Name = "exoneraciónToolStripMenuItem";
            this.exoneraciónToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.exoneraciónToolStripMenuItem.Text = "Exoneración";
            this.exoneraciónToolStripMenuItem.Click += new System.EventHandler(this.exoneraciónInfractorToolStripMenuItem_Click);
            // 
            // masivasRangoFechasToolStripMenuItem
            // 
            this.masivasRangoFechasToolStripMenuItem.Name = "masivasRangoFechasToolStripMenuItem";
            this.masivasRangoFechasToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.masivasRangoFechasToolStripMenuItem.Text = "Masivas Rango Fechas";
            this.masivasRangoFechasToolStripMenuItem.Click += new System.EventHandler(this.masivasRangoFechasToolStripMenuItem_Click);
            // 
            // revocatoriaToolStripMenuItem1
            // 
            this.revocatoriaToolStripMenuItem1.Name = "revocatoriaToolStripMenuItem1";
            this.revocatoriaToolStripMenuItem1.Size = new System.Drawing.Size(192, 22);
            this.revocatoriaToolStripMenuItem1.Text = "Revocatoria";
            this.revocatoriaToolStripMenuItem1.Click += new System.EventHandler(this.revocatoriaToolStripMenuItem1_Click);
            // 
            // reesolucionesToolStripMenuItem
            // 
            this.reesolucionesToolStripMenuItem.Image = global::Comparendos.Properties.Resources.search;
            this.reesolucionesToolStripMenuItem.Name = "reesolucionesToolStripMenuItem";
            this.reesolucionesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.reesolucionesToolStripMenuItem.Text = "Consultar Resoluciones";
            this.reesolucionesToolStripMenuItem.Click += new System.EventHandler(this.reesolucionesToolStripMenuItem_Click);
            // 
            // agentesToolStripMenuItem
            // 
            this.agentesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarAgentesToolStripMenuItem,
            this.crearRangoComparendoToolStripMenuItem,
            this.asignarComparenderasToolStripMenuItem,
            this.buscarComparenderasToolStripMenuItem});
            this.agentesToolStripMenuItem.Name = "agentesToolStripMenuItem";
            this.agentesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.agentesToolStripMenuItem.Text = "Agentes";
            // 
            // gestionarAgentesToolStripMenuItem
            // 
            this.gestionarAgentesToolStripMenuItem.Name = "gestionarAgentesToolStripMenuItem";
            this.gestionarAgentesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.gestionarAgentesToolStripMenuItem.Text = "Gestionar Agentes";
            this.gestionarAgentesToolStripMenuItem.Click += new System.EventHandler(this.gestionarAgentesToolStripMenuItem_Click);
            // 
            // crearRangoComparendoToolStripMenuItem
            // 
            this.crearRangoComparendoToolStripMenuItem.Name = "crearRangoComparendoToolStripMenuItem";
            this.crearRangoComparendoToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.crearRangoComparendoToolStripMenuItem.Text = "Crear Rango Comparendo";
            this.crearRangoComparendoToolStripMenuItem.Click += new System.EventHandler(this.crearRangoComparendoToolStripMenuItem_Click);
            // 
            // asignarComparenderasToolStripMenuItem
            // 
            this.asignarComparenderasToolStripMenuItem.Name = "asignarComparenderasToolStripMenuItem";
            this.asignarComparenderasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.asignarComparenderasToolStripMenuItem.Text = "Asignar Comparenderas";
            this.asignarComparenderasToolStripMenuItem.Click += new System.EventHandler(this.asignarComparenderasToolStripMenuItem_Click);
            // 
            // buscarComparenderasToolStripMenuItem
            // 
            this.buscarComparenderasToolStripMenuItem.Name = "buscarComparenderasToolStripMenuItem";
            this.buscarComparenderasToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.buscarComparenderasToolStripMenuItem.Text = "Buscar Comparenderas";
            this.buscarComparenderasToolStripMenuItem.Click += new System.EventHandler(this.buscarComparenderasToolStripMenuItem_Click);
            // 
            // infraccionesToolStripMenuItem
            // 
            this.infraccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurarInfraccionesToolStripMenuItem});
            this.infraccionesToolStripMenuItem.Name = "infraccionesToolStripMenuItem";
            this.infraccionesToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.infraccionesToolStripMenuItem.Text = "Infracciones";
            // 
            // configurarInfraccionesToolStripMenuItem
            // 
            this.configurarInfraccionesToolStripMenuItem.Name = "configurarInfraccionesToolStripMenuItem";
            this.configurarInfraccionesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.configurarInfraccionesToolStripMenuItem.Text = "Gestión Infracciones";
            this.configurarInfraccionesToolStripMenuItem.Click += new System.EventHandler(this.configurarInfraccionesToolStripMenuItem_Click);
            // 
            // archivosPlanosSimitToolStripMenuItem
            // 
            this.archivosPlanosSimitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarPlanosSimitToolStripMenuItem,
            this.cargarPlanosSimitToolStripMenuItem});
            this.archivosPlanosSimitToolStripMenuItem.Image = global::Comparendos.Properties.Resources.file;
            this.archivosPlanosSimitToolStripMenuItem.Name = "archivosPlanosSimitToolStripMenuItem";
            this.archivosPlanosSimitToolStripMenuItem.Size = new System.Drawing.Size(149, 20);
            this.archivosPlanosSimitToolStripMenuItem.Text = "Archivos Planos Simit";
            // 
            // generarPlanosSimitToolStripMenuItem
            // 
            this.generarPlanosSimitToolStripMenuItem.Image = global::Comparendos.Properties.Resources.stackoverflow;
            this.generarPlanosSimitToolStripMenuItem.Name = "generarPlanosSimitToolStripMenuItem";
            this.generarPlanosSimitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.generarPlanosSimitToolStripMenuItem.Text = "Generar Planos Simit";
            this.generarPlanosSimitToolStripMenuItem.Click += new System.EventHandler(this.generarPlanosSimitToolStripMenuItem_Click);
            // 
            // liquidacionToolStripMenuItem
            // 
            this.liquidacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liquidaciónComparendoToolStripMenuItem,
            this.acuerdosDePagoToolStripMenuItem,
            this.acuerdosDePagoPorInfractorToolStripMenuItem,
            this.eliminarAcuerdoDePagoToolStripMenuItem,
            this.coToolStripMenuItem,
            this.pagarFacturaToolStripMenuItem,
            this.buscarFacturaToolStripMenuItem,
            this.anularPagoToolStripMenuItem,
            this.registrarPagoSimitToolStripMenuItem});
            this.liquidacionToolStripMenuItem.Image = global::Comparendos.Properties.Resources.coin;
            this.liquidacionToolStripMenuItem.Name = "liquidacionToolStripMenuItem";
            this.liquidacionToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.liquidacionToolStripMenuItem.Text = "Liquidación";
            // 
            // liquidaciónComparendoToolStripMenuItem
            // 
            this.liquidaciónComparendoToolStripMenuItem.Name = "liquidaciónComparendoToolStripMenuItem";
            this.liquidaciónComparendoToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.liquidaciónComparendoToolStripMenuItem.Text = "Liquidación Comparendo";
            this.liquidaciónComparendoToolStripMenuItem.Click += new System.EventHandler(this.liquidaciónComparendoToolStripMenuItem_Click);
            // 
            // acuerdosDePagoToolStripMenuItem
            // 
            this.acuerdosDePagoToolStripMenuItem.Name = "acuerdosDePagoToolStripMenuItem";
            this.acuerdosDePagoToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.acuerdosDePagoToolStripMenuItem.Text = "Acuerdos de Pago";
            this.acuerdosDePagoToolStripMenuItem.Click += new System.EventHandler(this.acuerdosDePagoToolStripMenuItem_Click);
            // 
            // acuerdosDePagoPorInfractorToolStripMenuItem
            // 
            this.acuerdosDePagoPorInfractorToolStripMenuItem.Name = "acuerdosDePagoPorInfractorToolStripMenuItem";
            this.acuerdosDePagoPorInfractorToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.acuerdosDePagoPorInfractorToolStripMenuItem.Text = "Buscar Acuerdo de pago por infractor";
            this.acuerdosDePagoPorInfractorToolStripMenuItem.Click += new System.EventHandler(this.acuerdosDePagoPorInfractorToolStripMenuItem_Click);
            // 
            // eliminarAcuerdoDePagoToolStripMenuItem
            // 
            this.eliminarAcuerdoDePagoToolStripMenuItem.Name = "eliminarAcuerdoDePagoToolStripMenuItem";
            this.eliminarAcuerdoDePagoToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.eliminarAcuerdoDePagoToolStripMenuItem.Text = "Eliminar acuerdo de Pago";
            this.eliminarAcuerdoDePagoToolStripMenuItem.Click += new System.EventHandler(this.eliminarAcuerdoDePagoToolStripMenuItem_Click);
            // 
            // coToolStripMenuItem
            // 
            this.coToolStripMenuItem.Name = "coToolStripMenuItem";
            this.coToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.coToolStripMenuItem.Text = "Configuración de Tarifas";
            this.coToolStripMenuItem.Click += new System.EventHandler(this.coToolStripMenuItem_Click);
            // 
            // pagarFacturaToolStripMenuItem
            // 
            this.pagarFacturaToolStripMenuItem.Name = "pagarFacturaToolStripMenuItem";
            this.pagarFacturaToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.pagarFacturaToolStripMenuItem.Text = "Pagar factura";
            this.pagarFacturaToolStripMenuItem.Click += new System.EventHandler(this.pagarFacturaToolStripMenuItem_Click);
            // 
            // buscarFacturaToolStripMenuItem
            // 
            this.buscarFacturaToolStripMenuItem.Name = "buscarFacturaToolStripMenuItem";
            this.buscarFacturaToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.buscarFacturaToolStripMenuItem.Text = "Buscar factura";
            this.buscarFacturaToolStripMenuItem.Click += new System.EventHandler(this.buscarFacturaToolStripMenuItem_Click);
            // 
            // anularPagoToolStripMenuItem
            // 
            this.anularPagoToolStripMenuItem.Name = "anularPagoToolStripMenuItem";
            this.anularPagoToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.anularPagoToolStripMenuItem.Text = "Anular pago";
            this.anularPagoToolStripMenuItem.Click += new System.EventHandler(this.anularPagoToolStripMenuItem_Click);
            // 
            // registrarPagoSimitToolStripMenuItem
            // 
            this.registrarPagoSimitToolStripMenuItem.Name = "registrarPagoSimitToolStripMenuItem";
            this.registrarPagoSimitToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.registrarPagoSimitToolStripMenuItem.Text = "Registrar pago SIMIT";
            this.registrarPagoSimitToolStripMenuItem.Click += new System.EventHandler(this.registrarPagoSimitToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesGeneralesToolStripMenuItem});
            this.reportesToolStripMenuItem.Image = global::Comparendos.Properties.Resources.file_powerpoint;
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reportesGeneralesToolStripMenuItem
            // 
            this.reportesGeneralesToolStripMenuItem.Name = "reportesGeneralesToolStripMenuItem";
            this.reportesGeneralesToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.reportesGeneralesToolStripMenuItem.Text = "Reportes Generales";
            this.reportesGeneralesToolStripMenuItem.Click += new System.EventHandler(this.reportesGeneralesToolStripMenuItem_Click);
            // 
            // CoactivosToolStripMenuItem
            // 
            this.CoactivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConsultarInfractorToolStripMenuItem});
            this.CoactivosToolStripMenuItem.Name = "CoactivosToolStripMenuItem";
            this.CoactivosToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.CoactivosToolStripMenuItem.Text = "Notificaciones";
            // 
            // ConsultarInfractorToolStripMenuItem
            // 
            this.ConsultarInfractorToolStripMenuItem.Name = "ConsultarInfractorToolStripMenuItem";
            this.ConsultarInfractorToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ConsultarInfractorToolStripMenuItem.Text = "Consultar Infractor";
            this.ConsultarInfractorToolStripMenuItem.Click += new System.EventHandler(this.ConsultarInfractorToolStripMenuItem_Click);
            // 
            // imposicionPorFechaToolStripMenuItem
            // 
            this.imposicionPorFechaToolStripMenuItem.Name = "imposicionPorFechaToolStripMenuItem";
            this.imposicionPorFechaToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.imposicionPorFechaToolStripMenuItem.Text = "Imposición por rango de Fechas";
            // 
            // generadorToolStripMenuItem
            // 
            this.generadorToolStripMenuItem.Name = "generadorToolStripMenuItem";
            this.generadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generadorToolStripMenuItem.Text = "Generador";
            // 
            // imageListFinal
            // 
            this.imageListFinal.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFinal.ImageStream")));
            this.imageListFinal.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFinal.Images.SetKeyName(0, "aid.png");
            this.imageListFinal.Images.SetKeyName(1, "arrow-up.png");
            this.imageListFinal.Images.SetKeyName(2, "arrow-up-right.png");
            this.imageListFinal.Images.SetKeyName(3, "at.png");
            this.imageListFinal.Images.SetKeyName(4, "award-fill.png");
            this.imageListFinal.Images.SetKeyName(5, "bars.png");
            this.imageListFinal.Images.SetKeyName(6, "binoculars.png");
            this.imageListFinal.Images.SetKeyName(7, "box-add.png");
            this.imageListFinal.Images.SetKeyName(8, "calculate.png");
            this.imageListFinal.Images.SetKeyName(9, "cart.png");
            this.imageListFinal.Images.SetKeyName(10, "checkbox-partial.png");
            this.imageListFinal.Images.SetKeyName(11, "checkmark.png");
            this.imageListFinal.Images.SetKeyName(12, "checkmark2.png");
            this.imageListFinal.Images.SetKeyName(13, "close.png");
            this.imageListFinal.Images.SetKeyName(14, "cogs.png");
            this.imageListFinal.Images.SetKeyName(15, "coin.png");
            this.imageListFinal.Images.SetKeyName(16, "console.png");
            this.imageListFinal.Images.SetKeyName(17, "download.png");
            this.imageListFinal.Images.SetKeyName(18, "droplet.png");
            this.imageListFinal.Images.SetKeyName(19, "exit.png");
            this.imageListFinal.Images.SetKeyName(20, "eye.png");
            this.imageListFinal.Images.SetKeyName(21, "file.png");
            this.imageListFinal.Images.SetKeyName(22, "file-excel.png");
            this.imageListFinal.Images.SetKeyName(23, "file-pdf.png");
            this.imageListFinal.Images.SetKeyName(24, "file-powerpoint.png");
            this.imageListFinal.Images.SetKeyName(25, "file-word.png");
            this.imageListFinal.Images.SetKeyName(26, "filter.png");
            this.imageListFinal.Images.SetKeyName(27, "first.png");
            this.imageListFinal.Images.SetKeyName(28, "floppy.png");
            this.imageListFinal.Images.SetKeyName(29, "hash.png");
            this.imageListFinal.Images.SetKeyName(30, "home.png");
            this.imageListFinal.Images.SetKeyName(31, "image.png");
            this.imageListFinal.Images.SetKeyName(32, "info.png");
            this.imageListFinal.Images.SetKeyName(33, "last.png");
            this.imageListFinal.Images.SetKeyName(34, "lightning.png");
            this.imageListFinal.Images.SetKeyName(35, "list-nested.png");
            this.imageListFinal.Images.SetKeyName(36, "loop.png");
            this.imageListFinal.Images.SetKeyName(37, "newspaper.png");
            this.imageListFinal.Images.SetKeyName(38, "next.png");
            this.imageListFinal.Images.SetKeyName(39, "office.png");
            this.imageListFinal.Images.SetKeyName(40, "paperclip.png");
            this.imageListFinal.Images.SetKeyName(41, "pencil.png");
            this.imageListFinal.Images.SetKeyName(42, "plus.png");
            this.imageListFinal.Images.SetKeyName(43, "point-down.png");
            this.imageListFinal.Images.SetKeyName(44, "point-up.png");
            this.imageListFinal.Images.SetKeyName(45, "previous.png");
            this.imageListFinal.Images.SetKeyName(46, "print.png");
            this.imageListFinal.Images.SetKeyName(47, "question.png");
            this.imageListFinal.Images.SetKeyName(48, "remove.png");
            this.imageListFinal.Images.SetKeyName(49, "road.png");
            this.imageListFinal.Images.SetKeyName(50, "search.png");
            this.imageListFinal.Images.SetKeyName(51, "shuffle.png");
            this.imageListFinal.Images.SetKeyName(52, "signup.png");
            this.imageListFinal.Images.SetKeyName(53, "spell-check.png");
            this.imageListFinal.Images.SetKeyName(54, "stackoverflow.png");
            this.imageListFinal.Images.SetKeyName(55, "undo.png");
            this.imageListFinal.Images.SetKeyName(56, "upload.png");
            this.imageListFinal.Images.SetKeyName(57, "user.png");
            this.imageListFinal.Images.SetKeyName(58, "user2.png");
            this.imageListFinal.Images.SetKeyName(59, "users.png");
            this.imageListFinal.Images.SetKeyName(60, "wrench.png");
            // 
            // cargarPlanosSimitToolStripMenuItem
            // 
            this.cargarPlanosSimitToolStripMenuItem.Name = "cargarPlanosSimitToolStripMenuItem";
            this.cargarPlanosSimitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.cargarPlanosSimitToolStripMenuItem.Text = "Cargar Planos Simit";
            this.cargarPlanosSimitToolStripMenuItem.Click += new System.EventHandler(this.cargarPlanosSimitToolStripMenuItem_Click);
            // 
            // FPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Comparendos.Properties.Resources.LOGO_SIOT_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1143, 478);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulo de Comparendos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionTransitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem confuguracionDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparendosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearComparendoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarComparendoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarComparendoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularComparendoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelaranulacionComparendoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarComparenderasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearRangoComparendoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarComparenderasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resolucionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imposicionPorFechaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reesolucionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infraccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarInfraccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acuerdosDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acuerdosDePagoPorInfractorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarAcuerdoDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarFacturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularPagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPagoSimitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivosPlanosSimitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarPlanosSimitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liquidaciónComparendoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarAgentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gestionInfractorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesGeneralesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CoactivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConsultarInfractorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem plantillasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem imposiciónInfractorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioCódigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prescripciónInfractorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exoneraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masivasRangoFechasToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListFinal;
        private System.Windows.Forms.ToolStripMenuItem revocatoriaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cargarPlanosSimitToolStripMenuItem;
    }
}
