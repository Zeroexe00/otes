namespace home
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaSalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaSalasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaProfesoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iToolStripMenuItem,
            this.cursosToolStripMenuItem,
            this.alumnosToolStripMenuItem,
            this.salasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(817, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProfesorToolStripMenuItem,
            this.listaProfesoresToolStripMenuItem});
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.iToolStripMenuItem.Text = "Profesores";
            // 
            // nuevoProfesorToolStripMenuItem
            // 
            this.nuevoProfesorToolStripMenuItem.Name = "nuevoProfesorToolStripMenuItem";
            this.nuevoProfesorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.nuevoProfesorToolStripMenuItem.Text = "Nuevo Profesor";
            this.nuevoProfesorToolStripMenuItem.Click += new System.EventHandler(this.nuevoProfesorToolStripMenuItem_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCursoToolStripMenuItem,
            this.listaCursosToolStripMenuItem});
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.cursosToolStripMenuItem.Text = "Cursos";
            // 
            // nuevoCursoToolStripMenuItem
            // 
            this.nuevoCursoToolStripMenuItem.Name = "nuevoCursoToolStripMenuItem";
            this.nuevoCursoToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.nuevoCursoToolStripMenuItem.Text = "Nuevo Curso";
            this.nuevoCursoToolStripMenuItem.Click += new System.EventHandler(this.nuevoCursoToolStripMenuItem_Click);
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoAlumnoToolStripMenuItem,
            this.listaAlumnosToolStripMenuItem});
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // nuevoAlumnoToolStripMenuItem
            // 
            this.nuevoAlumnoToolStripMenuItem.Name = "nuevoAlumnoToolStripMenuItem";
            this.nuevoAlumnoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.nuevoAlumnoToolStripMenuItem.Text = "Nuevo Alumno";
            this.nuevoAlumnoToolStripMenuItem.Click += new System.EventHandler(this.nuevoAlumnoToolStripMenuItem_Click);
            // 
            // salasToolStripMenuItem
            // 
            this.salasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaSalaToolStripMenuItem,
            this.listaSalasToolStripMenuItem});
            this.salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            this.salasToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.salasToolStripMenuItem.Text = "Salas";
            // 
            // nuevaSalaToolStripMenuItem
            // 
            this.nuevaSalaToolStripMenuItem.Name = "nuevaSalaToolStripMenuItem";
            this.nuevaSalaToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.nuevaSalaToolStripMenuItem.Text = "Nueva Sala";
            this.nuevaSalaToolStripMenuItem.Click += new System.EventHandler(this.nuevaSalaToolStripMenuItem_Click);
            // 
            // listaSalasToolStripMenuItem
            // 
            this.listaSalasToolStripMenuItem.Name = "listaSalasToolStripMenuItem";
            this.listaSalasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listaSalasToolStripMenuItem.Text = "Lista de Salas";
            this.listaSalasToolStripMenuItem.Click += new System.EventHandler(this.listaSalasToolStripMenuItem_Click);
            // 
            // listaProfesoresToolStripMenuItem
            // 
            this.listaProfesoresToolStripMenuItem.Name = "listaProfesoresToolStripMenuItem";
            this.listaProfesoresToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.listaProfesoresToolStripMenuItem.Text = "Lista de Profesores";
            this.listaProfesoresToolStripMenuItem.Click += new System.EventHandler(this.listaProfesoresToolStripMenuItem_Click);
            // 
            // listaCursosToolStripMenuItem
            // 
            this.listaCursosToolStripMenuItem.Name = "listaCursosToolStripMenuItem";
            this.listaCursosToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.listaCursosToolStripMenuItem.Text = "Lista de Cursos";
            this.listaCursosToolStripMenuItem.Click += new System.EventHandler(this.listaCursosToolStripMenuItem_Click);
            // 
            // listaAlumnosToolStripMenuItem
            // 
            this.listaAlumnosToolStripMenuItem.Name = "listaAlumnosToolStripMenuItem";
            this.listaAlumnosToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.listaAlumnosToolStripMenuItem.Text = "Lista de Alumnos";
            this.listaAlumnosToolStripMenuItem.Click += new System.EventHandler(this.listaAlumnosToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 404);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTEC";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoProfesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaSalasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaSalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaProfesoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaAlumnosToolStripMenuItem;
    }
}

