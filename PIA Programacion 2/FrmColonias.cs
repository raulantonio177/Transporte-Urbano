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
    public partial class FrmColonias : Form
    {
        public FrmColonias()
        {
            InitializeComponent();
        }
        private void FrmColonias_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cargarMunicipios();
            cargarColonias();
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
        private void cargarColonias()
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
                comando.CommandText = "SP_COLONIAS_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvColonias.DataSource = datos;
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
                txtIdColonia.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Colonias_Buscar";
                comando.Parameters.Add("pIdColonia", Convert.ToInt64(txtIdColonia.Text));
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtNombre.Text = datos.Rows[0].ItemArray[1].ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                    cmbMunicipios.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdMun"].ToString());
                }
                else
                {
                    MessageBox.Show("Colonia no econtrada");
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
                comando.CommandText = "sp_Colonias_Eliminar";
                comando.Parameters.Add("pIdColonia", Convert.ToInt64(txtIdColonia.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("La colonia fue borrada correctamente");
                pantallaInicio();
                cargarColonias();
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
                comando.CommandText = "sp_Colonias_Insertar";
                comando.Parameters.Add("pIdColonia", Convert.ToInt64(txtIdColonia.Text));
                comando.Parameters.Add("pNombre", txtNombre.Text);
                comando.Parameters.Add("pIdMun", cmbMunicipios.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("La colonia ha sido ingresada correctamente");
                pantallaInicio();
                cargarColonias();
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
                comando.CommandText = "sp_Colonias_Modificar";
                comando.Parameters.Add("pIdColonia", txtIdColonia.Text);
                comando.Parameters.Add("pNombre", txtNombre.Text);
                comando.Parameters.Add("pIdMun", cmbMunicipios.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("La colonia ha sido modificada correctamente");
                pantallaInicio();
                cargarColonias();
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
            txtIdColonia.Clear();
            txtNombre.Clear();
            cmbMunicipios.SelectedIndex = 0;
            txtIdColonia.Enabled = true;
            txtIdColonia.Focus();
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

        private void dgvColonias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdColonia.Enabled = false;
            txtIdColonia.Text = dgvColonias.Rows[e.RowIndex].Cells["IdColonia"].Value.ToString();
            txtNombre.Text = dgvColonias.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            cmbMunicipios.SelectedValue = dgvColonias.Rows[e.RowIndex].Cells["IdMun"].Value.ToString();
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

        private void FrmColonias_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
