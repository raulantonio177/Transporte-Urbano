using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_Programacion_2
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            if (clsProceso.VidTipo=="Administrador")
            {
                mChoferCamion.Enabled = false;
                mVuelta.Enabled = false;
            }
            else if (clsProceso.VidTipo == "Empresa")
            {
                mEmpresas.Enabled = false;
            }
            else if (clsProceso.VidTipo == "Empleado")
            {
                mEmpresas.Enabled = false;
                mCamiones.Enabled = false;
                mColonias.Enabled = false;
                mRutas.Enabled = false;
                mEmpleados.Enabled = false;
                mMunicipios.Enabled = false;
                mUsuarios.Enabled = false;
            }
        }

        private void mAdminCamiones_Click(object sender, EventArgs e)
        {
            FrmCamiones venCamiones = new FrmCamiones();
            this.Hide();
            venCamiones.Show();
        }

        private void mCamionRuta_Click(object sender, EventArgs e)
        {
            FrmCamionRuta venCamionRuta = new FrmCamionRuta();
            this.Hide();
            venCamionRuta.Show();
        }

        private void mChoferCamion_Click(object sender, EventArgs e)
        {
            FrmChoferCamion venChoferCamion = new FrmChoferCamion();
            this.Hide();
            venChoferCamion.Show();
        }

        private void mAdminMunicipios_Click(object sender, EventArgs e)
        {
            FrmMunicipios venMunicipios = new FrmMunicipios();
            this.Hide();
            venMunicipios.Show();
        }

        private void mAdminColonias_Click(object sender, EventArgs e)
        {
            FrmColonias venColonias = new FrmColonias();
            this.Hide();
            venColonias.Show();
        }

        private void mAdminRutas_Click(object sender, EventArgs e)
        {
            FrmRutas venRutas = new FrmRutas();
            this.Hide();
            venRutas.Show();
        }

        private void mAdminEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleados venEmpleados = new FrmEmpleados();
            this.Hide();
            venEmpleados.Show();
        }

        private void mTipoEmpleado_Click(object sender, EventArgs e)
        {
            FrmTipoEmpleado venTipoEmp = new FrmTipoEmpleado();
            this.Hide();
            venTipoEmp.Show();
        }

        private void mAdminVuelta_Click(object sender, EventArgs e)
        {
            frmVueltas venVueltas = new frmVueltas();
            this.Hide();
            venVueltas.Show();
        }

        private void mAdminUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios venUsuarios = new FrmUsuarios();
            this.Hide();
            venUsuarios.Show();
        }

        private void mAdminEmpresas_Click(object sender, EventArgs e)
        {
            FrmEmpresa venEmpresas = new FrmEmpresa();
            this.Hide();
            venEmpresas.Show();
        }

        private void mReporteRutas_Click(object sender, EventArgs e)
        {
            ReporteMunicipioRutas venReporteRutas = new ReporteMunicipioRutas();
            this.Hide();
            venReporteRutas.Show();
        }

        private void mReporteEmpleados_Click(object sender, EventArgs e)
        {
            ReportePuestoEmpleado venReporteEmpleados = new ReportePuestoEmpleado();
            this.Hide();
            venReporteEmpleados.Show();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
