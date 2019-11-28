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
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            pantallaInicio();
            cmbEdoCivil.SelectedIndex = 0;
            cargarMunicipios();
            cargarColonias();
            cargarEmpresas();
            cargarPuestos();
            cargarEmpleados();
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
                cmbMunicipio.DisplayMember = "NOMBRE";
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
                cmbNomEmpresa.DataSource = datos;
                cmbNomEmpresa.DisplayMember = "Nombre";
                cmbNomEmpresa.ValueMember = "IdEmpresa";
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
        private void cargarPuestos()
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
                comando.CommandText = "SP_TIPOMPLEADO_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);
                DataRow linea;
                linea = datos.NewRow();
                linea["NOMBRE"] = "[SELECCIONAR]";
                linea["IDTIPOEMPLEADO"] = "-1";
                datos.Rows.InsertAt(linea, 0);
                cmbPuesto.DataSource = datos;
                cmbPuesto.DisplayMember = "Nombre";
                cmbPuesto.ValueMember = "IDTIPOEMPLEADO";
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
        private void cargarEmpleados()
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
                comando.CommandText = "SP_EMPLEADO_CONSULTAR_TODO";
                comando.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                comando.ExecuteNonQuery();
                adaptador.SelectCommand = comando;
                adaptador.Fill(datos);

                dgvEmpleados.DataSource = datos;
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
            OracleCommand cmd = new OracleCommand();
            OracleDataAdapter ad = new OracleDataAdapter();
            DataTable datos = new DataTable();
            try
            {
                txtidemp.Enabled = false;
                con.ConnectionString = "data source=XE;user id=UserPia;password=baseprogra";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Empleados_Buscar";
                cmd.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtidemp.Text));
                cmd.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                ad.SelectCommand = cmd;
                ad.Fill(datos);
                if (datos.Rows.Count > 0)
                {
                    txtnombre.Text = datos.Rows[0]["Nombre"].ToString();
                    txtApellidos.Text = datos.Rows[0]["Apellidos"].ToString();
                    cmbMunicipio.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdMunicipio"].ToString());
                    cargarColonias();
                    cmbColonia.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdColonia"].ToString());
                    txtCalleyNum.Text = datos.Rows[0]["CalleyNo"].ToString();
                    txtCodPostal.Text = datos.Rows[0]["CodPostal"].ToString();
                    dtpFechaNac.Value = DateTime.Parse(datos.Rows[0]["FechaNac"].ToString());
                    txtSalario.Text = datos.Rows[0]["Salario"].ToString();
                    if (datos.Rows[0]["edocivil"].ToString() == "1")
                    {
                        cmbEdoCivil.SelectedIndex = 1;
                    }
                    else if (datos.Rows[0]["edocivil"].ToString() == "2")
                    {
                        cmbEdoCivil.SelectedIndex = 2;
                    }
                    else if (datos.Rows[0]["edocivil"].ToString() == "3")
                    {
                        cmbEdoCivil.SelectedIndex = 3;
                    }
                    else if (datos.Rows[0]["edocivil"].ToString() == "4")
                    {
                        cmbEdoCivil.SelectedIndex = 4;
                    }
                    else if (datos.Rows[0]["edocivil"].ToString() == "5")
                    {
                        cmbEdoCivil.SelectedIndex = 5;
                    }
                    txtCorreo.Text = datos.Rows[0]["CorreoEmpresarial"].ToString();
                    if (datos.Rows[0]["SEXO"].ToString() == "F")
                    {
                        rdbFemenino.Checked = true;
                    }
                    else if (datos.Rows[0]["SEXO"].ToString() == "M")
                    {
                        rdbMasculino.Checked = true;
                    }
                    if (datos.Rows[0]["Turno"].ToString() == "1")
                    {
                        rdbMat.Checked = true;
                    }
                    if (datos.Rows[0]["Turno"].ToString() == "2")
                    {
                        rdbves.Checked = true;
                    }
                    if (datos.Rows[0]["Turno"].ToString() == "3")
                    {
                        rdbNoc.Checked = true;
                    }
                    if (datos.Rows[0]["NACIONALIDAD"].ToString() == "E")
                    {
                        chkExtranjero.Checked = true;
                    }
                    dtpFechaAlta.Value = DateTime.Parse(datos.Rows[0]["FechaIngreso"].ToString());
                    cmbNomEmpresa.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdEmpresa"].ToString());
                    cmbPuesto.SelectedValue = Convert.ToInt64(datos.Rows[0]["IdTipoEmpleado"].ToString());
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnRegistrar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado");
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
                cmd.CommandText = "sp_Empleado_Eliminar";
                cmd.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtidemp.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("El empleado ha sido borrado exitosamente");
                pantallaInicio();
                cargarEmpleados();
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
                cmd.CommandText = "sp_Empleado_Registrar";
                cmd.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtidemp.Text));
                cmd.Parameters.Add("pNombre", txtnombre.Text);
                cmd.Parameters.Add("pApellidos", txtApellidos.Text);
                cmd.Parameters.Add("pIdMunicipio", cmbMunicipio.SelectedValue);
                cmd.Parameters.Add("pIdColonia", cmbColonia.SelectedValue);
                cmd.Parameters.Add("pCalleyNum", txtCalleyNum.Text);
                cmd.Parameters.Add("pCodPostal", Convert.ToInt64(txtCodPostal.Text));
                cmd.Parameters.Add("pFechaNac", dtpFechaNac.Value.Date);
                cmd.Parameters.Add("pSalario", Convert.ToInt64(txtSalario.Text));
                if (cmbEdoCivil.SelectedIndex == 1)//soltero
                {
                    cmd.Parameters.Add("pEdoCivil", "1");
                }
                else if (cmbEdoCivil.SelectedIndex == 2) //casado
                {
                    cmd.Parameters.Add("pEdoCivil", "2");
                }
                else if (cmbEdoCivil.SelectedIndex == 3) //divorciado
                {
                    cmd.Parameters.Add("pEdoCivil", "3");
                }
                else if (cmbEdoCivil.SelectedIndex == 4) //Viudo
                {
                    cmd.Parameters.Add("pEdoCivil", "4");
                }
                else
                {   //union libre
                    cmd.Parameters.Add("pEdoCivil", "5");
                }
                cmd.Parameters.Add("pCorreoEmpresarial", txtCorreo.Text);
                if (rdbFemenino.Checked == true)
                {
                    cmd.Parameters.Add("pSexo", "F");
                }
                else if (rdbMasculino.Checked == true)
                {
                    cmd.Parameters.Add("pSexo", "M");

                }
                if (rdbMat.Checked == true)
                {
                    cmd.Parameters.Add("pTurno", "1");
                }
                if (rdbves.Checked == true)
                {
                    cmd.Parameters.Add("pTurno", "2");
                }
                if (rdbNoc.Checked == true)
                {
                    cmd.Parameters.Add("pTurno", "3");
                }
                if (chkExtranjero.Checked == true)
                {
                    cmd.Parameters.Add("pNacionalidad", "E");
                }
                else
                { 
                    cmd.Parameters.Add("pNacionalidad", "M");
                }
                cmd.Parameters.Add("pFechaIngreso",dtpFechaAlta.Value.Date);
                cmd.Parameters.Add("pIdEmpresa", cmbNomEmpresa.SelectedValue);
                cmd.Parameters.Add("pIdTipoEmpleado", cmbPuesto.SelectedValue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("El empleado ha sido registrado exitosamente");
                pantallaInicio();
                cargarEmpleados();
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
                con.ConnectionString = "data source=xe; user id=UserPia;password=baseprogra";
                con.Open();
                comando.Connection = con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Empleado_Modificar";
                comando.Parameters.Add("pIdEmpleado", Convert.ToInt64(txtidemp.Text));
                comando.Parameters.Add("pNombre", txtnombre.Text);
                comando.Parameters.Add("pApellidos", txtApellidos.Text);
                comando.Parameters.Add("pIdMunicipio", cmbMunicipio.SelectedValue);
                comando.Parameters.Add("pIdColonia", cmbColonia.SelectedValue);
                comando.Parameters.Add("pCalleyNum", txtCalleyNum.Text);
                comando.Parameters.Add("pCodPostal", Convert.ToInt64(txtCodPostal.Text));
                comando.Parameters.Add("pFechaNac", dtpFechaNac.Value.Date);
                comando.Parameters.Add("pSalario", Convert.ToInt64(txtSalario.Text));
                if (cmbEdoCivil.SelectedIndex == 1)//soltero
                {
                    comando.Parameters.Add("pEdoCivil", "1");
                }
                else if (cmbEdoCivil.SelectedIndex == 2) //casado
                {
                    comando.Parameters.Add("pEdoCivil", "2");
                }
                else if (cmbEdoCivil.SelectedIndex == 3) //divorciado
                {
                    comando.Parameters.Add("pEdoCivil", "3");
                }
                else if (cmbEdoCivil.SelectedIndex == 4) //Viudo
                {
                    comando.Parameters.Add("pEdoCivil", "4");
                }
                else
                {   //union libre
                    comando.Parameters.Add("pEdoCivil", "5");
                }
                comando.Parameters.Add("pCorreoEmpresarial", txtCorreo.Text);
                if (rdbFemenino.Checked == true)
                {
                    comando.Parameters.Add("pSexo", "F");
                }
                else
                {
                    if (rdbMasculino.Checked == true)
                    {
                        comando.Parameters.Add("pSexo", "M");
                    }
                }
                if (rdbMat.Checked == true)
                {
                    comando.Parameters.Add("pTurno", "1");
                }
                if (rdbves.Checked == true)
                {
                    comando.Parameters.Add("pTurno", "2");
                }
                if (rdbNoc.Checked == true)
                {
                    comando.Parameters.Add("pTurno", "3");
                }
                if (chkExtranjero.Checked == true)
                {
                    comando.Parameters.Add("pNacionalidad", "E");
                }
                else
                {
                   
                    
                    comando.Parameters.Add("pNacionalidad", "M");
                    
                }
                comando.Parameters.Add("pFechaIngreso", dtpFechaAlta.Value.Date);
                comando.Parameters.Add("pIdEmpresa", cmbNomEmpresa.SelectedValue);
                comando.Parameters.Add("pIdTipoEmpleado", cmbPuesto.SelectedValue);
                comando.ExecuteNonQuery();
                MessageBox.Show("El empleado ha sido modificado exitosamente");
                pantallaInicio();
                cargarEmpleados();
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
            txtApellidos.Clear();
            cmbMunicipio.SelectedIndex = 0;
            cmbColonia.SelectedIndex = 0;
            txtCalleyNum.Clear();
            txtCodPostal.Clear();
            dtpFechaNac.Value = DateTime.Now;
            txtSalario.Clear();
            cmbEdoCivil.SelectedIndex = 0;
            txtCorreo.Clear();
            rdbFemenino.Checked = false;
            rdbMasculino.Checked = false;
            rdbMat.Checked = false;
            rdbves.Checked = false;
            rdbNoc.Checked = false;
            chkExtranjero.Checked = false;
            dtpFechaAlta.Value = DateTime.Now;
            txtidemp.Enabled = true;
            txtidemp.Focus();
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnRegistrar.Enabled = false;
        }

        private void cmbMunicipio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarColonias();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pantallaInicio();
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidemp.Text= dgvEmpleados.Rows[e.RowIndex].Cells["IDEMPLEADO"].Value.ToString();
            txtnombre.Text = dgvEmpleados.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
            txtApellidos.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Apellidos"].Value.ToString();
            cmbMunicipio.SelectedValue = Convert.ToInt64(dgvEmpleados.Rows[e.RowIndex].Cells["IdMunicipio"].Value.ToString());
            cargarColonias();
            cmbColonia.SelectedValue = Convert.ToInt64(dgvEmpleados.Rows[e.RowIndex].Cells["IdColonia"].Value.ToString());
            txtCalleyNum.Text= dgvEmpleados.Rows[e.RowIndex].Cells["CalleyNo"].Value.ToString();
            txtCodPostal.Text = dgvEmpleados.Rows[e.RowIndex].Cells["CODPOSTAL"].Value.ToString();
            dtpFechaNac.Value = DateTime.Parse(dgvEmpleados.Rows[e.RowIndex].Cells["FechaNac"].Value.ToString());
            txtSalario.Text = dgvEmpleados.Rows[e.RowIndex].Cells["Salario"].Value.ToString();
            if (dgvEmpleados.Rows[e.RowIndex].Cells["EdoCivil"].Value.ToString() == "1")
            {
                cmbEdoCivil.SelectedIndex = 1;
            }
            else if (dgvEmpleados.Rows[e.RowIndex].Cells["EdoCivil"].Value.ToString() == "2")
            {
                cmbEdoCivil.SelectedIndex = 2;
            }
            else if (dgvEmpleados.Rows[e.RowIndex].Cells["EdoCivil"].Value.ToString() == "3")
            {
                cmbEdoCivil.SelectedIndex = 3;
            }
            else if (dgvEmpleados.Rows[e.RowIndex].Cells["EdoCivil"].Value.ToString() == "4")
            {
                cmbEdoCivil.SelectedIndex = 4;
            }
            else if (dgvEmpleados.Rows[e.RowIndex].Cells["EdoCivil"].Value.ToString() == "5")
            {
                cmbEdoCivil.SelectedIndex = 5;
            }
            txtCorreo.Text = dgvEmpleados.Rows[e.RowIndex].Cells["CorreoEmpresarial"].Value.ToString();
            if (dgvEmpleados.Rows[e.RowIndex].Cells["Sexo"].Value.ToString() == "F")
            {
                rdbFemenino.Checked = true;
            }
            else if (dgvEmpleados.Rows[e.RowIndex].Cells["Sexo"].Value.ToString() == "M")
            {
                rdbMasculino.Checked = true;
            }
            if (dgvEmpleados.Rows[e.RowIndex].Cells["Turno"].Value.ToString() == "1")
            {
                rdbMat.Checked = true;
            }
            else if (dgvEmpleados.Rows[e.RowIndex].Cells["Turno"].Value.ToString() == "2")
            {
                rdbves.Checked = true;
            }
            else if (dgvEmpleados.Rows[e.RowIndex].Cells["Turno"].Value.ToString() == "3")
            {
                rdbNoc.Checked = true;
            }
            if (dgvEmpleados.Rows[e.RowIndex].Cells["Nacionalidad"].Value.ToString() == "E")
            {
                chkExtranjero.Checked = true;
            }
           
            dtpFechaAlta.Value = DateTime.Parse(dgvEmpleados.Rows[e.RowIndex].Cells["FechaIngreso"].Value.ToString());
            cmbNomEmpresa.SelectedValue = Convert.ToInt64(dgvEmpleados.Rows[e.RowIndex].Cells["IdEmpresa"].Value.ToString());
            cmbPuesto.SelectedValue = Convert.ToInt64(dgvEmpleados.Rows[e.RowIndex].Cells["IdTipoEmpleado"].Value.ToString());
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

        private void FrmEmpleados_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
