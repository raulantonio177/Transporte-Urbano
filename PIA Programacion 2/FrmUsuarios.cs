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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        private void pantallaInicio()
        {
            txtIdUsuario.Clear();
            cmbPuesto.SelectedIndex=0;
            txtIdEmpleado.Clear();
            txtPassword.Clear();
            txtIdUsuario.Enabled = true;
            txtIdUsuario.Focus();
            btnRegistrar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }
      
        private void cargarUsuarios()
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
                comando.CommandText = "sp_Usuarios_Consultar_Todo";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvUsuarios.DataSource = datos;
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
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_USUARIOS_ELIMINAR";
                comando.Parameters.Add("pIdUsuario", Convert.ToInt64(txtIdUsuario.Text));
                comando.ExecuteNonQuery();
                MessageBox.Show("El usuario fue eliminado correctamente");
                pantallaInicio();
                cargarUsuarios();
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
                comando.CommandText = "SP_USUARIOS_INSERTAR";
                comando.Parameters.Add("pIdUsuario", Convert.ToInt64(txtIdUsuario.Text));
                if (cmbPuesto.SelectedIndex == 1)
                {
                    comando.Parameters.Add("pTipoUsuario", "Administrador");
                }
                else if (cmbPuesto.SelectedIndex == 2)
                {
                    comando.Parameters.Add("pTipoUsuario", "Empresa");
                }
                else if (cmbPuesto.SelectedIndex == 3)
                {
                    comando.Parameters.Add("pTipoUsuario", "Empleado");
                }
                comando.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtIdEmpleado.Text));
                comando.Parameters.Add("pPassword", txtPassword.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("El usuario ha sido registrado correctamente");
                pantallaInicio();
                cargarUsuarios();
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
                comando.CommandText = "SP_USUARIOS_MODIFICAR";
                comando.Parameters.Add("pIdUsuario", Convert.ToInt64(txtIdUsuario.Text));
                if (cmbPuesto.SelectedIndex == 1)
                {
                    comando.Parameters.Add("pTipoUsuario", "Administrador");
                }
                else if (cmbPuesto.SelectedIndex == 2)
                {
                    comando.Parameters.Add("pTipoUsuario", "Empresa");
                }
                else if (cmbPuesto.SelectedIndex == 3)
                {
                    comando.Parameters.Add("pTipoUsuario", "Empleado");
                }
                comando.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtIdEmpleado.Text));
                comando.Parameters.Add("pPassword", txtPassword.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("El usuario ha sido modificado correctamente");
                pantallaInicio();
                cargarUsuarios();
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
                txtIdUsuario.Enabled = false;
                con.ConnectionString = "data source=xe; user id=UserPia; password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_USUARIOS_BUSCAR";
                comando.Parameters.Add("pIdUsuario", Convert.ToInt64(txtIdUsuario.Text));
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtIdEmpleado.Text = datos.Rows[0]["IdEmpleado"].ToString();
                    if (datos.Rows[0]["TIPOUSUARIO"].ToString() == "Administrador")
                    {
                        cmbPuesto.SelectedIndex = 1;
                    }
                    else if (datos.Rows[0]["TIPOUSUARIO"].ToString() == "Empresa")
                    {
                        cmbPuesto.SelectedIndex = 2;
                    }
                    else if (datos.Rows[0]["TIPOUSUARIO"].ToString() == "Empleado")
                    {
                        cmbPuesto.SelectedIndex = 3;
                    }
                    txtPassword.Text = datos.Rows[0]["UPassword"].ToString();
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    cargarUsuarios();
                }
                else
                {
                    MessageBox.Show("ID no econtrado");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cargarUsuarios();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIdUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["IDUSUARIO"].Value.ToString();
            txtIdUsuario.Enabled = false;
            cmbPuesto.SelectedValue = dgvUsuarios.Rows[e.RowIndex].Cells["TIPOUSUARIO"].Value.ToString();
            txtIdEmpleado.Text = dgvUsuarios.Rows[e.RowIndex].Cells["IDEMPLEADO"].Value.ToString();
            txtPassword.Text = dgvUsuarios.Rows[e.RowIndex].Cells["UPASSWORD"].Value.ToString();
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

        private void FrmUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
