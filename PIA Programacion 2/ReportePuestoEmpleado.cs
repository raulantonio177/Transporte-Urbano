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
    public partial class ReportePuestoEmpleado : Form
    {
        public ReportePuestoEmpleado()
        {
            InitializeComponent();
        }

        private void ReportePuestoEmpleado_Load(object sender, EventArgs e)
        {
            cargarPuestos();
        }
        private void cargarPuestos()
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
                comando.CommandText = "SP_TIPOMPLEADO_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                DataRow linea;
                linea = datos.NewRow();
                linea["NOMBRE"] = "[SELECCIONAR]";
                linea["IDTIPOEMPLEADO"] = "-1";
                datos.Rows.InsertAt(linea, 0);
                cmbPuesto.DataSource = datos;
                cmbPuesto.DisplayMember = "Nombre";
                cmbPuesto.ValueMember = "IDTIPOEMPLEADO";
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
                comando.CommandText = "sp_Reporte_Empleados";
                if (rdbMatutino.Checked == true)
                {
                    comando.Parameters.Add("pTurno", "1");
                }
                if (rdbVespertino.Checked == true)
                {
                    comando.Parameters.Add("pTurno", "2");
                }
                if (rdbNocturno.Checked == true)
                {
                    comando.Parameters.Add("pTurno", "3");
                }
                comando.Parameters.Add("pPuesto", cmbPuesto.SelectedValue);
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvEmpleados.DataSource = datos;
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu venMenu = new FrmMenu();
            this.Hide();
            venMenu.Show();
        }

        private void ReportePuestoEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
