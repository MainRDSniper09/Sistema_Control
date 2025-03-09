namespace SFPresentation.Formularios
{
    partial class frmBuscarProducto
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
            dgvProductos = new DataGridView();
            btnBuscar = new Button();
            txbBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 34);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(720, 275);
            dgvProductos.TabIndex = 6;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.Black;
            btnBuscar.Location = new Point(657, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txbBuscar
            // 
            txbBuscar.Location = new Point(12, 5);
            txbBuscar.Name = "txbBuscar";
            txbBuscar.Size = new Size(625, 23);
            txbBuscar.TabIndex = 4;
            // 
            // frmBuscarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(739, 317);
            Controls.Add(dgvProductos);
            Controls.Add(btnBuscar);
            Controls.Add(txbBuscar);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MaximumSize = new Size(759, 360);
            MinimizeBox = false;
            MinimumSize = new Size(759, 360);
            Name = "frmBuscarProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Buscar Producto";
            Load += frmBuscarProducto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProductos;
        private Button btnBuscar;
        private TextBox txbBuscar;
    }
}