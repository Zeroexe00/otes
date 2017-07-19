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
    public partial class ListaProfesores : Form
    {
        private string stringConnection;
        public ListaProfesores()
        {
            stringConnection = ConfigurationManager.ConnectionStrings["conexionProyecto"].ConnectionString;
            InitializeComponent();
        }

        private void formListaPro(object sender, EventArgs e)
        {
            cargarProfes();
        }

        private void cargarProfes()
        {

            using (SqlConnection conn = new SqlConnection(stringConnection))
            {
                try
                {
                    string query = "select ProRut,CONCAT(PerNombre,' ',PerApellidoPaterno,' ',PerApellidoMaterno) as Nombre FROM TB_PERSONA inner join TB_PROFESOR on TB_PROFESOR.ProRut=TB_PERSONA.PerRut ";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();

                    DataSet ds = new DataSet();
                    da.Fill(ds, "Profesores");
                    dgwProfes.Rows.Clear();
                    foreach (DataRow row in ds.Tables["Profesores"].Rows)
                    {
                        DataGridViewButtonCell btnEdit = new DataGridViewButtonCell();
                        DataGridViewButtonCell btnCancel = new DataGridViewButtonCell();


                        btnEdit.Value = " ";
                        btnEdit.UseColumnTextForButtonValue = true;
                        int fila = dgwProfes.Rows.Add(
                                          row[0],
                                          row[1],
                                          row[2],
                                          row[3],
                                          btnEdit,
                                          btnCancel
                                          );
                        dgwProfes.Rows[fila].Cells[5].Value = " ";
                        dgwProfes.Rows[fila].Cells[4].Value = " ";


                    }
                }
                catch (SqlException es)
                {
                    MessageBox.Show(
          "Error al conectarse a la base de Datos : Al listar Profesores en Grilla" + es,
          ".: Sistema OTEC :.",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error
          );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                           "Error al conectarse a la base de Datos : Al listar Profesores en Grilla" + ex,
                           ".: Sistema OTEC :.",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                           );
                }
            }
        }
    }
}
