namespace SFPresentation.Formularios
{
    partial class Layout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            linkCerrarSesion = new LinkLabel();
            lblRol = new Label();
            lblUsuario = new Label();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            msMenu = new MenuStrip();
            mnVentas = new ToolStripMenuItem();
            smNuevo = new ToolStripMenuItem();
            smHistorial = new ToolStripMenuItem();
            mnInventario = new ToolStripMenuItem();
            smProductos = new ToolStripMenuItem();
            smCategorias = new ToolStripMenuItem();
            mnReportes = new ToolStripMenuItem();
            smVentas = new ToolStripMenuItem();
            mnUsuarios = new ToolStripMenuItem();
            mnConfiguracion = new ToolStripMenuItem();
            panelMain = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            msMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(58, 49, 69);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(919, 91);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(linkCerrarSesion);
            panel3.Controls.Add(lblRol);
            panel3.Controls.Add(lblUsuario);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(919, 91);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(360, 20);
            label1.Name = "label1";
            label1.Size = new Size(291, 45);
            label1.TabIndex = 3;
            label1.Text = "Sistema de Control";
            // 
            // linkCerrarSesion
            // 
            linkCerrarSesion.AutoSize = true;
            linkCerrarSesion.LinkColor = Color.White;
            linkCerrarSesion.Location = new Point(843, 62);
            linkCerrarSesion.Name = "linkCerrarSesion";
            linkCerrarSesion.Size = new Size(76, 15);
            linkCerrarSesion.TabIndex = 2;
            linkCerrarSesion.TabStop = true;
            linkCerrarSesion.Text = "Cerrar Sesion";
            linkCerrarSesion.LinkClicked += linkCerrarSesion_LinkClicked;
            // 
            // lblRol
            // 
            lblRol.Location = new Point(707, 34);
            lblRol.Name = "lblRol";
            lblRol.RightToLeft = RightToLeft.Yes;
            lblRol.Size = new Size(212, 15);
            lblRol.TabIndex = 1;
            lblRol.Text = "Rol";
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(707, 9);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.RightToLeft = RightToLeft.Yes;
            lblUsuario.Size = new Size(212, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(58, 49, 69);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(msMenu);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 91);
            panel2.Name = "panel2";
            panel2.Size = new Size(155, 407);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo_Empresa_Mia;
            pictureBox1.Location = new Point(0, 259);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 148);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // msMenu
            // 
            msMenu.BackColor = Color.FromArgb(58, 49, 69);
            msMenu.Items.AddRange(new ToolStripItem[] { mnVentas, mnInventario, mnReportes, mnUsuarios, mnConfiguracion });
            msMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            msMenu.Location = new Point(0, 0);
            msMenu.Name = "msMenu";
            msMenu.Size = new Size(155, 275);
            msMenu.TabIndex = 0;
            msMenu.Text = "menuStrip1";
            // 
            // mnVentas
            // 
            mnVentas.AutoSize = false;
            mnVentas.DropDownItems.AddRange(new ToolStripItem[] { smNuevo, smHistorial });
            mnVentas.ForeColor = Color.White;
            mnVentas.Name = "mnVentas";
            mnVentas.Padding = new Padding(0, 2, 0, 2);
            mnVentas.Size = new Size(148, 50);
            mnVentas.Tag = "ventas";
            mnVentas.Text = "Ventas >";
            // 
            // smNuevo
            // 
            smNuevo.AutoSize = false;
            smNuevo.BackColor = Color.White;
            smNuevo.Name = "smNuevo";
            smNuevo.Padding = new Padding(0, 2, 0, 2);
            smNuevo.Size = new Size(180, 30);
            smNuevo.Tag = "nuevo";
            smNuevo.Text = "Nuevo";
            smNuevo.Click += smNuevo_Click;
            // 
            // smHistorial
            // 
            smHistorial.AutoSize = false;
            smHistorial.BackColor = Color.White;
            smHistorial.Name = "smHistorial";
            smHistorial.Padding = new Padding(0, 2, 0, 2);
            smHistorial.Size = new Size(180, 30);
            smHistorial.Tag = "historial";
            smHistorial.Text = "Historial";
            smHistorial.Click += smHistorial_Click;
            // 
            // mnInventario
            // 
            mnInventario.AutoSize = false;
            mnInventario.DropDownItems.AddRange(new ToolStripItem[] { smProductos, smCategorias });
            mnInventario.ForeColor = Color.White;
            mnInventario.Name = "mnInventario";
            mnInventario.Size = new Size(148, 50);
            mnInventario.Tag = "inventario";
            mnInventario.Text = "Inventario >";
            // 
            // smProductos
            // 
            smProductos.AutoSize = false;
            smProductos.Name = "smProductos";
            smProductos.Padding = new Padding(0, 2, 0, 2);
            smProductos.Size = new Size(180, 30);
            smProductos.Tag = "productos";
            smProductos.Text = "Productos";
            smProductos.Click += smProductos_Click;
            // 
            // smCategorias
            // 
            smCategorias.AutoSize = false;
            smCategorias.Name = "smCategorias";
            smCategorias.Padding = new Padding(0, 2, 0, 2);
            smCategorias.Size = new Size(180, 30);
            smCategorias.Tag = "categorias";
            smCategorias.Text = "Categorias";
            smCategorias.Click += smCategorias_Click;
            // 
            // mnReportes
            // 
            mnReportes.AutoSize = false;
            mnReportes.DropDownItems.AddRange(new ToolStripItem[] { smVentas });
            mnReportes.ForeColor = Color.White;
            mnReportes.Name = "mnReportes";
            mnReportes.Size = new Size(148, 50);
            mnReportes.Tag = "reportes";
            mnReportes.Text = "Reportes >";
            // 
            // smVentas
            // 
            smVentas.AutoSize = false;
            smVentas.Name = "smVentas";
            smVentas.Padding = new Padding(0, 2, 0, 2);
            smVentas.Size = new Size(180, 30);
            smVentas.Tag = "ventas";
            smVentas.Text = "Ventas";
            smVentas.Click += smVentas_Click;
            // 
            // mnUsuarios
            // 
            mnUsuarios.AutoSize = false;
            mnUsuarios.ForeColor = Color.White;
            mnUsuarios.Name = "mnUsuarios";
            mnUsuarios.Size = new Size(148, 50);
            mnUsuarios.Tag = "usuarios";
            mnUsuarios.Text = "Usuarios";
            mnUsuarios.Click += mnUsuarios_Click;
            // 
            // mnConfiguracion
            // 
            mnConfiguracion.AutoSize = false;
            mnConfiguracion.ForeColor = Color.White;
            mnConfiguracion.Name = "mnConfiguracion";
            mnConfiguracion.Size = new Size(148, 50);
            mnConfiguracion.Tag = "configuracion";
            mnConfiguracion.Text = "Configuracion";
            mnConfiguracion.Click += mnConfiguracion_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(155, 91);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(764, 407);
            panelMain.TabIndex = 2;
            // 
            // Layout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(919, 498);
            Controls.Add(panelMain);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.White;
            MainMenuStrip = msMenu;
            MaximizeBox = false;
            MaximumSize = new Size(935, 537);
            MinimizeBox = false;
            MinimumSize = new Size(935, 537);
            Name = "Layout";
            Text = "Layout";
            Load += Layout_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private MenuStrip msMenu;
        private ToolStripMenuItem mnVentas;
        private ToolStripMenuItem mnInventario;
        private ToolStripMenuItem mnReportes;
        private ToolStripMenuItem mnUsuarios;
        private ToolStripMenuItem mnConfiguracion;
        private ToolStripMenuItem smNuevo;
        private ToolStripMenuItem smHistorial;
        private ToolStripMenuItem smProductos;
        private ToolStripMenuItem smCategorias;
        private ToolStripMenuItem smVentas;
        private Label lblRol;
        private Label lblUsuario;
        private PictureBox pictureBox1;
        private Label label1;
        private LinkLabel linkCerrarSesion;
        private Panel panelMain;
    }
}