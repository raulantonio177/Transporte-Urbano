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
    public partial class FrmCamionRuta : Form
    {
        public FrmCamionRuta()
        {
            InitializeComponent();
        }
        private void pantallaInicio()
        {
            txtIdCamionRuta.Clear();
            txtIdCamion.Clear();
            cmbRutas.SelectedIndex = -1;
            txtIdCamionRuta.Enabled = true;
            txtIdCamionRuta.Focus();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRegistrar.Enabled = false;
        }
        private void FrmCamionRuta_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cargarRutas();
            CargarCamionRutas();
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
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                DataRow linea;
                linea = datos.NewRow();
                linea["NOMBRERUTA"] = "[SELECCIONAR]";
                linea["IdRuta"] = "-1";
                datos.Rows.InsertAt(linea, 0);
                cmbRutas.DataSource = datos;
                cmbRutas.DisplayMember = "NombreRuta";
                cmbRutas.ValueMember = "IdRuta";
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
        private void CargarCamionRutas()
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
                comando.CommandText = "SP_CAMIONRUTA_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvCamionRuta.DataSource = datos;
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
                txtIdCamionRuta.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_CAMIONRUTA_BUSCAR";
                comando.Parameters.Add("pIdCamionRuta", Convert.ToInt64(txtIdCamionRuta.Text));
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtIdCamion.Text = datos.Rows[0]["IdCamion"].ToString();
                    cmbRutas.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdRuta"]);
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("CamionRuta no encontrado");
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
                comando.CommandText = "SP_CAMIONRUTA_ELIMINAR";
                comando.Parameters.Add("pIdCamionRuta", Convert.ToInt64(txtIdCamionRuta.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("CamionRuta eliminado satisfactoriamente");
                pantallaInicio();
                CargarCamionRutas();
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
                comando.CommandText = "SP_CAMIONRUTA_REGISTRAR";
                comando.Parameters.Add("pIdCamionRuta", Convert.ToInt64(txtIdCamionRuta.Text));
                comando.Parameters.Add("pIdCamion", Convert.ToInt64(txtIdCamion.Text));
                comando.Parameters.Add("pIdRuta", cmbRutas.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registrado con exito");
                pantallaInicio();
                CargarCamionRutas();
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
                comando.CommandText = "SP_CAMIONRUTA_MODIFICAR";
                comando.Parameters.Add("pIdCamionRuta", Convert.ToInt64(txtIdCamionRuta.Text));
                comando.Parameters.Add("pIdCamion", Convert.ToInt64(txtIdCamion.Text));
                comando.Parameters.Add("pIdRuta", Convert.ToInt64(cmbRutas.SelectedValue));
                comando.ExecuteNonQuery();
                MessageBox.Show("Modificacion exitosa");
                pantallaInicio();
                CargarCamionRutas();
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

        private void dgvCamionRuta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCamionRuta.Text = dgvCamionRuta.Rows[e.RowIndex].Cells["IdCamionRuta"].Value.ToString();
            txtIdCamion.Text = dgvCamionRuta.Rows[e.RowIndex].Cells["IdCamion"].Value.ToString();
            cmbRutas.SelectedValue = Convert.ToInt64(dgvCamionRuta.Rows[e.RowIndex].Cells["IdRuta"].Value.ToString());
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRegistrar.Enabled = false;
            txtIdCamionRuta.Enabled = false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu venMenu = new FrmMenu();
            this.Hide();
            venMenu.Show();
        }

        private void FrmCamionRuta_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
