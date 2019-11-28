using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace PIA_Programacion_2
{
    public partial class ReporteMunicipioRutas : Form
    {
        public ReporteMunicipioRutas()
        {
            InitializeComponent();
        }

        private void ReporteMunicipioRutas_Load(object sender, EventArgs e)
        {
            cargarMunicipios();
        }
        private void cargarMunicipios()
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            OracleDataAdapter adaptador = new OracleDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_MUNICIPIOS_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                DataRow linea;
                linea = datos.NewRow();
                linea["NOMBRE"] = "[SELECCIONAR]";
                linea["IdMun"] = "-1";
                datos.Rows.InsertAt(linea, 0);
                cmbMunicipios.DataSource = datos;
                cmbMunicipios.DisplayMember = "Nombre";
                cmbMunicipios.ValueMember = "IdMun";
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            OracleDataAdapter adaptador = new OracleDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Reporte_Rutas";
                comando.Parameters.Add("pIdMunicipio", cmbMunicipios.SelectedValue);
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvRutas.DataSource = datos;
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dgvRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu venMenu = new FrmMenu();
            this.Hide();
            venMenu.Show();
        }

        private void ReporteMunicipioRutas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
