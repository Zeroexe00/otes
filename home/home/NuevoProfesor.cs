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
    public partial class NuevoProfesor : Form
    {
        private string stringConnection;
        public NuevoProfesor()
        {
            stringConnection = ConfigurationManager.ConnectionStrings["conexionProyecto"].ConnectionString;

            InitializeComponent();
        }

        private void Profesores_Load(object sender, EventArgs e)
        {
           // cargarFormacionPos();
           // cargarHistorial();
        }


        private string digitoVerificador(int rut)
        {
            int digito, contador, multiplo, acumulador;
            string rutDigito;

            contador = 2;
            acumulador = 0;

            while (rut != 0)
            {
                multiplo = (rut % 10) * contador;
                acumulador = acumulador + multiplo;
                rut = rut / 10;
                contador = contador + 1;
                if (contador == 8)
                {
                    contador = 2;
                }
            }

            digito = 11 - (acumulador % 11);
            rutDigito = digito.ToString().Trim();
            if (digito == 10)
            {
                rutDigito = "K";
            }
            if (digito == 11)
            {
                rutDigito = "0";
            }
            return (rutDigito);
        }

        private int convierteRutNumerico(string rut, bool quitarUltimo)
        {
            if (quitarUltimo)
            {
                rut = rut.Substring(0, rut.Length - 1).Replace(".", "").Replace("-", "");
            }
            else
            {
                rut = rut.Replace(".", "").Replace("-", "");
            }
            return Convert.ToInt32(rut);
        }
        public string formateaRut(int rut)
        {
            return rut.ToString("N0") + "-" + digitoVerificador(rut);
        }

        public void formateaRut(TextBox objeto)
        {
            string run = objeto.Text;
            string rut = "";

            if (run.Length > 0)
            {
                int cont = 0;
                run = run.Replace(".", "").Replace("-", "");

                rut = "-" + run.Substring(run.Length - 1);
                for (int i = run.Length - 2; i >= 0; i--)
                {
                    rut = run.Substring(i, 1) + rut;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        rut = "." + rut;
                        cont = 0;
                    }
                }

                objeto.Text = rut;
                objeto.SelectionStart = objeto.Text.Length;
            }
        }

        public bool validaRut(string rut)
        {
            if (!rut.Equals(""))
            {
                string rutFormateado = formateaRut(convierteRutNumerico(rut, true));

                if (rutFormateado.Equals(rut))
                {
                    return true;
                };
            }
            return false;
        }








        private void cargarHistorial()
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    string query = "select  HisCodigo,HisAsignaturaImpartida,HisLugarDesempeño,HisCiudad,HisFechaIngreso FROM TB_HISTORIAL_LABORAL WHERE ProRut="+txtRut+"";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Historial");
                    
                    dgwHistorial.Rows.Clear();
                    foreach (DataRow row in ds.Tables["Historial"].Rows)
                    {
                        DataGridViewButtonCell btnEdit = new DataGridViewButtonCell();
                        DataGridViewButtonCell btnCancel = new DataGridViewButtonCell();


                        btnEdit.Value = " ";
                        btnEdit.UseColumnTextForButtonValue = true;
                        int fila = dgwHistorial.Rows.Add(
                                          row[0],
                                          row[1],
                                          row[2],
                                          row[3],
                                          row[4],
                                          btnEdit,
                                          btnCancel
                                          );
                        dgwHistorial.Rows[fila].Cells[5].Value = " ";
                        dgwHistorial.Rows[fila].Cells[6].Value = " ";


                    }
                }
                catch (SqlException es)
                {
                    MessageBox.Show(
          "Error al conectarse a la base de Datos : Al listar historial en Grilla " + es,
          ".: Sistema OTEC :.",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
          );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           "Error al conectarse a la base de Datos : Al listar historial en Grilla " + ex,
                           ".: Sistema Otec :.",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                }
            }
        }
    

        private void cargarFormacionPos()
        {
            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    string query = "select ProRut,TitCodigo,TitTituloAcademico,TitIntitucion,TitTipo,TitFechaEgreso FROM TB_TITULO";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Formacion");
                    dgwFormacionPos.Rows.Clear();
                    foreach (DataRow row in ds.Tables["Formacion"].Rows)
                    {

                        DataGridViewButtonCell btnEdit = new DataGridViewButtonCell();
                        DataGridViewButtonCell btnCancel = new DataGridViewButtonCell();


                        btnEdit.Value = " ";
                        btnEdit.UseColumnTextForButtonValue = true;
                        int fila = dgwFormacionPos.Rows.Add(
                                          row[0],
                                          row[1],
                                          row[2],
                                          row[3],
                                          row[4],
                                          row[5],
                                          btnEdit,
                                          btnCancel
                                          );
                        dgwHistorial.Rows[fila].Cells[6].Value = " ";
                        dgwHistorial.Rows[fila].Cells[7].Value = " ";


                    }
                }
                catch (SqlException es)
                {
                    MessageBox.Show(
          "Error al conectarse a la base de Datos : Al listar Formacion en Grilla " + es,
          ".: Sistema OTEC :.",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
          );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           "Error al conectarse a la base de Datos : Al listar Formacion en Grilla " + ex,
                           ".: Sistema OTEC :.",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
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
               tcDatosPro.SelectedTab=tabPage2;
            }
           

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (txtRut.Equals("") || txtNombre.Equals("") || txtApellidoMaterno.Equals("") || txtApellidoPaterno.Equals(""))
            {
                MessageBox.Show(
                                "Faltan registros por ingresar en su formulario",
                                ".: Sistema OTECs :.",
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

                      
                            cmd = new SqlCommand("INSERT INTO TB_TITULO (ProRut, TitTituloAcademico, TitIntitucion, TitTipo, TitFechaEgreso)  VALUES ( @rut, @titulo, @tipo, @Intitucion, @Fecha)", conn);

                        cmd.Parameters.AddWithValue("@rut", txtRut.Text);
                        cmd.Parameters.AddWithValue("@titulo", txtTituloPro.Text);
                        cmd.Parameters.AddWithValue("@tipo", cbxTipoTitulo.SelectedValue);
                        cmd.Parameters.AddWithValue("@Intitucion", txtInstitucion.Text);
                        cmd.Parameters.AddWithValue("@Fecha", dtpAñoEgreso.Value);
                        

                        cmd.ExecuteNonQuery();
                       

                    }
                    catch (SqlException eSql)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Alumno " + eSql,
                         ".: Sistema Ventas :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Alumno " + ex,
                         ".: Sistema Ventas :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    finally
                    {
                        conn.Close();
                        cargarFormacionPos();
                    }
                }

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

                        
                            cmd = new SqlCommand("INSERT INTO TB_PERSONA (PerRut, PerNombre, PerApellidoPaterno, PerApellidoMaterno, PerTelefono, PerEmail,PerFechaNacimiento,PerSexo,PerDireccion)  VALUES ( @rut, @nombre, @paterno, @materno, @telefono, @email,@fechanacimiento,@sexo,@direccion)", conn);

                       
                        cmd.Parameters.AddWithValue("@rut", txtRut.Text);
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@paterno", txtApellidoPaterno.Text);
                        cmd.Parameters.AddWithValue("@materno", txtApellidoMaterno.Text);
                        cmd.Parameters.AddWithValue("@fechanacimiento", dtpFechaNacimiento.Value);
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        cmd.Parameters.AddWithValue("@sexo", cbxSexo.SelectedValue);
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmailContacto.Text);
                       

                        cmd.ExecuteNonQuery();
                        limpiarTab1();

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

        private void btnAgregar1_Click(object sender, EventArgs e)
        {

            if (txtAsignatura.Equals("") || txtCiudad.Equals("") || txtLugarDesempeño.Equals("") || dtpAñoIngreso.Equals(""))
            {
                MessageBox.Show(
                                "Faltan registros por ingresar en su formulario",
                                ".: Sistema OTECs :.",
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


                        cmd = new SqlCommand("INSERT INTO TB_HISTORIAL_LABORAL (ProRut, HisAsignaturaImpartida, HisLugarDesempeño, HisCiudad, HisFechaIngreso)  VALUES ( @rut, @HisAsignaturaImpartida, @tipoHisLugarDesempeño @HisCiudad, @HisFechaIngreso)", conn);

                        cmd.Parameters.AddWithValue("@ProRut", txtRut.Text);
                        cmd.Parameters.AddWithValue("@HisAsignaturaImpartida", txtAsignatura.Text);
                        cmd.Parameters.AddWithValue("@HisLugarDesempeño", txtLugarDesempeño.Text);
                        cmd.Parameters.AddWithValue("@HisCiudad", txtCiudad.Text);
                        cmd.Parameters.AddWithValue("@HisFechaIngreso", dtpAñoIngreso.Value);


                        cmd.ExecuteNonQuery();


                    }
                    catch (SqlException eSql)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Historial " + eSql,
                         ".: Sistema OTEC :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                         "Error al conectarse a la base de Datos : Al guardar Historial " + ex,
                         ".: Sistema OTEC :.",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error
                         );
                    }
                    finally
                    {
                        conn.Close();
                        cargarHistorial();
                    }
                }

            }
        }

        private void btnSiguiente1_Click(object sender, EventArgs e)
        {
            if (txtRut.Equals("") || txtNombre.Equals("") || txtApellidoMaterno.Equals("") || txtApellidoPaterno.Equals(""))
            {
                MessageBox.Show(
                                "Faltan registros por ingresar en su formulario",
                                ".: Sistema OTECs :.",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                                );
            }
            else
            {
                tcDatosPro.SelectedTab = tabPage3;
            }
        }



        //metodoslimpiar
        #region
        private void limpiarTab2()
        {
            cbxTipoTitulo.SelectedValue = 0;
            txtTituloPro.Text = " ";
            txtInstitucion.Text = " ";
            dtpAñoEgreso.Value = DateTime.Now;

        }
        private void limpiarTab3()
        {
            txtAsignatura.Text = " ";
            txtLugarDesempeño.Text = " ";
            dtpAñoIngreso.Value = DateTime.Now;
            txtCiudad.Text = " ";
        }
        private void limpiarTab1()
        {
            txtNombre.Text = " ";
            txtRut.Text = " ";
            txtEmailContacto.Text = " ";
            txtDireccion.Text = " ";
            cbxSexo.SelectedValue = 0;

            txtApellidoPaterno.Text = " ";

            txtApellidoMaterno.Text = " ";

            txtTelefono.Text = " ";

            dtpFechaNacimiento.Value = DateTime.Now;


        }
        #endregion


        //eventosBotonLimpiar
        #region
        private void btnClean_Click(object sender, EventArgs e)
        {
            limpiarTab1();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarTab2();
        }
        
        private void btnLimpiar1_Click(object sender, EventArgs e)
        {
            limpiarTab3();

        }
        #endregion

        private void txtRut_KeyUp(object sender, KeyEventArgs e)
        {
            
            formateaRut(txtRut);
        }

        private void Validar(object sender, CancelEventArgs e)
        {
            if (!validaRut(txtRut.Text))
            {
                MessageBox.Show(
                                "Rut ingresado no corresponde"
                                
                                );
                txtRut.Select();
                txtRut.Focus();
            }
        }
    }
}
