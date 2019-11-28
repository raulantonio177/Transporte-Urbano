using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;

namespace PIA_Programacion_2
{
    public partial class FrmTipoEmpleado : Form
    {
        public FrmTipoEmpleado()
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
                    txtIdTipoEmp.Enabled = false;
                    con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                    con.Open();
                    comando.Connection = con;
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "SP_TIPOEMPLEADO_BUSCAR";
                    comando.Parameters.Add("pIdTipoEmpleado", Convert.ToInt64(txtIdTipoEmp.Text));
                    comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;                   
                    adaptador.SelectCommand = comando;
                    adaptador.Fill(datos);
                    if (datos.Rows.Count > 0)
                    {
                        txtPuesto.Text = datos.Rows[0].ItemArray[1].ToString();
                        btnModificar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnRegistrar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Tipo de empleado no econtrado");
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
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_TIPOEMPLEADO_ELIMINAR";
                comando.Parameters.Add("pIdTipoEmpleado", Convert.ToInt64(txtIdTipoEmp.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("El tipo de empleado fue borrado correctamente");
                pantallaInicio();
                cargarTipoEmpleados();
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
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_TIPOEMPLEADO_REGISTRAR";
                comando.Parameters.Add("pIdTipoEmpleado", Convert.ToInt64(txtIdTipoEmp.Text));
                comando.Parameters.Add("pNombre", txtPuesto.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("El tipo de empleado ha sido registrado correctamente");
                pantallaInicio();
                cargarTipoEmpleados();
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
                comando.CommandText = "SP_TIPOEMPLEADO_MODIFICAR";
                comando.Parameters.Add("pIdTipoEmpleado", Convert.ToInt64(txtIdTipoEmp.Text));
                comando.Parameters.Add("pNombre", txtPuesto.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("El tipo de empleado ha sido modificado correctamente");
                pantallaInicio();
                cargarTipoEmpleados();
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
            txtIdTipoEmp.Clear();
            txtPuesto.Clear();
            txtIdTipoEmp.Enabled = true;
            txtIdTipoEmp.Focus();
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

        private void FrmTipoEmpleado_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cargarTipoEmpleados();
        }
        private void cargarTipoEmpleados()
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
                comando.CommandText = "SP_TIPOMPLEADO_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvTipoEmpleados.DataSource = datos;
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

        private void dgvTipoEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdTipoEmp.Text = dgvTipoEmpleados.Rows[e.RowIndex].Cells["IdTipoEmpleado"].Value.ToString();
            txtPuesto.Text = dgvTipoEmpleados.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtIdTipoEmp.Enabled = false;
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

        private void FrmTipoEmpleado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
