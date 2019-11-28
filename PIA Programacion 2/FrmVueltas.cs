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
    public partial class frmVueltas : Form
    {
        public frmVueltas()
        {
            InitializeComponent();
        }
        private void pantallaInicio()
        {
            txtIdVuelta.Clear();
            txtIdChofer.Clear();
            dtpHoraSalida.Value = DateTime.Now;
            dtpHoraLlegada.Value = DateTime.Now;
            txtKmInicial.Clear();
            txtKmFinal.Clear();
            txtNumPasajeros.Clear();
            txtIdVuelta.Enabled = true;
            txtIdVuelta.Focus();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRegistrar.Enabled = false;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand cmd = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=XE;user id=UserPia;Password=baseprogra";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_vuelta_Eliminar";
                cmd.Parameters.Add("pIdVuelta", Convert.ToInt64(txtIdVuelta.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("El recorrido fue borrado correctamente");
                pantallaInicio();
                cargarVueltas();
            }
            catch (Exception ex)
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
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter ad = new OracleDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                txtIdVuelta.Enabled = false;
                con.ConnectionString = "data source=XE;user id=UserPia;password=baseprogra";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_vuelta_buscar";
                cmd.Parameters.Add("pIdVuelta", Convert.ToInt64(txtIdVuelta.Text));
                cmd.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ad.SelectCommand = cmd;
                ad.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtIdChofer.Text = datos.Rows[0]["IdChoferCamionRuta"].ToString();
                    dtpHoraSalida.Value = DateTime.Parse(datos.Rows[0]["HoraSalida"].ToString());
                    dtpHoraLlegada.Value = DateTime.Parse(datos.Rows[0]["HoraLlegada"].ToString());
                    txtKmInicial.Text = datos.Rows[0]["OdometroInicial"].ToString();
                    txtKmFinal.Text = datos.Rows[0]["OdometroFinal"].ToString();
                    txtNumPasajeros.Text = datos.Rows[0]["PasajerosQueAbordaron"].ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Recorrido no encontrado");
                    btnRegistrar.Enabled = true;
                }
            }
            catch (Exception ex)
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
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_vuelta_modificar";
                comando.Parameters.Add("pIdVuelta", Convert.ToInt64(txtIdVuelta.Text));
                comando.Parameters.Add("pIdchofer", txtIdChofer.Text);
                comando.Parameters.Add("pHoraSalida", Convert.ToDateTime(dtpHoraSalida.Value.ToString("HH:mm tt")));
                comando.Parameters.Add("pHoraLlegada", Convert.ToDateTime(dtpHoraLlegada.Value.ToString("HH:mm tt")));
                comando.Parameters.Add("pOdometroInicial", Convert.ToInt64(txtKmInicial.Text));
                comando.Parameters.Add("pOdometroFinal", Convert.ToInt64(txtKmFinal.Text));
                comando.Parameters.Add("pPasajerosQueAbordaron", Convert.ToInt64(txtNumPasajeros.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("El recorrido ha sido modificado correctamente");
                pantallaInicio();
                cargarVueltas();
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
            OracleCommand cmd = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=XE;user id=UserPia;password=baseprogra";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_vuelta_registrar";
                cmd.Parameters.Add("pIdVuelta", Convert.ToInt64(txtIdVuelta.Text));
                cmd.Parameters.Add("pIdchofer", txtIdChofer.Text);
                cmd.Parameters.Add("pHoraSalida",Convert.ToDateTime(dtpHoraSalida.Value.ToString("HH:mm tt")));
                cmd.Parameters.Add("pHoraLlegada",Convert.ToDateTime(dtpHoraLlegada.Value.ToString("HH:mm tt")));
                cmd.Parameters.Add("pOdometroInicial", Convert.ToInt64(txtKmInicial.Text));
                cmd.Parameters.Add("pOdometroFinal", Convert.ToInt64(txtKmFinal.Text));
                cmd.Parameters.Add("pPasajerosQueAbordaron", Convert.ToInt64(txtNumPasajeros.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("El recorrido ha sido registrado exitosamente");
                pantallaInicio();
                cargarVueltas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void frmVueltas_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cargarVueltas();
        }
        private void cargarVueltas()
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
                comando.CommandText = "SP_VUELTA_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvVueltas.DataSource = datos;
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

        private void dgvVueltas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdVuelta.Text= dgvVueltas.Rows[e.RowIndex].Cells["IdVuelta"].Value.ToString();
            txtIdChofer.Text= dgvVueltas.Rows[e.RowIndex].Cells["IdChoferCamionRuta"].Value.ToString();
            dtpHoraSalida.Value = DateTime.Parse(dgvVueltas.Rows[e.RowIndex].Cells["HoraSalida"].Value.ToString());
            dtpHoraLlegada.Value = DateTime.Parse(dgvVueltas.Rows[e.RowIndex].Cells["HoraLlegada"].Value.ToString());
            txtKmInicial.Text= dgvVueltas.Rows[e.RowIndex].Cells["OdometroInicial"].Value.ToString();
            txtKmFinal.Text = dgvVueltas.Rows[e.RowIndex].Cells["OdometroFinal"].Value.ToString();
            txtNumPasajeros.Text = dgvVueltas.Rows[e.RowIndex].Cells["PasajerosQueAbordaron"].Value.ToString();
            txtIdVuelta.Enabled = false;
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

        private void frmVueltas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
