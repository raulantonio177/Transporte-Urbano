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
    public partial class FrmMunicipios : Form
    {
        public FrmMunicipios()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            OracleCommand comando = new OracleCommand();
            OracleDataAdapter adaptador = new OracleDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                txtIdMun.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Municipios_Buscar";
                comando.Parameters.Add("pIdMun", Convert.ToInt64(txtIdMun.Text));
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtNombre.Text = datos.Rows[0].ItemArray[1].ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Municipio no econtrado");
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
                comando.CommandText = "sp_Municipios_Eliminar";
                comando.Parameters.Add("pIdMun", Convert.ToInt64(txtIdMun.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("El municipio fue borrado correctamente");
                pantallaInicio();
                cargarMunicipios();
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
            txtIdMun.Clear();
            txtNombre.Clear();
            txtIdMun.Enabled = true;
            txtIdMun.Focus();
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRegistrar.Enabled = false;
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
                comando.CommandText = "sp_Municipios_Insertar";
                comando.Parameters.Add("pIdMun", Convert.ToInt64(txtIdMun.Text));
                comando.Parameters.Add("pNombre", txtNombre.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("El municipio ha sido ingresado correctamente");
                pantallaInicio();
                cargarMunicipios();
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
                comando.CommandText = "sp_Municipios_Modificar";
                comando.Parameters.Add("pIdMun", txtIdMun.Text);
                comando.Parameters.Add("pNombre", txtNombre.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("El municipio ha sido modificado correctamente");
                pantallaInicio();
                cargarMunicipios();
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

        private void FrmMunicipios_Load(object sender, EventArgs e)
        {
            pantallaInicio();
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
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_MUNICIPIOS_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvMunicipios.DataSource = datos;
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

        private void dgvMunicipios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdMun.Text = dgvMunicipios.Rows[e.RowIndex].Cells["IdMun"].Value.ToString();
            txtNombre.Text = dgvMunicipios.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtIdMun.Enabled = false;
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

        private void FrmMunicipios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
