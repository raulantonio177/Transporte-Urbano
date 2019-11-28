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
    public partial class FrmChoferCamion : Form
    {
        public FrmChoferCamion()
        {
            InitializeComponent();
        }

        private void FrmChoferCamion_Load(object sender, EventArgs e)
        {
            cargarChoferCamion();
            pantallaInicio();
        }
        private void cargarChoferCamion()
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
                comando.CommandText = "SP_CHOFERCAMION_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvChoferCamion.DataSource = datos;
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
        private void pantallaInicio()
        {
            txtIdChoferCamion.Clear();
            txtIdCamionRuta.Clear();
            dtpFechaAsignacion.Value = DateTime.Now;
            txtIdChoferCamion.Enabled = true;
            txtIdChoferCamion.Focus();
            txtIdEmpleado.Clear();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRegistrar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=xe;user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_CHOFERCAMION_ELIMINAR";
                comando.Parameters.Add("pIdChoferCamionRuta", Convert.ToInt64(txtIdChoferCamion.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado satisfactoriamente");
                pantallaInicio();
                cargarChoferCamion();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            OracleDataAdapter adaptador = new OracleDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                txtIdChoferCamion.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_CHOFERCAMION_BUSCAR";
                comando.Parameters.Add("pIdChoferCamionRuta", Convert.ToInt64(txtIdChoferCamion.Text));
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtIdCamionRuta.Text = datos.Rows[0]["IdCamionRuta"].ToString();
                    txtIdEmpleado.Text = datos.Rows[0]["IdEmpleado"].ToString();
                    dtpFechaAsignacion.Value= DateTime.Parse(datos.Rows[0]["FechaAsignacion"].ToString());
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                    cargarChoferCamion();
                }
                else
                {
                    MessageBox.Show("ChoferCamion no encontrado");
                    btnRegistrar.Enabled = true;
                }
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=xe;user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_CHOFERCAMION_REGISTRAR";
                comando.Parameters.Add("pIdChoferCamionRuta", Convert.ToInt64(txtIdChoferCamion.Text));
                comando.Parameters.Add("pIdCamionRuta", Convert.ToInt64(txtIdCamionRuta.Text));
                comando.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtIdEmpleado.Text));
                comando.Parameters.Add("pFechaAsignacion", dtpFechaAsignacion.Value.Date);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registrado con exito");
                pantallaInicio();
                cargarChoferCamion();
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=xe;user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_CHOFERCAMION_MODIFICAR";
                comando.Parameters.Add("pIdChoferCamionRuta", Convert.ToInt64(txtIdChoferCamion.Text));
                comando.Parameters.Add("pIdCamionRuta", txtIdCamionRuta.Text);
                comando.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtIdEmpleado.Text));
                comando.Parameters.Add("pFechaAsignacion", dtpFechaAsignacion.Value.Date);
                comando.ExecuteNonQuery();
                MessageBox.Show("Ha sido modificado");
                pantallaInicio();
                cargarChoferCamion();
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

        private void dgvChoferCamion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdChoferCamion.Text = dgvChoferCamion.Rows[e.RowIndex].Cells["IdChoferCamionRuta"].Value.ToString();
            txtIdCamionRuta.Text = dgvChoferCamion.Rows[e.RowIndex].Cells["IdCamionRuta"].Value.ToString();
            txtIdEmpleado.Text = dgvChoferCamion.Rows[e.RowIndex].Cells["IdEmpleado"].Value.ToString();
            dtpFechaAsignacion.Value = DateTime.Parse(dgvChoferCamion.Rows[e.RowIndex].Cells["FechaAsignacion"].Value.ToString());
            txtIdChoferCamion.Enabled = false;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRegistrar.Enabled = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu venMenu = new FrmMenu();
            this.Hide();
            venMenu.Show();
        }

        private void FrmChoferCamion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
