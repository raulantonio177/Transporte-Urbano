namespace PIA_Programacion_2
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mCamiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminCamiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mCamionRuta = new System.Windows.Forms.ToolStripMenuItem();
            this.mChoferCamion = new System.Windows.Forms.ToolStripMenuItem();
            this.mMunicipios = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminMunicipios = new System.Windows.Forms.ToolStripMenuItem();
            this.mColonias = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminColonias = new System.Windows.Forms.ToolStripMenuItem();
            this.mRutas = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminRutas = new System.Windows.Forms.ToolStripMenuItem();
            this.mEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mTipoEmpleado = new System.Windows.Forms.ToolStripMenuItem();
            this.mVuelta = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminVuelta = new System.Windows.Forms.ToolStripMenuItem();
            this.mUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.mAdminEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.mReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mReporteRutas = new System.Windows.Forms.ToolStripMenuItem();
            this.mReporteEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mCamiones,
            this.mMunicipios,
            this.mColonias,
            this.mRutas,
            this.mEmpleados,
            this.mVuelta,
            this.mUsuarios,
            this.mEmpresas,
            this.mReportes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mCamiones
            // 
            this.mCamiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminCamiones,
            this.mCamionRuta,
            this.mChoferCamion});
            this.mCamiones.Name = "mCamiones";
            this.mCamiones.Size = new System.Drawing.Size(79, 20);
            this.mCamiones.Text = "CAMIONES";
            // 
            // mAdminCamiones
            // 
            this.mAdminCamiones.Name = "mAdminCamiones";
            this.mAdminCamiones.Size = new System.Drawing.Size(233, 22);
            this.mAdminCamiones.Text = "ADMINISTRACION";
            this.mAdminCamiones.Click += new System.EventHandler(this.mAdminCamiones_Click);
            // 
            // mCamionRuta
            // 
            this.mCamionRuta.Name = "mCamionRuta";
            this.mCamionRuta.Size = new System.Drawing.Size(233, 22);
            this.mCamionRuta.Text = "ASIGNAR CAMION A RUTA";
            this.mCamionRuta.Click += new System.EventHandler(this.mCamionRuta_Click);
            // 
            // mChoferCamion
            // 
            this.mChoferCamion.Name = "mChoferCamion";
            this.mChoferCamion.Size = new System.Drawing.Size(233, 22);
            this.mChoferCamion.Text = "ASIGNAR CHOFER A CAMION";
            this.mChoferCamion.Click += new System.EventHandler(this.mChoferCamion_Click);
            // 
            // mMunicipios
            // 
            this.mMunicipios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminMunicipios});
            this.mMunicipios.Name = "mMunicipios";
            this.mMunicipios.Size = new System.Drawing.Size(86, 20);
            this.mMunicipios.Text = "MUNICIPIOS";
            // 
            // mAdminMunicipios
            // 
            this.mAdminMunicipios.Name = "mAdminMunicipios";
            this.mAdminMunicipios.Size = new System.Drawing.Size(180, 22);
            this.mAdminMunicipios.Text = "ADMINISTRACION";
            this.mAdminMunicipios.Click += new System.EventHandler(this.mAdminMunicipios_Click);
            // 
            // mColonias
            // 
            this.mColonias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminColonias});
            this.mColonias.Name = "mColonias";
            this.mColonias.Size = new System.Drawing.Size(77, 20);
            this.mColonias.Text = "COLONIAS";
            // 
            // mAdminColonias
            // 
            this.mAdminColonias.Name = "mAdminColonias";
            this.mAdminColonias.Size = new System.Drawing.Size(180, 22);
            this.mAdminColonias.Text = "ADMINISTRACION";
            this.mAdminColonias.Click += new System.EventHandler(this.mAdminColonias_Click);
            // 
            // mRutas
            // 
            this.mRutas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminRutas});
            this.mRutas.Name = "mRutas";
            this.mRutas.Size = new System.Drawing.Size(54, 20);
            this.mRutas.Text = "RUTAS";
            // 
            // mAdminRutas
            // 
            this.mAdminRutas.Name = "mAdminRutas";
            this.mAdminRutas.Size = new System.Drawing.Size(180, 22);
            this.mAdminRutas.Text = "ADMINISTRACION";
            this.mAdminRutas.Click += new System.EventHandler(this.mAdminRutas_Click);
            // 
            // mEmpleados
            // 
            this.mEmpleados.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminEmpleados,
            this.mTipoEmpleado});
            this.mEmpleados.Name = "mEmpleados";
            this.mEmpleados.Size = new System.Drawing.Size(86, 20);
            this.mEmpleados.Text = "EMPLEADOS";
            // 
            // mAdminEmpleados
            // 
            this.mAdminEmpleados.Name = "mAdminEmpleados";
            this.mAdminEmpleados.Size = new System.Drawing.Size(180, 22);
            this.mAdminEmpleados.Text = "ADMINISTRACION";
            this.mAdminEmpleados.Click += new System.EventHandler(this.mAdminEmpleados_Click);
            // 
            // mTipoEmpleado
            // 
            this.mTipoEmpleado.Name = "mTipoEmpleado";
            this.mTipoEmpleado.Size = new System.Drawing.Size(180, 22);
            this.mTipoEmpleado.Text = "TIPO EMPLEADO";
            this.mTipoEmpleado.Click += new System.EventHandler(this.mTipoEmpleado_Click);
            // 
            // mVuelta
            // 
            this.mVuelta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminVuelta});
            this.mVuelta.Name = "mVuelta";
            this.mVuelta.Size = new System.Drawing.Size(89, 20);
            this.mVuelta.Text = "RECORRIDOS";
            // 
            // mAdminVuelta
            // 
            this.mAdminVuelta.Name = "mAdminVuelta";
            this.mAdminVuelta.Size = new System.Drawing.Size(180, 22);
            this.mAdminVuelta.Text = "ADMINISTRACION";
            this.mAdminVuelta.Click += new System.EventHandler(this.mAdminVuelta_Click);
            // 
            // mUsuarios
            // 
            this.mUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminUsuarios});
            this.mUsuarios.Name = "mUsuarios";
            this.mUsuarios.Size = new System.Drawing.Size(74, 20);
            this.mUsuarios.Text = "USUARIOS";
            // 
            // mAdminUsuarios
            // 
            this.mAdminUsuarios.Name = "mAdminUsuarios";
            this.mAdminUsuarios.Size = new System.Drawing.Size(180, 22);
            this.mAdminUsuarios.Text = "ADMINISTRACION";
            this.mAdminUsuarios.Click += new System.EventHandler(this.mAdminUsuarios_Click);
            // 
            // mEmpresas
            // 
            this.mEmpresas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mAdminEmpresas});
            this.mEmpresas.Name = "mEmpresas";
            this.mEmpresas.Size = new System.Drawing.Size(76, 20);
            this.mEmpresas.Text = "EMPRESAS";
            // 
            // mAdminEmpresas
            // 
            this.mAdminEmpresas.Name = "mAdminEmpresas";
            this.mAdminEmpresas.Size = new System.Drawing.Size(180, 22);
            this.mAdminEmpresas.Text = "ADMINISTRACION";
            this.mAdminEmpresas.Click += new System.EventHandler(this.mAdminEmpresas_Click);
            // 
            // mReportes
            // 
            this.mReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mReporteRutas,
            this.mReporteEmpleados});
            this.mReportes.Name = "mReportes";
            this.mReportes.Size = new System.Drawing.Size(73, 20);
            this.mReportes.Text = "REPORTES";
            // 
            // mReporteRutas
            // 
            this.mReporteRutas.Name = "mReporteRutas";
            this.mReporteRutas.Size = new System.Drawing.Size(192, 22);
            this.mReporteRutas.Text = "REPORTE RUTAS";
            this.mReporteRutas.Click += new System.EventHandler(this.mReporteRutas_Click);
            // 
            // mReporteEmpleados
            // 
            this.mReporteEmpleados.Name = "mReporteEmpleados";
            this.mReporteEmpleados.Size = new System.Drawing.Size(192, 22);
            this.mReporteEmpleados.Text = "REPORTE EMPLEADOS";
            this.mReporteEmpleados.Click += new System.EventHandler(this.mReporteEmpleados_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenu_FormClosing);
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mCamiones;
        private System.Windows.Forms.ToolStripMenuItem mAdminCamiones;
        private System.Windows.Forms.ToolStripMenuItem mCamionRuta;
        private System.Windows.Forms.ToolStripMenuItem mMunicipios;
        private System.Windows.Forms.ToolStripMenuItem mAdminMunicipios;
        private System.Windows.Forms.ToolStripMenuItem mColonias;
        private System.Windows.Forms.ToolStripMenuItem mAdminColonias;
        private System.Windows.Forms.ToolStripMenuItem mRutas;
        private System.Windows.Forms.ToolStripMenuItem mAdminRutas;
        private System.Windows.Forms.ToolStripMenuItem mEmpleados;
        private System.Windows.Forms.ToolStripMenuItem mAdminEmpleados;
        private System.Windows.Forms.ToolStripMenuItem mTipoEmpleado;
        private System.Windows.Forms.ToolStripMenuItem mVuelta;
        private System.Windows.Forms.ToolStripMenuItem mAdminVuelta;
        private System.Windows.Forms.ToolStripMenuItem mUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mAdminUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mChoferCamion;
        private System.Windows.Forms.ToolStripMenuItem mEmpresas;
        private System.Windows.Forms.ToolStripMenuItem mAdminEmpresas;
        private System.Windows.Forms.ToolStripMenuItem mReportes;
        private System.Windows.Forms.ToolStripMenuItem mReporteRutas;
        private System.Windows.Forms.ToolStripMenuItem mReporteEmpleados;
    }
}