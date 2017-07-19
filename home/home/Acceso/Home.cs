using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoProfesor pr = new NuevoProfesor();
            pr.MdiParent = this;
            pr.Show();
            

        }

        private void nuevoAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoAlumno na = new NuevoAlumno();
            na.MdiParent = this;
            na.Show();
        }

        private void listaSalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaSalas ls = new ListaSalas();
            ls.MdiParent = this;
            ls.Show();
        }

        private void nuevaSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevaSala ns = new NuevaSala();
            ns.MdiParent = this;
            ns.Show();
        }

        private void nuevoCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCurso nc = new NuevoCurso();
            nc.MdiParent = this;
            nc.Show();
        }

        private void listaProfesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaProfesores lp = new ListaProfesores();
            lp.MdiParent = this;
            lp.Show();
        }

        private void listaCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaCursos lc = new ListaCursos();
            lc.MdiParent = this;
            lc.Show();
        }

        private void listaAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaAlumnos la = new ListaAlumnos();
            la.MdiParent = this;
            la.Show();
        }
    }
}
