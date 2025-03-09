using Microsoft.Extensions.DependencyInjection;
using SFPresentation.Utilidades;
using SFPresentation.ViewModels;
using SFRepository.Entities;
using SFServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFPresentation.Formularios
{
    public partial class frmHistorial : Form
    {
        private readonly IVentaService _ventaService;
        private readonly IServiceProvider _serviceProvider;
        public frmHistorial(IServiceProvider serviceProvider, IVentaService ventaService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _ventaService = ventaService;
        }

        private async Task MostrarVenta()
        {
            var listaVenta = await _ventaService.Lista(
                 dtpFechaInicio.Value.ToString("dd/MM/yyyy"),
                 dtpFechaFin.Value.ToString("dd/MM/yyyy"),
                 txbEncontrar.Text.Trim()
            );

            foreach (var item in listaVenta)
            {
                Console.WriteLine($"Fecha en SQL: {item.FechaRegistro}");
            }

            var listaVM = listaVenta.Select(item => new VentaVM
            {
                FechaRegistro = item.FechaRegistro, 
                NumeroVenta = item.NumeroVenta,
                Usuario = item.usuarioRegistro.NombreUsuario,
                Cliente = item.NombreCliente,
                Total = item.PrecioTotal,
            }).ToList();

            dgvVenta.DataSource = listaVM;
            dgvVenta.Columns["FechaRegistro"].Visible = false;
        }


        private void frmHistorial_Load(object sender, EventArgs e)
        {
            dgvVenta.ImplementarConfiguracion("Ver");
            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await MostrarVenta();
        }

        private void dgvVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVenta.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var filaSeleccionada = (VentaVM)dgvVenta.CurrentRow.DataBoundItem;

                var _formDetalle = _serviceProvider.GetRequiredService<frmDetalleVenta>();
                _formDetalle._numeroVenta = filaSeleccionada.NumeroVenta;
                _formDetalle.ShowDialog();
            }
        }
    }
}
