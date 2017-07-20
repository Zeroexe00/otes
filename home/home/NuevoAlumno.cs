using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home
{
    public partial class NuevoAlumno : Form
    {
        private string stringConnection;

        public NuevoAlumno()
        {
            stringConnection = ConfigurationManager
               .ConnectionStrings["cnxOTEC"]
               .ConnectionString;
            InitializeComponent();
        }

        private void cargarControlesIniciales(object sender, EventArgs e)
        {
            cargarCurso();
            cargarProfesor();
        }

        private void cargarCurso()
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TB_CURSO.CurCodigo, TB_CURSO.CurNombre FROM TB_CURSO";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Curso");
                    cbxCurso.DisplayMember = "CurNombre";
                    cbxCurso.ValueMember = "CurCodigo";
                    cbxCurso.DataSource = dataSet.Tables["Curso"];
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                                            "Error al conectarse a la base de Datos : Al cargar Curso" + ex,
                                            " Sistema OTEC ",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error
                                            );
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void cargarProfesor()
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TB_PROFESOR.ProCodigo, TB_PROFESOR.ProNombre FROM TB_PROFESOR";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "Profesor");
                    cbxCurso.DisplayMember = "ProNombre";
                    cbxCurso.ValueMember = "ProCodigo";
                    cbxCurso.DataSource = dataSet.Tables["Profesor"];
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(
                                            "Error al conectarse a la base de Datos : Al cargar Profesor" + ex,
                                            " Sistema OTEC ",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error
                                            );
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnHaciaPag_Click(object sender, EventArgs e)
        {

            if (txtRut.Equals("") || txtNombre.Equals("") || txtApellidoMaterno.Equals("") || txtApellidoPaterno.Equals(""))
            {
                MessageBox.Show(
                                "Faltan registros por ingresar en su formulario",
                                ".: Sistema OTEC :.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
            }
            else
            {

                using (SqlConnection conn = new SqlConnection(stringConnection))
                {
                    conn.Open();
                    try
                    {
                        SqlCommand cmd;


                        cmd = new SqlCommand("INSERT INTO TB_PERSONA (PerRut, PerNombre, PerApellidoPaterno, PerApellidoMaterno, PerFechaNacimiento, PerSexo, PerDireccion, PerTelefono, PerEmail)  VALUES ( @rut, @nombre, @paterno, @materno, @fechanacimiento, @sexo, @direccion, @telefono, @email)", conn);


                        cmd.Parameters.AddWithValue("@rut", txtRut.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@paterno", txtApellidoPaterno.Text);
                        cmd.Parameters.AddWithValue("@materno", txtApellidoMaterno.Text);
                        cmd.Parameters.AddWithValue("@fechanacimiento", dtpFechaNacimiento.Value);
                        cmd.Parameters.AddWithValue("@sexo", cbxSexo.SelectedValue);
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);


                        cmd.ExecuteNonQuery();
                    

                    }
                    catch (SqlException eSql)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Profesor " + eSql,
                         ".: Sistema OTEC :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Alumno " + ex,
                         ".: Sistema OTEC :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    finally
                    {
                        conn.Close();

                    }
                }

            }

        }






        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void NuevoAlumno_Load(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbxCurso.Text.Equals("") || txtInstitucion.Text.Equals("") || cbxProfesor.Text.Equals("") || dtpFechaInicio.Text.Equals("") || dtpFechaTermino.Text.Equals("") || txtCosto.Text.Equals(""))
            {
                MessageBox.Show(
                                "Faltan registros por ingresar en su formulario",
                                " Sistema OTEC ",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
            }
            else
            {
                tabControl0.SelectedTab = tabPage3;
            }
        }

        private void btnGuardarCurso_Click(object sender, EventArgs e)
        {
            {
                if (cbxCurso.Text.Equals("") || txtInstitucion.Text.Equals("") || cbxProfesor.Text.Equals("") || dtpFechaInicio.Text.Equals("") || dtpFechaTermino.Text.Equals("") || txtCosto.Text.Equals(""))
                {
                    MessageBox.Show(
                                    "Faltan registros por ingresar en su formulario",
                                    " Sistema OTEC ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                    );
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(stringConnection))

                    {
                        conn.Open();
                        try
                        {
                            SqlCommand cmd;

                            if (btnGuardarCurso.Text == "Guardar")
                            {
                                cmd = new SqlCommand("INSERT INTO TB_ALUMNO (CurCOdigo, AluInstitucion, AluProfesor, AluFechaInicio, AluFechaTermino, AluCosto,AluSence) VALUES( @codigo, @institucion, @profesor, @fechainicio, @fechatermino, @costo, @sence)", conn);


                                cmd.Parameters.AddWithValue("@codigo", cbxCurso.Text);
                                cmd.Parameters.AddWithValue("@institucion", txtInstitucion.Text);
                                cmd.Parameters.AddWithValue("@profesor", cbxProfesor.Text);
                                cmd.Parameters.AddWithValue("@fechainicio", dtpFechaInicio.Text);
                                cmd.Parameters.AddWithValue("@fechatermino", dtpFechaTermino.Value);
                                cmd.Parameters.AddWithValue("@costo", txtCosto.Text);
                                cmd.Parameters.AddWithValue("@sence", cbxSence1.SelectedValue);

                                cmd.ExecuteNonQuery();
                            }
                        }



                        catch (SqlException eSql)
                        {
                            MessageBox.Show(
                             "Error al conectarse a la base de Datos : Al guardar Alumno " + eSql,
                             " Sistema OTEC ",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                             );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                             "Error al conectarse a la base de Datos : Al guardar Alumno " + ex,
                             " Sistema OTEC ",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                             );
                        }
                        finally
                        {
                            conn.Close();
                            
                        }
                    }
                }
            }
        }

        private void btnGuardarSlaboral_Click(object sender, EventArgs e)
        {
            {
                if (cbxSituacionLaboral.Text.Equals("") || txtLugarTrabajo.Text.Equals("") || txtRemuneracion.Text.Equals("") || txtDescuento.Text.Equals("") || cbxModoPago.Text.Equals("") || dtpFechaPago.Text.Equals("")|| cbxSence2.Text.Equals(""))
                {
                    MessageBox.Show(
                                    "Faltan registros por ingresar en su formulario",
                                    " Sistema OTEC ",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                    );
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(stringConnection))

                    {
                        conn.Open();
                        try
                        {
                            SqlCommand cmd;

                            if (btnGuardarSlaboral.Text == "Guardar")
                            {
                                cmd = new SqlCommand("INSERT INTO TB_ALUMNO (AluSituacionLaboral, AluLugarTrabajo, AluRemuneracion, AluDescuento, AluModoPago, AluFechaPago,AluSenceEmpresa) VALUES(@situacuionlaboral, @lugartrabajo, @remuneracion, @descuento, @modopago, @fechapago, @senceempresa)", conn);


                                cmd.Parameters.AddWithValue("@situacuionlaboral", cbxSituacionLaboral.SelectedValue);
                                cmd.Parameters.AddWithValue("@lugartrabajo", txtLugarTrabajo.Text);
                                cmd.Parameters.AddWithValue("@remuneracion", txtRemuneracion.Text);
                                cmd.Parameters.AddWithValue("@descuento", txtDescuento.Text);
                                cmd.Parameters.AddWithValue("@modopago", cbxModoPago.SelectedValue);
                                cmd.Parameters.AddWithValue("@fechapago", dtpFechaPago.Text);
                                cmd.Parameters.AddWithValue("@senceempresa", cbxSence2.SelectedValue);

                                cmd.ExecuteNonQuery();
                            }
                        }



                        catch (SqlException eSql)
                        {
                            MessageBox.Show(
                             "Error al conectarse a la base de Datos : Al guardar Alumno " + eSql,
                             " Sistema OTEC ",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                             );
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                             "Error al conectarse a la base de Datos : Al guardar Alumno " + ex,
                             " Sistema OTEC ",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error
                             );
                        }
                        finally
                        {
                            conn.Close();
                           
                        }
                    }
                }
            }
        }
    }
}
