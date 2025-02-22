using SFPresentation.ViewModels;
using SFServices.Interfaces;
using SFPresentation.Utilidades;
using System.Data;
using SFPresentation.Utilidades.Objetos;
using SFRepository.Entities;

namespace SFPresentation.Formularios
{
    public partial class frmCategoria : Form
    {
        private readonly IMedidaService _medidaService;
        private readonly ICategoriaService _categoriaService;
        public frmCategoria(ICategoriaService categoriaService, IMedidaService medidaService)
        {
            _categoriaService = categoriaService;
            _medidaService = medidaService;
            InitializeComponent();
        }

        // Metodo para eliminar los tabs
        public void MostarTab(string tabName)
        {
            var TabsMenu = new TabPage[]
            {
                tabLista,tabNuevo,tabEditar
            };

            foreach (var tab in TabsMenu)
            {
                if (tab.Name != tabName)
                {
                    tab.Parent = null;
                }
                else
                {
                    tab.Parent = tabControlMain;
                }
            }
        }

        private async Task MostrarCategorias(string buscar = "")
        {
            var listacategorias = await _categoriaService.Lista(buscar);
            var listaVM = listacategorias.Select(item => new CategoriaVM
            {
                IdCategoria = item.IdCategoria,
                Nombre = item.Nombre,
                IdMedida = item.RefMedida.IdMedida.ToString(),
                Medida = item.RefMedida.Nombre,
                Activo = item.Activo,
                Habilitado = item.Activo == 1 ? "Si" : "No",

            }).ToList();

            dgvCategorias.DataSource = listaVM;
            dgvCategorias.Columns["IdCategoria"].Visible = false;
            dgvCategorias.Columns["IdMedida"].Visible = false;
            dgvCategorias.Columns["Activo"].Visible = false;
        }
        private async void frmCategoria_Load(object sender, EventArgs e)
        {
            MostarTab(tabLista.Name);
            dgvCategorias.ImplementarConfiguracion("Editar"); // Mandamos a llamar nuestra configuracion previamente realizada
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ocupa todo nuestro cuadro hasta el final 
            await MostrarCategorias();

            OpcionCombo[] itemsHabilitado = new OpcionCombo[]
            {
                new OpcionCombo{Texto = "Si", Valor = 1},
                new OpcionCombo{Texto = "No", Valor = 0},
            };
            var listaMedida = await _medidaService.Lista();
            var items = listaMedida.Select(item => new OpcionCombo { Texto = item.Nombre, Valor = item.IdMedida }).ToArray();

            cbbMedidaNuevo.InsertarItems(items);
            cbbMedidaEditar.InsertarItems(items);

            cbbHabilitado.InsertarItems(itemsHabilitado);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarCategorias(txbBuscar.Text); // Funcion para buscar 
        }

        private void btnNuevoLista_Click(object sender, EventArgs e)
        {
            txbNombreNuevo.Text = "";
            cbbMedidaNuevo.SelectedIndex = 0;
            txbNombreNuevo.Select();
            MostarTab(tabNuevo.Name); // Mostamos unicamente el Tab en el que estemos dentro 
        }

        private void btnVolverEditar_Click(object sender, EventArgs e)
        {
            MostarTab(tabLista.Name);
        }

        private void btnVolverNuevo_Click(object sender, EventArgs e)
        {
            MostarTab(tabLista.Name);
        }

        private async void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (txbNombreNuevo.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre");
                return;
            }
            var item = (OpcionCombo)cbbMedidaNuevo.SelectedItem!;
            var objeto = new Categoria
            {
                Nombre = txbNombreNuevo.Text.Trim(),
                RefMedida = new Medida
                {
                    IdMedida = item.Valor
                }
            };
            var respuesta = await _categoriaService.Crear(objeto);
            if (!string.IsNullOrEmpty(respuesta))
            {
                MessageBox.Show("Error al guardar: " + respuesta);
            }
            else
            {
                MessageBox.Show("Categoría guardada correctamente");
                await MostrarCategorias();
                MostarTab(tabLista.Name);
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategorias.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var categoriaSeleccionada = (CategoriaVM)dgvCategorias.CurrentRow.DataBoundItem;

                txbNombreEditar.Text = categoriaSeleccionada.Nombre.ToString();

                cbbMedidaEditar.EstablecerValor(int.Parse(categoriaSeleccionada.IdMedida)); // Convert string to int
                cbbHabilitado.EstablecerValor(categoriaSeleccionada.Activo);

                MostarTab(tabEditar.Name);
                txbNombreEditar.Select();
            }
        }

        private async void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            if (txbNombreEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar el nombre");
                return;
            }
            var categoriaSeleccionada = (CategoriaVM)dgvCategorias.CurrentRow.DataBoundItem;
            var objeto = new Categoria
            {
                IdCategoria = categoriaSeleccionada.IdCategoria,
                Nombre = txbNombreEditar.Text.Trim(),
                RefMedida = new Medida
                {
                    IdMedida = ((OpcionCombo)cbbMedidaEditar.SelectedItem!).Valor
                },
                Activo = ((OpcionCombo)cbbHabilitado.SelectedItem!).Valor,
            };
            var respuesta = await _categoriaService.Editar(objeto);
            if (!string.IsNullOrEmpty(respuesta))
            {
                MessageBox.Show("Error al guardar: " + respuesta);
            }
            else
            {
                MessageBox.Show("Categoría guardada correctamente");
                await MostrarCategorias();
                MostarTab(tabLista.Name);
            }
        }
    }
}
