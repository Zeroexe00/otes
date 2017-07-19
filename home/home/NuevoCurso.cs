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
    public partial class NuevoCurso : Form
    {
        private string stringConnection;
        public NuevoCurso()
        {
            stringConnection = ConfigurationManager.ConnectionStrings["conexionProyecto"].ConnectionString;
            InitializeComponent();
        }

        private void NuevoCursoCarga(object sender, EventArgs e)
        {

        }


        //siguientebtn
        #region
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            tbcCurso.SelectedTab = tabPage2;
        }

        private void btnSiguiente1_Click(object sender, EventArgs e)
        {
            tbcCurso.SelectedTab = tabPage3;
        }


        #endregion

        private void btnAgrega_Click(object sender, EventArgs e)
        {
            if (txtNombreCurso.Equals("") || txtDocenteColaborador.Equals("") || txtCosto.Equals("") || txtProfe.Equals(""))
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
                                               
                            cmd = new SqlCommand("INSERT INTO TB_HORARIO (AluRut, AluNombre, AluApellidoPaterno, AluApellidoMaterno, ApoRut, CurCodigo)  VALUES ( @asignatura, @profesor, @jornada, @dias, @horainicio, @horafinaliza,@sala)", conn);

                        
                        cmd.Parameters.AddWithValue("@asignatura", txtAsignatura.Text);
                        cmd.Parameters.AddWithValue("@profesor", txtProfe.Text);
                        cmd.Parameters.AddWithValue("@jornada", txtJornada.Text);
                        cmd.Parameters.AddWithValue("@dias", txtDias.Text);
                        cmd.Parameters.AddWithValue("@horainicio", dtpHoraInicio.Value);
                        cmd.Parameters.AddWithValue("@horafinaliza", dtpHoraFinaliza.Value);
                        cmd.Parameters.AddWithValue("@sala", txtSala.Text);
                       

                        cmd.ExecuteNonQuery();

                    }
                    catch (SqlException eSql)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Curso " + eSql,
                         ".: Sistema OTEC :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Curso " + ex,
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
        //limpiartabs
        #region
        private void limpiarTab1()
        {
            txtNombreCurso.Text = "";
            
            txtCosto.Text = "";
            txtJornada.Text = "";
            txtNombreDocente.Text = "";
            txtDocenteColaborador.Text = "";
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaTermino.Value = DateTime.Now;
        }
        private void btnLimpia_Click(object sender, EventArgs e)
        {
            limpiarTab1();
        }
        private void limpiarTab2()
        {
            txtAsignatura.Text = "";
            txtProfe.Text = "";
            txtJorna.Text = "";
            txtDias.Text = "";
            dtpHoraFinaliza.Value = DateTime.Now;
            dtpHoraInicio.Value = DateTime.Now;
            txtSala.Text = "";
        }

        private void btnLimpia1_Click(object sender, EventArgs e)
        {
            limpiarTab2();
        }
        private void limpiarTab3()
        {
            txtObjEspecificos.Text = "";
            txtObjetivoGeneral.Text = "";
        }

        private void btnLimpia2_Click(object sender, EventArgs e)
        {
            limpiarTab3();
        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtNombreCurso.Equals("") || txtDocenteColaborador.Equals("") || txtCosto.Equals("") || txtProfe.Equals(""))
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

                        cmd = new SqlCommand("INSERT INTO TB_CURSO (PrmCodigo, CurNombre, CurDescripcion, CurProfeJefe, CurProfeColaborador, CurModalidad,CurSence,CurCupo)  VALUES ( @promocion, @curso, @descripcion, @profesor, @docentecolabora, @modalidad,@sence,@cupo)", conn);

                        cmd.Parameters.AddWithValue("@promocion", txtPromocion.Text);

                        cmd.Parameters.AddWithValue("@curso", txtNombreCurso.Text);
                        cmd.Parameters.AddWithValue("@profesor", txtNombreDocente.Text);
                        cmd.Parameters.AddWithValue("@costo", txtCosto.Text);
                        cmd.Parameters.AddWithValue("@jornada", txtJornada.Text);
                        cmd.Parameters.AddWithValue("@descripcion", txtObjetivoGeneral.Text);

                        cmd.Parameters.AddWithValue("@modalidad", cbxModalidad.SelectedValue);
                        cmd.Parameters.AddWithValue("@docentecolabora", txtDocenteColaborador.Text);
                        cmd.Parameters.AddWithValue("@sence", cbxSence.SelectedValue);
                        cmd.Parameters.AddWithValue("@cupo", txtCupoAlumno.Text);

                        
                        cmd.ExecuteNonQuery();


                    }
                    catch (SqlException eSql)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Curso " + eSql,
                         ".: Sistema OTEC :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Curso " + ex,
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
        private void cargaCurso()
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    string query = "SELECT HorAsignatura,HorProfesor,HorJornada,HorDias,HorHoraInicio,HorHoraFinaliza FROM TB_HORARIO";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Horario");
                    dgwHorario.Rows.Clear();
                    foreach (DataRow row in ds.Tables["Horario"].Rows)
                    {
                        


                        
                        int fila = dgwHorario.Rows.Add(
                                          row[0],
                                          row[1],
                                          row[2],
                                          row[3],
                                          row[4],
                                          row[5]
                                          
                                          );
                        


                    }
                }
                catch (SqlException es)
                {
                    MessageBox.Show(
          "Error al conectarse a la base de Datos : Al listar Alumno en Grilla" + es,
          ".: Sistema Alumnos :.",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
          );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           "Error al conectarse a la base de Datos : Al listar Alumno en Grilla" + ex,
                           ".: Sistema Alumnos :.",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                }
            }
        }


    }

}
