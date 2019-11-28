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
    public partial class FrmEmpresa : Form
    {
        public FrmEmpresa()
        {
            InitializeComponent();
        }
        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cargarColonias();
            cargarMunicipios();
            cargarEmpresas();
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
        private void cargarColonias()
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
                comando.CommandText = "SP_COLONIAS_BUSCARX_MUNICIPIO";
                comando.Parameters.Add("pIdMun",cmbMunicipio.SelectedValue);
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                DataRow linea;
                linea = datos.NewRow();
                linea["NOMBRE"] = "[SELECCIONAR]";
                linea["IdColonia"] = "-1";
                datos.Rows.InsertAt(linea, 0);
                cmbColonia.DataSource = datos;
                cmbColonia.DisplayMember = "NOMBRE";
                cmbColonia.ValueMember = "IdColonia";
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
        private void cargarEmpresas()
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
                comando.CommandText = "SP_EMPRESA_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvEmpresas.DataSource = datos;
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
                txtidemp.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Empresa_Buscar";
                comando.Parameters.Add("pIdEmpresa", Convert.ToInt64(txtidemp.Text));
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtnombre.Text = datos.Rows[0]["Nombre"].ToString();
                    txttelefono.Text = datos.Rows[0]["Telefono"].ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    cmbMunicipio.SelectedValue = Convert.ToInt64(datos.Rows[0]["Municipio"].ToString());
                    cargarColonias();
                    cmbColonia.SelectedValue = Convert.ToInt64(datos.Rows[0]["Colonia"].ToString());
                    txtCalleyNum.Text = datos.Rows[0]["CalleyNo"].ToString();
                    txtCodPostal.Text = datos.Rows[0]["CodPostal"].ToString();
                    dtpFechaFun.Value = DateTime.Parse(datos.Rows[0]["FECHAFUNDACION"].ToString());
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Empresa no econtrada");
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            try
            {
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Empresa_Eliminar";
                comando.Parameters.Add("pIdEmpresa", Convert.ToInt64(txtidemp.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("La empresa fue borrada correctamente");
                pantallaInicio();
                cargarEmpresas();
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
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Empresa_Registrar";
                comando.Parameters.Add("pIdEmpresa", Convert.ToInt64(txtidemp.Text));
                comando.Parameters.Add("pNombre", txtnombre.Text);
                comando.Parameters.Add("pTelefono", Convert.ToInt64(txttelefono.Text));
                comando.Parameters.Add("pMunicipio", cmbMunicipio.SelectedValue);
                comando.Parameters.Add("pColonia", cmbColonia.SelectedValue);
                comando.Parameters.Add("pCalleyNum", txtCalleyNum.Text);
                comando.Parameters.Add("pCodPostal", txtCodPostal.Text);
                comando.Parameters.Add("pFechaFundacion", dtpFechaFun.Value.Date);
                comando.ExecuteNonQuery();
                MessageBox.Show("La empresa ha sido ingresada correctamente");
                pantallaInicio();
                cargarEmpresas();
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
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Empresa_Modificar";
                comando.Parameters.Add("pIdEmpresa", Convert.ToInt64(txtidemp.Text));
                comando.Parameters.Add("pNombre", txtnombre.Text);
                comando.Parameters.Add("pTelefono", Convert.ToInt64(txttelefono.Text));
                comando.Parameters.Add("pMunicipio", cmbMunicipio.SelectedValue);
                comando.Parameters.Add("pColonia", cmbColonia.SelectedValue);
                comando.Parameters.Add("pCalleyNum", txtCalleyNum.Text);
                comando.Parameters.Add("pCodPostal", txtCodPostal.Text);
                comando.Parameters.Add("pFechaFundacion", dtpFechaFun.Value.Date);               
                comando.ExecuteNonQuery();
                MessageBox.Show("La empresa ha sido modificada correctamente");
                pantallaInicio();
                cargarEmpresas();
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
            txtidemp.Clear();
            txtnombre.Clear();
            txttelefono.Clear();
            cmbMunicipio.SelectedIndex = 0;
            cmbColonia.SelectedIndex = 0;
            txtCalleyNum.Clear();
            txtCodPostal.Clear();
            dtpFechaFun.Value = DateTime.Now;
            txtidemp.Enabled = true;
            txtidemp.Focus();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
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

        private void cmbMunicipio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarColonias();
        }

        private void dgvEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidemp.Text = dgvEmpresas.Rows[e.RowIndex].Cells["IdEmpresa"].Value.ToString();
            txtnombre.Text = dgvEmpresas.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txttelefono.Text = dgvEmpresas.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            cmbMunicipio.SelectedValue = Convert.ToInt64(dgvEmpresas.Rows[e.RowIndex].Cells["Municipio"].Value.ToString());
            cargarColonias();
            cmbColonia.SelectedValue = Convert.ToInt64(dgvEmpresas.Rows[e.RowIndex].Cells["Colonia"].Value.ToString());
            txtCalleyNum.Text = dgvEmpresas.Rows[e.RowIndex].Cells["CalleyNo"].Value.ToString();
            txtCodPostal.Text = dgvEmpresas.Rows[e.RowIndex].Cells["CodPostal"].Value.ToString();
            dtpFechaFun.Value = DateTime.Parse(dgvEmpresas.Rows[e.RowIndex].Cells["FechaFundacion"].Value.ToString());
            txtidemp.Enabled = false;
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

        private void FrmEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
