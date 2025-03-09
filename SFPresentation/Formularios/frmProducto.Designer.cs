namespace SFPresentation.Formularios
{
    partial class frmProducto
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
            tabEditar = new TabPage();
            label4 = new Label();
            txbCantidadEditar = new NumericUpDown();
            txbPrecioVentaEditar = new TextBox();
            txbPrecioCompraEditar = new TextBox();
            txbDescripcionEditar = new TextBox();
            txbCodigoEditar = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label11 = new Label();
            cbbCategoriaEditar = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            cbbHabilitado = new ComboBox();
            label14 = new Label();
            btnGuardarEditar = new Button();
            btnVolverEditar = new Button();
            tabNuevo = new TabPage();
            label10 = new Label();
            txbCantidadNuevo = new NumericUpDown();
            txbPrecioVentaNuevo = new TextBox();
            txbPrecioCompraNuevo = new TextBox();
            txbDescripcionNuevo = new TextBox();
            txbCodigoNuevo = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            btnGuardarNuevo = new Button();
            btnVolverNuevo = new Button();
            cbbCategoriaNuevo = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            tabLista = new TabPage();
            dgvProductos = new DataGridView();
            btnBuscar = new Button();
            txbBuscar = new TextBox();
            btnNuevoLista = new Button();
            tabControlMain = new TabControl();
            tabEditar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadEditar).BeginInit();
            tabNuevo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadNuevo).BeginInit();
            tabLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
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
            label1.Size = new Size(120, 15);
            label1.TabIndex = 3;
            label1.Text = "Inventario / Producto";
            // 
            // tabEditar
            // 
            tabEditar.Controls.Add(label4);
            tabEditar.Controls.Add(txbCantidadEditar);
            tabEditar.Controls.Add(txbPrecioVentaEditar);
            tabEditar.Controls.Add(txbPrecioCompraEditar);
            tabEditar.Controls.Add(txbDescripcionEditar);
            tabEditar.Controls.Add(txbCodigoEditar);
            tabEditar.Controls.Add(label5);
            tabEditar.Controls.Add(label6);
            tabEditar.Controls.Add(label11);
            tabEditar.Controls.Add(cbbCategoriaEditar);
            tabEditar.Controls.Add(label12);
            tabEditar.Controls.Add(label13);
            tabEditar.Controls.Add(cbbHabilitado);
            tabEditar.Controls.Add(label14);
            tabEditar.Controls.Add(btnGuardarEditar);
            tabEditar.Controls.Add(btnVolverEditar);
            tabEditar.Location = new Point(4, 24);
            tabEditar.Name = "tabEditar";
            tabEditar.Padding = new Padding(3);
            tabEditar.Size = new Size(732, 316);
            tabEditar.TabIndex = 2;
            tabEditar.Text = "Editar";
            tabEditar.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(432, 6);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 39;
            label4.Text = "Cantidad:";
            // 
            // txbCantidadEditar
            // 
            txbCantidadEditar.Location = new Point(432, 22);
            txbCantidadEditar.Name = "txbCantidadEditar";
            txbCantidadEditar.Size = new Size(294, 23);
            txbCantidadEditar.TabIndex = 38;
            // 
            // txbPrecioVentaEditar
            // 
            txbPrecioVentaEditar.Location = new Point(6, 239);
            txbPrecioVentaEditar.Name = "txbPrecioVentaEditar";
            txbPrecioVentaEditar.Size = new Size(364, 23);
            txbPrecioVentaEditar.TabIndex = 37;
            // 
            // txbPrecioCompraEditar
            // 
            txbPrecioCompraEditar.Location = new Point(6, 184);
            txbPrecioCompraEditar.Name = "txbPrecioCompraEditar";
            txbPrecioCompraEditar.Size = new Size(364, 23);
            txbPrecioCompraEditar.TabIndex = 35;
            // 
            // txbDescripcionEditar
            // 
            txbDescripcionEditar.Location = new Point(6, 129);
            txbDescripcionEditar.Name = "txbDescripcionEditar";
            txbDescripcionEditar.Size = new Size(364, 23);
            txbDescripcionEditar.TabIndex = 33;
            // 
            // txbCodigoEditar
            // 
            txbCodigoEditar.Location = new Point(6, 74);
            txbCodigoEditar.Name = "txbCodigoEditar";
            txbCodigoEditar.Size = new Size(364, 23);
            txbCodigoEditar.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.ForeColor = Color.Black;
            label5.Location = new Point(9, 224);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 36;
            label5.Text = "Precio Venta:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.ForeColor = Color.Black;
            label6.Location = new Point(9, 169);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 34;
            label6.Text = "Precio Compra:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(9, 114);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 32;
            label11.Text = "Descripcion";
            // 
            // cbbCategoriaEditar
            // 
            cbbCategoriaEditar.Cursor = Cursors.Hand;
            cbbCategoriaEditar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCategoriaEditar.FormattingEnabled = true;
            cbbCategoriaEditar.Location = new Point(6, 21);
            cbbCategoriaEditar.Name = "cbbCategoriaEditar";
            cbbCategoriaEditar.Size = new Size(364, 23);
            cbbCategoriaEditar.TabIndex = 31;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.ForeColor = Color.Black;
            label12.Location = new Point(9, 6);
            label12.Name = "label12";
            label12.Size = new Size(61, 15);
            label12.TabIndex = 30;
            label12.Text = "Categoria:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.White;
            label13.ForeColor = Color.Black;
            label13.Location = new Point(9, 59);
            label13.Name = "label13";
            label13.Size = new Size(49, 15);
            label13.TabIndex = 28;
            label13.Text = "Codigo:";
            // 
            // cbbHabilitado
            // 
            cbbHabilitado.Cursor = Cursors.Hand;
            cbbHabilitado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbHabilitado.FormattingEnabled = true;
            cbbHabilitado.Location = new Point(432, 74);
            cbbHabilitado.Name = "cbbHabilitado";
            cbbHabilitado.Size = new Size(294, 23);
            cbbHabilitado.TabIndex = 27;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.White;
            label14.ForeColor = Color.Black;
            label14.Location = new Point(435, 59);
            label14.Name = "label14";
            label14.Size = new Size(65, 15);
            label14.TabIndex = 26;
            label14.Text = "Habilitado:";
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
            // tabNuevo
            // 
            tabNuevo.Controls.Add(label10);
            tabNuevo.Controls.Add(txbCantidadNuevo);
            tabNuevo.Controls.Add(txbPrecioVentaNuevo);
            tabNuevo.Controls.Add(txbPrecioCompraNuevo);
            tabNuevo.Controls.Add(txbDescripcionNuevo);
            tabNuevo.Controls.Add(txbCodigoNuevo);
            tabNuevo.Controls.Add(label9);
            tabNuevo.Controls.Add(label8);
            tabNuevo.Controls.Add(label7);
            tabNuevo.Controls.Add(btnGuardarNuevo);
            tabNuevo.Controls.Add(btnVolverNuevo);
            tabNuevo.Controls.Add(cbbCategoriaNuevo);
            tabNuevo.Controls.Add(label3);
            tabNuevo.Controls.Add(label2);
            tabNuevo.Location = new Point(4, 24);
            tabNuevo.Name = "tabNuevo";
            tabNuevo.Padding = new Padding(3);
            tabNuevo.Size = new Size(732, 316);
            tabNuevo.TabIndex = 1;
            tabNuevo.Text = "Nuevo";
            tabNuevo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.ForeColor = Color.Black;
            label10.Location = new Point(432, 15);
            label10.Name = "label10";
            label10.Size = new Size(58, 15);
            label10.TabIndex = 13;
            label10.Text = "Cantidad:";
            // 
            // txbCantidadNuevo
            // 
            txbCantidadNuevo.Location = new Point(432, 31);
            txbCantidadNuevo.Name = "txbCantidadNuevo";
            txbCantidadNuevo.Size = new Size(294, 23);
            txbCantidadNuevo.TabIndex = 12;
            // 
            // txbPrecioVentaNuevo
            // 
            txbPrecioVentaNuevo.Location = new Point(6, 248);
            txbPrecioVentaNuevo.Name = "txbPrecioVentaNuevo";
            txbPrecioVentaNuevo.Size = new Size(364, 23);
            txbPrecioVentaNuevo.TabIndex = 11;
            // 
            // txbPrecioCompraNuevo
            // 
            txbPrecioCompraNuevo.Location = new Point(6, 193);
            txbPrecioCompraNuevo.Name = "txbPrecioCompraNuevo";
            txbPrecioCompraNuevo.Size = new Size(364, 23);
            txbPrecioCompraNuevo.TabIndex = 9;
            // 
            // txbDescripcionNuevo
            // 
            txbDescripcionNuevo.Location = new Point(6, 138);
            txbDescripcionNuevo.Name = "txbDescripcionNuevo";
            txbDescripcionNuevo.Size = new Size(364, 23);
            txbDescripcionNuevo.TabIndex = 7;
            // 
            // txbCodigoNuevo
            // 
            txbCodigoNuevo.Location = new Point(6, 83);
            txbCodigoNuevo.Name = "txbCodigoNuevo";
            txbCodigoNuevo.Size = new Size(364, 23);
            txbCodigoNuevo.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.ForeColor = Color.Black;
            label9.Location = new Point(9, 233);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 10;
            label9.Text = "Precio Venta:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.ForeColor = Color.Black;
            label8.Location = new Point(9, 178);
            label8.Name = "label8";
            label8.Size = new Size(89, 15);
            label8.TabIndex = 8;
            label8.Text = "Precio Compra:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(9, 123);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 6;
            label7.Text = "Descripcion";
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
            // cbbCategoriaNuevo
            // 
            cbbCategoriaNuevo.Cursor = Cursors.Hand;
            cbbCategoriaNuevo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbCategoriaNuevo.FormattingEnabled = true;
            cbbCategoriaNuevo.Location = new Point(6, 30);
            cbbCategoriaNuevo.Name = "cbbCategoriaNuevo";
            cbbCategoriaNuevo.Size = new Size(364, 23);
            cbbCategoriaNuevo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(9, 15);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 2;
            label3.Text = "Categoria:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(9, 68);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 0;
            label2.Text = "Codigo:";
            // 
            // tabLista
            // 
            tabLista.Controls.Add(dgvProductos);
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
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(6, 35);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(720, 275);
            dgvProductos.TabIndex = 3;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
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
            // frmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 407);
            Controls.Add(label1);
            Controls.Add(tabControlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProducto";
            Load += frmProducto_Load;
            tabEditar.ResumeLayout(false);
            tabEditar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadEditar).EndInit();
            tabNuevo.ResumeLayout(false);
            tabNuevo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txbCantidadNuevo).EndInit();
            tabLista.ResumeLayout(false);
            tabLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            tabControlMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabPage tabEditar;
        private Button btnGuardarEditar;
        private Button btnVolverEditar;
        private TabPage tabNuevo;
        private Label label10;
        private NumericUpDown txbCantidadNuevo;
        private TextBox txbPrecioVentaNuevo;
        private TextBox txbPrecioCompraNuevo;
        private TextBox txbDescripcionNuevo;
        private TextBox txbCodigoNuevo;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnGuardarNuevo;
        private Button btnVolverNuevo;
        private ComboBox cbbCategoriaNuevo;
        private Label label3;
        private Label label2;
        private TabPage tabLista;
        private DataGridView dgvProductos;
        private Button btnBuscar;
        private TextBox txbBuscar;
        private Button btnNuevoLista;
        private TabControl tabControlMain;
        private ComboBox cbbHabilitado;
        private Label label14;
        private Label label4;
        private NumericUpDown txbCantidadEditar;
        private TextBox txbPrecioVentaEditar;
        private TextBox txbPrecioCompraEditar;
        private TextBox txbDescripcionEditar;
        private TextBox txbCodigoEditar;
        private Label label5;
        private Label label6;
        private Label label11;
        private ComboBox cbbCategoriaEditar;
        private Label label12;
        private Label label13;
    }
}