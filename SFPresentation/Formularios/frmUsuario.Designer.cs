namespace SFPresentation.Formularios
{
    partial class frmUsuario
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
            label1 = new Label();
            label6 = new Label();
            btnGuardarEditar = new Button();
            btnVolverEditar = new Button();
            btnGuardarNuevo = new Button();
            btnVolverNuevo = new Button();
            cbbRolNuevo = new ComboBox();
            label3 = new Label();
            cbbHabilitado = new ComboBox();
            tabEditar = new TabPage();
            txbNombreUsuarioEditar = new TextBox();
            label4 = new Label();
            txbCorreoEditar = new TextBox();
            label5 = new Label();
            cbbRolEditar = new ComboBox();
            label9 = new Label();
            label10 = new Label();
            txbNombreCompletoEditar = new TextBox();
            txbNombreCompletoNuevo = new TextBox();
            tabNuevo = new TabPage();
            txbNombreUsuarioNuevo = new TextBox();
            label8 = new Label();
            txbCorreoNuevo = new TextBox();
            label7 = new Label();
            label2 = new Label();
            dgvUsuarios = new DataGridView();
            btnBuscar = new Button();
            txbBuscar = new TextBox();
            btnNuevoLista = new Button();
            tabLista = new TabPage();
            tabControlMain = new TabControl();
            tabEditar.SuspendLayout();
            tabNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tabLista.SuspendLayout();
            tabControlMain.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(16, 17);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 3;
            label1.Text = "Usuario";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(9, 212);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 12;
            label6.Text = "Habilitado:";
            // 
            // btnGuardarEditar
            // 
            btnGuardarEditar.BackColor = Color.White;
            btnGuardarEditar.Cursor = Cursors.Hand;
            btnGuardarEditar.FlatStyle = FlatStyle.Flat;
            btnGuardarEditar.ForeColor = Color.FromArgb(30, 90, 195);
            btnGuardarEditar.Location = new Point(651, 284);
            btnGuardarEditar.Name = "btnGuardarEditar";
            btnGuardarEditar.Size = new Size(75, 23);
            btnGuardarEditar.TabIndex = 11;
            btnGuardarEditar.Text = "Guardar";
            btnGuardarEditar.UseVisualStyleBackColor = false;
            btnGuardarEditar.Click += btnGuardarEditar_Click;
            // 
            // btnVolverEditar
            // 
            btnVolverEditar.BackColor = Color.White;
            btnVolverEditar.Cursor = Cursors.Hand;
            btnVolverEditar.FlatStyle = FlatStyle.Flat;
            btnVolverEditar.ForeColor = Color.Black;
            btnVolverEditar.Location = new Point(6, 284);
            btnVolverEditar.Name = "btnVolverEditar";
            btnVolverEditar.Size = new Size(75, 23);
            btnVolverEditar.TabIndex = 10;
            btnVolverEditar.Text = "Volver";
            btnVolverEditar.UseVisualStyleBackColor = false;
            btnVolverEditar.Click += btnVolverEditar_Click;
            // 
            // btnGuardarNuevo
            // 
            btnGuardarNuevo.BackColor = Color.White;
            btnGuardarNuevo.Cursor = Cursors.Hand;
            btnGuardarNuevo.FlatStyle = FlatStyle.Flat;
            btnGuardarNuevo.ForeColor = Color.FromArgb(30, 90, 195);
            btnGuardarNuevo.Location = new Point(651, 287);
            btnGuardarNuevo.Name = "btnGuardarNuevo";
            btnGuardarNuevo.Size = new Size(75, 23);
            btnGuardarNuevo.TabIndex = 5;
            btnGuardarNuevo.Text = "Guardar";
            btnGuardarNuevo.UseVisualStyleBackColor = false;
            btnGuardarNuevo.Click += btnGuardarNuevo_Click;
            // 
            // btnVolverNuevo
            // 
            btnVolverNuevo.BackColor = Color.White;
            btnVolverNuevo.Cursor = Cursors.Hand;
            btnVolverNuevo.FlatStyle = FlatStyle.Flat;
            btnVolverNuevo.ForeColor = Color.Black;
            btnVolverNuevo.Location = new Point(6, 287);
            btnVolverNuevo.Name = "btnVolverNuevo";
            btnVolverNuevo.Size = new Size(75, 23);
            btnVolverNuevo.TabIndex = 4;
            btnVolverNuevo.Text = "Volver";
            btnVolverNuevo.UseVisualStyleBackColor = false;
            btnVolverNuevo.Click += btnVolverNuevo_Click;
            // 
            // cbbRolNuevo
            // 
            cbbRolNuevo.Cursor = Cursors.Hand;
            cbbRolNuevo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbRolNuevo.FormattingEnabled = true;
            cbbRolNuevo.Location = new Point(6, 22);
            cbbRolNuevo.Name = "cbbRolNuevo";
            cbbRolNuevo.Size = new Size(720, 23);
            cbbRolNuevo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(9, 7);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 2;
            label3.Text = "Rol:";
            // 
            // cbbHabilitado
            // 
            cbbHabilitado.Cursor = Cursors.Hand;
            cbbHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbHabilitado.FormattingEnabled = true;
            cbbHabilitado.Location = new Point(6, 227);
            cbbHabilitado.Name = "cbbHabilitado";
            cbbHabilitado.Size = new Size(720, 23);
            cbbHabilitado.TabIndex = 13;
            // 
            // tabEditar
            // 
            tabEditar.Controls.Add(txbNombreUsuarioEditar);
            tabEditar.Controls.Add(cbbHabilitado);
            tabEditar.Controls.Add(label4);
            tabEditar.Controls.Add(label6);
            tabEditar.Controls.Add(txbCorreoEditar);
            tabEditar.Controls.Add(btnGuardarEditar);
            tabEditar.Controls.Add(label5);
            tabEditar.Controls.Add(btnVolverEditar);
            tabEditar.Controls.Add(cbbRolEditar);
            tabEditar.Controls.Add(label9);
            tabEditar.Controls.Add(label10);
            tabEditar.Controls.Add(txbNombreCompletoEditar);
            tabEditar.Location = new Point(4, 24);
            tabEditar.Name = "tabEditar";
            tabEditar.Padding = new Padding(3);
            tabEditar.Size = new Size(732, 316);
            tabEditar.TabIndex = 2;
            tabEditar.Text = "Editar";
            tabEditar.UseVisualStyleBackColor = true;
            // 
            // txbNombreUsuarioEditar
            // 
            txbNombreUsuarioEditar.Location = new Point(6, 175);
            txbNombreUsuarioEditar.Name = "txbNombreUsuarioEditar";
            txbNombreUsuarioEditar.Size = new Size(720, 23);
            txbNombreUsuarioEditar.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(9, 160);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 16;
            label4.Text = "Nombre Usuario:";
            // 
            // txbCorreoEditar
            // 
            txbCorreoEditar.Location = new Point(6, 119);
            txbCorreoEditar.Name = "txbCorreoEditar";
            txbCorreoEditar.Size = new Size(720, 23);
            txbCorreoEditar.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(9, 104);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 14;
            label5.Text = "Correo:";
            // 
            // cbbRolEditar
            // 
            cbbRolEditar.Cursor = Cursors.Hand;
            cbbRolEditar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbRolEditar.FormattingEnabled = true;
            cbbRolEditar.Location = new Point(6, 18);
            cbbRolEditar.Name = "cbbRolEditar";
            cbbRolEditar.Size = new Size(720, 23);
            cbbRolEditar.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(9, 3);
            label9.Name = "label9";
            label9.Size = new Size(27, 15);
            label9.TabIndex = 12;
            label9.Text = "Rol:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(9, 56);
            label10.Name = "label10";
            label10.Size = new Size(110, 15);
            label10.TabIndex = 10;
            label10.Text = "Nombre Completo:";
            // 
            // txbNombreCompletoEditar
            // 
            txbNombreCompletoEditar.Location = new Point(6, 71);
            txbNombreCompletoEditar.Name = "txbNombreCompletoEditar";
            txbNombreCompletoEditar.Size = new Size(720, 23);
            txbNombreCompletoEditar.TabIndex = 11;
            // 
            // txbNombreCompletoNuevo
            // 
            txbNombreCompletoNuevo.Location = new Point(6, 75);
            txbNombreCompletoNuevo.Name = "txbNombreCompletoNuevo";
            txbNombreCompletoNuevo.Size = new Size(720, 23);
            txbNombreCompletoNuevo.TabIndex = 1;
            // 
            // tabNuevo
            // 
            tabNuevo.Controls.Add(txbNombreUsuarioNuevo);
            tabNuevo.Controls.Add(label8);
            tabNuevo.Controls.Add(txbCorreoNuevo);
            tabNuevo.Controls.Add(label7);
            tabNuevo.Controls.Add(btnGuardarNuevo);
            tabNuevo.Controls.Add(btnVolverNuevo);
            tabNuevo.Controls.Add(cbbRolNuevo);
            tabNuevo.Controls.Add(label3);
            tabNuevo.Controls.Add(txbNombreCompletoNuevo);
            tabNuevo.Controls.Add(label2);
            tabNuevo.Location = new Point(4, 24);
            tabNuevo.Name = "tabNuevo";
            tabNuevo.Padding = new Padding(3);
            tabNuevo.Size = new Size(732, 316);
            tabNuevo.TabIndex = 1;
            tabNuevo.Text = "Nuevo";
            tabNuevo.UseVisualStyleBackColor = true;
            // 
            // txbNombreUsuarioNuevo
            // 
            txbNombreUsuarioNuevo.Location = new Point(6, 179);
            txbNombreUsuarioNuevo.Name = "txbNombreUsuarioNuevo";
            txbNombreUsuarioNuevo.Size = new Size(720, 23);
            txbNombreUsuarioNuevo.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(9, 164);
            label8.Name = "label8";
            label8.Size = new Size(97, 15);
            label8.TabIndex = 8;
            label8.Text = "Nombre Usuario:";
            // 
            // txbCorreoNuevo
            // 
            txbCorreoNuevo.Location = new Point(6, 123);
            txbCorreoNuevo.Name = "txbCorreoNuevo";
            txbCorreoNuevo.Size = new Size(720, 23);
            txbCorreoNuevo.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(9, 108);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 6;
            label7.Text = "Correo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(9, 60);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 0;
            label2.Text = "Nombre Completo:";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(6, 35);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(720, 275);
            dgvUsuarios.TabIndex = 3;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.Black;
            btnBuscar.Location = new Point(651, 7);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txbBuscar
            // 
            txbBuscar.Location = new Point(437, 7);
            txbBuscar.Name = "txbBuscar";
            txbBuscar.Size = new Size(194, 23);
            txbBuscar.TabIndex = 1;
            // 
            // btnNuevoLista
            // 
            btnNuevoLista.BackColor = Color.White;
            btnNuevoLista.Cursor = Cursors.Hand;
            btnNuevoLista.FlatStyle = FlatStyle.Flat;
            btnNuevoLista.ForeColor = Color.Black;
            btnNuevoLista.Location = new Point(6, 6);
            btnNuevoLista.Name = "btnNuevoLista";
            btnNuevoLista.Size = new Size(75, 23);
            btnNuevoLista.TabIndex = 0;
            btnNuevoLista.Text = "Nuevo";
            btnNuevoLista.UseVisualStyleBackColor = false;
            btnNuevoLista.Click += btnNuevoLista_Click;
            // 
            // tabLista
            // 
            tabLista.Controls.Add(dgvUsuarios);
            tabLista.Controls.Add(btnBuscar);
            tabLista.Controls.Add(txbBuscar);
            tabLista.Controls.Add(btnNuevoLista);
            tabLista.Location = new Point(4, 24);
            tabLista.Name = "tabLista";
            tabLista.Padding = new Padding(3);
            tabLista.Size = new Size(732, 316);
            tabLista.TabIndex = 0;
            tabLista.Text = "Lista";
            tabLista.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabLista);
            tabControlMain.Controls.Add(tabNuevo);
            tabControlMain.Controls.Add(tabEditar);
            tabControlMain.ItemSize = new Size(80, 20);
            tabControlMain.Location = new Point(12, 45);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(740, 344);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 2;
            // 
            // frmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 407);
            Controls.Add(label1);
            Controls.Add(tabControlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmUsuario";
            Load += frmUsuario_Load;
            tabEditar.ResumeLayout(false);
            tabEditar.PerformLayout();
            tabNuevo.ResumeLayout(false);
            tabNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tabLista.ResumeLayout(false);
            tabLista.PerformLayout();
            tabControlMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label6;
        private Button btnGuardarEditar;
        private Button btnVolverEditar;
        private Button btnGuardarNuevo;
        private Button btnVolverNuevo;
        private ComboBox cbbRolNuevo;
        private Label label3;
        private ComboBox cbbHabilitado;
        private TabPage tabEditar;
        private TextBox txbNombreCompletoNuevo;
        private TabPage tabNuevo;
        private Label label2;
        private DataGridView dgvUsuarios;
        private Button btnBuscar;
        private TextBox txbBuscar;
        private Button btnNuevoLista;
        private TabPage tabLista;
        private TabControl tabControlMain;
        private TextBox txbNombreUsuarioNuevo;
        private Label label8;
        private TextBox txbCorreoNuevo;
        private Label label7;
        private TextBox txbNombreUsuarioEditar;
        private Label label4;
        private TextBox txbCorreoEditar;
        private Label label5;
        private ComboBox cbbRolEditar;
        private Label label9;
        private Label label10;
        private TextBox txbNombreCompletoEditar;
    }
}