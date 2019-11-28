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
    public partial class FrmRutas : Form
    {
        public FrmRutas()
        {
            InitializeComponent();
        }

        private void FrmRutas_Load(object sender, EventArgs e)
        {
            cargarMunicipios();
            cargarRutas();
            pantallaInicio();
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
                cmbMunicipio.DataSource = datos;
                cmbMunicipio.DisplayMember = "Nombre";
                cmbMunicipio.ValueMember = "IdMun";
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
        private void cargarRutas()
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
                comando.CommandText = "SP_RUTAS_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            OracleDataAdapter adaptador = new OracleDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                txtIdRuta.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Rutas_Buscar";
                comando.Parameters.Add(":pIdRuta", Convert.ToInt64(txtIdRuta.Text));
                comando.Parameters.Add(":c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtNomRuta.Text = datos.Rows[0]["NombreRuta"].ToString();
                    cmbMunicipio.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdMunicipio"]);
                    txtPrecio.Text = datos.Rows[0]["Precio"].ToString();
                    txtKmRecorridos.Text = datos.Rows[0]["KmRecorridos"].ToString();
                    txtTiempoEstimado.Text = datos.Rows[0]["TiempoEstimado"].ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Ruta no encontrada");
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
                comando.CommandText = "sp_Rutas_Eliminar";
                comando.Parameters.Add("pIdRuta",Convert.ToInt64(txtIdRuta.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("Ruta eliminada satisfactoriamente");
                pantallaInicio();
                cargarRutas();
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
                comando.CommandText = "sp_Rutas_Registrar";
                comando.Parameters.Add("pIdRuta",Convert.ToInt64(txtIdRuta.Text));
                comando.Parameters.Add("pNombreRuta",txtNomRuta.Text);
                comando.Parameters.Add("pMunicipio",cmbMunicipio.SelectedValue);
                comando.Parameters.Add("pPrecio",Convert.ToInt64(txtPrecio.Text));
                comando.Parameters.Add("pKmRecorridos", Convert.ToInt64(txtKmRecorridos.Text));
                comando.Parameters.Add("pTiempoEstimado", Convert.ToInt64(txtTiempoEstimado.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("La ruta ha sido registrada");
                pantallaInicio();
                cargarRutas();
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
                comando.CommandText = "sp_Rutas_Modificar";
                comando.Parameters.Add("pIdRuta", Convert.ToInt64(txtIdRuta.Text));
                comando.Parameters.Add("pNombreRuta", txtNomRuta.Text);
                comando.Parameters.Add("pMunicipio", cmbMunicipio.SelectedValue);
                comando.Parameters.Add("pPrecio", Convert.ToInt64(txtPrecio.Text));
                comando.Parameters.Add("pKmRecorridos", Convert.ToInt64(txtKmRecorridos.Text));
                comando.Parameters.Add("pTiempoEstimado", Convert.ToInt64(txtTiempoEstimado.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("La ruta ha sido modificada");
                pantallaInicio();
                cargarRutas();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }
        private void pantallaInicio()
        {
            txtIdRuta.Clear();
            txtNomRuta.Clear();
            cmbMunicipio.SelectedIndex = 0;
            txtPrecio.Clear();
            txtKmRecorridos.Clear();
            txtTiempoEstimado.Clear();
            txtIdRuta.Enabled = true;
            txtIdRuta.Focus();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
        }

        private void dgvRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdRuta.Text = dgvRutas.Rows[e.RowIndex].Cells["IdRuta"].Value.ToString();
            txtNomRuta.Text = dgvRutas.Rows[e.RowIndex].Cells["NombreRuta"].Value.ToString();
            cmbMunicipio.SelectedValue = Convert.ToInt64(dgvRutas.Rows[e.RowIndex].Cells["IdMunicipio"].Value.ToString());
            txtPrecio.Text = dgvRutas.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            txtKmRecorridos.Text = dgvRutas.Rows[e.RowIndex].Cells["KmRecorridos"].Value.ToString();
            txtTiempoEstimado.Text = dgvRutas.Rows[e.RowIndex].Cells["TiempoEstimado"].Value.ToString();
            txtIdRuta.Enabled = false;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnRegistrar.Enabled = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu venMenu = new FrmMenu();
            this.Hide();
            venMenu.Show();
        }

        private void FrmRutas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
