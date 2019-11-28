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
    public partial class FrmCamiones : Form
    {
        public FrmCamiones()
        {
            InitializeComponent();
        }

        private void FrmCamiones_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cargarEmpresas();
            cargarCamiones();
        }
        private void cargarEmpresas()
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
                comando.CommandText = "SP_EMPRESA_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                DataRow linea;
                linea = datos.NewRow();
                linea["NOMBRE"] = "[SELECCIONAR]";
                linea["IdEmpresa"] = "-1";
                datos.Rows.InsertAt(linea, 0);
                cmbNumEmpresa.DataSource = datos;
                cmbNumEmpresa.DisplayMember = "Nombre";
                cmbNumEmpresa.ValueMember = "IdEmpresa";
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
        private void cargarCamiones()
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
                comando.CommandText = "SP_CAMIONES_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvCamiones.DataSource = datos;
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
            txtIdCamion.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtCapPasajeros.Clear();
            txtCapDiesel.Clear();
            cmbNumEmpresa.SelectedIndex = 0;
            txtIdCamion.Enabled = true;
            txtIdCamion.Focus();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRegistrar.Enabled = false;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Camiones_Eliminar";
                comando.Parameters.Add("pIdCamion", Convert.ToInt64(txtIdCamion.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("El camión fue destituido exitosamente");
                cargarCamiones();
                pantallaInicio();
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
                txtIdCamion.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Camiones_Buscar";
                comando.Parameters.Add(":pIdCamion", Convert.ToInt64(txtIdCamion.Text));
                comando.Parameters.Add(":c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtMarca.Text = datos.Rows[0]["Marca"].ToString();
                    txtModelo.Text = datos.Rows[0]["Modelo"].ToString();
                    txtCapPasajeros.Text = datos.Rows[0]["CapacidadPasajeros"].ToString();
                    txtCapDiesel.Text = datos.Rows[0]["CapacidadTanqueDiesel"].ToString();
                    cmbNumEmpresa.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdEmpresa"].ToString());
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Camion no encontrado");
                    btnRegistrar.Enabled = true;
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbNumEmpresa.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el nombre de la empresa");
                return;
            }
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Camiones_Insertar";
                comando.Parameters.Add("pIdCamion", Convert.ToInt64(txtIdCamion.Text));
                comando.Parameters.Add("pMarca", txtMarca.Text);
                comando.Parameters.Add("pModelo", txtModelo.Text);
                comando.Parameters.Add("pCapacidadPasajeros", Convert.ToInt64(txtCapPasajeros.Text));
                comando.Parameters.Add("pCapacidadTanqueDiesel", Convert.ToInt64(txtCapDiesel.Text));
                comando.Parameters.Add("pIdEmpresa", cmbNumEmpresa.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("El camión fue registrado correctamente");
                pantallaInicio();
                cargarCamiones();
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
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Camiones_Modificar";
                comando.Parameters.Add("pIdCamion", Convert.ToInt64(txtIdCamion.Text));
                comando.Parameters.Add("pMarca", txtMarca.Text);
                comando.Parameters.Add("pModelo", txtModelo.Text);
                comando.Parameters.Add("pCapacidadPasajeros", Convert.ToInt64(txtCapPasajeros.Text));
                comando.Parameters.Add("pCapacidadTanqueDiesel", Convert.ToInt64(txtCapDiesel.Text));
                comando.Parameters.Add("pIdEmpresa", cmbNumEmpresa.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("Los datos del camión se modificaron correctamente");
                cargarCamiones();
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

        private void dgvCamiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdCamion.Text = dgvCamiones.Rows[e.RowIndex].Cells["IdCamion"].Value.ToString();
            txtMarca.Text = dgvCamiones.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
            txtModelo.Text = dgvCamiones.Rows[e.RowIndex].Cells["Modelo"].Value.ToString();
            txtCapPasajeros.Text = dgvCamiones.Rows[e.RowIndex].Cells["CapacidadPasajeros"].Value.ToString();
            txtCapDiesel.Text = dgvCamiones.Rows[e.RowIndex].Cells["CapacidadTanqueDiesel"].Value.ToString();
            cmbNumEmpresa.SelectedValue = Convert.ToInt64(dgvCamiones.Rows[e.RowIndex].Cells["IdEmpresa"].Value.ToString());
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmMenu venMenu = new FrmMenu();
            this.Hide();
            venMenu.Show();
        }

        private void FrmCamiones_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
